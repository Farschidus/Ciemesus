using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_Gallery_Default : BasePublic
{
    private Guid? pIDSubject
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
            {
                Subjects subjects = new Subjects();
                subjects.LoadBySubjectAliasAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), pCurrentLanguageID);
                if (subjects.RowCount > 0)
                {
                    pSubject = subjects;
                    return subjects.pIDSubject;
                }
            }
            return null;
        }
    }
    private Subjects pSubject;

    const string flashObject = @"<div id='Player' style='text-align: center'>
            <embed id='mpl' width='470' height='320' 
                flashvars='&file={2}?pvu={0}&pvt={1}&frontcolor=000000&lightcolor=003300&screencolor=000' 
                allowfullscreen='true' allowscriptaccess='always' quality='high' name='mpl' style='undefined' 
                src='{3}' type='application/x-shockwave-flash'>
            </embed>
        </div>";
    const string otherFiles = @"<li class='thumbItem'><a style='border:none;' data-lightbox='ImageGroups' rel='lightbox' href='{0}' >{1}</a></li>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (pIDSubject.HasValue)
            {
                if (pSubject.pIsActive)
                {
                    litPageTitle.Text = pTitle = pSubject.pTitle;
                    litBody.Text = pSubject.pBody;
                    pageBanner.Subject = pSubject;
                    pagePlugin.SubjectID = pSubject.pIDSubject;
                    mLoadMedias();
                }
                else
                    litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
            }
            else
            {
                litBody.Text = Farschidus.Translator.AppTranslate["general.message.dates.creationDate"];
            }
        }
    }
    private void mLoadMedias()
    {
        StringBuilder sb = new StringBuilder();
        MediaSubjects medias = new MediaSubjects();
        medias.LoadByIDSubjectAndIDMediaSubjectType(pSubject.pIDSubject, (byte)MediaSubjectTypes.Enum.gallery);
        if (medias.RowCount > 0)
        {
            medias.Sort = MediaSubjects.ColumnNames.Priority;
            sb.Append("<ul class='thumbItems'>");
            do
            {
                string fileUrl, Thumbnail = string.Empty;
                if (medias.pFileExtention.Contains("flv"))
                {
                    fileUrl = System.IO.Directory.GetFiles(MapPath(Global.Constants.FOLDER_MEDIAS), medias.pIDMedia.ToString() + medias.pFileExtention)[0];
                    sb.Append(string.Format(flashObject, fileUrl, medias.pFileName, Global.Constants.FOLDER_VIDEOPLAYER.Substring(1), Global.Constants.FILE_PLAYER_SWF.Substring(1)));
                }
                else
                {
                    fileUrl = string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), medias.pIDMedia.ToString(), medias.pFileExtention);
                    Thumbnail = string.Format("<img src='{0}{1}{2}' width='150px' height='150px' />", Global.Constants.FOLDER_THUMBS.Substring(1), medias.pIDMedia.ToString(), medias.pFileExtention);
                    sb.Append(string.Format(otherFiles, fileUrl, Thumbnail));
                }
            }
            while (medias.MoveNext());
            sb.Append("</ul>");
        }
        else
        {
            sb.Append("");
        }
        litImages.Text = sb.ToString();
    }
}