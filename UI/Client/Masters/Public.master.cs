using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using BLL.BusinessEntity;
using System.Web.Security;

public partial class Masters_Public : Masters_Base
{
    private MembershipUser pCurrentUser
    {
        get
        {
            return Membership.GetUser(HttpContext.Current.User.Identity.Name);
        }
    }
    public string HomeUrl
    {
        get
        {
            Languages lang = new Languages();
            return string.Format("/{0}/{1}/Home", Global.MethodsAndProps.CurrentLanguageCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME);
        }
    }
    public string CurrentDate
    {
        get
        {
            string output;
            Languages lang = new Languages();
            lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);
            if (lang.pIsRTL)
                output = Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mToDate(DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone), lang.pIDLanguage, "d MMMM yyyy"));
            else
                output = Global.MethodsAndProps.mToDate(DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone), lang.pIDLanguage, "d MMMM yyyy");
            return output;
        }
    }

    string loginUser = @"<a href=""javascript:__doPostBack('btnLogout', 'Logout')"">Logout as {0} {1}</a>";
    //string loginUser = @" < div class='dropdown' style='display:inline-block'>
    //                  <button class='btn btn-login btn-sm dropdown-toggle' type='button' id='dropdownMenu1' data-toggle='dropdown' aria-haspopup='true' aria-expanded='true'>
    //                    <span class='caret'></span>
    //                      <span class='glyphicon glyphicon-user' aria-hidden='true'></span>
    //                      {0} {1}
    //                  </button>
    //                  <ul class='dropdown-menu' aria-labelledby='dropdownMenu1'>
    //                    <li><a href='{2}'>ویرایش اطلاعات شخصی</a></li>
    //                    <li><a href=""javascript:__doPostBack('btnLogout', 'Logout')"">خروج</a></li>
    //                  </ul>
    //                </div>";

    protected void Page_Load(object sender, EventArgs e)
    {
        Languages languages = new Languages();
        languages.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        // Set Current Language for Html Meta Tag
        HtmlMeta htmlMeta = new HtmlMeta();
        htmlMeta.HttpEquiv = "X-UA-Compatible";
        htmlMeta.Content = "IE=edge";
        Page.Header.Controls.AddAt(2, htmlMeta);

        if (!IsPostBack)
        {
            // Login User Info
            if (pCurrentUser != null)
            {
                string registrationPage = string.Format(Global.Constants.PAGE_REGISTER_ASPX.Substring(1), languages.pCode);
                ProfileCommon userProfile = Profile.GetProfile(pCurrentUser.UserName);
                litLogin.Text = string.Format(loginUser, userProfile.FirstName, userProfile.LastName, registrationPage);
            }
            else
            {
                litLogin.Text = string.Format("<a href='/en_US/Pages/Login'>{0}</a>", Farschidus.Translator.AppTranslate["general.label.login"]);
            }

            // CSS and Web Fonts for Current Language
            if (languages.pIsRTL)
            {
                HtmlLink link = new HtmlLink();
                link.Attributes.Add("href", ResolveUrl(Global.Constants.FILE_RTLCSS));
                link.Attributes.Add("type", "text/css");
                link.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(link);

                HtmlLink faFontLink = new HtmlLink();
                faFontLink.Attributes.Add("href", ResolveUrl(Global.Constants.FILE_FA_FONT));
                faFontLink.Attributes.Add("type", "text/css");
                faFontLink.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(faFontLink);
            }
            else
            {
                HtmlLink enFontLink = new HtmlLink();
                enFontLink.Attributes.Add("href", ResolveUrl(Global.Constants.FILE_EN_FONT));
                enFontLink.Attributes.Add("type", "text/css");
                enFontLink.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(enFontLink);
            }
            // Search Default Text for Current Language
            if (Request.QueryString[Global.Constants.QUERYSTRING_SEARCH] != null)
                txtSearch.Text = Request.QueryString[Global.Constants.QUERYSTRING_SEARCH].ToString();
            else
                txtSearch.Text = Farschidus.Translator.AppTranslate["general.label.search"];

            // FavIcon Selection
            HtmlLink favIcon = new HtmlLink();
            favIcon.Attributes.Add("type", "image/x-icon");
            favIcon.Attributes.Add("rel", "shortcut icon");
            if (File.Exists(Server.MapPath("~" + Global.Constants.IMAGE_PUBLIC_FAVICON)))
                favIcon.Attributes.Add("href", Global.Constants.IMAGE_PUBLIC_FAVICON);
            else
                favIcon.Attributes.Add("href", Global.Constants.IMAGE_CIEMESUS_FAVICON);
            Page.Header.Controls.Add(favIcon);
        }
        else
        {
            if (!string.IsNullOrEmpty(Request.Params["__EVENTTARGET"]) && Request.Params["__EVENTTARGET"].Contains("btnLogout"))
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();
                Response.Redirect(string.Format(Global.Constants.PAGE_HOME_ASPX, languages.pCode));
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect(string.Format(Global.Constants.PAGE_SEARCH_ASPX + txtSearch.Text.Trim(), Global.MethodsAndProps.CurrentLanguageCode));
    }

    public string mGenerateNavbar()
    {
        Languages languages = new Languages();
        languages.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);
        string sitemapFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}{2}", Global.Constants.FOLDER_SITEMAPS, languages.pCode, Global.Constants.FILE_EXTENSIONS_Sitemap));

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sitemapFile);
        XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
        manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        //XmlNode rootNode = xmlDoc.GetElementsByTagName("sm:siteMapNode", manager)[0].FirstChild;
        XmlNode rootNode = xmlDoc.SelectNodes("//sm:siteMapNode", manager)[0];
        if (rootNode != null && rootNode.HasChildNodes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<ul class=""nav navbar-nav"">");
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                mGetChildNodes(sb, childNode);
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
        else
        {
            return string.Empty;
        }
    }
    private void mGetChildNodes(StringBuilder sb, XmlNode node)
    {
        string nodeSelected = mIsCurrentNode(node.Attributes["url"].Value) ? "active" : "";
        string nodeUrl = mSetUrl(node.Attributes["url"].Value, node.Attributes["title"].Value, node.HasChildNodes);
        sb.Append(string.Format("<li class='{2}{0}'>{1}", nodeSelected, nodeUrl, node.HasChildNodes ? "dropdown " : ""));
        if (node.HasChildNodes)
        {
            sb.Append("<ul  class='dropdown-menu' role='menu'>");
            foreach (XmlNode childNode in node.ChildNodes)
            {
                mGetChildNodes(sb, childNode);
            }
            sb.Append("</ul>");
        }
        else
        {
            sb.Append("</li>");
        }
    }
    public bool mIsCurrentNode(object url)
    {
        if (!string.IsNullOrEmpty(url.ToString()))
        {
            if (Page.Request.RawUrl.Contains(url.ToString().Substring(1)))
                return true;
            else
                return false;
        }
        return false;
    }
    public string mSetUrl(object url, object title, bool hasChild = false)
    {
        if (mIsCurrentNode(url))
        {
            if (hasChild)
                return string.Format("<a {0} href='#'>{1}<span class='sr-only'>(current)</span></a>", @"class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-expanded=""false""", title.ToString());
            else
                return string.Format("<a href='#'>{0}<span class='sr-only'>(current)</span></a>", title.ToString());
        }
        else
        {
            if (url.ToString().Contains("javascript"))
            {
                if (hasChild)
                    return string.Format("<a {0} href='#'>{1}<span class='sr-only'>(current)</span></a>", @"class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-expanded=""false""", title.ToString());
                else
                    return string.Format("<a>{0}<span class='sr-only'>(current)</span></a>", title.ToString());
            }
            else
            {
                if (url.ToString().Substring(0, 1).Equals("~"))
                {
                    if (hasChild)
                        return string.Format("<a {0} href='{1}'>{2}<span class='sr-only'>(current)</span></a>", @"class=""dropdown-toggle"" data-toggle=""dropdown"" role=""button"" aria-expanded=""false""", url.ToString().Substring(1), title.ToString());
                    else
                        return string.Format(@"<a href='{0}'>{1}</a>", url.ToString().Substring(1), title.ToString());
                }
                else
                {
                    return string.Format(@"<a href='{0}'>{1}</a>", url.ToString(), title.ToString());
                }
            }
        }
    }
    public string mGetLogo()
    {
        Languages languages = new Languages();
        languages.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        StringBuilder sb = new StringBuilder();

        if (languages.pIsRTL)
        {
            sb.Append(@"<img class='hidden-xs' src='/Client/Images/Public/LogoFa.png'>");
            sb.Append(@"<img class='visible-xs' src='/Client/Images/Public/LogoFa-xs.png'>");
        }
        else
        {
            sb.Append(@"<img class='hidden-xs' src='/Client/Images/Public/LogoEn.png'>");
            sb.Append(@"<img class='visible-xs' src='/Client/Images/Public/LogoEn-xs.png'>");
        }

        return sb.ToString();
    }
}