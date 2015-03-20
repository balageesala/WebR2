var _CurrentQuestionID = "";

function VMCriteriaQuestionList(_list) {
    var self = this;
    self.AllQuestions = ko.observableArray();

    for (var i = 0; i < _list.length; i++) {
        self.AllQuestions.push(new VMCriteriaQuestion(_list[i], i + 1, _list.length));
    }

    ko.bindingHandlers.animate = {
        update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).animate(valueAccessor(), 1000);
        }
    };



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
        if (self.AllQuestions()[_pos].CriteriaType() == '1') {
            _enableButton = CheckAnySelected();
        }

        if (self.AllQuestions()[_pos].CriteriaType() == '2') {
            _enableButton = CheckAnySelected();
        }

        // Date of birth
        if (self.AllQuestions()[_pos].CriteriaType() == '7') {
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
                            $("#lblCriteriaDobError").html("You should be atleast 21 years.");
                        }
                        if (_return == 1 && _enableButton == true) {
                            _enableButton = true;
                            EnableButton("#btnSubmit");
                            $("#lblCriteriaDobError").html("&nbsp;");
                        }
                    }
                    else {
                        if (_return == 1) {
                            EnableButton("#btnSubmit");
                            $("#lblCriteriaDobError").html("&nbsp;");
                            return true;
                        }
                        else if (_return == -2) {
                            DisableButton("#btnSubmit");
                            $("#lblCriteriaDobError").html("You should be atleast 21 years.");
                            return true;
                        }
                        else {
                            DisableButton("#btnSubmit");
                            $("#lblCriteriaDobError").html("The date of birth you have entered is invalid");
                            return true;
                        }
                    }

                });
            }
            else {
                $("#lblCriteriaDobError").html("&nbsp;");
            }
        }

        if (self.AllQuestions()[_pos].CriteriaType() == '8') {
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

            if (self.AllQuestions()[_pos].CriteriaPreferenceType() == '1') {
                _enableButton = CheckAnyPrefSelected();
            }

            if (self.AllQuestions()[_pos].CriteriaPreferenceType() == '3') {
                if ($(".SelectOptionsOne").val() != "0" && $(".SelectOptionsTwo").val() != "0") {
                    if (eval($(".SelectOptionsTwo  option:selected").text()) >= eval($(".SelectOptionsOne  option:selected").text())) {
                        _enableButton = true;
                    }
                }
                else {
                    _enableButton = false;
                }
            }

            if (self.AllQuestions()[_pos].CriteriaPreferenceType() == '4') {
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


                if (_fromSal || _toSal) {
                    _enableButton = true;
                }
                else {
                    _enableButton = false;
                }

                if (isNaN(_salaryToEntered) == false || isNaN(_salaryFromEntered) == false) {
                    _enableButton = true;
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
            window.location.href = _SitePath + "web/CriteriaPoints";
        }


        if (_currentCriteria == "") {
            var _CriteriaCheck = new Object();
            _CriteriaCheck.CriteriaQuestionID = self.AllQuestions()[_pos]._id();

            var _Api = _SitePath + "api/CheckHasUserAnswered";
            $.postDATA(_Api, _CriteriaCheck, function (_return) {
                if (_return == false) {
                    DisplayQuestion(_CriteriaCheck.CriteriaQuestionID);
                }
                else {
                    self.AllQuestions()[_pos].HasUserAnswered(true);
                    ShowFirstUnAnswered();
                }
            });
        }
        else {

            var _CriteriaCheck = new Object();
            _CriteriaCheck.CriteriaQuestionID = _currentCriteria;

            var _Api = _SitePath + "api/CheckHasUserAnswered";
            $.postDATA(_Api, _CriteriaCheck, function (_return) {
                if (_return == true) {
                    SetUserAnswered(_currentCriteria);
                }
                DisplayQuestion(_currentCriteria);
            });
        }
        ChangeButtonStatus();
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

            if (typeof window.parent.SetCriteria !== 'undefined' && $.isFunction(window.parent.SetCriteria)) {
                window.parent.SetCriteria();
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
            window.location.href = _SitePath + "web/CriteriaPoints";
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

            // Post the criteria in cookie
            var _postPosAPI = _SitePath + "web/service/CriteriaPosition";

            var _postData = new Object();
            _postData.Criteria_id = self.AllQuestions()[_pos]._id();

            $.postDATA(_postPosAPI, _postData, function (_hasUserAnswered) {
                if (_hasUserAnswered) {
                    SetUserAnswered(self.AllQuestions()[_pos]._id());
                }

                _CurrentQuestionID = _questionID;
                if (self.AllQuestions()[_pos].CriteriaType() == '7') {
                    FillUserDateOfBirth();
                }

                if (self.AllQuestions()[_pos].HasUserAnswered()) {
                    self.AllQuestions()[_pos].ShowPartTwo(true);

                    // Get User Answer
                    var _userAnswerAPI = _SitePath + "api/GetCriteriaUserAnswer";
                    var _postData = new Object();
                    _postData.Criteria_id = self.AllQuestions()[_pos]._id();

                    $.postDATA(_userAnswerAPI, _postData, function (_return) {
                        var _partOneSelected = false;
                        var _partTwoSelected = false;


                        if (eval(self.AllQuestions()[_pos].CriteriaType()) == 1) {
                            $(".criteriaOptions").each(function (_pos, _obj) {
                                if (_return != null) {
                                    if (_return.UserOption != null) {
                                        if (_return.UserOption._id != null) {
                                            if ($(_obj).val() == _return.UserOption._id) {
                                                $(_obj).prop("checked", true);
                                                _partOneSelected = true;
                                               
                                            }
                                        }
                                       
                                    }
                                }
                            });
                        }

                        if (eval(self.AllQuestions()[_pos].CriteriaType()) == 2) {
                            $(".criteriaOptions").each(function (_pos, _obj) {
                                if (_return != null) {
                                    if (_return.UserOptionMultiple != null) {
                                        if (_return.UserOptionMultiple._ids != null) {
                                            for (var i = 0; i < _return.UserOptionMultiple._ids.length; i++) {
                                                if ($(_obj).val() == _return.UserOptionMultiple._ids[i]) {
                                                    $(_obj).prop("checked", true);
                                                    _partOneSelected = true;
                                                    
                                                }
                                            }
                                        }
                                    }
                                }

                            });
                        }

                        if (eval(self.AllQuestions()[_pos].CriteriaType()) == 7) {

                        }

                        if (eval(self.AllQuestions()[_pos].CriteriaType()) == 8) {
                            if (_return != null) {
                                $("#txtSalary").val(_return.UserText.Value);
                                if (_return.UserText.Value != "") {
                                    EnableButton("#btnSubmit");
                                }
                            }
                        }


                        if (eval(self.AllQuestions()[_pos].CriteriaPreferenceType()) == 1) {
                            $(".criteriaPrefOptions").each(function (_pos, _obj) {
                                if (_return != null) {
                                    if (_return.UserPreferenceMultiple != null) {
                                        if (_return.UserPreferenceMultiple._ids != null) {
                                            for (var i = 0; i < _return.UserPreferenceMultiple._ids.length; i++) {
                                                if ($(_obj).val() == _return.UserPreferenceMultiple._ids[i]) {
                                                    $(_obj).prop("checked", true);
                                                    _partTwoSelected = true;
                                                   
                                                }
                                            }
                                        }
                                    }

                                }

                            });
                        }

                        if (eval(self.AllQuestions()[_pos].CriteriaPreferenceType()) == 3) {
                            $(".SelectOptionsOne").val(_return.UserPreferenceRange.Min);
                            $(".SelectOptionsTwo").val(_return.UserPreferenceRange.Max);
                        }

                        if (eval(self.AllQuestions()[_pos].CriteriaPreferenceType()) == 4) {

                            if (_return != null) {
                                $("#txtSalaryFrom").val(_return.UserPreferenceRange.Min);
                                $("#txtSalaryTo").val(_return.UserPreferenceRange.Max);
                            }

                           
                        }

                        if (_partOneSelected || _partTwoSelected) {
                            EnableButton("#btnSubmit");
                        }

                        PostLoadEachQuestion();
                       // CheckSubmitDisable();
                    });

                }
                else {
                    PostLoadEachQuestion();
                    //CheckSubmitDisable();
                }

            });

        }
        else {
            window.location.href = _SitePath + "web/CriteriaPoints";
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

        for (var i = 0; i < self.AllQuestions()[_pos].CriteriaPreferenceOptions().length; i++) {
            var _prefCheckID = "#prefchk_" + self.AllQuestions()[_pos].CriteriaPreferenceOptions()[i]._id();
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

        for (var i = 0; i < self.AllQuestions()[_pos].CriteriaPreferenceOptions().length; i++) {
            var _prefCheckID = "#prefchk_" + self.AllQuestions()[_pos].CriteriaPreferenceOptions()[i]._id();
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

    GetCriteriaTypeOneObject = function (_data) {
        var _object = new Object();
        _object.Criteria_id = _data._id();
        _object.CriteriaType = _data.CriteriaType();
        _object.UserOption = $(".criteriaOptions:checked").val();
        return _object;
    };

    GetCriteriaTypeTwoObject = function (_data) {
        var _object = new Object();
        _object.Criteria_id = _data._id();
        _object.CriteriaType = _data.CriteriaType();

        var _optionSelected = new Array();
        $(".criteriaOptions").each(function (_pos, _obj) {
            if ($(_obj).is(":checked")) {
                _optionSelected.push($(_obj).val());
            }
        });
        _object.UserOptions = _optionSelected;
        return _object;
    };

    GetCriteriaTypeEightObject = function (_data) {
        var _object = new Object();
        _object.Criteria_id = _data._id();
        _object.CriteriaType = _data.CriteriaType();
        _object.UserOption = $("#txtSalary").val();
        return _object;
    };

    GetCriteriaTypeNineObject = function (_data) {
        var _object = new Object();
        _object.Criteria_id = _data._id();
        _object.CriteriaType = _data.CriteriaType();
        _object.UserOption = $("#txtZipCode").val();
        return _object;
    };



    GetCriteriaTypeSevenObject = function (_data) {
        var _object = new Object();
        _object.Criteria_id = _data._id();
        _object.CriteriaType = _data.CriteriaType();
        _object.UserOption_Month = $(".Month").val();
        _object.UserOption_Day = $(".Day").val();
        _object.UserOption_Year = $(".Year").val();
        return _object;
    }

    GetPreferenceTypeOneObject = function (_data, _object) {
        _object.Criteria_id = _data._id();
        _object.CriteriaPreferenceType = _data.CriteriaPreferenceType();
        _object.HasAllPreferencesSelected = $("#chkSelectAll").is(":checked");


        var _selectedOptions = new Array();
        $(".criteriaPrefOptions").each(function (_pos, _obj) {
            if ($(_obj).prop("checked") == true) {
                _selectedOptions.push($(_obj).val());
            }
        });

        _object.Preferences = _selectedOptions;
        return _object;

        //criteriaPrefOptions
    };

    GetPreferenceTypeThreeObject = function (_data, _object) {

        _object.Criteria_id = _data._id();
        _object.CriteriaPreferenceType = _data.CriteriaPreferenceType();
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
        if (_data.CriteriaType() == 9) {
            _object.Criteria_id = _data._id();
            _object.CriteriaPreferenceType = _data.CriteriaPreferenceType();
            _object.PreferenceRangeMin = 0;
            _object.PreferenceRangeMax = $("#txtDistanceRange").val();
            _object.HasAllPreferencesSelected = false;
        } else {
            _object.Criteria_id = _data._id();
            _object.CriteriaPreferenceType = _data.CriteriaPreferenceType();
            _object.PreferenceRangeMin = $("#txtSalaryFrom").val();
            _object.PreferenceRangeMax = $("#txtSalaryTo").val();
            _object.HasAllPreferencesSelected = false;
        }
       

        return _object;
    };

    PostPartOne = function (_data) {
        var _postObject;
        var _postAPI = _SitePath + "api/AddCriteriaUserAnswer";

        switch (eval(_data.CriteriaType())) {
            case 1: {
                _postObject = GetCriteriaTypeOneObject(_data);
                break;
            }
            case 2: {
                _postObject = GetCriteriaTypeTwoObject(_data);
                break;
            }
            case 7: {
                _postObject = GetCriteriaTypeSevenObject(_data);
                break;
            }
            case 8: {
                _postObject = GetCriteriaTypeEightObject(_data);
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
        var _postAPI = _SitePath + "api/AddCriteriaUserAnswer";

        switch (eval(_data.CriteriaType())) {
            case 1: {
                _postObject = GetCriteriaTypeOneObject(_data);
                break;
            }
            case 2: {
                _postObject = GetCriteriaTypeTwoObject(_data);
                break;
            }
            case 7: {
                _postObject = GetCriteriaTypeSevenObject(_data);
                break;
            }
            case 8: {
                _postObject = GetCriteriaTypeEightObject(_data);
                break;
            }
            case 9: {
                _postObject = GetCriteriaTypeNineObject(_data);
                break;
            }
        }

        switch (eval(_data.CriteriaPreferenceType())) {

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

                var _parentPage = window.parent.location.pathname;
                
                if (_parentPage.indexOf("MyProfileCriteria") != -1) {
                    window.parent.RemoveAndReBindCriteria();
                    window.parent.CloseIntelliWindow();
                } else {
                    window.parent.SetUserAnswered(_data._id());
                    window.parent.CloseIntelliWindow();
                }
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

    ClearAnswer = function (_data) {

        DisableButton("#btnSubmit");

        var _ClearCriteriaAPI = _SitePath + "api/ClearCriteria";
        var _ClearCriteriaObject = new Object();
        _ClearCriteriaObject.Criteria_id = _data._id();

      
        $.postDATA(_ClearCriteriaAPI, _ClearCriteriaObject, function (_return) {
            if (_return) {
                var _parentPage = window.parent.location.pathname;
                if (_parentPage.indexOf("MyProfileCriteria") != -1) {                 
                    $('.paddingfont').find("input:radio:checked").attr('checked', false);
                    $('.paddingfont').find('input[type=checkbox]:checked').each(function () { $(this).removeAttr('checked'); });
                    $('.paddingfont').find("input[type=text]").val("");
                  //  $('.dd option:selected').get(0).selectedIndex = 0;
                    $('select option:first-child').attr("selected", "selected");
                    window.parent.RemoveAndReBindCriteria();
                } else {                   
                    $('.paddingfont').find("input:radio:checked").attr('checked', false);
                    $('.paddingfont').find('input[type=checkbox]:checked').each(function () { $(this).removeAttr('checked'); });
                    $('.paddingfont').find("input[type=text]").val("");
                    $('.dd option:selected').get(0).selectedIndex = 0;
                    window.parent.SetUserAnswered(_data._id());            
                }
            } else {
                $('.paddingfont').find("input:radio:checked").attr('checked', false);
                $('.paddingfont').find('input[type=checkbox]:checked').each(function () { $(this).removeAttr('checked'); });
                $('.paddingfont').find("input[type=text]").val("");
                $('select option:first-child').attr("selected", "selected");
               // $('.dd option:selected').attr('selectedIndex', 0);
                window.parent.SetUserAnswered(_data._id());
            }
        });

    }


    GetPointsAssigned = function () {
        var _criteriaPoints = new Array();
        var _eachPoint = new Object();

        for (var i = 0; i < self.AllQuestions().length; i++) {
            _eachPoint.Criteria_id = self.AllQuestions()[i]._id();
            _eachPoint.Points = self.AllQuestions()[i].UserAssignedPoints();

            _criteriaPoints.push(_eachPoint);
        }

        return _criteriaPoints;
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

function VMCriteriaQuestion(_in, _pos, _total) {
    var self = this;
    self.Index = ko.observable(_pos);
    self.TotalCount = ko.observable(_total);
    self.ShowPartTwo = ko.observable(true);
    self.ShowSkipButton = ko.observable(true);
    self.ShowEditItem = ko.observable(false);
    self.position = ko.observable({ left: 0 });

    self.ShowBackButton = ko.computed(function () {
        if (eval(self.Index()) == 1) {
            return false;
        }
        else {
            return true;
        }
    }, this);

    self._id = ko.observable(_in._id);
    self.CriteriaID = ko.observable(_in.CriteriaID);
    self.CriteriaName = ko.observable(_in.CriteriaName);
    self.QuestionName = ko.observable(_in.QuestionName);
    self.Instruction = ko.observable(_in.Instruction);
    self.CriteriaQuestion = ko.observable(_in.CriteriaQuestion);
    self.CriteriaType = ko.observable(_in.CriteriaType);

    self.CriteriaOptions = ko.observableArray();
    if (_in.CriteriaOptions != null) {
        for (var i = 0; i < _in.CriteriaOptions.length; i++) {
            self.CriteriaOptions.push(new VMCriteriaOption(_in.CriteriaOptions[i]));
        }
    }

    self.CriteriaOptions_One = ko.observableArray();
    if (_in.CriteriaOptions_One != null) {
        for (var i = 0; i < _in.CriteriaOptions_One.length; i++) {
            self.CriteriaOptions_One.push(new VMCriteriaOption(_in.CriteriaOptions_One[i]));
        }
    }


    self.CriteriaOptions_Two = ko.observableArray();
    if (_in.CriteriaOptions_Two != null) {
        for (var i = 0; i < _in.CriteriaOptions_Two.length; i++) {
            self.CriteriaOptions_Two.push(new VMCriteriaOption(_in.CriteriaOptions_Two[i]));
        }
    }


    self.CriteriaOptions_Three = ko.observableArray();
    if (_in.CriteriaOptions_Three != null) {
        for (var i = 0; i < _in.CriteriaOptions_Three.length; i++) {
            self.CriteriaOptions_Three.push(new VMCriteriaOption(_in.CriteriaOptions_Three[i]));
        }
    }


    self.CriteriaOptions_Male = ko.observableArray();
    if (_in.CriteriaOptions_Male != null) {
        for (var i = 0; i < _in.CriteriaOptions_Male.length; i++) {
            self.CriteriaOptions_Male.push(new VMCriteriaOption(_in.CriteriaOptions_Male[i]));
        }
    }


    self.CriteriaOptions_Female = ko.observableArray();
    if (_in.CriteriaOptions_Female != null) {
        for (var i = 0; i < _in.CriteriaOptions_Female.length; i++) {
            self.CriteriaOptions_Female.push(new VMCriteriaOption(_in.CriteriaOptions_Female[i]));
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
    self.CriteriaPreferenceQuestion = ko.observable(_in.CriteriaPreferenceQuestion);
    self.CriteriaPreferenceType = ko.observable(_in.CriteriaPreferenceType);

    self.CriteriaPreferenceOptions = ko.observableArray();
    if (_in.CriteriaPreferenceOptions != null) {
        for (var i = 0; i < _in.CriteriaPreferenceOptions.length; i++) {
            self.CriteriaPreferenceOptions.push(new VMCriteriaOption(_in.CriteriaPreferenceOptions[i]));
        }
    }


    self.CriteriaPreferenceOptions_One = ko.observableArray();
    if (_in.CriteriaPreferenceOptions_One != null) {
        for (var i = 0; i < _in.CriteriaPreferenceOptions_One.length; i++) {
            self.CriteriaPreferenceOptions_One.push(new VMCriteriaOption(_in.CriteriaPreferenceOptions_One[i]));
        }
    }


    self.CriteriaPreferenceOptions_Two = ko.observableArray();
    if (_in.CriteriaPreferenceOptions_Two != null) {
        for (var i = 0; i < _in.CriteriaPreferenceOptions_Two.length; i++) {
            self.CriteriaPreferenceOptions_Two.push(new VMCriteriaOption(_in.CriteriaPreferenceOptions_Two[i]));
        }
    }


    self.CriteriaPreferenceOptions_Three = ko.observableArray();
    if (_in.CriteriaPreferenceOptions_Three != null) {
        for (var i = 0; i < _in.CriteriaPreferenceOptions_Three.length; i++) {
            self.CriteriaPreferenceOptions_Three.push(new VMCriteriaOption(_in.CriteriaPreferenceOptions_Three[i]));
        }
    }


    self.CriteriaPreferenceOptions_Male = ko.observableArray();
    if (_in.CriteriaPreferenceOptions_Male != null) {
        for (var i = 0; i < _in.CriteriaPreferenceOptions_Male.length; i++) {
            self.CriteriaPreferenceOptions_Male.push(new VMCriteriaOption(_in.CriteriaPreferenceOptions_Male[i]));
        }
    }


    self.CriteriaPreferenceOptions_Female = ko.observableArray();
    if (_in.CriteriaPreferenceOptions_Female != null) {
        for (var i = 0; i < _in.CriteriaPreferenceOptions_Female.length; i++) {
            self.CriteriaPreferenceOptions_Female.push(new VMCriteriaOption(_in.CriteriaPreferenceOptions_Female[i]));
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
    self.HideCriteriaInUserMatch = ko.observable(_in.HideCriteriaInUserMatch);
    self.HideCriteriaInOtherUserMatch = ko.observable(_in.HideCriteriaInOtherUserMatch);
    self.HideOtherUserValue = ko.observable(_in.HideOtherUserValue);
    self.Status = ko.observable(_in.Status);
    self.AddedDate = ko.observable(_in.AddedDate);
    self.Position = ko.observable(_in.Position);
    self.Comment = ko.observable(_in.Comment);
    //

    // Overrides
    self.CriteriaEditUrl = ko.computed(function () {
        return _SitePath + "web/inner/criteriaedit?c=" + self._id();
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
        var _getUserAnswerAPI = _SitePath + "api/GetCriteriaUserAnswer";
        var _getUserAnswerData = new Object();
        _getUserAnswerData.Criteria_id = self._id();

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
            
                switch (eval(self.CriteriaType())) {
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

                switch (eval(self.CriteriaPreferenceType())) {
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

function VMCriteriaOption(_in) {
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
    $(".criteriaOptions").each(function (_pos, _obj) {
        if ($(_obj).is(":checked")) {
            _anyChecked = true;
        }
    });
    return _anyChecked;
}

function CheckAnyPrefSelected() {
    var _anyChecked = false;
    var _anyUnchecked = false;
    $(".criteriaPrefOptions").each(function (_pos, _obj) {
        if ($(_obj).is(":checked")) {
            _anyChecked = true;
        }
        else {
            _anyUnchecked = true;
        }
    });


    return _anyChecked;
}



$(document).ready(function () {

    $("#txtSalaryTo").keyup(function () {

        EnableSalryButton();
    });

    $("#txtSalaryTo").blur(function () {

        EnableSalryButton();

    });

    $('.clsDistanceRange').keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $('#lblCriteriaDistanceeError').html("Enter numbers only.").show().fadeOut(4000);
            return false;
        }
    });

    $(".clsDistanceRange").blur(function () {
        
        var m_value = $(".clsDistanceRange").val();


    });

});


function EnableSalryButton() {

    //var _txtsal = $("#txtSalary").val();
    //var _txttosal = $("#txtSalaryTo").val();
    //var _txtfromsal = $("#txtSalaryFrom").val();

    //if (_txtsal != "" && _txttosal != "" && _txtfromsal != "") {

    //    EnableButton("btnSubmit")
    //}
}




function PostLoadEachQuestion() {
    
    $(".criteriaOptions").click(function () {
        // CheckSubmitDisable();

        if ($("input:checked").length > 0) {
            EnableButton("#btnSubmit");
        } else {
            DisableButton("#btnSubmit");
        }
       
    });

    $("#txtSalary").keyup(function () {
        CheckSubmitDisable();
    });

    $("#txtSalary").blur(function () {
          CheckSubmitDisable();
    });

    $("#txtSalary").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $('#lblCriteriaSalaryError').html("Enter numbers only.").show().fadeOut(4000);
            DisableButton("#btnSubmit");
            return false;
        }
    });

    $("#txtSalaryFrom").keyup(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryFrom").blur(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryFrom").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $('#lblCriteriaSalaryError').html("Enter numbers only.").show().fadeOut(4000);
            DisableButton("#btnSubmit");
            return false;
        }
    });


    $("#txtSalaryTo").keyup(function () {
        CheckSubmitDisable();
    });

    $("#txtSalaryTo").blur(function () {
         CheckSubmitDisable();
        
    });

    $("#txtSalaryTo").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $('#lblCriteriaSalaryError').html("Enter numbers only.").show().fadeOut(4000);
            DisableButton("#btnSubmit");
            return false;
        }
    });
    

    $(".criteriaPrefOptions").click(function () {
      //  CheckSubmitDisable();

        if ($(this).is(":checked") == false) {
            $("#chkSelectAll").prop("checked", false);
        }
        else {
            var _allChecked = true;
            $(".criteriaPrefOptions").each(function (_pos, _obj) {
                if ($(_obj).is(":checked") == false) {
                    _allChecked = false;
                    
                } else {
                    
                }
            });

            if (_allChecked) {
                $("#chkSelectAll").prop("checked", true);
            }
        }

        if ($("input:checked").length > 0) {
            EnableButton("#btnSubmit");
        } else {
            DisableButton("#btnSubmit");
        }


    });

    $("#chkSelectAll").click(function () {
        if ($(this).is(":checked")) {
            SelectAllPrefOptions();
        }
        else {
            DeselectAllPrefOptions();
        }
    });

    $("#txtZipCode").keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $('#lblCriteriaZipCodeError').html("Enter numbers only.").show().fadeOut(4000);
            return false;
        }
    });

    $("#txtZipCode").blur(function () {
        var m_value = $("#txtZipCode").val().trim();
        if (m_value.length != 5) {
            $('#lblCriteriaZipCodeError').html("Please provide a valid zipcode.").show().fadeOut(4000);
            return false;
        } else {
           
            //get zipcode address
            var _postZipCodeApi = _SitePath + "api/GetZipCodeAddress";
            var _postZipCodeData = new Object();
            _postZipCodeData.zipcode = m_value;
            $.postDATA(_postZipCodeApi, _postZipCodeData, function (_return) {   
                if (_return != "") {
                    EnableButton("#btnSubmit");
                    $('#lblCriteriaZipCodeError').html(_return).show();
                } else {
                    $('#lblCriteriaZipCodeError').html("Please provide a valid zipcode.").show().fadeOut(4000);
                    return false;
                }
            });

        }

    });


    $('.clsDistanceRange').keypress(function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            $('#lblCriteriaDistanceeError').html("Enter numbers only.").show().fadeOut(4000);
            return false;
        }
    });

    $(".clsDistanceRange").blur(function () {
        var m_value = $("#txtZipCode").val().trim();
        if (m_value.length != 5) {
            $('#lblCriteriaZipCodeError').html("zip code not valid.").show().fadeOut(4000);
            DisableButton("#btnSubmit");
            return false;
        } else {
            var _postZipCodeApi = _SitePath + "api/GetZipCodeAddress";
            var _postZipCodeData = new Object();
            _postZipCodeData.zipcode = m_value;
            $.postDATA(_postZipCodeApi, _postZipCodeData, function (_return) {
                if (_return != "") {
                    EnableButton("#btnSubmit");
                    $('#lblCriteriaZipCodeError').html(_return).show();
                    var m_value = $(".clsDistanceRange").val().trim();
                    if (m_value == "") {
                        DisableButton("#btnSubmit");
                    } else {
                        EnableButton("#btnSubmit");
                    }
                } else {
                    $('#lblCriteriaZipCodeError').html("Please provide a valid zipcode.").show().fadeOut(4000);
                    return false;
                }
            });
        }
    });




    var _allChecked = true;
    $(".criteriaPrefOptions").each(function (_pos, _obj) {
        if ($(_obj).is(":checked") == false) {
            _allChecked = false;
        }
    });

    if (_allChecked) {
        $("#chkSelectAll").prop("checked", true);
    }


    ChangeButtonStatus();


}





function ChangeButtonStatus() {
    if ($("input:checked").length > 0) {
        EnableButton("#btnSubmit");
    } else {
        DisableButton("#btnSubmit");
    }
}