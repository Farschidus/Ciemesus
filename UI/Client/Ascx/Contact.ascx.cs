using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_Ascx_Contact : System.Web.UI.UserControl
{
    private bool typeVisibility = true;
    public bool TypeVisibility
    {
        get { return typeVisibility; }
        set { typeVisibility = value; }
    }

    private ContactType type;
    public ContactType Type
    {
        get { return type; }
        set { type = value; }
    }

    private string xmlPath
    {
        get
        {
            if (ViewState["ContactXmlPath"] == null)
                return null;
            else
                return ViewState["ContactXmlPath"].ToString();
        }
        set
        {
            ViewState["ContactXmlPath"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            revEmail.ErrorMessage = Farschidus.Translator.AppTranslate["ascx.contact.message.emailFormatError"];
            ddlType.Visible = TypeVisibility;
            xmlPath = string.Format("{0}{1}.xml", Global.Constants.FOLDER_CONTACTS, Global.MethodsAndProps.CurrentLanguageCode);
            mDDLBinding();
        }
    }
    private void mDDLBinding()
    {
        if (TypeVisibility && System.IO.File.Exists(Server.MapPath(xmlPath)))
        {
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(Server.MapPath(xmlPath));

            ddlType.DataSource = dsXml;
            ddlType.DataTextField = "title";
            ddlType.DataValueField = "id";
            ddlType.DataBind();

            lblTitle.Text = dsXml.Tables[0].Rows[0]["title"].ToString();
            lblEmail.Text = dsXml.Tables[0].Rows[0]["email"].ToString();
            lblPhone.Text = dsXml.Tables[0].Rows[0]["phone"].ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>");
            lblFax.Text = dsXml.Tables[0].Rows[0]["fax"].ToString();
            lblAddress.Text = dsXml.Tables[0].Rows[0]["address"].ToString().Replace("\r\n", "<br/>").Replace("\n", "<br/>");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath(xmlPath));
        XmlNode root = xmlDoc.DocumentElement;
        XmlNode departmentNode = root.SelectSingleNode(string.Format("//Departments/Department[@id='{0}']", ddlType.SelectedValue));
        string sendTo = departmentNode.SelectSingleNode("email").InnerText;
        mSendEmail(sendTo, txtEmail.Text, txtName.Text, txtBody.Text);
        mClear();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Server.MapPath(xmlPath));
        XmlNode root = xmlDoc.DocumentElement;
        XmlNode departmentNode = root.SelectSingleNode(string.Format("//Departments/Department[@id='{0}']", ddlType.SelectedValue));

        lblTitle.Text = departmentNode.SelectSingleNode("title").InnerText;
        lblEmail.Text = departmentNode.SelectSingleNode("email").InnerText;
        lblPhone.Text = departmentNode.SelectSingleNode("phone").InnerText.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
        lblFax.Text = departmentNode.SelectSingleNode("fax").InnerText;
        lblAddress.Text = departmentNode.SelectSingleNode("address").InnerText.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
    }
    private void mSendEmail(string sendTo, string email, string name, string body)
    {
        DataSet dsXml = new DataSet();
        dsXml.ReadXml(Server.MapPath(xmlPath));
        try
        {
            Global.MethodsAndProps.mSendEmail(
                dsXml.Tables[0].Rows[0]["email"].ToString(),
                dsXml.Tables[0].Rows[0]["title"].ToString(),
                sendTo,
                dsXml.Tables[0].Rows[0]["subject"].ToString() + DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone).ToString(" MM/dd/yyyy HH:mm:ss"),
                "Sender Name: " + name + "<br/>Sender Email: " + email + "<br/><p>" + Global.MethodsAndProps.mCleanHtmlTags(body) + "</p>"
            );

            lblMessage.Text = Farschidus.Translator.AppTranslate["ascx.contact.message.sendSuccessful"];
        }
        catch (Exception ex)
        {
            lblMessage.Text = Farschidus.Translator.AppTranslate["general.message.error"] + " " + ex.Message;
        }
    }
    private void mClear()
    {
        txtEmail.Text = txtBody.Text = txtName.Text = string.Empty;
    }

    public enum ContactType
    {
        Contact,
        Opinion,
        Critique,
        Suggestion,
        Praise
    }
}