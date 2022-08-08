#region // using Directives
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
#endregion

namespace Farschidus.Web.UI.WebControls
{
    [ToolboxData("<{0}:Pager runat=\"server\"></{0}:Pager>")]
    [ToolboxBitmap(typeof(GridView), "Pager.bmp")]
    public class Pager : WebControl, IPostBackEventHandler, INamingContainer
    {
        private const string PAGER_SCRIPT = "052C83FD-A4C2-47C2-B9CD-ED2E0109092D";

        private string GoToImageUniqueID
        {
            get
            {
                return this.ClientID + "_img_goto";
            }
        }

        private string GoToDivUniqueID
        {
            get
            {
                return this.ClientID + "_div_goto";
            }
        }

        private string GoToDropDownUniqueID
        {
            get
            {
                return this.ClientID + "_ddl_goto";
            }
        }

        private string PageSizeSelectUniqueID
        {
            get
            {
                return this.ClientID + "_ddl_pageSize";
            }
        }

        #region // Save/Load Control State
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override object SaveControlState()
        {
            object[] objState = new object[3];
            objState[0] = CurrentIndex;
            objState[1] = PageSize;
            objState[2] = ItemCount;

            return objState;
        }

        protected override void LoadControlState(object state)
        {
            object[] savedState = (object[])state;
            CurrentIndex = (int)savedState[0];
            PageSize = (int)savedState[1];
            ItemCount = (double)savedState[2];
        }
        #endregion

        #region // PostBack Stuff
        private static readonly object EventCommandPageIndex = new object();
        private static readonly object EventCommandPageSize = new object();

        public delegate void PageIndexChangedEventHandler(Object sender, PagerPageIndexChangeEventArgs e);
        public delegate void PageSizeChangedEventHandler(Object sender, PagerPageSizeChangeEventArgs e);

        [Description("Fires when pager page size is changed.")]
        [Bindable(true)]
        [Category("Action")]
        public event PageSizeChangedEventHandler PageSizeChanged
        {
            add { Events.AddHandler(EventCommandPageSize, value); }
            remove { Events.RemoveHandler(EventCommandPageSize, value); }
        }

        [Description("Fires when pager page index is changed.")]
        [Bindable(true)]
        [Category("Action")]
        public event PageIndexChangedEventHandler PageIndexChanged
        {
            add { Events.AddHandler(EventCommandPageIndex, value); }
            remove { Events.RemoveHandler(EventCommandPageIndex, value); }
        }



        protected virtual void OnPageIndexChanged(PagerPageIndexChangeEventArgs e)
        {
            CurrentIndex = e.PageIndex;
            PageIndexChangedEventHandler clickHandler = (PageIndexChangedEventHandler)Events[EventCommandPageIndex];
            if (clickHandler != null) clickHandler(this, e);
        }

        protected virtual void OnPageSizeChanged(PagerPageSizeChangeEventArgs e)
        {
            this.PageSize = e.PageSize;
            PageSizeChangedEventHandler clickHandler = (PageSizeChangedEventHandler)Events[EventCommandPageSize];
            if (clickHandler != null) clickHandler(this, e);
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            string[] arguments = eventArgument.Split('$');
            if (arguments.Length > 0 && arguments[0] == CommandName.PageSizeChanged.ToString())
            {
                int newPageSize = Convert.ToInt32(arguments[1]);

                //Find new CurrentIndex according to new PageSiza
                //_currentIndex = ((CurrentIndex * this.PageSize) / newPageSize);

                this._pageSize = newPageSize;
                ////to reset pageCount
                //this.ItemCount = _itemCount;
                this.CurrentIndex = 1;
                OnPageSizeChanged(new PagerPageSizeChangeEventArgs(this.PageSize));
            }
            else
            {
                OnPageIndexChanged(new PagerPageIndexChangeEventArgs(Convert.ToInt32(eventArgument)));
            }
        }
        #endregion

        #region // Accessors (Behavioural)

        /// <summary>
        /// Gets or sets total number of rows.
        /// </summary>
        private double _itemCount;
        [Browsable(false)]
        public double ItemCount
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;

                double divide = ItemCount / PageSize;
                double ceiled = System.Math.Ceiling(divide);
                PageCount = Convert.ToInt32(ceiled);
            }
        }

        /// <summary>
        /// Gets or sets current page index.
        /// </summary>
        private int _currentIndex = 1;
        [Browsable(false)]
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        /// <summary>
        /// Gets or sets page size (results per page).
        /// </summary>
        private int _pageSize = 15;
        [Category("Behavioural")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// Gets or sets the value that indicates whether the page size option list is rendered as UI on page.
        /// </summary>
        private bool _generatePageSizeSelect = false;
        [Category("Behavioural")]
        public bool GeneratePageSizeSelect
        {
            get { return _generatePageSizeSelect; }
            set { _generatePageSizeSelect = value; }
        }


        /// <summary>
        /// Gets or sets page size selection (page sizes drop down list) starting option.
        /// </summary>
        private byte _pageSizeSelectStart = 5;
        [Category("Behavioural")]
        public byte PageSizeSelectStart
        {
            get { return _pageSizeSelectStart; }
            set { _pageSizeSelectStart = value; }
        }

        /// <summary>
        /// Gets or sets page size selection (page size drop down list) interval.
        /// </summary>
        private byte _pageSizeSelectInterval = 5;
        [Category("Behavioural")]
        public byte PageSizeSelectInterval
        {
            get { return _pageSizeSelectInterval; }
            set { _pageSizeSelectInterval = value; }
        }

        /// <summary>
        /// Gets or sets maximum option of page size selection (maximum results per page).
        /// </summary>
        private int _maximumPageSizeSelect = 100;
        [Category("Behavioural")]
        public int MaximumPageSizeSelect
        {
            get { return _maximumPageSizeSelect; }
            set { _maximumPageSizeSelect = value; }
        }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        private int _pageCount;
        [Browsable(false)]
        private int PageCount
        {
            get
            {
                double divide = ItemCount / PageSize;
                double ceiled = System.Math.Ceiling(divide);
                return Convert.ToInt32(ceiled);
            }
            set { _pageCount = value; }
        }

        /// <summary>
        /// Gets or sets the value that indicates whether the Next and Last clause is rendered as UI on page.
        /// </summary>
        private bool _showFirstLast = false;
        [Category("Behavioural")]
        public bool GenerateFirstLastSection
        {
            get { return _showFirstLast; }
            set { _showFirstLast = value; }
        }

        /// <summary>
        /// Gets or sets the value that indicates whether the SmartShortcuts are rendered as UI on page.
        /// </summary>
        private bool _enableSSC = true;
        [Category("Behavioural")]
        public bool GenerateSmartShortCuts
        {
            get { return _enableSSC; }
            set { _enableSSC = value; }
        }

        /// <summary>
        /// Gets or sets the value that will be used to calculate SmartShortcuts.
        /// </summary>
        private double _sscRatio = 3.0D;
        [Category("Behavioural")]
        public double SmartShortCutRatio
        {
            get { return _sscRatio; }
            set { _sscRatio = value; }
        }

        /// <summary>
        /// Gets or sets maximum number of SmartShortcuts that can be rendered.
        /// </summary>
        private int _maxSmartShortCutCount = 6;
        [Category("Behavioural")]
        public int MaxSmartShortCutCount
        {
            get { return _maxSmartShortCutCount; }
            set { _maxSmartShortCutCount = value; }
        }

        /// <summary>
        /// Gets or sets a value that to have the SmartShortcuts rendered, the page count must be greater that this value.
        /// </summary>
        private int _sscThreshold = 30;
        [Category("Behavioural")]
        public int SmartShortCutThreshold
        {
            get { return _sscThreshold; }
            set { _sscThreshold = value; }
        }

        /// <summary>
        /// Gets or sets the number of rendered page numbers in compact mode.
        /// </summary>
        private int _firstCompactedPageCount = 10;
        [Category("Behavioural")]
        public int CompactModePageCount
        {
            get { return _firstCompactedPageCount; }
            set { _firstCompactedPageCount = value; }
        }

        /// <summary>
        /// Gets or sets the number of rendered page numbers in standard mode.
        /// </summary>
        private int _notCompactedPageCount = 15;
        [Category("Behavioural")]
        public int NormalModePageCount
        {
            get { return _notCompactedPageCount; }
            set { _notCompactedPageCount = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether Pager renders Alt tooltip.
        /// </summary>
        private bool _altEnabled = false;
        [Category("Behavioural")]
        public bool GenerateToolTips
        {
            get { return _altEnabled; }
            set { _altEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether Pager information cell is rendered.
        /// </summary>
        private bool _infoCellVisible = true;
        [Category("Behavioural")]
        public bool GeneratePagerInfoSection
        {
            get { return _infoCellVisible; }
            set { _infoCellVisible = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicats whether GoTo section is rendered.
        /// </summary>
        private GoToSelectionMode _generateGoToSelect = GoToSelectionMode.Static;
        [Category("Behavioural")]
        public GoToSelectionMode GenerateGoToSelect
        {
            get { return _generateGoToSelect; }
            set { _generateGoToSelect = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether hidden hyperlinks should render.
        /// </summary>
        private bool _generateHiddenHyperlinks = false;
        [Category("Behavioural")]
        public bool GenerateHiddenHyperlinks
        {
            get { return _generateHiddenHyperlinks; }
            set { _generateHiddenHyperlinks = value; }
        }

        /// <summary>
        /// Gets or sets the hidden hyperlinks' QueryString parameter name.
        /// </summary>
        private string _queryStringParameterName = "pagerControlCurrentPageIndex";
        [Category("Behavioural")]
        public string QueryStringParameterName
        {
            get { return _queryStringParameterName; }
            set { _queryStringParameterName = value; }
        }

        #endregion

        #region // Accessors (Globalization)

        /// <summary>
        /// Gets or sets the text caption displayed as "go to" in the pager control.
        /// Default value: go to
        /// </summary>
        private string _GoTo = "";
        [Category("Globalization")]
        public string GoToClause
        {
            get { return _GoTo; }
            set { _GoTo = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Page Size" in the pager control.
        /// Default value: Page Size
        /// </summary>
        private string _pageSizeSelectClause = "";
        [Category("Globalization")]
        public string PageSizeSelectClause
        {
            get { return _pageSizeSelectClause; }
            set { _pageSizeSelectClause = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "go" in the pager control.
        /// Default value: go
        /// </summary>
        private string _GO = "";
        [Category("Globalization")]
        public string GoClause
        {
            get { return _GO; }
            set { _GO = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "of" in the pager control.
        /// Default value: of
        /// </summary>
        private string _OF = "";
        [Category("Globalization")]
        public string OfClause
        {
            get { return _OF; }
            set { _OF = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "from" in the pager control.
        /// Default value: From
        /// </summary>
        private string _FROM = "";
        [Category("Globalization")]
        public string FromClause
        {
            get { return _FROM; }
            set { _FROM = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "page" in the pager control.
        /// Default value: Page
        /// </summary>
        private string _PAGE = "";
        [Category("Globalization")]
        public string PageClause
        {
            get { return _PAGE; }
            set { _PAGE = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "to" in the pager control.
        /// Default value: to
        /// </summary>
        private string _TO = "";
        [Category("Globalization")]
        public string ToClause
        {
            get { return _TO; }
            set { _TO = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Showing Results" in the pager control.
        /// Default value: Showing Results
        /// </summary>
        private string _SHOWING_RESULT = "";
        [Category("Globalization")]
        public string ShowingResultClause
        {
            get { return _SHOWING_RESULT; }
            set { _SHOWING_RESULT = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Show Result" in the pager control.
        /// Default value: Show Result
        /// </summary>
        private string _SHOW_RESULT = "";
        [Category("Globalization")]
        public string ShowResultClause
        {
            get { return _SHOW_RESULT; }
            set { _SHOW_RESULT = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "to First Page" in the pager control.
        /// Default value: to First Page
        /// </summary>
        private string _BACK_TO_FIRST = "";
        [Category("Globalization")]
        public string BackToFirstClause
        {
            get { return _BACK_TO_FIRST; }
            set { _BACK_TO_FIRST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "to Last Page" in the pager control.
        /// Default value: to Last Page
        /// </summary>
        private string _GO_TO_LAST = "";
        [Category("Globalization")]
        public string GoToLastClause
        {
            get { return _GO_TO_LAST; }
            set { _GO_TO_LAST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Back to Page" in the pager control.
        /// Default value: Back to Page
        /// </summary>
        private string _BACK_TO_PAGE = "";
        [Category("Globalization")]
        public string BackToPageClause
        {
            get { return _BACK_TO_PAGE; }
            set { _BACK_TO_PAGE = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Next to Page" in the pager control.
        /// Default value: Next to Page
        /// </summary>
        private string _NEXT_TO_PAGE = "";
        [Category("Globalization")]
        public string NextToPageClause
        {
            get { return _NEXT_TO_PAGE; }
            set { _NEXT_TO_PAGE = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Last Page" in the pager control.
        /// Default value: &gt;&gt;
        /// </summary>
        private string _LAST = "&gt;&gt;";
        [Category("Globalization")]
        public string LastClause
        {
            get { return _LAST; }
            set { _LAST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "First Page" in the pager control.
        /// Default value: &lt;&lt;
        /// </summary>
        private string _FIRST = "&lt;&lt;";
        [Category("Globalization")]
        public string FirstClause
        {
            get { return _FIRST; }
            set { _FIRST = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Previous Page" in the pager control.
        /// Default value: &lt;
        /// </summary>
        private string _previous = "&lt;";
        [Category("Globalization")]
        public string PreviousClause
        {
            get { return _previous; }
            set { _previous = value; }
        }

        /// <summary>
        /// Gets or sets the text caption displayed as "Next Page" in the pager control.
        /// Default value: &gt;
        /// </summary>
        private string _next = "&gt;";
        [Category("Globalization")]
        public string NextClause
        {
            get { return _next; }
            set { _next = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether pager control should render RTL or LTR.
        /// </summary>
        private bool _rightToLeft = false;
        [Category("Globalization")]
        public bool RTL
        {
            get { return _rightToLeft; }
            set { _rightToLeft = value; }
        }

        #endregion

        #region // Accessors (Styles)

        /// <summary>
        /// Gets or sets the css class of the Pager Container Table.
        /// Default value: PagerContainerTable;
        /// </summary>
        private string _pagerContainer = "PagerContainer";
        [Category("Styles")]
        public string ContainerTable
        {
            get { return _pagerContainer; }
            set { _pagerContainer = value; }
        }

        private string _gotoStaticAndPageSizeContainer = "GotoStaticAndPageSizeContainer";
        [Category("Styles")]
        public string GotoStaticAndPageSizeContainer
        {
            get { return _gotoStaticAndPageSizeContainer; }
            set { _gotoStaticAndPageSizeContainer = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the Pager info cell.
        /// Default value: PagerInfoCell;
        /// </summary>
        private string _pagerInfoCell = "PagerInfoCell";
        [Category("Styles")]
        public string InfoCellCSS
        {
            get { return _pagerInfoCell; }
            set { _pagerInfoCell = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the current page cell.
        /// Default value: PagerCurrentPage;
        /// </summary>
        private string _currentPageCSS = "PagerCurrentPageCell";
        [Category("Styles")]
        public string CurrentPageCSS
        {
            get { return _currentPageCSS; }
            set { _currentPageCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the other pages cells.
        /// </summary>
        private string _otherPageCSS = "PagerOtherPageCells";
        [Category("Styles")]
        public string OtherPageCSS
        {
            get { return _otherPageCSS; }
            set { _otherPageCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the "go to first page"  cells.If is not provided gets the OtherPageCSS
        /// </summary>
        private string _firstPage = "FirstPage";
        [Category("Styles")]
        public string FirstPage
        {
            get { return _firstPage; }
            set { _firstPage = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the "go to next page"  cells.If is not provided gets the OtherPageCSS
        /// </summary>
        private string _nextPage = "NextPage";
        [Category("Styles")]
        public string NextPage
        {
            get { return _nextPage; }
            set { _nextPage = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the "go to last page"  cells.If is not provided gets the OtherPageCSS
        /// </summary>
        private string _lastPage = "LastPage";
        [Category("Styles")]
        public string LastPage
        {
            get { return _lastPage; }
            set { _lastPage = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the "go to previous page"  cells.If is not provided gets the OtherPageCSS
        /// </summary>
        private string _previousePage = "PreviousPage";
        [Category("Styles")]
        public string PreviousPage
        {
            get { return _previousePage; }
            set { _previousePage = value; }
        }


        /// <summary>
        /// Gets or sets the css class of the current page cell.
        /// </summary>
        private string _sSCCSS = "PagerSSCCells";
        [Category("Styles")]
        public string SSCCSS
        {
            get { return _sSCCSS; }
            set { _sSCCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager hyperLinks.
        /// </summary>
        private string _hyperlinkCSS = "PagerHyperlinkStyle";
        [Category("Styles")]
        public string HyperlinkCSS
        {
            get { return _hyperlinkCSS; }
            set { _hyperlinkCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager go to label navigator link css.
        /// </summary>
        private string _goToLabelCSS = "GoToLabel";
        [Category("Styles")]
        public string GoToLabelCSS
        {
            get { return _goToLabelCSS; }
            set { _goToLabelCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager go to selection navigator link css.
        /// </summary>
        private string _goToSelectCSS = "GoToSelect";
        [Category("Styles")]
        public string GoToSelectCSS
        {
            get { return _goToSelectCSS; }
            set { _goToSelectCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager go to selected option list CSS.
        /// </summary>
        private string _goToSelectedOption = "GoToSelectedOption";
        [Category("Styles")]
        public string GoToSelectedOptionCSS
        {
            get { return _goToSelectedOption; }
            set { _goToSelectedOption = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager go to arrow collapsed mode CSS.
        /// </summary>
        private string _goToArrowCollapsedCSS = "GoToArrowCollapsed";
        [Category("Styles")]
        public string GoToArrowCollapsedCSS
        {
            get { return _goToArrowCollapsedCSS; }
            set { _goToArrowCollapsedCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager go to arrow Expand mode CSS.
        /// </summary>
        private string _goToArrowExpandedCSS = "GoToArrowExpanded";
        [Category("Styles")]
        public string GoToArrowExpandedCSS
        {
            get { return _goToArrowExpandedCSS; }
            set { _goToArrowExpandedCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager page size caption label css.
        /// </summary>
        private string _ageSizeSelectLabelCSS = "PageSizeSelectLabelCSS";
        [Category("Styles")]
        public string PageSizeSelectLabelCSS
        {
            get { return _ageSizeSelectLabelCSS; }
            set { _ageSizeSelectLabelCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager page size selection navigator link css.
        /// </summary>
        private string _pageSizeSelectCSS = "PageSizeSelectCSS";
        [Category("Styles")]
        public string PageSizeSelectCSS
        {
            get { return _pageSizeSelectCSS; }
            set { _pageSizeSelectCSS = value; }
        }

        /// <summary>
        /// Gets or sets the css class of the  pager page size selected option list CSS.
        /// </summary>
        private string _pageSizeSelectedOptionCSS = "PageSizeSelectedCSS";
        [Category("Styles")]
        public string PageSizeSelectedOptionCSS
        {
            get { return _pageSizeSelectedOptionCSS; }
            set { _pageSizeSelectedOptionCSS = value; }
        }

        #endregion

        #region // Render Utilities
        private string GenerateAltMessage(int pageNumber)
        {
            StringBuilder altGen = new StringBuilder();
            altGen.Append(pageNumber == CurrentIndex ? ShowingResultClause : ShowResultClause);
            altGen.Append(" ");
            altGen.Append(((pageNumber - 1) * PageSize) + 1);
            altGen.Append(" ");
            altGen.Append(ToClause);
            altGen.Append(" ");
            altGen.Append(pageNumber == PageCount ? ItemCount : pageNumber * PageSize);
            altGen.Append(" ");
            altGen.Append(OfClause);
            altGen.Append(" ");
            altGen.Append(ItemCount);

            return altGen.ToString();
        }

        private string GetAlternativeText(int pageNumber)
        {
            return GenerateToolTips ? string.Format(" title=\"{0}\"", GenerateAltMessage(pageNumber)) : "";
        }

        private string RenderFirst()
        {
            string templateCell = "<li class=\"{0}\"><a href=\"{1}\" title=\"" + " " + BackToFirstClause + " " + "\"> " + FirstClause + " </a></li>";
            return String.Format(templateCell, FirstPage, Page.ClientScript.GetPostBackClientHyperlink(this, "1"));
        }

        private string RenderLast()
        {
            string templateCell = "<li class=\"{0}\"><a href=\"{1}\" title=\"" + " " + GoToLastClause + " " + "\"> " + LastClause + " </a></li>";
            return String.Format(templateCell, LastPage, Page.ClientScript.GetPostBackClientHyperlink(this, PageCount.ToString()));
        }

        private string RenderBack()
        {
            string templateCell = "<li class=\"{0}\"><a href=\"{1}\" title=\"" + " " + BackToPageClause + " " + (CurrentIndex - 1).ToString() + "\"> " + PreviousClause + " </a></li>";
            return String.Format(templateCell, PreviousPage, Page.ClientScript.GetPostBackClientHyperlink(this, (CurrentIndex - 1).ToString()));
        }

        private string RenderNext()
        {
            string templateCell = "<li class=\"{0}\"><a href=\"{1}\" title=\"" + " " + NextToPageClause + " " + (CurrentIndex + 1).ToString() + "\"> " + NextClause + " </a></li>";
            return String.Format(templateCell, NextPage, Page.ClientScript.GetPostBackClientHyperlink(this, (CurrentIndex + 1).ToString()));
        }

        private string RenderCurrent()
        {
            string tempCell = "<li class=\"{0}\"><span class=\"{1}\" " + GetAlternativeText(CurrentIndex) + " ><strong> " + CurrentIndex.ToString() + " </strong></span></li>";
            return string.Format(tempCell, CurrentPageCSS, HyperlinkCSS);
        }

        private string RenderOther(int pageNumber)
        {
            string templateCell = "<li class=\"{0}\"><a class=\"{1}\" href=\"{2}\" " + GetAlternativeText(pageNumber) + " > " + pageNumber.ToString() + " </a></li>";
            return String.Format(templateCell, OtherPageCSS, HyperlinkCSS, Page.ClientScript.GetPostBackClientHyperlink(this, pageNumber.ToString()));
        }

        private string RenderSSC(int pageNumber)
        {
            string templateCell = "<td class=\"{0}\"><a class=\"{1}\" href=\"{2}\" " + GetAlternativeText(pageNumber) + " > " + pageNumber.ToString() + " </a></td>";
            return String.Format(templateCell, SSCCSS, HyperlinkCSS, Page.ClientScript.GetPostBackClientHyperlink(this, pageNumber.ToString()));
        }

        private string RenderGoToDynamic()
        {
            string templateCell = "<div class=\"{0}\"><div style=\"display: inline-block;\" onclick=\"javascript:Thrita_Web_UI_WebControls_Pager_HandleGoToVisibility('{1}','{2}');\" class=\"{3}\">&nbsp;{4}&nbsp;</div><div style=\"display: inline-block;\" id=\"{5}\" onclick=\"javascript:Thrita_Web_UI_WebControls_Pager_HandleGoToVisibility('{6}','{7}');\" class=\"{8}\"></div><div style=\"display: inline-block;\" id=\"{9}\"><select class=\"{10}\" name=\"{11}\" id=\"{12}\" onchange=\"javascript:Thrita_Web_UI_WebControls_Pager_HandleGoto(this);\">{13}</select></div></div>";

            string listItemTemplate = "<option {0} value=\"{1}\">{2}</option>";

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= this.PageCount; i++)
            {
                sb.Append(string.Format(listItemTemplate, i == CurrentIndex ? string.Format("selected=\"selected\" class=\"{0}\"", GoToSelectedOptionCSS) : "", Page.ClientScript.GetPostBackClientHyperlink(this, i.ToString()), i));
            }
            return string.Format(templateCell, OtherPageCSS, GoToDivUniqueID, GoToImageUniqueID, GoToLabelCSS, GoToClause, GoToImageUniqueID, GoToDivUniqueID, GoToImageUniqueID, GoToArrowCollapsedCSS, GoToDivUniqueID, GoToSelectCSS, GoToDropDownUniqueID, GoToDropDownUniqueID, sb.ToString());
        }

        private string RenderGoToStatic()
        {
            string templateCell = "<div class=\"{0}\"><div style=\"display: inline-block;\" class=\"{1}\">&nbsp;{2}&nbsp;</div><div style=\"display: inline-block;\"><select class=\"{3}\" name=\"{4}\" id=\"{5}\" onchange=\"javascript:Thrita_Web_UI_WebControls_Pager_HandleGoto(this);\">{6}</select></div></div>";

            string listItemTemplate = "<option {0} value=\"{1}\">{2}</option>";

            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= this.PageCount; i++)
            {
                sb.Append(string.Format(listItemTemplate, i == CurrentIndex ? string.Format("selected=\"selected\" class=\"{0}\"", GoToSelectedOptionCSS) : "", Page.ClientScript.GetPostBackClientHyperlink(this, i.ToString()), i));
            }
            return string.Format(templateCell, OtherPageCSS, GoToLabelCSS, GoToClause, GoToSelectCSS, GoToDropDownUniqueID, GoToDropDownUniqueID, sb.ToString());
        }

        private string RenderPageSizeSelect()
        {
            string templateCell = "<div class=\"{0}\"><div style=\"display: inline-block;\" class=\"{1}\">&nbsp;{2}&nbsp;</div><div style=\"display: inline-block;\"><select class=\"{3}\" name=\"{4}\" id=\"{5}\" onchange=\"javascript:Thrita_Web_UI_WebControls_Pager_HandlePageSizeChanged(this);\">{6}</select></div></div>";

            string listItemTemplate = "<option {0} value=\"{1}\">{2}</option>";

            StringBuilder sb = new StringBuilder();
            for (int i = this.PageSizeSelectStart; i <= this.MaximumPageSizeSelect; i += this.PageSizeSelectInterval)
            {
                sb.Append(string.Format(listItemTemplate, i == PageSize ? string.Format("selected=\"selected\" class=\"{0}\"", PageSizeSelectedOptionCSS) : "", Page.ClientScript.GetPostBackClientHyperlink(this, CommandName.PageSizeChanged.ToString() + "$" + i.ToString()), i));
            }
            return string.Format(templateCell, OtherPageCSS, PageSizeSelectLabelCSS, PageSizeSelectClause, PageSizeSelectCSS, PageSizeSelectUniqueID, PageSizeSelectUniqueID, sb.ToString());
        }

        private string RenderGoToScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"
                                function Thrita_Web_UI_WebControls_Pager_HandlePageSizeChanged(selectObj) {
                                    eval(selectObj.options[selectObj.selectedIndex].value);
                                }

                                function Thrita_Web_UI_WebControls_Pager_HandleGoto(selectObj) {
                                    eval(selectObj.options[selectObj.selectedIndex].value);
                                }
                                    
                                ");

            if (GeneratePageSizeSelect == true)
            {
                sb.Append(@"
                                function Thrita_Web_UI_WebControls_Pager_HandlePageSizeChanged(selectObj) {
                                    eval(selectObj.options[selectObj.selectedIndex].value);
                                }                        
                                ");
            }

            if (GenerateGoToSelect == GoToSelectionMode.Dynamic)
            {
                sb.Append(@"
                                function Thrita_Web_UI_WebControls_Pager_HandleGoToVisibility(gotoDiv, gotoImage) {
                                    var gotoElem = document.getElementById(gotoDiv);
                                    gotoElem.style.display = gotoElem.style.display == 'none' ? 'inline' : 'none';
                                    var gotoImg = document.getElementById(gotoImage);
                                    
                                ");


                //sb.AppendFormat("gotoImg.src = gotoElem.style.display == 'none' ? '{0}' : '{1}';",
                //                        Page.ClientScript.GetWebResourceUrl(this.GetType(), "Thrita.EmbeddedFiles.arr_right.gif"),
                //                        Page.ClientScript.GetWebResourceUrl(this.GetType(), "Thrita.EmbeddedFiles.arr_left.gif")
                //                        );
                sb.AppendFormat(" var newClass = gotoElem.style.display == 'none' ? '{0}' : '{1}';",
                            GoToArrowCollapsedCSS,
                            GoToArrowExpandedCSS
                            );
                sb.Append("gotoImg.setAttribute('class', newClass); }");
            }

            string goToScript = "<script type=\"text/javascript\">{0}</script>";

            return string.Format(goToScript, sb.ToString());
        }
        #endregion

        #region // Smart ShortCut Stuff

        private List<int> _smartShortCutList;
        private List<int> SmartShortCutList
        {
            get { return _smartShortCutList; }
            set { _smartShortCutList = value; }
        }

        private void CalculateSmartShortcutAndFillList()
        {
            _smartShortCutList = new List<int>();
            double shortCutCount = this.PageCount * SmartShortCutRatio / 100;
            double shortCutCountRounded = System.Math.Round(shortCutCount, 0);
            if (shortCutCountRounded > MaxSmartShortCutCount) shortCutCountRounded = MaxSmartShortCutCount;
            if (shortCutCountRounded == 1) shortCutCountRounded++;

            for (int i = 1; i < shortCutCountRounded + 1; i++)
            {
                int calculatedValue = (int)(System.Math.Round((this.PageCount * (100 / shortCutCountRounded) * i / 100) * 0.1, 0) * 10);
                if (calculatedValue >= this.PageCount) break;
                SmartShortCutList.Add(calculatedValue);
            }
        }

        /* smart shortcut list calculator and list */
        private void RenderSmartShortCutByCriteria(int basePageNumber, bool getRightBand, HtmlTextWriter writer)
        {
            if (IsSmartShortCutAvailable())
            {

                List<int> lstSSC = this.SmartShortCutList;

                int rVal = -1;
                if (getRightBand)
                {
                    for (int i = 0; i < lstSSC.Count; i++)
                    {
                        if (lstSSC[i] > basePageNumber)
                        {
                            rVal = i;
                            break;
                        }
                    }
                    if (rVal >= 0)
                    {
                        for (int i = rVal; i < lstSSC.Count; i++)
                        {
                            if (lstSSC[i] != basePageNumber)
                            {
                                writer.Write(RenderSSC(lstSSC[i]));
                            }
                        }
                    }
                }
                else if (!getRightBand)
                {

                    for (int i = 0; i < lstSSC.Count; i++)
                    {
                        if (basePageNumber > lstSSC[i])
                        {
                            rVal = i;
                        }
                    }

                    if (rVal >= 0)
                    {
                        for (int i = 0; i < rVal + 1; i++)
                        {
                            if (lstSSC[i] != basePageNumber)
                            {
                                writer.Write(RenderSSC(lstSSC[i]));
                            }
                        }
                    }
                }
            }
        }

        bool IsSmartShortCutAvailable()
        {
            return this.GenerateSmartShortCuts && this.SmartShortCutList != null && this.SmartShortCutList.Count != 0;
        }
        #endregion

        #region // Render "SearchEngineFriendly" hyperlinks in HiddenDiv
        private string RenderHiddenDiv()
        {
            System.Text.RegularExpressions.Regex regEx;
            Uri theURL = System.Web.HttpContext.Current.Request.Url;
            bool hasQueryStringParam = !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"]) ? true : false;
            string tempHyperlink = "<a href=\"{0}\">page {1}</a>";
            string tempDiv = "<div style=\"display:none;\">{0}</div>";
            StringBuilder sb = new StringBuilder();

            if (hasQueryStringParam && System.Web.HttpContext.Current.Request.QueryString[this.QueryStringParameterName] != null)
            {
                regEx = new Regex(this.QueryStringParameterName + @"\=\d*", RegexOptions.Compiled | RegexOptions.Singleline);
                for (int i = 0; i < this.NormalModePageCount; i++)
                {
                    sb.Append(string.Format(tempHyperlink,
                                regEx.Replace(theURL.ToString(), this.QueryStringParameterName + "=" + (i + this.CurrentIndex)), i + this.CurrentIndex)
                        );
                }
            }
            else
            {
                string qsParameterName = "";
                for (int i = 0; i < this.NormalModePageCount; i++)
                {
                    qsParameterName = string.Format("{0}={1}", this.QueryStringParameterName, i + this.CurrentIndex);
                    sb.Append(string.Format(tempHyperlink,
                                hasQueryStringParam ? theURL.ToString() + "&" + qsParameterName : theURL.ToString() + "?" + qsParameterName,
                                i + this.CurrentIndex)
                            );
                }

            }

            return string.Format(tempDiv, sb.ToString());
        }
        #endregion

        #region // Override Control's Render operation

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (Farschidus.BrowserValidator.IsEnabledClientScript(Context))
            {
                if (!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), PAGER_SCRIPT))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), PAGER_SCRIPT, RenderGoToScript());
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (ItemCount > 0)
            {
                if (Page != null) Page.VerifyRenderingInServerForm(this);

                if (this.PageCount > this.SmartShortCutThreshold && GenerateSmartShortCuts)
                {
                    CalculateSmartShortcutAndFillList();
                }

                //writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1");
                //writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "1");
                //writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                writer.AddAttribute(HtmlTextWriterAttribute.Class, ContainerTable);
                if (RTL) writer.AddAttribute(HtmlTextWriterAttribute.Dir, "rtl");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
                writer.RenderBeginTag(HtmlTextWriterTag.Ul);

                if (GeneratePagerInfoSection)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, InfoCellCSS);
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    writer.Write(PageClause + " " + CurrentIndex.ToString() + " " + OfClause + " " + PageCount.ToString());
                    writer.RenderEndTag();
                }

                if (GenerateFirstLastSection && CurrentIndex != 1)
                    writer.Write(RenderFirst());

                if (CurrentIndex != 1)
                    writer.Write(RenderBack());

                if (CurrentIndex < CompactModePageCount)
                {

                    if (CompactModePageCount > PageCount) CompactModePageCount = PageCount;

                    
                    for (int i = 1; i < CompactModePageCount + 1; i++)
                    {
                        if (i == CurrentIndex)
                        {
                            writer.Write(RenderCurrent());
                        }
                        else
                        {
                            writer.Write(RenderOther(i));
                        }
                    }

                    RenderSmartShortCutByCriteria(CompactModePageCount, true, writer);

                }
                else if (CurrentIndex >= CompactModePageCount && CurrentIndex < NormalModePageCount)
                {

                    if (NormalModePageCount > PageCount) NormalModePageCount = PageCount;

                    for (int i = 1; i < NormalModePageCount + 1; i++)
                    {
                        if (i == CurrentIndex)
                        {
                            writer.Write(RenderCurrent());
                        }
                        else
                        {
                            writer.Write(RenderOther(i));
                        }
                    }

                    RenderSmartShortCutByCriteria(NormalModePageCount, true, writer);

                }
                else if (CurrentIndex >= NormalModePageCount)
                {
                    int gapValue = NormalModePageCount / 2;
                    int leftBand = CurrentIndex - gapValue;
                    int rightBand = CurrentIndex + gapValue;


                    RenderSmartShortCutByCriteria(leftBand, false, writer);

                    for (int i = leftBand; (i < rightBand + 1) && i < PageCount + 1; i++)
                    {
                        if (i == CurrentIndex)
                        {
                            writer.Write(RenderCurrent());
                        }
                        else
                        {
                            writer.Write(RenderOther(i));
                        }
                    }

                    if (rightBand < this.PageCount)
                    {

                        RenderSmartShortCutByCriteria(rightBand, true, writer);
                    }
                }

                if (CurrentIndex != PageCount)
                    writer.Write(RenderNext());

                if (GenerateFirstLastSection && CurrentIndex != PageCount)
                    writer.Write(RenderLast());

                    writer.RenderEndTag();

                    writer.RenderEndTag();

                    //writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "1");
                    //writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "1");
                    //writer.AddAttribute(HtmlTextWriterAttribute.Border, "0");
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, GotoStaticAndPageSizeContainer);
                    if (RTL) writer.AddAttribute(HtmlTextWriterAttribute.Dir, "rtl");
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);
                    //writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                switch (GenerateGoToSelect)
                {
                    case GoToSelectionMode.None:
                        break;
                    case GoToSelectionMode.Dynamic:
                        writer.Write(RenderGoToDynamic());
                        break;
                    case GoToSelectionMode.Static:
                        writer.Write(RenderGoToStatic());
                        break;
                }

                if (GeneratePageSizeSelect)
                    writer.Write(RenderPageSizeSelect());

                writer.RenderEndTag();


                if (GenerateGoToSelect == GoToSelectionMode.Dynamic || GenerateGoToSelect == GoToSelectionMode.Static)
                    writer.Write(RenderGoToScript());

                if (GenerateHiddenHyperlinks)
                    writer.Write(RenderHiddenDiv());
            }
        }
        #endregion
    }

    public class PagerPageIndexChangeEventArgs : EventArgs
    {
        private int pageIndex;
        public int PageIndex
        {
            get
            {
                return pageIndex;
            }
        }

        //private static string tableRowsArray;

        public PagerPageIndexChangeEventArgs(int pageIndex)
        {
            this.pageIndex = pageIndex;
        }
    }

    public class PagerPageSizeChangeEventArgs : EventArgs
    {
        public static string COMMAND_NAME = "PageChanged";

        private int pageSize;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
        }

        //private static string tableRowsArray;

        public PagerPageSizeChangeEventArgs(int pageSize)
        {
            this.pageSize = pageSize;
        }
    }

    public enum CommandName
    {
        PageIndexChanged = 1,
        PageSizeChanged
    }

    public enum GoToSelectionMode
    {
        None,
        Dynamic,
        Static
    }
}