using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class PSM_Settings_Default : BaseCP
{
    #region "Properties"

    public Guid? pIDSubject
    {
        get
        {
            if (ViewState["pIDSubject"] == null)
            {
                return null;
            }
            return new Guid(ViewState["pIDSubject"].ToString());
        }
        set
        {
            ViewState["pIDSubject"] = value;
        }
    }
    public Subjects pSubjects
    {
        get
        {
            Subjects subjects = new Subjects();
            if (ViewState["pSubjects"] == null)
            {
                subjects.LoadByIDSubjectType((byte)SubjectTypes.Enum.page);
                ViewState["pSubjects"] = subjects.Serialize();
            }
            else
            {
                subjects.Deserialize(ViewState["pSubjects"].ToString());
            }
            return subjects;
        }
        set
        {
            ViewState["pSubjects"] = value.Serialize();
        }
    }
    private string pFileExtension
    {
        get
        {
            return Session["pFileExtension"].ToString();
        }
        set
        {
            Session["pFileExtension"] = value;
        }
    }
    private Guid pTempMediaID
    {
        get
        {
            if (ViewState["pTempMediaID"] == null)
            {
                ViewState["pTempMediaID"] = Guid.NewGuid();
            }
            return new Guid(ViewState["pTempMediaID"].ToString());
        }
        set
        {
            ViewState["pTempMediaID"] = value;
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShowPluginManager = pShowThumbnailManager = true;
            pShownSearchButton = pShownDeleteButton = false;
            Title = Farschidus.Translator.AppTranslate["settingPage.default.page.title"];
            mInitialBindings();
        }
    }
    protected override void btnCreate_Click(object sender, EventArgs e)
    {
        //pListMode = ListMode.LoadAll;
        //mFillForm();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
        uplAddEdit.Update();
    }
    protected void fulImages_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        string strFavTemp = Global.Constants.IMAGE_TEMP_FAVICON;

        if (fulImage.HasFile)
        {
            fulImage.SaveAs(MapPath(strFavTemp));
        }
    }

    protected override void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        mLoadAll();
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {   
        Languages lang = new Languages();
        lang.LoadActiveLanguages();

        ddlCpDefLang.DataSource = ddlPubDefLang.DataSource = lang.DefaultView;
        ddlCpDefLang.DataTextField = ddlPubDefLang.DataTextField = Languages.ColumnNames.Title;
        ddlCpDefLang.DataValueField = ddlPubDefLang.DataValueField = Languages.ColumnNames.IDLanguage;

        ddlPubDefLang.DataBind();
        ddlPubDefLang.SelectedValue = Farschidus.Translator.PublicDefaultLanguage.ToString();

        ddlCpDefLang.DataBind();
        ddlCpDefLang.SelectedValue = Farschidus.Translator.CpDefaultLanguage.ToString();

        mLoadList();
    }
    private void mLoadList()
    {
        switch (pListMode)
        {
            case ListMode.LoadAll:
                mLoadAll();
                break;
            case ListMode.Search:
                mSearch();
                break;
        }
    }
    private void mLoadAll()
    {
        mFillForm();
    }
    private void mSearch()
    {
    }
    private void mFillForm()
    {
        Languages langCode = new Languages(pLanguageID);

        ddlTimezone.SelectedValue = Farschidus.Configuration.ConfigurationManager.Settings["Website", "TimeZone"];
        ddlServerDateFormat.SelectedValue = Farschidus.Configuration.ConfigurationManager.Settings["Website", "ServerDateFormat"];

        txtThumbWidth.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Thumbnail", "Dimention", "width");
        txtThumbHeight.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Thumbnail", "Dimention", "height");
        txtMail.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Email", "UserName", "value");
        txtMailPass.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Email", "Password", "value");
        txtMailHost.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Email", "Host", "value");
        txtMailPort.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Email", "Port", "value");
        txtlistPageHorizontal.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemInnerText("ListType", "List");
        txtListPageVertical.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemInnerText("ListType", "Grid");
        cbxSinglePage.Checked = Convert.ToBoolean(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "SinglePage", "value"));
        cbxRedirectToHome.Checked = Convert.ToBoolean(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "RedirectToHome", "value"));

        if (Farschidus.Configuration.ConfigurationManager.Settings.IsItemExisted("Website", "Name", "langCode", langCode.pCode))                    
            txtwebsiteName.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "Name", "langCode", langCode.pCode);       
        else        
            txtwebsiteName.Text = string.Empty;

        if (Farschidus.Configuration.ConfigurationManager.Settings.IsItemExisted("Metatags", "KeyWords", "langCode", langCode.pCode))
            txtMetaKeyWord.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Metatags", "KeyWords", "langCode", langCode.pCode);
        else
            txtMetaKeyWord.Text = string.Empty;

        if (Farschidus.Configuration.ConfigurationManager.Settings.IsItemExisted("Metatags", "Description", "langCode", langCode.pCode))
            txtMetaDesc.Text = Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Metatags", "Description", "langCode", langCode.pCode);
        else
            txtMetaDesc.Text = string.Empty;        
       
        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        bool isValid = true;
        return isValid;
    }
    private bool mValidateDelete(Guid iDSubject)
    {
        return true;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            try
            {
                if (File.Exists(MapPath(Global.Constants.IMAGE_TEMP_FAVICON)))
                {
                    string strFavFile = "~" + Global.Constants.IMAGE_PUBLIC_FAVICON;

                    if (File.Exists(MapPath(strFavFile)))
                        File.Delete(MapPath(strFavFile));
                    
                    File.Move(MapPath(Global.Constants.IMAGE_TEMP_FAVICON), MapPath(strFavFile));
                }

                Farschidus.Translator.SetPublicDefaultLanguage(ddlPubDefLang.SelectedValue);
                Farschidus.Translator.SetCPDefaultLanguage(ddlCpDefLang.SelectedValue);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Website", "TimeZone", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, ddlTimezone.SelectedValue);                
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Website", "ServerDateFormat", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, ddlServerDateFormat.SelectedValue);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Thumbnail", "Dimention", "width", txtThumbWidth.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Thumbnail", "Dimention", "height", txtThumbHeight.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Email", "UserName", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtMail.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Email", "Password", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtMailPass.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Email", "Host", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtMailHost.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Email", "Port", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtMailPort.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemInnerText("ListType", "Grid", txtListPageVertical.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemInnerText("ListType", "List", txtlistPageHorizontal.Text);
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Website", "SinglePage", "value", cbxSinglePage.Checked.ToString());
                Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Website", "RedirectToHome", "value", cbxRedirectToHome.Checked.ToString());
                
                Languages langCode = new Languages(pLanguageID);

                if (Farschidus.Configuration.ConfigurationManager.Settings.IsItemExisted("Website", "Name", "langCode", langCode.pCode))                                    
                    Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Website", "Name", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtwebsiteName.Text, "langCode", langCode.pCode);                
                else                
                    Farschidus.Configuration.ConfigurationManager.Settings.AddItem("Website", "Name", txtwebsiteName.Text, "langCode", langCode.pCode);                

                if (Farschidus.Configuration.ConfigurationManager.Settings.IsItemExisted("Metatags", "KeyWords", "langCode", langCode.pCode))                
                    Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Metatags", "KeyWords", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtMetaKeyWord.Text, "langCode", langCode.pCode);                
                else
                    Farschidus.Configuration.ConfigurationManager.Settings.AddItem("Metatags", "KeyWords", txtwebsiteName.Text, "langCode", langCode.pCode);                

                if (Farschidus.Configuration.ConfigurationManager.Settings.IsItemExisted("Metatags", "Description", "langCode", langCode.pCode))
                    Farschidus.Configuration.ConfigurationManager.Settings.UpdateItemAttribute("Metatags", "Description", Farschidus.Configuration.ConfigurationManager.STRING_VALUE, txtMetaDesc.Text, "langCode", langCode.pCode);                
                else
                    Farschidus.Configuration.ConfigurationManager.Settings.AddItem("Metatags", "Description", txtMetaDesc.Text, "langCode", langCode.pCode);
                

                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);
            }
            catch (Exception ex)
            {
                pMessage.Clear();
                pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
                mShowMessage(pMessage);
            }
        }
    }
    private void mDelete(Guid iDSubject)
    {
    }
    private void mClear()
    { 
        pIDSubject = null;
        uplAddEdit.Update();
    }

    #endregion
}