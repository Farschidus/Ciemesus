using System;
using System.Web;
using System.Web.UI;

public partial class Application_Ascx_BodyGalleryManager : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BodyGalleryPopupFrame.Attributes["src"] = BodyGalleryPopupFrame.Attributes["src"] + HttpContext.Current.Request.Url.Query;
    }
}