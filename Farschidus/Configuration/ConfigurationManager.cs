using System;
using System.Collections.Specialized;
using System.Web;
using System.Xml;

namespace Farschidus.Configuration
{
    public class ConfigurationManager
    {
        public const string STRING_THRITA_SETTING_FILE_PATH = "ConfigFilePath";
        public const string STRING_SETTINGS = "settings";
        public const string STRING_SECTION = "section";
        public const string STRING_ITEM = "item";
        public const string STRING_KEY = "key";
        public const string STRING_VALUE = "value";
        public const string STRING_NAME = "name";
        public const string STRING_LANGCODE = "langCode";

        private static readonly object padlock = new object();
        private static ConfigurationManager settings = null;
        public static ConfigurationManager Settings
        {
            get
            {
                lock (padlock)
                {
                    if (settings == null)
                    {
                        settings = new ConfigurationManager();
                    }
                    return settings;
                }
            }
        }

        //A two-Dimention indexer for getting value of an item inner text
        public string this[string section, string key]
        {
            get
            {
                return GetItemAttribute(section, key, STRING_VALUE);
            }
        }
        //A three-Dimention indexer for getting value of an item attribute
        public string this[string section, string key, string attribute]
        {
            get
            {
                return GetItemAttribute(section, key, attribute);
            }
        }

        private string configFilePath;
        /// <summary>
        /// The file path of the xml config file
        /// </summary>
        public string ConfigFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(configFilePath))
                {
                    if (System.Configuration.ConfigurationManager.AppSettings[STRING_THRITA_SETTING_FILE_PATH] != null)
                    {
                        configFilePath = System.Configuration.ConfigurationManager.AppSettings[STRING_THRITA_SETTING_FILE_PATH];
                    }
                    else
                    {
                        configFilePath = "~/Client/Files/Xmls/config.xml";
                    }

                    configFilePath = HttpContext.Current.Server.MapPath(configFilePath);
                    if (!System.IO.File.Exists(configFilePath))
                    {
                        CreateConfigFile(configFilePath);
                    }
                }
                return configFilePath;
            }
        }

        private void CreateConfigFile(string filePath)
        {
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            System.IO.Stream settingStream = myAssembly.GetManifestResourceStream("Farschidus.EmbeddedFiles.Config.xml");
            System.IO.FileStream targetStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);


            byte[] buffer = new byte[0x10000];
            int bytes;
            try
            {
                while ((bytes = settingStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    targetStream.Write(buffer, 0, bytes);
                }
            }
            finally
            {
                targetStream.Flush();
                targetStream.Close();
                settingStream.Flush();
                settingStream.Close();
            }
        }

        private XmlDocument configDocument;
        /// <summary>
        /// The config.xml file
        /// </summary>
        public XmlDocument ConfigDocument
        {
            get
            {
                if (configDocument == null)
                {
                    configDocument = new XmlDocument();
                    configDocument.Load(ConfigFilePath);
                }
                return configDocument;
            }
            set
            {
                configDocument = value;
            }
        }

        /// <summary>
        /// This methods returns the specified section
        /// </summary>
        /// <param name="section">The section of the setting item</param>       
        /// <returns>xmlNode of the found Item</returns>
        public XmlNode GetSection(string section)
        {
            string errorMessage = "There is a problem reading setting file!";
            XmlNode resultNode = null;

            if (IsSectionExisted(section))
            {
                resultNode = ConfigDocument.SelectSingleNode(string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));
            }
            else
            {
                errorMessage = string.Format("There is no such section:('{0}')", section);
            }

            return resultNode;
        }
        /// <summary>
        /// This methods returns the specified Item Node of the given section
        /// </summary>
        /// <param name="section">The section of the setting item</param>
        /// <param name="key">The key of the setting item to find</param>
        /// <returns>xmlNode of the found Item</returns>
        public XmlNode GetItem(string section, string key)
        {
            string errorMessage = "There is a problem reading setting file!";
            XmlNode resultNode = null;

            if (IsSectionExisted(section))
            {
                XmlNode xmlSectionNode = ConfigDocument.SelectSingleNode
                    (string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                XmlNode xmlNode = xmlSectionNode.SelectSingleNode(string.Format("{0}[@{1}=\"{2}\"]", STRING_ITEM, STRING_KEY, key));
                if (xmlNode != null)
                {
                    resultNode = xmlNode;
                }
                else
                {
                    errorMessage = string.Format("There is no such item key:('{0}')", key);
                }
            }
            else
            {
                errorMessage = string.Format("There is no such section:('{0}')", section);
            }

            return resultNode;
        }
        /// <summary>
        /// Get the string value of the InnerText of the found item in the given section by given key.
        /// </summary>
        /// <param name="section">The name of the section to look for the item in.</param>
        /// <param name="key">The key of the item to look for.</param>
        /// <returns>string value of the InnerText of the found item</returns>
        public string GetItemInnerText(string section, string key)
        {
            string result = string.Empty;
            XmlNode xmlNode = GetItem(section, key);
            if (xmlNode != null)
            {
                result = xmlNode.InnerText;
            }
            else
            {
                throw new Exception(string.Format("There is no such Item:('{0}') in this section.", key));
            }

            return result;
        }
        /// <summary>
        /// Gets the value of the given attribute of the found item in the given section
        /// </summary>
        /// <param name="section">The name of the section to look for the item in.</param>
        /// <param name="key">The key of the item to look for.</param>
        /// <param name="attribute"> The attribute of the item to return its value</param>
        /// <returns>Returns the value of the given attribute of the found item in the given section</returns>
        public string GetItemAttribute(string section, string key, string attribute)
        {
            string result = string.Empty;
            XmlNode xmlNode = GetItem(section, key);
            if (xmlNode != null)
            {
                if (xmlNode.Attributes[attribute] != null)
                {
                    result = xmlNode.Attributes[attribute].Value;
                }
                else
                {
                    throw new Exception(string.Format("There is no such attribute:('{0}') in this Item.", attribute));
                }
            }

            return result;
        }
        /// <summary>
        /// This methods returns the specified Item Node of the given section with given key and specifice attribute and its value
        /// </summary>
        /// <param name="section">The section of the setting item</param>
        /// <param name="key">The key of the setting item to find</param>
        /// <param name="property">The property of the setting item to find</param>
        /// <param name="propValue">The value of the property in item to find</param>
        /// <returns>string of the Value attributein founded Item</returns>
        public string GetItemAttribute(string section, string key, string property, string propValue)
        {
            string errorMessage = "There is a problem reading setting file!";
            string result = null;

            if (IsSectionExisted(section))
            {
                XmlNode xmlSectionNode = ConfigDocument.SelectSingleNode(string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                XmlNode xmlNode = xmlSectionNode.SelectSingleNode(string.Format("{0}[@{1}=\"{2}\"and @{3}=\"{4}\"]", STRING_ITEM, STRING_KEY, key, property, propValue));
                if (xmlNode != null)
                {
                    result = xmlNode.Attributes[STRING_VALUE].Value;
                }
                else
                {
                    errorMessage = string.Format("There is no such item key:('{0}')", key);
                }
            }
            else
            {
                errorMessage = string.Format("There is no such section:('{0}')", section);
            }

            return result;
        }

        /// <summary>
        /// Updates the section
        /// </summary>
        /// <param name="section">The name of the section</param>
        /// <param name="attribute">The name of the attribute to change</param>
        /// <param name="newValue">The new value of the Item</param>
        /// <returns>true if successful, false if fails</returns>
        public bool UpdateSection(string section, string attribute, string newValue)
        {
            if (!string.IsNullOrEmpty(section)
             && !string.IsNullOrEmpty(attribute))
            {
                XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                if (xmlNodeSection != null)
                {
                    if (xmlNodeSection.Attributes[attribute] != null)
                    {
                        xmlNodeSection.Attributes[attribute].Value = newValue;
                        ConfigDocument.Save(ConfigFilePath);
                        settings = new ConfigurationManager();
                        return true;
                    }
                    else
                    {
                        throw new Exception(string.Format("There is no such attribute: [{0}]", attribute));
                    }
                }
                else
                {
                    throw new Exception(string.Format("There is no such section:[{0}]", section));
                }
            }
            else
            {
                throw new Exception("The 'section' or 'attribute' can not be null or empty string");
            }
        }

        /// <summary>
        /// Adds a new section to the config file
        /// </summary>
        /// <param name="name">The name of the section</param>
        /// <returns>true if successful, false if fails</returns>
        public bool AddSection(string name)
        {
            try
            {
                XmlNode section = ConfigDocument.CreateElement(STRING_SECTION);
                XmlAttribute attrName = ConfigDocument.CreateAttribute(STRING_NAME);
                attrName.Value = name;
                section.Attributes.Append(attrName);
                ConfigDocument.ChildNodes[1].AppendChild(section);
                ConfigDocument.Save(ConfigFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Adds a new Item to the given section
        /// </summary>
        /// <param name="section">The name of the section</param>
        /// <param name="key">The key of the item to add section</param>
        /// <param name="value">The value of the item to add section</param>
        /// <returns>true if successful, false if fails</returns>
        public bool AddItem(string section, string key, string value)
        {
            ListDictionary valueAttr = new ListDictionary();
            valueAttr.Add(STRING_VALUE, value);          

            return AddItem(section, key, valueAttr);
        }
        public bool AddItem(string section, string key, string value, string property, string propValue)
        {
            ListDictionary valueAttr = new ListDictionary();
            valueAttr.Add(STRING_VALUE, value);
            valueAttr.Add(property, propValue);

            return AddItem(section, key, valueAttr);
        }
        /// <summary>
        /// Adds a new Item to the given section
        /// </summary>
        /// <param name="section">The name of the section</param>
        /// <param name="key">The key of the item to add section</param>
        /// <param name="attributes">The attribute and their values to add as pair values</param>
        /// <returns>true if successful, false if fails</returns>
        public bool AddItem(string section, string key, ListDictionary attributes)
        {
            if (!string.IsNullOrEmpty(section) && !string.IsNullOrEmpty(key) && attributes.Count > 0)
            {
                if (IsSectionExisted(section))
                {
                    XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                        string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                    if (!string.IsNullOrEmpty(key))
                    {
                        //Create Item node
                        if (!IsItemExisted(section, key))
                        {
                            XmlNode xmlNodeItem = ConfigDocument.CreateElement(STRING_ITEM);

                            //Create  attributes of the "Item" node
                            XmlAttribute xmlAtrKey = ConfigDocument.CreateAttribute(STRING_KEY);
                            //Set the value of "key" attribute.
                            xmlAtrKey.Value = key;
                            //Appent "key" attribute to the newly created section item element
                            xmlNodeItem.Attributes.Append(xmlAtrKey);

                            XmlAttribute xmlAtrValue = null;
                            foreach (string attrKeys in attributes.Keys)
                            {
                                if (!string.IsNullOrEmpty(attrKeys))
                                {
                                    xmlAtrValue = ConfigDocument.CreateAttribute(attrKeys);
                                    //Set the value of "value" attribute.
                                    xmlAtrValue.Value = attributes[attrKeys].ToString();

                                    //Appent the attribute to the newly created item element.
                                    xmlNodeItem.Attributes.Append(xmlAtrValue);
                                }
                            }
                            //Appent newly created item to the given section.
                            xmlNodeSection.AppendChild(xmlNodeItem);

                            ConfigDocument.Save(ConfigFilePath);
                        }
                        else
                        {
                            throw new Exception(string.Format("an item with the same key already exists [{0}]", key));
                        }
                    }
                    else
                    {
                        throw new Exception("The key value of item can not be null or empty string");
                    }
                }
                else
                {
                    throw new Exception(string.Format("There is no section with the given name [{0}]", section));
                }
            }
            else
            {
                throw new Exception("The 'section','key' and 'attributes' can not be null or empty");
            }

            return true;
        }
        /// <summary>
        /// Adds a new Item to the given section
        /// </summary>
        /// <param name="section">The name of the section</param>
        /// <param name="key">The key of the item to add section</param>
        /// <param name="attribute">The name of the attribute to change</param>
        /// <param name="value">The new value of the Item</param>
        /// <returns>true if successful, false if fails</returns>
        public bool UpdateItemInnerText(string section, string key, string value)
        {
            if (!string.IsNullOrEmpty(section) && !string.IsNullOrEmpty(key))
            {
                if (IsSectionExisted(section))
                {
                    if (IsItemExisted(section, key))
                    {
                        XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                        string.Format(@"{0}/{1}[@{2}=""{3}""]/{4}[@{5}=""{6}""]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section, STRING_ITEM, STRING_KEY, key));

                        if (xmlNodeSection != null)
                        {
                            xmlNodeSection.InnerXml = string.Empty; ;
                            xmlNodeSection.AppendChild(ConfigDocument.CreateCDataSection(value));
                            ConfigDocument.Save(ConfigFilePath);
                            settings = new ConfigurationManager();
                            return true;
                        }
                        else
                        {
                            throw new Exception("The 'section','key','attribute' or 'value' can not be null or empty");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("The 'section','key' and 'attribute'  can not be null or empty string");
            }
            return true;
        }
         
        public bool UpdateItemAttribute(string section, string key, string attribute, string value)
        {
            if (!string.IsNullOrEmpty(section) && !string.IsNullOrEmpty(key)
             && !string.IsNullOrEmpty(attribute))
            {
                if (IsSectionExisted(section))
                {
                    //Create section node
                    if (IsItemExisted(section, key))
                    {
                        XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                        string.Format("{0}/{1}[@{2}=\"{3}\"]/{4}[@{5}=\"{6}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section, STRING_ITEM, STRING_KEY, key));

                        if (xmlNodeSection != null)
                        {
                            if (xmlNodeSection.Attributes[attribute] != null)
                            {
                                xmlNodeSection.Attributes[attribute].Value = value;
                                ConfigDocument.Save(ConfigFilePath);
                                settings = new ConfigurationManager();
                                return true;
                            }
                            else
                            {
                                throw new Exception(string.Format("There is no such attribute: [{0}]", attribute));
                            }
                        }
                        else
                        {
                            throw new Exception("The 'section','key','attribute' or 'value' can not be null or empty");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("The 'section','key' and 'attribute'  can not be null or empty string");
            }
            return true;
        }

        public bool UpdateItemAttribute(string section, string key, string attribute, string value, string property, string propValue)
        {
            if (!string.IsNullOrEmpty(section) && !string.IsNullOrEmpty(key)
             && !string.IsNullOrEmpty(attribute))
            {
                if (IsSectionExisted(section))
                {
                    //Create section node
                    if (IsItemExisted(section, key))
                    {
                        XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                        string.Format("{0}/{1}[@{2}=\"{3}\"]/{4}[@{5}=\"{6}\"][@{7}=\"{8}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section, STRING_ITEM, STRING_KEY, key, property, propValue));

                        if (xmlNodeSection != null)
                        {
                            if (xmlNodeSection.Attributes[attribute] != null)
                            {
                                xmlNodeSection.Attributes[attribute].Value = value;
                                ConfigDocument.Save(ConfigFilePath);
                                settings = new ConfigurationManager();
                                return true;
                            }
                            else
                            {
                                throw new Exception(string.Format("There is no such attribute: [{0}]", attribute));
                            }
                        }
                        else
                        {
                            throw new Exception("The 'section','key','attribute' or 'value' can not be null or empty");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("The 'section','key' and 'attribute'  can not be null or empty string");
            }
            return true;
        }
        /// <summary>
        /// Deletes the item with the given key from the sepecified section.
        /// </summary>
        /// <param name="section">The name of the section</param>
        /// <param name="key">The key of the item to delete.</param>
        /// <returns>true if successful, false if fails</returns>
        public bool DeleteItem(string section, string key)
        {
            if (IsSectionExisted(section))
            {
                XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                    string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                //Create section node
                if (IsItemExisted(section, key))
                {
                    XmlNode xmlNodeItem = xmlNodeSection.SelectSingleNode(
                         string.Format("{0}[@{1}=\"{2}\"]", STRING_ITEM, STRING_KEY, key));

                    //Remove the Item from the section
                    xmlNodeSection.RemoveChild(xmlNodeItem);

                    ConfigDocument.Save(ConfigFilePath);
                }
                else
                {
                    throw new Exception(string.Format("There is no item with the given key [{0}]", key));
                }
            }
            else
            {
                throw new Exception(string.Format("There is no section [{0}]", section));
            }

            return true;
        }

        /// <summary>
        /// Checks if a section with the given name exists.
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <returns>true if found, otherwise false.</returns>
        public bool IsSectionExisted(string section)
        {
            bool result = false;

            XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

            if (xmlNodeSection != null)
            {
                result = true;
            }

            return result;

        }
        /// <summary>
        /// Checks if the Item with the given key exists in the specified section.
        /// </summary>
        /// <param name="section">The name of the section.</param>
        /// <param name="key">The key of the Item to look for.</param>
        /// <returns>true if found, otherwise false</returns>
        public bool IsItemExisted(string section, string key)
        {
            bool result = false;
            if (IsSectionExisted(section))
            {
                XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                    string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                XmlNode xmlItemNode = xmlNodeSection.SelectSingleNode(
                    string.Format("{0}[@{1}=\"{2}\"]", STRING_ITEM, STRING_KEY, key));

                if (xmlItemNode != null)
                {
                    result = true;
                }
            }
            else
            {
                throw new Exception(string.Format("There is no such section [{0}].", section));
            }
            return result;
        }

        public bool IsItemExisted(string section, string key, string property, string propValue)
        {
            bool result = false;
            if (IsSectionExisted(section))
            {
                XmlNode xmlNodeSection = ConfigDocument.SelectSingleNode(
                    string.Format("{0}/{1}[@{2}=\"{3}\"]", STRING_SETTINGS, STRING_SECTION, STRING_NAME, section));

                XmlNode xmlItemNode = xmlNodeSection.SelectSingleNode(
                    string.Format("{0}[@{1}=\"{2}\"and @{3}=\"{4}\"]", STRING_ITEM, STRING_KEY, key, property, propValue));                                  

                if (xmlItemNode != null)
                {
                    result = true;
                }
            }
            else
            {
                throw new Exception(string.Format("There is no such section [{0}].", section));
            }
            return result;
        }

        public void CheckandCreateNode(string section, string key, string defaultValue)
        {
            if (!Settings.IsSectionExisted(section))
            {
                Settings.AddSection(section);
                Settings.AddItem(section, key, defaultValue);
            }
            if(!Settings.IsItemExisted(section, key))
            {
                Settings.AddItem(section, key, defaultValue);
            }
        }
    }

    public enum StringConstants
    {
        Date,
        ServerFormat,
        Email,
        UserName,
        Password,
        Host,
        Port
    }
}