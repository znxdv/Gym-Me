<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="ReportTransaction.aspx.cs" Inherits="Final_Project.View.ReportTransaction" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <CR:CrystalReportViewer style="display:flex; justify-content:center; margin: 5%;" ID="ReportViewer" runat="server" AutoDataBind="true" />
</asp:Content>
