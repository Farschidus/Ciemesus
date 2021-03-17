using System.Web;

namespace Farschidus
{
    /// <summary>
    /// GetFile class for addressing files in your web application.
    /// </summary>
    public class GetFile
    {
        /// <summary>
        /// AbsoluteURL example:  "~/JavaScripts/jQuery/jquery1.3.2.js"
        /// </summary>
        public static string ByAbsoluteURL(string AbsoluteURL)
        {
            string path = string.Empty;
            string originalURL = string.Empty;

            if (!string.IsNullOrEmpty(AbsoluteURL))
            {
                originalURL = HttpContext.Current.Request.Url.Host;
                path = "http://" + originalURL + AbsoluteURL.Remove(0, 1);
            }
            else
            {
                // Do nothing!
            }
            return path;
        }
    }

    public class BrowserValidator
    {
        public static bool IsEnabledClientScript(HttpContext context)
        {
            if (context.Request.Browser.EcmaScriptVersion.Major >= 1)
                return true;
            return false;
        }
    }
}
