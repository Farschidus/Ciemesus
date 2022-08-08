using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Profile;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;
using System.Web.Security;

public partial class PSM_UserPages_Default : BaseCP
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
            return Membership.GetUser(pIDUser.Value);
        }
    }
    

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShowMediaManager = pShowBannerManager = pShowPluginManager = pShowThumbnailManager = true;
            pShownCreateButton = pShownDeleteButton = false;
            grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
            Title = Farschidus.Translator.AppTranslate["membersPageManager.default.page.title"];            
            mInitialBindings();
        }
        listPager.PageSizeSelectClause = Farschidus.Translator.AppTranslate["general.label.pager.pageSizeSelectClause"];
        listPager.GoToClause = Farschidus.Translator.AppTranslate["general.label.pager.goToClause"];
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pListMode = ListMode.Search;
        //listPager.CurrentIndex = 1;

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
        pListMode = ListMode.LoadAll;
        mClear();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
        uplAddEdit.Update();
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        mClear();
        pListMode = ListMode.LoadAll;
        mLoadList();
    }
    protected override void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        mLoadAll();
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

    #endregion

    #region "Methodes"

    private void mInitialBindings()
    {
        ddlRoleSearch.DataSource = Roles.GetAllRoles().Where(x => x != Global.Constants.STRING_ROLE_CIEMESUS).ToArray();
        ddlRoleSearch.DataBind();
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
        Subjects subject = new Subjects();
        subject.LoadBySubjectAliasAndIDSubjectType(pIDUser.Value.ToString(), (byte)SubjectTypes.Enum.userPage);
        if (subject.RowCount > 0)
        {
            txtTitle.Text = subject.pTitle;
            HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
            TCMEValue.Value = subject.pBody;
            cbxIsActive.Checked = subject.pIsActive;
            mSetPopupData(subject); 
        } 
        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        TextBox txtBody = (TextBox)tinyMCE.FindControl("txtBody");
        if (string.IsNullOrEmpty(txtTitle.Text) && string.IsNullOrEmpty(txtBody.Text))
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["general.message.fieldsEmpty"], Farschidus.Web.UI.Message.MessageTypes.Error);
        }
        return isValid;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            DAL.GlobalCore.TransactionMgr tx = DAL.GlobalCore.TransactionMgr.ThreadTransactionMgr();
            bool isNew = false;
            try
            {
                tx.BeginTransaction();
                Subjects subjects = new Subjects();
                subjects.LoadBySubjectAliasAndIDSubjectType(pIDUser.Value.ToString(), (byte)SubjectTypes.Enum.userPage);
                if (subjects.RowCount > 0)
                {
                    // Do Nothing, It's an Edit action
                }
                else
                {
                    subjects.AddNew();
                    subjects.pIDSubject = Guid.NewGuid();
                    subjects.pDate = DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone);
                    isNew = true;
                }

                subjects.pIDSubjectType = (byte)SubjectTypes.Enum.userPage;
                subjects.pIDLanguage = pLanguageID;
                subjects.pTitle = txtTitle.Text;
                HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
                subjects.pBody = System.Web.HttpUtility.HtmlDecode(TCMEValue.Value);
                subjects.pIsActive = cbxIsActive.Checked;
                subjects.pAlias = pIDUser.ToString();
                subjects.SetColumnNull(Subjects.ColumnNames.IDParent);
                    
                subjects.Save();

                if(isNew)
                    mSetPopupData(subjects);

                tx.CommitTransaction();
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);
            }
            catch (Exception ex)
            {
                tx.RollbackTransaction();
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
        //    pMessage.Add(Farschidus.Translator.Translate("users.profile.message.hasInvoice"), Farschidus.Web.UI.Message.MessageTypes.Warning);
        //    mShowMessage(pMessage);
        //    return false;
        //}
        //Activations activation = new Activations();
        //activation.LoadByIDMember(iDUser);
        //if (activation.RowCount > 0)
        //{
        //    pMessage.Clear();
        //    pMessage.Add(Farschidus.Translator.Translate("users.profile.message.hasActivation"), Farschidus.Web.UI.Message.MessageTypes.Warning);
        //    mShowMessage(pMessage);
        //    return false;
        //}
        //else
        //{
            return true;
        //}
    }
    private void mDelete(Guid iDUser)
    {
        DAL.GlobalCore.TransactionMgr tx = DAL.GlobalCore.TransactionMgr.ThreadTransactionMgr();
        try
        {
            Subjects subjects = new Subjects();
            subjects.LoadBySubjectAliasAndIDSubjectType(pIDUser.Value.ToString(), (byte)SubjectTypes.Enum.userPage);
            if (subjects.RowCount > 0)
            {
                tx.BeginTransaction();
                MediaSubjects mediaSubjects = new MediaSubjects();
                mediaSubjects.LoadByIDSubject(subjects.pIDSubject);
                mediaSubjects.DeleteAll();
                mediaSubjects.Save();

                SubjectPlugins subjectPlugin = new SubjectPlugins();
                subjectPlugin.LoadByIDSubject(subjects.pIDSubject);
                subjectPlugin.DeleteAll();
                subjectPlugin.Save();

                GalleryPlugins GalleryPlugins = new GalleryPlugins();
                GalleryPlugins.LoadByIDSubject(subjects.pIDSubject);
                GalleryPlugins.DeleteAll();
                GalleryPlugins.Save();

                Subjects subject = new Subjects(subjects.pIDSubject);
                subject.MarkAsDeleted(false);
                subject.Save();

                tx.CommitTransaction();
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.deleted"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);

                mLoadList();
            }
        }
        catch (Exception ex)
        {
            tx.RollbackTransaction();
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
        }
    }
    private void mClear()
    {
        HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
        txtTitle.Text = TCMEValue.Value = string.Empty;
        cbxIsActive.Checked = true;
        pIDUser = null;

        uplAddEdit.Update();
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
    private void mSetPopupData(Subjects subject)
    {
        hdfData.Value = string.Format("{0}|{1}", subject.pIDSubject.ToString(), pLanguageID);
        pUpdatePanelToolbarButtons.Update();
    }
    public string mGetUSerFullName(object idUser)
    {
        var userProfile = GetProfileInstance.GetProfile(Membership.GetUser(idUser).UserName);
        if (userProfile != null)
            return userProfile.FirstName + " " + userProfile.LastName;
        else
            return "";
    }

    #endregion
}