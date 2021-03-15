using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Farschidus.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class PSM_Plugins_Default : BaseCP
{
    #region "Properties"

    public int? pIDPlugin
    {
        get
        {
            if (ViewState["pIDPlugin"] == null)
            {
                return null;
            }
            return (int)ViewState["pIDPlugin"];
        }
        set
        {
            ViewState["pIDPlugin"] = value;
        }
    }
    private string pTempJSFileID
    {
        get
        {
            return ViewState["pTempJSFileID"].ToString().Replace("-", "");
        }
        set
        {
            ViewState["pTempJSFileID"] = value;
        }
    }
    private string pJSFileName;

    #endregion

    #region "Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShownLanguageDDL = pShownSearchButton = false;
            Title = Farschidus.Translator.AppTranslate["pluginsManaging.default.page.title"];
            grvList.EmptyDataText = Farschidus.Translator.AppTranslate["general.message.gridsEmptyDataText"];           
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
        pTempJSFileID = Guid.NewGuid().ToString();
    }
    protected override void btnSubmit_Click(object sender, EventArgs e)
    {
        mSave();
    }
    protected override void btnDelete_Click(object sender, EventArgs e)
    {
        pMessage.Clear();
        bool hasSelect = false;
        int item;
        Plugins plugin = new Plugins();
        foreach (GridViewRow grvRow in grvList.Rows)
        {
            if (((CheckBox)grvRow.FindControl("chkList")).Checked)
            {
                item = Convert.ToInt32(grvList.DataKeys[grvRow.RowIndex][Plugins.ColumnNames.IDPlugin].ToString());
                plugin.LoadByPrimaryKey(item);
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
        string[] jsFile = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_TEMP), "*.js");
        if (jsFile.Length > 0)
            System.IO.File.Delete(jsFile[0]);
        mLoadList();
    }
    protected void grvList_RowDraged(object sender, GridViewRowDragedEventArgs e)
    {
        // Use "e" Arquments: e.Status, e.ComandName, e.ComandName, e.DragedRowIndex, e.TargetRowIndex;
    }
    protected void grvList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        mClear();
        pIDPlugin = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.NewEditIndex)][0]);
        e.Cancel = true;
        mFillForm();
    }
    protected void grvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int iDPlugin = Convert.ToInt32(grvList.DataKeys[Convert.ToInt32(e.RowIndex)][0]);
        mDelete(iDPlugin);
    }
    protected void Pager_PageIndexChanged(object sender, PagerPageIndexChangeEventArgs e)
    {
        mLoadList();
    }
    protected void Pager_PageSizeChanged(object sender, PagerPageSizeChangeEventArgs e)
    {
        mLoadList();
    }
    protected void fulFile_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        string strJSFile = string.Empty;
        string strTempFolder = string.Empty;

        if (fulFile.HasFile)
        {
            strTempFolder = System.IO.Path.Combine(Global.Constants.FOLDER_TEMP);
            if (!System.IO.Directory.Exists(MapPath(strTempFolder)))
            {
                System.IO.Directory.CreateDirectory(MapPath(strTempFolder));
            }
            strJSFile = string.Format("{0}{1}@{2}.js", strTempFolder, pTempJSFileID, System.IO.Path.GetFileNameWithoutExtension(fulFile.FileName));
            fulFile.SaveAs(MapPath(strJSFile));
        }
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
        Plugins plugins = new Plugins();
        plugins.LoadAll(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount, null);

        listPager.ItemCount = itemCount;

        grvList.DataSource = plugins.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mSearch()
    {
        int itemCount = 0;
        Plugins plugins = new Plugins();

        string name = "";
        if (!string.IsNullOrEmpty(txtNameSearch.Text))
        {
            name = txtNameSearch.Text.Trim();
        }
        string jSfileName = "";
        if (!string.IsNullOrEmpty(txtJSfileNameSearch.Text))
        {
            jSfileName = txtJSfileNameSearch.Text.Trim();
        }
        string version = "";
        if (!string.IsNullOrEmpty(txtVersionSearch.Text))
        {
            version = txtVersionSearch.Text.Trim();
        }
        string description = "";
        if (!string.IsNullOrEmpty(txtDescriptionSearch.Text))
        {
            description = txtDescriptionSearch.Text.Trim();
        }
        string settings = "";
        if (!string.IsNullOrEmpty(txtSettingsSearch.Text))
        {
            settings = txtSettingsSearch.Text.Trim();
        }
        string css = "";
        if (!string.IsNullOrEmpty(txtCssSearch.Text))
        {
            css = txtCssSearch.Text.Trim();
        }
        string jSinit = "";
        if (!string.IsNullOrEmpty(txtJSinitSearch.Text))
        {
            jSinit = txtJSinitSearch.Text.Trim();
        }

        plugins.Search(listPager.CurrentIndex - 1, listPager.PageSize, ref itemCount,
             null,
             name,
             jSfileName,
             version,
             description,
             settings,
             css,
             jSinit,
             null);
        listPager.ItemCount = itemCount;

        grvList.DataSource = plugins.DefaultView;
        grvList.DataBind();
        uplList.Update();
    }
    private void mFillForm()
    {
        Plugins plugins = new Plugins(pIDPlugin.Value);

        txtName.Text = plugins.pName;
        txtVersion.Text = plugins.pVersion;
        txtDescription.Text = plugins.pDescription;
        txtSettings.Text = plugins.pSettings;
        txtCss.Text = plugins.pCss;
        txtJSinit.Text = plugins.pJSinit;

        string[] jsFile = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_PLUGINS), plugins.pJSfileName);
        if (jsFile.Length > 0)
            litPopupJS.Text = string.Format(@"<a href='{0}?{1}' target='_blank'>{2}</a>",
                Global.Constants.FOLDER_PLUGINS.Substring(1) + System.IO.Path.GetFileName(jsFile[0]),
                DateTime.Now.ToString(),
                plugins.pJSfileName);

        uplAddEdit.Update();
    }
    private bool mValidateAddEdit()
    {
        pMessage.Clear();
        bool isValid = true;
        string strTempFolder = System.IO.Path.Combine(Global.Constants.FOLDER_TEMP);
        string strDestinationFolder = Global.Constants.FOLDER_PLUGINS;

        string[] fileEntries = System.IO.Directory.GetFiles(MapPath(strTempFolder), pTempJSFileID + "*.js");
        if (fileEntries.Length > 0)
        {
            pJSFileName = fileEntries[0].Split('@')[1];
            if (System.IO.Directory.Exists(MapPath(strDestinationFolder)))
            {
                string[] file = System.IO.Directory.GetFiles(MapPath(strDestinationFolder), pJSFileName);
                if (file.Length > 0 && !pIDPlugin.HasValue)
                {
                    isValid = false;
                    pMessage.Add(Farschidus.Translator.AppTranslate["pluginsManaging.default.message.fileExist"], Farschidus.Web.UI.Message.MessageTypes.Error);
                    System.IO.File.Delete(fileEntries[0]);
                }
            }
        }
        else if (!pIDPlugin.HasValue)
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["pluginsManaging.default.message.noFile"], Farschidus.Web.UI.Message.MessageTypes.Error);
        }
        return isValid;
    }
    private bool mValidateDelete(int iDPlugin)
    {
        pMessage.Clear();
        bool isValid = true;
        SubjectPlugins subjectPlugins = new SubjectPlugins();
        subjectPlugins.LoadByIDPlugin(iDPlugin);
        GalleryPlugins galleryPlugins = new GalleryPlugins();
        galleryPlugins.LoadByIDPlugin(iDPlugin);
        if (subjectPlugins.RowCount > 0)
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["pluginsManaging.default.message.subjectPluginsRelation"], Farschidus.Web.UI.Message.MessageTypes.Warning);
            do
            {
                pMessage.Add(subjectPlugins.Subjects.pTitle, Farschidus.Web.UI.Message.MessageTypes.Information);                
            }
            while (subjectPlugins.MoveNext());
        }
        if (galleryPlugins.RowCount > 0)
        {
            isValid = false;
            pMessage.Add(Farschidus.Translator.AppTranslate["pluginsManaging.default.message.galleryPluginsRelation"], Farschidus.Web.UI.Message.MessageTypes.Warning);
            do
            {
                pMessage.Add(galleryPlugins.Subjects.pTitle, Farschidus.Web.UI.Message.MessageTypes.Information);
            }
            while (galleryPlugins.MoveNext());
        }
        return isValid;
    }
    private void mSave()
    {
        if (mValidateAddEdit())
        {
            try
            {
                Plugins plugins = new Plugins();
                if (pIDPlugin.HasValue)
                {
                    plugins.LoadByPrimaryKey(pIDPlugin.Value);
                    if (string.IsNullOrEmpty(pJSFileName))
                        pJSFileName = plugins.pJSfileName;
                }
                else
                {
                    plugins.AddNew();
                }

                plugins.pName = txtName.Text;
                plugins.pJSfileName = pJSFileName;
                plugins.pVersion = txtVersion.Text;
                plugins.pDescription = txtDescription.Text;
                plugins.pSettings = txtSettings.Text;
                plugins.pCss = txtCss.Text;
                plugins.pJSinit = txtJSinit.Text;

                plugins.Save();
                mSaveFile(pJSFileName);

                pMessage.Clear();
                pMessage.Add(Farschidus.Translator.AppTranslate["general.message.success"], Farschidus.Web.UI.Message.MessageTypes.Success);
                mShowMessage(pMessage);
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
    private void mDelete(int iDPlugin, bool loadList = true)
    {
        try
        {
            if (mValidateDelete(iDPlugin))
            {
                Plugins plugins = new Plugins(iDPlugin);
                string[] jsFile = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_PLUGINS), plugins.pJSfileName);
                if (jsFile.Length > 0)
                    System.IO.File.Delete(jsFile[0]);
                plugins.MarkAsDeleted(false);

                plugins.Save();
            }           
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
            pMessage.Clear();
            pMessage.Add(ex.Message, Farschidus.Web.UI.Message.MessageTypes.Error);
            mShowMessage(pMessage);
        }
    }
    private void mClear()
    {
        pJSFileName = litPopupJS.Text = txtName.Text = txtVersion.Text = txtDescription.Text =
            txtSettings.Text = txtCss.Text = txtJSinit.Text = string.Empty;
        pIDPlugin = null;
        pTempJSFileID = Guid.NewGuid().ToString();
        uplAddEdit.Update();
    }

    private void mSaveFile(string fileName)
    {
        string strTempFolder = System.IO.Path.Combine(Global.Constants.FOLDER_TEMP);
        string strDestinationFolder = Global.Constants.FOLDER_PLUGINS;

        if (System.IO.Directory.Exists(MapPath(strTempFolder)))
        {
            string[] fileEntries = System.IO.Directory.GetFiles(MapPath(strTempFolder), pTempJSFileID + "*.js");
            if (fileEntries.Length > 0)
            {
                if (!System.IO.Directory.Exists(MapPath(strDestinationFolder)))
                    System.IO.Directory.CreateDirectory(MapPath(strDestinationFolder));

                System.IO.File.Copy(fileEntries[0], MapPath(strDestinationFolder + fileName), true);
                System.IO.File.Delete(fileEntries[0]);
                pTempJSFileID = Guid.NewGuid().ToString();
            }
        }
    }

    #endregion
}