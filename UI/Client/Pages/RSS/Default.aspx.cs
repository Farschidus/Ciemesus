using System;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;
using System.Net;
using System.Xml;
using System.Text;
using System.IO;

public partial class Pages_RSS_Default : BasePublic
{
    private enum NewsType
    {
        Health_Care = 0,
        Technology_and_Commerce,
        Iran_Economic
    }
    private NewsType pNewsType
    {
        get
        {
            if (ViewState["pNewsType"] == null)
            {
                NewsType output = NewsType.Health_Care;
                if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
                {
                    Enum.TryParse(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), out output);
                }
                ViewState["pNewsType"] = output;
            }
            return (NewsType)ViewState["pNewsType"];
        }
    }
    private string[] feeds
    {
        get
        {
            switch (pNewsType)
            {
                case NewsType.Health_Care:
                    {
                        return new string[] {
                            "http://www.fiercebiotechit.com/feed",
                            "http://www.fiercepharma.com/feed",
                            "http://www.fiercemedicaldevices.com/feed",
                            "http://www.fiercebiotechresearch.com/feed",
                            "http://www.fiercepharmamanufacturing.com/feed",
                            "http://www.fiercebiotechit.com/feed",
                            "http://www.fiercepharmamarketing.com/feed",
                            "http://www.fiercedrugdelivery.com/feed",
                            "http://www.fiercecro.com/feed",
                            "http://www.fiercevaccines.com/feed",
                            "http://www.fiercepharmaasia.com/feed",
                            "http://www.fierceanimalhealth.com/feed"
                        };
                    }
                case NewsType.Technology_and_Commerce:
                    {
                        return new string[] {
                            "http://www.iea.org/newsroomandevents/news.xml",
                            "https://www.iaea.org/feeds/topnews",
                            "https://rss.sciencedaily.com/earth_climate/renewable_energy.xml",
                            "https://www.wto.org/library/rss/latest_news_e.xml",
                            "https://www.ota.com/rss.xml",
                            "http://www.mining.com/feed/",
                            "http://www.siemens.com/news-topics/apps/topicsfeed/category_default_en.xml"
                        };
                    }
                case NewsType.Iran_Economic:
                    {
                        return new string[] {
                            "http://financialtribune.com/rss.xml",
                            "http://www.suna.org.ir/en/news/rss/22/,/1",
                            "http://www.investiniran.ir/en/news/rss/20,23,35/1025,1026,1063/1,2,15,17,18,19",
                            "http://www.cbi.ir/NewsRss.aspx?ln=en",
                            "http://en.mimt.gov.ir/rssfeeds/func/main2/rssData/W3sicGFyYW1zIjp7ImNvbnRlbnRfdHlwZSI6IjE5Iiwid2RfaWQiOiIzMDcxMiIsImV4dHJhX3doZXJlIjoiRFN6TkhcL0I1MjhjcnI4UXE5MUlwcFFVMXdHcXRxVWppb2lJdDc1ZnZhM21aUUVRWTA0NmZFbWpwak40Wk9qb3lNREF3TmpJeE9UY3kiLCJkaXNwbGF5X2Jhc2VkIjoiMSIsImRpc3BsYXlfZGF5cyI6IiIsIml0ZW1zX2NvdW50IjoiIn19XQ%3D%3D/rssModule/cdk/"
                        };
                    }
                default:
                    {
                        return new string[] {
                            "http://www.fiercebiotechit.com/feed",
                            "http://www.fiercepharma.com/feed",
                            "http://www.fiercemedicaldevices.com/feed",
                            "http://www.fiercebiotechresearch.com/feed",
                            "http://www.fiercepharmamanufacturing.com/feed",
                            "http://www.fiercebiotechit.com/feed",
                            "http://www.fiercepharmamarketing.com/feed",
                            "http://www.fiercedrugdelivery.com/feed",
                            "http://www.fiercecro.com/feed",
                            "http://www.fiercevaccines.com/feed",
                            "http://www.fiercepharmaasia.com/feed",
                            "http://www.fierceanimalhealth.com/feed"
                        };
                    }
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            litPageTitle.Text = pTitle = pNewsType.ToString().Replace("_", " ") + " News";
            imgPageBanner.ImageUrl = "/Client/Images/Public/" + pNewsType.ToString() + ".jpg";
            mFillBody();
        }
    }

    private void mFillBody()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string feed in feeds)
        {
            sb.Append(mGetRSS(feed));
        }
        litBody.Text = sb.ToString();
    }
    private string mGetRSS(string url)
    {
        StringBuilder sb = new StringBuilder();

        WebRequest rssReq = WebRequest.Create(url);
        rssReq.Timeout = 3000;

        try
        {
            WebResponse rep = rssReq.GetResponse();
      
            XmlDocument xmlDoc = new XmlDocument();
            using (Stream responseStream = rep.GetResponseStream())
            {
                xmlDoc.Load(responseStream);
            }
            XmlNode rootNode = xmlDoc.SelectSingleNode("rss");
            XmlNodeList itemNodes = rootNode.SelectNodes("channel/item");
            DateTime dateTime;
            int counter = 0;
            foreach (XmlNode item in itemNodes)
            {
                if (counter > 5)
                    break;
                dateTime = DateTime.Parse(item["pubDate"].InnerText.Substring(0, 16));
                sb.Append("<a target='_blank' href=" + item["link"].InnerText + ">");
                sb.Append("<div class='rptNewsItem'>");
                    sb.Append("<div class='date'>");
                        sb.Append("<div class='date-month'>" + dateTime.ToString("MMM") + "</div>");
                        sb.Append("<div class='date-day'>" + dateTime.ToString("dd") + "</div>");
                        sb.Append("<div class='date-year'>" + dateTime.ToString("yyyy") + "</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='rptTitle'>");
                        sb.Append(item["title"].InnerText);
                    sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</a>");
                counter++;
            }
        }
        catch // (Exception ex)
        {
            sb.Append(""); //ex.Message);
        }
        return sb.ToString();
    }
}