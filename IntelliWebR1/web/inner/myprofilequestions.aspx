<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofilequestions.aspx.cs" Inherits="IntelliWebR1.web.inner.myprofilequestions" %>

<%@ Register Src="~/web/ko/template_philosophyquestion.ascx" TagPrefix="uc1" TagName="template_philosophyquestion" %>
<%@ Register Src="~/web/ko/template_myprofilequestions.ascx" TagPrefix="uc1" TagName="template_myprofilequestions" %>

<style type="text/css">
   

    .btnSubmitN{
          font-size: 14px;
  color: #ffffff;
  font-weight: 400;
  font-family: 'Open Sans', sans-serif;
  background: #c1272d;
  padding: 0px 12px 0px 12px;
  border-radius: 2px;
  text-decoration: none;
  display: inline-block;
  height: 30px;
  text-align: center;
  line-height: 27px;
  cursor: pointer;
    }

     .Disabled {
        background-color: #999;
    }

</style>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<div>
    <div style="clear: both;"></div>
    <div id="divMyProfileGenQuestions" class="four eleven_middle" data-bind="template: { name: 'template_myprofilequestions', foreach: AllQuestions }"></div>
    <input type="hidden" id="hdnRating" />
</div>
<div style="height: 20px;">&nbsp;</div>
<uc1:template_myprofilequestions runat="server" ID="template_myprofilequestions" />

<script type="text/javascript">

    function bindBarRatting() {

        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('show', {
                showValues: true,
                showSelectedRating: false
            });
            $('.rating-enable').trigger('click');
        });
    }

    function DistroyRating() {
        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('destroy');
            $(_obj).hide();
        });
        $("#hdnRating").val("0");
    }

    function autoGrow(oField) {
        if (oField.scrollHeight > oField.clientHeight) {
            oField.style.height = oField.scrollHeight + "px";
        }
    }


    $(document).ready(function () {
        CheckIsUserOnline();
        var _api = _SitePath + "api/GetAllQuestions";
        $.getDATA(_api, function (_data) {
            if (_data != "") {
              //  alert(_data);
                ko.applyBindings(new QuestionListVM(_data), document.getElementById("divMyProfileGenQuestions"));
                setTimeout(function () {
                    ShowFirstUnAnswered();
                    bindBarRatting();
                }, 1000);
            } else {
                $("#divMyProfileGenQuestions").html("You have answred all genaral questions.");
            }
        }, function () { });
    });


</script>
