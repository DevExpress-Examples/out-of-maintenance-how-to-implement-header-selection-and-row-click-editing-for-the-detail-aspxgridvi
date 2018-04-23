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

public partial class _Default : System.Web.UI.Page {
    protected void detgrid_BeforePerformDataSelect(object sender, EventArgs e) {
        Session["CategoryID"] = ((ASPxGridView)sender).GetMasterRowKeyValue();
    }

    protected void chk_Init(object sender, EventArgs e) {
        ASPxCheckBox checkBox = (ASPxCheckBox)sender;
        GridViewHeaderTemplateContainer container = checkBox.NamingContainer as GridViewHeaderTemplateContainer;
        ASPxGridView grid = container.Grid;

        checkBox.ClientSideEvents.CheckedChanged = string.Format("function(s,e) {{if(s.GetChecked()) {0}.SelectAllRowsOnPage(); else {0}.UnselectAllRowsOnPage();}}", grid.ClientInstanceName);
        checkBox.ClientInstanceName = String.Format("chk_{0}", grid.ClientInstanceName);

        Boolean cbChecked = true;
        Int32 start = grid.VisibleStartIndex;
        Int32 end = grid.VisibleStartIndex + grid.SettingsPager.PageSize;
        end = (end > grid.VisibleRowCount ? grid.VisibleRowCount : end);

        for (int i = start; i < end; i++)
            if (!grid.Selection.IsRowSelected(i)) {
                cbChecked = false;
                break;
            }

        checkBox.Checked = cbChecked;
    }

    protected void detgrid_Init(object sender, EventArgs e) {
        ASPxGridView grid = (ASPxGridView)sender;
        GridViewDetailRowTemplateContainer container = grid.NamingContainer as GridViewDetailRowTemplateContainer;

        grid.ClientInstanceName = String.Format("detail_{0}", container.KeyValue);
        grid.ClientSideEvents.RowDblClick = string.Format("function(s,e){{ {0}.StartEditRow(e.visibleIndex); }}", grid.ClientInstanceName);

        grid.ClientSideEvents.SelectionChanged = String.Format("function (s, e) {{ {0}.SetChecked(s.GetSelectedKeysOnPage().length == s.GetVisibleRowsOnPage()); }}",
            String.Format("chk_{0}", grid.ClientInstanceName));
    }

    protected void detds_updating(object sender, SqlDataSourceCommandEventArgs e) {
        e.Cancel = true; // for demo purposes only
    }
}
