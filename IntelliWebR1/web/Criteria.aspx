<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intelli.Master" AutoEventWireup="true" CodeBehind="Criteria.aspx.cs" Inherits="IntelliWebR1.web.Criteria" %>

<%@ Register Src="~/web/ko/template_criteriaquestion.ascx" TagPrefix="uc1" TagName="template_criteriaquestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle_content">
        <div class="one">
            <uc1:template_criteriaquestion runat="server" ID="template_criteriaquestion" />
            <div class="CriteriaDiv">
                <div id="divCriteriaQuetion" class="CriteriaQuestionBox" data-bind="template: { name: 'template_criteriaquestion', foreach: AllQuestions }"></div>
            </div>
        </div>
        <aside></aside>
        <span class="clear"></span>
    </div>
</asp:Content>
