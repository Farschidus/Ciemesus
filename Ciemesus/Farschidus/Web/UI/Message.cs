using System;
using System.Text;
using System.Xml;

namespace Farschidus.Web.UI
{
    public class Message
    {
        public enum MessageTypes
        {
            Success,
            Information,
            Warning,
            Error
        }
        public const string DEFAULT_HTML_TEXT = "<div><input type='button' class='closeNotification' onclick='closeNotification()' /><ul></ul></div>";
        public const string DIV_TAG = "div";
        public const string UL_TAG = "ul";
        public const string LI_TAG = "li";
        public const string SPAN_TAG = "<span class='icon{0}'></span><p class='message'>{1}</p>";
        public const string ATTR_CLASS = "class";

        private string _htmlText;
        public string HtmlText
        {
            get
            {
                return _htmlText;
            }
            set
            {
                _htmlText = value.Trim();
            }
        }

        public Message()
        {
        }
        public void Add(string message, MessageTypes messageType)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (string.IsNullOrEmpty(HtmlText))
                {
                    HtmlText = DEFAULT_HTML_TEXT;
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(_htmlText);

                XmlNode nodDiv = xmlDoc.SelectSingleNode(DIV_TAG);

                XmlNode nodUL = xmlDoc.SelectSingleNode("//" + UL_TAG);

                //Create li node
                XmlNode nodLI = xmlDoc.CreateElement(LI_TAG);

                //Create "class" attribute of the "li" node
                XmlAttribute xmlAtrName = xmlDoc.CreateAttribute(ATTR_CLASS);

                //Set the value of class attribute to the given li 
                xmlAtrName.Value = messageType.ToString();

                string iconAndMessage = string.Format(SPAN_TAG, messageType.ToString(), message);
                //Add message as li inner text
                nodLI.InnerXml = iconAndMessage;

                //Appent "name" attribute to the newly created section element of setting
                nodDiv.Attributes.Append(xmlAtrName);

                //Appent newly created section to the root element of setting
                nodUL.AppendChild(nodLI);

                _htmlText = xmlDoc.InnerXml.ToString();
            }     
        }
        public void Clear()
        {
            _htmlText = "";
        }
    }
}