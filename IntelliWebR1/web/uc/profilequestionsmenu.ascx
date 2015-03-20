<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="profilequestionsmenu.ascx.cs" Inherits="IntelliWebR1.web.uc.profilequestionsmenu" %>

<div style="margin-left: -12px; float: left;width:945px;">
    <div class="four generally fl">
        <ul class="nav">
            <li><a style="cursor:pointer;" id="lnkGenaralQuestions">General</a></li>
            <li><a style="cursor:pointer;" id="lnkSexQuestions">Sex</a></li>
        </ul>
        <span class="clear"></span>
    </div>
    <div class="sixteen_drop fr" id="divFilter" style="float:right;">
        <a style="cursor:pointer;" id="btnFilter">Filter</a>
    </div>
</div>
<span class="clear"></span>

<script type="text/javascript">
    $(document).ready(function () {

        // $("#lnkGenaralQuestions").css("color", "red");


        var _ApiHideSexLink = _SitePath + "api/ThisUserHasSexQuestions";
        var _SexLinkObject = new Object();
        _SexLinkObject.OtherUserID = _OtherUserID;
        $("#lnkSexQuestions").hide();
        $.postDATA(_ApiHideSexLink, _SexLinkObject, function (_return) {
            if (_return) {
                $("#lnkSexQuestions").show();
            } else {
                $("#lnkSexQuestions").hide();
                $("#divSextab").hide();
            }
        });

        $("#lnkGenaralQuestions").click(function () {
            $(".sixteen_cont").empty();
            $("#divLoadProfileMatchp").empty();
            NoBlockBar();
            LoadGenaralQuestions();
           
        });

        $("#lnkSexQuestions").click(function () {
            $(".sixteen_cont").empty();
            $("#divLoadProfileMatchp").empty();
            $("#divFilter").hide();
            yesBlockBar();
            LoadSexQuestions();
        });

        $("#btnFilter").click(function () {
            var _filterUrl = _SitePath + "web/inner/profilequestionsfilter";
            SetUrlIntelliWindow(_filterUrl, "700", "424");
        });

    });
</script>
