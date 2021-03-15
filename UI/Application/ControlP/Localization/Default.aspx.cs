using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Application_ControlP_Localization_Default : BaseCP
{
    #region "Properties"

    private List<TableRow> trs;
    private bool isLoaded
    {
        get 
        { 
            bool result = false;
            if (Session["isLoaded"] != null)
                Boolean.TryParse(Session["isLoaded"].ToString(), out result);
            return result;
        }
        set 
        {
            Session["isLoaded"] = value;
        }
    }
    private string parameters
    {
        get
        {
            return Session["parameters"].ToString();
        }
        set
        {
            Session["parameters"] = value;
        }
    }
    private string translateTemplateFile
    {
        get
        {
            string result = string.Empty;
            switch ((TranslatorType.Enum)(Enum.Parse(typeof(TranslatorType.Enum), ddlSection.SelectedValue)))
            {
                case TranslatorType.Enum.controlPanel:
                    {
                        result = Global.Constants.FOLDER_APP_LOCALE;
                        break;
                    }
                case TranslatorType.Enum.website:
                    {
                        result = Global.Constants.FOLDER_CLIENT_LOCALE;
                        break;
                    }
            }
            return string.Format("{0}{1}", result, Global.Constants.FILE_TRANSLATOR_TEMPLATE_XML);
        }
    }
    private string translateFile
    {
        get
        {
            string result = string.Empty;
            switch ((TranslatorType.Enum)(Enum.Parse(typeof(TranslatorType.Enum), ddlSection.SelectedValue)))
            {
                case TranslatorType.Enum.controlPanel:
                    {
                        result = Global.Constants.FOLDER_APP_LOCALE;
                        break;
                    }
                case TranslatorType.Enum.website:
                    {
                        result = Global.Constants.FOLDER_CLIENT_LOCALE;
                        break;
                    }
            }
            Languages lang = new Languages(pLanguageID);
            return string.Format("{0}{1}.xml", result, lang.pCode);
        }
    }

    #endregion

    #region "Events"

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        if (isLoaded)
        {
            string[] parames = parameters.Split(',');
            mBindingTextBox(parames[0], parames[1], parames[2], parames[3], Convert.ToBoolean(parames[4]));
        }
    }
    protected override void OnInit(EventArgs e)
    {
        if (isLoaded)
        {
            foreach (TableRow tr in trs)
            {
                tblModuleDetails.Rows.Add(tr);
            }
        }
        base.OnInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShownSearchButton = false;
            Title = Farschidus.Translator.AppTranslate["localization.default.page.title"];
            pShownLoadAllButton = pShownDeleteButton = false;
            ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
            ddlSection.Items.Add(liInitial);
            ddlModules.Items.Add(liInitial);
            BLL.Hardcodes.Tables tables = new BLL.Hardcodes.Tables();
            ddlSection.DataSource = tables.TranslatorTypes;
            ddlSection.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
            ddlSection.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
            ddlSection.DataBind();
        }
    }
    protected override void btnLoadAll_Click(object sender, EventArgs e)
    {
    }
    protected override void btnCreate_Click(object sender, EventArgs e)
    {
        uplAddEdit.Update();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        mClear();
        pListMode = ListMode.LoadAll;
        uplAddEdit.Update();
    }
    protected override void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlModules.SelectedIndex = 0;
        isLoaded = false;
        uplList.Update();
    }
    protected void ddlModules_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddlModules.SelectedIndex.Equals(0))
        {
            isLoaded = true;
            Languages lang = new Languages(pLanguageID);
            parameters = string.Format("{0},{1},{2},{3},{4}", lang.pCode, translateTemplateFile, translateFile, ddlModules.SelectedItem.Value, lang.pIsRTL.ToString());
        }
        else
        {
            isLoaded = false;
        }
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        mDDModulLBinding();
    }

    #endregion

    #region "Private Methodes"

    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        try
        {
            if (!File.Exists(Server.MapPath(translateFile)))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath(translateTemplateFile));
                XmlNode root = doc.DocumentElement;

                Languages lang = new Languages(pLanguageID);                
                root.Attributes["name"].Value = lang.pTitle;
                root.Attributes["full_name"].Value = lang.pCode;
                doc.Save(Server.MapPath(translateFile));
            }
            return true;
        }
        catch (Exception ex)
        {
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            return false;
        }

    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            DAL.GlobalCore.TransactionMgr tx = DAL.GlobalCore.TransactionMgr.ThreadTransactionMgr();
            try
            {
                tx.BeginTransaction();
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath(translateFile));
                XmlNode root = doc.DocumentElement;
                XmlNode messageNode = root.SelectSingleNode(string.Format("//message[@key='{0}']", ddlModules.SelectedItem.Value));

                Table tblModuleDetails = (Table)uplAddEdit.FindControl("tblModuleDetails");                
                foreach (TableRow row in tblModuleDetails.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        foreach (Control tb in cell.Controls)
                        {
                            if (tb is TextBox)
                            {
                                messageNode = root.SelectSingleNode(string.Format("//message[@key='{0}']", ((TextBox)tb).ID));
                                messageNode.InnerText = ((TextBox)tb).Text;
                            }
                        }
                    }
                }
                doc.Save(Server.MapPath(translateFile));

                tx.CommitTransaction();
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);
            }
            catch (Exception ex)
            {
                tx.RollbackTransaction();
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
    private void mClear()
    {
        tblModuleDetails.Rows.Clear();
    }
    private void mDDModulLBinding()
    {
        Languages lang = new Languages(pLanguageID);

        XmlDocument doc = new XmlDocument();
        if (ddlSection.SelectedValue.Equals("0"))
        {
            ddlModules.Enabled = false;
        }
        else
        {
            ddlModules.Enabled = true;            

            ddlModules.Items.Clear();
            ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
            ddlModules.Items.Add(liInitial);

            doc.Load(Server.MapPath(translateTemplateFile));
            XmlNodeList list = doc.GetElementsByTagName("module");

            foreach (XmlNode node in list)
            {
                ddlModules.Items.Add(new ListItem(node.Attributes["name"].InnerText));
            }
        }
    }
    private void mBindingTextBox(string languageCode, string templateFile, string targetFile, string moduleName, bool isRTL)
    {
        bool FileIsAvailble = false;
        XmlDocument targetDoc = new XmlDocument();
        XmlNode targetModuleNode = null;
        if (File.Exists(Server.MapPath(targetFile)))
        {
            FileIsAvailble = true;
            targetDoc.Load(Server.MapPath(targetFile));
            XmlNode targetRoot = targetDoc.DocumentElement;
            targetModuleNode = targetRoot.SelectSingleNode(string.Format("//locale/module[@name='{0}']", moduleName));
        }

        XmlDocument templateDoc = new XmlDocument();
        templateDoc.Load(Server.MapPath(templateFile));
        XmlNode root = templateDoc.DocumentElement;
        XmlNode templateModuleNode = root.SelectSingleNode(string.Format("//locale/module[@name='{0}']", moduleName));
        int i = 0;
        List<TableRow> trc = new List<TableRow>();

        foreach (XmlNode node in templateModuleNode)
        {
            TableRow tRow1 = new TableRow();
            TableRow tRow2 = new TableRow();
            TableCell tCell1 = new TableCell();
            TableCell tCell2 = new TableCell();

            tCell1.Text = templateModuleNode.ChildNodes[i].Attributes["key"].InnerText + "<br/>" + templateModuleNode.ChildNodes[i].InnerText;
            tCell1.CssClass = "left ltr";

            TextBox tx = new TextBox();
            tx.Attributes.Add("runat", "server");
            tx.Style["width"] = "819px";
            tx.Text = FileIsAvailble ? targetModuleNode.ChildNodes[i].InnerText : templateModuleNode.ChildNodes[i].InnerText;
            tx.ID = templateModuleNode.ChildNodes[i].Attributes["key"].InnerText;
            i++;

            tCell2.Controls.Add(tx);
            if (isRTL)
            {
                tCell2.CssClass = "right rtl";
            }
            else
            {
                tCell2.CssClass = "right ltr";
            }

            tRow1.Cells.Add(tCell1);
            tRow2.Cells.Add(tCell2);
            
            trc.Add(tRow1);
            trc.Add(tRow2);
        }
        trs = trc;
    }

    #endregion
}