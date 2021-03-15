using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_VideoPlayer_Default : System.Web.UI.Page
{

    public string pVideoUrl
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_PLAYING_VIDEO_URL] != null)
            {
                return Request.QueryString[Global.Constants.QUERYSTRING_PLAYING_VIDEO_URL].ToString();
            }
            return string.Empty;
        }
    }
    public string pVideoTitle
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_PLAYING_VIDEO_TITLE] != null)
            {
                return Request.QueryString[Global.Constants.QUERYSTRING_PLAYING_VIDEO_TITLE].ToString();
            }
            return string.Empty;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "video/x-flv";
        Response.AddHeader("Content-Disposition", "inline; filename=" + pVideoTitle + ".flv");
        if (System.IO.File.Exists(pVideoUrl))
        {
            Response.TransmitFile(pVideoUrl);
        }
        Response.End();
    }
}
