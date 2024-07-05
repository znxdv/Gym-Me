<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="Final_Project.View.History" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/HistoryPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="content-container">
        <asp:Panel ID="transaction_list" runat="server">
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" cssClass="grid-view">

                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" ItemStyle-CssClass="center-column" />
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID" ItemStyle-CssClass="center-column" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" ItemStyle-CssClass="center-column" DataFormatString="{0:d MMMM yyyy}" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Action" ShowHeader="True" Text="Detail" />
                </Columns>

            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
