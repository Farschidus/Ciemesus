using BLL.BusinessEntity;
using System;
using System.Web.UI;

public partial class Client_Ascx_PageBodyGallery : UserControl
{
    public Subjects Subject
    {
        get
        {
            Subjects content = new Subjects();
            if (ViewState["PageBodyGallerySubject"] == null)
            {
                return null;
            }
            else
            {
                content.Deserialize(ViewState["PageBodyGallerySubject"].ToString());
            }
            return content;
        }
        set
        {
            ViewState["PageBodyGallerySubject"] = value.Serialize();
            mInitializing();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string mGetUrl(string mediaID, string extention)
    {
        return string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), mediaID, extention);
    }
    private void mInitializing()
    {
        MediaSubjects medias = new MediaSubjects();
        medias.LoadByIDSubjectAndIDMediaSubjectType(Subject.pIDSubject, (byte)MediaSubjectTypes.Enum.imageAttachment);
        if (medias.RowCount > 0)
        {
            rptMedia.Visible = true;
            medias.Sort = MediaSubjects.ColumnNames.Priority;
            rptMedia.DataSource = medias.DefaultView;
            rptMedia.DataBind();
        }
        else
        {
            rptMedia.Visible = false;
        }
        uplMedia.Update();
    }
}