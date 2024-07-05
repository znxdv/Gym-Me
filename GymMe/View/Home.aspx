<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Final_Project.View.Home" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/HomePage.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
   <div class="content-container">
        <h1>Welcome to Your Dashboard</h1>
        <asp:Label ID="Label1" runat="server" Text="User role: "></asp:Label>
        <asp:Label ID="Lbl_user" runat="server"></asp:Label>
        
        <asp:Panel ID="customer_list" runat="server">
            <asp:GridView ID="GridView" runat="server" CssClass="grid-view"
                          OnRowEditing="GridView_RowEditing" OnRowDeleting="GridView_RowDeleting" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="ID" SortExpression="UserID"/>
                    <asp:BoundField DataField="UserName" HeaderText="Username" SortExpression="UserName" />
                    <asp:BoundField DataField="UserEmail" HeaderText="Email" SortExpression="UserEmail" />
                    <asp:BoundField DataField="UserDOB" DataFormatString="{0: d MMMM yyyy}" HeaderText="Date of Birth" SortExpression="UserDOB" />
                    <asp:BoundField DataField="UserGender" HeaderText="Gender" SortExpression="UserGender" />
                    <asp:BoundField DataField="UserRole" HeaderText="Role" SortExpression="UserRole" />
                    <asp:BoundField DataField="UserPassword" HeaderText="Password" SortExpression="UserPassword" />
                    <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        
        <asp:Label ID="Lbl_Greet" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
