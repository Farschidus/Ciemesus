using BLL.BusinessEntity;
using System;

public partial class Pages_Page_Default : BasePublic
{
    private Guid? pIDSubject
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
            {
                Subjects subjects = new Subjects();
                subjects.LoadBySubjectAliasAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), pCurrentLanguageID);
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
                    litPageTitle.Text = pTitle = pSubject.pTitle;
                    litBody.Text = pSubject.pBody;
                    pageBanner.Subject = pSubject;
                    pageMedia.Subject = pSubject;
                    pagePlugin.SubjectID = pSubject.pIDSubject;
                }
                else
                    litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
            }
            else
            {
                litBody.Text = Farschidus.Translator.AppTranslate["general.message.pageNotExist"];
            }
        }
    }
}