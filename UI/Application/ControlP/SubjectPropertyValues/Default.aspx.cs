using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class PSM_SubjectPropertyValues_Default : BaseCP
{
    #region "Properties"

    public int? pIDSubjectPropertyValue
    {
        get
        {
            if (ViewState["pIDSubjectPropertyValue"] == null)
            {
                return null;
            }
            return (int)ViewState["pIDSubjectPropertyValue"];
        }
        set
        {
            ViewState["pIDSubjectPropertyValue"] = value;
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    pShowMediaManager = pShowBannerManager = pShowPluginManager = pShowThumbnailManager = true;
        //    pShownSearchButton = true;
        //    grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
        //    Title = Farschidus.Translator.AppTranslate["replacewithModuleName.default.page.title"];
        //    listPager.PageSizeSelectClause = Farschidus.Translator.AppTranslate["general.label.pager.pageSizeSelectClause"];
        //    listPager.GoToClause = Farschidus.Translator.AppTranslate["general.label.pager.goToClause"];
        //    mInitialBindings();
        //}
    }
    protected override void btnLoadAll_Click(object sender, EventArgs e)
    {
        //pListMode = ListMode.LoadAll;
        //listPager.CurrentIndex = 1;
        //mLoadList();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //pListMode = ListMode.Search;
        //listPager.CurrentIndex = 1;

        //mLoadList();
    }
    protected override void btnCreate_Click(object sender, EventArgs e)
    {
        //mClear();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        //mSave();
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        //mLoadList();
    }
    protected void grvList_RowDraged(object sender, GridViewRowDragedEventArgs e)
    {
        // Use "e" Arquments: e.Status, e.ComandName, e.ComandName, e.DragedRowIndex, e.TargetRowIndex;
    }
    protected void grvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //mClear();
        //pIDSubjectPropertyValue = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0]);
        //e.Cancel = true;
        //mFillForm();
    }
    protected void grvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //iDSubjectPropertyValue = Convert.To(grvList.DataKeys[Convert.ToInt32(e.RowIndex)][0]);
        //if (mValidateDelete(iDSubjectPropertyValue))
        //{
        //    mDelete(iDSubjectPropertyValue);
        //}
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        //mLoadList();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        //mLoadList();
    }

    #endregion

    #region "Methodes"

    private void mInitialBindings()
    {
        //mLoadList();

        //// Put ddls loading here like the example below:
        //PhaseStatuses statuses = new PhaseStatuses();
        //statuses.LoadAll();
        //ddlPhaseStatuses.DataSource = statuses.DefaultView;
        //ddlPhaseStatuses.DataTextField = DAL.DataAccess._PhaseStatuses.ColumnNames.Title;
        //ddlPhaseStatuses.DataValueField = DAL.DataAccess._PhaseStatuses.ColumnNames.IDPhaseStatus;
        //ddlPhaseStatuses.DataBind();
    }
    private void mLoadList()
    {
        //switch (pListMode)
        //{
        //    case ListMode.LoadAll:
        //        mLoadAll();
        //        break;
        //    case ListMode.Search:
        //        mSearch();
        //        break;
        //}
    }
    private void mLoadAll()
    {
        //int itemCount = 0;
        //SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues();
        //subjectPropertyValues.LoadAll(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount, null);

        //listPager.ItemCount = itemCount;

        //grvList.DataSource = subjectPropertyValues.DefaultView;
        //grvList.DataBind();
        //uplList.Update();
    }
    private void mSearch()
    {
        //   int itemCount = 0;
        //   SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues();

        //   string iDSubject = "";
        //   if (!string.IsNullOrEmpty(txtIDSubjectSearch.Text))
        //   {
        //       iDSubject = txtIDSubjectSearch.Text.Trim();
        //   }
        //   string iDProperty = "";
        //   if (!string.IsNullOrEmpty(txtIDPropertySearch.Text))
        //   {
        //       iDProperty = txtIDPropertySearch.Text.Trim();
        //   }
        //   string value = "";
        //   if (!string.IsNullOrEmpty(txtValueSearch.Text))
        //   {
        //       value = txtValueSearch.Text.Trim();
        //   }

        //   subjectPropertyValues.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount,
        //iDSubject,
        //iDProperty,
        //value,
        //null);
        //   listPager.ItemCount = itemCount;

        //   grvList.DataSource = subjectPropertyValues.DefaultView;
        //   grvList.DataBind();
        //   uplList.Update();
    }
    private void mFillForm()
    {
        //SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues(pIDSubjectPropertyValue.Value);
        //txtIDSubject.Text = subjectPropertyValues.pIDSubject;
        //txtIDProperty.Text = subjectPropertyValues.pIDProperty;
        //txtValue.Text = subjectPropertyValues.pValue;
        //uplAddEdit.Update();
    }
    //private bool mValidateAddEdit()
    //{
    //    pMessage.Clear();
    //    bool isValid = true;
    //    // Validation logic goes here (Validate Example is in Phases Default page)
    //    return isValid;
    //}
    //private bool mValidateDelete( iDSubjectPropertyValue)
    //{
    //    return true;
    //}
    private void mSave()
    {
        //if (mValidateAddEdit())
        //{
        //    try
        //    {
        //    SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues();
        //    if (pIDSubjectPropertyValue.HasValue)
        //    {
        //        subjectPropertyValues.LoadByPrimaryKey(pIDSubjectPropertyValue.Value);
        //    }
        //    else
        //    {
        //        subjectPropertyValues.AddNew();
        //    }
        //subjectPropertyValues.pIDSubject = txtIDSubject.Text;
        //subjectPropertyValues.pIDProperty = txtIDProperty.Text;
        //subjectPropertyValues.pValue = txtValue.Text;

        //    subjectPropertyValues.Save();
        //    pMessage.Clear();
        //    pMessage.Add(Farschidus.Translator.AppTranslate["message.addEdit.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
        //    mShowMessage(pMessage);

        //    if (!pIDSubjectPropertyValue.HasValue)
        //    {
        //        mClear();
        //    }
        //    }
        //    catch (Exception ex)
        //    {
        //        pMessage.Clear();
        //        pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
        //        mShowMessage(pMessage);
        //    }
        //}
        //else
        //{
        //    mShowMessage(pMessage);
        //}
    }
    //private void mDelete( iDSubjectPropertyValue)
    //{
    //try
    //{
    //    SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues(iDSubjectPropertyValue);
    //    subjectPropertyValues.MarkAsDeleted(false);

    //    pMessage.Clear();
    //    pMessage.Add(Farschidus.Translator.AppTranslate["message.delete.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
    //    mShowMessage(pMessage);

    //    subjectPropertyValues.Save();
    //    mLoadList();
    //}
    //catch (Exception ex)
    //{
    //    pMessage.Clear();
    //    pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
    //    mShowMessage(pMessage);
    //}
    //}
    private void mClear()
    {
        //txtIDSubject.Text = txtIDProperty.Text = txtValue.Text = string.Empty;
        //    pIDSubjectPropertyValue = null;
        //    uplAddEdit.Update();
    }

    #endregion
}
