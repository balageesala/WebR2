<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todaymatch.aspx.cs" Inherits="IntellidateR1Web.web.inner.todaymatch" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div style="width: 100%;">
   
    <div id="divTodayMatch" style="min-height:454px">
        
    </div>

    <div style="clear: both; height: 1px;"></div>
    <div>
        <div style="margin-left: 10px; margin-top: 30px; margin-left: 30px; font-size: 20px; float: left;width:93%;">
          
            <div id="divYouRematch" style="float:left;">

            </div>

             <div id="divTheyRematch" style="float:right;">

            </div>

        </div>
    </div>
</div>
<script type="text/javascript">

    $(document).ready(function () {

        //if user having past day match it will show up until 11.59 am
        //our day will starts at 12 pm to next 11.59 am .


        var now = new Date();
        var millisTill12 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 11, 59, 59, 0) - now;
        if (millisTill12 < 0) {
            millisTill12 += 86400000; // it's after 12pm
        }

    
        // set time for today 12 pm
        // this will fires while user registered day before 12 pm and he stays in site after 12 pm 
        //if the day is before 12 pm
        var now = new Date();
        var hh = now.getHours();
        var MM = now.getMinutes();
        var SS = now.getSeconds();
        if (hh <= 11 && MM <= 59 && SS <= 59) {
            //set if user having yesterday rematch
            bindYesterdayRematchs();
            bindYesterDayMatch();
            setTimeout(function () {
                bindRematchs();
                bindTodayMatch();
            }, millisTill12);
        } else {
            bindRematchs();
            bindTodayMatch();
        }
    });


    function bindRematchs()
    {

        var _MYREMATCH_API = _SitePath + "API/TodayYouRematch";
        var _THEYREMATCH_API = _SitePath + "API/TodayTheyRematch";
        $.getDATA(_MYREMATCH_API, function (_retID) {
            if (_retID != "0") {
                var _loadLeftUrl = _SitePath + "web/inner/leftrematch?OtherUserID=" + _retID;
                $("#divYouRematch").load(_loadLeftUrl, function () {
                });
            }
        }, function () { });

        $.getDATA(_THEYREMATCH_API, function (_retID) {
            if (_retID != "0") {
                var _loadRightUrl = _SitePath + "web/inner/rightrematch?OtherUserID=" + _retID;
                $("#divTheyRematch").load(_loadRightUrl, function () {

                });
            }
        }, function () { });
    }

    //function for yesterday rematch

    function bindYesterdayRematchs() {
        var _MYREMATCH_API = _SitePath + "API/YesterdayYouRematch";
        var _THEYREMATCH_API = _SitePath + "API/YesterdayTheyRematch";
        $.getDATA(_MYREMATCH_API, function (_retID) {
            if (_retID != "0") {
                var _loadLeftUrl = _SitePath + "web/inner/leftrematch?OtherUserID=" + _retID;
                $("#divYouRematch").load(_loadLeftUrl, function () {
                });
            }
        }, function () { });

        $.getDATA(_THEYREMATCH_API, function (_retID) {
            if (_retID != "0") {
                var _loadRightUrl = _SitePath + "web/inner/rightrematch?OtherUserID=" + _retID;
                $("#divTheyRematch").load(_loadRightUrl, function () {

                });
            }
        }, function () { });
    }


    function bindTodayMatch(){
        var _loadTodayUrl = _SitePath + "web/inner/thisdaymatch";
        $("#divTodayMatch").load(_loadTodayUrl, function () {

        });
    }

    function bindYesterDayMatch() {
        var _loadTodayUrl = _SitePath + "web/inner/yesterdaymatch";
        $("#divTodayMatch").load(_loadTodayUrl, function () {

        });
    }





</script>
