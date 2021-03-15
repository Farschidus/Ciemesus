using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Application_Ascx_BannerManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BannerPopupFrame.Attributes["src"] = BannerPopupFrame.Attributes["src"] + HttpContext.Current.Request.Url.Query;
    }
}