using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class ControlP_SubjectPropertyValues_Popup : BasePage
{
    #region "Properties"

    private Guid pSubjectID;
    private byte pLanguageID;

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (!hdfData.Value.Equals(string.Empty))
            {
                string[] Data = hdfData.Value.Split('|');
                pLanguageID = Convert.ToByte(Data[1]);
            }
            if (!hdfRefresh.Value.Equals("1001"))
                hdfRefresh.Value = "1000";
            //hdfData.Value is ready now
            mInitialBindings();
            hdfRefresh.Value = "1001";
        }
        else
        {
            this.DataBind();
            ListItem liInitial = new ListItem(Farschidus.Translator.AppTranslate["dropdown.initial.selectText"], "0");
            ddlSubjectProperties.Items.Add(liInitial);

            grvListPropertyValues.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
        }
    }
    protected void ddlSubjectProperties_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idProperty = int.Parse(ddlSubjectProperties.SelectedValue);
        Properties property = new Properties(idProperty);
        PropertyTypes.Enum selectedType = (PropertyTypes.Enum)Enum.Parse(typeof(PropertyTypes.Enum), property.pIDType.ToString());

        mFillForm(selectedType, idProperty);
    }
    protected void grvListPropertyValues_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int idProperty = int.Parse(grvListPropertyValues.DataKeys[Convert.ToInt32(e.RowIndex)][0].ToString());
        SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues(pSubjectID, idProperty);

        if (subjectPropertyValues.RowCount > 0)
        {
            subjectPropertyValues.MarkAsDeleted(false);
            subjectPropertyValues.Save();
            mLoadListPropertyValues();
            mClear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string result = string.Empty;
            int idProperty = Convert.ToInt32(ddlSubjectProperties.SelectedValue);
            SubjectPropertyValues subjectPropertyValue = new SubjectPropertyValues(pSubjectID, idProperty);
            Properties property = new Properties(idProperty);
            PropertyTypes.Enum selectedType = (PropertyTypes.Enum)Enum.Parse(typeof(PropertyTypes.Enum), property.pIDType.ToString());

            if (subjectPropertyValue.RowCount.Equals(0))
                subjectPropertyValue.AddNew();

            switch (selectedType)
            {
                case PropertyTypes.Enum.text:
                    {
                        result = txtText.Text;
                        break;
                    }
                case PropertyTypes.Enum.integer:
                    {
                        result = txtInteger.Text;
                        break;
                    }
                case PropertyTypes.Enum.floati:
                    {
                        result = txtFloati.Text;
                        break;
                    }
                case PropertyTypes.Enum.singleSelect:
                    {
                        result = rblSingleSelect.SelectedValue;
                        break;
                    }
                case PropertyTypes.Enum.multiSelect:
                    {
                        foreach (GridViewRow grvRow in grvMultiSelect.Rows)
                        {
                            if (((CheckBox)grvRow.FindControl("chkItemsList")).Checked)
                                result += grvMultiSelect.DataKeys[grvRow.RowIndex][PropertyItems.ColumnNames.IDPropertyItem] + ",";
                        }
                        if (!string.IsNullOrEmpty(result))
                            result = result.Substring(0, result.LastIndexOf(','));
                        break;
                    }
                case PropertyTypes.Enum.trueFalse:
                    {
                        result = chbTrueFalse.Checked.ToString();
                        break;
                    }
                case PropertyTypes.Enum.date:
                    {
                        if (pLanguageID == 2)
                        {
                            result = Farschidus.JalaliDateTime.ConvertToGregorianDate(ucJalaliDatePiker.JalaliDate).ToShortDateString();
                        }
                        else
                        {
                            result = txtDate.Text;
                        }
                        break;
                    }
                case PropertyTypes.Enum.time:
                    {
                        result = txtTime.Text;
                        break;
                    }
                case PropertyTypes.Enum.dateTime:
                    {
                        if (pLanguageID == 2)
                        {
                            result = Farschidus.JalaliDateTime.ConvertToGregorianDate(ucJalaliDatePiker.JalaliDate).ToShortDateString();
                        }
                        else
                        {
                            result = txtDate.Text;
                        }

                        result += " " + txtTime.Text;
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(result))
            {
                subjectPropertyValue.pIDSubject = pSubjectID;
                subjectPropertyValue.pIDProperty = Convert.ToInt32(ddlSubjectProperties.SelectedValue);
                subjectPropertyValue.pValue = result;
                subjectPropertyValue.Save();

                mLoadListPropertyValues();
                mClear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
            }
            else
            {
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.valueNotSet"], Farschidus.Web.UI.Message.MessageTypes.Warning);
            }
        }
        catch (Exception ex)
        {
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
        }
        finally
        {
            mShowMessage(pMessage);
        }
    }

    #endregion

    #region "Private Methodes"

    private void mInitialBindings()
    {
        if (!hdfData.Value.Equals(string.Empty))
        {
            string[] Data = hdfData.Value.Split('|');
            pSubjectID = new Guid(Data[0]);
            if (hdfRefresh.Value.Equals("1000"))
                mBindDdlSubjectProperties();
            mLoadListPropertyValues();
        }
    }
    private void mLoadListPropertyValues()
    {
        SubjectPropertyValues subjectPropertyValue = new SubjectPropertyValues();
        subjectPropertyValue.LoadByIDSubject(pSubjectID);
        grvListPropertyValues.DataSource = subjectPropertyValue.DefaultView;
        grvListPropertyValues.DataBind();
        uplPageList.Update();
    }
    private void mBindDdlSubjectProperties()
    {
        List<int> propertyIDs = new List<int>();
        mLoadRecursivlyByParentID(ref propertyIDs, pSubjectID);
        if (propertyIDs.Count > 0)
        {
            Properties properties = new Properties();
            properties.LoadAll();
            properties.Filter = string.Format("{0} IN ({1})", Properties.ColumnNames.IDProperty, string.Join(",", propertyIDs.ToArray()));

            ddlSubjectProperties.DataSource = properties.DefaultView;
            ddlSubjectProperties.DataTextField = Properties.ColumnNames.Name;
            ddlSubjectProperties.DataValueField = Properties.ColumnNames.IDProperty;
            ddlSubjectProperties.DataBind();
            uplAddEdit.Update();
        }
    }
    private void mFillForm(PropertyTypes.Enum selectedType, int idProperty)
    {
        string strValue = string.Empty;
        SubjectPropertyValues subjectPropertyValues = new SubjectPropertyValues(pSubjectID, idProperty);
        if (subjectPropertyValues.RowCount > 0)
            strValue = subjectPropertyValues.pValue;

        switch (selectedType)
        {
            case PropertyTypes.Enum.text:
                {
                    trText.Visible = true;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = false;
                    txtText.Text = strValue;
                    break;
                }
            case PropertyTypes.Enum.integer:
                {
                    trText.Visible = false;
                    trInteger.Visible = true;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = false;
                    txtInteger.Text = strValue;
                    break;
                }
            case PropertyTypes.Enum.floati:
                {
                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = true;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = false;
                    txtFloati.Text = strValue;
                    break;
                }
            case PropertyTypes.Enum.singleSelect:
                {
                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = true;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = false;

                    PropertyItems propertyItem = new PropertyItems();
                    propertyItem.LoadByIDProperty(idProperty);
                    rblSingleSelect.DataSource = propertyItem.DefaultView;
                    rblSingleSelect.DataTextField = PropertyItems.ColumnNames.Title;
                    rblSingleSelect.DataValueField = PropertyItems.ColumnNames.IDPropertyItem;
                    rblSingleSelect.DataBind();
                    if (!string.IsNullOrEmpty(strValue))
                        rblSingleSelect.SelectedValue = strValue;
                    break;
                }

            case PropertyTypes.Enum.multiSelect:
                {
                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = true;
                    trTrueFalse.Visible = false;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = false;

                    PropertyItems propertyItem = new PropertyItems();
                    propertyItem.LoadByIDProperty(idProperty);
                    grvMultiSelect.DataSource = propertyItem.DefaultView;
                    grvMultiSelect.DataBind();

                    if (!string.IsNullOrEmpty(strValue))
                    {
                        string[] values = strValue.Split(',');
                        foreach (string val in values)
                        {
                            foreach (GridViewRow grvRow in grvMultiSelect.Rows)
                            {
                                if (val.Equals(grvMultiSelect.DataKeys[grvRow.RowIndex][PropertyItems.ColumnNames.IDPropertyItem].ToString()))
                                {
                                    ((CheckBox)grvRow.FindControl("chkItemsList")).Checked = true;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                }
            case PropertyTypes.Enum.trueFalse:
                {
                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = true;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = false;
                    if (!string.IsNullOrEmpty(strValue))
                        chbTrueFalse.Checked = Convert.ToBoolean(strValue);
                    break;
                }
            case PropertyTypes.Enum.date:
                {

                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    if (pLanguageID == 2)
                    {
                        trDatePe.Visible = true;
                        trDate.Visible = false;
                        if (!string.IsNullOrEmpty(strValue))
                            ucJalaliDatePiker.JalaliDate = new Farschidus.JalaliDateTime(Convert.ToDateTime(strValue)).ToShortDateString();
                    }
                    else
                    {
                        trDatePe.Visible = false;
                        trDate.Visible = true;
                        if (!string.IsNullOrEmpty(strValue))
                            txtDate.Text = strValue;
                    }
                    trTime.Visible = false;
                    break;
                }
            case PropertyTypes.Enum.time:
                {
                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    trDate.Visible = false;
                    trDatePe.Visible = false;
                    trTime.Visible = true;
                    txtTime.Text = strValue;
                    break;
                }
            case PropertyTypes.Enum.dateTime:
                {
                    trText.Visible = false;
                    trInteger.Visible = false;
                    trFloati.Visible = false;
                    trSingleSelect.Visible = false;
                    trMultiSelect.Visible = false;
                    trTrueFalse.Visible = false;
                    if (pLanguageID.Equals(2))
                    {
                        trDatePe.Visible = true;
                        trDate.Visible = false;
                        if (!string.IsNullOrEmpty(strValue))
                            ucJalaliDatePiker.JalaliDate = new Farschidus.JalaliDateTime(Convert.ToDateTime(strValue.Split(' ')[0])).ToShortDateString();
                    }
                    else
                    {
                        trDatePe.Visible = false;
                        trDate.Visible = true;
                        if (!string.IsNullOrEmpty(strValue))
                            txtDate.Text = strValue.Split(' ')[0];
                    }
                    trTime.Visible = true;
                    if (!string.IsNullOrEmpty(strValue))
                        txtTime.Text = strValue.Split(' ')[1];
                    break;
                }
        }
        uplAddEdit.Update();
    }
    private void mClear()
    {
        ddlSubjectProperties.SelectedIndex = 0;
        trText.Visible = trInteger.Visible = trFloati.Visible = trTrueFalse.Visible = false;
        trDate.Visible = trDatePe.Visible = trTime.Visible = trMultiSelect.Visible = false;
        trSingleSelect.Visible = false;
        uplAddEdit.Update();
    }
    private void mLoadRecursivlyByParentID(ref List<int> propertyIDs, Guid subjectID)
    {
        Subjects subjects = new Subjects(subjectID)
        {
            Sort = Subjects.ColumnNames.Priority
        };

        if (subjects.RowCount > 0)
        {
            do
            {
                if (subjects.SubjectProperties.RowCount > 0)
                {
                    do {
                       propertyIDs.Add(subjects.SubjectProperties.pIDProperty);
                    }
                    while (subjects.SubjectProperties.MoveNext());
                }
                if (!subjects.IsColumnNull(Subjects.ColumnNames.IDParent))
                    mLoadRecursivlyByParentID(ref propertyIDs, subjects.pIDParent);
            }
            while (subjects.MoveNext());
        }
        else
        {
            propertyIDs.Add(subjects.SubjectProperties.pIDProperty);
        }
    }

    #endregion

    #region "Public Methodes"

    public string mGetPropertyName(object IDProperty)
    {
        Properties property = new Properties(Convert.ToInt32(IDProperty));
        return property.pName;
    }
    public string mGetCorrectValue(object IDProperty, string strValue)
    {
        string result = strValue;
        Properties property = new Properties((int)IDProperty);
        PropertyTypes.Enum type = (PropertyTypes.Enum)Enum.Parse(typeof(PropertyTypes.Enum), property.pIDType.ToString());

        switch (type)
        {
            case PropertyTypes.Enum.date:
                {
                    if (pLanguageID.Equals(2))
                        result = Global.MethodsAndProps.mToFarsiDigit(new Farschidus.JalaliDateTime(Convert.ToDateTime(strValue)).ToShortDateString());
                    break;
                }
            case PropertyTypes.Enum.dateTime:
                {
                    if (pLanguageID.Equals(2))
                        result = Global.MethodsAndProps.mToFarsiDigit(new Farschidus.JalaliDateTime(Convert.ToDateTime(strValue)).ToString());
                    break;
                }
            case PropertyTypes.Enum.singleSelect:
                {
                    PropertyItems items = new PropertyItems();
                    items.LoadByIDProperty((int)IDProperty);
                    items.Filter = string.Format("{0} IN ({1})", PropertyItems.ColumnNames.IDPropertyItem, strValue);
                    result = items.pTitle;
                    break;
                }
            case PropertyTypes.Enum.multiSelect:
                {
                    char seperator;
                    if (pLanguageID.Equals(2))
                        seperator = '،';
                    else
                        seperator = ',';

                    result = string.Empty;
                    PropertyItems items = new PropertyItems();
                    items.LoadByIDProperty((int)IDProperty);
                    if (items.RowCount > 0)
                    {
                        items.Filter = string.Format("{0} IN ({1})", PropertyItems.ColumnNames.IDPropertyItem, strValue);
                        do
                        {
                            result += items.pTitle + seperator + " ";
                        }
                        while (items.MoveNext());
                        result = result.Substring(0, result.LastIndexOf(seperator));
                    }
                    break;
                }
            case PropertyTypes.Enum.trueFalse:
                {
                    if (strValue == "True")
                        result = Global.Constants.HTML_IMAGE_CHECK;
                    else
                        result = Global.Constants.HTML_IMAGE_ERROR;
                    break;
                }
        }
        return result;
    }

    #endregion
}