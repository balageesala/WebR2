<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="IntelliWebR1.web.Home" %>

<%@ Register Src="~/web/ko/template_todaymatch.ascx" TagPrefix="uc1" TagName="template_todaymatch" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <style type="text/css">
    .divtodaymatch {
        text-align: center;
        padding-top: 30px;
        font-weight: bold;
    }
    .divborder{
        border-bottom: 5px solid #ececec;
        margin-bottom: 15px;
    }

    .divPaddingTop{
         padding-top: 80px;
    }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <uc1:template_todaymatch runat="server" ID="template_todaymatch" />
        <div class="middle_content">
            <section class="main_content">
                <div class="main_lt" style="min-height: 600px;">
                    <div class="six_profile_info">
                       
                         <!--Todays match -->
                        <div class="six_profile_both" id="divTodayMatch" data-bind="template: { name: 'template_todaymatch' }"> </div>
                        
                        <!--Rematch left side -->

                        <div class="rematch_d fl" id="DivRematchYou"></div>

                        <!--Rematch Right side -->

                        <div class="rematch_d fr rematch_7A-" id="DivRematchThem"></div>

                    </div>
                </div>
                <span class="clear"></span>
            </section>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            var _TodayMatchAPI = _SitePath + "api/GetThisDayMatch";
            var _DateObject = new Object();
            var _ThisTodayDate = new Date();
            if (_ThisTodayDate.getHours() < 12) {
                var _normalDate = _ThisTodayDate.addDays(-1);
                _DateObject.ThisDay = _normalDate.getDate();
                _DateObject.ThisMounth = _normalDate.getMonth();
                _DateObject.ThisYear = _normalDate.getFullYear();
            } else {
                _DateObject.ThisDay = _ThisTodayDate.getDate();
                _DateObject.ThisMounth = _ThisTodayDate.getMonth();
                _DateObject.ThisYear = _ThisTodayDate.getFullYear();
            }

            $.postDATA(_TodayMatchAPI, _DateObject, function (_return) {
                if (_return != null) {
                    ko.applyBindings(new VMTodaysMatch(_return), document.getElementById("divTodayMatch"));
                } else {
                    $("#divTodayMatch").html("Sorry, we can't find any match at this time.");
                    $("#divTodayMatch").addClass("divtodaymatch");
                }

                //get rematch you 
                var _RematchYouApi = _SitePath + "api/TodayYouRematch";
                $.postDATA(_RematchYouApi, _DateObject, function (_returnID) {
                    if (_returnID != "0") {
                        var _loadLeftUrl = _SitePath + "web/inner/leftrematch?OtherUserID=" + _returnID;
                        $("#DivRematchYou").load(_loadLeftUrl, function () {
                            $(".six_profile_both").addClass("divborder");                    
                        });
                    } else {
                        $("#DivRematchYou").html("&nbsp;");
                    }
                });

                //get rematch them
                var _RematchThemApi = _SitePath + "api/TodayTheyRematch";
                $.postDATA(_RematchThemApi, _DateObject, function (_returnID) {
                    if (_returnID != "0") {
                        var _loadLeftUrl = _SitePath + "web/inner/rightrematch?OtherUserID=" + _returnID;
                        $("#DivRematchThem").load(_loadLeftUrl, function () {
                            $(".six_profile_both").addClass("divborder");
                        });
                    } else {
                        $("#DivRematchThem").html("&nbsp;");
                    }
                });

            });

        });

        Date.prototype.addDays = function (days) {
            var dat = new Date(this.valueOf())
            dat.setDate(dat.getDate() + days);
            return dat;
        }
    </script>


</asp:Content>
