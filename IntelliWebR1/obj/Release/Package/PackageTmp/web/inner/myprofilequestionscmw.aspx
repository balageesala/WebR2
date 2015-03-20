<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="myprofilequestionscmw.aspx.cs" Inherits="IntelliWebR1.web.inner.myprofilequestionscmw" %>

<%@ Register Src="~/web/ko/template_questionscheck.ascx" TagPrefix="uc1" TagName="template_questionscheck" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>

<div class="tenth_drop fr" style="margin-right: 2px; margin-top: -22px; padding-bottom: 10px;">
    <input type="button" id="btnFilter" class="filter" value="Filter" />
</div>
<span class="clear"></span>
<div id="divQuestionsCheck" data-bind="template: { name: 'template_questionscheck' }"></div>
<uc1:template_questionscheck runat="server" ID="template_questionscheck" />

<script type="text/javascript">
    $(document).ready(function () {
        var _api = _SitePath + "api/GetAllQuestionAnswers";
        $.getDATA(_api, function (_data) {
            ko.applyBindings(new QuestionAnswerListVM(_data), document.getElementById("divQuestionsCheck"));
        }, function () { });

        $("#btnFilter").click(function () {
            var _filterUrl = _SitePath + "web/inner/questionsfilter";
            SetUrlIntelliWindow(_filterUrl, "700", "424");

        });


    });
</script>
