using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class ControlP_Plugin_Popup : BasePage
{
    #region "Properties"

    private Guid pSubjectID;
    private int pSelectedPluginID
    {
        get
        {
            return Convert.ToInt32(ddlPlugins.SelectedValue);
        }
    }

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (!hdfRefresh.Value.Equals("1001"))
                hdfRefresh.Value = "1000";
            //hdfData.Value is ready now
            mInitialBindings();
            hdfRefresh.Value = "1001";
        }
        else
        {
            this.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SubjectPlugins subjectPlugin = new SubjectPlugins(pSubjectID, Convert.ToInt32(ddlAddedPlugins.SelectedValue));
        subjectPlugin.pOptions = txtAddedOptions.Text;
        subjectPlugin.pCSS = txtAddedCSS.Text;
        subjectPlugin.Save();

        pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
        mShowMessage(pMessage);
    }

    protected void ddlPlugins_SelectedIndexChanged(object sender, EventArgs e)
    {
        mFillPluginData(Convert.ToInt32(ddlPlugins.SelectedValue));
    }
    protected void ddlAddedPlugins_SelectedIndexChanged(object sender, EventArgs e)
    {
        mFillPagePluginData(Convert.ToInt32(ddlAddedPlugins.SelectedValue));
    }

    protected void btnAddToPage_Click(object sender, EventArgs e)
    {
        try
        {
            SubjectPlugins subjectPlugins = new SubjectPlugins(pSubjectID, pSelectedPluginID);

            if (subjectPlugins.RowCount > 0)
            {
                pMessage.Add(Farschidus.Translator.AppTranslate["plugin.popup.message.alreadyExist"] + ": " + subjectPlugins.Plugins.pName, Farschidus.Web.UI.Message.MessageTypes.Information);
            }
            else
            {
                subjectPlugins.AddNew();
                subjectPlugins.pIDSubject = pSubjectID;
                subjectPlugins.pIDPlugin = pSelectedPluginID;
                subjectPlugins.pOptions = txtOptions.Text;
                subjectPlugins.pCSS = txtCSS.Text;
                subjectPlugins.Save();

                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mLoadAll();
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
    protected void btnRemoveFromPage_Click(object sender, EventArgs e)
    {
        try
        {
            pMessage.Clear();
            SubjectPlugins subjectPlugins = new SubjectPlugins(pSubjectID, Convert.ToInt32(ddlAddedPlugins.SelectedValue));
            subjectPlugins.MarkAsDeleted(false);
            subjectPlugins.Save();

            pMessage.Add(Farschidus.Translator.AppTranslate["general.message.deleted"], Farschidus.Web.UI.Message.MessageTypes.Success);
            mShowMessage(pMessage);
            mLoadAll();
            mClearAndDisableButtons();
        }
        catch (Exception ex)
        {
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
        }
    }

    #endregion

    #region "Methodes"

    private void mInitialBindings()
    {
        if (!hdfData.Value.Equals(string.Empty))
        {
            string[] Data = hdfData.Value.Split('|');
            pSubjectID = new Guid(Data[0]);
            if (hdfRefresh.Value.Equals("1000"))
                mLoadAll();
        }
    }
    private void mLoadAll()
    {
        mLoadAllPagePlugins();
        mLoadAllPlugins();
        mClearAndDisableButtons();
    }
    private void mLoadAllPagePlugins()
    {
        ddlAddedPlugins.Items.Clear();

        SubjectPlugins subjectPlugins = new SubjectPlugins();
        subjectPlugins.LoadByIDSubject(pSubjectID);
        if (subjectPlugins.RowCount > 0)
        {
            List<BLL.Hardcodes.Item> listItems = new List<BLL.Hardcodes.Item>();
            do
            {
                listItems.Add(new BLL.Hardcodes.Item(subjectPlugins.pIDPlugin, subjectPlugins.Plugins.pName));
            }
            while (subjectPlugins.MoveNext());
            ddlAddedPlugins.DataSource = listItems;
            ddlAddedPlugins.DataTextField = BLL.Hardcodes.Item.FIELD_Title;
            ddlAddedPlugins.DataValueField = BLL.Hardcodes.Item.FIELD_ID;
            ddlAddedPlugins.DataBind();

            mFillPagePluginData((int)listItems[0].ID);
        }
        uplPageList.Update();
    }
    private void mLoadAllPlugins()
    {
        ddlPlugins.Items.Clear();

        Plugins Plugins = new Plugins();
        Plugins.LoadAll();

        ddlPlugins.DataSource = Plugins.DefaultView;
        ddlPlugins.DataTextField = Plugins.ColumnNames.Name;
        ddlPlugins.DataValueField = Plugins.ColumnNames.IDPlugin;
        ddlPlugins.DataBind();
        uplList.Update();

        if (Plugins.RowCount > 0)
            mFillPluginData(Plugins.pIDPlugin);
    }
    private void mFillPluginData(int pluginID)
    {
        Plugins plugin = new Plugins(pluginID);
        if (plugin.RowCount > 0)
        {
            lblVersion.Text = plugin.pVersion;
            lblDescription.Text = plugin.pDescription;
            txtOptions.Text = plugin.pSettings;
            txtCSS.Text = plugin.pCss;
        }
    }
    private void mFillPagePluginData(int pluginID)
    {
        SubjectPlugins subjectPlugin = new SubjectPlugins(pSubjectID, pluginID);

        lbladdedVersion.Text = subjectPlugin.Plugins.pVersion;
        lblAddedDescription.Text = subjectPlugin.Plugins.pDescription;
        txtAddedOptions.Text = subjectPlugin.pOptions;
        txtAddedCSS.Text = subjectPlugin.pCSS;

        uplList.Update();
    }
    private void mClearAndDisableButtons()
    {
        if (ddlAddedPlugins.Items.Count > 0)
        {
            btnSave.Enabled = true;
        }
        else
        {
            btnSave.Enabled = false;
            txtAddedCSS.Text = txtAddedOptions.Text = lbladdedVersion.Text = lblAddedDescription.Text = string.Empty;
            uplPageList.Update();
        }
    }

    #endregion
}