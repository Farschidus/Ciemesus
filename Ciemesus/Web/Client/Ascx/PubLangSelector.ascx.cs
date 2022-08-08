using BLL.BusinessEntity;
using System;
using System.Text;

public partial class Client_Ascx_PubLangSelector : System.Web.UI.UserControl
{
    public enum Type
    {
        Dropdown,
        Literal
    }

    private Type renderType;
    public Type RenderType
    {
        set
        {
            renderType = value;
        }
    }

    private bool renderTitle;
    public bool RenderTitle
    {
        set
        {
            renderTitle = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInitializing();
        }
    }
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(string.Format(Global.Constants.PAGE_HOME_ASPX, ddlLanguages.SelectedValue), true);
    }

    private void mInitializing()
    {
        Languages languages = new Languages();
        languages.LoadActiveLanguages();
        languages.Sort = Languages.ColumnNames.Priority;

        switch (renderType)
        {
            case Type.Dropdown:
                mRenderDropDown(languages);
                break;
            case Type.Literal:
                mRenderLiteral(languages);
                break;
        }
    }
    private void mRenderLiteral(Languages languages)
    {
        litLanguages.Visible = true;
        string item = @"<li class='{2}'><a href='{0}'>{1}</a></li>";
        StringBuilder sb = new StringBuilder();

        sb.Append("<ul id='LanguagesList'>");
        if(renderTitle)
            sb.Append(string.Format("<li class='languageTitle'>{0}</li>", Farschidus.Translator.AppTranslate["general.label.language"]));
        do
        {
            if (languages.pCode.Equals(Global.MethodsAndProps.CurrentLanguageCode))
                sb.Append(string.Format(item,  string.Format("javascript:void({0})",languages.pIDLanguage), languages.pTitle.Substring(0, 2), string.Format("{0} {1}", "mr-1 selected", languages.pCode.Substring(0, 2))));
            else
                sb.Append(string.Format(item, string.Format(Global.Constants.PAGE_HOME_ASPX.Substring(1), languages.pCode), languages.pTitle.Substring(0, 2), string.Format("{0} {1}", "mr-1 selectable", languages.pCode.Substring(0, 2))));
        }
        while (languages.MoveNext());
        sb.Append("</ul>");

        litLanguages.Text = sb.ToString();
    }
    private void mRenderDropDown(Languages languages)
    {
        ddlLanguages.Visible = true;
        ddlLanguages.DataSource = languages.DefaultView;
        ddlLanguages.DataTextField = Languages.ColumnNames.Title;
        ddlLanguages.DataValueField = Languages.ColumnNames.Code;
        ddlLanguages.DataBind();
        ddlLanguages.SelectedValue = Global.MethodsAndProps.CurrentLanguageCode;
    }
}