<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Final_Project.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/LoginPage.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="Login-Page-Container">
            <div class="Login-Page-Content">
                <div class="Login-Page-Title">
                    <span class="Login-Title">Welcome Back!</span>
                </div>
                <div class="Login-Input-Txt">
                    <asp:Label ID="Lbl_Username" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="Txt_Username" runat="server" Placeholder="Username"></asp:TextBox>
                </div>
                <div class="Login-Input-Txt">
                    <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Txt_Password" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                <div class="Login-Input-Remember">
                    <asp:CheckBox ID="Chk_Remember" runat="server" Text="Remember Me"/>
                </div>
                <div class="Login-Input">
                    <asp:Label ID="Lbl_Error" runat="server" Text="" CssClass="Login_Error"></asp:Label>
                </div>
                <div class="Login-Input-Button">
                    <asp:Button ID="Btn_Login" runat="server" Text="Login" OnClick="Btn_Login_Click"  />
                </div>
                <div class="Login-To-Register">
                    <span>Don't have an account?</span>
                    <br />
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="~/View/Register.aspx">Sign Up!</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
