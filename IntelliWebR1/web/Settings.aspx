<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="IntelliWebR1.web.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <asp:fileupload runat="server" ID="FUpload"></asp:fileupload>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>
