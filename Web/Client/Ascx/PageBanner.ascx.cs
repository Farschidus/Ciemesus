using BLL.BusinessEntity;
using System;
using System.Text;
using System.Web.UI;

public partial class Client_Ascx_PageBanner : UserControl
{
    public Subjects Subject
    {
        get
        {
            Subjects subjects = new Subjects();
            if (ViewState["BannerSubject"] == null)
            {
                return null;
            }
            else
            {
                subjects.Deserialize(ViewState["BannerSubject"].ToString());
            }
            return subjects;
        }
        set
        {
            ViewState["BannerSubject"] = value.Serialize();
            Subjects.BannerTypes bannerType = Subjects.BannerTypes.inActive;

            Subjects subject = new Subjects(Subject.pIDSubject);
            if (!string.IsNullOrEmpty(subject.pBannerType))
                bannerType = (Subjects.BannerTypes)Enum.Parse(typeof(Subjects.BannerTypes), subject.pBannerType);
            mInitializing(bannerType);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private void mInitializing(Subjects.BannerTypes bannerType)
    {
        switch (bannerType)
        {
            case Subjects.BannerTypes.inActive:
                {
                    imgPageBanner.Visible = false;
                    rptGallery.Visible = false;
                    break;
                }
            case Subjects.BannerTypes.picture:
                {
                    imgPageBanner.Visible = true;
                    rptGallery.Visible = false;

                    MediaSubjects mediaSubject = new MediaSubjects();
                    mediaSubject.LoadByIDSubjectAndIDMediaSubjectType(Subject.pIDSubject, (byte)MediaSubjectTypes.Enum.headerImage);
                    if (mediaSubject.RowCount > 0)
                    {
                        string strImageDestinationFolder = Global.Constants.FOLDER_MEDIAS;
                        string[] files = System.IO.Directory.GetFiles(MapPath(strImageDestinationFolder), mediaSubject.pIDMedia.ToString() + ".*");
                        if (files.Length > 0)
                            imgPageBanner.ImageUrl = string.Format("{0}{1}", Global.Constants.FOLDER_MEDIAS.Substring(1), System.IO.Path.GetFileName(files[0]));
                    }
                    break;
                }
            case Subjects.BannerTypes.gallery:
                {
                    imgPageBanner.Visible = false;
                    rptGallery.Visible = true;

                    Subjects subjectGallery = new Subjects(Subject.pIDGallery);
                    if (subjectGallery.RowCount > 0)
                    {
                        MediaSubjects mediaSubjects = new MediaSubjects
                        {
                            Sort = MediaSubjects.ColumnNames.Priority
                        };
                        mediaSubjects.LoadByIDSubjectAndIDMediaSubjectType(subjectGallery.pIDSubject, (byte)MediaSubjectTypes.Enum.gallery);
                        
                        if (mediaSubjects.RowCount > 0)
                        {
                            System.Data.DataColumn dc = mediaSubjects.AddColumn("FilePath", Type.GetType("System.String"));
                            do
                            {
                                string[] files = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_MEDIAS), mediaSubjects.pIDMedia.ToString() + ".*");
                                if (files.Length > 0)
                                {
                                    mediaSubjects.SetColumn("FilePath", Global.Constants.FOLDER_MEDIAS.Substring(1) + System.IO.Path.GetFileName(files[0]));
                                }
                            }
                            while (mediaSubjects.MoveNext());
                            mSetGalleryScript();

                            rptGallery.DataSource = mediaSubjects.DefaultView;
                            rptGallery.DataBind();
                        }
                    }
                    break;
                }
        }
        uplBanner.Update();
    }
    private void mSetGalleryScript()
    {
        if (Subject != null && Subject.pBannerType == Subjects.BannerTypes.gallery.ToString())
        {
            GalleryPlugins galleryPlugin = new GalleryPlugins();
            galleryPlugin.LoadByIDSubject(Subject.pIDSubject);
            if (galleryPlugin.RowCount > 0)
            {
                //Javascript
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), galleryPlugin.Plugins.pJSfileName, string.Format("{0}{1}", Global.Constants.FOLDER_PLUGINS.Substring(1), galleryPlugin.Plugins.pJSfileName));
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), galleryPlugin.Plugins.pName, galleryPlugin.Plugins.pJSinit.Replace("#options#", galleryPlugin.pOptions), true);
                //Cascade Style Sheet
                StringBuilder sb = new StringBuilder();
                sb.Append("<style type='text/css' rel='stylesheet'>");
                sb.Append(galleryPlugin.pCSS);
                sb.Append("</style>");
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), galleryPlugin.Plugins.pName + "CSS", sb.ToString(), false);
                litCSS.Text = sb.ToString();
            }
        }
    }

    public string mGenerateImageInfo(string filename, string description, DateTime date)
    {
        GalleryPlugins galleryPlugin = new GalleryPlugins();
        galleryPlugin.LoadByIDSubject(Subject.pIDSubject);

        StringBuilder sb = new StringBuilder();

        if (galleryPlugin.pGenerateTitle || galleryPlugin.pGenerateDesc || galleryPlugin.pGenerateDate)
        {
            sb.Append("<div class='carousel-caption d-none d-md-block'>");

            if (galleryPlugin.pGenerateTitle)
                sb.Append("<h5>" + filename + "</h5>");
            if (galleryPlugin.pGenerateDesc)
                sb.Append("<p>" + description + "</p>");
            if (galleryPlugin.pGenerateDate)
                sb.Append("<p>" + date.ToString(galleryPlugin.pDateFormat) + "</p>");

            sb.Append("</div>");
        }

        return sb.ToString();
    }
}