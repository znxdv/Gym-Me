<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionQueue.aspx.cs" Inherits="Final_Project.View.TransactionQueue" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/TransactionQueuePage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="content-container">
        <asp:Panel ID="transaction_list" runat="server">
            <asp:GridView ID="GridView" runat="server" OnRowUpdating="GridView_RowUpdating" AutoGenerateColumns="False" CssClass="grid-view">

                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID">
                    </asp:BoundField>
                    <asp:BoundField DataField="UserID" HeaderText="User ID" SortExpression="UserID">
                    </asp:BoundField>
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" DataFormatString="{0:d MMMM yyyy}" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:ButtonField ButtonType="Button" CommandName="Update" HeaderText="Action" ShowHeader="True" Text="Handle" />
                </Columns>

            </asp:GridView>
          </asp:Panel>
    </div>

</asp:Content>
