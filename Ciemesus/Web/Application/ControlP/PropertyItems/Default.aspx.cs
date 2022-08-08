using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class PSM_PropertyItems_Default : BaseCP
{
    #region "Properties"

    public int? pIDPropertyItem
    {
        get
        {
            if (ViewState["pIDPropertyItem"] == null)
            {
                return null;
            }
            return (int)ViewState["pIDPropertyItem"];
        }
        set
        {
            ViewState["pIDPropertyItem"] = value;
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShowMediaManager = pShowBannerManager = pShowPluginManager = pShowThumbnailManager = true;
            pShownSearchButton = true;
            grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
            Title = Farschidus.Translator.AppTranslate["propertyItems.default.page.title"];           
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
        mClear();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        mLoadList();
    }
    protected void grvList_RowDraged(object sender, GridViewRowDragedEventArgs e)
    {
        // Use "e" Arquments: e.Status, e.ComandName, e.ComandName, e.DragedRowIndex, e.TargetRowIndex;
    }
    protected void grvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        mClear();
        pIDPropertyItem = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0]);
        e.Cancel = true;
        mFillForm();
    }
    protected void grvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int iDPropertyItem = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.RowIndex)][0]);
        if (mValidateDelete(iDPropertyItem))
        {
            mDelete(iDPropertyItem);
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

    #endregion

    #region "Methodes"

    private void mInitialBindings()
    {
        mLoadList();

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
        PropertyItems propertyItems = new PropertyItems();
        propertyItems.LoadAll(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount, null);

        listPager.ItemCount = itemCount;

        grvList.DataSource = propertyItems.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mSearch()
    {
        int itemCount = 0;
        PropertyItems propertyItems = new PropertyItems();

        string title = "";
        if (!string.IsNullOrEmpty(txtTitleSearch.Text))
        {
            title = txtTitleSearch.Text.Trim();
        }

        propertyItems.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount,
     null,
     null,
     title,
     null);
        listPager.ItemCount = itemCount;

        grvList.DataSource = propertyItems.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mFillForm()
    {
        PropertyItems propertyItems = new PropertyItems(pIDPropertyItem.Value);
        //txtIDPropertyItem.Text = propertyItems.pIDPropertyItem;
        //txtIDProperty.Text = propertyItems.pIDProperty;
        txtTitle.Text = propertyItems.pTitle;
        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        // Validation logic goes here (Validate Example is in Phases Default page)
        return isValid;
    }
    private bool mValidateDelete(int iDPropertyItem)
    {
        return true;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            try
            {
                PropertyItems propertyItems = new PropertyItems();
                if (pIDPropertyItem.HasValue)
                {
                    propertyItems.LoadByPrimaryKey(pIDPropertyItem.Value);
                }
                else
                {
                    propertyItems.AddNew();
                }
                //propertyItems.pIDPropertyItem = txtIDPropertyItem.Text;
                //propertyItems.pIDProperty = txtIDProperty.Text;
                propertyItems.pTitle = txtTitle.Text;

                propertyItems.Save();
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["message.addEdit.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);

                if (!pIDPropertyItem.HasValue)
                {
                    mClear();
                }
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
    private void mDelete(int iDPropertyItem)
    {
        try
        {
            PropertyItems propertyItems = new PropertyItems(iDPropertyItem);
            propertyItems.MarkAsDeleted(false);

            pMessage.Clear();
            pMessage.Add(Farschidus.Translator.AppTranslate["message.delete.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
            mShowMessage(pMessage);

            propertyItems.Save();
            mLoadList();
        }
        catch (Exception ex)
        {
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
        }
    }
    private void mClear()
    {
        txtIDPropertyItem.Text = txtIDProperty.Text = txtTitle.Text = string.Empty;
        pIDPropertyItem = null;
        uplAddEdit.Update();
    }

    #endregion
}
