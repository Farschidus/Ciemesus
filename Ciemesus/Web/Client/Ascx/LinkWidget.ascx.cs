using BLL.BusinessEntity;
using System;
using System.Text;
using System.Web.UI;

public partial class Client_Ascx_LinkWidget : UserControl
{
    private byte subjectType;
    private Global.Constants.Modules moduleName;
    public Global.Constants.Modules ModuleName
    {
        get
        {
            return moduleName;
        }
        set
        {
            moduleName = value;
            switch (moduleName)
            {
                case Global.Constants.Modules.Page:
                case Global.Constants.Modules.PageList:
                    subjectType = (byte)SubjectTypes.Enum.page;
                    break;
                case Global.Constants.Modules.List:
                case Global.Constants.Modules.ListItem:
                    subjectType = (byte)SubjectTypes.Enum.list;
                    break;
                case Global.Constants.Modules.Gallery:
                    subjectType = (byte)SubjectTypes.Enum.imageGallery;
                    break;
                default:
                    subjectType = (byte)SubjectTypes.Enum.page;
                    break;
            }
        }
    }

    private string listNameAlias;
    public string ListNameAlias
    {
        get
        {
            return listNameAlias;
        }
        set
        {
            listNameAlias = value;
        }
    }

    private bool generateTitle = true;
    public bool GenerateTitle
    {
        get
        {
            return generateTitle;
        }
        set
        {
            generateTitle = value;
        }
    }

    private byte language;
    private Guid subjectID;
    const string widget = @"<a href='{0}'>
        <div class='widgetImage' style='background: url({1}) no-repeat center center'></div>
        <div class='widgetDesc'>{2}</div>
    </a>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInitialBindings();
        }
    }

    private void mInitialBindings()
    {
        if(mFindSubject())
            mLoadSubject();
    }
    private bool mFindSubject()
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        Subjects subject = new Subjects();
        string[] aliasArray = listNameAlias.Split(',');
        foreach (string alias in aliasArray)
        {
            subject.LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(alias, subjectType, lang.pIDLanguage, true);
            if (subject.RowCount > 0)
            {
                language = subject.pIDLanguage;
                subjectID = subject.pIDSubject;
                listNameAlias = alias;
                if (generateTitle)
                    lblTitle.Text = subject.pTitle;
                return true;
            }
        }
        return false;
    }
    private void mLoadSubject()
    {
        StringBuilder sb = new StringBuilder();
        Subjects widgetSubject = new Subjects(subjectID);

        MediaSubjects medias = new MediaSubjects();
        medias.LoadByIDSubjectAndIDMediaSubjectType(widgetSubject.pIDSubject, (byte)MediaSubjectTypes.Enum.thumbnail);

        sb.Append(string.Format(widget, mGetURL(widgetSubject.pAlias), mGetImage(medias), widgetSubject.pBody));

        litWidget.Text = sb.ToString();
    }

    private string mGetURL(string alias)
    {
        Languages lang = new Languages(language);
        return string.Format("/{0}/{1}/{2}/{3}", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, moduleName.ToString(), alias);
    }
    private string mGetImage(MediaSubjects media)
    {
        if (media.RowCount > 0)
            return string.Format("{0}{1}{2}", Global.Constants.FOLDER_MEDIAS.Substring(1), media.Medias.pIDMedia.ToString(), media.Medias.pFileExtention);
        else
            return Global.Constants.IMAGE_NOAVAILABLE_SMALL;
    }
    private string mGetDate(DateTime dateTime)
    {
        Languages lang = new Languages();
        lang.LoadByLanguageCode(Global.MethodsAndProps.CurrentLanguageCode);

        return Global.MethodsAndProps.mToDate(dateTime, lang.pIDLanguage, "d MMMM yyyy");
    }
}