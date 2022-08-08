using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_GalleryList : System.Web.UI.UserControl
{
    private Gallery.Types galleryType;
    public Gallery.Types GalleryType
    {
        get
        {
            return galleryType;
        }
        set
        {
            galleryType = value;
        }
    }

    private byte language;
    public byte Language
    {
        get
        {
            return language;
        }
        set
        {
            language = value;
        }
    }

    private string categoryID;
    public string CategoryID
    {
        get
        {
            return categoryID;
        }
        set
        {
            categoryID = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInitialBindings();
        }
    }

    private void mInitialBindings()
    {
        mLoadAll();
    }
    private void mLoadAll()
    {
        Subjects subject = new Subjects();
        if (!string.IsNullOrEmpty(categoryID))
            subject.LoadByIDParentAndIDSubjectTypeAndIDLanguage(new Guid(categoryID), (byte)galleryType, language, true);
        else
            subject.LoadByIDSubjectTypeAndIDLanguage((byte)galleryType, language);
        if (subject.RowCount > 0)
        {
            subject.Sort = Subjects.ColumnNames.Priority;
            rptGalleryBar.DataSource = subject.DefaultView;
            rptGalleryBar.DataBind();
        }
    }
    public string mGetURL(object alias)
    {
        Languages lang = new Languages(language);
        string url = string.Format("/{0}/{1}/Gallery/{2}", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, alias.ToString());
        return url;
    }
    public string mGetCoverImage(object IDSubject)
    {
        string imageUrl = string.Empty;
        MediaSubjects media = new MediaSubjects();
        media.LoadByIDSubjectAndIDMediaSubjectType(new Guid(IDSubject.ToString()), (byte)MediaSubjectTypes.Enum.thumbnail);
        if (media.RowCount > 0)
        {
            imageUrl = string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), media.Medias.pIDMedia.ToString(), media.Medias.pFileExtention);
        }
        return imageUrl;
    }
}