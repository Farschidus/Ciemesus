using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Application_Ascx_AlphabetLinks : System.Web.UI.UserControl
{
    private string[] letters = { "All", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K",
					"L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V",
					"W", "X", "Y", "Z"};	
    public String Letter
    {
        get
        {
            if (ViewState["AlphabetLinksSelectedLetter"] == null)
                ViewState["AlphabetLinksSelectedLetter"] = String.Empty;
            return ViewState["AlphabetLinksSelectedLetter"].ToString();
        }
        set
        {
            ViewState["AlphabetLinksSelectedLetter"] = value;
        }
    }
    public String LetterPercentSign
    {
        get
        {
            return Letter + "%";
        }
    }
    public delegate void OnSelectedChanged(object sender, EventArgs e);
    public event OnSelectedChanged SelectedChanged;
    
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Page_PreRender(object sender, EventArgs e)
	{
		rptrAlphabetLinks.DataSource = letters;
		rptrAlphabetLinks.DataBind();
	}
    protected void Select(object sender, CommandEventArgs e)
	{
        if (e.CommandArgument.ToString() == "All")
            ViewState["AlphabetLinksSelectedLetter"] = String.Empty;
        else
            ViewState["AlphabetLinksSelectedLetter"] = e.CommandArgument.ToString();

        if (SelectedChanged != null)
        {
            SelectedChanged(sender, new EventArgs());
        }
	}
    protected void DisableSelectedLink(object sender, RepeaterItemEventArgs e)
	{
		LinkButton lb = (LinkButton)e.Item.Controls[1];
        if ((lb.Text == Letter) || (lb.Text == "All" && Letter == String.Empty))
        {
            lb.Enabled = false;
            lb.CssClass = "alphabetSelected";
        }
	}
}
