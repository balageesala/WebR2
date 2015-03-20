<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profilemenu.ascx.cs" Inherits="IntelliWebR1.web.uc.profilemenu" %>
<%@ Register Src="~/web/uc/iconsmenu.ascx" TagPrefix="uc1" TagName="iconsmenu" %>

<style type="text/css">
    .widthchange1 {
        margin-top: 10px;
        float: left;
        border-bottom: 0px;
        width: 100%;
    }

    .widthchange2 {
        margin-top: 10px;
        float: left;
        border-bottom: 0px;
        width: 168%;
    }
</style>


<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
<div class="tab thirteen_top_nav" style="height:32px;">
    <div class="tab_nav thirteen_nav" style="margin: -2px !important;height:0px;">
        <ul>
            <li><a id="liOtherWritten">About me</a></li>
            <li><a id="liOtherPhotos">Photos</a></li>
            <li><a id="liOtherCriteria">Criteria</a></li>
            <li><a id="liOtherQuestions">Questions</a></li>
        </ul>
    </div>

    <uc1:iconsmenu runat="server" ID="iconsmenu" />
</div>

