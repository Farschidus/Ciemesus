using BLL.BusinessEntity;
using System;
using System.Text;
using System.Web.UI;

public partial class Client_Ascx_ListGroups : UserControl
{
    private string listAliasName;
    public string ListAliasName
    {
        get
        {
            return listAliasName;
        }
        set
        {
            listAliasName = value;
            mInitialBindings();
        }
    }

    private bool generateListItems;
    public bool GenerateListItems
    {
        get
        {
            return generateListItems;
        }
        set
        {
            generateListItems = value;
        }
    }

    private bool generateAjaxUrl;
    public bool GenerateAjaxUrl
    {
        get
        {
            return generateAjaxUrl;
        }
        set
        {
            generateAjaxUrl = value;
        }
    }

    private string updatePaneClientID;
    public string UpdatePaneClientID
    {
        get
        {
            return updatePaneClientID;
        }
        set
        {
            updatePaneClientID = value;
        }
    }

    private byte language;
    private Guid subjectID;
    const string item =
@"<div class='col-xs-6 col-sm-4'>
    <a href='{0}'>
        <img src='{1}' class='itemImage img-responsive' />
        <span class='item-title' style='display:none;'>{2}</span>
    </a>
</div>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInitialBindings();
        }
    }

    private void mInitialBindings()
    {
        if(mFindSubject())
            mLoadItems();
    }
    private bool mFindSubject()
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        Subjects subject = new Subjects();
        string[] aliasArray = listAliasName.Split(',');
        foreach (string alias in aliasArray)
        {
            subject.LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(alias, (byte)SubjectTypes.Enum.list, lang.pIDLanguage, true);
            if (subject.RowCount > 0)
            {
                language = subject.pIDLanguage;
                subjectID = subject.pIDSubject;
                listAliasName = alias;
                return true;
            }
        }
        return false;
    }
    private void mLoadItems()
    {
        StringBuilder sb = new StringBuilder();
        Subjects ListItems = new Subjects
        {
            Sort = Subjects.ColumnNames.Priority
        };
        ListItems.LoadByIDParentAndIDLanguage(subjectID, language);

        MediaSubjects medias = new MediaSubjects();
        int columnCounter = 1;
        do
        {
            if (columnCounter == 1)
                sb.Append("<div class='row'>");

            medias.LoadByIDSubjectAndIDMediaSubjectType(ListItems.pIDSubject, (byte)MediaSubjectTypes.Enum.thumbnail);
            if (medias.RowCount > 0)
            {
                if(generateAjaxUrl)
                    sb.Append(string.Format(item, string.Format(@"javascript:__doPostBack(""{0}"", ""{1}"")", updatePaneClientID, ListItems.pIDSubject.ToString()), mGetImage(medias), ListItems.pTitle));
                else
                    sb.Append(string.Format(item, mGetURL(ListItems.pAlias), mGetImage(medias), ListItems.pTitle));
            }

            if (columnCounter == 3)
            {
                sb.Append("</div>");
                columnCounter = 0;
            }
            columnCounter++;
        }
        while (ListItems.MoveNext());

        litItems.Text = sb.ToString();
    }

    private string mGetURL(string alias)
    {
        Languages lang = new Languages(language);
        string url = string.Format(Global.Constants.PAGE_LISTITEM_ASPX.Substring(1), lang.pCode, alias);
        return url;
    }
    private string mGetImage(MediaSubjects media)
    {
        return string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), media.Medias.pIDMedia.ToString(), media.Medias.pFileExtention);
    }
    private string mGetDate(DateTime dateTime)
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        return Global.MethodsAndProps.mToDate(dateTime, lang.pIDLanguage, "d MMMM yyyy");
    }
}