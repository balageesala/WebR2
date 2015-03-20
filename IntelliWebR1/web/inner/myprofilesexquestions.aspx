﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofilesexquestions.aspx.cs" Inherits="IntelliWebR1.web.inner.myprofilesexquestions" %>


<%@ Register Src="~/web/uc/myprofilequestionsmenu.ascx" TagPrefix="uc1" TagName="myprofilequestionsmenu" %>
<%@ Register Src="~/web/ko/template_sexquestions.ascx" TagPrefix="uc1" TagName="template_sexquestions" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>

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
<div>
    <div style="clear: both;"></div>
    <div id="divMyProfileSexQuestions" class="four eleven_middle" data-bind="template: { name: 'template_sexquestions', foreach: AllQuestions }"></div>
    <input type="hidden" id="hdnRating" />
</div>
<div style="height: 20px;">&nbsp;</div>
<uc1:template_sexquestions runat="server" id="template_sexquestions" />
<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });

    function bindBarRatting() {

        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('show', {
                showValues: true,
                showSelectedRating: false,
                onSelect: function (value, text) {
                    $("#hdnRating").val(value);
                }
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


</script>
