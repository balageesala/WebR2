function QuestionListVM(_in) {
    var self = this;

    ko.bindingHandlers.animate = {
        update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).animate(valueAccessor(), 1000);
        }
    };


    self.AllQuestions = ko.observableArray();
    for (var i = 0; i < _in.length; i++) {
        self.AllQuestions.push(new QuestionsVM(_in[i]));
    }

    ShowFirstUnAnswered = function () {
        var _pos = -1;
        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i].HasUserAnswered() == false) {
                _pos = i;
                break;
            }
        }
        if (_pos > -1) {
            DisplayQuestion(self.AllQuestions()[_pos]._id());
        }
    };

    ShowNextQuestion = function () {
        var _pos = -1;
        
        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i].ShowThisQuestion() == true) {
                _pos = i;
                break;
            }
        }
            var _position = eval(_pos + 1);
            DisplayQuestion(self.AllQuestions()[_position]._id());
    };


    DisplayQuestion = function (_questionId) {
        var _pos = -1;
        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _questionId) {
                _pos = i;
            }
            else {
                self.AllQuestions()[i].ShowThisQuestion(false);
            }
        }

        if (_pos == -1) {
            return;
        }
        self.AllQuestions()[_pos].ShowThisQuestion(true);
        PostLoadQuestion();
    };

    SubmtClick = function (_data) {
        
        var _submitObject = new Object();
        var _submitAPI = _SitePath + "api/AnswerQuestion"

       // alert($("#hdnRating").val());

        _submitObject.Question_id = _data._id();
        _submitObject.OptionAnswer = GetSelectedOption();
        _submitObject.PreferenceAnswer = GetSelectedPreferences();
        _submitObject.Rating = $("#hdnRating").val();
        _submitObject.Comment = $("#txtComment").val();
        _submitObject.AnsweredPrivately = $("#chkAnswerPrivately").is(":checked");

        $.postDATA(_submitAPI, _submitObject, function (_return) {
            // Display next question
            _data.HasUserAnswered(true);
            ShowFirstUnAnswered();

            $("#btnSubmit").attr('disabled', 'disabled');
            $("#btnSubmit").addClass("Disabled");


        });
    };


    SkipClick = function (_data) {
        _data.HasUserAnswered(false);
        ShowNextQuestion();
        $("#btnSubmit").attr('disabled', 'disabled');
        $("#btnSubmit").addClass("Disabled");
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

    self.position = ko.observable({ top: 0 });

    self.CheckHasUserAnswered = ko.computed(function () {
        var _checkApi = _SitePath + "api/CheckHasUserAnsweredQuestion";
        var _dataToPost = new Object();
        _dataToPost.Question_id = self._id();
        $.postDATA(_checkApi, _dataToPost, function (_result) {
            //console.log(self._id() + "  " + _result);
            self.HasUserAnswered(_result);
        });

    }, this);
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
            // DisableSlider();
            DistroyRating();
        }
        else {
            // EnableSlider();
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

    bindBarRatting();
}


function DisableSlider() {
    $("#divSlider").slider("value", 0);
    $("#divSlider").slider("disable");

    $("#txtSlider").val(0);
    $("#txtSlider").prop("disabled", true);
}

function EnableSlider() {
    $("#divSlider").slider("enable");
    $("#txtSlider").prop("disabled", false);
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

    EditQuestionAnswer = function (_data) {
        //alert(_data.Question_id());
     
       var _Url = _SitePath + "web/inner/questionsedit?qid="+_data.Question_id();
       SetUrlIntelliWindow(_Url,700, 520);


    };

    DeleteQuestionAnswer = function (_data) {
        var m_QtnObj = new Object();
        m_QtnObj.Question_id = _data.Question_id();
        var DELETEQTN_API = _SitePath + "api/DeleteQuestion";

        $.postDATA(DELETEQTN_API, m_QtnObj, function (_return) {
            if (_return) {
                self.AllAnswers.remove(_data);
            }
        });



    };


    RemoveAndReBindAnswers = function () {

        var _api = _SitePath + "api/GetAllQuestionAnswers";
        $.getDATA(_api, function (_in) {
            if (_in != null) {
                self.AllAnswers.removeAll();
                for (var i = 0; i < _in.length; i++) {
                    self.AllAnswers.push(new QuestionAnswerVM(_in[i]));
                }
            }
        }, function () { });

    };

   
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
            var _Answers = new Array();
            _Answers = self.PreferenceAnswerText().split(',');
            var AnswerHtml = "";
            for (var i = 0; i < _Answers.length; i++) {
                AnswerHtml = "<div>" + AnswerHtml + "</div><div>" + _Answers[i] + "</div>";
            }
            return AnswerHtml;
        }
        else {
            return "<span style=\"color:red;\">None</span>";
        }
    },this);

    self.NonPreferenceAnswerText = ko.observable(_in.NonPreferenceAnswerText);
    self.NonPreferenceAnswerTextFixed = ko.computed(function () {
        if (self.NonPreferenceAnswerText() != "") {
            var _Answers = new Array();
            _Answers = self.NonPreferenceAnswerText().split(',');
            var AnswerHtml = "";
            for (var i = 0; i < _Answers.length; i++) {
                AnswerHtml = "<div>" + AnswerHtml + "</div><div>" + _Answers[i] + "</div>";
            }
            return AnswerHtml;
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
    self.IsEdited = ko.observable(_in.IsEdited);
    self.EditableDate = ko.observable(_in.EditableDate);
    self.Status = ko.observable(_in.Status);

    self.LocalTime = ko.computed(function () {
        var date = new Date(self.EditableDate());
      
        //var curr_hour = date.getHours();
        //var a_p;
        //if (curr_hour < 12) {
        //    a_p = "AM";
        //}
        //else {
        //    a_p = "PM";
        //}
        //if (curr_hour == 0) {
        //    curr_hour = 12;
        //}
        //if (curr_hour > 12) {
        //    curr_hour = curr_hour - 12;
        //}
        //var curr_min = date.getMinutes();
        //var _Formate = date.getMonth() + "/" + date.getDay() + "/" + date.getFullYear() + " " + curr_hour + ":" + curr_min + "" + a_p;
       
       

        return date;// "Wed Jun 29 2011 09:52:48 GMT-0700 (PDT)"
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
        if (self.Comment() != "" && self.Comment()!=null) {
            return true;
        }
        else {
            return false;
        }
    });

    self.CalenderIconPath = ko.computed(function () {
        return _SitePath + "web/images/calender_item.png";
    }, this);
    self.CommentIconPath = ko.computed(function () {
        return _SitePath + "web/images/comment_item.png";
    }, this);
    self.PrivacyIconPath = ko.computed(function () {
        return _SitePath + "web/images/privacy_item.png";
    }, this);
    self.SexIconPath = ko.computed(function () {
        return _SitePath + "web/images/sex_item.png";
    }, this);

    self.DeleteIconPath = ko.computed(function () {
        return _SitePath + "web/images/close.png";
    }, this);

    self.IsDeleted = ko.computed(function () {
       
        if (self.Status() == "I") {
            return false;
        } else {
            return true;
        }

    }, this);
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