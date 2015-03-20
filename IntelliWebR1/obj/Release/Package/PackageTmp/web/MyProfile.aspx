<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intellidate.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="IntellidateR1Web.web.MyProfile" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>
<%@ Register Src="~/web/uc/userphoto.ascx" TagPrefix="uc1" TagName="userphoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="divmyprofile">
        <div class="divWhiteBox">
            <uc1:userphoto runat="server" ID="userphoto" />
            <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
            <div id="divMyProfileContainer" class="divMyProfileContainer"></div>
        </div>
        <div class="divBlockBox">
            &nbsp;
        </div>
    </div>

</asp:Content>
