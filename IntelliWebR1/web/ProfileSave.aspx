<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intellidate.Master" AutoEventWireup="true" CodeBehind="ProfileSave.aspx.cs" Inherits="IntellidateR1Web.web.ProfileSave" %>

<%@ Register Src="~/web/uc/savedmemenu.ascx" TagPrefix="uc1" TagName="savedmemenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:savedmemenu runat="server" id="savedmemenu" />
</asp:Content>
