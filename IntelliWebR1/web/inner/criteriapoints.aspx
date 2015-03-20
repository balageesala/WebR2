<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="criteriapoints.aspx.cs" Inherits="IntelliWebR1.web.inner.criteriapoints" %>

<%@ Register Src="~/web/ko/template_criteriapoint.ascx" TagPrefix="uc1" TagName="template_criteriapoint" %>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<div class="CriteriaPointsTitles">
    <div class="CriteriaPointsTitleDiv">
        <div class="CriteriaPointsTitleText">Now Time to Assign Points to each of the Category</div>
        <div class="CriteriaPointsAvailableDiv">
            <div class="CriteriaPointsAvailableText">Available Points</div>
            <div class="CriteriaPointsAvailableTextBoxDiv">
                <input type="text" class="CriteriaPointsAvailableTextBox" id="txtPointsLeft" disabled="disabled" value="100" />
            </div>
        </div>
    </div>
</div>
<div class="CriteriaPointsDividerLine">
    <div class="CriteriaDividerLine gradientLine"></div>
</div>
<div class="CriteriaPointsDiv">
    <div class="CriteriaPointsRow" id="divCriteriaPoints" data-bind="template: { name: 'template_criteriapoint', foreach: AllQuestions }">
    </div>
</div>
<div style="text-align: right; width: 1010px; margin: 0 auto;">
    <div class="SubmitButton FloatRight Disabled" id="btnSubmit" tabindex="0">
        <div>Submit</div>
    </div>
</div>
<uc1:template_criteriapoint runat="server" ID="template_criteriapoint" />
