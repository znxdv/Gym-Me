<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Final_Project.View.Profile" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ProfilePage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <div class="profile-container">
            <div class="title">Update Profile</div>
            <div class="form-group">
                <asp:Label ID="Lbl_Username" runat="server" Text="Username:" CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_Username" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_Email" runat="server" Text="Email:" CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_Email" runat="server" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_Gender" runat="server" Text="Gender" CssClass="label"></asp:Label>
                <asp:RadioButtonList ID="RBtn_Gender" runat="server" CssClass="radiobuttonlist">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth (DD/MM/YY):" CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_DOB" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_error" runat="server" Text="" Visible="false" CssClass="error"></asp:Label>
                <asp:Label ID="Lbl_scs" runat="server" Text="" Visible="false" CssClass="success"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="Btn_UpdateProfile" runat="server" Text="Update Profile" OnClick="Btn_UpdateProfile_Click" CssClass="button" />
            </div>
        </div>
        <div class="password-container">
            <div class="title">Password</div>
            <div class="form-group">
                <asp:Label ID="Lbl_currentPassword" runat="server" Text="Current Password:" CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_currentPassword" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_newPassword" runat="server" Text="New Password:" CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_newPassword" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_confirmationPassword" runat="server" Text="Confirmation Password:" CssClass="label"></asp:Label>
                <asp:TextBox ID="Txt_confirmationPassword" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Lbl_error2" runat="server" Text="" Visible="false" CssClass="error"></asp:Label>
                <asp:Label ID="Lbl_scs2" runat="server" Text="" Visible="false" CssClass="success"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Button ID="Btn_updatePassword" runat="server" Text="Update Password" OnClick="Btn_updatePassword_Click" CssClass="button" />
            </div>
        </div>
    </div>
</asp:Content>
