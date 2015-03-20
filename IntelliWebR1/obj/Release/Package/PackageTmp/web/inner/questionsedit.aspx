<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionsedit.aspx.cs" Inherits="IntelliWebR1.web.inner.questionsedit" %>

<%@ Register Src="~/web/ko/template_questionsedit.ascx" TagPrefix="uc1" TagName="template_questionsedit" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.0.0.js" type="text/javascript"></script>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div class="popupqtn">
    <div style="height:12px;"><a class="close" id="btnClose">x</a></div>
    <input type="hidden" id="hdnRating" />
    <div id="divQuestionEdit" class="four eleven_middle" data-bind="template: { name: 'template_questionsedit' }"></div>
    <div id="lblerror" style="margin-left: 22px;color: red;font-family: 'Open Sans', sans-serif;"></div>
    <span class="clear"></span>
</div>
<script type="text/html" id="template_questionsedit">
    <div class="tabs_matter">
        <h2 data-bind="text: QuestionDetails().QuestionText"></h2>
        <input type="hidden" class="optionAnswer" data-bind="value: OptionAnswerText " />
        <input type="hidden" class="preferenceAnswerText" data-bind="value: PreferenceAnswerText " />
        <div class="tabs_left">
            <h5 data-bind="text: QuestionDetails().OptionsQuestion"></h5>
            <ul>
                <!--ko foreach:QuestionDetails().OptionElements().Options-->
                <li>
                    <input type="radio" class="philosophyOptions" name="philosophyOptions" data-bind="attr: { id: OptionCheckID, value: _id, 'data-text': OptionText }" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label></li>
                <!--/ko-->
            </ul>
        </div>
        <div class="tabs_left marg_no">
            <h5 data-bind="text: QuestionDetails().PreferenceQuestion"></h5>
            <ul>
                <!--ko foreach:QuestionDetails().PreferenceElements().Options-->
                <li>
                    <input type="checkbox" data-bind="attr: { id: OptionPrefCheckID, value: _id, 'data-text': OptionText }" class="philosophyPrefOptions" name="philosophyPrefOptions" /><label data-bind="    attr: { 'for': OptionPrefCheckID }, text: OptionText"></label></li>
                <!--/ko-->
                <!--ko if:QuestionDetails().PreferenceElements().HasSelectAllText-->
                <li>
                    <input type="checkbox" id="chkSelectAll" /><label for="chkSelectAll" data-bind="text: QuestionDetails().PreferenceElements().SelectAllText"></label>
                </li>
                <!--/ko-->
            </ul>
        </div>
        <span class="clear"></span>
        <div class="input select rating-c" style="float: left;width: 102%;">
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
        <div class="clear"></div>
        <!--ko if:QuestionDetails().QuestionCategory() == '0'-->
        <div class="comment">
            <textarea id="txtComment" placeholder="Comments (optional)" data-bind="value: Comment " onkeyup="autoGrow(this);"></textarea>
        </div>
        <div class="clear"></div>
        <div class="check">
            <label>
                <input type="checkbox" id="chkAnswerPrivately" data-bind="attr: { checked: AnsweredPrivately }"   >
                Keep Private
            </label>
        </div>
         <!--/ko-->
       
    </div>

     <div class="clear" style="height:10px;">&nbsp;</div>
      <div style="margin-top: 14px;width: 200px;float: left;"><a id="AClearAnswer" style=" font-family: 'Open Sans', sans-serif;text-decoration:underline;cursor:pointer;" data-bind="event: { click: ClearAnswer }">Clear Answer</a></div>
        <div class="buttons" style="margin-right: 8px;">
            <input type="button" class="btnsubmit Disabled" disabled="disabled" style="border: 0px; cursor: pointer;" value="Update" id="btnSubmit" data-bind="event: { click: SubmitClick }" />
        </div>

</script>

<script type="text/javascript">

    $(document).ready(function () {

        $("#lblerror").html("");
        var APIGET_QUESTION = window.parent._SitePath + "api/GetQuestion";
        var _GetObject = new Object();
        _GetObject.Question_id = getParameterByName("qid");


        $.postDATA(APIGET_QUESTION, _GetObject, function (_return) {
            ko.applyBindings(new QuestionAnswerVM(_return), document.getElementById("divQuestionEdit"));
            CheckAnswredOptions();
            CheckPreferenceAnswers();

            if (_return.Rating == 0) {
                bindBarRattingWithValue("0");
            } else {

                bindBarRattingWithValue(_return.Rating);
            }
            $(".philosophyPrefOptions").bind("click", function () {
                SetButtonStatus();
                var _checked = true;
                $(".philosophyPrefOptions").each(function (_pos, _obj) {
                    if ($(_obj).is(":checked") == false) {
                        _checked = false;
                    }
                });
                $("#chkSelectAll").prop("checked", _checked);
                if (_checked) {
                    DistroyRating();
                }
                else {
                    bindBarRattingWithValue(_return.Rating);
                }
            });

            $("#chkSelectAll").bind("click", function () {
                var _checked = $("#chkSelectAll").is(":checked");
                $(".philosophyPrefOptions").each(function (_pos, _obj) {
                    $(_obj).prop("checked", _checked);
                });
               
                if (_checked) {
                    DistroyRating();
                }
                else {
                    bindBarRattingWithValue(_return.Rating);
                }
            });

            $("#chkAnswerPrivately").change(function () {
                SetButtonStatus();
            });

          
        });

        $("#btnClose").click(function () {
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


    

    function CheckAnswredOptions() {

        var _optAnswerText = new Array();
        var optionAnswer = $(".optionAnswer").val();
        _optAnswerText = optionAnswer.split(',');

        $(".philosophyOptions").each(function (_pos, _obj) {

            var _optAns = $(_obj).attr("data-text");
            for (var i = 0; i < _optAnswerText.length; i++) {
                if (_optAnswerText[i] == _optAns) {
                    $(_obj).prop("checked", true);
                }
            }
        });

    }


    function CheckPreferenceAnswers() {

        var _preAnswerText = new Array();
        var preferenceAnswer = $(".preferenceAnswerText").val();
        _preAnswerText = preferenceAnswer.split(',');

        $(".philosophyPrefOptions").each(function (_pos, _obj) {
            var _optAns = myTrim($(_obj).attr("data-text"));
            for (var i = 0; i < _preAnswerText.length; i++) {
                var _valueText = myTrim(_preAnswerText[i]);
                if (_valueText == _optAns) {
                    $(_obj).prop("checked", true);
                }
            }
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






    function myTrim(x) {
        return x.replace(/^\s+|\s+$/gm, '');
    }




    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    function QuestionListVM(_in) {
        var self = this;
        self.AllQuestions = ko.observableArray();

        for (var i = 0; i < _in.length; i++) {
            self.AllQuestions.push(new QuestionsVM(_in[i]));
        }


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


    }

    function QuestionAnswerVM(_in) {

        var self = this;
        self._id = ko.observable(_in._id);
        self.UserID = ko.observable(_in.UserID);
        self.Question_id = ko.observable(_in.Question_id);
        self.QuestionDetails = ko.observable(new QuestionsVM(_in.QuestionDetails));
        self.OptionAnswerText = ko.observable(_in.OptionAnswerText);
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
                return "<span style=\"color:red;\">None</span>";
            }
        }, this);

        self.Rating = ko.observable(_in.Rating);
        self.Comment = ko.observable(_in.Comment);
        self.AnsweredPrivately = ko.observable(_in.AnsweredPrivately);
        self.TimeStamp = ko.observable(_in.TimeStamp);
        self.LocalTime = ko.computed(function () {
            var date = new Date(self.TimeStamp());
            return date.toString() // "Wed Jun 29 2011 09:52:48 GMT-0700 (PDT)"
        }, this);

        self.IsSexQuestion = ko.computed(function () {
            if (eval(self.QuestionDetails().QuestionCategory()) == 1) {
                return true;
            }
            else {
                return false;
            }
        });

        self.CommentAvailable = ko.computed(function () {
            if (self.Comment() != "" && self.Comment() != null) {
                return true;
            }
            else {
                return false;
            }
        });



        SubmitClick = function (_data) {

            //alert("hi");
            $("#btnSubmit").addClass("Disabled");
            $("#btnSubmit").attr('disabled', 'disabled');
            $("#btnSubmit").val("Please wait..");
         
            var _EditObject = new Object();
            var _EditAPI = window.parent._SitePath + "api/EditUserAnswer";

            _EditObject.Question_id = _data.QuestionDetails()._id();
            _EditObject.OptionAnswer = GetEditSelectedOption();
            _EditObject.PreferenceAnswer = GetEditSelectedPreferences();
            _EditObject.Rating = $("#hdnRating").val();
            _EditObject.Comment = $("#txtComment").val();
            _EditObject.AnsweredPrivately = $("#chkAnswerPrivately").is(":checked");

            // console.log(_EditObject);

            $.postDATA(_EditAPI, _EditObject, function (_return) {
                // close and rebind the knock out
                if (_return) {
                    $("#lblerror").html("Question saved sucessfully.");
                    setTimeout(function () {
                        setTimeout(function () {
                            try {
                                window.parent.RemoveAndReBindAnswers();
                                window.parent.CloseIntelliWindow();
                            } catch (e) {
                                window.parent.CloseIntelliWindow();
                            }
                        }, 2000);
                    }, 2000);
                } else {
                    window.parent.CloseIntelliWindow();
                }

            });
        };


        ClearAnswer = function (_data) {
            var _QuestionObject = new Object();
            _QuestionObject.Question_id = _data.QuestionDetails()._id();
            var Api_ClearQuestion = window.parent._SitePath + "api/DeleteQuestion";
            $.postDATA(Api_ClearQuestion, _QuestionObject, function (_return) {
                if (_return) {
                    $(".philosophyOptions").each(function (_pos, _obj) { $(_obj).prop("checked", false); });
                    $(".philosophyPrefOptions").each(function (_pos, _obj) { $(_obj).prop("checked", false); });
                    ClearBarRatting();
                    $("#chkAnswerPrivately").prop("checked", false);
                    $("#txtComment").val("");
                    window.parent.RemoveAndReBindAnswers();
                }
            });
        }

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


    function GetEditSelectedOption() {

        var _optionID = "";
        $(".philosophyOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked")) {
                _optionID = $(_obj).val();
            }
        });

        return _optionID;


    }

    function GetEditSelectedPreferences() {

        var _preferencesSelected = new Array();
        $(".philosophyPrefOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked")) {
                _preferencesSelected.push($(_obj).val());
            }
        });

        return _preferencesSelected;
    }



</script>



