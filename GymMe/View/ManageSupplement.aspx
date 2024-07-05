<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="ManageSupplement.aspx.cs" Inherits="Final_Project.View.ManageSupplement" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ManageSupplementPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="content-container">
            <asp:Panel ID="supplement_list" runat="server">
    <asp:GridView ID="GridView" runat="server" CssClass="grid-view" OnRowEditing="GridView_RowEditing" OnRowDeleting="GridView_RowDeleting" AutoGenerateColumns="False">

        <Columns>
            <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID"/>
            <asp:BoundField DataField="SupplementName" HeaderText="Supplement Name" SortExpression="SupplementName" />
            <asp:BoundField DataField="SupplementExpiryDate" DataFormatString="{0: d MMMM yyyy}" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" />
            <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
            <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True"/>
        </Columns>
        
    </asp:GridView>
</asp:Panel>
    <asp:Button ID="ButtonInsert" runat="server" Text="Insert Supplement" OnClick="ButtonInsert_Click" CssClass="button" />
    </div>
</asp:Content>
