using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_Login_Default : BasePublic
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pTitle = Farschidus.Translator.AppTranslate["login.default.label.loginButton"];
        }
    }
    protected void LoginControl_LoggedIn(object sender, EventArgs e)
    {
        Languages lang = new Languages(Farschidus.Translator.CpDefaultLanguage);
        if (!string.IsNullOrEmpty(Request.QueryString[Global.Constants.QUERYSTRING_RETURN_URL]))
        {
            Response.Redirect(Request.QueryString[Global.Constants.QUERYSTRING_RETURN_URL]);
        }
        else if (Roles.IsUserInRole(LoginControl.UserName, Global.Constants.STRING_ROLE_ADMINISTRATOR) || Roles.IsUserInRole(LoginControl.UserName, Global.Constants.STRING_ROLE_CIEMESUS))
        {
            Response.Redirect(string.Format(Global.Constants.PAGE_CP_DESKTOP_ASPX, lang.pCode));
        }
        else
        {
            lang.LoadByPrimaryKey(Farschidus.Translator.PublicDefaultLanguage);
            MembershipUser user = Membership.GetUser(LoginControl.UserName);
            Response.Redirect(string.Format(Global.Constants.PAGE_HOME_ASPX, lang.pCode, user.ProviderUserKey.ToString()));
        }
    }
}