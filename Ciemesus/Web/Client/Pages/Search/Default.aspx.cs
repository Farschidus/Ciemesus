using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_Search_Default : BasePublic
{
    private string SearchResultFor = Farschidus.Translator.AppTranslate["search.default.message.SearchResultFor"].ToString();
    private string pSearchPhrase
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SEARCH] != null)
            {
                int itemCount = 0;
                string phrase = Request.QueryString[Global.Constants.QUERYSTRING_SEARCH].ToString();
                Subjects subjects = new Subjects();
                subjects.SearchSite(0, 0, ref itemCount,
                    null,
                    null,
                    null,
                    pCurrentLanguageID,
                    null,
                    phrase,
                    phrase,
                    null,
                    null,
                    null,
                    true,
                    null,
                    null,
                    null);
                if (subjects.RowCount > 0)
                {
                    pSubjects = subjects;
                }
                return phrase;
            }
            return string.Empty;
        }
    }
    private Subjects pSubjects;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtSearch.Text = pSearchPhrase;
            if (string.IsNullOrEmpty(pSearchPhrase))
            {
                litBody.Text = Farschidus.Translator.AppTranslate["search.default.message.typeinSearchBox"];
            }
            else if (pSubjects == null)
            {
                litBody.Text = Farschidus.Translator.AppTranslate["search.default.message.noResult"] + " <i>" + pSearchPhrase + "</i>";
            }
            else
            {
                pTitle = string.Format(@"{0} ""{1}""", SearchResultFor, pSearchPhrase);
                Languages lang = new Languages(pCurrentLanguageID);
                StringBuilder sb = new StringBuilder();
                Subjects subject = new Subjects();
                sb.AppendLine(string.Format("<h2>{0} <i>{1}</i></h2>", SearchResultFor, pSearchPhrase));
                sb.AppendLine("<ol class='searchResult'>");
                do
                {
                    if (pSubjects.pIDSubjectType.Equals((byte)SubjectTypes.Enum.list))
                    {
                        subject.LoadByIDParentAndIDSubjectTypeAndIDLanguage(pSubjects.pIDSubject, (byte)SubjectTypes.Enum.listItem, pCurrentLanguageID, true);
                        if (subject.RowCount > 0)
                            sb.AppendLine(string.Format("<li><a target='_blank' href='/{0}/{1}/{2}/{3}/{4}'>{5}</a></li>", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, pSubjects.SubjectTypes.pTitle, ListTypePage.Enum.grid, pSubjects.pAlias, pSubjects.pTitle));
                        else
                            continue;
                    }
                    else
                    {
                        sb.AppendLine(string.Format("<li><a target='_blank' href='/{0}/{1}/{2}/{3}'>{4}</a></li>", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, pSubjects.SubjectTypes.pTitle, pSubjects.pAlias, pSubjects.pTitle));
                    }
                }
                while (pSubjects.MoveNext());
                sb.AppendLine("</ol>");
                litBody.Text = sb.ToString();
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format(Global.Constants.PAGE_SEARCH_ASPX + txtSearch.Text.Trim(), Global.MethodsAndProps.CurrentLanguageCode));
    }
}