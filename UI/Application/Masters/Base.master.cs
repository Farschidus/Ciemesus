using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Masters_Base : BaseMasterPage
{
    public string formLang
    {
        get
        {
            BLL.BusinessEntity.Languages languages = new BLL.BusinessEntity.Languages();                
            languages.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);
            return languages.pCode.Split('_')[0];
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            form1.Action = Request.RawUrl;
        }
    }
    protected void CiemesusScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        if (e.Exception.Data["ExtraInfo"] != null)
        {
            CiemesusScriptManager.AsyncPostBackErrorMessage =
                e.Exception.Message +
                e.Exception.Data["ExtraInfo"].ToString();
        }
        else
        {
            CiemesusScriptManager.AsyncPostBackErrorMessage = e.Exception.Message + e.Exception.InnerException.Message + 
                "An unspecified error occurred.";
        }
    }
}
