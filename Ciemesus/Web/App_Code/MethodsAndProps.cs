using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using BLL.BusinessEntity;
using System.Xml;
using System.Collections.Specialized;

namespace Global
{
    /// <summary>
    /// Summary description for Global
    /// </summary>
    public class MethodsAndProps
    {
        public static string WebsiteName
        {
            get
            {
                return Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "Name", "langCode", CurrentLanguageCode);
            }
        }
        public static string DateFormat
        {
            get
            {
                return Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "ServerDateFormat", "value");
            }
        }
        public static double TimeZone
        {
            get
            {
                return double.Parse(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Website", "TimeZone", Farschidus.Configuration.ConfigurationManager.STRING_VALUE));
            }
        }
        public static string CurrentLanguageCode
        {
            get
            {
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["loc"]))
                    return HttpContext.Current.Request.QueryString["loc"].ToString();
                else
                    return "en_US";
            }
        }

        public static string mGetLimitedString(int? count, string text)
        {
            int length = 20;
            if (count.HasValue)
                length = count.Value;

            if (text.Length <= length)
                return text;
            else
            {
                int last = text.Substring(length - 1).IndexOf(' ');
                return text.Substring(0, length + last) + "...";
            }
        }
        public static string mToFarsiDigit(string str)
        {
            string vInt = "1234567890";
            char[] mystring = str.ToCharArray(0, str.Length);
            var newStr = string.Empty;
            for (var i = 0; i <= (mystring.Length - 1); i++)
                if (vInt.IndexOf(mystring[i]) == -1)
                    newStr += mystring[i];
                else
                    newStr += ((char)((int)mystring[i] + 1728));
            return newStr;
        }
        public static void mSendEmail(string fromEmailAddress, string fromDisplayName, string toEmailAddress, string subject, string emailBody)
        {
            MailAddress from = new MailAddress(fromEmailAddress, fromDisplayName);
            MailAddress to = new MailAddress(toEmailAddress);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = subject;
            mail.Body = emailBody;
            mail.IsBodyHtml = true;
            mail.Sender = from;
            mail.Priority = MailPriority.Normal;

            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
            MailSettingsSectionGroup mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;

            System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(mailSettings.Smtp.Network.UserName, mailSettings.Smtp.Network.Password);
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = networkCredential;
            smtp.Send(mail); 
        }
        public static void mSendEmail(string fromEmailAddress, string fromDisplayName, string toEmailAddress, string subject, ListDictionary templateParameters, string templatePath)
        {
            if (!string.IsNullOrEmpty(templatePath) || !File.Exists(templatePath))
            {
                MailAddress from = new MailAddress(fromEmailAddress, fromDisplayName);
                MailAddress to = new MailAddress(toEmailAddress);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Sender = from;
                mail.Priority = MailPriority.Normal;

                System.IO.StreamReader fileReader = File.OpenText(templatePath);
                string body = fileReader.ReadToEnd();
                foreach (string key in templateParameters.Keys)
                {
                    body = body.Replace(key, Convert.ToString(templateParameters[key]));
                }
                fileReader.Close();
                mail.Body = body;

                Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.config");
                MailSettingsSectionGroup mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(mailSettings.Smtp.Network.UserName, mailSettings.Smtp.Network.Password);
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = networkCredential;
                smtp.Send(mail);  //Send the MailMessage useing the Web.config settings
            }
            else
            {
                throw new Exception("The Email Template File Is Not Exist Or Is Not Defined");
            }
        }
        public static string mSeperateDigits(double number, int count)
        {
            return number.ToString("N0", new System.Globalization.NumberFormatInfo()
            {
                NumberGroupSizes = new[] { count },
                NumberGroupSeparator = ","
            });
        }
        public static string mCleanHtmlTags(string Contect)
        {
            return System.Text.RegularExpressions.Regex.Replace(Contect, @"<(.|\n)*?>", string.Empty);
        }
        public static string mToDate(object dateTime, byte languageID, string DateFormat)
        {
            if (string.IsNullOrEmpty(DateFormat))
            {
                if (languageID.Equals(2))
                    return new Farschidus.JalaliDateTime((DateTime)dateTime).ToShortDateString();
                else
                    return ((DateTime)dateTime).ToShortDateString();
            }
            else
            {
                if (languageID.Equals(2))
                    return new Farschidus.JalaliDateTime((DateTime)dateTime).ToString(DateFormat);
                else
                    return ((DateTime)dateTime).ToString(DateFormat);
            }
        }
        public static bool mIsAliasUnique(string alias, byte subjectType, byte lanquage, Guid? idSubject)
        {
            Subjects subject = new Subjects();
            subject.LoadAllBySubjectAliasAndIDSubjectTypeAndIDLanguage(mAliasCorrection(alias), subjectType, lanquage);
            if (subject.RowCount > 0)
            {
                if (idSubject.HasValue && idSubject.Value.Equals(subject.pIDSubject))
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        public static string mAliasCorrection(string alias)
        {
            return alias.Trim().Replace(" ", "_");
        }
        public static string mGetPageURL(Subjects subject, SubjectTypes.Enum subjectTypeEnum)
        {
            Languages lang = new Languages(subject.pIDLanguage);            
            string url = string.Empty;
            string moduleName = string.Empty;

            switch (subjectTypeEnum)
            {
                case SubjectTypes.Enum.home:
                    {
                        moduleName = "Home";
                        break;
                    }
                case SubjectTypes.Enum.contact:
                    {
                        moduleName = "Contact";
                        break;
                    }
                case SubjectTypes.Enum.page:
                    {
                        moduleName = "Page";
                        break;
                    }
                case SubjectTypes.Enum.imageGallery:
                case SubjectTypes.Enum.videoGallery:
                case SubjectTypes.Enum.audioGallery:
                    {
                        moduleName = "Gallery";
                        break;
                    }
                case SubjectTypes.Enum.list:
                    {
                        moduleName = "List/List";
                        break;
                    }
                case SubjectTypes.Enum.listItem:
                    {
                        moduleName = @"ListItem";
                        break;
                    }
                case SubjectTypes.Enum.form:
                    {
                        moduleName = "Form";
                        break;
                    }
            }

            switch (subjectTypeEnum)
            {
                case SubjectTypes.Enum.home:
                case SubjectTypes.Enum.contact:
                    {
                        url = string.Format("/{0}/{1}/{2}/", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, moduleName);
                        break;
                    }
                default:
                    {
                        url = string.Format("/{0}/{1}/{2}/{3}", lang.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, moduleName, subject.pAlias);
                        break;
                    }
            }

            return url;
        }
        public static string mGetHtmlLink(Guid? subjectId, SubjectTypes.Enum subjectTypeEnum)
        {
            string result = string.Empty;
            if (subjectId.HasValue)
            {
                Subjects subject = new Subjects(subjectId.Value);
                result = Global.MethodsAndProps.mGetPageURL(subject, subjectTypeEnum);
                result = string.Format("<a href='{0}' class='pageLink' target='_blank'>{0}</a>", result);
            }
            return result;
        }
        public static string mGetHtmlSpan(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Format("<span class='pageEmptySpan'>{0}</a>", text);
            else
                return string.Format("<span class='pageSpan'>{0}</a>", text);

        }
        public static int[] mGetImageDimention(string filePath)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(filePath))
            {
                return new int[] { image.Width, image.Height };
            }
        }
        public static int[] mGetResizedImageDimention(string filePath, float targetWidth, float targetHeight)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(filePath))
            {
                float ratio = 1f;
                float newWidth = image.Width;
                float newHeight = image.Height;
                float targetRatio = targetWidth / targetHeight;
                float sourceRatio = newWidth / newHeight;

                if (image.Width > targetWidth || image.Height > targetHeight)
                {
                    if (sourceRatio > targetRatio)
                        ratio = newWidth / targetWidth;
                    else
                        ratio = newHeight / targetHeight;

                    newWidth = image.Width / ratio;
                    newHeight = image.Height / ratio;
                }
                return new int[] { (int)newWidth, (int)newHeight };
            }
        }
        public static void mGenerateThumbnail(string imagePath)
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(Global.Constants.FOLDER_THUMBS)))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(Global.Constants.FOLDER_THUMBS));
            string strMediaExtention = System.IO.Path.GetExtension(imagePath).ToLower();
            int width = int.Parse(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Thumbnail", "Dimention", "width"));
            int height = int.Parse(Farschidus.Configuration.ConfigurationManager.Settings.GetItemAttribute("Thumbnail", "Dimention", "height"));

            if (strMediaExtention.Equals(".jpg") || strMediaExtention.Equals(".jpeg") || strMediaExtention.Equals(".png"))
            {
                string[] oldThumbFilePath = Directory.GetFiles(HttpContext.Current.Server.MapPath(Global.Constants.FOLDER_THUMBS), Path.GetFileNameWithoutExtension(imagePath) + ".*");

                if (oldThumbFilePath.Length > 0 && File.Exists(oldThumbFilePath[0]))
                    File.Delete(oldThumbFilePath[0]);

                int[] newIntDim = mGetResizedImageDimention(imagePath, width, height);

                System.Drawing.Image originalImage = System.Drawing.Image.FromFile(imagePath);
                System.Drawing.Image thumb = originalImage.GetThumbnailImage(newIntDim[0], newIntDim[1], null, IntPtr.Zero);

                string thumbFullFilePath = Path.Combine(Global.Constants.FOLDER_THUMBS, Path.GetFileName(imagePath));
                System.Drawing.Imaging.ImageFormat imageFormat;
                switch (strMediaExtention)
                {
                    case ".jpg":
                    case ".jpeg":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".png":
                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    default:
                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    thumb.Save(ms, imageFormat);
                    FileStream file = new FileStream(HttpContext.Current.Server.MapPath(thumbFullFilePath), FileMode.Create, System.IO.FileAccess.Write);
                    ms.WriteTo(file);
                    file.Close();
                }
            }
        }
        public static void mUpdateSiteMap(string resourceKey, string newAlias, string modulName)
        {
            Languages languages = new Languages();
            languages.LoadAll();
            string sitemapFile;
            do
            {
                sitemapFile = HttpContext.Current.Server.MapPath(string.Format("{0}{1}.sitemap", Global.Constants.FOLDER_SITEMAPS, languages.pCode));
                if (System.IO.File.Exists(sitemapFile))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(sitemapFile);
                    XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
                    manager.AddNamespace("sm", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
                    XmlNode renamedNode = xmlDoc.SelectSingleNode("//sm:siteMapNode[@resourceKey='" + resourceKey + "']", manager);
                    if (renamedNode != null)
                    {
                        if (renamedNode.Attributes["url"].Value.Contains(Global.Constants.STRING_PAGELIST_MODULE))
                            modulName = Global.Constants.STRING_PAGELIST_MODULE;
                        if (renamedNode.Attributes["url"].Value.Contains(Global.Constants.STRING_LIST_MODULE))
                        {
                            System.Globalization.TextInfo TitleCase = new System.Globalization.CultureInfo("en-US", false).TextInfo;
                            if (renamedNode.Attributes["url"].Value.Contains(TitleCase.ToTitleCase(ListTypePage.Enum.grid.ToString())))
                            {
                                modulName = Global.Constants.STRING_LIST_MODULE + "/" + TitleCase.ToTitleCase(ListTypePage.Enum.grid.ToString());
                            }
                            else
                            {
                                modulName = Global.Constants.STRING_LIST_MODULE + "/" + TitleCase.ToTitleCase(ListTypePage.Enum.list.ToString());
                            }
                        }
                        renamedNode.Attributes["url"].Value = string.Format("~/{0}/{1}/{2}/{3}", languages.pCode, Global.Constants.STRING_PUBLIC_FOLDER_NAME, modulName, newAlias);
                    }
                    xmlDoc.Save(sitemapFile);
                }
            }
            while (languages.MoveNext());
        }

        //public static mReOrder(Subjects unorderedSubjects, string draggedPriority, string targetPriority, bool direction)
        //{
        //    string initFilter = "";
        //    if (!string.IsNullOrEmpty(unorderedSubjects.Filter))
        //    {
        //        initFilter = unorderedSubjects.Filter + " AND ";
        //    }
        //    unorderedSubjects.Filter = initFilter + string.Format("{0}={1}", Subjects.ColumnNames.Priority, draggedPriority);
        //    unorderedSubjects.pPriority = -1;

        //    if (direction)
        //    {
        //        unorderedSubjects.Filter = initFilter + string.Format("{0}>={1} AND {0} < {2}", Subjects.ColumnNames.Priority, targetPriority, draggedPriority);
        //        if (unorderedSubjects.RowCount > 0)
        //        {
        //            do
        //            {
        //                unorderedSubjects.pPriority += 1;
        //            } while (unorderedSubjects.MoveNext());
        //        }
        //    }
        //    else
        //    {
        //        unorderedSubjects.Filter = initFilter + string.Format("{0}>{1} AND {0} <= {2}", Subjects.ColumnNames.Priority, draggedPriority, targetPriority);
        //        if (unorderedSubjects.RowCount > 0)
        //        {
        //            do
        //            {
        //                unorderedSubjects.pPriority -= 1;
        //            } while (unorderedSubjects.MoveNext());
        //        }
        //    }
        //    unorderedSubjects.Filter = initFilter + string.Format("{0}={1}", Subjects.ColumnNames.Priority, "-1");
        //    unorderedSubjects.pPriority = Convert.ToInt32(targetPriority);

        //   pSubjects = unorderedSubjects;
        //   Subjects subjects = new Subjects();
        //   subjects = pSubjects;
        //   subjects.Save();
        //}
    }
}