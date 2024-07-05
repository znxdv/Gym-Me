<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="OrderSupplement.aspx.cs" Inherits="Final_Project.View.Order_Supplement" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/OrderSupplementPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="content-container">
        <asp:Panel ID="supplementType_list" runat="server">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="SupplementTypeID" AutoGenerateColumns="False" CssClass="grid-view">

                <Columns>
                    <asp:BoundField DataField="SupplementTypeID" HeaderText="ID" SortExpression="SupplementTypeID" />
                    <asp:BoundField DataField="SupplementTypeName" HeaderText="Type Name" SortExpression="SupplementTypeName" />
                </Columns>

            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="supplement_list" runat="server">
            <asp:GridView ID="GridView2" runat="server" DataKeyNames="SupplementID" AutoGenerateColumns="False" CssClass="grid-view">
                <Columns>
                    <asp:BoundField DataField="SupplementID" HeaderText="ID" SortExpression="SupplementID" Visible="false" ItemStyle-CssClass="center-column" />
                    <asp:BoundField DataField="SupplementName" HeaderText="Name" SortExpression="SupplementName" />
                    <asp:BoundField DataField="SupplementExpiryDate" HeaderText="Expiry Date" SortExpression="SupplementExpiryDate" DataFormatString="{0: d MMMM yyyy}" />
                    <asp:BoundField DataField="SupplementPrice" HeaderText="Price" SortExpression="SupplementPrice" />
                    <asp:BoundField DataField="SupplementTypeID" HeaderText="Type ID" SortExpression="SupplementTypeID" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="QuantityTextBox" runat="server" CssClass="tb" Visible="true"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="Lbl_status" CssClass="success" runat="server" Text=""></asp:Label>
            <asp:Button ID="Btn_clear" runat="server" Text="Clear Cart" OnClick="Btn_clear_Click" />
            <asp:Button ID="Btn_add" runat="server" Text="Add to Cart" onclick="Btn_addToCart_Click"/>
            <asp:Button ID="Btn_order" runat="server" Text="Order" OnClick="Btn_order_Click" />
        </asp:Panel>

    </div>

</asp:Content>
