﻿using BLL.BusinessEntity;
using Farschidus.Web.UI.WebControls;
using System;
using System.Web.UI.WebControls;

public partial class PSM_Gallery_Default : BaseCP
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
                subjects.LoadByIDSubjectType(Convert.ToByte(ddlListGalleryType.SelectedValue));
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
            pShowBodyGalleryManager = pShowBannerManager = pShowPluginManager = pShowThumbnailManager = true;
            grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
            Title = Farschidus.Translator.AppTranslate["galleryManaging.default.page.title"];            
            mInitialBindings();
        }
        listPager.PageSizeSelectClause = Farschidus.Translator.AppTranslate["general.label.pager.pageSizeSelectClause"];
        listPager.GoToClause = Farschidus.Translator.AppTranslate["general.label.pager.goToClause"];
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pListMode = ListMode.Search;
        listPager.CurrentIndex = 1;

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
    protected override void btnDelete_Click(object sender, EventArgs e)
    {
        pMessage.Clear();
        bool hasSelect = false;
        Guid item;
        Subjects subject = new Subjects();
        foreach (GridViewRow grvRow in grvList.Rows)
        {
            if (((CheckBox)grvRow.FindControl("chkList")).Checked)
            {
                item = new Guid(grvList.DataKeys[grvRow.RowIndex][Subjects.ColumnNames.IDSubject].ToString());
                subject.LoadByPrimaryKey(item);
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
        mClear();
        pListMode = ListMode.LoadAll;
        mLoadList();
    }
    protected override void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCategory.Items.Clear();
        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
        ddlCategory.Items.Add(liInitial);

        Subjects categories = new Subjects();
        categories.LoadByIDSubjectTypeAndIDLanguage((byte)SubjectTypes.Enum.category, pLanguageID);
        categories.Sort = Subjects.ColumnNames.Priority;
        ddlCategory.DataSource = categories.DefaultView;
        ddlCategory.DataTextField = Subjects.ColumnNames.Title;
        ddlCategory.DataValueField = Subjects.ColumnNames.IDSubject;
        ddlCategory.DataBind();

        mLoadAll();
    }
    protected void ddlListGalleryType_SelectedIndexChanged(object sender, EventArgs e)
    {
        pListMode = ListMode.LoadAll;
        listPager.CurrentIndex = 1;
        mLoadList();
    }
    protected void grvList_RowDraged(object sender, GridViewRowDragedEventArgs e)
    {
        string daraggedPriority = grvList.DataKeys[e.DragedRowIndex][Subjects.ColumnNames.Priority].ToString();
        string targetPriority = grvList.DataKeys[e.TargetRowIndex][Subjects.ColumnNames.Priority].ToString();
        bool direction = !(e.Status == Farschidus.Web.UI.WebControls.DragStatus.After);
        this.ReOrder(pSubjects, daraggedPriority, targetPriority, direction);
    }
    protected void grvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pIDSubject = new Guid(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0].ToString());
        e.Cancel = true;
        pListMode = ListMode.Edit;
        mFillForm();
    }
    protected void grvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Guid iDSubject = new Guid(grvList.DataKeys[Convert.ToInt32(e.RowIndex)][0].ToString());
        //if (mValidateDelete(iDSubject))
        //{
            mDelete(iDSubject);
        //}
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        mLoadList();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        mLoadList();
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {
        BLL.Hardcodes.Tables deafaultView = new BLL.Hardcodes.Tables();
        ddlGalleryTypeSearch.DataSource = ddlAddEditGalleryType.DataSource = ddlListGalleryType.DataSource = deafaultView.GalleryTypes;
        ddlGalleryTypeSearch.DataTextField = ddlAddEditGalleryType.DataTextField = ddlListGalleryType.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        ddlGalleryTypeSearch.DataValueField = ddlAddEditGalleryType.DataValueField = ddlListGalleryType.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        ddlListGalleryType.DataBind();
        ddlAddEditGalleryType.DataBind();
        ddlGalleryTypeSearch.DataBind();

        ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
        ddlCategory.Items.Add(liInitial);

        Subjects categories = new Subjects();
        categories.LoadByIDSubjectTypeAndIDLanguage((byte)SubjectTypes.Enum.category, pLanguageID);
        categories.Sort = Subjects.ColumnNames.Priority;
        ddlCategory.DataSource = categories.DefaultView;
        ddlCategory.DataTextField = Subjects.ColumnNames.Title;
        ddlCategory.DataValueField = Subjects.ColumnNames.IDSubject;
        ddlCategory.DataBind();

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
        subjects.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount,
         null,
         Convert.ToByte(ddlListGalleryType.SelectedValue),
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
        listPager.ItemCount = itemCount;

        grvList.DataSource = subjects.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mSearch()
    {
        int itemCount = 0;
        Subjects subjects = new Subjects();

        string title = "";
        if (!string.IsNullOrEmpty(txtTitleSearch.Text))
        {
            title = txtTitleSearch.Text.Trim();
        }
        string alias = "";
        if (!string.IsNullOrEmpty(txtAliasSearch.Text))
        {
            alias = Global.MethodsAndProps.mAliasCorrection(txtAliasSearch.Text.Trim());
        }

        subjects.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount,
         null,
         Convert.ToByte(ddlGalleryTypeSearch.SelectedValue),
         null,
         pLanguageID,
         null,
         title,
         null,
         alias,
         null,
         null,
         null,
         null,
         null,
         SubjectTypes.ColumnNames.Priority);
        listPager.ItemCount = itemCount;

        grvList.DataSource = subjects.DefaultView;
        grvList.DataBind();
        ddlListGalleryType.SelectedValue = ddlGalleryTypeSearch.SelectedValue;
        uplList.Update();
    }
    private void mFillForm()
    {
        Subjects subject = new Subjects();
        subject.LoadByIDSubjectAndIDLanguage(pIDSubject.Value, pLanguageID);

        txtAlias.Text = subject.pAlias;
        txtTitle.Text = subject.pTitle;
        HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
        TCMEValue.Value = subject.pBody;
        cbxIsActive.Checked = subject.pIsActive;
        if (subject.IsColumnNull(Subjects.ColumnNames.IDParent))
            ddlCategory.SelectedIndex = 0;
        else
            ddlCategory.SelectedValue = subject.pIDParent.ToString();

        mSetPopupData(subject);

        //lblPageID.Text = pIDSubject.Value.ToString();
        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        if (!Global.MethodsAndProps.mIsAliasUnique(txtAlias.Text, Convert.ToByte(ddlAddEditGalleryType.SelectedValue), pLanguageID, pIDSubject))
        {
                isValid = false;
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.aliasDuplication"], Farschidus.Web.UI.Message.MessageTypes.Error);
        }        
        return isValid;
    }
    private bool mValidateDelete(Guid iDSubject)
    {       
        pMessage.Clear();
        bool isValid = true;
        Subjects subject = new Subjects();
        subject.LoadByIDGallery(iDSubject);

        if (subject.RowCount > 0)
        {            
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["galleryManaging.default.message.subjectGalleryRelation"], Farschidus.Web.UI.Message.MessageTypes.Warning);
            do
            {   
                pMessage.Add(subject.pTitle, Farschidus.Web.UI.Message.MessageTypes.Information);
            }
            while (subject.MoveNext());
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
                if (pIDSubject.HasValue)
                {
                    subjects.LoadByPrimaryKey(pIDSubject.Value);
                }
                else
                {
                    subjects.AddNew();
                    subjects.pPriority = mSetPriority();
                    pIDSubject = subjects.pIDSubject = Guid.NewGuid();                    
                    subjects.pDate = DateTime.UtcNow.AddHours(Global.MethodsAndProps.TimeZone);
                    isNew = true;
                }

                subjects.pIDSubjectType = Convert.ToByte(ddlAddEditGalleryType.SelectedValue);
                subjects.pIDLanguage = pLanguageID;
                subjects.pTitle = txtTitle.Text;
                HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
                subjects.pBody = System.Web.HttpUtility.HtmlDecode(TCMEValue.Value);
                subjects.pIsActive = cbxIsActive.Checked;
                if (ddlCategory.SelectedIndex != 0)
                    subjects.pIDParent = new Guid(ddlCategory.SelectedValue);
                else
                    subjects.SetColumnNull(Subjects.ColumnNames.IDParent);
                subjects.pAlias = Global.MethodsAndProps.mAliasCorrection(txtAlias.Text);
                subjects.Save();

                if(pIDSubject.HasValue)
                    Global.MethodsAndProps.mUpdateSiteMap(subjects.pIDSubject.ToString(), subjects.pAlias, Global.Constants.STRING_GALLERY_MODULE);
                
                if (isNew)
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
    private void mDelete(Guid iDSubject, bool loadList = true)
    {
        if (mValidateDelete(iDSubject))
        {
            DAL.GlobalCore.TransactionMgr tx = DAL.GlobalCore.TransactionMgr.ThreadTransactionMgr();
            try
            {
                tx.BeginTransaction();
                MediaSubjects mediaSubjects = new MediaSubjects();
                mediaSubjects.LoadByIDSubject(iDSubject);
                mediaSubjects.DeleteAll();
                mediaSubjects.Save();

                SubjectPlugins subjectPlugin = new SubjectPlugins();
                subjectPlugin.LoadByIDSubject(iDSubject);
                subjectPlugin.DeleteAll();
                subjectPlugin.Save();

                GalleryPlugins GalleryPlugins = new GalleryPlugins();
                GalleryPlugins.LoadByIDSubject(iDSubject);
                GalleryPlugins.DeleteAll();
                GalleryPlugins.Save();                


                Subjects subject = new Subjects(iDSubject);
                subject.MarkAsDeleted(false);
                subject.Save();

                tx.CommitTransaction();
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
                tx.RollbackTransaction();
                pMessage.Clear();
                pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);                
            }            
        }
        mShowMessage(pMessage);
    }
    private void mClear()
    {
        HiddenField TCMEValue = (HiddenField)tinyMCE.FindControl("TCMEValue");
        txtTitle.Text = txtAlias.Text = TCMEValue.Value = string.Empty;
        cbxIsActive.Checked = true;
        pIDSubject = null;
        ddlAddEditGalleryType.SelectedIndex = ddlCategory.SelectedIndex = 0;
        uplAddEdit.Update();
    }

    private int mSetPriority()
    {
        Subjects subjects = new Subjects();
        subjects.LoadByIDSubjectType(Convert.ToByte(ddlAddEditGalleryType.SelectedValue));
        subjects.Sort = Subjects.ColumnNames.Priority;
        if (subjects.RowCount > 0)
        {
            subjects.MoveTo(subjects.RowCount - 1);
            if (!subjects.IsColumnNull(Subjects.ColumnNames.Priority))
            {
                return subjects.pPriority + 1;
            }
            else
            {
                subjects.Rewind();
                int i = 1;
                if (subjects.RowCount > 0)
                {
                    do
                    {
                        subjects.pPriority = i;
                        i++;
                    }
                    while (subjects.MoveNext());
                }
                return i++;
            }
        }
        else
        {
            return 1;
        }
    }
    private void ReOrder(Subjects unorderedSubjects, string draggedPriority, string targetPriority, bool direction)
    {
        string initFilter = "";
        if (!string.IsNullOrEmpty(unorderedSubjects.Filter))
        {
            initFilter = unorderedSubjects.Filter + " AND ";
        }
        unorderedSubjects.Filter = initFilter + string.Format("{0}={1}", Subjects.ColumnNames.Priority, draggedPriority);
        unorderedSubjects.pPriority = -1;

        if (direction)
        {
            unorderedSubjects.Filter = initFilter + string.Format("{0}>={1} AND {0} < {2}", Subjects.ColumnNames.Priority, targetPriority, draggedPriority);
            if (unorderedSubjects.RowCount > 0)
            {
                do
                {
                    unorderedSubjects.pPriority += 1;
                } while (unorderedSubjects.MoveNext());
            }
        }
        else
        {
            unorderedSubjects.Filter = initFilter + string.Format("{0}>{1} AND {0} <= {2}", Subjects.ColumnNames.Priority, draggedPriority, targetPriority);
            if (unorderedSubjects.RowCount > 0)
            {
                do
                {
                    unorderedSubjects.pPriority -= 1;
                } while (unorderedSubjects.MoveNext());
            }
        }
        unorderedSubjects.Filter = initFilter + string.Format("{0}={1}", Subjects.ColumnNames.Priority, "-1");
        unorderedSubjects.pPriority = Convert.ToInt32(targetPriority);

        pSubjects = unorderedSubjects;
        Subjects subjects = new Subjects();
        subjects = pSubjects;
        subjects.Save();

        mLoadAll();
        pMessage.Add(Farschidus.Translator.AppTranslate["general.message.reordered"], Farschidus.Web.UI.Message.MessageTypes.Success);
        mShowMessage(pMessage);
    }
    private void mSetPopupData(Subjects subject)
    {
        hdfData.Value = string.Format("{0}|{1}", subject.pIDSubject.ToString(), pLanguageID);
        pUpdatePanelToolbarButtons.Update();
    }
    public string mGetPageURL()
    {
        return Global.MethodsAndProps.mGetHtmlLink(pIDSubject, SubjectTypes.Enum.imageGallery);
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

    #endregion
}