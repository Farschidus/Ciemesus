using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BaseCP : BasePage
{
    #region Fields & Properties

    private LinkButton pCreateButton
    {
        get
        {
            return (LinkButton)this.Master.Master.FindControl("cphMainMaster").FindControl("btnCreate");
        }
    }
    private LinkButton pDeleteButton
    {
        get
        {
            return (LinkButton)this.Master.Master.FindControl("cphMainMaster").FindControl("btnDelete");
        }
    }
    private LinkButton pLoadAllButton
    {
        get
        {
            return (LinkButton)this.Master.Master.FindControl("cphMainMaster").FindControl("btnLoadAll");
        }
    }
    private LinkButton pSubmitButton
    {
        get
        {
            return (LinkButton)this.Master.Master.FindControl("cphMainMaster").FindControl("btnSubmit");
        }
    }
    private LinkButton pCancelButton
    {
        get
        {
            return (LinkButton)this.Master.Master.FindControl("cphMainMaster").FindControl("btnCancel");
        }
    }
    private DropDownList pLanguegesDropDownList
    {
        get
        {
            return (DropDownList)this.Master.Master.FindControl("cphMainMaster").FindControl("ddlLanguages");
        }
    }
    public UpdatePanel pUpdatePanelToolbarButtons
    {
        get
        {
            return (UpdatePanel)this.Master.Master.FindControl("cphMainMaster").FindControl("uplToolbarButtons");
        }
    }
    public ListMode pListMode
    {
        get
        {
            if (ViewState["pPageMode"] == null)
            {
                return ListMode.LoadAll;
            }
            return (ListMode)ViewState["pPageMode"];
        }
        set
        {
            ViewState["pPageMode"] = value;
        }
    }
    public byte pLanguageID
    {
        get
        {
            if (pLanguegesDropDownList.Items.Count < 1)
                return Farschidus.Translator.PublicDefaultLanguage;
            else
                return Convert.ToByte(pLanguegesDropDownList.SelectedValue);
        }
        set
        {
            pLanguegesDropDownList.SelectedValue = value.ToString();
            pUpdatePanelToolbarButtons.Update();
        }
    }
    public bool pShownSearchButton
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("liSearch"))).Visible = value;
        }
    }
    public bool pShownCreateButton
    {
        set
        {
            pCreateButton.Visible = value;
        }
    }
    public bool pShownDeleteButton
    {
        set
        {
            pDeleteButton.Visible = value;
        }
    }
    public bool pShownLoadAllButton
    {
        set
        {
            pLoadAllButton.Visible = value;
        }
    }
    public bool pShownSubmitButton
    {
        set
        {
            pSubmitButton.Visible = value;
        }
    }
    public bool pShownCancelButton
    {
        set
        {
            pCancelButton.Visible = value;
        }
    }
    public bool pShownLanguageDDL
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("liLanguageDDL"))).Visible = value;
        }
    }
    public bool pShowThumbnailManager
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("ThumbnailManager"))).Visible = value;
        }
    }
    public bool pShowBannerManager
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("BannerManager"))).Visible = value;
        }
    }
    public bool pShowPluginManager
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("PluginManager"))).Visible = value;
        }
    }
    public bool pShowMediaManager
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("MediaManager"))).Visible = value;
        }
    }
    public bool pShowPropertyManager
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("PropertyManager"))).Visible = value;
        }
    }
    public bool pShowPropertyValueManager
    {
        set
        {
            ((System.Web.UI.HtmlControls.HtmlGenericControl)(this.Master.Master.FindControl("cphMainMaster").FindControl("PropertyValueManager"))).Visible = value;
        }
    }

    #endregion

    #region Events

    protected override void OnInit(EventArgs e)
    {        
        pCreateButton.Click += new EventHandler(btnCreate_Click);
        pDeleteButton.Click += new EventHandler(btnDelete_Click);
        pLoadAllButton.Click += new EventHandler(btnLoadAll_Click);
        pSubmitButton.Click += new EventHandler(btnSubmit_Click);
        pCancelButton.Click += new EventHandler(btnCancel_Click);
        pLanguegesDropDownList.SelectedIndexChanged += new EventHandler(ddlLanguages_SelectedIndexChanged);

        base.OnInit(e);
    }

    #endregion

    #region Methods & Enums

    public enum ListMode
    {
        LoadAll = 1,
        Search,
        Edit
    }

    protected virtual void btnCreate_Click(object sneder, EventArgs e) { }
    protected virtual void btnDelete_Click(object sneder, EventArgs e) { }
    protected virtual void btnLoadAll_Click(object sneder, EventArgs e) { }
    protected virtual void btnSubmit_Click(object sneder, EventArgs e) { }
    protected virtual void btnCancel_Click(object sneder, EventArgs e) { }
    protected virtual void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e) { }

    #endregion
}