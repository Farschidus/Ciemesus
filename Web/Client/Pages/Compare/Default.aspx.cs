using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using BLL.BusinessEntity;

public partial class Pages_Compare_Default : BasePublic
{
    private List<string> pSubjects
    {
        get
        {
            if (ViewState["pSubjects"] == null)
            {
                List<string> subjectList = new List<string>();
                ViewState["pSubjects"] = subjectList;
            }
            return (List<string>)ViewState["pSubjects"];
        }
        set
        {
            ViewState["pSubjects"] = value;
        }
    }
    private bool pHasSubjects
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
            {
                string[] aliases = Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString().Split('/').Distinct().ToArray<string>();
                Subjects subject = new Subjects();
                foreach (string alias in aliases)
                {
                    subject.LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(alias, (byte)SubjectTypes.Enum.listItem, pCurrentLanguageID, true);
                    if (subject.RowCount > 0)
                    {
                        pSubjects.Add(subject.Serialize());
                    }
                }
                if (pSubjects.Count > 0)
                {
                    subject.Deserialize(pSubjects[0]);
                    //mGetHighestGroupID(subject.pIDSubject);                //Obsolete just for this Project
                    //hdfGroupID.Value = pHighestGroupID.ToString();         //Obsolete just for this Project
                    hdfGroupID.Value = subject.pIDParent.ToString();
                    hdfLang.Value = pCurrentLanguageID.ToString();
                }
            }
            return pSubjects.Count > 0;
        }
    }
    private Guid pHighestGroupID;

    private const string columnsStartFirstDiv = "<div class='columnsStartFirstDiv'>";
    private const string columnsStartDiv = "<div class='columnsStartDiv'>";
    private const string columnsEndDiv = "</div>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (pHasSubjects)
            {
                StringBuilder sb = new StringBuilder();
                Subjects subject = new Subjects();
                subject.Deserialize(pSubjects[0]);
                mLoadKeys(ref sb, subject.pIDSubject);
                foreach (string serializedSubject in pSubjects)
                {
                    subject.Deserialize(serializedSubject);
                    mLoadValues(ref sb, subject);
                }

                pTitle = Farschidus.Translator.AppTranslate["comparePage.page.default.title"];
                litBody.Text = sb.ToString();
                pageBanner.Subject = subject;
                //pageMedia.Subject = subject;
                pagePlugin.SubjectID = subject.pIDSubject;
            }
            else
                litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
        }
    }

    private void mLoadKeys(ref StringBuilder sb, Guid subjectID)
    {
        sb.Append(columnsStartFirstDiv);

        List<string> propertyDic = new List<string>();
        List<int> propertyIDs = new List<int>();
        mLoadRecursivlyByParentID(ref propertyIDs, subjectID);

        Properties properties = new Properties();
        properties.LoadAll();
        properties.Filter = string.Format("{0} IN ({1})", Properties.ColumnNames.IDProperty, string.Join(",", propertyIDs.ToArray()));

        if (properties.RowCount > 0)
        {
            do
            {
                propertyDic.Add(properties.pName);
            }
            while (properties.MoveNext());

            foreach (string prop in propertyDic)
            {
                sb.AppendFormat("<div style='background-color: #666666; border-bottom: 1px solid #fff; padding: 5px;'>{0}<br/></div>", prop);
            }
        }

        sb.Append(columnsEndDiv);
    }
    private void mLoadValues(ref StringBuilder sb, Subjects subject)
    {
        sb.Append(columnsStartDiv);
        sb.Append(string.Format("<img width='100px' height='100px' src='{0}' style='margin: 30px 0 0 30px;'></img>", mGetCoverImage(subject.pIDSubject.ToString())));

        string resultValue = Farschidus.Translator.AppTranslate["general.label.na"];
        List<string> valueList = new List<string>();
        List<int> propertyIDs = new List<int>();
        mLoadRecursivlyByParentID(ref propertyIDs, subject.pIDSubject);

        Properties properties = new Properties();
        properties.LoadAll();
        properties.Filter = string.Format("{0} IN ({1})", Properties.ColumnNames.IDProperty, string.Join(",", propertyIDs.ToArray()));

        if (properties.RowCount > 0)
        {
            do
            {
                SubjectPropertyValues subjectPropertyValue = new SubjectPropertyValues(subject.pIDSubject, properties.pIDProperty);
                if (subjectPropertyValue.RowCount > 0)
                {
                    if (properties.pIDType.Equals((byte)PropertyTypes.Enum.date) && pCurrentLanguageID == 2)
                        resultValue = Global.MethodsAndProps.mToFarsiDigit(new Farschidus.JalaliDateTime(Convert.ToDateTime(subjectPropertyValue.pValue)).ToShortDateString());
                    else if (properties.pIDType.Equals((byte)PropertyTypes.Enum.dateTime) && pCurrentLanguageID == 2)
                        resultValue = Global.MethodsAndProps.mToFarsiDigit(new Farschidus.JalaliDateTime(Convert.ToDateTime(subjectPropertyValue.pValue.Split(' ')[0])).ToShortDateString());
                    if (properties.pIDType.Equals((byte)PropertyTypes.Enum.singleSelect))
                    {
                        PropertyItems items = new PropertyItems();
                        items.LoadByIDProperty((int)properties.pIDProperty);
                        items.Filter = string.Format("{0} IN ({1})", PropertyItems.ColumnNames.IDPropertyItem, subjectPropertyValue.pValue);
                        resultValue = items.pTitle;
                    }
                    else
                        resultValue = subjectPropertyValue.pValue;
                }
                else
                {
                    resultValue = Farschidus.Translator.AppTranslate["general.label.na"];
                }
                valueList.Add(resultValue);
            }
            while (properties.MoveNext());

            foreach (string val in valueList)
            {
                //sb.Append(string.Format("{0}<br/>", val));
                sb.AppendFormat("<div style='background-color: #f0f0f0; color: #3c3c3c; border-bottom: 1px solid #fff; padding: 5px;'>{0}<br/></div>", val);
            }
        }
        sb.Append(columnsEndDiv);
    }
    private void mLoadRecursivlyByParentID(ref List<int> propertyIDs, Guid subjectID)
    {
        Subjects subjects = new Subjects(subjectID);
        subjects.Sort = Subjects.ColumnNames.Priority;
        if (subjects.RowCount > 0)
        {
            do
            {
                if (subjects.SubjectProperties.RowCount > 0)
                {
                    do
                    {
                        propertyIDs.Add(subjects.SubjectProperties.pIDProperty);
                    }
                    while (subjects.SubjectProperties.MoveNext());
                }
                if (!subjects.IsColumnNull(Subjects.ColumnNames.IDParent))
                    mLoadRecursivlyByParentID(ref propertyIDs, subjects.pIDParent);
            }
            while (subjects.MoveNext());
        }
        else
        {
            propertyIDs.Add(subjects.SubjectProperties.pIDProperty);
        }
    }
    private void mGetHighestGroupID(Guid subjectID)
    {
        Subjects subjects = new Subjects(subjectID);
        subjects.Sort = Subjects.ColumnNames.Priority;
        if (subjects.RowCount > 0)
        {
            do
            {
                if (!subjects.IsColumnNull(Subjects.ColumnNames.IDParent))
                    mGetHighestGroupID(subjects.pIDParent);
                else
                    pHighestGroupID = subjects.pIDSubject;
            }
            while (subjects.MoveNext());
        }
    }
    private string mGetCoverImage(string IDSubject)
    {
        string result = "{0}{1}";
        MediaSubjects cover = new MediaSubjects();
        cover.LoadByIDSubjectAndIDMediaSubjectType(new Guid(IDSubject), (byte)MediaSubjectTypes.Enum.thumbnail);
        if (cover.RowCount > 0)
            result = string.Format(result, Global.Constants.FOLDER_MEDIAS.Substring(1), cover.pIDMedia + cover.pFileExtention);
        else
            result = string.Format(result, Global.Constants.IMAGE_NOAVAILABLE_SMALL, string.Empty);
        return result;
    }

    [WebMethod]
    public static string GetGroupItems(string prefixText, string subjectID, string langID)
    {
        StringBuilder sb = new StringBuilder();
        if (!string.IsNullOrEmpty(subjectID))
        {
            List<BLL.Hardcodes.Item> items = new List<BLL.Hardcodes.Item>();
            mLoadAllListItemsRecursivlyBySubjectID(ref items, new Guid(subjectID), byte.Parse(langID));

            Pages_Compare_Default temp = new Pages_Compare_Default();
            List<BLL.Hardcodes.Item> result = (from m in items where m.Title.IndexOf(prefixText, 0, StringComparison.CurrentCultureIgnoreCase) > 1 select m).ToList<BLL.Hardcodes.Item>();
            foreach (BLL.Hardcodes.Item item in result)
            {
                Subjects subject = new Subjects();
                subject.LoadBySubjectAliasAndIDLanguage(item.ID.ToString(), byte.Parse(langID));
                //MediaSubjects mediaSubject = new MediaSubjects();
                //mediaSubject.LoadByIDSubject(subject.pIDSubject);
                //if (mediaSubject.RowCount > 0)
                //{
                    sb.AppendFormat("<li><a href='{1}/'><img class='autoCompleteImage' src='{0}'/>{2}</a></li>", temp.mGetCoverImage(subject.pIDSubject.ToString()), item.ID, item.Title);
                //}
                //else
                //{
                    //sb.AppendFormat("<li><a href='{0}/'>{0}</a></li>", item.ID, item.Title);
                //}
                
            }
        }
        return sb.ToString();
    }
    private static void mLoadAllListItemsRecursivlyBySubjectID(ref List<BLL.Hardcodes.Item> listItems, Guid subjectID, byte langID)
    {
        Subjects subject = new Subjects(subjectID);
        subject.Sort = Subjects.ColumnNames.Priority;

        Subjects subjects = new Subjects();
        
        if (subject.RowCount > 0)
        {
            subjects.LoadByIDParentAndIDSubjectTypeAndIDLanguage(subjectID, (byte)SubjectTypes.Enum.listItem, langID, true);
            subjects.Sort = Subjects.ColumnNames.Priority;
            if (subjects.RowCount > 0)
            {
                do
                {
                    listItems.Add(new BLL.Hardcodes.Item(subjects.pAlias.ToUpper(), subjects.pTitle));
                }
                while (subjects.MoveNext());
            }

            subject.LoadByIDParent(subjectID);
            subject.Sort = Subjects.ColumnNames.Priority;
            if (subject.RowCount > 0)
                do
                {
                    mLoadAllListItemsRecursivlyBySubjectID(ref listItems, subject.pIDSubject, langID);
                }
                while (subject.MoveNext());
        }
    }
}