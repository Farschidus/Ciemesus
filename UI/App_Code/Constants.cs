using System;

namespace Global
{
    public class Constants
    {
        // PAGEs
        public const string PAGE_LOGIN_ASPX = "~/{0}/Pages/Login/";
        public const string PAGE_HOME_ASPX = "~/{0}/Pages/Home/";
        public const string PAGE_SEARCH_ASPX = "~/{0}/Pages/Search/";
        public const string PAGE_REGISTER_ASPX = "~/{0}/Pages/Registration/";
        public const string PAGE_LISTITEM_ASPX = "~/{0}/Pages/ListItem/{1}";
        public const string PAGE_GALLERY_ASPX = "~/{0}/Pages/Gallery/{1}";
        public const string PAGE_USERPAGE_ASPX = "~/{0}/Pages/UserPage/{1}";
        public const string PAGE_COMPARE_ASPX = "~/{0}/Pages/Compare/{1}";
        public const string PAGE_CP_DESKTOP_ASPX = "~/{0}/ControlP/Desktop/";
        public const string PAGE_CP_PAGES_ASPX = "~/{0}/ControlP/Pages/";
        // FOLDERs
        public const string FOLDER_FORMS = "~/Client/User_Files/Forms/";
        public const string FOLDER_FORMS_BankReciept = "~/Client/User_Files/Forms/BankReciept/";
        public const string FOLDER_APPLICANT = "~/Client/User_Files/Applicants/";
        public const string FOLDER_MEDIAS = "~/Client/User_Files/Medias/";
        public const string FOLDER_THUMBS = "~/Client/User_Files/Thumbs/";
        public const string FOLDER_TEMP = "~/Client/User_Files/Temp/";
        public const string FOLDER_USERPROFILE = "~/Client/User_Files/UserProfile/";
        public const string FOLDER_SITEMAPS = "~/Client/Files/SiteMaps/";
        public const string FOLDER_PLUGINS = "~/Client/User_Files/Plugins/";
        public const string FOLDER_VIDEOPLAYER = "~/Client/Pages/VideoPlayer/";
        public const string FOLDER_CONTACTS = "~/Client/Files/Xmls/Contacts/";
        public const string FOLDER_APP_LOCALE = "~/Application/Locale/";
        public const string FOLDER_CLIENT_LOCALE = "~/Client/Locale/";
        public const string FOLDER_APPLICATION_STYLE = "~/Application/Styles/";
        // FILES
        public const string FILE_SCRIPTS_PERSIANDATEPIKER = "/Application/Scripts/persianDatePicker.js";
        public const string FILE_SCRIPTS_JQUERY = "~/Application/Scripts/jquery.min.js";
        public const string FILE_CPRTLCSS = "~/Application/Styles/rtl.css";
        public const string FILE_RTLCSS = "~/Client/Styles/rtl.css";
        public const string FILE_EN_FONT = "~/Client/Styles/enFont.css";
        public const string FILE_FA_FONT = "~/Client/Styles/faFont.css";
        public const string FILE_CONTACT_XML = "~/Client/Files/Xmls/Contacts.xml";
        public const string FILE_PLAYER_SWF = "~/Client/Files/Flash/Player.swf";
        public const string FILE_TRANSLATOR_TEMPLATE_XML = "en_Template.xml";
        public const string FILE_FORMS_XML = "~/Client/Files/Xmls/Forms.xml";
        public const string FILE_EMAIL_TEMPLATE_HTML_GENERAL = "~/Client/Files/Xmls/EmailTemplateGeneral.html";
        public const string FILE_EMAIL_TEMPLATE_HTML_DETAILED = "~/Client/Files/Xmls/EmailTemplateDetailed.html";
        // Images
        public const string IMAGE_TEMP_FAVICON = "~/Client/User_Files/Temp/favicon.ico";
        public const string IMAGE_PUBLIC_FAVICON = "/Client/Images/favicon.ico";
        public const string IMAGE_CIEMESUS_FAVICON = "/Application/Images/General/ciemesus.ico";
        public const string IMAGE_NOAVAILABLE_ICON = "/Client/Images/Public/noImageIcon.jpg";
        public const string IMAGE_NOAVAILABLE_SMALL = "/Client/Images/Public/noImageSmall.png";
        public const string IMAGE_NOAVAILABLE_BIG = "/Client/Images/Public/noImageBig.jpg";
        // HTML Tags
        public const string HTML_IMAGE_CHECK = "<img src=\"/Application/Images/General/check.png\" />";
        public const string HTML_IMAGE_ERROR = "<img src=\"/Application/Images/General/error.png\" />";
        public const string HTML_ICON_GRID = "<img src='/Application/Images/CP/Grid.png' />";
        public const string HTML_ICON_LIST = "<img src='/Application/Images/CP/List.png' />";
        // File Extensions
        public const string FILE_EXTENSIONS_Sitemap = ".sitemap";
        // QUERYSTRINGs
        public const string QUERYSTRING_SUBJECT_ID = "sid";
        public const string QUERYSTRING_SUBJECT_TYPE_ID = "tid";
        public const string QUERYSTRING_SUBJECT_TYPE_NAME = "stn";
        public const string QUERYSTRING_SUBJECT_ALIAS = "als";
        public const string QUERYSTRING_LIST_STYLE = "stl";
        public const string QUERYSTRING_SEARCH = "sch";
        public const string QUERYSTRING_PLAYING_VIDEO_URL = "pvu";
        public const string QUERYSTRING_PLAYING_VIDEO_TITLE = "pvt";
        public const string QUERYSTRING_RETURN_URL = "ReturnUrl";
        // SESSIONs
        public const string SESSION_PURCHASE_PRICE = "PurchasePrice";
        // STRINGs
        public const string STRING_ROLES_ADMIN = "Administrator";
        public const string STRING_ROLES_MEMBER = "Member";
        public const string STRING_PUBLIC_FOLDER_NAME = "Pages";
        public const string STRING_PAGELIST_MODULE = "PageList";
        public const string STRING_PAGE_MODULE = "Page";
        public const string STRING_GALLERY_MODULE = "Gallery";
        public const string STRING_LIST_MODULE = "List";
        public const string STRING_LISTITEM_MODULE = "ListItem";
        public const string STRING_ROLE_ADMINISTRATOR = "Administrator";
        public const string STRING_ROLE_CIEMESUS = "SuperAdmin";
        public const string STRING_ROLE_MEMBER = "Member";
        
        // INTEGERs
        public const int INT_width = 300;
        public const int INT_height = 300;

        // ENUMS
        public enum Modules
        {
            Home = 0,
            Page,
            PageList,
            List,
            ListItem,
            Gallery,
            Search,
            UserPage,
            Contact,
            Login,
            Errors,
            Compare
        }
    }
}