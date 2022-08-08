using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

/// <summary>
/// Summary description for BasePublic
/// </summary>
public class BasePublic : BasePage
{

    public string pTitle
    {
        set
        {
            Page.Title = Global.MethodsAndProps.WebsiteName + " - " + value;
        }
    }
    public byte pCurrentLanguageID
    {
        get
        {
            BLL.BusinessEntity.Languages lang = new BLL.BusinessEntity.Languages();
            lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);
            if (lang.RowCount > 0)
                return lang.pIDLanguage;
            else
                return 0;
        }
    }

    public virtual void mSearch()
    {
    }
}