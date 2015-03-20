<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="answerquestion.aspx.cs" Inherits="IntelliWebR1.web.inner.answerquestion" %>


<!DOCTYPE html>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.0.0.js" type="text/javascript"></script>


<style type="text/css">
    body {
        background-color: none;
        background: none;
        font-family: Tahoma, sans-serif, Arial;
    }

    .SubmitButton div {
        padding-top: 8px;
        font-size: 18px;
        text-transform: uppercase;
        -webkit-touch-callout: none;
        -webkit-user-select: none;
        -khtml-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    .SubmitButtonSmall {
        width: 78px;
        height: 34px;
        background-color: #C1282D;
        color: #ffffff;
        text-align: center;
        border-radius: 4px 4px;
        margin: 10px;
        cursor: pointer;
    }

    .FloatRight {
        float: right;
    }

    .Disabled {
        background-color: #999;
    }
</style>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<html>
    <body>

        <div class="popupqtn">
     <div style="height:12px;"><a class="close closeButton" id="btnClose">x</a></div>
     <input type="hidden" id="hdnRating" />
    <div id="divNewQuestion" class="four eleven_middle"  data-bind="template: { name: 'template_myprofilequestions' }">
    </div>
</div>

    </body>


</html>


<script type="text/html" id="template_myprofilequestions">
   
    <div class="tabs_matter tableft" data-bind="animate: position()">
        <h2 data-bind="text: QuestionText"></h2>
        <div class="tabs_left" style="width: 280px;margin:0px;">
            <h5 data-bind="text: OptionsQuestion"></h5>
            <ul>
                <!--ko foreach:OptionElements().Options-->
                <li style="width: 280px;">
                    <input type="radio" data-bind="attr: { id: OptionCheckID, value: _id }" class="philosophyOptions" name="philosophyOptions" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label>
                </li>
                <!--/ko-->

            </ul>
        </div>
        <div class="tabs_left marg_no" style="width: 280px;">
            <h5 data-bind="text: PreferenceQuestion"></h5>
            <ul>
                <!--ko foreach:PreferenceElements().Options-->
                <li style="width: 280px;">
                    <input type="checkbox" data-bind="attr: { id: OptionPrefCheckID, value: _id }" class="philosophyPrefOptions" name="philosophyPrefOptions" /><label data-bind="    attr: { 'for': OptionPrefCheckID }, text: OptionText"></label>
                </li>
                <!--/ko-->
                <!--ko if:PreferenceElements().HasSelectAllText-->
                <li style="width: 280px;">
                    <input type="checkbox" id="chkSelectAll" /><label for="chkSelectAll" data-bind="text: PreferenceElements().SelectAllText"></label>
                </li>
                <!--/ko-->
            </ul>
        </div>
        <div class="clear"></div>
        <div class="input select rating-c">
            <select id="example-c" class="selectexample-c" name="rating">
                <option value=""></option>
                <option value="0">0</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
                <option value="8">8</option>
                <option value="9">9</option>
                <option value="10">10</option>
            </select>
        </div>
        <!--ko if:QuestionCategory() == '0'-->
        <div style="float:left;width:561px;">
        <div class="comment">
            <textarea id="txtComment" placeholder="Comments (optional)" onkeyup="autoGrow(this);"></textarea>
        </div>
        <div class="check">
            <label>
                <input type="checkbox" id="chkAnswerPrivately">
                Keep Private
            </label>
        </div>
            </div>
        <!--/ko-->
        <div class="clear"></div>
    </div>
    <div class="buttons" style="margin-top:10px;">
        <input type="button" class="btnsubmit Disabled" disabled="disabled" style="border: 0px;cursor:pointer;" value="Submit" id="btnSubmit" data-bind="event: { click: SubmtClick }" />
    </div>
</script>




<script type="text/javascript">

    var _SitePath = window.parent._SitePath;
    $(document).ready(function () {

       // alert(_SitePath);

        var _API_NEWQTN = _SitePath + "api/GetUnAnswredQuestion";
        var _QuestionObj = new Object();
        _QuestionObj.Question_id = getParameterByName("qid");
        $.postDATA(_API_NEWQTN, _QuestionObj, function (_ret) {
            ko.applyBindings(new QuestionsVM(_ret), document.getElementById("divNewQuestion"));

            PostLoadQuestion();
            bindBarRattingWithValue("0");


            $(".closeButton").click(function () {
                window.parent.CloseIntelliWindow();
            });

        });

        PostLoadQuestion();
       

        $(".closeButton").click(function () {
            window.parent.CloseIntelliWindow();
        });




    });

    function bindBarRatting() {

        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('show', {
                showValues: true,
                showSelectedRating: false,
                onSelect: function (value, text) {
                    SetButtonStatus();
                    $("#hdnRating").val(value);
                }
            });
            $('.rating-enable').trigger('click');
        });
    }


    function bindBarRattingWithValue(_RattingValue) {

        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('show', {
                initialRating: _RattingValue,
                showValues: true,
                showSelectedRating: false,
                onSelect: function (value, text) {
                    SetButtonStatus();
                    $("#hdnRating").val(value);
                }
            });
            $('.rating-enable').trigger('click');
        });
    }

    function DistroyRating() {
        SetButtonStatus();
        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('destroy');
            $(_obj).hide();
        });
        $("#hdnRating").val("0");
    }

    function ClearBarRatting() {
        $('.selectexample-c').each(function (e, _obj) {
            $(_obj).barrating('destroy');
            $(_obj).barrating('show', {
                initialRating: " ",
                showValues: true,
                showSelectedRating: false,
                onSelect: function (value, text) {
                    $("#hdnRating").val(value);
                }
            });
        });
    }


    function autoGrow(oField) {
        if (oField.scrollHeight < 100) {
            if (oField.scrollHeight > oField.clientHeight) {
                oField.style.height = oField.scrollHeight + "px";
            }
        }
    }


    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }


    function QuestionsVM(_in) {

        var self = this;

        self.ShowThisQuestion = ko.observable(false);
        self.HasUserAnswered = ko.observable(false);

        self._id = ko.observable(_in._id);
        self.QuestionID = ko.observable(_in.QuestionID);
        self.QuestionText = ko.observable(_in.QuestionText);
        self.QuestionCategory = ko.observable(_in.QuestionCategory);
        self.OptionsQuestion = ko.observable(_in.OptionsQuestion);
        self.PreferenceQuestion = ko.observable(_in.PreferenceQuestion);
        self.OptionType = ko.observable(_in.OptionType);
        self.PreferenceType = ko.observable(_in.PreferenceType);

        self.OptionElements = ko.observable(new ElementTypeSingleSelecttVM(_in.OptionElements));
        self.PreferenceElements = ko.observable(new ElementTypeMultiSelectVM(_in.PreferenceElements));




        SubmtClick = function (_data) {

            var _submitObject = new Object();
            var _submitAPI = _SitePath + "api/AnswerQuestion"

            var _question_id = _data._id();

            _submitObject.Question_id = _question_id;
            _submitObject.OptionAnswer = GetSelectedOption();
            _submitObject.PreferenceAnswer = GetSelectedPreferences();
            _submitObject.Rating = $("#txtSlider").val();
            _submitObject.Comment = $("#txtComment").val();
            _submitObject.AnsweredPrivately = $("#chkAnswerPrivately").is(":checked");

            var _GetDivToRebind = window.parent.document.getElementsByClassName("cls" + _question_id);
            //$(_GetDivToRebind).html("");
            var _OtherUserID = window.parent._OtherUserID;
            var _urlPath = _SitePath + "web/inner/questionssinglematch?dis=1&uid=" + _OtherUserID + "&pid=" + _question_id;


            var _hdnmatchp= window.parent.document.getElementById("hdnUpdateMatchp");

            //var _DummyDiv = document.createElement("div");

            
            //var _QmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=q";

            //alert(_QmatchpPath);
            //$(_DummyDiv).data(_QmatchpPath);

            // alert($(_DummyDiv).html());

            // $(_getmatchpDiv).html(_DummyDiv.html());

            $.postDATA(_submitAPI, _submitObject, function (_return) {
   
                $("#btnSubmit").attr('disabled', 'disabled');
                $("#btnSubmit").addClass("Disabled");

                $(_GetDivToRebind).load(_urlPath, function () {
                    $(_hdnmatchp).val("1");
                    ResetMatchp();
                });
                window.parent.CloseIntelliWindow();

            });
        };


    }

    function ResetMatchp() {
        var API_ResetMatchp = _SitePath + "api/ResetMatchPercentages";
        var _MatchpObject = new Object();
        var _OtherUserID = window.parent._OtherUserID;
        _MatchpObject.OtherUserID = _OtherUserID;
        $.postDATA(API_ResetMatchp, _MatchpObject, function (_ret) {
        });
    }



    function ElementTypeSingleSelecttVM(_in) {
        var self = this;
        self.Options = ko.observableArray();
        self.SelectType = ko.observable(_in.SelectType);

        for (var i = 0; i < _in.Options.length; i++) {
            self.Options.push(new ElementOptionVM(_in.Options[i]));
        }
    }

    function ElementTypeMultiSelectVM(_in) {
        var self = this;

        self.Options = ko.observableArray();
        self.SelectType = ko.observable(_in.SelectType);
        self.SelectAllText = ko.observable(_in.SelectAllText);
        self.PlaceHolder = ko.observable(_in.PlaceHolder);

        for (var i = 0; i < _in.Options.length; i++) {
            self.Options.push(new ElementOptionVM(_in.Options[i]));
        }

        self.HasSelectAllText = ko.computed(function () {
            return (self.SelectAllText() != "");
        }, this);
    }

    function ElementOptionVM(_in) {
        var self = this;
        self._id = ko.observable(_in._id);
        self.OptionID = ko.observable(_in.OptionID);
        self.OptionText = ko.observable(_in.OptionText);

        self.OptionCheckID = ko.computed(function () {
            return "rdo_" + self._id();
        }, this)

        self.OptionPrefCheckID = ko.computed(function () {
            return "chk_" + self._id();
        }, this)
    }

    function PostLoadQuestion() {


        $("#chkSelectAll").bind("click", function () {
            var _checked = $("#chkSelectAll").is(":checked");
            $(".philosophyPrefOptions").each(function (_pos, _obj) {
                $(_obj).prop("checked", _checked);
            });
            SetButtonStatus();
            if (_checked) {
                DistroyRating();
            }
            else {
                bindBarRatting();
            }
        });

        $(".philosophyPrefOptions").bind("click", function () {
            if ($(".philosophyPrefOptions").is(":checked") == false) {
                $("#chkSelectAll").prop("checked", false);

            }
            else {
                var _checked = true;
                $(".philosophyPrefOptions").each(function (_pos, _obj) {
                    if ($(_obj).is(":checked") == false) {
                        _checked = false;
                    }
                });
                $("#chkSelectAll").prop("checked", _checked);
            }
            SetButtonStatus();

            if ($("#chkSelectAll").is(":checked")) {
                DistroyRating();
            }
            else {
                bindBarRatting();
            }
        });

        $(".philosophyOptions").bind("click", function () {
            var _selected = false;
            $(".philosophyOptions").each(function (_pos, _obj) {
                if ($(_obj).is(":checked") == true) {
                    _selected = true;
                }
            });
            SetButtonStatus();
        });

       
    }

    function SetButtonStatus() {
        var _optionChecked = false;
        $(".philosophyOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked") == true) {
                _optionChecked = true;
            }
        });

        var _preferenceChecked = false;
        $(".philosophyPrefOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked") == true) {
                _preferenceChecked = true;
            }
        });

        if (_optionChecked && _preferenceChecked) {
            if ($("#btnSubmit").hasClass("Disabled")) {
                $("#btnSubmit").removeClass("Disabled");
                $("#btnSubmit").removeAttr("disabled");
            }
        }
        else {
            if (!$("#btnSubmit").hasClass("Disabled")) {
                $("#btnSubmit").addClass("Disabled");
                $("#btnSubmit").attr('disabled', 'disabled');
            }
        }

    }

    function GetSelectedOption() {
        var _optionID = "";
        $(".philosophyOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked")) {
                _optionID = $(_obj).val();
            }
        });

        return _optionID;
    }

    function GetSelectedPreferences() {
        var _preferencesSelected = new Array();
        $(".philosophyPrefOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked")) {
                _preferencesSelected.push($(_obj).val());
            }
        });

        return _preferencesSelected;
    }


    function QuestionAnswerListVM(_in) {
        var self = this;
        self.AllAnswers = ko.observableArray();

        for (var i = 0; i < _in.length; i++) {
            self.AllAnswers.push(new QuestionAnswerVM(_in[i]));
        }
    }


    function QuestionAnswerVM(_in) {

        var self = this;
        self._id = ko.observable(_in._id);
        self.UserID = ko.observable(_in.UserID);
        self.Question_id = ko.observable(_in.Question_id);
        self.QuestionDetails = ko.observable(new QuestionsVM(_in.QuestionDetails));
        //self.OptionAnswer = ko.observable(new OptionsSingleSelectAnswerVM(_in.OptionAnswer));
        self.OptionAnswerText = ko.observable(_in.OptionAnswerText);
        //self.PreferenceAnswer = ko.observable(new OptionsMultiSelectAnswerVM(_in.PreferenceAnswer));
        self.PreferenceAnswerText = ko.observable(_in.PreferenceAnswerText);
        self.PreferenceAnswerTextFixed = ko.computed(function () {
            if (self.PreferenceAnswerText() != "") {
                return self.PreferenceAnswerText();
            }
            else {
                return "<span style=\"color:red;\">None</span>";
            }
        }, this);

        self.NonPreferenceAnswerText = ko.observable(_in.NonPreferenceAnswerText);
        self.NonPreferenceAnswerTextFixed = ko.computed(function () {
            if (self.NonPreferenceAnswerText() != "") {
                return self.NonPreferenceAnswerText();
            }
            else {
                return "<span style=\"color:#000;\">None</span>";
            }
        }, this);

        self.Rating = ko.observable(_in.Rating);
        self.Comment = ko.observable(_in.Comment);
        self.AnsweredPrivately = ko.observable(_in.AnsweredPrivately);
        self.TimeStamp = ko.observable(_in.TimeStamp);
        self.EditedDate = ko.observable(_in.EditedDate);

    }

    function OptionsSingleSelectAnswerVM(_in) {
        var self = this;
        self.Option_id = ko.observable(_in.Option_id);
    }

    function OptionsMultiSelectAnswerVM(_in) {
        var self = this;
        self.Option_id = ko.observableArray();
        for (var i = 0; i < _in.Option_id.length; i++) {
            self.Option_id.push(_in.Option_id[i]);
        }
    }

</script>



