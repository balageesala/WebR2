<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MyProfileQuestions.aspx.cs" Inherits="IntelliWebR1.web.MyProfileQuestions" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>
<%@ Register Src="~/web/uc/myprofilequestionsmenu.ascx" TagPrefix="uc1" TagName="myprofilequestionsmenu" %>
<%@ Register Src="~/web/ko/template_myprofilequestions.ascx" TagPrefix="uc1" TagName="template_myprofilequestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <style type="text/css">

        .tableft{
            position:relative;
            top: -900px;
            background:#fff;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="eleven">
                <div class="tab_nav ninth_top_nav">
                    <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
                </div>
                <span class="clear"></span>
                <div class="eleven_cont">
                    <div class="four">
                        <uc1:myprofilequestionsmenu runat="server" ID="myprofilequestionsmenu" />
                        <span class="clear"></span>
                        <div class="eleven_middle" style="width: 744px;" id="divMyProfileContainer"></div>
                    </div>
                </div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>
</asp:Content>
