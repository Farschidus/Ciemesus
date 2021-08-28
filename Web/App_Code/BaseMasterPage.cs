using Farschidus.Web.UI;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BaseMasterPage : MasterPage
{
    protected Message pMessage = new Message();
    protected void mShowMessage(Message Message)
    {
        if (!string.IsNullOrEmpty(Message.HtmlText))
            mShowMessage(Message.HtmlText);
    }
    protected void mShowMessage(string Message)
    {
        ((Panel)Master.FindControl("pnlNotification")).Visible = true;
        ((Label)Master.FindControl("lblNotificationMessage")).Text = Message;
        ((UpdatePanel)Master.FindControl("udpNotification")).Update();
    }
}