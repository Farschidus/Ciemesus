using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI;

public class BasePage : System.Web.UI.Page
{
    protected Message pMessage = new Message();
    protected void mShowMessage(Message Message)
    {
        if (!string.IsNullOrEmpty(Message.HtmlText))
            this.mShowMessage(Message.HtmlText);
    }
    protected void mShowMessage(string Message)
    {
        ((Panel)this.Master.Master.FindControl("pnlNotification")).Visible = true;
        ((Literal)this.Master.Master.FindControl("lblNotificationMessage")).Text = Message;
        ((UpdatePanel)this.Master.Master.FindControl("udpNotification")).Update();
    }
}