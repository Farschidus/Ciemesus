using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class ControlP_Banner_Popup : System.Web.UI.Page
{
    #region "Properties"

    private Guid pSubjectID;
    private byte pLanguageID;
    private byte pMediaSubjectTypeID;

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (!hdfData.Value.Equals(string.Empty))
            {
                string[] Data = hdfData.Value.Split('|');
                pSubjectID = new Guid(Data[0]);
                pLanguageID = Convert.ToByte(Data[1]);
                pMediaSubjectTypeID = (byte)MediaSubjectTypes.Enum.headerImage;
            }
            if (!hdfRefresh.Value.Equals("1000"))
            {
                hdfRefresh.Value = "1000";
                mPostbackBindings();
            }
        }
        else
        {
            mInitialBindings();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected void rblTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        mBindings();
        lblMessage.Text = string.Empty;
        uplAddEdit.Update();
    }
    protected void ddlGalleryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        mDDLGalleryBinding(null);
        uplAddEdit.Update();
    }
    protected void ddlPlugins_SelectedIndexChanged(object sender, EventArgs e)
    {
        mFillPluginFields(Convert.ToInt32(ddlPlugins.SelectedValue));
        uplAddEdit.Update();
    }

    protected void grvList_Select(object sender, CommandEventArgs e)
    {
        mDeleteMediaSubject();

        MediaSubjects mediaSubject = new MediaSubjects();
        mediaSubject.AddNew();
        mediaSubject.pIDMedia = Convert.ToInt32(e.CommandArgument);
        mediaSubject.pIDSubject = pSubjectID;
        mediaSubject.pIDMediaSubjectType = pMediaSubjectTypeID;
        mediaSubject.Save();

        mSave();
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        mLoadMedias();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        mLoadMedias();
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {
        BLL.Hardcodes.Tables tables = new BLL.Hardcodes.Tables();
        rblTypes.DataSource = tables.HeaderTypes;
        rblTypes.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        rblTypes.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        rblTypes.DataBind();    
    }
    private void mBindings()
    {
        Subjects.BannerTypes headerTypes = (Subjects.BannerTypes)Enum.Parse(typeof(Subjects.BannerTypes), rblTypes.SelectedValue);
        switch (headerTypes)
        {
            case Subjects.BannerTypes.inActive:
                {
                    trInActive.Visible = true;
                    trPicture.Visible = false;
                    trGallery.Visible = false;
                    btnSave.Visible = true;
                    break;
                }
            case Subjects.BannerTypes.picture:
                {
                    trInActive.Visible = false;
                    trPicture.Visible = true;
                    trGallery.Visible = false;
                    btnSave.Visible = false;
                    mLoadMedias();
                    mReloadImagePath();
                    break;
                }
            case Subjects.BannerTypes.gallery:
                {
                    trInActive.Visible = false;
                    trPicture.Visible = false;
                    trGallery.Visible = true;
                    btnSave.Visible = true;

                    BLL.Hardcodes.Tables tables = new BLL.Hardcodes.Tables();
                    ddlGalleryType.Items.Clear();
                    ddlGalleryType.DataSource = tables.GalleryTypes;
                    ddlGalleryType.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
                    ddlGalleryType.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
                    ddlGalleryType.DataBind();
                    mDDLGalleryBinding(null);

                    Plugins plugins = new Plugins();
                    plugins.LoadAll();
                    ddlPlugins.DataSource = plugins.DefaultView;
                    ddlPlugins.DataTextField = Plugins.ColumnNames.Name;
                    ddlPlugins.DataValueField = Plugins.ColumnNames.IDPlugin;
                    ddlPlugins.DataBind();
                    if (plugins.RowCount > 0)
                    {
                        GalleryPlugins galleryPlugin = new GalleryPlugins();
                        galleryPlugin.LoadByIDSubject(pSubjectID);
                        if (galleryPlugin.RowCount > 0)
                        {
                            ddlPlugins.SelectedValue = galleryPlugin.pIDPlugin.ToString();
                            mFillPluginFields(galleryPlugin.pIDPlugin);
                        }
                        else
                        {
                            mFillPluginFields(plugins.pIDPlugin);
                        }
                    }
                    break;
                }
        }
    }

    private void mFillPluginFields(int pluginID)
    {
        GalleryPlugins galleryPlugin = new GalleryPlugins(pSubjectID, pluginID);
        if (galleryPlugin.RowCount > 0)
        {
            ddlPlugins.SelectedValue = galleryPlugin.pIDPlugin.ToString();
            cbxGenerateTitle.Checked = galleryPlugin.pGenerateTitle;
            cbxGenerateDescription.Checked = galleryPlugin.pGenerateDesc;
            cbxGenerateAnchor.Checked = galleryPlugin.pGenerateAnchor;
            cbxGenerateDate.Checked = galleryPlugin.pGenerateDate;
            txtDateFormat.Text = galleryPlugin.pDateFormat;
            txtOptions.Text = galleryPlugin.pOptions;
            txtCSS.Text = galleryPlugin.pCSS;
        }
        else
        {
            Plugins plugin = new Plugins(Convert.ToInt32(ddlPlugins.SelectedValue));
            txtOptions.Text = plugin.pSettings;
            txtCSS.Text = plugin.pCss;
        }
    }
    private void mPostbackBindings()
    {
        if (!hdfData.Value.Equals(string.Empty))
        {            
            Subjects subjects = new Subjects(pSubjectID);
            if (!string.IsNullOrEmpty(subjects.pBannerType))
            {
                Subjects.BannerTypes headerTypes = (Subjects.BannerTypes)Enum.Parse(typeof(Subjects.BannerTypes), subjects.pBannerType);
                rblTypes.SelectedValue = ((byte)headerTypes).ToString();

                mBindings();

                if (headerTypes == Subjects.BannerTypes.gallery)
                    mDDLGalleryBinding(subjects.pIDGallery);
            }
            else
            {
                rblTypes.SelectedIndex = 0;
            } 
        }
    }
    private void mDDLGalleryBinding(Guid? headerGalleryID)
    {
        SubjectTypes.Enum galleryTypes = (SubjectTypes.Enum)Enum.Parse(typeof(SubjectTypes.Enum), ddlGalleryType.SelectedValue);

        Subjects subjects = new Subjects();

        subjects.LoadByIDSubjectTypeAndIDLanguage((byte)galleryTypes, pLanguageID);
        ddlGallery.Items.Clear();
        ddlGallery.DataSource = subjects.DefaultView;
        ddlGallery.DataTextField = Subjects.ColumnNames.Title;
        ddlGallery.DataValueField = Subjects.ColumnNames.IDSubject;
        ddlGallery.DataBind();
        if (headerGalleryID.HasValue)
            ddlGallery.SelectedValue = headerGalleryID.Value.ToString();
    }
    private void mSave()
    {
        try
        {
            Subjects.BannerTypes headerTypes = (Subjects.BannerTypes)Enum.Parse(typeof(Subjects.BannerTypes), rblTypes.SelectedValue);

            Subjects subjects = new Subjects(pSubjectID);
            subjects.pBannerType = headerTypes.ToString();

            switch (headerTypes)
            {
                case Subjects.BannerTypes.gallery:
                    subjects.pIDGallery = new Guid(ddlGallery.SelectedValue);
                    mSaveSubjectPlugin();
                    mDeleteMediaSubject();
                    break;
                case Subjects.BannerTypes.picture:
                    subjects.SetColumnNull(Subjects.ColumnNames.IDGallery);
                    mLoadMedias();
                    mReloadImagePath();
                    mDeleteSubjectPlugin();
                    break;
                case Subjects.BannerTypes.inActive:
                    subjects.SetColumnNull(Subjects.ColumnNames.IDGallery);
                    mDeleteSubjectPlugin();
                    mDeleteMediaSubject();
                    break;
            }


            subjects.Save();

            lblMessage.ForeColor = System.Drawing.Color.LightGreen;
            lblMessage.Text = Farschidus.Translator.AppTranslate["general.message.success"];
        }
        catch (Exception ex)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = ex.Message;
        }
    }

    private void mSaveSubjectPlugin()
    {
        int pluginID = Convert.ToInt32(ddlPlugins.SelectedValue);

        GalleryPlugins galleryPlugin = new GalleryPlugins(pSubjectID, pluginID);
        if (galleryPlugin.RowCount > 0)
        {
            // in Edit Mode, so do nothing.
        }
        else
        {
            mDeleteSubjectPlugin();
            galleryPlugin.AddNew();
            galleryPlugin.pIDSubject = pSubjectID;
            galleryPlugin.pIDPlugin = pluginID;
        }

        galleryPlugin.pGenerateTitle = cbxGenerateTitle.Checked;
        galleryPlugin.pGenerateDesc = cbxGenerateDescription.Checked;
        galleryPlugin.pGenerateAnchor = cbxGenerateAnchor.Checked;
        galleryPlugin.pGenerateDate = cbxGenerateDate.Checked;
        galleryPlugin.pDateFormat = txtDateFormat.Text;
        galleryPlugin.pOptions = txtOptions.Text;
        galleryPlugin.pCSS = txtCSS.Text;

        galleryPlugin.Save();
    }
    private void mDeleteSubjectPlugin()
    {
        GalleryPlugins galleryPlugin = new GalleryPlugins();
        galleryPlugin.LoadByIDSubject(pSubjectID);
        galleryPlugin.MarkAsDeleted(false);
        galleryPlugin.Save();
    }
    private void mDeleteMediaSubject()
    {
        MediaSubjects mediaSubject = new MediaSubjects();
        mediaSubject.LoadByIDSubjectAndIDMediaSubjectType(pSubjectID, pMediaSubjectTypeID);
        if (mediaSubject.RowCount > 0)
        {
            mediaSubject.MarkAsDeleted(false);
            mediaSubject.Save();
        }
    }
    private void mLoadMedias()
    {
        int itemCount = 0;

        Medias medias = new Medias();
        medias.loadAllImages(Pager.CurrentIndex - 1, Pager.PageSize, ref itemCount, null);

        Pager.ItemCount = itemCount;

        grvList.DataSource = medias.DefaultView;
        grvList.DataBind();
    }
    private void mReloadImagePath()
    {
        MediaSubjects mediaSubjects = new MediaSubjects();
        mediaSubjects.LoadByIDSubjectAndIDMediaSubjectType(pSubjectID, pMediaSubjectTypeID);
        if (mediaSubjects.RowCount > 0)
        {
            string[] imageFile = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_MEDIAS), mediaSubjects.pIDMedia.ToString() + ".*");
            if (imageFile.Length > 0)
            {
                litImage.Text = string.Format(@"<a href='javascript:void(0)' onclick=""window.open('/{0}?{1}', 'Banner Image', 'height=515,width=990,top=120,left=10,scrollbars=yes,resizable=yes')"">{2}</a>",
                    Global.Constants.FOLDER_MEDIAS.Substring(2) + System.IO.Path.GetFileName(imageFile[0]),
                    DateTime.Now.ToString(),
                    Farschidus.Translator.AppTranslate["ascx.media.popupLinks.title"]);
            }
        }
    }

    #endregion

    #region "Public Methodes"

    public string mCheckMediaSebject(int mediaID)
    {
        MediaSubjects mediaSubjects = new MediaSubjects(mediaID, pSubjectID, pMediaSubjectTypeID);
        if (mediaSubjects.RowCount > 0)
            return Global.Constants.HTML_IMAGE_CHECK;
        else
            return Global.Constants.HTML_IMAGE_ERROR;
    }

    #endregion
}