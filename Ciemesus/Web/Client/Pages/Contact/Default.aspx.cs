using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_Page_Default : BasePublic
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInitBindings();
            pTitle = litPageTitle.Text = Farschidus.Translator.AppTranslate["ascx.contact.lable.title"];
        }
    }
    private void mInitBindings()
    {
    }
}