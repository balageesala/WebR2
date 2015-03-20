var _CurrentQuestionID = "";
var _currentPhilosophy = "";
function VMPhilosophyQuestionList(_list) {
    var self = this;
    self.AllQuestions = ko.observableArray();

    for (var i = 0; i < _list.length; i++) {
        self.AllQuestions.push(new VMPhilosophyQuestion(_list[i], i + 1, _list.length));
    }

    CheckSubmitDisable = function () {
        // Get the question info
        var _pos = -1;
        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _CurrentQuestionID) {
                _pos = i;
                break;
            }
        }

        if (_pos == -1) {
            return true;
        }
        var _enableButton = false;

        // Check if part two is getting displayed

        // Radio buttons
        if (self.AllQuestions()[_pos].PhilosophyType() == '1') {
            _enableButton = CheckAnySelected();
        }

        if (self.AllQuestions()[_pos].PhilosophyType() == '2') {
            _enableButton = CheckAnySelected();
        }

        // Date of birth
        if (self.AllQuestions()[_pos].PhilosophyType() == '7') {
            if ($(".Month").val() != "0" && $(".Day").val() != "0" && $(".Year").val() != "0") {

                var _dateEntered = new Object();
                _dateEntered.Month = $(".Month").val();
                _dateEntered.Year = $(".Year").val();
                _dateEntered.Day = $(".Day").val();

                var _dateAPI = _SitePath + "api/ValidateDOB";
                $.postDATA(_dateAPI, _dateEntered, function (_return) {
                    if (self.AllQuestions()[_pos].ShowPartTwo()) {
                        if (_return != 1 && _enableButton == true) {
                            _enableButton = false;
                            DisableButton("#btnSubmit");
                            $("#lblPhilosophyDobError").html("You should be atleast 21 years.");
                        }
                        if (_return == 1 && _enableButton == true) {
                            _enableButton = true;
                            EnableButton("#btnSubmit");
                            $("#lblPhilosophyDobError").html("&nbsp;");
                        }
                    }
                    else {
                        if (_return == 1) {
                            EnableButton("#btnSubmit");
                            $("#lblPhilosophyDobError").html("&nbsp;");
                            return true;
                        }
                        else if (_return == -2) {
                            DisableButton("#btnSubmit");
                            $("#lblPhilosophyDobError").html("You should be atleast 21 years.");
                            return true;
                        }
                        else {
                            DisableButton("#btnSubmit");
                            $("#lblPhilosophyDobError").html("The date of birth you have entered is invalid");
                            return true;
                        }
                    }

                });
            }
            else {
                $("#lblPhilosophyDobError").html("&nbsp;");
            }
        }

        if (self.AllQuestions()[_pos].PhilosophyType() == '8') {
            var _salaryEntered = $("#txtSalary").val();
            if (_salaryEntered == "") {
                _enableButton = false;
            }
            else if (isNaN(_salaryEntered) == true) {
                _enableButton = false;
            }
            else {
                _enableButton = true;
            }
        }

        if (self.AllQuestions()[_pos].ShowPartTwo()) {

            if (self.AllQuestions()[_pos].PhilosophyPreferenceType() == '1') {
                _enableButton = CheckAnyPrefSelected();
            }

            if (self.AllQuestions()[_pos].PhilosophyPreferenceType() == '3') {
                if ($(".SelectOptionsOne").val() != "0" && $(".SelectOptionsTwo").val() != "0") {
                    if (eval($(".SelectOptionsTwo  option:selected").text()) >= eval($(".SelectOptionsOne  option:selected").text())) {
                        _enableButton = true;
                    }
                }
                else {
                    _enableButton = false;
                }
            }

            if (self.AllQuestions()[_pos].PhilosophyPreferenceType() == '4') {
                // Check from salary
                var _fromSal = false;
                var _toSal = false;

                var _salaryFromEntered = $("#txtSalaryFrom").val();
                if (_salaryFromEntered == "") {
                    _fromSal = false;
                }
                else if (isNaN(_salaryFromEntered) == true) {
                    _fromSal = false;
                }
                else {
                    _fromSal = true;
                }

                var _salaryToEntered = $("#txtSalaryTo").val();
                if (_salaryToEntered == "") {
                    _toSal = false;
                }
                else if (isNaN(_salaryToEntered) == true) {
                    _toSal = false;
                }
                else {
                    _toSal = true;
                }


                if (_fromSal && _toSal) {
                    _enableButton = true;
                }
                else {
                    _enableButton = false;
                }
            }
        }

        if (_enableButton) {
            EnableButton("#btnSubmit");
        }
        else {
            DisableButton("#btnSubmit");
        }

        return true;
    };

    ShowFirstUnAnswered = function () {
        var _pos = -1;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i].HasUserAnswered() == false) {
                _pos = i;
                break;
            }
        }

        if (_pos == -1) {
            //window.location.href = _SitePath + "web/PhilosophyPoints";
        }


        if (_currentPhilosophy == "") {
            var _PhilosophyCheck = new Object();
            _PhilosophyCheck.PhilosophyQuestionID = self.AllQuestions()[_pos]._id();

            var _Api = _SitePath + "api/CheckUserHasAnsweredPhilosophy";
            $.postDATA(_Api, _PhilosophyCheck, function (_return) {
                if (_return == false) {
                    DisplayQuestion(_PhilosophyCheck.PhilosophyQuestionID);
                }
                else {
                    self.AllQuestions()[_pos].HasUserAnswered(true);
                    ShowFirstUnAnswered();
                }
            });
        }
        else {

            var _PhilosophyCheck = new Object();
            _PhilosophyCheck.PhilosophyQuestionID = _currentPhilosophy;

            var _Api = _SitePath + "api/CheckUserHasAnsweredPhilosophy";
            $.postDATA(_Api, _PhilosophyCheck, function (_return) {
                if (_return == true) {
                    SetUserAnswered(_currentPhilosophy);
                }
                DisplayQuestion(_currentPhilosophy);
            });
        }
    };

    SetUserAnswered = function (_questionID) {
        var _pos = -1;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _questionID) {
                _pos = i;
                break;
            }
        }

        if (_pos > -1) {
            self.AllQuestions()[_pos].HasUserAnswered(true);
            if (typeof window.parent.LoadPoints !== 'undefined' && $.isFunction(window.parent.LoadPoints)) {
                window.parent.LoadPoints();
            }

            if (typeof window.parent.SetPhilosophy !== 'undefined' && $.isFunction(window.parent.SetPhilosophy)) {
                window.parent.SetPhilosophy();
            }
        }
    };

    DisplayQuestionByIndex = function (_showIndex) {
        var _pos = -1;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (eval(self.AllQuestions()[i].Index()) == _showIndex) {
                _pos = i;
                break;
            }
        }

        if (_pos > -1) {
            DisplayQuestion(self.AllQuestions()[_pos]._id());
        }
        else {
            //window.location.href = _SitePath + "web/PhilosophyPoints";
        }
    };

    DisplayQuestionEditable = function (_questionID) {

        var _pos = -1;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _questionID) {
                _pos = i;
                break;
            }
        }

        if (_pos > -1) {
            DisplayQuestion(_questionID);
            self.AllQuestions()[i].ShowEditItem(true);
            self.AllQuestions()[i].ShowPartTwo(true);
            self.AllQuestions()[i].ShowSkipButton(false);
        }
    };

    DisplayQuestion = function (_questionID) {
        var _pos = -1;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _questionID) {
                _pos = i;
                break;
            }
        }

        if (_pos > -1) {
            for (var i = 0; i < self.AllQuestions().length; i++) {
                $("#" + self.AllQuestions()[i]._id()).fadeOut(500);
                $("#" + self.AllQuestions()[i]._id()).hide();
                $("#" + self.AllQuestions()[i]._id()).addClass("displayNone");
                self.AllQuestions()[i].ShowThisQuestion(false);

            }
        }

        if (_pos > -1) {

            self.AllQuestions()[_pos].ShowThisQuestion(true);
            $("#" + self.AllQuestions()[_pos]._id()).hide();
            $("#" + self.AllQuestions()[_pos]._id()).removeClass("displayNone");
            $("#" + self.AllQuestions()[_pos]._id()).fadeIn(1000);

            // Post the Philosophy in cookie
            var _postPosAPI = _SitePath + "web/service/PhilosophyPosition";

            var _postData = new Object();
            _postData.Philosophy_id = self.AllQuestions()[_pos]._id();

            $.postDATA(_postPosAPI, _postData, function (_hasUserAnswered) {
                if (_hasUserAnswered) {
                    SetUserAnswered(self.AllQuestions()[_pos]._id());
                }

                _CurrentQuestionID = _questionID;
                if (self.AllQuestions()[_pos].PhilosophyType() == '7') {
                    FillUserDateOfBirth();
                }

                if (self.AllQuestions()[_pos].HasUserAnswered()) {
                    self.AllQuestions()[_pos].ShowPartTwo(true);

                    // Get User Answer
                    var _userAnswerAPI = _SitePath + "api/GetPhilosophyUserAnswer";
                    var _postData = new Object();
                    _postData.Philosophy_id = self.AllQuestions()[_pos]._id();

                    $.postDATA(_userAnswerAPI, _postData, function (_return) {
                        var _partOneSelected = false;
                        var _partTwoSelected = false;


                        if (eval(self.AllQuestions()[_pos].PhilosophyType()) == 1) {
                            $(".PhilosophyOptions").each(function (_pos, _obj) {
                                if (_return != null) {
                                    if (_return.UserOption != null) {
                                        if ($(_obj).val() == _return.UserOption._id) {
                                            $(_obj).prop("checked", true);
                                            _partOneSelected = true;
                                        }
                                    }
                                }


                            });
                        }

                        if (eval(self.AllQuestions()[_pos].PhilosophyType()) == 2) {
                            $(".PhilosophyOptions").each(function (_pos, _obj) {
                                if (_return != null) {
                                    if (_return.UserOptionMultiple != null) {
                                        for (var i = 0; i < _return.UserOptionMultiple._ids.length; i++) {
                                            if ($(_obj).val() == _return.UserOptionMultiple._ids[i]) {
                                                $(_obj).prop("checked", true);
                                                _partOneSelected = true;
                                            }
                                        }
                                    }
                                }

                            });
                        }

                        if (eval(self.AllQuestions()[_pos].PhilosophyType()) == 7) {

                        }

                        if (eval(self.AllQuestions()[_pos].PhilosophyType()) == 8) {
                            $("#txtSalary").val(_return.UserText.Value);
                        }


                        if (eval(self.AllQuestions()[_pos].PhilosophyPreferenceType()) == 1) {
                            $(".PhilosophyPrefOptions").each(function (_pos, _obj) {
                                if (_return != null) {
                                    if (_return.UserPreferenceMultiple != null) {
                                        for (var i = 0; i < _return.UserPreferenceMultiple._ids.length; i++) {
                                            if ($(_obj).val() == _return.UserPreferenceMultiple._ids[i]) {
                                                $(_obj).prop("checked", true);
                                                _partTwoSelected = true;
                                            }
                                        }
                                    }

                                }

                            });
                        }

                        if (eval(self.AllQuestions()[_pos].PhilosophyPreferenceType()) == 3) {
                            $(".SelectOptionsOne").val(_return.UserPreferenceRange.Min);
                            $(".SelectOptionsTwo").val(_return.UserPreferenceRange.Max);
                        }

                        if (eval(self.AllQuestions()[_pos].PhilosophyPreferenceType()) == 4) {
                            $("#txtSalaryFrom").val(_return.UserPreferenceRange.Min);
                            $("#txtSalaryTo").val(_return.UserPreferenceRange.Max);
                        }

                        if (_partOneSelected && _partTwoSelected) {
                            EnableButton("#btnSubmit");
                        }

                        PostLoadEachQuestion();
                        CheckSubmitDisable();
                    });

                }
                else {
                    PostLoadEachQuestion();
                    CheckSubmitDisable();
                }

            });



        }
        else {
            //window.location.href = _SitePath + "web/PhilosophyPoints";
        }
    };

    FillUserDateOfBirth = function () {
        var _Api = _SitePath + "api/UserDOB";
        $.getDATA(_Api, function (_Dob) {
            var _month = _Dob.split('-')[0];
            var _day = _Dob.split('-')[1];
            var _year = _Dob.split('-')[2];

            $(".Month").val(eval(_month));
            $(".Day").val(eval(_day));
            $(".Year").val(eval(_year));

            EnableButton("#btnSubmit");

        }, function () { })
    };

    IsPartTwoEnabled = function () {
        var _isPartTwoEnabled = false;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i].ShowThisQuestion() == true) {
                _isPartTwoEnabled = self.AllQuestions()[i].ShowPartTwo();
                break;
            }
        }

        return _isPartTwoEnabled;
    };

    MalePartTwoEnabled = function () {
        var _pos = -1;

        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i].ShowThisQuestion() == true) {
                _pos = i;

                break;
            }
        }
        if (_pos > -1) {
            self.AllQuestions()[_pos].ShowPartTwo(true);
            self.AllQuestions()[_pos].ShowSkipButton(true);
        }

    };

    BackClick = function (_data) {
        DisplayQuestionByIndex(eval(_data.Index()) - 1);

    };

    SelectAllPrefOptions = function () {
        var _pos = -1;
        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _CurrentQuestionID) {
                _pos = i;
                break;
            }
        }

        if (_pos == -1) {
            return true;
        }

        for (var i = 0; i < self.AllQuestions()[_pos].PhilosophyPreferenceOptions().length; i++) {
            var _prefCheckID = "#prefchk_" + self.AllQuestions()[_pos].PhilosophyPreferenceOptions()[i]._id();
            $(_prefCheckID).prop("checked", true);
        }
        CheckSubmitDisable();
    };

    DeselectAllPrefOptions = function () {
        var _pos = -1;
        for (var i = 0; i < self.AllQuestions().length; i++) {
            if (self.AllQuestions()[i]._id() == _CurrentQuestionID) {
                _pos = i;
                break;
            }
        }

        if (_pos == -1) {
            return true;
        }

        for (var i = 0; i < self.AllQuestions()[_pos].PhilosophyPreferenceOptions().length; i++) {
            var _prefCheckID = "#prefchk_" + self.AllQuestions()[_pos].PhilosophyPreferenceOptions()[i]._id();
            $(_prefCheckID).prop("checked", false);
        }
        CheckSubmitDisable();

    };

    SkipClick = function (_data) {
        if (IsPartTwoEnabled() == false) {
            MalePartTwoEnabled();
            PostLoadEachQuestion();
            CheckSubmitDisable();
            return;
        }
        else {
            DisplayQuestionByIndex(eval(_data.Index()) + 1);
        }
    }

    GetPhilosophyTypeOneObject = function (_data) {
        var _object = new Object();
        _object.Philosophy_id = _data._id();
        _object.PhilosophyType = _data.PhilosophyType();
        _object.UserOption = $(".PhilosophyOptions:checked").val();
        return _object;
    };

    GetPhilosophyTypeTwoObject = function (_data) {
        var _object = new Object();
        _object.Philosophy_id = _data._id();
        _object.PhilosophyType = _data.PhilosophyType();

        var _optionSelected = new Array();
        $(".PhilosophyOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked")) {
                _optionSelected.push($(_obj).val());
            }
        });
        _object.UserOptions = _optionSelected;
        return _object;
    };

    GetPhilosophyTypeEightObject = function (_data) {
        var _object = new Object();
        _object.Philosophy_id = _data._id();
        _object.PhilosophyType = _data.PhilosophyType();
        _object.UserOption = $("#txtSalary").val();
        return _object;
    };

    GetPhilosophyTypeSevenObject = function (_data) {
        var _object = new Object();
        _object.Philosophy_id = _data._id();
        _object.PhilosophyType = _data.PhilosophyType();
        _object.UserOption_Month = $(".Month").val();
        _object.UserOption_Day = $(".Day").val();
        _object.UserOption_Year = $(".Year").val();
        return _object;
    }

    GetPreferenceTypeOneObject = function (_data, _object) {
        _object.Philosophy_id = _data._id();
        _object.PhilosophyPreferenceType = _data.PhilosophyPreferenceType();
        _object.HasAllPreferencesSelected = $("#chkSelectAll").is(":checked");


        var _selectedOptions = new Array();
        $(".PhilosophyPrefOptions").each(function (_pos, _obj) {
            if ($(_obj).prop("checked") == true) {
                _selectedOptions.push($(_obj).val());
            }
        });

        _object.Preferences = _selectedOptions;
        return _object;

        //PhilosophyPrefOptions
    };

    GetPreferenceTypeThreeObject = function (_data, _object) {

        _object.Philosophy_id = _data._id();
        _object.PhilosophyPreferenceType = _data.PhilosophyPreferenceType();
        _object.PreferenceRangeMin = $(".SelectOptionsOne").val();
        _object.PreferenceRangeMax = $(".SelectOptionsTwo").val();

        var _allMinOptions = new Array();
        $('.SelectOptionsOne option').each(function () {
            _allMinOptions.push($(this).attr('value'));
        });

        var _allMaxOptions = new Array();
        $('.SelectOptionsTwo option').each(function () {
            _allMaxOptions.push($(this).attr('value'));
        });

        if (_object.PreferenceRangeMin == _allMinOptions[1] && _object.PreferenceRangeMax == _allMaxOptions[_allMaxOptions.length - 1]) {
            _object.HasAllPreferencesSelected = true;
        }
        else {
            _object.HasAllPreferencesSelected = false;
        }

        return _object;
    };

    GetPreferenceTypeFourObject = function (_data, _object) {

        _object.Philosophy_id = _data._id();
        _object.PhilosophyPreferenceType = _data.PhilosophyPreferenceType();
        _object.PreferenceRangeMin = $("#txtSalaryFrom").val();
        _object.PreferenceRangeMax = $("#txtSalaryTo").val();
        _object.HasAllPreferencesSelected = false;

        return _object;
    };

    PostPartOne = function (_data) {
        var _postObject;
        var _postAPI = _SitePath + "api/AddPhilosophyUserAnswer";

        switch (eval(_data.PhilosophyType())) {
            case 1: {
                _postObject = GetPhilosophyTypeOneObject(_data);
                break;
            }
            case 2: {
                _postObject = GetPhilosophyTypeTwoObject(_data);
                break;
            }
            case 7: {
                _postObject = GetPhilosophyTypeSevenObject(_data);
                break;
            }
            case 8: {
                _postObject = GetPhilosophyTypeEightObject(_data);
                break;
            }
        }

        $.postDATA(_postAPI, _postObject, function (_return) {
            MalePartTwoEnabled();
            CheckSubmitDisable();
            PostLoadEachQuestion();
            return;
        });
    };

    PostPartOneAndTwo = function (_data) {
        var _postObject;
        var _postAPI = _SitePath + "api/AddPhilosophyUserAnswer";

        switch (eval(_data.PhilosophyType())) {
            case 1: {
                _postObject = GetPhilosophyTypeOneObject(_data);
                break;
            }
            case 2: {
                _postObject = GetPhilosophyTypeTwoObject(_data);
                break;
            }
            case 7: {
                _postObject = GetPhilosophyTypeSevenObject(_data);
                break;
            }
            case 8: {
                _postObject = GetPhilosophyTypeEightObject(_data);
                break;
            }
        }

        switch (eval(_data.PhilosophyPreferenceType())) {

            case 1: {
                _postObject = GetPreferenceTypeOneObject(_data, _postObject);
                break;
            }

            case 3: {
                _postObject = GetPreferenceTypeThreeObject(_data, _postObject);
                break;
            }

            case 4: {
                _postObject = GetPreferenceTypeFourObject(_data, _postObject);
                break;
            }
        }

        // Get Comment
        var _Comment = "";
        if ($(".txtComment").length > 0) {
            _Comment = $(".txtComment").val();
            _postObject.Comment = _Comment;
        }

        $.postDATA(_postAPI, _postObject, function (_return) {
            // Go next question
            if (_data.ShowEditItem()) {
                window.parent.SetUserAnswered(_data._id());
                window.parent.CloseIntelliWindow();
            }
            else {
                _data.HasUserAnswered(true);
                DisplayQuestionByIndex(eval(_data.Index()) + 1);
            }

            return;
        });


    };

    SubmitClick = function (_data) {

        if ($("#btnSubmit").data("enabled") == false) {
            return;
        }

        if (_data.ShowPartTwo() == false) {
            // Post Part One
            PostPartOne(_data);
        }
        else {
            // Submitting the whole part
            PostPartOneAndTwo(_data);

        }
    };

    GetPointsAssigned = function () {
        var _PhilosophyPoints = new Array();
        var _eachPoint = new Object();

        for (var i = 0; i < self.AllQuestions().length; i++) {
            _eachPoint.Philosophy_id = self.AllQuestions()[i]._id();
            _eachPoint.Points = self.AllQuestions()[i].UserAssignedPoints();

            _PhilosophyPoints.push(_eachPoint);
        }

        return _PhilosophyPoints;
    };
}

function EnableButton(_buttonID) {
    if ($(_buttonID).hasClass("Disabled")) {
        $(_buttonID).removeClass("Disabled");
    }
    $(_buttonID).data("enabled", true);
}

function DisableButton(_buttonID) {
    if ($(_buttonID).hasClass("Disabled") == false) {
        $(_buttonID).addClass("Disabled");
    }
    $(_buttonID).data("enabled", false);
}

function VMPhilosophyQuestion(_in, _pos, _total) {
    var self = this;
    self.Index = ko.observable(_pos);
    self.TotalCount = ko.observable(_total);
    self.ShowPartTwo = ko.observable(false);
    self.ShowSkipButton = ko.observable(true);
    self.ShowEditItem = ko.observable(false);


    self.ShowBackButton = ko.computed(function () {
        if (eval(self.Index()) == 1) {
            return false;
        }
        else {
            return true;
        }
    }, this);

    self._id = ko.observable(_in._id);
    self.PhilosophyID = ko.observable(_in.PhilosophyID);
    self.PhilosophyName = ko.observable(_in.PhilosophyName);
    self.PhilosophyQuestion = ko.observable(_in.PhilosophyQuestion);
    self.PhilosophyType = ko.observable(_in.PhilosophyType);

    self.PhilosophyOptions = ko.observableArray();
    if (_in.PhilosophyOptions != null) {
        for (var i = 0; i < _in.PhilosophyOptions.length; i++) {
            self.PhilosophyOptions.push(new VMPhilosophyOption(_in.PhilosophyOptions[i]));
        }
    }

    self.PhilosophyOptions_One = ko.observableArray();
    if (_in.PhilosophyOptions_One != null) {
        for (var i = 0; i < _in.PhilosophyOptions_One.length; i++) {
            self.PhilosophyOptions_One.push(new VMPhilosophyOption(_in.PhilosophyOptions_One[i]));
        }
    }


    self.PhilosophyOptions_Two = ko.observableArray();
    if (_in.PhilosophyOptions_Two != null) {
        for (var i = 0; i < _in.PhilosophyOptions_Two.length; i++) {
            self.PhilosophyOptions_Two.push(new VMPhilosophyOption(_in.PhilosophyOptions_Two[i]));
        }
    }


    self.PhilosophyOptions_Three = ko.observableArray();
    if (_in.PhilosophyOptions_Three != null) {
        for (var i = 0; i < _in.PhilosophyOptions_Three.length; i++) {
            self.PhilosophyOptions_Three.push(new VMPhilosophyOption(_in.PhilosophyOptions_Three[i]));
        }
    }


    self.PhilosophyOptions_Male = ko.observableArray();
    if (_in.PhilosophyOptions_Male != null) {
        for (var i = 0; i < _in.PhilosophyOptions_Male.length; i++) {
            self.PhilosophyOptions_Male.push(new VMPhilosophyOption(_in.PhilosophyOptions_Male[i]));
        }
    }


    self.PhilosophyOptions_Female = ko.observableArray();
    if (_in.PhilosophyOptions_Female != null) {
        for (var i = 0; i < _in.PhilosophyOptions_Female.length; i++) {
            self.PhilosophyOptions_Female.push(new VMPhilosophyOption(_in.PhilosophyOptions_Female[i]));
        }
    }

    self.OptionSelectAllText_One = ko.observable(_in.OptionSelectAllText_One);
    self.OptionSelectAllText_Two = ko.observable(_in.OptionSelectAllText_Two);
    self.OptionSelectAllText = ko.observable(_in.OptionSelectAllText);
    self.PreferenceSelectAllText = ko.observable(_in.PreferenceSelectAllText);
    self.TextInputType = ko.observable(_in.TextInputType);
    self.AutoFillJsonPath = ko.observable(_in.AutoFillJsonPath);
    self.OptionsRangeMin = ko.observable(_in.OptionsRangeMin);
    self.OptionsRangeMax = ko.observable(_in.OptionsRangeMax);
    self.SortOptionsAlphabetically = ko.observable(_in.SortOptionsAlphabetically);
    self.PhilosophyPreferenceQuestion = ko.observable(_in.PhilosophyPreferenceQuestion);
    self.PhilosophyPreferenceType = ko.observable(_in.PhilosophyPreferenceType);

    self.PhilosophyPreferenceOptions = ko.observableArray();
    if (_in.PhilosophyPreferenceOptions != null) {
        for (var i = 0; i < _in.PhilosophyPreferenceOptions.length; i++) {
            self.PhilosophyPreferenceOptions.push(new VMPhilosophyOption(_in.PhilosophyPreferenceOptions[i]));
        }
    }


    self.PhilosophyPreferenceOptions_One = ko.observableArray();
    if (_in.PhilosophyPreferenceOptions_One != null) {
        for (var i = 0; i < _in.PhilosophyPreferenceOptions_One.length; i++) {
            self.PhilosophyPreferenceOptions_One.push(new VMPhilosophyOption(_in.PhilosophyPreferenceOptions_One[i]));
        }
    }


    self.PhilosophyPreferenceOptions_Two = ko.observableArray();
    if (_in.PhilosophyPreferenceOptions_Two != null) {
        for (var i = 0; i < _in.PhilosophyPreferenceOptions_Two.length; i++) {
            self.PhilosophyPreferenceOptions_Two.push(new VMPhilosophyOption(_in.PhilosophyPreferenceOptions_Two[i]));
        }
    }


    self.PhilosophyPreferenceOptions_Three = ko.observableArray();
    if (_in.PhilosophyPreferenceOptions_Three != null) {
        for (var i = 0; i < _in.PhilosophyPreferenceOptions_Three.length; i++) {
            self.PhilosophyPreferenceOptions_Three.push(new VMPhilosophyOption(_in.PhilosophyPreferenceOptions_Three[i]));
        }
    }


    self.PhilosophyPreferenceOptions_Male = ko.observableArray();
    if (_in.PhilosophyPreferenceOptions_Male != null) {
        for (var i = 0; i < _in.PhilosophyPreferenceOptions_Male.length; i++) {
            self.PhilosophyPreferenceOptions_Male.push(new VMPhilosophyOption(_in.PhilosophyPreferenceOptions_Male[i]));
        }
    }


    self.PhilosophyPreferenceOptions_Female = ko.observableArray();
    if (_in.PhilosophyPreferenceOptions_Female != null) {
        for (var i = 0; i < _in.PhilosophyPreferenceOptions_Female.length; i++) {
            self.PhilosophyPreferenceOptions_Female.push(new VMPhilosophyOption(_in.PhilosophyPreferenceOptions_Female[i]));
        }
    }

    self.PreferenceTextInputType = ko.observable(_in.PreferenceTextInputType);
    self.PreferenceAutoFillJsonPath = ko.observable(_in.PreferenceAutoFillJsonPath);
    self.PreferenceSelectAllText_One = ko.observable(_in.PreferenceSelectAllText_One);
    self.PreferenceSelectAllTextEnable_One = ko.computed(function () {
        if (self.PreferenceSelectAllText_One == null) {
            return false;
        }
        if (self.PreferenceSelectAllText_One == "") {
            return false;
        }
        return true;
    }, this);

    self.PreferenceSelectAllText_Two = ko.observable(_in.PreferenceSelectAllText_Two);
    self.SortPreferenceOptionsAlphabetically = ko.observable(_in.SortPreferenceOptionsAlphabetically);
    self.MatchSuccessText = ko.observable(_in.MatchSuccessText);
    self.MatchFailText = ko.observable(_in.MatchFailText);
    self.HidePhilosophyInUserMatch = ko.observable(_in.HidePhilosophyInUserMatch);
    self.HidePhilosophyInOtherUserMatch = ko.observable(_in.HidePhilosophyInOtherUserMatch);
    self.HideOtherUserValue = ko.observable(_in.HideOtherUserValue);
    self.Status = ko.observable(_in.Status);
    self.AddedDate = ko.observable(_in.AddedDate);
    self.Position = ko.observable(_in.Position);
    self.Comment = ko.observable(_in.Comment);
    //

    // Overrides
    self.PhilosophyEditUrl = ko.computed(function () {
        return _SitePath + "web/inner/Philosophyedit?c=" + self._id();
    }, this);

    self.QuestionDivID = ko.computed(function () {
        return "qdiv_" + self._id();
    }, this);

    self.HasUserAnswered = ko.observable(false);
    self.ShowThisQuestion = ko.observable(false);

    self.UserAssignedPoints = ko.observable(0);
    self.AllowAssigningPoints = ko.observable(false);

    self.MyAnswer = ko.observable("");
    self.AcceptableAnswers = ko.observable("");
    self.UnacceptableAnswers = ko.observable("");

    self.GetUserAssignedPoints = ko.computed(function () {
        var _getUserAnswerAPI = _SitePath + "api/GetPhilosophyUserAnswer";
        var _getUserAnswerData = new Object();
        _getUserAnswerData.Philosophy_id = self._id();

        $.postDATA(_getUserAnswerAPI, _getUserAnswerData, function (_return) {
            if (_return != null) {

                self.UserAssignedPoints(_return.PointsAssigned);
                if (_return.UserPreferenceMultiple == null && _return.UserPreferenceRange == null) {
                    self.AllowAssigningPoints(false);
                }
                else {

                    if (_return.HasAllPreferencesSelected) {
                        self.AllowAssigningPoints(false);
                    }
                    else {
                        self.AllowAssigningPoints(true);
                    }


                }
                //alert("self.PhilosophyType()" + self.PhilosophyType());
                //alert("self.PhilosophyPreferenceType()" + self.PhilosophyPreferenceType());

                switch (eval(self.PhilosophyType())) {
                    case 1: {
                        self.MyAnswer(_return.UserOptionString);
                        break;
                    }
                    case 2: {
                        self.MyAnswer(_return.UserOptionMultipleString);
                        break;
                    }
                    case 7: {
                        self.MyAnswer(_return.UserOptionDateString);
                        break;
                    }
                    case 8: {
                        self.MyAnswer(_return.UserText.Value);
                        break;
                    }
                }

                switch (eval(self.PhilosophyPreferenceType())) {
                    case 1: {
                        self.AcceptableAnswers(_return.UserPreferenceMultipleString);
                        self.UnacceptableAnswers(_return.UserNonPreferenceMultipleString);
                        break;
                    }
                    case 3: {
                        self.AcceptableAnswers(_return.UserPreferenceRangeString);
                        self.UnacceptableAnswers(_return.UserNonPreferenceRangeString);
                        break;
                    }
                    case 4: {
                        self.AcceptableAnswers(_return.UserPreferenceRangeString);
                        self.UnacceptableAnswers(_return.UserNonPreferenceRangeString);
                        break;
                    }
                }

            }
            else {
                self.AllowAssigningPoints(false);
            }
        });

    });




}

function VMPhilosophyOption(_in) {
    var self = this;
    self._id = ko.observable(_in._id);
    self.OptionID = ko.observable(_in.OptionID);
    self.OptionText = ko.observable(_in.OptionText);

    self.OptionCheckID = ko.computed(function () {
        return "chk_" + self._id();
    }, this);

    self.OptionPrefCheckID = ko.computed(function () {
        return "prefchk_" + self._id();
    }, this);

}

function CheckAnySelected() {
    var _anyChecked = false;
    $(".PhilosophyOptions").each(function (_pos, _obj) {
        if ($(_obj).is(":checked")) {
            _anyChecked = true;
        }
    });
    return _anyChecked;
}

function CheckAnyPrefSelected() {
    var _anyChecked = false;
    var _anyUnchecked = false;
    $(".PhilosophyPrefOptions").each(function (_pos, _obj) {
        if ($(_obj).is(":checked")) {
            _anyChecked = true;
        }
        else {
            _anyUnchecked = true;
        }
    });


    return _anyChecked;
}

function PostLoadEachQuestion() {
    $(".PhilosophyOptions").click(function () {
        CheckSubmitDisable();

    });

    $("#txtSalary").keyup(function () {
        CheckSubmitDisable();
    });

    $("#txtSalary").blur(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryFrom").keyup(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryFrom").blur(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryTo").keyup(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryTo").blur(function () {
        CheckSubmitDisable();
    });

    $(".PhilosophyPrefOptions").click(function () {
        CheckSubmitDisable();

        if ($(this).is(":checked") == false) {
            $("#chkSelectAll").prop("checked", false);
        }
        else {
            var _allChecked = true;
            $(".PhilosophyPrefOptions").each(function (_pos, _obj) {
                if ($(_obj).is(":checked") == false) {
                    _allChecked = false;
                }
            });

            if (_allChecked) {
                $("#chkSelectAll").prop("checked", true);
            }
        }
    });

    $("#chkSelectAll").click(function () {
        var _check = $(this).is(":checked");
        $(".philosophyPrefOptions").each(function (_pos, _obj) {
            $(_obj).prop("checked", _check);
        });
    });

    $(".PhilosophyPrefOptions").click(function () {
        var _allChecked = true;
        $(".PhilosophyPrefOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked") == false) {
                _allChecked = false;
            }
        });

        if (_allChecked) {
            $("#chkSelectAll").prop("checked", true);
        }
    });

}