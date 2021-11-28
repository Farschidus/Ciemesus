using BLL.BusinessEntity;
using System;
using System.Web.UI;

public partial class Client_Ascx_LatestList : UserControl
{
    private string itemClass;
    public string ItemClass
    {
        get
        {
            return itemClass;
        }
        set
        {
            itemClass = value;
        }
    }

    private bool showDate;
    public bool ShowDate
    {
        get
        {
            return showDate;
        }
        set
        {
            showDate = value;
        }
    }

    private bool showCoverImg;
    public bool ShowCoverImg
    {
        get
        {
            return showCoverImg;
        }
        set
        {
            showCoverImg = value;
        }
    }
    
    private bool showDescription;
    public bool ShowDescription
    {
        get
        {
            return showDescription;
        }
        set
        {
            showDescription = value;
        }
    }

    private byte limit;
    public byte Limit
    {
        get
        {
            return limit;
        }
        set
        {
            limit = value;
        }
    }

    private string subjectType;
    public string SubjectType
    {
        get
        {
            return subjectType;
        }
        set
        {
            subjectType = value;
        }
    }

    private string title;
    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = Farschidus.Translator.AppTranslate[value];
        }
    }

    private Global.Constants.ListTypeStyle listTypeLink;
    public Global.Constants.ListTypeStyle ListTypeLink
    {
        get
        {
            return listTypeLink;
        }
        set
        {
            listTypeLink = value;
        }
    }

    private byte language;
    private Guid subjectID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInitialBindings();
        }
    }

    private void mInitialBindings()
    {
        if (mFindSubject())
            mLoadAll();
    }
    private bool mFindSubject()
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        Subjects subject = new Subjects();
        string[] aliasArray = subjectType.Split(',');
        foreach (string alias in aliasArray)
        {
            subject.LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(alias, (byte)SubjectTypes.Enum.list, lang.pIDLanguage, true);
            if (subject.RowCount > 0)
            {
                language = subject.pIDLanguage;
                subjectID = subject.pIDSubject;
                subjectType = subject.pAlias;
                lblTitle.Text = subject.pTitle;
                return true;
            }
        }
        return false;
    }
    private void mLoadAll()
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        Subjects ListItems = new Subjects();
        ListItems.LoadByIDParent(subjectID);
        ListItems.Sort = Subjects.ColumnNames.Priority;

        Subjects result = new Subjects();
        for (int i = 0; i < limit; i++)
        {
            result.AddNew();
            result.pIDSubject = ListItems.pIDSubject;
            result.pTitle = ListItems.pTitle;
            result.pBody = ListItems.pBody;
            result.pDate = ListItems.pDate;
            result.pAlias = ListItems.pAlias;
            var moreItem = ListItems.MoveNext();
            if (!moreItem) break;
        }

        rptSidebar.DataSource = result.DefaultView;
        rptSidebar.DataBind();
    }
    public string mGetURL(string alias)
    {
        Languages lang = new Languages(language);
        // string url = string.Format(Global.Constants.PAGE_LISTITEM_ASPX.Substring(1), lang.pCode, alias);
        return string.Format("/{0}/Pages/List/{1}/{2}", lang.pCode, ListTypeLink.ToString(), alias);
    }
    public string mGetDate(DateTime dateTime)
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        return Global.MethodsAndProps.mToDate(dateTime, lang.pIDLanguage, "d MMMM yyyy");
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
    public string mGetDescription(string body, int stringLimit = 100)
    {
        return Global.MethodsAndProps.mGetLimitedString(stringLimit, Global.MethodsAndProps.mCleanHtmlTags(body));
    }
}