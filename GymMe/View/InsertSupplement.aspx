<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="InsertSupplement.aspx.cs" Inherits="Final_Project.View.InsertSupplement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="InsertSupplement-Page-Container">
        <asp:Panel ID="supplementType_list" runat="server">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="SupplementTypeID" AutoGenerateColumns="False">

                <Columns>
                    <asp:BoundField DataField="SupplementTypeID" HeaderText="ID" SortExpression="SupplementTypeID" />
                    <asp:BoundField DataField="SupplementTypeName" HeaderText="Type Name" SortExpression="SupplementTypeName" />
                </Columns>

            </asp:GridView>
        </asp:Panel>
        <div class="InsertSupplement-Page-Content">
            <div class="InsertSupplement-Input-Txt">
                <asp:Label ID="Lbl_supplementName" runat="server" Text="Supplement Name: "></asp:Label>
                <asp:TextBox ID="Txt_supplementName" runat="server" Placeholder="Supplement Name"></asp:TextBox>
            </div>
            <div class="InsertSupplement-Input">
                <asp:Label ID="Lbl_supplementExpiryDate" runat="server" Text="Expiry Date: "></asp:Label>
                <asp:TextBox ID="Txt_supplementExpiryDate" runat="server" TextMode="Date"></asp:TextBox>/
            </div>
            <div class="InsertSupplement-Input-Txt">
                <asp:Label ID="Lbl_supplementPrice" runat="server" Text="Price: "></asp:Label>
                <asp:TextBox ID="Txt_supplementPrice" runat="server" Placeholder="Price"></asp:TextBox>
            </div>
            <div class="InsertSupplement-Input-Txt">
                <asp:Label ID="Lbl_supplementTypeID" runat="server" Text="Type ID: "></asp:Label>
                <asp:TextBox ID="Txt_supplementTypeID" runat="server" Placeholder="Type ID"></asp:TextBox>
            </div>
            <div class="InsertSupplement-Input">
                <asp:Label ID="Lbl_Error" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="Lbl_Success" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            <div class="InsertSupplement-Input-Button">
                <asp:Button ID="Btn_Insert" runat="server" Text="Insert Supplement" OnClick="Btn_Insert_Click" />
            </div>
            <div class="InsertSupplement-Input-Button">
                <asp:Button ID="ButtonBack" runat="server" Text="Back to Manage Supplement" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
</asp:Content>
