<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_todaymatch.ascx.cs" Inherits="IntelliWebR1.web.ko.template_todaymatch" %>




<script type="text/html" id="template_todaymatch">

   
        <div class="six_profile_info_lt">
            <h1>Today's Match</h1>
            <img data-bind="attr: { 'src': PicUrl, 'title': UserName }, event: { 'click': GoProfilePage }" style="cursor:pointer;"/>
            <h3 data-bind="text: UserName"></h3>
        </div>
        <div class="six_profile_info_rt">
            <div class="overall_scrore">
                <img data-bind="attr: { 'src': OverallMatchpUrl }, event: { 'click': GoProfilePage }" style="width: 220px;cursor:pointer;" />
            </div>
            <span class="clear"></span>
            <div class="six_work">
                <div class="six_teacher_wrkflow">
                    <img data-bind="attr: { 'src': CriteriaMatchpUrl }, event: { 'click': GoProfilePage }" style="width: 130px;cursor:pointer;" />
                    <h3>Criteria</h3>
                </div>
                <div class="six_teacher_wrkflow">
                    <img data-bind="attr: { 'src': QuestionsMatchpUrl }, event: { 'click': GoProfileQuestionPage }" style="width: 130px;cursor:pointer;" />
                    <h3>Questions</h3>
                </div>
                <span class="clear"></span>
            </div>
        </div>
        <span class="clear"></span>
    
</script>

<script type="text/javascript">

    function VMTodaysMatch(_in) {
        var self = this;
        self.MatchUserID = ko.observable(_in.MatchUserID);
        self.UserName = ko.observable(_in.UserName);
        self.PicUrl = ko.observable(_in.PicUrl);
        self.OverallMatchp = ko.observable(_in.OverallMatchp);
        self.CriteriaMatchp = ko.observable(_in.CriteriaMatchp);
        self.QuestionsMatchp = ko.observable(_in.QuestionsMatchp);

        self.OverallMatchpUrl = ko.computed(function () {
            return _SitePath + "web/service/OverallMatchImage?o=y&p=" + self.OverallMatchp();
        }, this);

        self.CriteriaMatchpUrl = ko.computed(function () {
            return _SitePath + "web/service/OverallMatchImage?p=" + self.CriteriaMatchp();
        }, this);

        self.QuestionsMatchpUrl = ko.computed(function () {
            return _SitePath + "web/service/OverallMatchImage?p=" + self.QuestionsMatchp();
        }, this);

        GoProfilePage = function (_data) {
            window.location.href = _SitePath + "web/Profile?" + _data.UserName() + "#criteria";
        };

        GoProfileQuestionPage = function (_data) {
            if (_data.QuestionsMatchp() != "-1") {
                window.location.href = _SitePath + "web/Profile?" + _data.UserName() + "#questions";
            } else {
                window.location.href = _SitePath + "web/Profile?" + _data.UserName() + "#criteria";
            }
        };

    }

</script>
