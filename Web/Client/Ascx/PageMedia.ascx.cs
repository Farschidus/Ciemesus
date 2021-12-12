using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_PageMedia : System.Web.UI.UserControl
{
    public Subjects Subject
    {
        get
        {
            Subjects content = new Subjects();
            if (ViewState["PageMediaSubject"] == null)
            {
                return null;
            }
            else
            {
                content.Deserialize(ViewState["PageMediaSubject"].ToString());
            }
            return content;
        }
        set
        {
            ViewState["PageMediaSubject"] = value.Serialize();
            mInitializing();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string mGetUrl(string mediaID, string extention)
    {
        return string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), mediaID, extention);
    }
    private void mInitializing()
    {
        MediaSubjects medias = new MediaSubjects();
        medias.LoadByIDSubjectAndIDMediaSubjectType(Subject.pIDSubject, (byte)MediaSubjectTypes.Enum.attachment);
        if (medias.RowCount > 0)
        {
            rptMedia.Visible = true;
            medias.Sort = MediaSubjects.ColumnNames.Priority;
            rptMedia.DataSource = medias.DefaultView;
            rptMedia.DataBind();
        }
        else
        {
            rptMedia.Visible = false;
        }
        uplMedia.Update();
    }
}