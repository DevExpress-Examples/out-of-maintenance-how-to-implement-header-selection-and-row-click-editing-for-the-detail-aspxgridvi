<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxe" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to implement header selection and row click editing for the detail ASPxGridView</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dxwgv:ASPxGridView ID="masgrid" runat="server" AutoGenerateColumns="False" DataSourceID="masds"
				KeyFieldName="CategoryID" Width="740px">
				<Templates>
					<DetailRow>
						<dxwgv:ASPxGridView ID="detgrid" runat="server" AutoGenerateColumns="False" DataSourceID="detds"
							KeyFieldName="ProductID" OnBeforePerformDataSelect="detgrid_BeforePerformDataSelect"
							OnInit="detgrid_Init">
							<Columns>
								<dxwgv:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
									<HeaderTemplate>
										<dxe:ASPxCheckBox ID="chk" runat="server" OnInit="chk_Init">
										</dxe:ASPxCheckBox>
									</HeaderTemplate>
								</dxwgv:GridViewCommandColumn>
								<dxwgv:GridViewDataTextColumn FieldName="ProductID" ReadOnly="True" VisibleIndex="1">
									<EditFormSettings Visible="False" />
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="ProductName" VisibleIndex="2">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="SupplierID" VisibleIndex="3">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="CategoryID" VisibleIndex="4">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="QuantityPerUnit" VisibleIndex="5">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="UnitPrice" VisibleIndex="6">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="UnitsInStock" VisibleIndex="7">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="UnitsOnOrder" VisibleIndex="8">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataTextColumn FieldName="ReorderLevel" VisibleIndex="9">
								</dxwgv:GridViewDataTextColumn>
								<dxwgv:GridViewDataCheckColumn FieldName="Discontinued" VisibleIndex="10">
								</dxwgv:GridViewDataCheckColumn>
								<dxwgv:GridViewDataTextColumn FieldName="EAN13" VisibleIndex="11">
								</dxwgv:GridViewDataTextColumn>
							</Columns>
							<SettingsDetail IsDetailGrid="True" />
						</dxwgv:ASPxGridView>
					</DetailRow>
				</Templates>
				<Columns>
					<dxwgv:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
						<EditFormSettings Visible="False" />
					</dxwgv:GridViewDataTextColumn>
					<dxwgv:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
					</dxwgv:GridViewDataTextColumn>
					<dxwgv:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
					</dxwgv:GridViewDataTextColumn>
				</Columns>
				<SettingsDetail ShowDetailRow="True" />
			</dxwgv:ASPxGridView>
			&nbsp;
			<asp:AccessDataSource ID="masds" runat="server" DataFile="~/App_Data/nwind.mdb" SelectCommand="SELECT * FROM [Categories]">
			</asp:AccessDataSource>
			<asp:AccessDataSource ID="detds" runat="server" DataFile="~/App_Data/nwind.mdb" DeleteCommand="DELETE FROM [Products] WHERE [ProductID] = ?"
				InsertCommand="INSERT INTO [Products] ([ProductID], [ProductName], [SupplierID], [CategoryID], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [UnitsOnOrder], [ReorderLevel], [Discontinued], [EAN13]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
				SelectCommand="SELECT * FROM [Products] WHERE ([CategoryID] = ?)" UpdateCommand="UPDATE [Products] SET [ProductName] = ?, [SupplierID] = ?, [CategoryID] = ?, [QuantityPerUnit] = ?, [UnitPrice] = ?, [UnitsInStock] = ?, [UnitsOnOrder] = ?, [ReorderLevel] = ?, [Discontinued] = ?, [EAN13] = ? WHERE [ProductID] = ?" OnDeleting="detds_updating" OnInserting="detds_updating" OnUpdating="detds_updating">
				<SelectParameters>
					<asp:SessionParameter DefaultValue="-1" Name="CategoryID" SessionField="CategoryID"
						Type="Int32" />
				</SelectParameters>
				<DeleteParameters>
					<asp:Parameter Name="ProductID" Type="Int32" />
				</DeleteParameters>
				<UpdateParameters>
					<asp:Parameter Name="ProductName" Type="String" />
					<asp:Parameter Name="SupplierID" Type="Int32" />
					<asp:Parameter Name="CategoryID" Type="Int32" />
					<asp:Parameter Name="QuantityPerUnit" Type="String" />
					<asp:Parameter Name="UnitPrice" Type="Decimal" />
					<asp:Parameter Name="UnitsInStock" Type="Int16" />
					<asp:Parameter Name="UnitsOnOrder" Type="Int16" />
					<asp:Parameter Name="ReorderLevel" Type="Int16" />
					<asp:Parameter Name="Discontinued" Type="Boolean" />
					<asp:Parameter Name="EAN13" Type="String" />
					<asp:Parameter Name="ProductID" Type="Int32" />
				</UpdateParameters>
				<InsertParameters>
					<asp:Parameter Name="ProductID" Type="Int32" />
					<asp:Parameter Name="ProductName" Type="String" />
					<asp:Parameter Name="SupplierID" Type="Int32" />
					<asp:Parameter Name="CategoryID" Type="Int32" />
					<asp:Parameter Name="QuantityPerUnit" Type="String" />
					<asp:Parameter Name="UnitPrice" Type="Decimal" />
					<asp:Parameter Name="UnitsInStock" Type="Int16" />
					<asp:Parameter Name="UnitsOnOrder" Type="Int16" />
					<asp:Parameter Name="ReorderLevel" Type="Int16" />
					<asp:Parameter Name="Discontinued" Type="Boolean" />
					<asp:Parameter Name="EAN13" Type="String" />
				</InsertParameters>
			</asp:AccessDataSource>
		</div>
	</form>
</body>
</html>