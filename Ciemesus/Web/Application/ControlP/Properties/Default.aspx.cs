using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;
using System.Data;

public partial class PSM_Properties_Default : BaseCP
{
    #region "Properties"

    public int? pIDProperty
    {
        get
        {
            if (ViewState["pIDProperty"] == null)
            {
                return null;
            }
            return (int)ViewState["pIDProperty"];
        }
        set
        {
            ViewState["pIDProperty"] = value;
        }
    }
    public PropertyItems pPropertyItems
    {
        get
        {
            PropertyItems propertyItems = new PropertyItems();
            if (ViewState["pPropertyItems"] == null)
                ViewState["pPropertyItems"] = propertyItems.Serialize();
            else
                propertyItems.Deserialize(ViewState["pPropertyItems"].ToString());

            return propertyItems;
        }
        set
        {
            ViewState["pPropertyItems"] = value.Serialize();
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShowMediaManager = pShowBannerManager = pShowPluginManager = pShowThumbnailManager = false;
            pShownSearchButton = true;
            grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
            grvSingleSelectItems.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
            Title = Farschidus.Translator.AppTranslate["propertyManaging.default.page.title"];
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
    protected override void btnDelete_Click(object sender, EventArgs e)
    {
        pMessage.Clear();
        bool hasSelect = false;
        int item;
        Properties property = new Properties();
        foreach (GridViewRow grvRow in grvList.Rows)
        {
            if (((CheckBox)grvRow.FindControl("chkList")).Checked)
            {
                item = Convert.ToInt32(grvList.DataKeys[grvRow.RowIndex][Properties.ColumnNames.IDProperty].ToString());
                property.LoadByPrimaryKey(item);
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
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected override void btnCancel_Click(object sender, EventArgs e)
    {
        mLoadList();
    }
    protected override void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        mLoadAll();
    }
    protected void grvList_RowDraged(object sender, GridViewRowDragedEventArgs e)
    {
        //string daraggedPriority = grvList.DataKeys[e.DragedRowIndex][Subjects.ColumnNames.Priority].ToString();
        //string targetPriority = grvList.DataKeys[e.TargetRowIndex][Subjects.ColumnNames.Priority].ToString();
        //bool direction = !(e.Status == Farschidus.Web.UI.WebControls.DragStatus.After);
        //this.ReOrder(pSubjects, daraggedPriority, targetPriority, direction);
    }
    protected void grvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        pListMode = ListMode.Edit;
        mClear();
        pIDProperty = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0]);
        Properties property = new Properties(pIDProperty.Value);
        e.Cancel = true;
        PropertyTypes.Enum selectedType = (PropertyTypes.Enum)Enum.Parse(typeof(PropertyTypes.Enum), property.pIDType.ToString());
        mSetTableVisibility(selectedType);
        ddlProprtyTypes.Enabled = false;
        mFillForm();
    }
    protected void grvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int iDProperty = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.RowIndex)][0]);
        mDelete(iDProperty);
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        mLoadList();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        mLoadList();
    }
    protected void ddlProprtyTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        PropertyTypes.Enum propertyType = (PropertyTypes.Enum)Enum.Parse(typeof(PropertyTypes.Enum), ddlProprtyTypes.SelectedValue);
        mSetTableVisibility(propertyType);
    }
    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        PropertyItems propertyItems = new PropertyItems();
        propertyItems = pPropertyItems;

        propertyItems.AddNew();

        propertyItems.pTitle = txtSingleSelectItem.Text;
        pPropertyItems = propertyItems;
        grvSingleSelectItems.DataSource = pPropertyItems.DefaultView;
        grvSingleSelectItems.DataBind();

        txtSingleSelectItem.Text = string.Empty;
    }
    protected void grvSingleSelectItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Save")
        {
            int index = grvSingleSelectItems.EditIndex;

            GridViewRow row = grvSingleSelectItems.Rows[index];
            TextBox itemTitle = (TextBox)row.FindControl("txtGridItemTitle");

            PropertyItems propertyItems = new PropertyItems();
            propertyItems = pPropertyItems;
            propertyItems.MoveTo(index);
            
            propertyItems.pTitle = itemTitle.Text;
            pPropertyItems = propertyItems;
            grvSingleSelectItems.EditIndex = -1;
            grvSingleSelectItems.DataSource = pPropertyItems.DefaultView;
            grvSingleSelectItems.DataBind();
        }
    }
    protected void grvSingleSelectItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            PropertyItems propertyItems = new PropertyItems();
            propertyItems = pPropertyItems;
            propertyItems.MoveTo(e.RowIndex);
            propertyItems.MarkAsDeleted(false);

            pPropertyItems = propertyItems;

            grvSingleSelectItems.DataSource = pPropertyItems.DefaultView;
            grvSingleSelectItems.DataBind();
            uplAddEdit.Update();
        }
        catch (Exception ex)
        {
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
        }
    }
    protected void grvSingleSelectItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grvSingleSelectItems.EditIndex = e.NewEditIndex;

        PropertyItems propertyItems = new PropertyItems();
        propertyItems = pPropertyItems;

        grvSingleSelectItems.DataSource = propertyItems.DefaultView;
        grvSingleSelectItems.DataBind();
    }
    protected void grvSingleSelectItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        grvSingleSelectItems.EditIndex = -1;
    }
    protected void grvSingleSelectItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grvSingleSelectItems.EditIndex = -1;
        grvSingleSelectItems.DataSource = pPropertyItems.DefaultView;
        grvSingleSelectItems.DataBind();
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {
        BLL.Hardcodes.Tables hcTables = new BLL.Hardcodes.Tables();
        ddlProprtyTypes.DataSource = hcTables.PropertyTypes;
        ddlProprtyTypes.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
        ddlProprtyTypes.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
        ddlProprtyTypes.DataBind();
        mLoadList();
        ddlProprtyTypes.SelectedIndex = 0;
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
        Properties properties = new Properties();
        listPager.ItemCount = itemCount;
        properties.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount, null, pLanguageID, null, null, null);

        listPager.ItemCount = itemCount;
        grvList.DataSource = properties.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mSearch()
    {
        int itemCount = 0;
        Properties properties = new Properties();

        string iDType = "";
        if (!string.IsNullOrEmpty(txtIDTypeSearch.Text))
        {
            iDType = txtIDTypeSearch.Text.Trim();
        }
        string name = "";
        if (!string.IsNullOrEmpty(txtNameSearch.Text))
        {
            name = txtNameSearch.Text.Trim();
        }

        properties.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount,
         null,
         pLanguageID,
         null,
         name,
         null);
        listPager.ItemCount = itemCount;

        grvList.DataSource = properties.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mFillForm()
    {
        Properties properties = new Properties(pIDProperty.Value);
        ddlProprtyTypes.SelectedValue = properties.pIDType.ToString();
        txtName.Text = properties.pName;

        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;

        if (pListMode != ListMode.Edit)
        {
            Properties properties = new Properties();
            properties.LoadByIDLanguageAndIDTypeAndName(pLanguageID, Convert.ToByte(ddlProprtyTypes.SelectedValue), txtName.Text);
            if (properties.RowCount > 0)
            {
                isValid = false;
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.propertyDuplication"], Farschidus.Web.UI.Message.MessageTypes.Error);
            }
        }

        return isValid;
    }
    private bool mValidateDelete(int iDProperty)
    {
        //pMessage.Clear();
        bool isValid = true;
        SubjectProperties subjectProperties = new SubjectProperties();
        subjectProperties.LoadByIDProperty(iDProperty);
        if (subjectProperties.RowCount > 0)
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["propertyManaging.default.message.subjectPropertyRelation"], Farschidus.Web.UI.Message.MessageTypes.Warning);

            Subjects subject = new Subjects();
            do
            {
                subject.LoadByIDSubjectAndIDLanguage(subjectProperties.pIDSubject, pLanguageID);
                if (subject.RowCount > 0)
                {
                    pMessage.Add(subject.pAlias, Farschidus.Web.UI.Message.MessageTypes.Information);
                }
            }
            while (subjectProperties.MoveNext()); 
        }
        return isValid;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            try
            {
                Properties properties = new Properties();
                if (pIDProperty.HasValue)
                {
                    properties.LoadByPrimaryKey(pIDProperty.Value);
                }
                else
                {
                    properties.AddNew();
                }

                PropertyTypes.Enum selectedType = (PropertyTypes.Enum)Enum.Parse(typeof(PropertyTypes.Enum), ddlProprtyTypes.SelectedValue);

                properties.pName = txtName.Text;
                properties.pIDType = (byte)selectedType;
                properties.pIDLanguage = pLanguageID;

                properties.Save();
                if (selectedType == PropertyTypes.Enum.singleSelect || selectedType == PropertyTypes.Enum.multiSelect)
                    mSaveItem(properties.pIDProperty);

                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);

                if (!pIDProperty.HasValue)
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
        uplAddEdit.Update();
    }
    private void mSaveItem(int idProperty)
    {
        PropertyItems propertyItems = new PropertyItems();
        propertyItems = pPropertyItems;
        if (propertyItems.RowCount > 0)
        {
            do
            {
                propertyItems.pIDProperty = idProperty;
            }
            while (propertyItems.MoveNext());
        }
        propertyItems.Save();
    }
    private void mDelete(int iDProperty, bool loadList = true)
    {
        if (mValidateDelete(iDProperty))
        {
            try
            {
                Properties properties = new Properties(iDProperty);
                PropertyItems propertyItem = new PropertyItems();
                SubjectPropertyValues SubjectPropertyValue = new SubjectPropertyValues();

                SubjectPropertyValue.LoadByIDProperty(iDProperty);
                if (SubjectPropertyValue.RowCount > 0)
                {
                    SubjectPropertyValue.DeleteAll();
                    SubjectPropertyValue.Save();
                }

                propertyItem.LoadByIDProperty(iDProperty);
                if (propertyItem.RowCount > 0)
                {
                    propertyItem.DeleteAll();
                    propertyItem.Save();
                }

                properties.MarkAsDeleted(false);
                properties.Save();

                if (loadList)
                {
                    pMessage.Clear();
                    pMessage.Add(Farschidus.Translator.AppTranslate["general.message.deleted"], Farschidus.Web.UI.Message.MessageTypes.Success);
                    mShowMessage(pMessage);

                    mLoadAll();
                }
            }
            catch (Exception ex)
            {
                pMessage.Clear();
                pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
                mShowMessage(pMessage);
            }
        }
        mShowMessage(pMessage);
    }
    private void mClear()
    {
        txtName.Text = txtSingleSelectItem.Text = string.Empty;
        ddlProprtyTypes.SelectedIndex = 0;
        ddlProprtyTypes.Enabled = true;
        mSetTableVisibility(PropertyTypes.Enum.text);
        pIDProperty = null;
        grvSingleSelectItems.DataSource = null;
        grvSingleSelectItems.DataBind();
        uplAddEdit.Update();
    }

    private void mSetTableVisibility(PropertyTypes.Enum selectedType)
    {
        switch (selectedType)
        {
            case PropertyTypes.Enum.text:
            case PropertyTypes.Enum.integer:
            case PropertyTypes.Enum.floati:
            case PropertyTypes.Enum.trueFalse:
            case PropertyTypes.Enum.date:
            case PropertyTypes.Enum.time:
            case PropertyTypes.Enum.dateTime:
            case PropertyTypes.Enum.image:
                {
                    trSingleSelectItem.Visible = trItems.Visible = false;
                    break;
                }
            case PropertyTypes.Enum.singleSelect:
            case PropertyTypes.Enum.multiSelect:
                {
                    pPropertyItems.DeleteAll();
                    trSingleSelectItem.Visible = trItems.Visible = true;
                    PropertyItems propertyItems = new PropertyItems();
                    if (pIDProperty.HasValue)
                    {
                        propertyItems.LoadByIDProperty(pIDProperty.Value);
                    }
                    pPropertyItems = propertyItems;
                    txtSingleSelectItem.Text = "";

                    grvSingleSelectItems.DataSource = pPropertyItems.DefaultView;
                    grvSingleSelectItems.DataBind();
                    break;
                }
        }
    }

    //private void ReOrder(Properties unorderedSubjects, string draggedPriority, string targetPriority, bool direction)
    //{
    //    string initFilter = "";
    //    if (!string.IsNullOrEmpty(unorderedSubjects.Filter))
    //    {
    //        initFilter = unorderedSubjects.Filter + " AND ";
    //    }
    //    unorderedSubjects.Filter = initFilter + string.Format("{0}={1}", Subjects.ColumnNames.Priority, draggedPriority);
    //    unorderedSubjects.pPriority = -1;

    //    if (direction)
    //    {
    //        unorderedSubjects.Filter = initFilter + string.Format("{0}>={1} AND {0} < {2}", Subjects.ColumnNames.Priority, targetPriority, draggedPriority);
    //        if (unorderedSubjects.RowCount > 0)
    //        {
    //            do
    //            {
    //                unorderedSubjects.pPriority += 1;
    //            } while (unorderedSubjects.MoveNext());
    //        }
    //    }
    //    else
    //    {
    //        unorderedSubjects.Filter = initFilter + string.Format("{0}>{1} AND {0} <= {2}", Subjects.ColumnNames.Priority, draggedPriority, targetPriority);
    //        if (unorderedSubjects.RowCount > 0)
    //        {
    //            do
    //            {
    //                unorderedSubjects.pPriority -= 1;
    //            } while (unorderedSubjects.MoveNext());
    //        }
    //    }
    //    unorderedSubjects.Filter = initFilter + string.Format("{0}={1}", Subjects.ColumnNames.Priority, "-1");
    //    unorderedSubjects.pPriority = Convert.ToInt32(targetPriority);

    //    pSubjects = unorderedSubjects;
    //    Subjects subjects = new Subjects();
    //    subjects = pSubjects;
    //    subjects.Save();

    //    mLoadAll();

    //    pMessage.Add(Farschidus.Translator.AppTranslate["general.message.reordered"], Farschidus.Web.UI.Message.MessageTypes.Success);
    //    mShowMessage(pMessage);
    //}

    #endregion

    #region "Public Methodes"

    public string mGetPropertyTypeName(object IDType)
    {
        BLL.Hardcodes.Tables htTables = new BLL.Hardcodes.Tables();
        return htTables.PropertyTypes.Find(x => x.ID.ToString() == IDType.ToString()).Title;
    }

    #endregion
}