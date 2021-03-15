using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL.BusinessEntity;

public partial class Pages_Home_Default : BasePublic
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Subjects pSubjects = new Subjects();
            pSubjects.LoadByIDSubjectTypeAndIDLanguage((byte)SubjectTypes.Enum.home, pCurrentLanguageID);
            if (pSubjects.RowCount > 0)
            {
                if (pSubjects.pIsActive)
                {
                    pTitle = pSubjects.pTitle;
                    litBody.Text = pSubjects.pBody;
                    pageMedia.Subject = pSubjects;
                    pageBanner.Subject = pSubjects;
                    pagePlugin1.SubjectID = pSubjects.pIDSubject;
                    
                }
                else
                {
                    litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
                }
            }
        }
    }
    protected void ContactUs_Click(object sender, EventArgs e)
    {
        string url;
        Languages lang = new Languages(pCurrentLanguageID);
        url = string.Format("~/{0}/{1}/{2}/", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, "Contact");
        Response.Redirect(url, true);
    }
    protected void Projects_Click(object sender, EventArgs e)
    {
        string url;
        Languages lang = new Languages(pCurrentLanguageID);
        url = string.Format("~/{0}/{1}/{2}/{3}/{4}", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, "List", "Horizontal", "پروژه‌ها");
        Response.Redirect(url, true);      
    }
}