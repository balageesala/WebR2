<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofilerankorder.aspx.cs" Inherits="IntelliWebR1.web.inner.myprofilerankorder" %>

<style type="text/css">
    .txt-area {
        margin-left: 25px;
        border: 1px solid #AAAAAA;
        width: 26px;
        height: 24px;
        font-size: 1em;
        text-align: center;
        margin-top: 0px;
        margin-left: 8px;
    }

    .divprofile-temp {
        margin-top: 0px;
    }

    .rank-title {
        color: #2d2929;
        font-size: 1.15em;
        margin-left: 75px;
        margin-bottom: 0px;
        margin-top: -28px;
    }
</style>

<div id="divRankOrder" class="twelve_cont"  data-bind="template: { name: 'template_rankorder', foreach: AllAnswers }"></div>

<script type="text/html" id="template_rankorder">
    <div class="divprofile-temp">
        <input type="text" class="txt-area txtPriority" maxlength="4" data-bind="value: RankOrder, valueUpdate: 'keyup', attr: { 'data-Answer_id': _id, 'data-rankorder': OldRankOrder }, event: { keyup: ValidateNumber, blur: UpDateRankOrder }" placeholder="0">
    </div>
    <div class="object" style="width:57%;" data-bind="text: QuestionDetails().QuestionText"></div>
    <span class="clear"></span>
</script>

<script type="text/javascript">

    $(document).ready(function () {
        var _api = _SitePath + "api/RankOrderQA";
        $.getDATA(_api, function (_data) {
            //alert(JSON.stringify(_data));
            ko.applyBindings(new QuestionAnswerListVM(_data), document.getElementById("divRankOrder"));
        }, function () { });
    });


    function QuestionsVM(_in) {
        var self = this;
        self._id = ko.observable(_in._id);
        self.QuestionID = ko.observable(_in.QuestionID);
        self.QuestionText = ko.observable(_in.QuestionText);
        self.QuestionCategory = ko.observable(_in.QuestionCategory);
        self.OptionsQuestion = ko.observable(_in.OptionsQuestion);
        self.PreferenceQuestion = ko.observable(_in.PreferenceQuestion);
        self.OptionType = ko.observable(_in.OptionType);
        self.PreferenceType = ko.observable(_in.PreferenceType);

    }




    function QuestionAnswerVM(_in) {

        var self = this;
        self._id = ko.observable(_in._id);
        self.UserID = ko.observable(_in.UserID);
        self.Question_id = ko.observable(_in.Question_id);
        self.QuestionDetails = ko.observable(new QuestionsVM(_in.QuestionDetails));
        self.OptionAnswerText = ko.observable(_in.OptionAnswerText);
        self.PreferenceAnswerText = ko.observable(_in.PreferenceAnswerText);
        self.NonPreferenceAnswerText = ko.observable(_in.NonPreferenceAnswerText);
        self.Rating = ko.observable(_in.Rating);
        self.Comment = ko.observable(_in.Comment);
        self.AnsweredPrivately = ko.observable(_in.AnsweredPrivately);
        self.TimeStamp = ko.observable(_in.TimeStamp);
        self.EditedDate = ko.observable(_in.EditedDate);
        self.RankOrder = ko.observable(_in.RankOrder);
        self.OldRankOrder = ko.observable(_in.RankOrder);
    }

    function QuestionAnswerListVM(_in) {
        var self = this;
        self.AllAnswers = ko.observableArray();

        for (var i = 0; i < _in.length; i++) {
            self.AllAnswers.push(new QuestionAnswerVM(_in[i]));
        }

        UpDateRankOrder = function (_data) {

            var _EnteredRankOrder = _data.RankOrder();
            if (_EnteredRankOrder == "" || _EnteredRankOrder == "0") {
                alert("Please enter a number");
                return;
            }
            else {
                var API_RankOrder = _SitePath + "api/SetRankOrder";
                var _max = GetMaxCount();
                if (_EnteredRankOrder > _max) {
                    _EnteredRankOrder = eval(_max);
                }

                var _RankObject = new Object();
                _RankObject.Answer_id = _data._id();
                _RankObject._RankOrder = _EnteredRankOrder;

                $.postDATA(API_RankOrder, _RankObject, function (_ret) {
                    RebindRankOrder();
                });
            }




        }

        ValidateNumber = function (_data) {
            var _valueEntered = _data.RankOrder();
            var _oldRank = _data.OldRankOrder();
            if (isNaN(_valueEntered) == true) {
                alert("Please enter a number");
                _data.RankOrder(_oldRank);
                return;
            }
        }


        GetMaxCount = function () {
            return self.AllAnswers().length;
        };


        RemoveAndReBindRankOrder = function (_data) {
            self.AllAnswers.removeAll();
            for (var i = 0; i < _data.length; i++) {
                self.AllAnswers.push(new QuestionAnswerVM(_data[i]));
            }
        }



        RebindRankOrder = function () {
            var _APIGetRankOrder = _SitePath + "api/RankOrderQA";
            $.getDATA(_APIGetRankOrder, function (_List) {
                RemoveAndReBindRankOrder(_List);
            }, function () { });
        }



    }




</script>


<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>