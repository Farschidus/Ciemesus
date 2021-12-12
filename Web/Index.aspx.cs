using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI.HtmlControls;
using BLL.BusinessEntity;


public partial class Index : BasePublic
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Farschidus.Configuration.ConfigurationManager config = new Farschidus.Configuration.ConfigurationManager();
        bool singlePage = Convert.ToBoolean(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "SinglePage", "value"));

        if (singlePage)
        {
            mRenderSinglePage();
        }
        else
        {
            Languages lang = new Languages(Farschidus.Translator.PublicDefaultLanguage);
            Response.Redirect(string.Format(Global.Constants.PAGE_HOME_ASPX, lang.pCode));
        }
    }

    private void mRenderSinglePage()
    {
        mRenderHeader();
        mRenderSections();
        mRenderFooter();
    }
    private void mRenderHeader()
    {
        Subjects sbjHome = new Subjects();
        sbjHome.LoadByIDSubjectTypeAndIDLanguage((byte)SubjectTypes.Enum.home, pCurrentLanguageID);
        Title = sbjHome.pTitle;
        litHeader.Text = sbjHome.pBody;
        mRenderScripts(sbjHome.pIDSubject);
    }
    private void mRenderSections()
    {
        Subjects sbjPages = new Subjects();
        sbjPages.LoadByIDSubjectTypeAndIDLanguage((byte)SubjectTypes.Enum.page, pCurrentLanguageID);
        StringBuilder sb = new StringBuilder();
        if(sbjPages.RowCount > 0)
        {
            sbjPages.Sort = Subjects.ColumnNames.Priority;
            do
            {
                sb.AppendFormat("<section id='{0}'>", sbjPages.pTitle.ToLower());
                sb.Append(sbjPages.pBody);
                sb.AppendFormat("</section>", sbjPages.pTitle);
            }
            while (sbjPages.MoveNext());
        }
        litSections.Text = sb.ToString();
    }
    private void mRenderFooter()
    {
        litFooter.Text = Farschidus.Translator.AppTranslate["footer.label.companyName"];
    }
    private void mRenderScripts(Guid homeID)
    {
        StringBuilder sb = new StringBuilder();
        SubjectPlugins subjectPlugins = new SubjectPlugins();
        subjectPlugins.LoadByIDSubject(homeID);

        if (subjectPlugins.RowCount > 0)
        {
            do {
                sb.AppendFormat(@"<script src=""{0}{1}""></script>", Global.Constants.FOLDER_PLUGINS.Substring(1), subjectPlugins.Plugins.pJSfileName);
            }
            while (subjectPlugins.MoveNext());
        }
        litScripts.Text = sb.ToString();
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
            sb.Append(@"<ul class=""nav navbar-nav navbar-right"">");
            sb.Append(@"<li class=""hidden active""><a href=""#page-top""></a></li>");
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
                        return string.Format(@"<a class='page-scroll' href='{0}'>{1}</a>", url.ToString().Substring(1), title.ToString());
                }
                else
                {
                    return string.Format(@"<a class='page-scroll' href='{0}'>{1}</a>", url.ToString(), title.ToString());
                }
            }
        }
    }
}