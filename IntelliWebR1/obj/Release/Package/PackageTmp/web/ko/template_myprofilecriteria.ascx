<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_myprofilecriteria.ascx.cs" Inherits="IntelliWebR1.web.ko.template_myprofilecriteria" %>
<script type="text/html" id="template_myprofilecriteria">
    <div class="ninth_head">
        <ul>
            <li class="grade">Points</li>
            <li class="subject">Category</li>
            <li class="question">Your Answer</li>
            <li class="correct">Acceptable Answer(s)</li>
            <li class="incorrect">Unacceptable Answer(s)</li>
        </ul>
        <span class="clear"></span>
    </div>
    <div data-bind="foreach: AllCriteriaQuestions">
        <div class="ninth_info" >
        <ul>
            <li class="grade">
                <!--ko ifnot:HasAllPreferencesSelected -->
                <!--ko if:IsDeleted -->
                <input type="text" disabled="disabled" />
                <!--/ko-->
                <!--ko ifnot:IsDeleted -->
                <input type="text" class="points" data-bind="value: UserAssignedPoints, attr: { 'data-criteriaid': Criteria_id }" maxlength="3" required="required" />
                <!--/ko-->
                <!--/ko-->
                <!--ko if:HasAllPreferencesSelected -->
                <input type="text" disabled="disabled" />
                <!--/ko-->
            </li>
            <li class="subject editCriteria" data-bind="text: CriteriaName, attr: { 'data-url': CriteriaEditUrl }" data-width="700" data-height="450"></li>
            <!--ko if:IsNoMyAnswer -->
            <li class="question editCriteria" style="color: red;" data-bind="text: MyAnswer, attr: { 'data-url': CriteriaEditUrl }" data-width="700" data-height="450">I have never been in a relationship</li>
            <!--/ko-->
            <!--ko ifnot:IsNoMyAnswer -->
            <li class="question editCriteria" data-bind="text: MyAnswer, attr: { 'data-url': CriteriaEditUrl }" data-width="700" data-height="450">I have never been in a relationship</li>
            <!--/ko-->
            <!--ko if:IsNoAcceptAnswers -->
            <li class="correct editCriteria" style="color: red;" data-bind="html: AcceptableAnswersBind, attr: { 'data-url': CriteriaEditUrl }" data-width="700" data-height="450"></li>
            <!--/ko-->
            <!--ko ifnot:IsNoAcceptAnswers -->
            <li class="correct editCriteria" data-bind="html: AcceptableAnswersBind, attr: { 'data-url': CriteriaEditUrl }" data-width="700" data-height="450"></li>
            <!--/ko-->
            <li class="incorrect editCriteria" style="color: red;" data-bind="html: UnacceptableAnswersBind, attr: { 'data-url': CriteriaEditUrl }" data-width="700" data-height="450"></li>
            <li class="calendar">
                <!--ko ifnot:IsDeleted-->
                <a data-bind="event: { click: DeleteCriteriaAnswer }" style="cursor:pointer;">C</a>
                <!--/ko-->
                <!--ko if:IsEdited-->
                <a style="cursor:pointer;"><img src="images/09_cont_calen.png" width="15" height="16" alt="calendar" data-bind="attr: { title: LocalTime }" /></a>
                <!--/ko-->   
            </li>
        </ul>
        </div>
    </div>
</script>


<script type="text/javascript">

    function VMMyProfileCriteria(_ln) {
        var self = this;
        self._id = ko.observable(_ln._id);
        self.Criteria_id = ko.observable(_ln.Criteria_id);
        self.UserAssignedPoints = ko.observable(_ln.UserAssignedPoints);
        self.CriteriaName = ko.observable(_ln.CriteriaName);
        self.MyAnswer = ko.observable(_ln.MyAnswer);
        self.AcceptableAnswers = ko.observable(_ln.AcceptableAnswers);
        self.UnacceptableAnswers = ko.observable(_ln.UnacceptableAnswers);
        self.IsAnswred = ko.observable(_ln.IsAnswred);
        self.IsEdited = ko.observable(_ln.IsEdited);
        self.EditableDate = ko.observable(_ln.EditableDate);
        self.Status = ko.observable(_ln.Status);
        self.HasAllPreferencesSelected = ko.observable(_ln.HasAllPreferencesSelected);

        self.LocalTime = ko.computed(function () {
            return new Date(self.EditableDate());
        }, this);

        self.CriteriaEditUrl = self.CriteriaEditUrl = ko.computed(function () {
            return _SitePath + "web/inner/criteriaedit?c=" + self.Criteria_id();
        }, this);


        self.UnacceptableAnswersNone = ko.computed(function () {
            if (self.UnacceptableAnswers() == "" || self.UnacceptableAnswers() == null) {
                return "none";
            } else {
                return self.UnacceptableAnswers();
            }
        }, this);


        self.UnacceptableAnswersBind = ko.computed(function () {


            if (self.UnacceptableAnswers() == "" || self.UnacceptableAnswers() == null) {
                return "<span style='color:#000;'>none</span>";
            } else if (self.HasAllPreferencesSelected()) {
                  var _Answers = new Array();
                  _Answers =  self.UnacceptableAnswers().split(',');
                  var AnswerHtml = "";
                  for (var i = 0; i < _Answers.length; i++) {
                     
                          AnswerHtml ="<div>" +AnswerHtml + "</div><div>" + _Answers[i]+"</div>";
                  }
                  return AnswerHtml;
            }
            else {

                var _Answers = new Array();
                _Answers = self.UnacceptableAnswers().split(',');
                var AnswerHtml = "";
                for (var i = 0; i < _Answers.length; i++) {
                    AnswerHtml = "<div>" + AnswerHtml + "</div><div>" + _Answers[i] + "</div>";
                }
                return AnswerHtml;
            }
        }, this);

        self.AcceptableAnswersBind = ko.computed(function () {
            var _Answers = new Array();
            _Answers = self.AcceptableAnswers().split(',');
            var AnswerHtml = "";
            for (var i = 0; i < _Answers.length; i++) {
                AnswerHtml = "<div>" + AnswerHtml + "</div><div>" + _Answers[i] + "</div>";
            }
            return AnswerHtml;
        }, this);

        self.CalenderIconPath = ko.computed(function () {
            return _SitePath + "web/images/calender_item.png";
        }, this);

        self.DeleteIconPath = ko.computed(function () {
            return _SitePath + "web/images/close.png";
        }, this);


        self.CommentIconPath = ko.computed(function () {
            return _SitePath + "web/images/comment_item.png";
        }, this);

        self.PrivacyIconPath = ko.computed(function () {
            return _SitePath + "web/images/privacy_item.png";
        }, this);

        self.IsNoMyAnswer = ko.computed(function () {
            if (self.MyAnswer() == "No answer") {
                return true;
            } else {
                return false;
            }
        }, this);

        self.IsNoAcceptAnswers = ko.computed(function () {
            if (self.AcceptableAnswers() == "No answer") {
                return true;
            } else {
                return false;
            }
        }, this);



        self.IsDeleted = ko.computed(function () {

            if (self.IsAnswred()) {
                if (self.Status() != "I") {
                    return false;
                } else {
                    return true;
                }
            }
            else {
                return true;
            }


        }, this);

    }

    function VMMyProfileCriteriaList(_list) {
        var self = this;
        self.AllCriteriaQuestions = ko.observableArray();
        self.IsSubmit = ko.observable(false);

        for (var i = 0; i < _list.length; i++) {
            self.AllCriteriaQuestions.push(new VMMyProfileCriteria(_list[i]));
        }

        DeleteCriteriaAnswer = function (_data) {

            var _ClearCriteriaAPI = _SitePath + "api/ClearCriteria";
            var _ClearCriteriaObject = new Object();
            _ClearCriteriaObject.Criteria_id = _data.Criteria_id();

            $.postDATA(_ClearCriteriaAPI, _ClearCriteriaObject, function (_return) {
                if (_return) {
                    RemoveAndReBindCriteria();
                }
            });


        };

        RemoveAndReBindData = function (_list) {

            self.AllCriteriaQuestions.removeAll();

            for (var i = 0; i < _list.length; i++) {
                self.AllCriteriaQuestions.push(new VMMyProfileCriteria(_list[i]));
            }
        };

        RemoveAndReBindCriteria = function () {

            var APIGET_CRITERIA = _SitePath + "api/GetMyProfileCriteriaList";

            $.getDATA(APIGET_CRITERIA, function (_data) {
                if (_data != null) {
                    RemoveAndReBindData(_data);
                }

                $(".editCriteria").click(function (e) {
                    SetIntelliWindow(this, e);
                });

            });


        }


        SubmitPoints = function () {

            var _pointsArray = new Array();
            var _pointObject = new Object();

            $(".points").each(function (_pos, _obj) {
                _pointObject = new Object();
                _pointObject.Criteria_id = $(_obj).data("criteriaid");
                _pointObject.PointsAssigned = $(_obj).val();
                _pointsArray.push(_pointObject);
            });

            // get allotted points
            var _pointsAssigned = _pointsArray;
            //console.log(_pointsAssigned);

            var _QuestionIDs = new Array();
            var _Points = new Array();

            for (var i = 0; i < _pointsAssigned.length; i++) {
                _QuestionIDs.push(_pointsAssigned[i].Criteria_id);
                _Points.push(_pointsAssigned[i].PointsAssigned);
            }

            var _CriteriaPoints = new Object();

            var _sQuestionIDs = "";
            for (var i = 0; i < _QuestionIDs.length; i++) {
                _sQuestionIDs = _sQuestionIDs + "," + _QuestionIDs[i];
            }
            _sQuestionIDs = _sQuestionIDs.substr(1);

            var _sPoints = "";
            for (var i = 0; i < _Points.length; i++) {
                _sPoints = _sPoints + "," + _Points[i];
            }
            _sPoints = _sPoints.substr(1);

            _CriteriaPoints.CriteriaQuestionIDs = _sQuestionIDs;
            _CriteriaPoints.Points = _sPoints;

            //console.log(_CriteriaPoints);

            var _assignPointsAPI = _SitePath + "api/CriteriaPoints";
            $.postDATA(_assignPointsAPI, _CriteriaPoints, function (_return) {

                RemoveAndReBindCriteria();
                $("#divPointsResult").html("Points assigned successfully.");

            });


        };

        SetPoints = function (_item) {

            var _Points = _item.UserAssignedPoints();
            if (_item.UserAssignedPoints() == "") {
                _item.UserAssignedPoints(0);
            }
            //validate points
            var _getPoints = 0;
            for (var i = 0; i < self.AllCriteriaQuestions().length; i++) {
                var _Totalpoints = eval(self.AllCriteriaQuestions()[i].UserAssignedPoints());
                _getPoints = _getPoints + _Totalpoints;
            }
            if (_getPoints > 100) {
                self.PointsRemining(eval(100 - _getPoints));
                self.IsSubmit(false);
                return false;
            } else {
                self.PointsRemining(eval(100 - _getPoints));
                if (_getPoints == 100) {
                    self.IsSubmit(true);
                } else {
                    self.IsSubmit(false);
                }
            }
        };

    }


    function validateFloatKeyPress(el, evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        var number = el.value.split('.');
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        //get the carat position
        var caratPos = getSelectionStart(el);
        var dotPos = el.value.indexOf(".");
        if (caratPos > dotPos && dotPos > -1 && (number[1].length > 1)) {
            return false;
        }
        return true;
    }

</script>
