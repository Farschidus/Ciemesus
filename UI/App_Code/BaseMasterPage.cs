using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using Farschidus.Web.UI;

public class BaseMasterPage : System.Web.UI.MasterPage
{
    protected Message pMessage = new Message();
    protected void mShowMessage(Message Message)
    {
        if (!string.IsNullOrEmpty(Message.HtmlText))
            this.mShowMessage(Message.HtmlText);
    }
    protected void mShowMessage(string Message)
    {
        ((Panel)this.Master.FindControl("pnlNotification")).Visible = true;
        ((Label)this.Master.FindControl("lblNotificationMessage")).Text = Message;
        ((UpdatePanel)this.Master.FindControl("udpNotification")).Update();
    }
}