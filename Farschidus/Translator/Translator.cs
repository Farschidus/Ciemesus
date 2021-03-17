using System;
using System.Data;
using System.Web;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Web.Configuration;

namespace Farschidus
{
    public class Translator
    {
        private const string SECTION_LANGUAGE = "Language";
        private const string ITEM_PUBLIC_DEFAULT = "PublicDefault";
        private const string ITEM_CP_DEFAULT = "CpDefault";
        private const string STRING_LOCALE = "locale";
        private const string STRING_MESSAGE = "message";
        private const string STRING_KEY = "key";
        private const string STRING_VALUE = "value";
        private const string CLIENT_LOCALE_PATH = "~/Client/Locale/{0}.xml";
        private const string APPLICATION_LOCALE_PATH = "~/Application/Locale/{0}.xml";

        private static readonly object padlock = new object();
        private static Translator _appTranslate = null;
        public static Translator AppTranslate
        {
            get
            {
                lock (padlock)
                {
                    if (_appTranslate == null)
                    {
                        _appTranslate = new Translator();
                    }
                    return _appTranslate;
                }
            }
        }
        public string this[string key]
        {
            get { return AppTranslator(key); }
        }
        private static string AppTranslator(string key)
        {
            string address = System.Web.HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;
            string localeFilePath = string.Empty;
            if(address.Contains("Application"))
                localeFilePath = HttpContext.Current.Server.MapPath(string.Format(APPLICATION_LOCALE_PATH, CurrentLanguageCode));
            else
                localeFilePath = HttpContext.Current.Server.MapPath(string.Format(CLIENT_LOCALE_PATH, CurrentLanguageCode));

            XmlDocument xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(localeFilePath))
            {
                throw new Exception(string.Format("There is no language file ('{0}') in App_Locale folder or 'App_Locale' folder doesn't exist.", CurrentLanguageCode));
            }
            xmlDoc.Load(localeFilePath);
            XmlNode xmlNode = xmlDoc.SelectSingleNode("//message[@key='" + key + "']");
            if (xmlNode == null)
            {
                throw new Exception(string.Format("There is no such key:('{0}') in {1} xml file.", key, CurrentLanguageCode));
            }
            return xmlNode.InnerText;
        }

        private static string CurrentLanguageCode
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["loc"]))
                    return HttpContext.Current.Request.QueryString["loc"].ToString();
                else
                    return "en_US";
            }
        }
        public static byte PublicDefaultLanguage
        {
            get
            {
                Configuration.ConfigurationManager.Settings.CheckandCreateNode(SECTION_LANGUAGE, ITEM_PUBLIC_DEFAULT, "1");
                return Convert.ToByte(Configuration.ConfigurationManager.Settings[SECTION_LANGUAGE, ITEM_PUBLIC_DEFAULT]);
            }
        }
        public static byte CpDefaultLanguage
        {
            get
            {
                Configuration.ConfigurationManager.Settings.CheckandCreateNode(SECTION_LANGUAGE, ITEM_CP_DEFAULT, "1");
                return Convert.ToByte(Configuration.ConfigurationManager.Settings[SECTION_LANGUAGE, ITEM_CP_DEFAULT]);
            }
        }

        public static bool SetPublicDefaultLanguage(string languageID)
        {
            try
            {
                Configuration.ConfigurationManager.Settings.CheckandCreateNode(SECTION_LANGUAGE, ITEM_PUBLIC_DEFAULT, "1");
                Configuration.ConfigurationManager.Settings.UpdateItemAttribute(SECTION_LANGUAGE, ITEM_PUBLIC_DEFAULT, STRING_VALUE, languageID);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SetCPDefaultLanguage(string languageID)
        {
            try
            {
                Configuration.ConfigurationManager.Settings.CheckandCreateNode(SECTION_LANGUAGE, ITEM_CP_DEFAULT, "1");
                Configuration.ConfigurationManager.Settings.UpdateItemAttribute(SECTION_LANGUAGE, ITEM_CP_DEFAULT, STRING_VALUE, languageID);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string Translate(string key)
        {
            return Translate(key, CurrentLanguageCode);
        }
        public static string Translate(string key, string Language)
        {
            string baseUrl = System.Web.HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath;
            baseUrl = baseUrl.Remove(baseUrl.LastIndexOf("/"));
            return Translate(baseUrl, key, Language);
        }
        public static string Translate(object sender, string key)
        {
            string baseUrl = ((System.Web.UI.Control)sender).TemplateSourceDirectory;
            return Translate(baseUrl, key, CurrentLanguageCode);
        }
        public static string Translate(string baseUrl, string key, string Language)
        {
            string localeFilePath = baseUrl + "/Locale/" + Language + ".xml";

            XmlDocument xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(HttpContext.Current.Server.MapPath(localeFilePath)))
            {
                throw new Exception(string.Format("There is no such language:('{0}') in project.", Language));
            }
            xmlDoc.Load(HttpContext.Current.Server.MapPath(localeFilePath));

            XmlNode xmlNode = xmlDoc.SelectSingleNode("/locale/message[@key='" + key + "']");
            if (xmlNode != null)
            {
                return xmlNode.InnerText;
            }
            else
            {
                throw new Exception(string.Format("There is no such key [{0}]!", key));
            }
            throw new Exception("UnSpecified Error!");
        }

        public bool CreateLocaleItem(string targetFolder, string key, string value, string Language)
        {
            string localeFilePath = string.Format("{0}/{1}.xml", targetFolder, Language);
            XmlDocument xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(localeFilePath))
            {
                throw new Exception(string.Format("There is no such language:('{0}') in project.", CurrentLanguageCode));
            }
            xmlDoc.Load(localeFilePath);
            XmlNode xmlNode = xmlDoc.SelectSingleNode("/locale/message[@key='" + key + "']");
            if (xmlNode != null)
            {
                // node already  exists
                return false;
            }
            XmlNode xmlNodeRoot = xmlDoc.SelectSingleNode(STRING_LOCALE);

            //Create new "message" node
            XmlNode xmlNodeSection = xmlDoc.CreateElement(STRING_MESSAGE);

            //Create "key" attribute of the "message" node
            XmlAttribute xmlAtrName = xmlDoc.CreateAttribute(STRING_KEY);

            //Set the value of "key" attribute
            xmlAtrName.Value = key;
            xmlNodeSection.InnerText = value;
            //Appent "key" attribute to the newly created "message" element of "locale" file
            xmlNodeSection.Attributes.Append(xmlAtrName);

            //Appent newly created "message" to the root element of "locale" file
            xmlNodeRoot.AppendChild(xmlNodeSection);

            xmlDoc.Save(localeFilePath);

            return true;
        }
        public bool RemoveLocaleItem(string targetFolder, string key, string Language)
        {
            string localeFilePath = string.Format("{0}/{1}.xml", targetFolder, Language);
            XmlDocument xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(localeFilePath))
            {
                throw new Exception(string.Format("There is no such language:('{0}') in project.", CurrentLanguageCode));
            }
            xmlDoc.Load(localeFilePath);
            XmlNode xmlNode = xmlDoc.SelectSingleNode("/locale/message[@key='" + key + "']");
            if (xmlNode == null)
            {
                // node not  exists
                return false;
            }
            XmlNode xmlNodeRoot = xmlDoc.SelectSingleNode(STRING_LOCALE);
            //Appent newly created "message" to the root element of "locale" file
            xmlNodeRoot.RemoveChild(xmlNode);

            xmlDoc.Save(localeFilePath);

            return true;
        }
    }
}