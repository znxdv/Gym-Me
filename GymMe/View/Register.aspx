<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Final_Project.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" runat="server" media="screen" href="~/Styles/RegisterPage.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Register-Page-Container">
            <div class="Register-Page-Content">
                <div class="Register-Page-Title">
                    <span class="Register-Title">Welcome To GymMe!</span>
                </div>
                <div class="Register-Input-Txt">
                    <asp:Label ID="Lbl_Username" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="Txt_Username" runat="server" Placeholder="Username"></asp:TextBox>
                </div>
                <div class="Register-Input-Txt">
                    <asp:Label ID="Lbl_Email" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="Txt_Email" runat="server" Placeholder="Email" TextMode="Email"></asp:TextBox>
                </div>
                <div class="Register-Input-Txt">
                    <asp:Label ID="Lbl_Gender" runat="server" Text="Gender"></asp:Label>
                    <asp:RadioButtonList ID="Register_Btn_Gender" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="Register-Input-Txt">
                    <asp:Label ID="Lbl_Password" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Txt_Password" runat="server" Placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>
                <div class="Register-Input-Txt">
                    <asp:Label ID="Lbl_Confirm_Password" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="Txt_Confirm_Password" runat="server" Placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                </div>

                <div class="Register-Input-DOB">
                    <asp:Label ID="Lbl_DOB" runat="server" Text="Date of Birth: "></asp:Label>
                    <asp:TextBox ID="Txt_DOB" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="Register-Input">
                    <asp:Label ID="Lbl_Error" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
                    <asp:Label ID="Lbl_Success" CssClass="success" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                <div class="Register-Input-Button">
                    <asp:Button ID="Btn_Register" runat="server" Text="Register" OnClick="Btn_Register_Click" />
                </div>
                <div class="Register-To-Login">
                    <span>Already have an account?</span>
                    <asp:HyperLink ID="HyperLink" runat="server" NavigateUrl="~/View/Login.aspx">Login Here!</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
