using Farschidus.Web.UI;
using System.Web.UI;
using System.Web.UI.WebControls;

public class BasePage : Page
{
    protected Message pMessage = new Message();
    protected ProfileCommon GetProfileInstance
    {
        get
        {
            return ((ProfileCommon)(Context.Profile));
        }
    }
    protected void mShowMessage(Message Message)
    {
        if (!string.IsNullOrEmpty(Message.HtmlText))
            mShowMessage(Message.HtmlText);
    }
    protected void mShowMessage(string Message)
    {
        ((Panel)Master.Master.FindControl("pnlNotification")).Visible = true;
        ((Literal)Master.Master.FindControl("lblNotificationMessage")).Text = Message;
        ((UpdatePanel)Master.Master.FindControl("udpNotification")).Update();
    }
}