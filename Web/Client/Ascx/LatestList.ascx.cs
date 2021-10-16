using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_LatestList : System.Web.UI.UserControl
{
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
            result.pAlias = ListItems.pAlias;
            ListItems.MoveNext();
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
}