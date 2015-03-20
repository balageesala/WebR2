<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_currentmatchs.ascx.cs" Inherits="IntelliWebR1.web.ko.template_currentmatchs" %>


<script type="text/html" id="template-currentmatchs">
    <div class="twenty_six_left">

        <div class="twenty_six_current" style="margin:0 0 0 0;padding:0 0 0 0 ;">
            <ul class="row1" data-bind="foreach: AllMatchs" style="margin: 0px auto 0px;">
                <!-- ko if:(MatchType()=='1' && !IsLastMatch()) -->
                <li><small data-bind="text: OnlyDate" style="margin:0 0 0 0;padding:0 0 0 0 ;"></small></li>
                <!-- /ko -->
            </ul>
            <span class="clear"></span>
        </div>
        <div class="twenty_six_you">
            <h2>Current matches</h2>
            <ul class="row1" data-bind="foreach: AllMatchs" >
                <!-- ko if:(MatchType()=='1' && !IsLastMatch()) -->
                <!-- ko ifnot:MatchUserID()=='0' -->
                <li><img data-bind="attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoProfilePage }" /></li>
                <!-- /ko -->
                <!-- ko if:MatchUserID()=='0' -->
                <li><small>&nbsp;</small></li>
                <!-- /ko -->
                <!-- /ko -->
            </ul>
            <span class="clear"></span>
        </div>
        <!-- ko if: UserMatchTypeTwo -->
        <div class="twenty_six_you">
            <h2>You rematched them</h2>
            <ul class="row1" data-bind="foreach: AllMatchs">
                <!-- ko if:(MatchType()=='2'  && !IsLastMatch()) -->
                <!-- ko ifnot:MatchUserID()=='0' -->
                <li>
                    <img data-bind="attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoProfilePage }" /></li>
                <!-- /ko -->
                <!-- ko if:MatchUserID()=='0' -->
                <li><small>&nbsp;</small></li>
                <!-- /ko -->
                <!-- /ko -->
            </ul>
            <span class="clear"></span>
        </div>
        <!-- /ko -->
        <!-- ko if: UserMatchTypeThree -->
        <div class="twenty_six_you">
            <h2>They rematched you</h2>
            <ul class="row1" data-bind="foreach: AllMatchs">
                <!-- ko if:(MatchType()=='3'  && !IsLastMatch()) -->
                <!-- ko ifnot:MatchUserID()=='0' -->
                <li>
                    <img data-bind="attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoProfilePage }" /></li>
                <!-- /ko -->
                <!-- ko if:MatchUserID()=='0' -->
                <li><small>&nbsp;</small></li>
                <!-- /ko -->
                <!-- /ko -->
            </ul>
            <span class="clear"></span>
        </div>
        <!-- /ko -->
    </div>

    <div class="twenty_six_right">
        <ul data-bind="foreach: AllMatchs">
            <!-- ko if:(MatchType()=='1'  && IsLastMatch()) -->
            <!-- ko ifnot:MatchUserID()=='0' -->
            <li><small class="timer" data-bind="text: timer"></small><img data-bind="attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoProfilePage }" /></li>
            <!-- /ko -->
            <!-- ko if:MatchUserID()=='0' -->
            <li><small class="timer" data-bind="text: timer"></small><div style="min-height:90px;">&nbsp;</div></li>
            <!-- /ko -->
            <!-- /ko -->
            <!-- ko if:(MatchType()=='2'  && IsLastMatch()) -->
            <!-- ko ifnot:MatchUserID()=='0' -->
            <li><img data-bind="attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoProfilePage }" /></li>
            <!-- /ko -->
            <!-- /ko -->
            <!-- ko if:(MatchType()=='3'  && IsLastMatch()) -->
            <!-- ko ifnot:MatchUserID()=='0' -->
            <li><img data-bind="attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoProfilePage }" /></li>
            <!-- /ko -->
            <!-- /ko -->
        </ul>
    </div>
    <span class="clear"></span>
</script>

<script type="text/javascript">


    function VMCurrentMatchs(_in) {
        var self = this;
        self.MatchUserID = ko.observable(_in.MatchUserID);
        self.MatchType = ko.observable(_in.MatchType);
        self.MatchedDate = ko.observable(_in.MatchedDate);
        self.PhotoUrl = ko.observable(_in.PhotoUrl);
        self.UserName = ko.observable(_in.UserName);
        self.OnlyDate = ko.computed(function () {
            var _ThisDate = new Date(self.MatchedDate());
            var _ThisMonth = eval(_ThisDate.getMonth() + 1);
            if (_ThisMonth < 10) {
                _ThisMonth = "0" + _ThisMonth;
            }
            var _FormattedDate = _ThisMonth + "-" + _ThisDate.getDate() + "-" + _ThisDate.getFullYear();
            return _FormattedDate;
        }, this);

        self.IsLastMatch = ko.observable(_in.IsLastMatch);

        self.timer = ko.observable();

        var _TimeOutSecns;
        var _TodayDate = new Date();
        _TodayDate = new Date(_TodayDate.getFullYear(), _TodayDate.getMonth(), _TodayDate.getDate(), _TodayDate.getHours(), _TodayDate.getMinutes(), _TodayDate.getSeconds());
        if (_TodayDate.getHours() < 12) {
            var _EndDate = new Date(_TodayDate.getFullYear(), _TodayDate.getMonth(), _TodayDate.getDate(), 11, 59, 59);
            _TimeOutSecns = getSecoundsBitweenTowTimes(_EndDate, _TodayDate);

        } else {
            var _NowDate = new Date();
            var _TomorrowDate = new Date(_TodayDate.setDate(_TodayDate.getDate() + 1));
            var _EndDate = new Date(_TomorrowDate.getFullYear(), _TomorrowDate.getMonth(), _TomorrowDate.getDate(), 12, 00, 00);
            _TimeOutSecns = getSecoundsBitweenTowTimes(_EndDate, _NowDate);
        }
        _TimeOutSecns = Math.round(_TimeOutSecns);

        self.ShowTimer = ko.observable(_TimeOutSecns);

        setInterval(function () {
            self.ShowTimer(eval(self.ShowTimer() - 1));
            // alert(newTimer);
            var _GetTimerText = SetCountdownText(self.ShowTimer())
            self.timer(_GetTimerText);
        }, 1000);

    }


    function VMCurrentMatchsList(_list) {
        var self = this;
        self.AllMatchs = ko.observableArray();
        self.UserMatchTypeOne = ko.observable(false);
        self.UserMatchTypeTwo = ko.observable(false);
        self.UserMatchTypeThree = ko.observable(false);
        for (var i = 0; i < _list.length; i++) {
            self.AllMatchs.push(new VMCurrentMatchs(_list[i]));
            if (_list[i].MatchUserID != 0) {
                if (_list[i].MatchType == 1) {
                    self.UserMatchTypeOne(true);
                }
                if (_list[i].MatchType == 2) {
                    self.UserMatchTypeTwo(true);
                }
                if (_list[i].MatchType == 3) {
                    self.UserMatchTypeThree(true);
                }
            }
        }


        GoProfilePage = function (_data) {
            window.location.href = _SitePath + "web/Profile?" + _data.UserName() + "#criteria";
        }

    }




    function GetUserPhoto(UserID) {
        var _UserData = new Object();
        _UserData.UserID = UserID;
        var Photo_API = _SitePath + "api/GetUserImageUrl";
        $.postDATA(Photo_API, _UserData, function (_return) {
            return _return;
        });
    }

    function SetCountdownText(seconds) {
        //store:
        _currentSeconds = seconds;

        //get minutes:
        var minutes = parseInt(seconds / 60);

        //shrink:
        seconds = (seconds % 60);

        //get hours:
        var hours = parseInt(minutes / 60);

        //shrink:
        minutes = (minutes % 60);

        //build text:
        //	var strText = AddZero(hours) + ":" + AddZero(minutes) + ":" + AddZero(seconds);
        var strText = AddZero(hours) + ":" + AddZero(minutes) + ":" + AddZero(seconds);
        //apply:
        return strText;

    }

    function AddZero(num) {
        return ((num >= 0) && (num < 10)) ? "0" + num : num + "";
    }

    function getSecoundsBitweenTowTimes(start, end) {
        var dif = start.getTime() - end.getTime()
        var _insecounds = dif / 1000;
        return _insecounds;
    }




</script>
