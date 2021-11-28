using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.BusinessEntity;
using System.Collections.Specialized;
using System.Web.Security;

public partial class Pages_Store_Default : BasePublic
{
    readonly string[] strQuantity = { "تعداد", "کارتن", "عدد" };
    private byte storeType
    {
        get
        {
            // Grid => General =>  کلی
            // List => Detailed => جزیی
            ListTypePage.Enum result = ListTypePage.Enum.list;
            if (Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE] != null)
            {
                Enum.TryParse<ListTypePage.Enum>(Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE].ToString(), true, out result);
            }
            return (byte)result;
        }
        set
        {
            ViewState["storeType"] = value;
        }
    }
    private Guid pSelectedItem
    {
        get
        {
            return (Guid)ViewState["pSelectedItem"];
        }
        set
        {
            ViewState["pSelectedItem"] = value;
        }
    }
    private List<Pair> pPropertyIDAndValues
    {
        get
        {
            return (List<Pair>)ViewState["pPropertyIDAndValues"];
        }
        set
        {
            ViewState["pPropertyIDAndValues"] = value;
        }
    }
    private List<KeyValuePair<Guid, string>> pBasket
    {
        get
        {
            if (ViewState["pBasket"] == null)
            {
                List<KeyValuePair<Guid, string>> newBasket = new List<KeyValuePair<Guid, string>>();
                ViewState["pBasket"] = newBasket;
            }
            return (List<KeyValuePair<Guid, string>>)ViewState["pBasket"];
        }
        set
        {
            ViewState["pBasket"] = value;
        }
    }
    //private string listItem
    //{
    //    get
    //    {
    //        ListTypePage.Enum result = ListTypePage.Enum.grid;
    //        if (Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE] != null)
    //        {
    //            Enum.TryParse<ListTypePage.Enum>(Request.QueryString[Global.Constants.QUERYSTRING_LIST_STYLE].ToString(), true, out result);
    //        }
    //        System.Globalization.TextInfo TitleCase = new System.Globalization.CultureInfo("en-US", false).TextInfo;
    //        return Farschidus.Configuration.ConfigurationManager.Settings.GetItemInnerText("ListType", TitleCase.ToTitleCase(result.ToString()));
    //    }
    //}
    const string otherFiles = @"<li class='thumbItem'><a style='border:none;' data-lightbox='ImageGroups' rel='lightbox' href='{0}' >{1}</a></li>";
    const string listItem = @"<div class='Store-Grid'>
                            <a href='{0}'> 
                              <img class='Store-image' src='{1}'></img>
                              <div class='Store-text'>{2}</div>
                            </a>
                          </div>";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (isAuthenticated())
        {
            if (!IsPostBack)
            {
                mInisializing();
            }
            else if (!string.IsNullOrEmpty(Request.Params["__EVENTTARGET"]) && Request.Params["__EVENTTARGET"].Contains("MiniCardItem"))
            {
                mRemoveItemFromBasket(Convert.ToInt16(Request.Params["__EVENTARGUMENT"]));
            }
            else if (!string.IsNullOrEmpty(Request.Params["__EVENTARGUMENT"]))
            {
                mFillItemView(new Guid(Request.Params["__EVENTARGUMENT"]));
            }
        }
        else
        {
            FormsAuthentication.RedirectToLoginPage();
            // "?" + Global.Constants.QUERYSTRING_RETURN_URL + Request.Url
        }
    }
    protected void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        mListBinding(new Guid(ddlGroups.SelectedValue));
    }
    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = mGetPropertyData(pPropertyIDAndValues, "حجم");
        string[] propertyItemsID = value.Split(',');
        mClear(false);

        PropertyItems propertyItems = new PropertyItems();
        if (rblType.SelectedValue.Contains("مایع"))
        {
            for (int i = 0; i < propertyItemsID.Length; i++)
            {
                propertyItems.LoadByPrimaryKey(propertyItemsID[i]);
                if (propertyItems.pTitle.Contains("کیلو") || propertyItems.pTitle.Contains("گرم"))
                    continue;
                ListItem item = new ListItem();
                item.Text = propertyItems.pTitle;
                item.Value = propertyItems.pIDPropertyItem.ToString();
                rblCapacity.Items.Add(item);
            }
        }
        else
        {
            for (int i = 0; i < propertyItemsID.Length; i++)
            {
                propertyItems.LoadByPrimaryKey(propertyItemsID[i]);
                if (propertyItems.pTitle.Contains("لیتر") || propertyItems.pTitle.Contains("سی سی"))
                    continue;
                ListItem item = new ListItem();
                item.Text = propertyItems.pTitle;
                item.Value = propertyItems.pIDPropertyItem.ToString();
                rblCapacity.Items.Add(item);
            }
        }
        uplCapacity.Update();
    }
    protected void rblCapacity_SelectedIndexChanged(object sender, EventArgs e)
    {
        int multiplier = (storeType.Equals(1)) ? 12 : 1;
        string value = mGetPropertyData(pPropertyIDAndValues, "حجم");
        string value2 = mGetPropertyData(pPropertyIDAndValues, "قیمت");
        string[] capacities = value.Split(',');
        string[] prices = value2.Split('|');
        int index = Array.IndexOf(capacities, rblCapacity.SelectedValue);
        if (index > -1)
        {
            int price = int.Parse(prices[index]) * multiplier;
            litPrice.Text = Global.MethodsAndProps.mToFarsiDigit(price.ToString());
            litUnit.Text = "&nbsp; ریال";
            litQuantity.Text = string.Format("<input type='number' min='1' max='99' step='1' value='1' name='quantity' title='Qty' class='qty' maxlength='2' size='2' onchange='farschidus(this.value)' >&nbsp;<span>{0}</span>", strQuantity[storeType]);
            btnAddToBasket.Visible = true;
        }
        uplPrice.Update();
    }
    protected void btnAddToBasket_Click(object sender, EventArgs e)
    {
        btnCheckout.Visible = true;
        Subjects item = new Subjects(pSelectedItem);
        if (pBasket.Count > 0)
        {
            if (pBasket.Exists(x => x.Key.Equals(pSelectedItem)))
            {
                bool flag = false;
                string[] oldArray = new string[5];
                List<KeyValuePair<Guid, string>> all = pBasket.Where(x => x.Key.Equals(pSelectedItem)).ToList();
                foreach (KeyValuePair<Guid, string> a in all)
                {
                    oldArray = a.Value.Split(',');
                    if (rblCapacity.SelectedItem.Text.Equals(oldArray[2]))
                    {
                        flag = true;
                        pBasket.Remove(a);
                        break;
                    }
                }
                if (flag)
                {
                    int quantity = Convert.ToInt32(oldArray[4]);
                    oldArray[4] = (quantity + Convert.ToInt32(hfdQuantity.Value)).ToString();
                    //// ----- Add New One  -------- ///
                    pBasket.Add(new KeyValuePair<Guid, string>(pSelectedItem, string.Join(",", oldArray)));
                }
                else
                {
                    string[] names = { item.pTitle, rblType.SelectedItem.Text, rblCapacity.SelectedItem.Text, litPrice.Text, hfdQuantity.Value };
                    pBasket.Add(new KeyValuePair<Guid, string>(pSelectedItem, string.Join(",", names)));
                }
            }
            else
            {
                string[] names = { item.pTitle, rblType.SelectedItem.Text, rblCapacity.SelectedItem.Text, litPrice.Text, hfdQuantity.Value };
                pBasket.Add(new KeyValuePair<Guid, string>(pSelectedItem, string.Join(",", names)));
            }
        }
        else
        {
            string[] names = { item.pTitle, rblType.SelectedItem.Text, rblCapacity.SelectedItem.Text, litPrice.Text, hfdQuantity.Value };
            pBasket.Add(new KeyValuePair<Guid, string>(pSelectedItem, string.Join(",", names)));
        }
        mFillMiniCard();
        ScriptManager.RegisterStartupScript(uplItemView, typeof(string), "closePopupModal", "closePopup()", true);
        uplItemView.Update();
        uplMiniCard.Update();
    }
    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        string dateStamp = Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mToDate(DateTime.UtcNow.AddHours(3.5), 2, "HH:mm yyyy/MM/dd"));
        string OrderNo = Guid.NewGuid().ToString();
        ListDictionary list = new ListDictionary();

        try
        {
            if (storeType.Equals(1))
            {
                MembershipUser user = Membership.GetUser();
                var userProfile = GetProfileInstance.GetProfile(user.UserName);

                list.Add("<!--OrderNo-->", OrderNo);
                list.Add("<!--OrderDate-->", dateStamp);
                list.Add("<!--FirstName-->", userProfile.FirstName);
                list.Add("<!--LastName-->", userProfile.LastName);
                list.Add("<!--Tel-->", userProfile.Tel);
                list.Add("<!--Mobile-->", userProfile.Mobile);
                list.Add("<!--State-->", userProfile.State);
                list.Add("<!--City-->", userProfile.City);
                list.Add("<!--Description-->", userProfile.Description);
                list.Add("<!--Details-->", mGetDetails());

                Global.MethodsAndProps.mSendEmail("noreply@SepehrParmis.com", "فروشگاه سپهر پارمیس", "sepehr.parmis@yahoo.com", "سفارش جدید " + dateStamp, list, Server.MapPath(Global.Constants.FILE_EMAIL_TEMPLATE_HTML_GENERAL));

                litMessage.Text = "<span class='label label-success' style='font-size:16px;margin-top:230px;display:block;margin-right: 5px;'>با تشکر از خرید شما، سفارش شما ثبت گردید. در اولین فرصت از بخش فروش با شما تماس گرفته خواهد شد.</span>";
                litMessage.Text += "<br/>";
                litMessage.Text += string.Format("<span class='label label-success' style='font-size:18px'>کد پیگیری: {0}</span>", OrderNo);
                litMessage.Text += string.Format("<div style='font-size:18px;bottom:0px;color:#5CB85C;position:absolute;margin-right:95px'>آدرس: {0}", "تهران، خیابان پاسداران ، خیابان بوستان هشتم ، پلاک ۱۱۲، طبقه ۴");
                litMessage.Text += "<br/>";
                litMessage.Text += string.Format("تلفن: {0}</div>", "۲۲۵۹۸۵۴۲");

                pBasket.Clear();
            }
            else
            {
                pnlDetailed.Visible = true;
                litMessage.Text = "";
            }            
        }
        catch (Exception ex)
        {
            litMessage.Text = ex.Message;
        }
        finally
        {
            btnCheckout.Visible = false;
            uplMiniCard.Update();
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try {
            string dateStamp = Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mToDate(DateTime.UtcNow.AddHours(3.5), 2, "HH:mm yyyy/MM/dd"));
            string OrderNo = Guid.NewGuid().ToString();
            ListDictionary list = new ListDictionary();

            list.Add("<!--OrderNo-->", OrderNo);
            list.Add("<!--OrderDate-->", dateStamp);
            list.Add("<!--FullName-->", txtFullName.Text);
            list.Add("<!--Tel-->", txtTel.Text);
            list.Add("<!--Address-->", txtAddress.Text);
            list.Add("<!--Details-->", mGetDetails());

            Global.MethodsAndProps.mSendEmail("noreply@SepehrParmis.com", "فروشگاه سپهر پارمیس", "sepehr.parmis@yahoo.com", "سفارش جدید " + dateStamp, list, Server.MapPath(Global.Constants.FILE_EMAIL_TEMPLATE_HTML_DETAILED));

            litMessage.Text = "<span class='label label-success' style='font-size:16px;margin-top:230px;display:block;margin-right: 5px;'>با تشکر از خرید شما، سفارش شما ثبت گردید. در اولین فرصت از بخش فروش با شما تماس گرفته خواهد شد.</span>";
            litMessage.Text += "<br/>";
            litMessage.Text += string.Format("<span class='label label-success' style='font-size:18px'>کد پیگیری: {0}</span>", OrderNo);
            litMessage.Text += string.Format("<div style='font-size:18px;bottom:0px;color:#5CB85C;position:absolute;margin-right:95px'>آدرس: {0}", "تهران، خیابان پاسداران ، خیابان بوستان هشتم ، پلاک ۱۱۲، طبقه ۴");
            litMessage.Text += "<br/>";
            litMessage.Text += string.Format("تلفن: {0}</div>", "۲۲۵۹۸۵۴۲");
        }
        catch (Exception ex)
        {
            litMessage.Text = ex.Message;
        }
        finally
        {
            pBasket.Clear();
            btnCheckout.Visible = false;
            pnlDetailed.Visible = false;
            uplMiniCard.Update();
        }
    }

    private bool isAuthenticated()
    {
        if (storeType.Equals(1))
        {
            if (User.Identity.IsAuthenticated && (User.IsInRole(Global.Constants.STRING_ROLE_MEMBER) || User.IsInRole(Global.Constants.STRING_ROLE_ADMINISTRATOR)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    private void mInisializing()
    {
        if (Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS] != null)
        {
            btnCheckout.Visible = false;
            litMessage.Text = "<span class='label label-info'>سبد شما خالی است</span>";
            Subjects subjects = new Subjects();
            subjects.LoadBySubjectAliasAndIDLanguage(Request.QueryString[Global.Constants.QUERYSTRING_SUBJECT_ALIAS].ToString(), pCurrentLanguageID);
            if (subjects.RowCount > 0)
            {
                Subjects groups = new Subjects
                {
                    Sort = Subjects.ColumnNames.Priority
                };
                groups.LoadByIDParentAndIDSubjectTypeAndIDLanguage(subjects.pIDSubject, (byte)SubjectTypes.Enum.list, pCurrentLanguageID, true);
                if (groups.RowCount > 0)
                {
                    ddlGroups.DataSource = groups.DefaultView;
                    ddlGroups.DataTextField = Subjects.ColumnNames.Title;
                    ddlGroups.DataValueField = Subjects.ColumnNames.IDSubject;
                    ddlGroups.DataBind();
                    mListBinding(groups.pIDSubject);

                    litPageTitle.Text = pTitle = "فروشگاه";
                    litDesc.Text = subjects.pBody;
                    pageBanner.Subject = subjects;
                    pagePluginForList.SubjectID = subjects.pIDSubject;
                }
                else
                {
                    litBody.Text = Farschidus.Translator.AppTranslate["search.default.message.noResult"];
                }
            }
            else
            {
                litBody.Text = Farschidus.Translator.AppTranslate["general.message.pageNotExist"];
            }
        }
    }
    private void mListBinding(Guid parentID)
    {
        Subjects subjects = new Subjects
        {
            Sort = Subjects.ColumnNames.Priority
        };
        subjects.LoadByIDParentAndIDSubjectTypeAndIDLanguage(parentID, (byte)SubjectTypes.Enum.listItem, pCurrentLanguageID, true);
        if (subjects.RowCount > 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul id='StoreList'>");
            do
            {
                sb.Append("<li>");
                sb.Append(string.Format(listItem, mGenerateURL(subjects.pIDSubject), mGetCoverImage(subjects.pIDSubject.ToString()), subjects.pTitle, Global.MethodsAndProps.mGetLimitedString(100, Global.MethodsAndProps.mCleanHtmlTags(subjects.pBody))));
                sb.Append("</li>");
            }
            while (subjects.MoveNext());
            sb.Append("</ul>");
            litBody.Text = sb.ToString();
        }
        else
        {
            litBody.Text = string.Empty;
        }
    }
    private void mFillItemView(Guid subjectID)
    {
        pSelectedItem = subjectID;
        mClear(true);
        hfdQuantity.Value = "1";

        Subjects item = new Subjects(subjectID);

        if (item.RowCount > 0)
        {
            litItemTitle.Text = item.pTitle;

            List<Pair> propertyIDAndValues = new List<Pair>();
            mGetPropertiesThatHasValue(ref propertyIDAndValues, item);
            pPropertyIDAndValues = propertyIDAndValues;
            string value = mGetPropertyData(pPropertyIDAndValues, "نوع");
            string[] propertyItemsID = value.Split(',');
            mGenerateTypeRadioButton(propertyItemsID);

            itemPlugin.SubjectID = item.pIDSubject;
            litAttachments.Text = string.Format("<img class='img' src='{0}'></img>", mGetCoverImage(item.pIDSubject.ToString()));
        }
        else
        {
            litBody.Text = Farschidus.Translator.AppTranslate["general.message.page.deactivate"];
        }
        uplItemView.Update();
    }
    private string mGenerateURL(Guid iDSubject)
    {
        return string.Format(@"javascript:togglePopUp(""StoreItemView"",""{0}"",""{1}"",true)", uplItemView.ClientID, iDSubject);
    }
    public string mGetCoverImage(string IDSubject)
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
    public string mGetThumbnails(string IDSubject)
    {
        StringBuilder result = new StringBuilder();
        string thumbItem = "<img src='{0}{1}' />";

        MediaSubjects Thumbnail = new MediaSubjects();
        Thumbnail.LoadByIDSubjectAndIDMediaSubjectType(new Guid(IDSubject), (byte)MediaSubjectTypes.Enum.thumbnail);
        if (Thumbnail.RowCount > 0)
            result.AppendFormat(thumbItem, Global.Constants.FOLDER_THUMBS.Substring(1), Thumbnail.pIDMedia + Thumbnail.pFileExtention);
        else
            result.AppendFormat(thumbItem, Global.Constants.IMAGE_NOAVAILABLE_SMALL, string.Empty);
        return result.ToString();
    }
    private void mGetPropertiesThatHasValue(ref List<Pair> propertyIDAndValues, Subjects subject)
    {
        if (subject.SubjectPropertyValues.RowCount > 0)
        {
            do
            {
                propertyIDAndValues.Add(new Pair(subject.SubjectPropertyValues.pIDProperty, subject.SubjectPropertyValues.pValue));
            }
            while (subject.SubjectPropertyValues.MoveNext());
        }
    }
    private string mGetPropertyData(List<Pair> propIDAndValues, string filterName)
    {
        string result = string.Empty;
        Properties prop = new Properties();
        foreach (Pair propIdVal in propIDAndValues)
        {
            prop.LoadByPrimaryKey(propIdVal.First);
            if (prop.pName.Contains(filterName))
            {
                PropertyTypes.Enum propType = (PropertyTypes.Enum)prop.pIDType;
                switch (propType)
                {
                    case PropertyTypes.Enum.integer:
                        {
                            result = propIdVal.Second.ToString();
                            break;
                        }
                    case PropertyTypes.Enum.multiSelect:
                        {
                            result = propIdVal.Second.ToString();
                            break;
                        }
                }
            }
        }
        return result;
    }
    private void mGenerateTypeRadioButton(string[] propertyItemsID)
    {
        rblType.Items.Clear();
        PropertyItems propertyItems = new PropertyItems();
        foreach (string propItem in propertyItemsID)
        {
            propertyItems.LoadByPrimaryKey(propItem);
            ListItem item = new ListItem();
            item.Text = propertyItems.pTitle;
            item.Value = propertyItems.pTitle;
            rblType.Items.Add(item);
        }
    }
    private void mFillMiniCard()
    {
        int total = 0;
        string[] arrValue = new string[5];
        StringBuilder sb = new StringBuilder();
        sb.Append("<ul id='list-group'>");
        int i = 0;
        foreach (KeyValuePair<Guid, string> item in pBasket)
        {
            arrValue = item.Value.Split(',');
            sb.AppendFormat(@"<li class='list-group-item'><a id=""{5}{6}"" href=""javascript:__doPostBack('{5}{6}', '{6}')""><span class='glyphicon glyphicon-remove pull-right'></span></a>{0} - {1} - {2} - {3} {7} - {4} ریال</li>", arrValue[0], arrValue[1], arrValue[2], Global.MethodsAndProps.mToFarsiDigit(arrValue[4]), Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(Convert.ToDouble(mToLatinDigit(arrValue[3])), 3)), "MiniCardItem", i, strQuantity[storeType]);
            total += Convert.ToInt32(mToLatinDigit(arrValue[3])) * Convert.ToInt32(arrValue[4]);
            i++;
        }
        double offPercentage = total * .15;
        sb.Append("</ul>");
        sb.Append("<ul id='list-group'>");
        if (storeType.Equals(2)) {
            sb.AppendFormat("<li class='list-group-item'>{0} : {1} ریال</li>", "جمع", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(total, 3)));
            sb.AppendFormat("<li class='list-group-item'>{0} : {1} ریال</li>", "تخفیف ۱۵% خرید آنلاین", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(offPercentage, 3)));
            sb.AppendFormat("<li class='list-group-item'>{0} : {1} ریال</li>", "جمع کل", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(total - offPercentage, 3)));
        }
        else {
            sb.AppendFormat("<li class='list-group-item'>{0} : {1} ریال</li>", "جمع کل", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(total, 3)));
        }
        sb.Append("</ul>");
        litMessage.Text = sb.ToString();
    }
    private void mRemoveItemFromBasket(int index)
    {
        pBasket.RemoveAt(index);
        if (pBasket.Count > 0)
        {
            mFillMiniCard();
        }
        else
        {
            litMessage.Text = "<span class='label label-info'>سبد شما خالی است</span>";
            btnCheckout.Visible = false;
        }
        uplMiniCard.Update();
    }
    private static string mToLatinDigit(string str)
    {
        string vInt = "۱۲۳۴۵۶۷۸۹۰";
        char[] mystring = str.ToCharArray(0, str.Length);
        var newStr = string.Empty;
        for (var i = 0; i <= (mystring.Length - 1); i++)
            if (vInt.IndexOf(mystring[i]) == -1)
                newStr += mystring[i];
            else
                newStr += ((char)((int)mystring[i] - 1728));
        return newStr;
    }
    private string mGetDetails()
    {
        int total = 0;
        int i = 1;
        string[] arrValue = new string[5];
        string tableRow = "<tr style='border: 1px solid #000;'><td style='width:35px;'>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>";
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat(tableRow, "ردیف", "نام کالا", "نوع و حجم", "تعداد", "قیمت واحد به ریال");
        foreach (KeyValuePair<Guid, string> item in pBasket)
        {
            arrValue = item.Value.Split(',');
            sb.AppendFormat(tableRow, Global.MethodsAndProps.mToFarsiDigit(i.ToString()), arrValue[0], arrValue[1] + " - " + arrValue[2], Global.MethodsAndProps.mToFarsiDigit(arrValue[4]), Global.MethodsAndProps.mToFarsiDigit(arrValue[3]));
            total += Convert.ToInt32(mToLatinDigit(arrValue[3])) * Convert.ToInt32(arrValue[4]);
            i++;
        }
        if (storeType.Equals(1))
        {
            sb.AppendFormat("<tr style='border: 1px solid #000;'><td colspan='4' style='text-align:left'>{0}</td><td>{1} ریال</td></tr>", "جمع کل", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(total, 3)));
        }
        else
        {
            double offPercentage = total * .15;
            sb.AppendFormat("<tr style='border: 1px solid #000;'><td colspan='4' style='text-align:left'>{0}</td><td>{1} ریال</td></tr>", "جمع", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(total, 3)));
            sb.AppendFormat("<tr style='border: 1px solid #000;'><td colspan='4' style='text-align:left'>{0}</td><td>{1} ریال</td></tr>", "تخفیف ۱۵% خرید آنلاین", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(offPercentage, 3)));
            sb.AppendFormat("<tr style='border: 1px solid #000;'><td colspan='4' style='text-align:left'>{0}</td><td>{1} ریال</td></tr>", "جمع کل", Global.MethodsAndProps.mToFarsiDigit(Global.MethodsAndProps.mSeperateDigits(total - offPercentage, 3)));
        }
        return sb.ToString();
    }
    private void mClear(bool clearType)
    {
        if (clearType)
            rblType.Items.Clear();
        rblCapacity.Items.Clear();
        litPrice.Text = litUnit.Text = litQuantity.Text = string.Empty;
        btnAddToBasket.Visible = false;
    }
}