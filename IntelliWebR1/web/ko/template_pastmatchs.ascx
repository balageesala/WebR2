<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_pastmatchs.ascx.cs" Inherits="IntelliWebR1.web.ko.template_pastmatchs" %>

<script type="text/html" id="template-pastmatchs">
      <h2>Past
            <br />
            matches</h2>
        <div class="twenty_six_past">
            <ul class="row1" data-bind="foreach: AllPastMatchs">
                <!-- ko ifnot:IsRematched() -->
                <li><small data-bind="text: FMatchedDate"></small><img data-bind="    attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoMatchProfilePage }"  /><a href="#" data-bind="event: { 'click': RematchThisMatch }"">Rematch</a></li>
                <!-- /ko -->
                <!-- ko if:IsRematched() -->
                <li><small data-bind="text: FMatchedDate"></small><img data-bind="    attr: { 'src': PhotoUrl, 'title': UserName }, event: { 'click': GoMatchProfilePage }" /><b  data-bind="    text: FRematchedDate"></b></li>
                <!-- /ko -->
            </ul>
        </div>
</script>

<script type="text/javascript">

    function VMPastMatchs(_in) {
        var self = this;
        self.MatchUserID = ko.observable(_in.MatchUserID);
        self.MatchType = ko.observable(_in.MatchType);
        self.MatchedDate = ko.observable(_in.MatchedDate);
        self.PhotoUrl = ko.observable(_in.PhotoUrl);
        self.RematchedDate = ko.observable(_in.RematchedDate);
        self.IsRematched = ko.observable(_in.IsRematched);
        self.UserName = ko.observable(_in.UserName);
        
        self.FMatchedDate = ko.computed(function () {
            var _ThisDate = new Date(self.MatchedDate());
            var _FormattedDate = (_ThisDate.getMonth() + 1) + "-" + _ThisDate.getDate() + "-" + _ThisDate.getFullYear();
            return _FormattedDate;
        }, this);

        self.FRematchedDate = ko.computed(function () {
            if (self.IsRematched()) {
                var _ThisDate = new Date(self.RematchedDate());
                var _FormattedDate = (_ThisDate.getMonth() + 1) + "-" + _ThisDate.getDate() + "-" + _ThisDate.getFullYear();
                return _FormattedDate;
            } else {
                return "";
            }
        }, this);

    }

    function VMPastMatchsList(_list) {
        var self = this;
        self.AllPastMatchs = ko.observableArray();
        for (var i = 0; i < _list.length; i++) {
            self.AllPastMatchs.push(new VMPastMatchs(_list[i]));
        }

        GoMatchProfilePage = function (_Data) {
            window.location.href = _SitePath + "web/MatchProfile?" + _Data.UserName();
        }

        RematchThisMatch = function (_Data) {
            var _rematchurl = _SitePath + "web/inner/rematchuser?RematchID=" + _Data.MatchUserID();
            SetUrlIntelliWindow(_rematchurl, "640", "300");
        }

    }

</script>
