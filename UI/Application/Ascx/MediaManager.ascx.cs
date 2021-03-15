using System;
using System.Web;

public partial class Application_Ascx_MediaManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            MediaPopupFrame.Attributes["src"] = MediaPopupFrame.Attributes["src"] + HttpContext.Current.Request.Url.Query;
    }
}