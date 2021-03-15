using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;
using System.Web.Security;

public partial class PSM_UserManager_Default : BaseCP
{
    #region "Properties"

    public Guid? pIDUser
    {
        get
        {
            if (ViewState["pIDUser"] == null)
            {
                return null;
            }
            return (Guid)ViewState["pIDUser"];
        }
        set
        {
            ViewState["pIDUser"] = value;
        }
    }
    public MembershipUser pMembershipUser
    {
        get
        {
            if (ViewState["pMembershipUser"] == null)
            {
                ViewState["pMembershipUser"] = Membership.GetUser(pIDUser.Value);
            }
            return (MembershipUser)ViewState["pMembershipUser"];
        }
        set
        {
            ViewState["pMembershipUser"] = value;
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShownLanguageDDL = false;
            Title = Farschidus.Translator.AppTranslate["userManager.default.page.title"];            
            mInitialBindings();
        }
        listPager.PageSizeSelectClause = Farschidus.Translator.AppTranslate["general.label.pager.pageSizeSelectClause"];
        listPager.GoToClause = Farschidus.Translator.AppTranslate["general.label.pager.goToClause"];
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pListMode = ListMode.Search;
        //Pager.CurrentIndex = 1;

        mLoadList();
    }
    protected override void btnLoadAll_Click(object sender, EventArgs e)
    {
        pListMode = ListMode.LoadAll;
        listPager.CurrentIndex = 1;
        mLoadList();
    }
    protected override void btnCreate_Click(object sender, EventArgs e)
    {
        lblUserName.Visible = false;
        txtUserName.Visible = true;
        mClear();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected override void btnDelete_Click(object sender, EventArgs e)
    {
        pMessage.Clear();
        bool hasSelect = false;
        Guid item;
        Members member = new Members();
        foreach (GridViewRow grvRow in grvList.Rows)
        {
            if (((CheckBox)grvRow.FindControl("chkList")).Checked)
            {
                item = new Guid(grvList.DataKeys[grvRow.RowIndex]["ProviderUserKey"].ToString());
                member.LoadByPrimaryKey(item);
                if (mValidateDelete(item))
                {
                    mDelete(item, false);
                    hasSelect = true;
                }
            }
        }
        if (hasSelect)
        {
            mLoadAll();
            pMessage.Add(Farschidus.Translator.AppTranslate["general.message.deleted"], Farschidus.Web.UI.Message.MessageTypes.Success);
        }
        mShowMessage(pMessage);
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        mLoadList();
    }
    protected void grvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        mClear();
        pIDUser = new Guid(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0].ToString());
        e.Cancel = true;
        mFillForm();
    }
    protected void grvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Guid iDUser = new Guid(grvList.DataKeys[Convert.ToInt32(e.RowIndex)][0].ToString());
        if (mValidateDelete(iDUser))
        {
            mDelete(iDUser);
        }
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        mLoadList();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        mLoadList();
    }
    protected void AlphabetLinkList_SelectedChanged(object sender, EventArgs e)
    {
        pListMode = ListMode.Search;
        mLoadList();
    }
    protected void ChangePassword(object sender, CommandEventArgs e)
    {
        pnlChangePassword.Visible = true;
        try
        {
            string UserName = e.CommandName;
            MembershipUser theUser = Membership.GetUser(UserName);
            lblPopupUsername.Text = theUser.UserName;
        }
        catch { }
    }
    protected void UserActivity(object sender, CommandEventArgs e)
    {
        try
        {
            string UserName = e.CommandArgument.ToString();
            MembershipUser theUser = Membership.GetUser(UserName);
            if (e.CommandName == "ActivateUser")
            {
                theUser.IsApproved = true;
            }
            if (e.CommandName == "InactivateUser")
            {
                theUser.IsApproved = false;
            }
            Membership.UpdateUser(theUser);
            mLoadList();
        }
        catch { }
        grvList.DataBind();
    }
    protected void UnlockUser(object sender, CommandEventArgs e)
    {
        try
        {
            string UserName = e.CommandArgument.ToString();
            MembershipUser theUser = Membership.GetUser(UserName);
            if (e.CommandName == "LockUser")
            {
                // Nothing can do!!!
            }
            if (e.CommandName == "UnlockUser")
            {
                theUser.UnlockUser();
            }
            mLoadList();
        }
        catch { }
        grvList.DataBind();
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser theUser = Membership.GetUser(lblPopupUsername.Text);
            string tempPWD = theUser.ResetPassword();
            theUser.ChangePassword(tempPWD, txtPopupNewPassword.Text);
            pnlChangePassword.Visible = false;

            pMessage.Clear();
            pMessage.Add(Farschidus.Translator.AppTranslate["general.message.passwordChaneged"], Farschidus.Web.UI.Message.MessageTypes.Success);
            mShowMessage(pMessage);
        }
        catch (Exception ex)
        {
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlChangePassword.Visible = false;
    }

    #endregion

    #region "Methodes"

    private void mInitialBindings()
    {
        cblUserRoles.DataSource = ddlRoleSearch.DataSource = Roles.GetAllRoles().Where(x => x != Global.Constants.STRING_ROLE_CIEMESUS).ToArray();
        ddlRoleSearch.DataBind();
        cblUserRoles.DataBind();

        BLL.Hardcodes.Tables hcTables = new BLL.Hardcodes.Tables();
        rblGender.DataSource = hcTables.SexTypes;
        rblGender.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        rblGender.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        rblGender.DataBind();
        
        mLoadList();
    }
    private void mLoadList()
    {
        switch (pListMode)
        {
            case ListMode.LoadAll:
                mLoadAll();
                break;
            case ListMode.Search:
                mSearch();
                break;
        }
    }
    private void mLoadAll()
    {
        grvList.DataSource = GetUsers(Farschidus.Web.Security.Membership.GetAllUsers("", "", "", "", ""));
        grvList.DataBind();

        uplList.Update();
    }
    private void mSearch()
    {
        string iDRole = string.Empty;
        if (!ddlRoleSearch.SelectedIndex.Equals(0))
        {
            iDRole = ddlRoleSearch.SelectedValue;
        }

        string isAproved = string.Empty;
        if (!ddlApprovalSearch.SelectedIndex.Equals(0))
        {
            isAproved = ddlApprovalSearch.SelectedValue;
        }

        string isLocked = string.Empty;
        if (!ddlLockUsersSearch.SelectedIndex.Equals(0))
        {
            isLocked = ddlLockUsersSearch.SelectedValue;
        }

        string isOnline = string.Empty;
        if (!ddlOnlineUsersSearch.SelectedIndex.Equals(0))
        {
            isOnline = ddlOnlineUsersSearch.SelectedValue;
        }

        grvList.DataSource = GetUsers(Farschidus.Web.Security.Membership.GetAllUsers(AlphabetLinkList.Letter, iDRole, isAproved, isLocked, isOnline));
        grvList.DataBind();
        uplList.Update();
    }
    private void mFillForm()
    {
        cblUserRoles.DataSource = Roles.GetAllRoles().Where(x => x != Global.Constants.STRING_ROLE_CIEMESUS).ToArray();
        cblUserRoles.DataBind();

        lblUserName.Text = pMembershipUser.UserName;
        lblUserName.Visible = true;
        txtUserName.Visible = false;

        string[] userRoles = Roles.GetRolesForUser(lblUserName.Text).Where(x => x != Global.Constants.STRING_ROLE_CIEMESUS).ToArray();
        foreach (string role in userRoles)
        {
            ListItem checkbox = cblUserRoles.Items.FindByValue(role);
            checkbox.Selected = true;
        }

        ProfileCommon userProfile = Profile.GetProfile(lblUserName.Text);

        txtEmail.Text = pMembershipUser.Email;
        txtFirstName.Text = userProfile.FirstName;
        txtLastName.Text = userProfile.LastName;
        txtDateOfBirth.Text = userProfile.DateOfBirth.ToShortDateString();
        rblGender.SelectedValue = Convert.ToByte(userProfile.Gender).ToString();
        txtTel.Text = userProfile.Tel;
        txtAddress.Text = userProfile.Address;

        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        bool isValid = true;
        return isValid;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            try
            {
                if (pIDUser.HasValue)
                {
                    string email = pMembershipUser.Email;
                    if (!string.IsNullOrEmpty(txtEmail.Text) && !email.Equals(txtEmail.Text.Trim()))
                    {
                        pMembershipUser.Email = txtEmail.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtPassword.Text))
                    {
                        string tempPWD = pMembershipUser.ResetPassword();
                        pMembershipUser.ChangePassword(tempPWD, txtPassword.Text.Trim());
                    }
                }
                else
                {
                    Membership.CreateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim(), txtEmail.Text.Trim());
                    MembershipUser membershipUser = Membership.GetUser(txtUserName.Text.Trim());
                    pIDUser = new Guid(membershipUser.ProviderUserKey.ToString());
                }

                Membership.UpdateUser(pMembershipUser);

                ProfileCommon userProfile = Profile.GetProfile(pMembershipUser.UserName);

                if (!string.IsNullOrEmpty(txtFirstName.Text))
                    userProfile.SetPropertyValue("FirstName", txtFirstName.Text);
                if (!string.IsNullOrEmpty(txtLastName.Text))
                    userProfile.SetPropertyValue("LastName", txtLastName.Text);
                if (!string.IsNullOrEmpty(txtDateOfBirth.Text))
                    userProfile.SetPropertyValue("DateOfBirth", Convert.ToDateTime(string.Format("{0} {1}", Convert.ToDateTime(txtDateOfBirth.Text).ToString(Global.MethodsAndProps.DateFormat), DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone).ToString("HH:mm:ss"))));
                if (!string.IsNullOrEmpty(rblGender.SelectedValue))
                    userProfile.SetPropertyValue("Gender", Convert.ToBoolean(Convert.ToByte(rblGender.SelectedValue)));
                if (!string.IsNullOrEmpty(txtTel.Text))
                    userProfile.SetPropertyValue("Tel", txtTel.Text);
                if (!string.IsNullOrEmpty(txtAddress.Text))
                    userProfile.SetPropertyValue("Address", txtAddress.Text);

                userProfile.Save();
                UpdateUserRoles();

                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);
            }
            catch (Exception ex)
            {
                pMessage.Clear();
                pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
                mShowMessage(pMessage);
            }
        }
        else
        {
            mShowMessage(pMessage);
        }
    }
    private bool mValidateDelete(Guid iDUser)
    {
        //Invoices invoice = new Invoices();
        //invoice.LoadByIDMember(iDUser);
        //if (invoice.RowCount > 0)
        //{
        //    pMessage.Clear();
        //    pMessage.Add(Farschidus.Translator.AppTranslate["users.profile.message.hasInvoice"], Farschidus.Web.UI.Message.MessageTypes.Warning);
        //    mShowMessage(pMessage);
        //    return false;
        //}
        //Activations activation = new Activations();
        //activation.LoadByIDMember(iDUser);
        //if (activation.RowCount > 0)
        //{
        //    pMessage.Clear();
        //    pMessage.Add(Farschidus.Translator.AppTranslate["users.profile.message.hasActivation"], Farschidus.Web.UI.Message.MessageTypes.Warning);
        //    mShowMessage(pMessage);
        //    return false;
        //}
        //else
        //{
        return true;
        //}
    }
    private void mDelete(Guid iDUser, bool loadList = true)
    {
        //DAL.GlobalCore.TransactionMgr tx = DAL.GlobalCore.TransactionMgr.ThreadTransactionMgr();
        try
        {
            //tx.BeginTransaction();

            Members member = new Members(iDUser);
            member.MarkAsDeleted(false);
            member.Save();

            MembershipUser user = Membership.GetUser(iDUser);
            Membership.DeleteUser(user.UserName, true);

            if (loadList)
            {
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.deleted"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);

                mLoadList();
            }
        }
        catch (Exception ex)
        {
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
            //tx.RollbackTransaction();
        }
    }
    private void mClear()
    {
        lblUserName.Text = txtUserName.Text = txtFirstName.Text = txtLastName.Text = txtEmail.Text =
            txtPassword.Text = txtDateOfBirth.Text = txtTel.Text = txtAddress.Text = string.Empty;
        pIDUser = null;
        pMembershipUser = null;

        foreach (ListItem rolebox in cblUserRoles.Items)
        {
            rolebox.Selected = false;
        }

        uplAddEdit.Update();
    }

    public string mGetUSerFullName(object idUser)
    {
        ProfileCommon userProfile = Profile.GetProfile(Membership.GetUser(idUser).UserName);
        if (userProfile != null)
            return userProfile.FirstName + " " + userProfile.LastName;
        else
            return "";
    }
    private string mGetRolesForUser(object username)
    {
        String result = String.Empty;
        try
        {
            string UserName = Convert.ToString(username);
            string[] rolez = Roles.GetRolesForUser(UserName);
            foreach (string role in rolez)
            {
                result += role + ", ";
            }
        }
        catch
        {
            return (result + "ERROR!!");
        }
        if (result.LastIndexOf(", ") > 0)
        {
            return result.Remove(result.LastIndexOf(", "));
        }
        else
        {
            return result;
        }
    }
    public string mGetVisibility(object IsLockedOut)
    {
        bool isLocked = Convert.ToBoolean(IsLockedOut);
        if (isLocked)
            return "display: none";
        else
            return "display: block";
    }
    private void UpdateUserRoles()
    {
        foreach (ListItem rolebox in cblUserRoles.Items)
        {
            if (rolebox.Selected)
            {
                if (!Roles.IsUserInRole(pMembershipUser.UserName, rolebox.Text))
                {
                    Roles.AddUserToRole(pMembershipUser.UserName, rolebox.Text);
                }
            }
            else
            {
                if (Roles.IsUserInRole(pMembershipUser.UserName, rolebox.Text))
                {
                    Roles.RemoveUserFromRole(pMembershipUser.UserName, rolebox.Text);
                }
            }
        }
    }
    private DataTable GetUsers(MembershipUserCollection muc)
    {
        listPager.ItemCount = muc.Count;
        int from = (listPager.CurrentIndex - 1) * listPager.PageSize;
        int to = listPager.PageSize;

        DataTable dt = new DataTable();
        dt.Columns.Add("UserName", Type.GetType("System.String"));
        dt.Columns.Add("ProviderUserKey", Type.GetType("System.Guid"));
        dt.Columns.Add("LastActivityDate", Type.GetType("System.DateTime"));
        dt.Columns.Add("IsApproved", Type.GetType("System.Boolean"));
        dt.Columns.Add("IsLockedOut", Type.GetType("System.Boolean"));

        foreach (MembershipUser mu in muc)
        {
            DataRow dr = dt.NewRow();
            dr["UserName"] = mu.UserName;
            dr["ProviderUserKey"] = mu.ProviderUserKey;
            dr["LastActivityDate"] = mu.LastActivityDate;
            dr["IsApproved"] = mu.IsApproved;
            dr["IsLockedOut"] = mu.IsLockedOut;
            dt.Rows.Add(dr);
        }

        System.Collections.Generic.IEnumerable<DataRow> rows = dt.AsEnumerable().Skip(from).Take(to);
        System.Collections.Generic.List<DataRow> newRows = rows.ToList<DataRow>();

        DataTable newDt = new DataTable();
        newDt.Columns.Add("UserName", Type.GetType("System.String"));
        newDt.Columns.Add("ProviderUserKey", Type.GetType("System.Guid"));
        newDt.Columns.Add("LastActivityDate", Type.GetType("System.DateTime"));
        newDt.Columns.Add("IsApproved", Type.GetType("System.Boolean"));
        newDt.Columns.Add("IsLockedOut", Type.GetType("System.Boolean"));

        foreach (DataRow row in newRows)
        {
            DataRow dr2 = newDt.NewRow();
            dr2["UserName"] = row["UserName"];
            dr2["ProviderUserKey"] = row["ProviderUserKey"];
            dr2["LastActivityDate"] = row["LastActivityDate"];
            dr2["IsApproved"] = row["IsApproved"];
            dr2["IsLockedOut"] = row["IsLockedOut"];
            newDt.Rows.Add(dr2);
        }

        return newDt;
    }

    #endregion
}