using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_UserPage_Default : BasePublic
{
    private Guid? pIDSubject
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
            {
                Subjects subjects = new Subjects();
                subjects.LoadBySubjectAliasAndIDSubjectType(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), (byte)SubjectTypes.Enum.userPage);
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
                    pTitle = pSubject.pTitle;
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