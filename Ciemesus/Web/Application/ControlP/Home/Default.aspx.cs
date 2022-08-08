using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class ControlP_Home_Default : BaseCP
{
    #region "Properties"

    public Guid? pIDSubject
    {
        get
        {
            if (ViewState["pIDSubject"] == null)
            {
                return null;
            }
            return new Guid(ViewState["pIDSubject"].ToString());
        }
        set
        {
            ViewState["pIDSubject"] = value;
        }
    }
    public Subjects pSubjects
    {
        get
        {
            Subjects subjects = new Subjects();
            if (ViewState["pSubjects"] == null)
            {
                subjects.LoadByIDSubjectType((byte)SubjectTypes.Enum.page);
                ViewState["pSubjects"] = subjects.Serialize();
            }
            else
            {
                subjects.Deserialize(ViewState["pSubjects"].ToString());
            }
            return subjects;
        }
        set
        {
            ViewState["pSubjects"] = value.Serialize();
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShowMediaManager = pShowBodyGalleryManager = pShowBannerManager = pShowPluginManager = pShowThumbnailManager = true;
            pShownSearchButton = pShownLoadAllButton = pShownDeleteButton = false;
            grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
            Title = Farschidus.Translator.AppTranslate["homePageManaging.default.page.title"];
            mInitialBindings();
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pListMode = ListMode.Search;
        mLoadList();
    }
    protected override void btnLoadAll_Click(object sender, EventArgs e)
    {
        pListMode = ListMode.LoadAll;
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
        pIDSubject = new Guid(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0].ToString());
        e.Cancel = true;
        pListMode = ListMode.Edit;
        mFillForm();
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {
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
        int itemCount = 0;
        Subjects subjects = new Subjects();
        subjects.Search(0, 0, ref itemCount,
         null,
        (byte)SubjectTypes.Enum.home,
         null,
         pLanguageID,
         null,
         null,
         null,
         null,
         null,
         null,
         null,
         null,
         null,
         SubjectTypes.ColumnNames.Priority);
        if (subjects.RowCount > 0)
            pShownCreateButton = false;
        else
            pShownCreateButton = true;

        pUpdatePanelToolbarButtons.Update();

        grvList.DataSource = subjects.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mSearch()
    {
        int itemCount = 0;
        Subjects subjects = new Subjects();

        string iDHeaderGallery = "";
        if (!string.IsNullOrEmpty(txtIDHeaderGallerySearch.Text))
        {
            iDHeaderGallery = txtIDHeaderGallerySearch.Text.Trim();
        }
        string bannerType = "";
        if (!string.IsNullOrEmpty(txtBannerTypeSearch.Text))
        {
            bannerType = txtBannerTypeSearch.Text.Trim();
        }
        string alias = "";
        if (!string.IsNullOrEmpty(txtAliasSearch.Text))
        {
            alias = txtAliasSearch.Text.Trim();
        }

        subjects.Search(0, 0, ref itemCount,
         null,
        (byte)SubjectTypes.Enum.home,
         null,
         pLanguageID,
         null,
         null,
         null,
         alias,
         null,
         null,
         null,
         bannerType,
         null,
         SubjectTypes.ColumnNames.Priority);

        grvList.DataSource = subjects.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mFillForm()
    {
        Subjects subjec = new Subjects(pIDSubject.Value);
       
        //txtAlias.Text = No need as there is a constant "Home" for this page url
        txtTitle.Text = subjec.pTitle;
        HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
        TCMEValue.Value = subjec.pBody;
        cbxIsActive.Checked = subjec.pIsActive;

        mSetPopupData(subjec);

        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        // Validation logic goes here (Validate Example is in Phases Default page)
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
                if (pIDSubject.HasValue)
                {
                    subjects.LoadByPrimaryKey(pIDSubject.Value);
                }
                else
                {
                    subjects.AddNew();
                    pIDSubject = subjects.pIDSubject = Guid.NewGuid();
                    isNew = true;
                }

                subjects.pIDSubjectType = (byte)SubjectTypes.Enum.home;
                subjects.pIDLanguage = pLanguageID;
                subjects.pTitle = txtTitle.Text;
                HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
                subjects.pBody = System.Web.HttpUtility.HtmlDecode(TCMEValue.Value);
                subjects.pIsActive = cbxIsActive.Checked;
                subjects.pDate = DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone);
                //subjects.pAlias = no Need as there is a constant "Home" for this page url
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
    private void mClear()
    {
        HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
        txtTitle.Text = TCMEValue.Value = string.Empty;
        cbxIsActive.Checked = true;
        pIDSubject = null;
        uplAddEdit.Update();
    }
    private void mSetPopupData(Subjects subject)
    {
        hdfData.Value = string.Format("{0}|{1}", subject.pIDSubject.ToString(), pLanguageID);
        pUpdatePanelToolbarButtons.Update();
    }

    #endregion

    #region "Public Methodes"

    public string mGetGalleryTypeName(string type)
    {
        if (!string.IsNullOrEmpty(type))
        {
            Subjects.BannerTypes headerTypes = (Subjects.BannerTypes)Enum.Parse(typeof(Subjects.BannerTypes), type);
            return Farschidus.Translator.AppTranslate["headerTypes.title." + headerTypes.ToString()];
        }
        else
        {
            return Farschidus.Translator.AppTranslate["headerTypes.title.inActive"];
        }
    }
    public string mGetPageURL()
    {
        return Global.MethodsAndProps.mGetHtmlLink(pIDSubject, SubjectTypes.Enum.home);
    }

    #endregion
}