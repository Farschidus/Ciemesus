using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_ListCoverGallery : System.Web.UI.UserControl
{
    private string listNameAlias;
    public string ListNameAlias
    {
        get
        {
            return listNameAlias;
        }
        set
        {
            listNameAlias = value;
        }
    }

    private bool generateTitle = true;
    public bool GenerateTitle
    {
        get
        {
            return generateTitle;
        }
        set
        {
            generateTitle = value;
        }
    }

    private byte language;
    private Guid subjectID;
    const string item =
@"<li class='item'>
    <a href='{0}'>
        <div class='itemImage' style='background: url({1}) no-repeat center center'></div>
        <span class='item-title'>{2}</span>
    </a>
</li>";

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
        string[] aliasArray = listNameAlias.Split(',');
        foreach (string alias in aliasArray)
        {
            subject.LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(alias, (byte)SubjectTypes.Enum.list, lang.pIDLanguage, true);
            if (subject.RowCount > 0)
            {
                language = subject.pIDLanguage;
                subjectID = subject.pIDSubject;
                listNameAlias = alias;
                if (generateTitle)
                    lblTitle.Text = subject.pTitle;
                return true;
            }
        }
        return false;
    }
    private void mLoadItems()
    {
        StringBuilder sb = new StringBuilder();
        Subjects ListItems = new Subjects();
        ListItems.LoadByIDParentAndIDLanguage(subjectID, language);
        ListItems.Sort = Subjects.ColumnNames.Date + " DESC";

        MediaSubjects medias = new MediaSubjects();
        sb.Append("<ul class='SideBar-SlideContainer'>");
        do
        {
            medias.LoadByIDSubjectAndIDMediaSubjectType(ListItems.pIDSubject, (byte)MediaSubjectTypes.Enum.thumbnail);
            if (medias.RowCount > 0)
            {
                sb.Append(string.Format(item, mGetURL(ListItems.pAlias), mGetImage(medias), ListItems.pTitle));
            }
        }
        while (ListItems.MoveNext());
        sb.Append("</ul>");

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