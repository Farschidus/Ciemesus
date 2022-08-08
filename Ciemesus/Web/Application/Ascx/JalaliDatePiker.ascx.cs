using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class Application_Ascx_JalaliDatePiker : System.Web.UI.UserControl
{
    #region "Properties"

    private string cssClass;
    public string CssClass
    {
        get
        {
            return cssClass;
        }
        set
        {
            cssClass = value;
        }
    }

    public string JalaliDate
    {
        get
        {
            return txtJalaliDatePicker.Text;
        }
        set
        {
            txtJalaliDatePicker.Text = value;
        }
    }


    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlLink link = new HtmlLink();
        link.Attributes.Add("href", ResolveUrl(Global.Constants.FOLDER_APPLICATION_STYLE + cssClass));
        link.Attributes.Add("type", "text/css");
        link.Attributes.Add("rel", "stylesheet");
        Page.Header.Controls.Add(link);

        LiteralControl persianDatePickerRef = new LiteralControl("<script type='text/javascript' src='" + Global.Constants.FILE_SCRIPTS_PERSIANDATEPIKER + "'></script>");
        Page.Header.Controls.Add(persianDatePickerRef);

        ScriptManager scriptManager = new ScriptManager();
        string script = @"$(document).ready(function () { Sys.WebForms.PageRequestManager.getInstance().add_endRequest(bindCalendar); });
                                function bindCalendar() { $('input.jalaliDatePicker').persianDatepicker(); }";
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "txtJalaliDatePicker", script, true);
    }
}