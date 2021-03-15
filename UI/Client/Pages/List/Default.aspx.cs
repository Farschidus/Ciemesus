using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_List_Default : BasePublic
{
    public byte pSubjectTypeID
    {
        get
        {
            return (byte)ViewState["pSubjectTypeID"];
        }
        set
        {
            ViewState["pSubjectTypeID"] = value;
        }
    }

    private Subjects pSubject
    {
        get
        {
            Subjects subjects = new Subjects();
            if (ViewState["pSubjects"] == null)
            {
                if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
                {
                    subjects.LoadBySubjectAliasAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), pCurrentLanguageID);
                    if (subjects.RowCount > 0)
                    {
                        ViewState["pSubjects"] = subjects.Serialize();
                    }
                }
                
            }
            subjects.Deserialize(ViewState["pSubjects"].ToString());
            return subjects;
        }
        set
        {
            ViewState["pSubjects"] = value.Serialize();
        }
    }
    private ListTypePage.Enum listType
    {
        get
        {
            ListTypePage.Enum result = ListTypePage.Enum.list;
            if (Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE] != null)
            {
                Enum.TryParse<ListTypePage.Enum>(Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE].ToString(), true, out result);
            }
            return result;
        }
        set
        {
            ViewState["listType"] = value;
        }
    }
    private string listItem
    {
        get
        {
            ListTypePage.Enum result = ListTypePage.Enum.list;
            if (Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE] != null)
            {
                Enum.TryParse<ListTypePage.Enum>(Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE].ToString(), true, out result);
            }
            System.Globalization.TextInfo TitleCase = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            return Farschidus.Configuration.ConfigurationManager.Settings.GetItemInnerText("ListType", TitleCase.ToTitleCase(result.ToString()));
        }
    } 
//    const string listItem = @"<div class='List-ItemDataGrid'>
//                        <a href='{0}'> 
//                          <img class='List-ItemImageGrid' src='{1}'></img>
//                          <div class='List-ItemBodyGrid'>{2}<br></div>
//                        </a>
//                      </div>";

    const string flashObject = @"<div id='Player' style='text-align: center'>
            <embed id='mpl' width='470' height='320' 
                flashvars='&file={2}?pvu={0}&pvt={1}&frontcolor=000000&lightcolor=003300&screencolor=000' 
                allowfullscreen='true' allowscriptaccess='always' quality='high' name='mpl' style='undefined' 
                src='{3}' type='application/x-shockwave-flash'>
            </embed>
        </div>";
    const string otherFiles = @"<li class='thumbItem'><a style='border:none;' data-lightbox='ImageGroups' rel='lightbox' href='{0}' >{1}</a></li>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInisializing();
        }
        else if (!string.IsNullOrEmpty(Request.Params["__EVENTARGUMENT"]))
        {
            mFillItemView(new Guid(Request.Params["__EVENTARGUMENT"]));
        }
    }
    private void mInisializing()
    {
        if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
        {
            Subjects subjects = new Subjects();
            subjects.LoadBySubjectAliasAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), pCurrentLanguageID);
            if (subjects.RowCount > 0)
            {
                litPageTitle.Text = pTitle = subjects.pTitle;
                litBody.Text = subjects.pBody;
                pageBanner.Subject = subjects;
                pagePluginForList.SubjectID = subjects.pIDSubject;
                mListBinding(subjects.pIDSubject);

                ListTypePage.Enum aa = listType;
            }
            else
            {
                litBody.Text = Farschidus.Translator.AppTranslate["general.message.pageNotExist"];
            }
        }
    }
    private void mListBinding(Guid parentID)
    {
        Subjects subjects = new Subjects();
        subjects.LoadByIDParentAndIDSubjectTypeAndIDLanguage(parentID, (byte)SubjectTypes.Enum.listItem, pCurrentLanguageID, true);
        subjects.Sort = Subjects.ColumnNames.Priority;
        if (subjects.RowCount > 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='ListRepeator'>");
            do
            {
                sb.Append(string.Format(listItem, mGenerateURL(subjects.pIDSubject), mGetCoverImage(subjects.pIDSubject.ToString()), subjects.pTitle, Global.MethodsAndProps.mGetLimitedString(100, Global.MethodsAndProps.mCleanHtmlTags(subjects.pBody))));
            }
            while (subjects.MoveNext());
            sb.Append("</div>");
            litBody.Text = sb.ToString();
        }
    }
    private void mFillItemView(Guid subjectID)
    {
        Subjects item = new Subjects(subjectID);
        
        if (item.RowCount > 0)
        {
            litItemTitle.Text = item.pTitle;
            litItemBody.Text = item.pBody;
            itemBanner.Subject = item;
            pagePlugin1.SubjectID = item.pIDSubject;
            litCoverImage.Text = string.Format("<img class='itemCoverImage' src='{0}' />", mGetCoverImage(item.pIDSubject.ToString()));
        }
        else
        {
            litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
        }
        uplItemView.Update();
    }

    private void mLoadMedias(Subjects Subject)
    {
        StringBuilder sb = new StringBuilder();
        MediaSubjects medias = new MediaSubjects();
        medias.LoadByIDSubjectAndIDMediaSubjectType(Subject.pIDSubject, (byte)MediaSubjectTypes.Enum.attachment);
        if (medias.RowCount > 0)
        {
            medias.Sort = MediaSubjects.ColumnNames.Priority;
            sb.Append("<ul class='thumbItems'>");
            do
            {
                string fileUrl, Thumbnail = string.Empty;
                if (medias.pFileExtention.Contains("flv"))
                {
                    fileUrl = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_MEDIAS), medias.pIDMedia.ToString() + medias.pFileExtention)[0];
                    sb.Append(string.Format(flashObject, fileUrl, medias.pFileName, Global.Constants.FOLDER_VIDEOPLAYER.Substring(1), Global.Constants.FILE_PLAYER_SWF.Substring(1)));
                }
                else
                {
                    fileUrl = string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), medias.pIDMedia.ToString(), medias.pFileExtention);
                    Thumbnail = string.Format("<img src='{0}{1}{2}' width='150px' height='150px' />", Global.Constants.FOLDER_THUMBS.Substring(1), medias.pIDMedia.ToString(), medias.pFileExtention);
                    sb.Append(string.Format(otherFiles, fileUrl, Thumbnail));
                }
            }
            while (medias.MoveNext());
            sb.Append("</ul>");
        }
        else
        {
            sb.Append("");
        }
        litAttachments.Text = sb.ToString();
    }
    private string mGenerateURL(Guid iDSubject)
    {
        // return string.Format(@"javascript:__doPostBack(""{0}"", ""{1}"")", uplItemView.ClientID, iDSubject);
        Subjects item = new Subjects(iDSubject);
        Languages lang = new Languages(item.pIDLanguage);
        return string.Format(Global.Constants.PAGE_LISTITEM_ASPX.Substring(1), lang.pCode, item.pAlias);
    }
    private void mLoadRecursivlyByParentID(ref List<int> propertyIDs, Guid subjectID)
    {
        Subjects subjects = new Subjects(subjectID);
        subjects.Sort = Subjects.ColumnNames.Priority;
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
}