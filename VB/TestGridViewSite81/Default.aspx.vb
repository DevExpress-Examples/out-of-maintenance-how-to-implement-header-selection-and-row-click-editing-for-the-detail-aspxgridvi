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
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub ASPxGridView2_BeforePerformDataSelect(ByVal sender As Object, ByVal e As EventArgs)
		Session("CategoryID") = (CType(sender, ASPxGridView)).GetMasterRowKeyValue()
	End Sub
	Protected Sub ASPxGridView1_HtmlRowCreated(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
		If e.RowType = GridViewRowType.Detail Then
			Dim masterGridView As ASPxGridView = CType(sender, ASPxGridView)
			Dim gridView As ASPxGridView = CType(masterGridView.FindDetailRowTemplateControl(e.VisibleIndex, "ASPxGridView2"), ASPxGridView)
			gridView.ClientInstanceName = "detail_" & e.VisibleIndex
			gridView.ClientSideEvents.RowDblClick = String.Format("function(s,e){{ {0}.StartEditRow(e.visibleIndex); }}", gridView.ClientInstanceName)
			' selection
			Dim column As GridViewCommandColumn = Nothing
			For i As Integer = 0 To gridView.VisibleColumns.Count - 1
				If TypeOf gridView.VisibleColumns(i) Is GridViewCommandColumn Then
					column = CType(gridView.VisibleColumns(i), GridViewCommandColumn)
					Exit For
				End If
			Next i
			If column Is Nothing Then
				Return
			End If
			Dim checkBox As ASPxCheckBox = CType(gridView.FindHeaderTemplateControl(column, "ASPxCheckBox1"), ASPxCheckBox)
			checkBox.ClientSideEvents.CheckedChanged = String.Format("function(s,e) {{if(s.GetChecked()) {0}.SelectAllRowsOnPage(); else {0}.UnselectAllRowsOnPage();}}", gridView.ClientInstanceName)
		End If
	End Sub
End Class
