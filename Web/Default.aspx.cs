using System;

public partial class Default : BasePublic
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Farschidus.Configuration.ConfigurationManager config = new Farschidus.Configuration.ConfigurationManager();
        bool singlePage = Convert.ToBoolean(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "SinglePage", "value"));

        if (singlePage)
        {
            Response.Redirect("Index.aspx", true);
        }
        else
        {
            bool RedirectToHome = Convert.ToBoolean(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "RedirectToHome", "value"));
            if (RedirectToHome)
            {
                Response.Redirect(string.Format(Global.Constants.PAGE_HOME_ASPX, Global.MethodsAndProps.CurrentLanguageCode), true);
            }
        }
    }
}