<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="Final_Project.View.TransactionDetail" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/TransactionDetailPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server"><br />
    <div class="container">
        <div class="Detail-container">
            <div class="title">Transaction Detail</div>
            <asp:Label ID="Lbl_Username" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Lbl_SupplementID" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Lbl_SupplementName" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Lbl_Quantity" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Lbl_TransactionDate" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Lbl_Status" runat="server" Text=""></asp:Label>
            <asp:Label ID="Lbl_Error" runat="server" Text="" Visible="false"></asp:Label>
        </div>
        
    </div>
</asp:Content>
