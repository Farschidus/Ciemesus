using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Masters_Base : BaseMasterPage
{
    public string Lang
    {
        get
        {
            BLL.BusinessEntity.Languages languages = new BLL.BusinessEntity.Languages();                
            languages.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);
            return languages.pCode.Split('_')[0];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GenerateJsAndCssLinks();
            form1.Action = Request.RawUrl;
        }
    }

    private void GenerateJsAndCssLinks()
    {
        HtmlGenericControl jsBundleLink = new HtmlGenericControl("script");
        jsBundleLink.Attributes.Add("src", string.Format("/application/static/dist/js/base.min.js?{0}", System.Configuration.ConfigurationManager.AppSettings["Version"]));
        jsBundleLink.Attributes["type"] = "text/javascript";
        Page.Header.Controls.AddAt(4, jsBundleLink);

        HtmlLink cssBundleLink = new HtmlLink();
        cssBundleLink.Attributes.Add("href", string.Format("/application/static/dist/css/base.min.css?{0}", System.Configuration.ConfigurationManager.AppSettings["Version"]));
        cssBundleLink.Attributes.Add("type", "text/css");
        cssBundleLink.Attributes.Add("rel", "stylesheet");
        Page.Header.Controls.AddAt(5, cssBundleLink);
    }

    protected void CiemesusScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        if (e.Exception.Data["ExtraInfo"] != null)
        {
            CiemesusScriptManager.AsyncPostBackErrorMessage =
                e.Exception.Message +
                e.Exception.Data["ExtraInfo"].ToString();
        }
        else
        {
            CiemesusScriptManager.AsyncPostBackErrorMessage = e.Exception.Message + e.Exception.InnerException.Message + 
                "An unspecified error occurred.";
        }
    }
}
