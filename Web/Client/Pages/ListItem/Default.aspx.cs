using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_ListItem_Default : BasePublic
{
    private Guid? pIDSubject
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
            {
                Subjects subjects = new Subjects();
                subjects.LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), (byte)SubjectTypes.Enum.listItem, pCurrentLanguageID, true);
                if (subjects.RowCount > 0)
                {
                    pSubject = subjects;
                    return subjects.pIDSubject;
                }
            }
            return null;
        }
    }
    private Subjects pSubject;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (pIDSubject.HasValue)
            {
                if (pSubject.pIsActive)
                {
                    Languages lang = new Languages(pCurrentLanguageID);
                    litPageTitle.Text = pTitle = pSubject.pTitle;
                    //litBody.Text = string.Format("<img class='itemImage' src='{0}'></img>{1}", mGetCoverImage(pSubject.pIDSubject.ToString()), mGetThumbnails(pSubject.pIDSubject.ToString()), pSubject.pBody);
                    litBody.Text = pSubject.pBody;
                    pageBanner.Subject = pSubject;
                    //pageMedia.Subject = pSubject;
                    pagePlugin.SubjectID = pSubject.pIDSubject;
                }
                else
                    litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
            }
        }
    }
    public string mGetCoverImage(string IDSubject)
    {
        string result = "{0}{1}";
        MediaSubjects cover = new MediaSubjects();
        cover.LoadByIDSubjectAndIDMediaSubjectType(new Guid(IDSubject), (byte)MediaSubjectTypes.Enum.thumbnail);
        if (cover.RowCount > 0)
            result = string.Format(result, Global.Constants.FOLDER_MEDIAS.Substring(1), cover.pIDMedia + cover.pFileExtention);
        else
            result = string.Format(result, Global.Constants.IMAGE_NOAVAILABLE_SMALL, string.Empty);
        return result;
    }
    public string mGetThumbnails(string IDSubject)
    {
        StringBuilder result = new StringBuilder();
        string thumbItem = "<li><a href='{0}{1}{2}' rel='lightbox[Thumbnail]'><img src='{3}{4}{5}' style='width: 50px; height: 50px; border:1px solid #555; padding:5px'></a></li>";

        MediaSubjects ThumbNails = new MediaSubjects();
        ThumbNails.LoadByIDSubjectAndIDMediaSubjectType(new Guid(IDSubject), (byte)MediaSubjectTypes.Enum.attachment);
        if (ThumbNails.RowCount > 0)
        {
            result.Append("<ul id='Thumbnails' class='jcarousel-skin-tango'>");
            do
            {
                result.AppendFormat(thumbItem, Global.Constants.FOLDER_MEDIAS.Substring(1), ThumbNails.pIDMedia, ThumbNails.pFileExtention, Global.Constants.FOLDER_THUMBS.Substring(1), ThumbNails.pIDMedia, ThumbNails.pFileExtention);
            }
            while (ThumbNails.MoveNext());
            result.Append("</ul>");
        }
        return result.ToString();
    }
    private void mLoadRecursivlyByParentID(ref List<int> propertyIDs, Guid subjectID)
    {
        Subjects subjects = new Subjects(subjectID)
        {
            Sort = Subjects.ColumnNames.Priority
        };
        if (subjects.RowCount > 0)
        {
            do
            {
                if (subjects.SubjectProperties.RowCount > 0)
                {
                    do
                    {
                        propertyIDs.Add(subjects.SubjectProperties.pIDProperty);
                    }
                    while (subjects.SubjectProperties.MoveNext());
                }
                if (!subjects.IsColumnNull(Subjects.ColumnNames.IDParent))
                    mLoadRecursivlyByParentID(ref propertyIDs, subjects.pIDParent);
            }
            while (subjects.MoveNext());
        }
        else
        {
            propertyIDs.Add(subjects.SubjectProperties.pIDProperty);
        }
    }
}