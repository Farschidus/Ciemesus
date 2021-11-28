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
    private const string itemOdd = @"
                         <div id='{0}' class='itemContainerOdd itemContainer'>
                            <div class='itemImageTitle'>
                                <div class='itemImageOdd itemImage' style='background: {1}'></div>
                                <div class='itemTitleOdd itemTitle'>{2}</div>
                            </div>
                            <div>{3}</div>
                        </div>";
    private const string itemEven = @"
                         <div id='{0}' class='itemContainerEven itemContainer'>
                            <div class='itemImageTitle'>
                                <div class='itemImageEven itemImage' style='background: {1}'></div>
                                <div class='itemTitleEven itemTitle'>{2}</div>
                            </div>
                            <div>{3}</div>
                        </div>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            mInisializing();
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
                pTitle = subjects.pTitle;
                pageBanner.Subject = subjects;
                pagePlugin.SubjectID = subjects.pIDSubject;
                pageMedia.Subject = subjects;
                mListBinding(subjects.pIDSubject);
            }
            else
            {
                litBody.Text = Farschidus.Translator.AppTranslate["general.message.pageNotExist"];
            }
        }
    }
    private void mListBinding(Guid parentID)
    {
        Subjects subjects = new Subjects
        {
            Sort = Subjects.ColumnNames.Priority
        };
        subjects.LoadByIDParentAndIDLanguage(parentID, pCurrentLanguageID);

        string[] oddEvenItem = { itemOdd, itemEven };
        int i = 0;
        StringBuilder sb = new StringBuilder();
        do{
            sb.Append(string.Format(oddEvenItem[i], subjects.pAlias, mGetCoverImage(subjects.pIDSubject.ToString()), subjects.pTitle, subjects.pBody));
            if (i == 0)
                i = 1;
            else
                i = 0;
        }
        while (subjects.MoveNext());

        litBody.Text = sb.ToString();
        uplItemView.Update();
    }

    public string mGetCoverImage(string IDSubject)
    {
        string result = " url({0}{1}) no-repeat -130px 0";
        MediaSubjects cover = new MediaSubjects();
        cover.LoadByIDSubjectAndIDMediaSubjectType(new Guid(IDSubject), (byte)MediaSubjectTypes.Enum.thumbnail);
        if (cover.RowCount > 0)
            result = string.Format(result, Global.Constants.FOLDER_MEDIAS.Substring(1), cover.pIDMedia + cover.pFileExtention);
        else
            result = string.Format(result, Global.Constants.IMAGE_NOAVAILABLE_SMALL, "");
        return result;
    }
}