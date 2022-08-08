using System;
using System.IO;
using BLL.BusinessEntity;

public partial class ControlP_Desktop_Default : BaseCP
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pShownLanguageDDL = pShownSearchButton = pShownCreateButton = pShownLoadAllButton = pShownDeleteButton = false;
            Title = Farschidus.Translator.AppTranslate["desktop.default.page.title"];
            //mInitialBindings();
        }
    }
    protected void btnRegenerateIcon_Click(object sender, EventArgs e)
    {
        string strMediaFolder = Global.Constants.FOLDER_MEDIAS;

        string[] files = Directory.GetFiles(MapPath(strMediaFolder), "*.*");
        if (files.Length > 0)
        {
            foreach (string file in files)
                Global.MethodsAndProps.mGenerateThumbnail(file);
        }
    }
    private void mInitialBindings()
    {
        Members members = new Members();
        members.LoadAll();
        litMembers.Text = Farschidus.Translator.AppTranslate["desktop.default.members.count"] + " " + members.RowCount.ToString();
    }

}