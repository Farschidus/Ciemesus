using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_BreadcrumpGen : System.Web.UI.UserControl
{
    private const string URL = "/{0}/" + Global.Constants.STRING_PUBLIC_FOLDER_NAME + "/{1}/";
    private string divider = string.Format("<span class='breadDivider'>{0}</span>", Farschidus.Translator.AppTranslate["bredCrump.seperator"]);
    private const string home = "Home";
    private const string aliasTitlePlaceholder = "<span class='breadCurrent'>{0}</span>";
    private const string linkPlaceholder = "<a class='breadlink' href='{0}'>{1}</a>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            mInitializing();
    }

    private void mInitializing()
    {
        string currentLang = Global.MethodsAndProps.CurrentLanguageCode;
        StringBuilder sb = new StringBuilder();
        string[] url = Page.Request.RawUrl.Substring(1).Split('/');
        Global.Constants.Modules moduleName = (Global.Constants.Modules)Enum.Parse(typeof(Global.Constants.Modules), url[2]);
        string aliasName = string.Empty;
        string aliasTitle = string.Empty;
        string listName = string.Empty;
        string ListNameAliasForUrl = string.Empty;
        string galleryCategoryAliasForUrl = string.Empty;

        if (!moduleName.Equals(Global.Constants.Modules.Home) && !moduleName.Equals(Global.Constants.Modules.Contact))
        {
            aliasName = url[3];
            aliasTitle = mGetTitleByAlias(url[3], moduleName);
        }

        if (moduleName.Equals(Global.Constants.Modules.Home))
            sb.Append(string.Format(aliasTitlePlaceholder, Farschidus.Translator.AppTranslate["bredCrump.pages.home"]));
        else
        {
            sb.Append(string.Format(linkPlaceholder, string.Format(URL, Global.MethodsAndProps.CurrentLanguageCode, Global.Constants.Modules.Home), Farschidus.Translator.AppTranslate["bredCrump.pages.home"]));
            switch (moduleName)
            {
                case Global.Constants.Modules.Page:
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, aliasTitle));
                    break;
                case Global.Constants.Modules.PageList:
                case Global.Constants.Modules.List:
                    aliasName = url[4];
                    aliasTitle = mGetTitleByAlias(url[4], moduleName);
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, aliasTitle));
                    break;
                case Global.Constants.Modules.ListItem:
                    listName = mGetListNameByListItem(aliasName, ref ListNameAliasForUrl);
                    sb.Append(divider + string.Format(linkPlaceholder, string.Format(URL, currentLang, Global.Constants.Modules.List.ToString() + "/Grid") + ListNameAliasForUrl, listName));
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, aliasTitle));
                    break;
                case Global.Constants.Modules.Gallery:
                    string GalleryCategory = mGetGallerySubject(aliasName, ref galleryCategoryAliasForUrl);
                    listName = mGetListName(galleryCategoryAliasForUrl, ref ListNameAliasForUrl);
                    sb.Append(divider + string.Format(linkPlaceholder, string.Format(URL, currentLang, Global.Constants.Modules.List.ToString()) + ListNameAliasForUrl, listName));
                    sb.Append(divider + string.Format(linkPlaceholder, string.Format(URL, currentLang, Global.Constants.Modules.ListItem.ToString()) + galleryCategoryAliasForUrl, GalleryCategory));
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, aliasTitle));
                    break;
                case Global.Constants.Modules.Search:
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, Farschidus.Translator.AppTranslate["bredCrump.pages.search"]));
                    break;
                case Global.Constants.Modules.Contact:
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, Farschidus.Translator.AppTranslate["bredCrump.pages.contact"]));
                    break;
                case Global.Constants.Modules.Compare:
                    sb.Append(divider + string.Format(aliasTitlePlaceholder, Farschidus.Translator.AppTranslate["bredCrump.pages.compare"]));
                    break;
            }
        }
        litBreadcrump.Text = sb.ToString();
    }
    private string mGetTitleByAlias(string alias, Global.Constants.Modules moduleName)
    {
        byte subjectType = 0;
        string output = string.Empty;
        switch (moduleName)
        {
            case Global.Constants.Modules.Page:
            case Global.Constants.Modules.PageList:
                subjectType = (byte)SubjectTypes.Enum.page;
                break;
            case Global.Constants.Modules.List:
            case Global.Constants.Modules.ListItem:
                subjectType = (byte)SubjectTypes.Enum.list;
                break;
            case Global.Constants.Modules.Gallery:
                subjectType = (byte)SubjectTypes.Enum.imageGallery;
                break;
            default:
                subjectType = 1;
                break;
        }
        Subjects subject = new Subjects();
        subject.LoadBySubjectAliasAndIDSubjectType(alias, subjectType);
        if (subject.RowCount > 0)
            output = subject.pTitle;

        return output;
    }
    private string mGetGallerySubject(string aliasName, ref string galleryCategoryAliasForUrl)
    {
        string output = string.Empty;
        Subjects subject = new Subjects();
        subject.LoadBySubjectAliasAndIDSubjectType(aliasName, (byte)SubjectTypes.Enum.imageGallery);
        if (subject.RowCount > 0)
        {
            subject.LoadByPrimaryKey(subject.pIDParent);
            output = subject.pTitle;
            galleryCategoryAliasForUrl = subject.pAlias;
        }
        return output;
    }
    private string mGetListNameByListItem(string aliasName, ref string listNameAliasForUrl)
    {
        string output = string.Empty;
        Subjects subject = new Subjects();
        subject.LoadBySubjectAliasAndIDSubjectType(aliasName, (byte)SubjectTypes.Enum.listItem);
        if (subject.RowCount > 0)
        {
            subject.LoadByPrimaryKey(subject.pIDParent);
            output = subject.pTitle;
            listNameAliasForUrl = subject.pAlias;
        }
        return output;
    }
    private string mGetListName(string aliasName, ref string listNameAliasForUrl)
    {
        string output = string.Empty;
        Subjects subject = new Subjects();
        subject.LoadBySubjectAliasAndIDSubjectType(aliasName, (byte)SubjectTypes.Enum.list);
        if (subject.RowCount > 0)
        {
            subject.LoadByPrimaryKey(subject.pIDParent);
            output = subject.pTitle;
            listNameAliasForUrl = subject.pAlias;
        }
        return output;
    }
}