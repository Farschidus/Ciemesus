using BLL.BusinessEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Xml;

public partial class ControlP_MenuManager_Default : BaseCP
{
    #region "Properties"

    private string pURL
    {
        get
        {
            if (ViewState["pURL"] == null)
            {
                return string.Empty;
            }
            return ViewState["pURL"].ToString();
        }
        set
        {
            ViewState["pURL"] = pURL;
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShownLoadAllButton = pShownSearchButton = pShownDeleteButton = false;
            Title = Farschidus.Translator.AppTranslate["menuManager.default.page.title"];
            Languages language = new Languages(Farschidus.Translator.PublicDefaultLanguage);
            hdfMenuName.Value = language.pCode;
            mInitialBindings();
        }
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        mClear();
        uplList.Update();
    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        mDDLAliasBinding();
        if (ddlModule.SelectedIndex.Equals(0))
        {
            trUrl.Visible = true;
            trPage.Visible = false;
            trListFormat.Visible = false;
        }
        else
        {
            trUrl.Visible = false;
            SubjectTypes.Enum selectedModule = (SubjectTypes.Enum)Enum.Parse(typeof(SubjectTypes.Enum), ddlModule.SelectedValue);
            switch (selectedModule)
            {
                case SubjectTypes.Enum.home:
                    {
                        trPage.Visible = true;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;
                        break;
                    }
                case SubjectTypes.Enum.page:
                    {
                        trPage.Visible = true;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = true;
                        cbxShowRelated.Text = Farschidus.Translator.AppTranslate["menuManager.default.checkbox.showRelated"];
                        break;
                    }
                case SubjectTypes.Enum.list:
                    {
                        trPage.Visible = true;
                        trListFormat.Visible = true;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;
                        break;
                    }
                case SubjectTypes.Enum.store:
                    {
                        trPage.Visible = true;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;
                        break;
                    }
                case SubjectTypes.Enum.imageGallery:
                case SubjectTypes.Enum.audioGallery:
                case SubjectTypes.Enum.videoGallery:
                case SubjectTypes.Enum.category:
                    {
                        trPage.Visible = true;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;

                        break;
                    }
                case SubjectTypes.Enum.userPage:
                    {
                        trPage.Visible = false;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;
                        break;
                    }
                case SubjectTypes.Enum.contact:
                    {
                        trPage.Visible = false;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;
                        break;
                    }
                case SubjectTypes.Enum.form:
                    {
                        trPage.Visible = true;
                        trListFormat.Visible = false;
                        cbxShowRelated.Checked = false;
                        cbxShowRelated.Visible = false;
                        break;
                    }
            }
        }
    }
    protected override void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        Languages language = new Languages(pLanguageID);

        hdfMenuName.Value = language.pCode;
        string siteMapPath = MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, language.pCode));
        if (!File.Exists(siteMapPath))
        {
            pMessage.Clear();
            pMessage.Add(Farschidus.Translator.AppTranslate["menuManager.default.message.noSiteMap"], Farschidus.Web.UI.Message.MessageTypes.Error);
            pMessage.Add(Farschidus.Translator.AppTranslate["menuManager.default.message.addSiteMap"], Farschidus.Web.UI.Message.MessageTypes.Information);
            mShowMessage(pMessage);
        }
        mModulesBindings();
        mDDLAliasBinding();
        cbxShowRelated.Text = Farschidus.Translator.AppTranslate["menuManager.default.checkbox.showRelated"];

        uplList.Update();
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {
        Languages lang = new Languages(Farschidus.Translator.PublicDefaultLanguage);
        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["menuManager.default.addEdit.ddlNoUrl"], "0");
        ddlModule.Items.Add(liInitial);

        BLL.Hardcodes.Tables tables = new BLL.Hardcodes.Tables();
        ddlModule.DataSource = tables.SubjectTypes;
        ddlModule.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        ddlModule.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        ddlModule.DataBind();

        rblPageListFormat.DataSource = tables.ListTypeStyle;
        rblPageListFormat.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        rblPageListFormat.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        rblPageListFormat.DataBind();
        rblPageListFormat.Items[0].Text += "</br>" + Global.Constants.HTML_ICON_GRID;
        rblPageListFormat.Items[1].Text += "</br>" + Global.Constants.HTML_ICON_LIST;

        trUrl.Visible = true;
        trPage.Visible = false;
        trListFormat.Visible = false;
    }
    private void mModulesBindings()
    {
        ddlModule.Items.Clear();
        Languages lang = new Languages(pLanguageID);
        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["menuManager.default.addEdit.ddlNoUrl"], "0");
        ddlModule.Items.Add(liInitial);

        BLL.Hardcodes.Tables tables = new BLL.Hardcodes.Tables();
        ddlModule.DataSource = tables.SubjectTypes;
        ddlModule.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        ddlModule.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        ddlModule.DataBind();
    }
    private void mDDLAliasBinding()
    {
        SubjectTypes.Enum module = (SubjectTypes.Enum)Enum.Parse(typeof(SubjectTypes.Enum), ddlModule.SelectedValue);
        switch (module)
        {
            case SubjectTypes.Enum.home:
                {
                    Subjects Subject = new Subjects();
                    Subject.LoadByIDSubjectTypeAndIDLanguage((byte)module, pLanguageID);
                    ddlAlias.Enabled = false;
                    ddlAlias.Items.Clear();
                    if (Subject.RowCount > 0)
                    {
                        ddlAlias.DataSource = Subject.DefaultView;
                    }
                    else
                    {
                        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["menuManager.default.dropdown.createPage"], "0");
                        ddlAlias.Items.Add(liInitial);
                    }
                    ddlAlias.DataTextField = Subjects.ColumnNames.Title;
                    ddlAlias.DataValueField = Subjects.ColumnNames.IDSubject;
                    ddlAlias.DataBind();
                    break;
                }
            case SubjectTypes.Enum.page:
            case SubjectTypes.Enum.imageGallery:
            case SubjectTypes.Enum.videoGallery:
            case SubjectTypes.Enum.audioGallery:
            case SubjectTypes.Enum.category:
                {
                    Subjects subject = new Subjects
                    {
                        Sort = Subjects.ColumnNames.Priority
                    };
                    subject.LoadByIDSubjectTypeAndIDLanguage((byte)module, pLanguageID);
                    
                    ddlAlias.Enabled = true;
                    ddlAlias.Items.Clear();
                    ddlAlias.DataSource = subject.DefaultView;
                    ddlAlias.DataTextField = Subjects.ColumnNames.Title;
                    ddlAlias.DataValueField = Subjects.ColumnNames.IDSubject;
                    ddlAlias.DataBind();
                    break;
                }
            case SubjectTypes.Enum.list:
            case SubjectTypes.Enum.store:
                {
                    ddlAlias.Enabled = true;
                    ddlAlias.Items.Clear();

                    Subjects subject = new Subjects
                    {
                        Sort = Subjects.ColumnNames.Priority
                    };
                    subject.LoadAllListByIDLanguage(pLanguageID);
                    
                    if (subject.RowCount > 0)
                    {
                        List<BLL.Hardcodes.Item> ddlItems = new List<BLL.Hardcodes.Item>();
                        do
                        {
                            List<string> items = new List<string>();
                            mLoadRecursivlyByParentID(ref items, subject.pIDSubject, subject.pTitle);
                            items.Reverse();
                            ddlItems.Add(new BLL.Hardcodes.Item(subject.pIDSubject, string.Join(" / ", items.ToArray())));
                        }
                        while (subject.MoveNext());

                        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
                        ddlAlias.Items.Add(liInitial);

                        ddlAlias.DataSource = ddlItems;
                        ddlAlias.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
                        ddlAlias.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
                        ddlAlias.DataBind();
                    }
                    else
                    {
                        ddlAlias.Items.Add(new ListItem(Farschidus.Translator.AppTranslate["menuManager.default.addEdit.ddlAlias.noList"], "0"));
                    }
                    break;
                }
            case SubjectTypes.Enum.form:
                {
                    Subjects subject = new Subjects
                    {
                        Sort = Subjects.ColumnNames.Priority
                    };
                    subject.LoadByIDSubjectTypeAndIDLanguage((byte)SubjectTypes.Enum.form, pLanguageID);
                    
                    ddlAlias.Enabled = true;
                    ddlAlias.Items.Clear();
                    if (subject.RowCount > 0)
                    {
                        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
                        ddlAlias.Items.Add(liInitial);

                        ddlAlias.DataSource = subject.DefaultView;
                        ddlAlias.DataTextField = Subjects.ColumnNames.Title;
                        ddlAlias.DataValueField = Subjects.ColumnNames.IDSubject;
                        ddlAlias.DataBind();
                    }
                    else
                    {
                        ddlAlias.Items.Add(new ListItem(Farschidus.Translator.AppTranslate["menuManager.default.addEdit.ddlAlias.noList"], "0"));
                    }
                    break;
                }
            default:
                {
                    ddlAlias.Items.Clear();
                    ddlAlias.Enabled = false;
                    break;

                }
        }
        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        if (string.IsNullOrEmpty(txtTitle.Text) || ddlAlias.SelectedValue.Equals("0"))
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["menuManager.default.message.selectDDLs"], Farschidus.Web.UI.Message.MessageTypes.Error);
        }
        if (!ddlModule.SelectedValue.Equals("0") && !System.Text.RegularExpressions.Regex.Match(ddlModule.SelectedItem.Text, SubjectTypes.Enum.contact.ToString(), System.Text.RegularExpressions.RegexOptions.IgnoreCase).Success && string.IsNullOrEmpty(ddlAlias.SelectedValue))
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["menuManager.default.message.createPage"], Farschidus.Web.UI.Message.MessageTypes.Error);
        }
        return isValid;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            try
            {
                string url = string.Empty;
                string moduleName = string.Empty;
                string alias = string.Empty;
                string subjectID = string.Empty;
                string listStyle = string.Empty;
                string listType = string.Empty;

                Languages language = new Languages(pLanguageID);
                SubjectTypes.Enum module = (SubjectTypes.Enum)Enum.Parse(typeof(SubjectTypes.Enum), ddlModule.SelectedValue);
                switch (module)
                {
                    case SubjectTypes.Enum.home:
                        {
                            moduleName = "Home";
                            break;
                        }
                    case SubjectTypes.Enum.contact:
                        {
                            moduleName = "Contact";
                            break;
                        }
                    case SubjectTypes.Enum.page:
                        {
                            if (cbxShowRelated.Checked)
                                moduleName = "PageList";
                            else
                                moduleName = "Page";
                            Subjects subject = new Subjects(new Guid(ddlAlias.SelectedValue));
                            alias = subject.pAlias;
                            subjectID = subject.pIDSubject.ToString();
                            break;
                        }
                    case SubjectTypes.Enum.imageGallery:
                    case SubjectTypes.Enum.videoGallery:
                    case SubjectTypes.Enum.audioGallery:
                        {
                            moduleName = "Gallery";
                            Subjects subject = new Subjects(new Guid(ddlAlias.SelectedValue));
                            alias = subject.pAlias;
                            subjectID = subject.pIDSubject.ToString();
                            break;
                        }
                    case SubjectTypes.Enum.list:
                        {
                            moduleName = "List";
                            Subjects subject = new Subjects(new Guid(ddlAlias.SelectedValue));
                            alias = subject.pAlias;
                            subjectID = subject.pIDSubject.ToString();
                            listStyle = ((ListTypePage.Enum)Enum.Parse(typeof(ListTypePage.Enum), rblPageListFormat.SelectedValue)).ToString();

                            break;
                        }
                    case SubjectTypes.Enum.store:
                        {
                            moduleName = "Store";
                            Subjects subject = new Subjects(new Guid(ddlAlias.SelectedValue));
                            alias = subject.pAlias;
                            subjectID = subject.pIDSubject.ToString();
                            break;
                        }
                    case SubjectTypes.Enum.form:
                        {
                            moduleName = "Form";
                            Subjects subject = new Subjects(new Guid(ddlAlias.SelectedValue));
                            alias = subject.pAlias;
                            subjectID = subject.pIDSubject.ToString();
                            break;
                        }
                    case SubjectTypes.Enum.category:
                        {
                            moduleName = "Category";
                            Subjects subject = new Subjects(new Guid(ddlAlias.SelectedValue));
                            alias = subject.pAlias;
                            subjectID = subject.pIDSubject.ToString();
                            break;
                        }
                }

                if (ddlModule.SelectedIndex != 0)
                {
                    switch (module)
                    {
                        case SubjectTypes.Enum.home:
                        case SubjectTypes.Enum.contact:
                            {
                                url = string.Format("~/{0}/{1}/{2}/", language.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, moduleName);
                                break;
                            }
                        case SubjectTypes.Enum.list:
                            {
                                System.Globalization.TextInfo TitleCase = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                                url = string.Format("~/{0}/{1}/{2}/{3}/{4}", language.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, moduleName, TitleCase.ToTitleCase(listStyle), alias);
                                break;
                            }
                        default:
                            {
                                System.Globalization.TextInfo TitleCase = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                                url = string.Format("~/{0}/{1}/{2}/{3}", language.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, moduleName, alias);
                                break;
                            }
                    }
                }
                else
                {
                    url = txtRawUrl.Text;
                }

                string siteMapPath = Server.MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, language.pCode));
                if (!File.Exists(siteMapPath))
                    mCreatesiteMap(siteMapPath);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(siteMapPath);
                XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
                XmlNode node = xmlDoc.SelectSingleNode(string.Format("//sm:siteMapNode[contains(@url,'{0}')]", url), manager);
                pMessage.Clear();
                if (node == null || string.IsNullOrEmpty(url))
                {
                    mSaveSiteMap(txtTitle.Text.Trim(), url, subjectID, siteMapPath);
                    mClear();
                    uplAddEdit.Update();
                    pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                }
                else
                {
                    pMessage.Add(Farschidus.Translator.AppTranslate["menuManager.default.message.duplicateSiteMap"], Farschidus.Web.UI.Message.MessageTypes.Error);
                }
                mShowMessage(pMessage);
            }
            catch (Exception ex)
            {
                pMessage.Clear();
                pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
                mShowMessage(pMessage);
            }
        }
        else
        {
            mShowMessage(pMessage);
        }
    }
    private void mSaveSiteMap(string title, string url, string subjectID, string siteMapPath)
    {
        XmlDocument xmlDoc = new XmlDocument();

        if (!File.Exists(siteMapPath))
        {
            string strXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><siteMap xmlns=\"http://schemas.microsoft.com/AspNet/SiteMap-File-1.0\"><siteMapNode roles=\"*\"></siteMapNode></siteMap>";
            xmlDoc.LoadXml(strXml);
        }
        else
        {
            xmlDoc.Load(siteMapPath);
        }

        XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
        manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");

        XmlNode newNode = xmlDoc.CreateElement("siteMapNode", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        XmlAttribute atrTitle = xmlDoc.CreateAttribute("title");
        XmlAttribute atrResourceKey = xmlDoc.CreateAttribute("resourceKey");
        atrTitle.Value = title;
        string guID = string.Empty;
        if (!string.IsNullOrEmpty(subjectID))
            guID = subjectID;
        else
            guID = Guid.NewGuid().ToString();

        atrResourceKey.Value = guID;

        XmlAttribute atrURL = xmlDoc.CreateAttribute("url");
        newNode.Attributes.Append(atrTitle);
        if (!string.IsNullOrEmpty(url))
        {
            atrURL.Value = url;
        }
        else
        {
            atrURL.Value = string.Format("javascript:void({0})", guID);
        }
        newNode.Attributes.Append(atrURL);
        newNode.Attributes.Append(atrResourceKey);

        XmlNode refNode = xmlDoc.SelectNodes("//sm:siteMap", manager)[0].FirstChild;
        refNode.AppendChild(newNode);
        xmlDoc.Save(siteMapPath);
    }
    private void mClear()
    {
        txtTitle.Text = txtRawUrl.Text = string.Empty;
        ddlModule.SelectedIndex = 0;
        ddlAlias.Items.Clear();
        ddlAlias.Enabled = false;
        cbxShowRelated.Visible = false;
        trUrl.Visible = true;
        trPage.Visible = false;
        trListFormat.Visible = false;
    }

    private static string mGetWellFormattedJsTree(XmlDocument xmlDoc)
    {
        XmlNode siteMapRootNode = xmlDoc.GetElementsByTagName("siteMap")[0].FirstChild;
        XmlNodeList FirstLevelList = siteMapRootNode.ChildNodes;

        XmlDocument outputXML = new XmlDocument();
        XmlNode root = outputXML.CreateElement("ul");

        foreach (XmlNode node in FirstLevelList)
        {
            root.AppendChild(mGenerateItemforJsTree(outputXML, node));
            mGetChildNodes(outputXML, node, root);
        }

        outputXML.AppendChild(root);
        return outputXML.InnerXml.ToString();
    }
    private static XmlNode mGenerateItemforJsTree(XmlDocument outputXML, XmlNode node)
    {
        XmlNode item = outputXML.CreateElement("li");
        XmlAttribute atrID = outputXML.CreateAttribute("id");

        item.InnerText = node.Attributes["title"].Value;
        atrID.Value = node.Attributes["resourceKey"].Value;

        item.Attributes.Append(atrID);
        return item;
    }
    private static bool mGetChildNodes(XmlDocument outputXML, XmlNode node, XmlNode root)
    {
        if (node.HasChildNodes)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                root.AppendChild(mGenerateItemforJsTree(outputXML, childNode));
                mGetChildNodes(outputXML, childNode, root);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    private void mLoadRecursivlyByParentID(ref List<string> ddlItems, Guid subjectID, string title)
    {
        Subjects subjects = new Subjects(subjectID)
        {
            Sort = Subjects.ColumnNames.Priority
        };

        if (subjects.RowCount > 0)
        {
            do
            {
                ddlItems.Add(subjects.pTitle);
                if (!subjects.IsColumnNull(Subjects.ColumnNames.IDParent))
                    mLoadRecursivlyByParentID(ref ddlItems, subjects.pIDParent, title);
            }
            while (subjects.MoveNext());
        }
        else
        {
            ddlItems.Add(title);
        }
    }
    private void mCreatesiteMap(string siteMapPath)
    {
        XmlDocument xmlDoc = new XmlDocument();
        string strXml = "<?xml version='1.0' encoding='utf-8'?><siteMap xmlns='http://schemas.microsoft.com/AspNet/SiteMap-File-1.0\'><siteMapNode roles='*'></siteMapNode></siteMap>";
        xmlDoc.LoadXml(strXml);
        xmlDoc.Save(siteMapPath);
    }

    #endregion

    #region "WebMethod"

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string LoadSiteMap(string siteMap)
    {
        List<JsTree> result = new List<JsTree>();
        string sitemapFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, siteMap));
        if (File.Exists(sitemapFile))
        {
            XmlDocument xmlDoc = new XmlDocument();
            FileStream fs = new FileStream(sitemapFile, FileMode.Open, FileAccess.Read);
            xmlDoc.Load(fs);
            XmlNode siteMapRootNode = xmlDoc.GetElementsByTagName("siteMap")[0].FirstChild;

            result = mGetJsTreeDataObj(siteMapRootNode);
            fs.Close();
        }
        string jsonData = JsonConvert.SerializeObject(result, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        });
        return jsonData;
    }

    private static List<JsTree> mGetJsTreeDataObj(XmlNode siteMapNode)
    {
        var parentNode = new List<JsTree>();
        foreach (XmlNode node in siteMapNode.ChildNodes)
        {
            var jsTree = new JsTree
            {
                Id = node.Attributes["resourceKey"].Value,
                Text = node.Attributes["title"].Value
            };

            if (node.HasChildNodes)
            {
                jsTree.Children = mGetJsTreeDataObj(node);
                parentNode.Add(jsTree);
            }
            else
            {
                parentNode.Add(jsTree);
            }
        }

        return parentNode;
    }

    [WebMethod]
    [ScriptMethod]
    public static void MoveNode(string nodeID, string refID, int position, string treeType)
    {
        string sitemapFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, treeType));

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sitemapFile);
        XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
        manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");

        XmlNode selectedNode = xmlDoc.SelectSingleNode("//sm:siteMapNode[@resourceKey='" + nodeID + "']", manager);
        XmlNode refNode;
        if (refID != "#")
            refNode = xmlDoc.SelectSingleNode("//sm:siteMapNode[@resourceKey='" + refID + "']", manager);
        else
            refNode = xmlDoc.GetElementsByTagName("siteMap")[0].FirstChild;

        XmlNode parentSelectedNode = selectedNode.ParentNode;
        XmlNodeList newParentChildrens = refNode.ChildNodes;

        parentSelectedNode.RemoveChild(selectedNode);

        
        if (position > 0)
        {
            var newRefNode = newParentChildrens[position - 1];
            refNode.InsertAfter(selectedNode, newRefNode);
        }
        else if(position == 0)
        {
            if (refNode.HasChildNodes)
            {
                refNode.InsertBefore(selectedNode, refNode.FirstChild);
            }
            else
            {
                refNode.AppendChild(selectedNode);
            }
        }
        xmlDoc.Save(sitemapFile);
    }

    [WebMethod]
    [ScriptMethod]
    public static void DeleteNode(string nodeID, string treeType)
    {
        string sitemapFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, treeType));
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sitemapFile);
        XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
        manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        XmlNode deletedNode = xmlDoc.SelectSingleNode("//sm:siteMapNode[@resourceKey='" + nodeID + "']", manager);
        XmlNode parentOfDeletedNode = deletedNode.ParentNode;
        parentOfDeletedNode.RemoveChild(deletedNode);

        xmlDoc.Save(sitemapFile);
    }

    [WebMethod]
    [ScriptMethod]
    public static void RenameNode(string nodeID, string newName, string treeType)
    {
        string sitemapFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, treeType));
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(sitemapFile);
        XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
        manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
        XmlNode renamedNode = xmlDoc.SelectSingleNode("//sm:siteMapNode[@resourceKey='" + nodeID + "']", manager);
        renamedNode.Attributes["title"].Value = newName;

        xmlDoc.Save(sitemapFile);
    }

    public class JsTree
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public List<JsTree> Children { get; set; }
    }

    #endregion
}