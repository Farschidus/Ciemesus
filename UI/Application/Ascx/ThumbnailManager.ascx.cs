using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Ascx_ThumbnailManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ThumbnailPopupFrame.Attributes["src"] = ThumbnailPopupFrame.Attributes["src"] + HttpContext.Current.Request.Url.Query;
    }
}