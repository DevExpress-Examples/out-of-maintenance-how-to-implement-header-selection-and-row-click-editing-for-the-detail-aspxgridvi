using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ASPxGridView2_BeforePerformDataSelect(object sender, EventArgs e) {
        Session["CategoryID"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }
    protected void ASPxGridView1_HtmlRowCreated(object sender, ASPxGridViewTableRowEventArgs e) {
        if (e.RowType == GridViewRowType.Detail) {
            ASPxGridView masterGridView = (ASPxGridView)sender;
            ASPxGridView gridView = (ASPxGridView)masterGridView.FindDetailRowTemplateControl(e.VisibleIndex, "ASPxGridView2");
            gridView.ClientInstanceName = "detail_" + e.VisibleIndex;
            gridView.ClientSideEvents.RowDblClick = string.Format("function(s,e){{ {0}.StartEditRow(e.visibleIndex); }}", gridView.ClientInstanceName);
            // selection
            GridViewCommandColumn column = null;
            for (int i = 0; i < gridView.VisibleColumns.Count; i++)
                if (gridView.VisibleColumns[i] is GridViewCommandColumn) {
                    column = (GridViewCommandColumn)gridView.VisibleColumns[i];
                    break;
                }
            if (column == null)
                return;
            ASPxCheckBox checkBox = (ASPxCheckBox)gridView.FindHeaderTemplateControl(column, "ASPxCheckBox1");
            checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s,e) {{if(s.GetChecked()) {0}.SelectAllRowsOnPage(); else {0}.UnselectAllRowsOnPage();}}", gridView.ClientInstanceName);
        }
    }
}
