<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MatchHistory.aspx.cs" Inherits="IntelliWebR1.web.MatchHistory" %>

<%@ Register Src="~/web/ko/template_currentmatchs.ascx" TagPrefix="uc1" TagName="template_currentmatchs" %>
<%@ Register Src="~/web/ko/template_pastmatchs.ascx" TagPrefix="uc1" TagName="template_pastmatchs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content2">
        <div class="middle_content">
            <div class="twenty_six">
                <uc1:template_currentmatchs runat="server" ID="template_currentmatchs" />
                <div class="twenty_six_toper" id="divCurrentMatchs" data-bind="template: { name: 'template-currentmatchs'}" ></div>
                <div class="line_hy"></div>
                <uc1:template_pastmatchs runat="server" ID="template_pastmatchs" />
               <div class="twenty_six_past_cont" id="divPastMatchs" data-bind="template: { name: 'template-pastmatchs' }" ></div>               
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            //bind knock out 
            var _CurrentMatchsAPI = _SitePath + "api/GetCurrentMatchs";
            $.getDATA(_CurrentMatchsAPI, function (_data) {         
                if (_data != "") {
                    var _GetTotalData = new Array;
                    var _GetTodaysData = GetMatchTypeObject(1);
                    for (var i = 0; i < _GetTodaysData.length; i++) {
                        _GetTodaysData[i].MatchType = 1;
                        _GetTodaysData[i].MatchUserID = _GetTodaysData[i].MatchUserID;
                        _GetTodaysData[i].IsLastMatch = _GetTodaysData[i].IsLastMatch;
                        for (var x = 0; x < _data.length; x++) {
                            if (_data[x].MatchType == 1) {
                                var _MatchedDate = new Date(_data[x].MatchedDate);
                                var _FormatedMatchedDate = (_MatchedDate.getMonth() + 1) + "-" + _MatchedDate.getDate() + "-" + _MatchedDate.getFullYear();
                                if (_GetTodaysData[i].MatchedDate == _FormatedMatchedDate) {
                                    _GetTodaysData[i].MatchUserID = _data[x].MatchUserID;
                                    _GetTodaysData[i].MatchType = _data[x].MatchType;
                                    _GetTodaysData[i].PhotoUrl = _data[x].PhotoUrl;
                                    _GetTodaysData[i].UserName = _data[x].UserName;
                                }
                            }
                        }
                        var _dateMounth = _GetTodaysData[i].MatchedDate.split('-')[0] - 1;
                        var _dateDate = _GetTodaysData[i].MatchedDate.split('-')[1];
                        var _dateYear = _GetTodaysData[i].MatchedDate.split('-')[2];
                        _GetTodaysData[i].MatchedDate = new Date(_dateYear, _dateMounth, _dateDate);

                    }

                    var _GetRematchThemData = GetMatchTypeObject(2);

                    for (var i = 0; i < _GetRematchThemData.length; i++) {
                        _GetRematchThemData[i].MatchType = 2;
                        _GetRematchThemData[i].MatchUserID = _GetRematchThemData[i].MatchUserID;
                        _GetRematchThemData[i].MatchedDate = _GetRematchThemData[i].MatchedDate;
                        _GetRematchThemData[i].IsLastMatch = _GetRematchThemData[i].IsLastMatch;
                        for (var x = 0; x < _data.length; x++) {
                            if (_data[x].MatchType == 2) {
                                var _MatchedDate = new Date(_data[x].MatchedDate);
                                var _FormatedMatchedDate = (_MatchedDate.getMonth() + 1) + "-" + _MatchedDate.getDate() + "-" + _MatchedDate.getFullYear();
                                if (_GetRematchThemData[i].MatchedDate == _FormatedMatchedDate) {
                                    _GetRematchThemData[i].MatchUserID = _data[x].MatchUserID;
                                    _GetRematchThemData[i].MatchType = _data[x].MatchType;
                                    _GetRematchThemData[i].MatchedDate = _data[x].MatchedDate;
                                    _GetRematchThemData[i].PhotoUrl = _data[x].PhotoUrl;
                                    _GetRematchThemData[i].UserName = _data[x].UserName;
                                }
                            }
                        }

                    }

                    var _GetRematchYouData = GetMatchTypeObject(3);
                    for (var i = 0; i < _GetRematchYouData.length; i++) {
                        _GetRematchYouData[i].MatchType = 3;
                        _GetRematchYouData[i].MatchUserID = _GetRematchYouData[i].MatchUserID;
                        _GetRematchYouData[i].MatchedDate = _GetRematchYouData[i].MatchedDate;
                        _GetRematchYouData[i].IsLastMatch = _GetRematchYouData[i].IsLastMatch;
                        for (var x = 0; x < _data.length; x++) {
                            if (_data[x].MatchType == 3) {
                                var _MatchedDate = new Date(_data[x].MatchedDate);
                                var _FormatedMatchedDate = (_MatchedDate.getMonth() + 1) + "-" + _MatchedDate.getDate() + "-" + _MatchedDate.getFullYear();
                                if (_GetRematchYouData[i].MatchedDate == _FormatedMatchedDate) {
                                    _GetRematchYouData[i].MatchUserID = _data[x].MatchUserID;
                                    _GetRematchYouData[i].MatchType = _data[x].MatchType;
                                    _GetRematchYouData[i].MatchedDate = _data[x].MatchedDate;
                                    _GetRematchYouData[i].PhotoUrl = _data[x].PhotoUrl;
                                    _GetRematchYouData[i].UserName = _data[x].UserName;
                                }
                            }
                        }

                    }

                    //todays match
                    for (var i = 0; i < _GetTodaysData.length; i++) {
                        var _TodayMatch = new Object();
                        _TodayMatch.MatchUserID = _GetTodaysData[i].MatchUserID;
                        _TodayMatch.MatchType = _GetTodaysData[i].MatchType;
                        _TodayMatch.MatchedDate = _GetTodaysData[i].MatchedDate;
                        _TodayMatch.PhotoUrl = _GetTodaysData[i].PhotoUrl;
                        _TodayMatch.IsLastMatch = _GetTodaysData[i].IsLastMatch;
                        _TodayMatch.UserName = _GetTodaysData[i].UserName;
                        _GetTotalData.push(_TodayMatch);
                    }

                    //rematch them
                    for (var i = 0; i < _GetRematchThemData.length; i++) {
                        var _TodayMatch = new Object();
                        _TodayMatch.MatchUserID = _GetRematchThemData[i].MatchUserID;
                        _TodayMatch.MatchType = _GetRematchThemData[i].MatchType;
                        _TodayMatch.MatchedDate = _GetRematchThemData[i].MatchedDate;
                        _TodayMatch.PhotoUrl = _GetRematchThemData[i].PhotoUrl;
                        _TodayMatch.IsLastMatch = _GetRematchThemData[i].IsLastMatch;
                        _TodayMatch.UserName = _GetRematchThemData[i].UserName;
                        _GetTotalData.push(_TodayMatch);
                    }

                    //rematch you
                    for (var i = 0; i < _GetRematchYouData.length; i++) {
                        var _TodayMatch = new Object();
                        _TodayMatch.MatchUserID = _GetRematchYouData[i].MatchUserID;
                        _TodayMatch.MatchType = _GetRematchYouData[i].MatchType;
                        _TodayMatch.MatchedDate = _GetRematchYouData[i].MatchedDate;
                        _TodayMatch.PhotoUrl = _GetRematchYouData[i].PhotoUrl;
                        _TodayMatch.IsLastMatch = _GetRematchYouData[i].IsLastMatch;
                        _TodayMatch.UserName = _GetRematchYouData[i].UserName;
                        _GetTotalData.push(_TodayMatch);
                    }

                    ko.applyBindings(new VMCurrentMatchsList(_GetTotalData), document.getElementById("divCurrentMatchs"));

                } else {
                    $("#divCurrentMatchs").html("Sorry, you don't have any current matchs at this time.");
                    $("#divCurrentMatchs").css("text-align", "center");
                    $("#divCurrentMatchs").css("margin-top", "20px");
                    $("#divCurrentMatchs").css("padding-bottom", "20px");
                }
            }, function () { });

        });


        Date.prototype.addDays = function (days) {
            var dat = new Date(this.valueOf())
            dat.setDate(dat.getDate() + days);
            return dat;
        }


        function getDates(startDate, stopDate) {
            var dateArray = new Array();
            var currentDate = startDate;
            while (currentDate >= stopDate) {
                dateArray.push(new Date(currentDate))
                currentDate = currentDate.addDays(-1);
            }
            return dateArray;
        }


        function GetMatchTypeObject(Type) {

            var _MatchData = new Array();
            var rangeDates; 
            var _ThisTodayDate = new Date();
            if (_ThisTodayDate.getHours() < 12) {
                rangeDates = getDates(new Date(), new Date().addDays(-7));
                rangeDates.shift();
            } else {
                rangeDates = getDates(new Date(), new Date().addDays(-6));
            }


            //set todays matchs
            for (var i = 0; i < rangeDates.length; i++) {
                var _matchObject = new Object();
                var _ThisDate = rangeDates[i];
                var _FormattedThisDate = (_ThisDate.getMonth() + 1) + "-" + _ThisDate.getDate() + "-" + _ThisDate.getFullYear();
                _matchObject.MatchUserID = 0;
                _matchObject.MatchType = Type;
                _matchObject.MatchedDate = _FormattedThisDate;
                _matchObject.PhotoUrl = "";
                _matchObject.UserName = "";
                _matchObject.IsLastMatch = false;
                if ( i == eval(rangeDates.length - 1)) {
                    _matchObject.IsLastMatch = true;
                }
                _MatchData.push(_matchObject);
            }
            return _MatchData;
        }


        function SetTimmer() {

        }


        $(document).ready(function () {
            var now = new Date();
            var millisTill12 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 12, 00, 00, 0) - now;
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
            //reload the page after 11:59 am
            if (hh <= 11 && MM <= 59 && SS <= 59) {
                setTimeout(function () {
                    window.location.reload();
                }, millisTill12);
            }

            //bind past matchs
            var _PastMatchsAPI = _SitePath + "api/GetPastMatchs";
            $.getDATA(_PastMatchsAPI, function (_return) {
                if (_return != "") {
                    ko.applyBindings(new VMPastMatchsList(_return), document.getElementById("divPastMatchs"));
                } else {
                    $("#divPastMatchs").hide();
                }
               
            }, function () { });

        });


    </script>


</asp:Content>
