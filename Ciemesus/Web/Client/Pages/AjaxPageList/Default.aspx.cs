using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Pages_PageList_Default : BasePublic
{
    private Subjects pSubject
    {
        get
        {
            Subjects subject = new Subjects();
            if (ViewState["pSubject"] == null)
            {
                ViewState["pSubject"] = subject.Serialize();
            }
            subject.Deserialize(ViewState["pSubject"].ToString());
            return subject;
        }
        set
        {
            ViewState["pSubject"] = value.Serialize();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInisializing();
        }
        else if(this.Request.Params["__EVENTTARGET"].ToString().Equals(uplItemView.ClientID))
        {
            mItem_Comman(new Guid(this.Request.Params["__EVENTARGUMENT"].ToString()));            
        }
    }

    private void mInisializing()
    {
        if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
        {
            Subjects subjects = new Subjects();
            subjects.LoadBySubjectAliasAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), pCurrentLanguageID);
            if (subjects.RowCount > 0)
            {
                pSubject = subjects;
                mFillItemView();
            }
            else
            {
                litBody.Text = Farschidus.Translator.Translate("page.default.message.pageNotExist");
            }
        }
        mListBinding(pSubject.pIDSubject);
    }
    private void mItem_Comman(Guid subjectID)
    {
        Subjects subject = new Subjects(subjectID);
        pSubject = subject;
        mFillItemView();
    }
    private void mFillItemView()
    {        
        if (pSubject.pIsActive)
        {
            pTitle = pSubject.pTitle;
            litBody.Text = pSubject.pBody;
            pageBanner.Subject = pSubject;
            pageMedia.Subject = pSubject;
        }
        else
        {
            litBody.Text = Farschidus.Translator.AppTranslate["message.page.deactivate"];
        }
        
        uplItemView.Update();
    }
    private void mListBinding(Guid subjectID)
    {
        StringBuilder sb = new StringBuilder();
        mLoadRecursivly(sb, subjectID, string.Empty, string.Empty);
        string output = sb.ToString();
        litRelatedPages.Text = output.Substring(0, output.LastIndexOf("</ul>"));
    }
    private void mLoadRecursivly(StringBuilder sb, Guid subjectID, string title, string prefix)
    {
        Subjects subjects = new Subjects();
        subjects.LoadByIDParentAndIDLanguage(subjectID, pCurrentLanguageID);
        subjects.Sort = Subjects.ColumnNames.Priority;
        if (subjects.RowCount > 0)
        {
            do
            {
                sb.Append(string.Format(@"{0}<li><a href=""javascript:__doPostBack('{1}','{2}')"" ", prefix, uplItemView.ClientID, subjects.pIDSubject.ToString()));
                prefix = string.Format(@"onclick=""next(this)""><span>{0}</span><span class=""arrow""></span></a><ul>", subjects.pTitle);
                mLoadRecursivly(sb, subjects.pIDSubject, subjects.pTitle, prefix);
                prefix = string.Empty;
            }
            while (subjects.MoveNext());
            sb.Append("</ul></li>");
        }
        else
        {
            sb.Append(string.Format(@"><span>{0}</span></a></li>", title));
        }
    }
}