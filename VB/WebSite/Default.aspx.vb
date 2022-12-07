Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub detgrid_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		Session("CategoryID") = (CType(sender, ASPxGridView)).GetMasterRowKeyValue()
	End Sub

	Protected Sub chk_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim checkBox As ASPxCheckBox = CType(sender, ASPxCheckBox)
		Dim container As GridViewHeaderTemplateContainer = TryCast(checkBox.NamingContainer, GridViewHeaderTemplateContainer)
		Dim grid As ASPxGridView = container.Grid

		checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s,e) {{if(s.GetChecked()) {0}.SelectAllRowsOnPage(); else {0}.UnselectAllRowsOnPage();}}", grid.ClientInstanceName)
		checkBox.ClientInstanceName = String.Format("chk_{0}", grid.ClientInstanceName)

		Dim cbChecked As Boolean = True
		Dim start As Int32 = grid.VisibleStartIndex
		Dim [end] As Int32 = grid.VisibleStartIndex + grid.SettingsPager.PageSize
		If [end] > grid.VisibleRowCount Then
			[end] = (grid.VisibleRowCount)
		Else
			[end] = ([end])
		End If

		For i As Integer = start To [end] - 1
			If (Not grid.Selection.IsRowSelected(i)) Then
				cbChecked = False
				Exit For
			End If
		Next i

		checkBox.Checked = cbChecked
	End Sub

	Protected Sub detgrid_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim grid As ASPxGridView = CType(sender, ASPxGridView)
		Dim container As GridViewDetailRowTemplateContainer = TryCast(grid.NamingContainer, GridViewDetailRowTemplateContainer)

		grid.ClientInstanceName = String.Format("detail_{0}", container.KeyValue)
		grid.ClientSideEvents.RowDblClick = String.Format("function(s,e){{ {0}.StartEditRow(e.visibleIndex); }}", grid.ClientInstanceName)

		grid.ClientSideEvents.SelectionChanged = String.Format("function (s, e) {{ {0}.SetChecked(s.GetSelectedKeysOnPage().length == s.GetVisibleRowsOnPage()); }}", String.Format("chk_{0}", grid.ClientInstanceName))
	End Sub

	Protected Sub detds_updating(ByVal sender As Object, ByVal e As SqlDataSourceCommandEventArgs)
		e.Cancel = True ' for demo purposes only
	End Sub
End Class
