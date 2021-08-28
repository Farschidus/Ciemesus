using System;
using System.Web.Security;

public partial class Pages_Registration_Default : BasePublic
{
    private MembershipUser pCurrentUser
    {
        get
        {
            return Membership.GetUser(System.Web.HttpContext.Current.User.Identity.Name);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            litPageTitle.Text = pTitle = Farschidus.Translator.AppTranslate["registration.page.default.title"];
            mInitialBindings();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }

    private void mInitialBindings()
    {
        if (User.Identity.IsAuthenticated)
        {
            mFillForm();
        }

        BLL.Hardcodes.Tables hcTables = new BLL.Hardcodes.Tables();
        rblGender.DataSource = hcTables.Gender;
        rblGender.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        rblGender.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        rblGender.DataBind();
    }
    private void mFillForm()
    {
        var userProfile = GetProfileInstance.GetProfile(pCurrentUser.UserName);

        lblUserName.Text = pCurrentUser.UserName;
        lblUserName.Visible = true;
        rfvUserName.Enabled = rfvPasswordCreate.Enabled = rfvRepeatPassword.Enabled = false;
        txtUserNameCreate.Visible = false;
        txtEmail.Text = pCurrentUser.Email;
        txtPasswordCreate.Text = txtRepeatPassword.Text = string.Empty;
        txtFirstName.Text = userProfile.FirstName;
        txtLastName.Text = userProfile.LastName;
        rblGender.SelectedValue = Convert.ToByte(userProfile.Gender).ToString();
        txtTel.Text = userProfile.Tel;
        txtMobile.Text = userProfile.Mobile;
        txtState.Text = userProfile.State;
        txtCity.Text = userProfile.City;
        txtAddress.Text = userProfile.Address;
        txtDescription.Text = userProfile.Description;
        
        uplRegistration.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        return isValid;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            if (User.Identity.IsAuthenticated || !string.IsNullOrEmpty(txtUserNameCreate.Text.Trim()) && Membership.GetUser(txtUserNameCreate.Text.Trim()) == null)
            {
                try
                {
                    if (User.Identity.IsAuthenticated)
                    {
                        string email = pCurrentUser.Email;
                        if (!string.IsNullOrEmpty(txtEmail.Text) && !email.Equals(txtEmail.Text.Trim()))
                        {
                            pCurrentUser.Email = txtEmail.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(txtPasswordCreate.Text))
                        {
                            string tempPWD = pCurrentUser.ResetPassword();
                            pCurrentUser.ChangePassword(tempPWD, txtPasswordCreate.Text.Trim());
                        }
                        var userProfile = GetProfileInstance.GetProfile(pCurrentUser.UserName);

                        mUpdateProfile(userProfile);
                        
                        Membership.UpdateUser(pCurrentUser);
                    }
                    else
                    {
                        Membership.CreateUser(txtUserNameCreate.Text.Trim(), txtPasswordCreate.Text.Trim(), txtEmail.Text.Trim());
                        MembershipUser membershipUser = Membership.GetUser(txtUserNameCreate.Text.Trim());
                        Roles.AddUserToRole(membershipUser.UserName, Global.Constants.STRING_ROLE_MEMBER);
                        var userProfile = GetProfileInstance.GetProfile(membershipUser.UserName);

                        mUpdateProfile(userProfile);
                        
                        membershipUser.IsApproved = true;
                        Membership.UpdateUser(membershipUser);
                    }

                    pMessage.Clear();
                    pMessage.Add(Farschidus.Translator.AppTranslate["registration.page.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                    mShowMessage(pMessage);

                    string mailBody = string.Format("<span>شما یک ثبت نام جدید با نام {0} {1} دارید:</span>", txtFirstName.Text, txtLastName.Text);
                    Global.MethodsAndProps.mSendEmail("noreply@storr.ir", "Storr.ir = new user registeration", "info@storr.ir", "یک ثبت نام جدید در وب‌سایت فروشگاه", mailBody);

                    mClear();
                    Response.Redirect(string.Format(Global.Constants.PAGE_HOME_ASPX, Global.MethodsAndProps.CurrentLanguageCode));
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
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["registration.page.message.userExist"], Farschidus.Web.UI.Message.MessageTypes.Error);
                mShowMessage(pMessage);
            }
        }
        else
        {
            mShowMessage(pMessage);
        }
    }

    private void mUpdateProfile(ProfileCommon userProfile)
    {
        userProfile.SetPropertyValue("DateOfBirth", DateTime.UtcNow.AddHours(3.5));

        if (!string.IsNullOrEmpty(txtFirstName.Text))
            userProfile.SetPropertyValue("FirstName", txtFirstName.Text);

        if (!string.IsNullOrEmpty(txtLastName.Text))
            userProfile.SetPropertyValue("LastName", txtLastName.Text);
            
        if (!string.IsNullOrEmpty(rblGender.SelectedValue))
            userProfile.SetPropertyValue("Gender", Convert.ToBoolean(Convert.ToByte(rblGender.SelectedValue)));

        if (!string.IsNullOrEmpty(txtTel.Text))
            userProfile.SetPropertyValue("Tel", txtTel.Text);

        if (!string.IsNullOrEmpty(txtMobile.Text))
            userProfile.SetPropertyValue("Mobile", txtMobile.Text);

        if (!string.IsNullOrEmpty(txtCity.Text))
            userProfile.SetPropertyValue("City", txtCity.Text);

        if (!string.IsNullOrEmpty(txtAddress.Text))
            userProfile.SetPropertyValue("Address", txtAddress.Text);

        if (!string.IsNullOrEmpty(txtDescription.Text))
            userProfile.SetPropertyValue("Description", txtDescription.Text);

        userProfile.Save();
    }

    private void mClear()
    {
        txtUserNameCreate.Text = txtPasswordCreate.Text = txtRepeatPassword.Text = txtEmail.Text =
        txtFirstName.Text = txtLastName.Text =
        txtTel.Text = txtMobile.Text = txtState.Text = txtCity.Text = txtAddress.Text = txtDescription.Text = string.Empty;
        rblGender.SelectedIndex = 0;

        uplRegistration.Update();
    }
}