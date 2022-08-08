using BLL.BusinessEntity;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Masters_CPanel : Masters_Base
{
    protected override void OnInit(EventArgs e)
    {        
        base.OnInit(e);
        mDDLsInisialize();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl jsBundleLink = new HtmlGenericControl("script");
            jsBundleLink.Attributes.Add("src", string.Format("/application/static/dist/js/cp.min.js?{0}", System.Configuration.ConfigurationManager.AppSettings["Version"]));
            jsBundleLink.Attributes["type"] = "text/javascript";
            Page.Header.Controls.AddAt(4, jsBundleLink);

            Languages languages = new Languages();
            languages.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);
            // Set Sitemap Provider
            MenuDataSource.SiteMapProvider = "CP_" + languages.pCode;

            if (languages.pIsRTL)
            {
                HtmlLink link = new HtmlLink();
                link.Attributes.Add("href", ResolveUrl(Global.Constants.FILE_CPRTLCSS));
                link.Attributes.Add("type", "text/css");
                link.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(link);
            }

            Languages lang = new Languages(Farschidus.Translator.PublicDefaultLanguage);
            //lnkHomePage.HRef =  string.Format(Global.Constants.PAGE_HOME_ASPX, lang.pCode);
            lnkHomePage.Title = Farschidus.Translator.AppTranslate["general.label.backToWebsite"];
        }
    }
    protected void ddlCPLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        Uri uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
        string url = uri.GetLeftPart(UriPartial.Path).Replace("default.aspx", "");
        string currentLang = HttpContext.Current.Request.RawUrl.Split('/')[1];
        Languages languages = new Languages(byte.Parse(ddlCPLanguages.SelectedValue));
        Response.Redirect(url.ToLower().Replace("application", languages.pCode), true);
    }
    
    private void mDDLsInisialize()
    {
        Languages languages = new Languages();
        languages.LoadActiveLanguages();
        languages.Sort = Languages.ColumnNames.Priority;
        ddlCPLanguages.DataSource = ddlLanguages.DataSource = languages.DefaultView;
        ddlCPLanguages.DataTextField = ddlLanguages.DataTextField = Languages.ColumnNames.Title;
        ddlCPLanguages.DataValueField = ddlLanguages.DataValueField = Languages.ColumnNames.IDLanguage;
        ddlLanguages.DataBind();
        ddlCPLanguages.DataBind();
        ddlLanguages.SelectedValue = Farschidus.Translator.PublicDefaultLanguage.ToString();

        Languages cpLang = new Languages();
        cpLang.LoadByLanguageCode(HttpContext.Current.Request.RawUrl.Split('/')[1]);
        if (cpLang.RowCount > 0)
            ddlCPLanguages.SelectedValue = cpLang.pIDLanguage.ToString();
    }
    protected void CPLoginStatus_OnLoggedOut(object sender, EventArgs e)
    {
        Session.Clear();
        Languages lang = new Languages(Farschidus.Translator.PublicDefaultLanguage);
        Response.Redirect("~/");
    }
}