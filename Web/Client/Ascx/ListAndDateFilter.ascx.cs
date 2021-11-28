using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;

public partial class Client_Ascx_ListAndDateFilter : System.Web.UI.UserControl
{
    private byte language;
    public byte Language
    {
        get
        {
            return language;
        }
        set
        {
            language = value;
        }
    }

    private string updatePanelID;
    public string UpdatePanelID
    {
        set
        {
            updatePanelID = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(updatePanelID))
            {
                mBindCategoriesWithPostback();
                mBindDatesWithPostback();
            }
            else
            {
                mBindCategories();
                mBindDates();
            }
        }
    }

    private void mBindDates()
    {
        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime finishDate = new DateTime(2020, 1, 1);
        const int YearGap = 10;
        StringBuilder sb = new StringBuilder();
        do
        {
            sb.Append(string.Format(@"<a href=""javascript:__doPostBack('{0}','Date#{1}')"">{1} - {2}</a>", updatePanelID, startDate.Year.ToString(), startDate.AddYears(YearGap).Year.ToString()));
            sb.Append(" | ");
            startDate = startDate.AddYears(YearGap);
        }
        while (startDate <= finishDate);
        litDates.Text = sb.ToString().Remove(sb.ToString().LastIndexOf(" | "));
    }
    private void mBindCategories()
    {
        Subjects subject = new Subjects
        {
            Sort = Subjects.ColumnNames.Priority
        };

        subject.LoadAllListByIDLanguage(language);
        StringBuilder sb = new StringBuilder();
        if (subject.RowCount > 0)
        {    
            do
            {
                sb.Append(string.Format(@"<a href=""javascript:__doPostBack('{0}','Category#{1}')"">{2}</a>", updatePanelID, subject.pIDSubject, subject.pTitle));
                sb.Append(" | ");
            }
            while (subject.MoveNext());
        }
        litCategories.Text = sb.ToString().Remove(sb.ToString().LastIndexOf(" | "));
    }

    private void mBindDatesWithPostback()
    {
        DateTime startDate = new DateTime(1980, 1, 1);
        DateTime finishDate = new DateTime(2020, 1, 1);
        const int YearGap = 10;
        StringBuilder sb = new StringBuilder();
        do
        {
            //sb.Append(string.Format(@"<a href=""javascript:__doPostBack('{0}','Date#{1}')"">{1} - {2}</a>", updatePanelID, startDate.Year.ToString(), startDate.AddYears(YearGap).Year.ToString()));
            sb.Append(" | ");
            startDate = startDate.AddYears(YearGap);
        }
        while (startDate <= finishDate);
        litDates.Text = sb.ToString().Remove(sb.ToString().LastIndexOf(" | "));
    }
    private void mBindCategoriesWithPostback()
    {
        Languages lang = new Languages(language);
        Subjects subject = new Subjects
        {
            Sort = Subjects.ColumnNames.Priority
        };

        subject.LoadAllListByIDLanguage(language);

        if (subject.RowCount > 0)
        {
            
            StringBuilder sb = new StringBuilder();
            do
            {
                sb.Append(string.Format(@"<a href='/{0}/{1}/{2}/Advertise'>{3}</a>", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, Global.Constants.STRING_PAGELIST_MODULE, subject.pIDSubject, subject.pTitle));
                sb.Append(" | ");
            }
            while (subject.MoveNext());
            litCategories.Text = sb.ToString().Remove(sb.ToString().LastIndexOf(" | "));
        }
    }
}