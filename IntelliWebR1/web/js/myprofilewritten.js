
$(document).ready(function () {

    var _APIGetAnsers = _SitePath + "api/Description";
    $.getDATA(_APIGetAnsers, function (_data) {
        $("#liAboutme").addClass("active");
        ko.applyBindings(new VMDescriptionAnswersList(_data), document.getElementById("divmyprofilewritten"));
    }, function () { });

});





function VMDescriptionAnswers(_ans) {
    var self = this;
    self.AnswerID = ko.observable(_ans.AnswerID);
    self.QuestionId = ko.observable(_ans.QuestionId);
    self.GetQuestion = ko.observable(_ans.GetQuestion);
    self.Answer = ko.observable(_ans.Answer);
    self.UserId = ko.observable(_ans.UserId);
    self.UserRank = ko.observable(_ans.UserRank);
    self.OtherUser = ko.observable(_ans.OtherUser);
    self.CreatedDate = ko.observable(_ans.CreatedDate);
    self.Priority = ko.observable(_ans.Priority);
    self.Status = ko.observable(_ans.Status);
    self.MaxAnswerLength = ko.observable(_ans.MaxAnswerLength);
    self.OldPriority = ko.observable(_ans.Priority);
    self.EditedAnswer = ko.observable("");
    self.ShowEdit = ko.observable(false);

    self.AnswerHtml = ko.computed(function () {
        var _ans = self.Answer();
        if (_ans == "") {
            _ans = "<span class=\"placeHolderdiv\">Enter your answer</span>";
        }
        else {
            _ans = replaceAll('\n', '<br />', _ans);
        }

        return _ans;
    }, this);


    self.SubmitText = ko.computed(function () {
        var _ans = self.Answer();
        if (_ans == "") {
            return "Submit";
        }
        else {
            return "Update";
        }

        return _ans;
    }, this);




}

function replaceAll(find, replace, str) {
    return str.replace(new RegExp(find, 'g'), replace);
}

function VMDescriptionAnswersList(_list) {
    var self = this;
    self.AllDescAnswers = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllDescAnswers.push(new VMDescriptionAnswers(_list[i]));
    }

    ShowEditBox = function (_data) {
        _data.ShowEdit(true);

        var _questionID = _data.QuestionId();
        $(".profileAnswer").each(function (i, obj) {
            if ($(obj).data("questionid") == _questionID) {
                $(obj).val(_data.Answer());
            }
        });


    };

    CancelEdit = function (_data) {
        _data.ShowEdit(false);
    };

    SaveEdit = function (_data) {
        CheckIsUserOnline();
        var _questionID = _data.QuestionId();
        var _AnserText = "";
        $(".profileAnswer").each(function (i, obj) {

            if ($(obj).data("questionid") == _questionID) {
                _AnserText = $(obj).val();

            }
        });

        var _charLimit = _data.MaxAnswerLength();

        if (_AnserText.length > _charLimit) {
            alert("The maximum allowed characters are " + _charLimit);
            return;
        }

        var _setPriorityAnswerAPI = _SitePath + "api/Description";
        var _setPriorityAnswerObject = new Object();
        _setPriorityAnswerObject.AnswerText = _AnserText;
        _setPriorityAnswerObject.QuestionId = _questionID;
        _setPriorityAnswerObject.Method = "SA";
        _data.Answer(_AnserText);
        _data.EditedAnswer(_AnserText);
        _data.ShowEdit(false);
        $.postDATA(_setPriorityAnswerAPI, _setPriorityAnswerObject, function (_ret) {
            
        });
    }

    GetMaxCount = function () {
        return self.AllDescAnswers().length;
    };


    ValidateMaxAnswerLength = function (data) {

        var _questionID = data.QuestionId();
        var _AnserText = "";
        $(".profileAnswer").each(function (i, obj) {
            if ($(obj).data("questionid") == _questionID) {
                _AnserText = $(obj).val();
            }
        });
        var m_AnswerTextLength = _AnserText.length;
        var m_charLimit = data.MaxAnswerLength();
        if (m_AnswerTextLength >= m_charLimit) {
            alert("The maximum allowed characters are " + m_charLimit);
            return;
        }
    };


    ValidateNumber = function (_data) {
        var _valueEntered = _data.Priority();
        var _oldPriority = _data.OldPriority();
        if (isNaN(_valueEntered) == true) {
            alert("Please enter a number");
            _data.Priority(_oldPriority);
            return;
        }
    }

    UpDatePriority = function (_data) {
        CheckIsUserOnline();
        var _EnteredPriority = _data.Priority();
        if (_EnteredPriority == "" || _EnteredPriority == "0")
        {
            alert("Please enter a number");
            return;
        }
        else {
            var API_SETPRIORITY = _SitePath + "api/SetWrittnPriority";
            var _max = GetMaxCount();
            if (_EnteredPriority > _max) {
                _EnteredPriority =eval(_max);
            }

            var _PriorityObject = new Object();
            _PriorityObject.AnswerID = _data.AnswerID();
            _PriorityObject.Priority = _EnteredPriority;

            $.postDATA(API_SETPRIORITY, _PriorityObject, function (_ret) {
                RebindData();
            });


        }

    }

    RemoveAndReBindAnswers= function (_data) {
        self.AllDescAnswers.removeAll();
        for (var i = 0; i < _data.length; i++) {
            self.AllDescAnswers.push(new VMDescriptionAnswers(_data[i]));
        }
    }



    RebindData = function () {
        var _APIGetAnsers = _SitePath + "api/Description";
        $.getDATA(_APIGetAnsers, function (_List) {
            RemoveAndReBindAnswers(_List);
        }, function () { });
    }
}


