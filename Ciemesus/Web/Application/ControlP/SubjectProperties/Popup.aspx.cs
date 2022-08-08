using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class ControlP_SubjectProperties_Popup : BasePage
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
            grvGroupPropeties.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];
        }
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        mLoadAllProperties();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        mLoadAllProperties();
    }
    protected void btnAddToPage_Click(object sender, EventArgs e)
    {
        try
        {
            SubjectProperties subjectProperties = new SubjectProperties(pSubjectID, Convert.ToInt32(ddlProperties.SelectedValue));
            if (subjectProperties.RowCount.Equals(0))
            {
                subjectProperties.AddNew();
                subjectProperties.pIDSubject = pSubjectID;
                subjectProperties.pIDProperty = Convert.ToInt32(ddlProperties.SelectedValue);
                subjectProperties.pIsSearchable = chbIsSearchable.Checked;
                subjectProperties.Save();
                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mLoadAllGroupProperties();
            }
            else
            {
                pMessage.Add(Farschidus.Translator.AppTranslate["property.popup.message.alreadyExist"], Farschidus.Web.UI.Message.MessageTypes.Information);
            }
        }
        catch (Exception ex)
        {
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
        }
        finally
        {
            mShowMessage(pMessage);
        }
    }
    protected void btnRemoveFromPage_Click(object sender, EventArgs e)
    {
        try
        {
            pMessage.Clear();
            bool hasSelect = false;
            int item;
            SubjectProperties subjectProperties = new SubjectProperties();
            foreach (GridViewRow grvRow in grvGroupPropeties.Rows)
            {
                if (((CheckBox)grvRow.FindControl("chkPageList")).Checked)
                {
                    item = Convert.ToInt32(grvGroupPropeties.DataKeys[grvRow.RowIndex][SubjectProperties.ColumnNames.IDProperty].ToString());
                    subjectProperties.LoadByPrimaryKey(pSubjectID, item);
                    if (subjectProperties.RowCount > 0)
                    {
                        subjectProperties.MarkAsDeleted(false);
                        subjectProperties.Save();
                        hasSelect = true;
                    }
                }
            }
            if (hasSelect)
            {
                //reorderMediaSubjects(subjectProperties);
                mLoadAllGroupProperties();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.deleted"], Farschidus.Web.UI.Message.MessageTypes.Success);
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
            //pMediaSubjectTypeID = Convert.ToByte(Data[2]);
            if (hdfRefresh.Value.Equals("1000"))
                mLoadAll();
        }
    }
    private void mLoadAll()
    {
        mLoadAllProperties();
        mLoadAllGroupProperties();
    }
    private void mLoadAllProperties()
    {
        Properties properties = new Properties();
        properties.LoadByIDLanguage(pLanguageID);

        ddlProperties.DataSource = properties.DefaultView;
        ddlProperties.DataTextField = Properties.ColumnNames.Name;
        ddlProperties.DataValueField = Properties.ColumnNames.IDProperty;
        ddlProperties.DataBind();
    }
    private void mLoadAllGroupProperties()
    {        
        Properties properties = new Properties();
        properties.LoadByIDSubjectAndIDLanguage(pSubjectID, pLanguageID);
        grvGroupPropeties.DataSource = properties.DefaultView;
        grvGroupPropeties.DataBind();
        uplPageList.Update();
    }

    #endregion

    #region "Public Methodes"

    public string mIsSearchable(object IDProperty)
    {
        string result = string.Empty;
        SubjectProperties subjectProperties = new SubjectProperties(pSubjectID, (int)IDProperty);
        if (subjectProperties.RowCount > 0)
        {
            if (subjectProperties.pIsSearchable)
                result = Global.Constants.HTML_IMAGE_CHECK;
            else
                result = Global.Constants.HTML_IMAGE_ERROR;
        }
        else
        {
            result = "N/A";
        }
        return result;
    }

    #endregion
}