<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication4._Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxe:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" AutoPostBack="True"
            SelectedIndex="0">
            <Items>
                <dxe:ListEditItem Text="PercentOfRow" Value="PercentOfRow" />
                <dxe:ListEditItem Text="PercentOfColumn" Value="PercentOfColumn" />
            </Items>
        </dxe:ASPxRadioButtonList>
        <dxwpg:aspxpivotgrid id="ASPxPivotGrid1" runat="server" DataSourceID="AccessDataSource1" OnCustomCellDisplayText="ASPxPivotGrid1_CustomCellDisplayText">
            <OptionsPager RowsPerPage="20">
            </OptionsPager>
            <OptionsLoadingPanel Text="Loading&amp;hellip;">
            </OptionsLoadingPanel>
            <Fields>
                <dxwpg:PivotGridField Area="RowArea" AreaIndex="0" FieldName="Sales_Person">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField Area="DataArea" AreaIndex="0" FieldName="Quantity">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField Area="ColumnArea" AreaIndex="0" FieldName="CategoryName">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField Area="DataArea" AreaIndex="1" Caption="Percent" FieldName="Custom">
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField Area="FilterArea" AreaIndex="0" Caption="Year" FieldName="OrderDate"
                    GroupInterval="DateYear">
                </dxwpg:PivotGridField>
            </Fields>
        </dxwpg:aspxpivotgrid>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [Sales Person] AS Sales_Person, [Quantity], [CategoryName], [ProductName], [Country], [OrderDate] FROM [SalesPerson]">
        </asp:AccessDataSource>
    
    </div>
    </form>
</body>
</html>
