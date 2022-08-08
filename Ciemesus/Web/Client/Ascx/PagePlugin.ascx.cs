using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_PagePlugin : System.Web.UI.UserControl
{
    public Guid SubjectID
    {
        set
        {
            mInitializing(value);
        }
    }

    private void mInitializing(Guid SubjectID)
    {
        SubjectPlugins subjectPlugins = new SubjectPlugins();
        subjectPlugins.LoadByIDSubject(SubjectID);
        if (subjectPlugins.RowCount > 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<style type='text/css' rel='stylesheet'>");
            do
            {
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), subjectPlugins.Plugins.pJSfileName, string.Format("{0}{1}", Global.Constants.FOLDER_PLUGINS.Substring(1), subjectPlugins.Plugins.pJSfileName));
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), subjectPlugins.Plugins.pName, subjectPlugins.Plugins.pJSinit.Replace("#options#", subjectPlugins.pOptions), true);
                sb.Append(subjectPlugins.pCSS);
            }
            while (subjectPlugins.MoveNext());
            sb.Append("</style>");
            litCSS.Text = sb.ToString();

            uplPlugins.Update();
        }
    }
    private void mSetGalleryScript(SubjectPlugins subjectPlugins)
    {
        //Javascript

        //Cascade Style Sheet
        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), galleryPlugin.Plugins.pName + "CSS", sb.ToString(), false);
        
    }
}