using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class PSM_Forms_Report : System.Web.UI.Page
{
    private Guid? pIDSubject
    {
        get
        {
            if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ID] != null)
            {
                Guid subjectID = new Guid(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ID].ToString());
                Subjects subjects = new Subjects(subjectID);
                if (subjects.RowCount > 0)
                {
                    return subjects.pIDSubject;
                }
            }
            return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && pIDSubject.HasValue)
        {
            Subjects subject = new Subjects(pIDSubject.Value);
            Languages lang = new Languages(subject.pIDLanguage);

            string outputTempFile = Server.MapPath(Global.Constants.FOLDER_TEMP + Guid.NewGuid().ToString() + ".pdf");
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            var output = new FileStream(outputTempFile, FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);
            
            document.Open();

            XmlDocument doc = new XmlDocument();
            string formXMLpath = Server.MapPath(Global.Constants.FILE_FORMS_XML);
            doc.Load(formXMLpath);
            XmlNode root = doc.DocumentElement;
            XmlNode formNode = root.SelectSingleNode(string.Format("//form[@id='{0}']", subject.pIDSubject.ToString()));
            XmlNodeList userDataList = formNode.SelectNodes("userData");
            XmlNodeList fields;

            document.AddTitle(subject.pTitle);
            foreach (XmlNode userData in userDataList)
            {
                var padfTable = new PdfPTable(2);
                padfTable.HorizontalAlignment = 0;
                padfTable.SpacingBefore = 10;
                padfTable.SpacingAfter = 10;
                padfTable.DefaultCell.Border = 0;
                if (lang.pIsRTL)
                {
                    padfTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                    padfTable.SetWidths(new int[] { 70, 30 });
                }
                else
                {
                    padfTable.RunDirection = PdfWriter.RUN_DIRECTION_LTR;
                    padfTable.SetWidths(new int[] { 30, 70 });
                }

                fields = userData.ChildNodes;
                foreach (XmlNode field in fields)
                {
                    padfTable.AddCell(new Phrase(field.Attributes["name"].Value, GetTahoma()));
                    padfTable.AddCell(new Phrase(field.InnerText, GetTahoma()));
                }
                document.Add(padfTable);
                document.NewPage();
            }            

            document.Close();

            Response.Clear();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", string.Format("attachment; filename=\"{0} {1}.pdf\"", subject.pTitle, new Farschidus.JalaliDateTime(DateTime.UtcNow.AddHours(3.5)).ToString("(yyyy//MM//dd_hh:mm:ss)")));
            Response.TransmitFile(outputTempFile);
            Response.End();
        }
    }
    public static iTextSharp.text.Font GetTahoma()
    {
        var fontName = "Tahoma";
        if (!FontFactory.IsRegistered(fontName))
        {
            var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf";
            FontFactory.Register(fontPath);
        }
        return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    }
}