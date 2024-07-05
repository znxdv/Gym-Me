<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="UpdateSupplement.aspx.cs" Inherits="Final_Project.View.UpdateSupplement" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/UpdateSupplementPage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <div class="Update-container">
            <div class="title">Update Supplement</div>
                <div class="form_group">
                    <asp:Label ID="Lbl_supplementName" runat="server" Text="Supplement Name: " CssClass="label"></asp:Label>
                    <asp:TextBox ID="Txt_supplementName" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                <div class="form_group">
                    <asp:Label ID="Lbl_supplementExpiryDate" runat="server" Text="Expiry Date: " CssClass="label"></asp:Label>
                    <asp:TextBox ID="Txt_supplementExpiryDate" runat="server" TextMode="Date" CssClass="textbox"></asp:TextBox>
                </div>
                <div class="form_group">
                    <asp:Label ID="Lbl_supplementPrice" runat="server" Text="Price: " CssClass="label"></asp:Label>
                    <asp:TextBox ID="Txt_supplementPrice" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                    <div class="form_group">
                <asp:Label ID="Lbl_supplementTypeID" runat="server" Text="Type ID: " CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_supplementTypeID" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
                <div>
                    <asp:Label ID="Lbl_error" runat="server" Text="" Visible="false" CssClass="label"></asp:Label>
                    <asp:Label ID="Lbl_scs" runat="server" Text="" Visible="false" CssClass="label"></asp:Label>
                </div>

                <div>
                    <asp:Button ID="Btn_updateSupplement" runat="server" Text="Update Supplement" onclick="Btn_updateSupplement_Click" CssClass="button" />
                </div>
            </div>
    </div>
</asp:Content>
