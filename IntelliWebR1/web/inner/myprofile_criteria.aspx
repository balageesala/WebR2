<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofile_criteria.aspx.cs" Inherits="IntellidateR1Web.web.inner.myprofile_criteria" %>


 
<asp:literal id="ltScripts" runat="server"></asp:literal>

<div id="divMyProfileCriterias" data-bind="template: { name: 'template_myprofilecriteria' }"></div>

<script type="text/html" id="template_myprofilecriteria">
<div style="padding-top: 10px;">
    <div style="padding-top: 10px;display:inline-block;text-align:right;position: absolute;margin-top: -69px;pointer-events:none;">
        <div style="float:left;width:952px;">&nbsp;</div>
        <div style="float:left;width: 340px; height: 60px; border: 0px solid;">
            <div style="float: left; font-size: 22px;margin:15px;">Points Remaining</div>
            <div style="float: left;margin:18px;margin-left:-10px;margin-top:14px;">
                <input type="text" id="txtPointsLeft"  data-bind="value: PointsReminingSelf" disabled="disabled" style="width: 50px;height: 24px;font-size: 20px;" /></div>
            <div style="float: left;margin-left: -20px;margin-top: 2px;pointer-events:all;">
                <!--ko if:IsSubmit-->
                <div class="SubmitButtonSmall FloatRight" id="btnSubmit"  data-bind="click: SubmitPoints" >
                    <div>Submit</div>
                </div>
                 <!--/ko-->
            </div>
        </div>
    </div>
    <div style="height:10px;font-size:12px;text-align:left;width:1320px;margin-top: 8px;" id="divPointsResult">&nbsp;</div>
    <div style="width: 1320px; min-height: 500px; border-top: 0px solid #B6B6B6; padding-top: 10px;">
        <div style="width: 100%; height: 32px; background-color: #C1282D">
            <div style="float: left; width: 68px; color: #F7F9FF; padding: 4px; text-align: left;">Points</div>
            <div style="float: left; width: 200px; color: #F7F9FF; padding: 4px; text-align: left;">Category</div>
            <div style="float: left; width: 300px; color: #F7F9FF; padding: 4px; text-align: left;">My Answer</div>
            <div style="float: left; width: 300px; color: #F7F9FF; padding: 4px; text-align: left;">Acceptable Answer(s)</div>
            <div style="float: left; width: 300px; color: #F7F9FF; padding: 4px; text-align: left;">Unacceptable Answer(s)</div>
            <div style="float: left; width: 32px; color: #F7F9FF; padding: 4px; text-align: center;"><img id="imgCalenderTitle" runat="server" src="images/calender_title.png" /></div>
            <div style="float: left; width: 20px; color: #F7F9FF; padding: 4px; text-align: center;"><img id="imgDeleteTitle" style="float: left; width: 20px;height:20px;" runat="server" src="images/close_white.png" /></div>  
    </div>
        <div style="clear:both;"></div>
        
        
    <div  data-bind = "foreach: AllCriteriaQuestions ">
    <div style="width: 100%; min-height: 32px; border-bottom: 1px solid #95746D;display:inline-block;">
        <div style="float: left; width: 68px; padding: 4px;text-align:center;">
           <!--ko ifnot:HasAllPreferencesSelected -->
            <!--ko if:IsDeleted -->
            <input type="text" style="width: 42px;" disabled="disabled" />
            <!--/ko-->
            <!--ko ifnot:IsDeleted -->
            <input type="text" style="width: 42px;" class="points" data-bind="value: UserAssignedPoints, attr: { 'data-criteriaid': Criteria_id }, event: { 'blur': SetPoints }" onkeypress="return validateFloatKeyPress(this,event);" maxlength="5" required="required" />
            <!--/ko-->
            <!--/ko-->
           <!--ko if:HasAllPreferencesSelected -->
            <input type="text" style="width: 42px;" disabled="disabled" />
            <!--/ko-->
        </div>
        <div class="editCriteria" style="float: left; cursor:pointer; width: 200px; padding: 6px; text-align: left; font-size: 12px;" data-bind="text: CriteriaName, attr: { 'data-url': CriteriaEditUrl }" data-width="920" data-height="620"></div>
         <!--ko if:IsNoMyAnswer -->
        <div class="editCriteria" style="float: left; cursor:pointer; width: 300px; padding: 4px; text-align: left; font-size: 12px;color:red;" data-bind="text: MyAnswer, attr: { 'data-url': CriteriaEditUrl }" data-width="920" data-height="620"></div>
        <!--/ko-->

         <!--ko ifnot:IsNoMyAnswer -->
        <div class="editCriteria" style="float: left; cursor:pointer; width: 300px; padding: 4px; text-align: left; font-size: 12px;" data-bind="text: MyAnswer, attr: { 'data-url': CriteriaEditUrl }" data-width="920" data-height="620"></div>
        <!--/ko-->
         <!--ko if:IsNoAcceptAnswers -->
         <div class="editCriteria" style="float: left; cursor:pointer; width: 300px; padding: 4px; text-align: left; font-size: 12px;color:red;" data-bind="text: AcceptableAnswersBind, attr: { 'data-url': CriteriaEditUrl }" data-width="920" data-height="620"></div>
        <!--/ko-->

          <!--ko ifnot:IsNoAcceptAnswers -->
         <div class="editCriteria" style="float: left; cursor:pointer; width: 300px; padding: 4px; text-align: left; font-size: 12px;" data-bind="text: AcceptableAnswersBind, attr: { 'data-url': CriteriaEditUrl }" data-width="920" data-height="620"></div>
        <!--/ko-->


        <div class="editCriteria" style="float: left; cursor:pointer; width: 300px; padding: 4px; text-align: left; font-size: 12px;color:red;" data-bind="html: UnacceptableAnswersBind, attr: { 'data-url': CriteriaEditUrl }" data-width="920" data-height="620" ></div>
        
         <!--ko if:IsEdited-->
         <div style="float: left; width: 40px;text-align:center;">
         <img  style="cursor:pointer;" data-bind="attr: { src: CalenderIconPath, title: LocalTime }" />
         </div>
          <!--/ko-->
            <!--ko ifnot:IsEdited-->
        <div style="float: left; width: 40px;text-align:center;">&nbsp;</div>
         <!--/ko-->
         <!--ko ifnot:IsDeleted-->
        <div style="float: left; width: 20px;text-align:center;cursor:pointer;" data-bind="event: { click: DeleteCriteriaAnswer }">
         <img  style="float: left; width: 20px;height:20px;" data-bind="attr: { src: DeleteIconPath }" />
         </div>
         <!--/ko-->
         <!--ko if:IsDeleted-->
        <div style="float: left; width: 20px;text-align:center;cursor:pointer;">
         &nbsp;    
        </div>
         <!--/ko-->

       </div>
    <div style="clear:both;"></div>
   </div> 
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
                return self.UnacceptableAnswers();
            }
            else {
                return self.UnacceptableAnswers();
            }
        }, this);

        self.AcceptableAnswersBind = ko.computed(function () {
                      return self.AcceptableAnswers();
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

        self.PointsRemining = ko.observable(0);
        self.IsSubmit = ko.observable(false);

        self.PointsReminingSelf = ko.computed(function () {
            if (self.PointsRemining() == 0) {
                var _points = 0;
                for (var i = 0; i < _list.length; i++) {
                    _points = _points + eval(_list[i].UserAssignedPoints);
                }
                var _remining = 100 - _points;
                self.PointsRemining(_remining);
                return self.PointsRemining();
            } else {
                return self.PointsRemining();
            }
        }, this);

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


    $(document).ready(function () {

        var APIGET_CRITERIA = _SitePath + "api/GetMyProfileCriteriaList";

        $.getDATA(APIGET_CRITERIA, function (_data) {

            // alert(JSON.stringify(_data));

            ko.applyBindings(new VMMyProfileCriteriaList(_data), document.getElementById("divMyProfileCriterias"));
            $(".editCriteria").click(function (e) {
                SetIntelliWindow(this, e);
            });
        });

    });

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



<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>