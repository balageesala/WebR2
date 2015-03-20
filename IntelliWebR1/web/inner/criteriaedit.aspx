<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="criteriaedit.aspx.cs" Inherits="IntelliWebR1.web.inner.criteriaedit" %>

<%@ Register Src="~/web/ko/template_criteriaedit.ascx" TagPrefix="uc1" TagName="template_criteriaedit" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.0.0.js" type="text/javascript"></script>
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <style>
        body {
            margin: 0px;
            font-family: Verdana;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <div style="display: inline-block; width: 700px; min-height: 300px; max-height: 620px; background-color: #F4F4F4; padding-bottom: 25px; border-radius: 4px 4px; border: 1px solid #C3C3C3">
        <div style="width: 100%; float: left;">
            <div class="closecss" id="btnClose">x</div>
        </div>
        <div id="divCriteriaEdit" style="width: 700px;" data-bind="template: { name: 'template_criteriaedit', foreach: AllQuestions }">
        </div>
    </div>
    <uc1:template_criteriaedit runat="server" ID="template_criteriaedit" />

    <script type="text/javascript">
        $(document).ready(function () {
            $.getDATA(_SitePath + "api/GetCriteriaList", function (_return) {
                ko.applyBindings(new VMCriteriaQuestionList(_return), document.getElementById("divCriteriaEdit"));
                //alert(JSON.stringify(_return));
                DisplayQuestionEditable(_editCriteria);
                PostLoadEachQuestion();
            }, function () { });
            $("#btnClose").click(function () {
                window.parent.CloseIntelliWindow();
            });
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            var SESSION_API = _SitePath + "api/SessionCheck";
            $.getDATA(SESSION_API, function (_IsOnline) {
                if (!_IsOnline) {
                    window.location.href = _SitePath + "web/LogOut";
                    window.parent.CloseIntelliWindow();
                } else {
                    return true;
                }
            }, function () { });

        });


    </script>


</body>
</html>
