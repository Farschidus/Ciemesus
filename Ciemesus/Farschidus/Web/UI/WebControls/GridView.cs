using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Drawing;

namespace Farschidus.Web.UI.WebControls
{
    [ToolboxData("<{0}:GridView runat=server></{0}:GridView>")]
    [ToolboxBitmap(typeof(GridView), "GridView.bmp")]
    public class GridView : System.Web.UI.WebControls.GridView, IPostBackEventHandler
    {
        private const string TableDnD_Embeded_SCRIPT = "200306D7-7B17-40A9-B04E-0FB7A2D1E989";

        private string DragCssClass;
        private string ShowDragHandleCSS;
        private bool enableReordering = false;
        private bool enableCheckbox = false;
        public override DataControlFieldCollection Columns
        {
            get
            {
                return base.Columns;
            }
        }

        private void InstantiateTableOddRowColorScript()
        {
            StringBuilder sb_Script = new StringBuilder();
            sb_Script.Append("<script language=\"javascript\">");
            sb_Script.Append("$(document).ready(function () {");
            sb_Script.Append("\r");
            sb_Script.Append("$('#" + this.ClientID + " tr:odd').addClass('odd');");
            sb_Script.Append("\r");
            sb_Script.Append("});");
            sb_Script.Append("\r");
            sb_Script.Append("</script>");

            Page.ClientScript.RegisterClientScriptBlock(GetType(), Guid.NewGuid().ToString(), sb_Script.ToString());
        }
        private void InstantiateTableDnDScript()
        {
            StringBuilder sb_Script = new StringBuilder();
            sb_Script.Append("\r");
            sb_Script.Append("<script language=\"javascript\">");
            sb_Script.Append("\r");
            sb_Script.Append("$(document).ready(function () {");
            sb_Script.Append("\r");
            sb_Script.Append("initTableDnDFor" + this.ID + "();");
            sb_Script.Append("\r");
            sb_Script.Append("});");
            sb_Script.Append("\r");

            sb_Script.Append("function initTableDnDFor" + this.ID + "()");
            sb_Script.Append("{");
            sb_Script.Append("\r");
            sb_Script.Append("var dragID;");
            sb_Script.Append("$('#" + this.ClientID + "').tableDnD( {");
            sb_Script.Append("onDrop: function(table, row) {");
            sb_Script.Append("$('#" + this.ClientID + " tr').removeClass('odd');");
            sb_Script.Append("$('#" + this.ClientID + " tr:odd').addClass('odd');");
            sb_Script.Append("var rows = table.tBodies[0].rows;");
            sb_Script.Append("var count = '';");
            sb_Script.Append("var rowIds = new Array();");
            sb_Script.Append("for (var i=0; i<rows.length; i++) {");
            //sb_Script.Append("count += rows[i].id + '/';");
            sb_Script.Append("rowIds[i] = rows[i].id.split('$')[1];");
            sb_Script.Append("}");
            sb_Script.Append("if(dragID != rowIds[dragID-1])");
            sb_Script.Append("{");
            sb_Script.Append("__doPostBack('" + this.UniqueID + "', 'Drag$' + dragID.toString()  + rowIds.join(','));");
            sb_Script.Append("}");
            sb_Script.Append("},");
            sb_Script.Append("\r");
            sb_Script.Append("dragHandle: '" + DragCssClass + "',");
            sb_Script.Append("\r");
            sb_Script.Append("onDragStart: function (table, row) {");
            sb_Script.Append("\r");
            sb_Script.Append("dragID = row.parentNode.id.split('$')[1];");
            sb_Script.Append("\r");
            sb_Script.Append("}");
            sb_Script.Append("\r");
            sb_Script.Append("});");
            sb_Script.Append("\r");
            sb_Script.Append("$('#" + this.ClientID + " tr').hover(function () {");
            sb_Script.Append("\r");
            sb_Script.Append("$(this.cells[0]).addClass('" + ShowDragHandleCSS + "')");
            sb_Script.Append("\r");
            sb_Script.Append("}, function () {");
            sb_Script.Append("\r");
            sb_Script.Append("$(this.cells[0]).removeClass('" + ShowDragHandleCSS + "');");
            sb_Script.Append("\r");
            sb_Script.Append("});");
            sb_Script.Append("\r");
            sb_Script.Append("$('#" + this.ClientID + " th').parent('tr').addClass('nodrop nodrag');");
            sb_Script.Append("\r");
            sb_Script.Append("}");
            sb_Script.Append("\r");

            sb_Script.Append("</script>");

            Page.ClientScript.RegisterClientScriptBlock(GetType(), Guid.NewGuid().ToString(), sb_Script.ToString());
        }
        private void InstantiateCheckAllScript()
        {
            StringBuilder sb_Script = new StringBuilder();
            sb_Script.Append("<script language=\"javascript\">");
            sb_Script.Append("\r");
            sb_Script.Append("$(document).on('change', '#" + this.ClientID + " input.check-all', function () {");
            sb_Script.Append("\r");
            sb_Script.Append("$('#" + this.ClientID + "').find('td input:checkbox').prop('checked', $(this).is(':checked'));");
            sb_Script.Append("\r");
            sb_Script.Append("});");
            sb_Script.Append("</script>");

            Page.ClientScript.RegisterClientScriptBlock(GetType(), Guid.NewGuid().ToString(), sb_Script.ToString());
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (Farschidus.BrowserValidator.IsEnabledClientScript(Context))
            {
                foreach (DataControlField dcf in Columns)
                {
                    if (dcf.GetType().ToString().Equals(typeof(CheckAllBoxField).ToString()))
                    {
                        enableCheckbox = true;
                    }
                    if (dcf.GetType().ToString().Equals(typeof(DragField).ToString()))
                    {
                        this.ShowDragHandleCSS = ((DragField)(dcf)).ShowDragHandleCSS;
                        this.DragCssClass = ((DragField)(dcf)).DragCssClass;
                        enableReordering = true;
                    }
                }

                this.InstantiateTableOddRowColorScript();

                if (enableReordering)
                {
                    
                    if (!Page.ClientScript.IsClientScriptIncludeRegistered(GetType(), TableDnD_Embeded_SCRIPT))
                    {
                        Page.ClientScript.RegisterClientScriptInclude(GetType(), TableDnD_Embeded_SCRIPT, Page.ClientScript.GetWebResourceUrl(GetType(), "Farschidus.EmbeddedFiles.TableDnD.js"));
                    }

                    this.InstantiateTableDnDScript();
                }

                if (enableCheckbox)
                {
                    this.InstantiateCheckAllScript();
                }
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (enableReordering)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), Guid.NewGuid().ToString(), "Sys.WebForms.PageRequestManager.getInstance().add_endRequest(initTableDnDFor" + this.ID + ");", true);
            }
            base.Render(writer);
        }
        protected override void PrepareControlHierarchy()
        {
            base.PrepareControlHierarchy();
            if (enableReordering)
            {
                for (int i = 0; i < Rows.Count; i++)
                {
                    if (Rows[i].RowType == DataControlRowType.DataRow)
                    {
                        string argsData = "Drag$" + Rows[i].RowIndex.ToString();
                        this.Rows[i].Attributes.Add("id", argsData);
                    }
                }
            }
        }

        #region // PostBack Stuff
        // Defines a key for storing the delegate for the RowDraged event in the Events list.
        private static readonly object RowDragedEvent = new object();

        public delegate void GridViewRowDragedEventHandler(Object sender, GridViewRowDragedEventArgs e);

        // Defines the RowDraged event using the event property syntax.
        // The Events property stores all the event delegates of a control as name/value pairs. 
        [Description("Fires after the Drag Command is executed on the data source")]
        [Bindable(true)]
        [Category("Action")]
        public event GridViewRowDragedEventHandler RowDraged
        {
            // When a user attaches an event handler to the RowDraged event (RowDraged += myHandler;), 
            // the Add method adds the handler to the delegate for the RowDraged event (keyed by RowDragedEvent in the Events list).
            add
            {
                Events.AddHandler(RowDragedEvent, value);
            }
            // When a user removes an event handler from the RowDraged event (RowDraged -= myHandler;), 
            // the Remove method removes the handler from the delegate for the RowDraged event (keyed by RowDragedEvent in the Events list).
            remove
            {
                Events.RemoveHandler(RowDragedEvent, value);
            }
        }

        // Invokes delegates registered with the RowDraged event.
        protected virtual void OnRowDraged(GridViewRowDragedEventArgs e)
        {
            // Retrieves the event delegate for the RowDraged event from the Events property 
            // (which stores the control's event delegates). 
            // You must cast the retrieved delegate to the type of your event delegate.
            GridViewRowDragedEventHandler rowDragedEventDelegate = (GridViewRowDragedEventHandler)Events[RowDragedEvent];
            if (rowDragedEventDelegate != null)
            {
                rowDragedEventDelegate(this, e);
            }
        }

        // Method of IPostBackEventHandler that raises change events.
        protected override void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.Contains("Drag"))
                OnRowDraged(new GridViewRowDragedEventArgs(eventArgument));
            else
                base.RaisePostBackEvent(eventArgument);
        }
        #endregion
    }

    public class GridViewRowDragedEventArgs : EventArgs
    {
        private string commandName;
        public string ComandName
        {
            get
            {
                return commandName;
            }
        }

        private int dragedRowIndex;
        public int DragedRowIndex
        {
            get
            {
                return dragedRowIndex;
            }
        }

        private DragStatus status;
        public DragStatus Status
        {
            get
            {
                return status;
            }
        }

        private int targetRowIndex;
        public int TargetRowIndex
        {
            get
            {
                return targetRowIndex;
            }
        }

        public GridViewRowDragedEventArgs(string eventArgument)
        {
            string[] args = eventArgument.Split('$');
            this.commandName = args[0].Trim();
            this.dragedRowIndex = int.Parse(args[1].Split(',')[0]);

            mFillStatusAndTargetID(args[1]);
        }

        private void mFillStatusAndTargetID(string args)
        {
            args = args.Substring(args.IndexOf(',') + 1);
            List<string> listArgs = new List<string>(args.Split(','));
            this.targetRowIndex = listArgs.FindIndex(delegate (string e)
                           {
                               return e.Equals(dragedRowIndex.ToString());
                           }
                       );
            if (this.dragedRowIndex > this.targetRowIndex)
            {
                this.status = DragStatus.Befor;
            }
            else if (this.dragedRowIndex < this.targetRowIndex)
            {
                this.status = DragStatus.After;
            }
        }
    }

    public enum DragStatus
    {
        Befor = 0,
        After = 1
    }

    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class CheckAllBoxField : CheckBoxField
    {
        public override string HeaderText
        {
            get
            {
                return "<input id=\"CheckAllboxHeader\" type=\"checkbox\" class=\"check-all\" />";
            }
        }

        public override string Text
        {
            get
            {
                return string.Empty;
            }
        }

        [DefaultValue("")]
        [Description("Specifies the Checkbox Value")]
        [Bindable(true)]
        [Category("Thrita")]
        public string Value
        {
            get
            {
                object ID = (String)ViewState["Value"];
                return (ID == null) ? "" : (String)ID;
            }
            set
            {
                ViewState["Value"] = value;
            }
        }

        [DefaultValue("CheckAllBoxFieldID")]
        [Description("Specifies the Checkbox ID")]
        [Bindable(true)]
        [Category("Thrita")]
        public string ID
        {
            get
            {
                object ID = (String)ViewState["ID"];
                return (ID == null) ? "CheckAllBoxFieldID" : (String)ID;
            }
            set
            {
                ViewState["ID"] = value;
            }
        }

        public CheckAllBoxField()
        {
        }

        // Gets a default value for a basic design-time experience. 
        // Since it would look odd, even at design time, to have 
        // more than one CheckBox selected, make sure that none
        // are selected.
        protected override object GetDesignTimeValue()
        {
            return false;
        }

        protected override object GetValue(Control controlContainer)
        {
            return true;
        }

        // This method is called by the ExtractRowValues methods of 
        // GridView and DetailsView. Retrieve the current value of the 
        // cell from the Checked state of the CheckBox.
        public override void ExtractValuesFromCell(IOrderedDictionary dictionary, DataControlFieldCell cell,
                                                   DataControlRowState rowState, bool includeReadOnly)
        {
            // Determine whether the cell contains a CheckBox 
            // in its Controls collection.
            if (cell.Controls.Count > 0)
            {
                CheckBox checkBox = cell.Controls[0] as CheckBox;

                object checkedValue = null;
                if (null == checkBox)
                {
                    // A CheckBox is expected, but a null is encountered.
                    // Add error handling.
                    throw new InvalidOperationException
                        ("CheckAllBoxField could not extract control.");
                }
                else
                {
                    checkedValue = checkBox.Checked;
                }


                // Add the value of the Checked attribute of the
                // CheckBox to the dictionary.
                if (dictionary.Contains(DataField))
                    dictionary[DataField] = checkedValue;
                else
                    dictionary.Add(DataField, checkedValue);
            }
        }

        // This method adds a CheckBox control and any other 
        // content to the cell's Controls collection.
        protected override void InitializeDataCell
            (DataControlFieldCell cell, DataControlRowState rowState)
        {

            CheckBox checkBox = new CheckBox();

            // If the CheckBox is bound to a DataField, add
            // the OnDataBindingField method event handler to the
            // DataBinding event.
            if (DataField.Length != 0)
            {
                checkBox.DataBinding += new EventHandler(this.OnDataBindField);
            }

            //checkBox.CssClass = "checkbox";    Didn't Work????????????????????

            // Because the CheckAllBoxField is a BoundField, it only
            // displays data. Therefore, unless the row is in edit mode,
            // the CheckBox is displayed as disabled.
            checkBox.Enabled = true;
            checkBox.ID = this.ID;
            // If the row is in edit mode, enable the button.
            //if ((rowState & DataControlRowState.Edit) == 0 ||
            //    (rowState & DataControlRowState.Insert) == 0)
            //{
            //    checkBox.Enabled = false;
            //}
            //else
            //{
            //    checkBox.Enabled = true;
            //}

            cell.Controls.Add(checkBox);
        }
    }

    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    public sealed class DragField : DataControlField
    {
        [DefaultValue("dragHandler")]
        [Description("Specifies the CssClass Name of Drag Handler")]
        [Bindable(true)]
        [Category("Thrita")]
        public string DragCssClass
        {
            get
            {
                object dragCssClass = (String)ViewState["DragCssClass"];
                return (dragCssClass == null) ? "dragHandler" : (String)dragCssClass;
            }
            set
            {
                ViewState["DragCssClass"] = value;
            }
        }

        [DefaultValue("showDragHandle")]
        [Description("Specifies the CssClass Name of MouseHover for Drag Handler")]
        [Bindable(true)]
        [Category("Thrita")]
        public string ShowDragHandleCSS
        {
            get
            {
                object showDragHandleCSS = (String)ViewState["showDragHandleCSS"];
                return (showDragHandleCSS == null) ? "showDragHandle" : (String)showDragHandleCSS;
            }
            set
            {
                ViewState["showDragHandleCSS"] = value;
            }
        }



        public DragField()
        {
        }

        protected override DataControlField CreateField()
        {
            throw new NotImplementedException();
        }

        // This method adds a Span and any other 
        // content to the cell's Controls collection.
        public override void InitializeCell(DataControlFieldCell cell, DataControlCellType cellType, DataControlRowState rowState, int rowIndex)
        {
            System.Web.UI.HtmlControls.HtmlGenericControl span = new System.Web.UI.HtmlControls.HtmlGenericControl("span");

            span.InnerHtml = "&nbsp;&nbsp;";
            cell.CssClass = this.DragCssClass;
            //cell.Attributes.Add("onclick", "test");
            cell.Controls.Add(span);
        }
    }
}