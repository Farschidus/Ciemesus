using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using BLL;

public partial class ControlP_UserManager_AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            try
            {
                AddUser();
                Response.Redirect("AddUser.aspx");
            }
            catch (Exception ex)
            {
                ConfirmationMessage.InnerText = "Error: " + ex.Message;
            }
        }
    }

    protected void AddUser()
    {
        // Add User.
        MembershipUser newUser = Membership.CreateUser(username.Text, password.Text, email.Text);
        newUser.Comment = comment.Text;
        newUser.IsApproved = isapproved.Checked;
        Membership.UpdateUser(newUser);

        // Add Roles.
        foreach (ListItem rolebox in UserRoles.Items)
        {
            if (rolebox.Selected)
            {
                Roles.AddUserToRole(username.Text, rolebox.Text);
            }
        }
    }
    private void Page_PreRender()
    {
        UserRoles.DataSource = Roles.GetAllRoles();
        UserRoles.DataBind();
    }
}
