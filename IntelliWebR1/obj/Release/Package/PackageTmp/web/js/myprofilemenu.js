
$(document).ready(function () {

    // enable tab events
    $(document).keydown(function (e) {
        if (e.keyCode == 13) {
            //check foucs button
            var _IsCheckYourWork = $("#liCheckYourWork").is(":focus");
            var _IsGenaral = $("#liGenaral").is(":focus");
            var _IsSex = $("#liSex").is(":focus");
            var _IsRankOrder = $("#liRankOrder").is(":focus");
            if (_IsCheckYourWork) {
                $("#liCheckYourWork").trigger("click");
            }
            if (_IsGenaral) {
                $("#liGenaral").trigger("click");
            }
            if (_IsSex) {
                $("#liSex").trigger("click");
            }
            if (_IsRankOrder) {
                $("#liRankOrder").trigger("click");
            }
        }
    });




    SetDefaultPage();
    $("#liCheckYourWork").click(function () {
        clearActiveclass();
        SetCheckYourWork();
    });

    $("#liGenaral").click(function () {
        clearActiveclass();
        SetNormalQuestions();
    });

    $("#liSex").click(function () {
        clearActiveclass();
        SetSexQuestions();
    });

    $("#liRankOrder").click(function () {
        clearActiveclass();
        SetQuestionsRankOrder();
    });

});

function ChangeWidthforCheckYourWork() {

    $(".eleven").css("width", "100%");
    $(".ninth_top_nav").css("width", "97.5%");
    $("#divMyProfileContainer").css("width", "930px");
    $("#divMyProfileContainer").css("margin", "0px");
}

function ResetWidthfoRemaningTabs() {
    $(".eleven").css("width", "740px");
    $(".ninth_top_nav").css("width", "718px");
    $("#divMyProfileContainer").css("width", "744px");
    $("#divMyProfileContainer").css("margin", "0px");
}


function SetDefaultPage() {
    var _pathurl = window.location.href;
    clearActiveclass();
    if (_pathurl.indexOf('#') != "-1") {
        var _tabSection = _pathurl.split('#')[1];
        if (_tabSection == "checkwork") {
            SetCheckYourWork();
        }
        if (_tabSection == "questionsnormal") {
            SetNormalQuestions();
        }
        if (_tabSection == "questionssex") {
            SetSexQuestions();
        }
        if (_tabSection == "rankorder") {
            SetQuestionsRankOrder();
        }
    } else {
        SetCheckYourWork();
    }
}



function clearActiveclass() {
    ResetWidthfoRemaningTabs();
    $("#liQuestions").addClass("active");
    $("#liCheckYourWork").css("color", "#000000");
    $("#liGenaral").css("color", "#000000");
    $("#liSex").css("color", "#000000");
    $("#liRankOrder").css("color", "#000000");
}


function SetCheckYourWork() {
    ChangeWidthforCheckYourWork();
    var _UrlPath = _SitePath + "web/inner/myprofilequestionscmw";
    $("#divMyProfileContainer").empty();
   
    $("#divMyProfileContainer").load(_UrlPath, function () {
        window.location.hash = "checkwork";
        $("#liCheckYourWork").css("color", "red");
    });
}



function SetSexQuestions() {
    var _UrlPath = _SitePath + "web/inner/myprofilesexquestions";
    $("#divMyProfileContainer").empty();
    $("#divMyProfileContainer").load(_UrlPath, function () {
        window.location.hash = "questionssex";
        $("#liSex").css("color", "red");
    });
}

function SetNormalQuestions() {
    var _UrlPath = _SitePath + "web/inner/myprofilequestions";
    $("#divMyProfileContainer").empty();
    $("#divMyProfileContainer").load(_UrlPath, function () {
        window.location.hash = "questionsnormal";
        $("#liGenaral").css("color", "red");
    });
}


function SetQuestionsRankOrder() {
    var _UrlPath = _SitePath + "web/inner/myprofilerankorder";
    $("#divMyProfileContainer").empty();
    $("#divMyProfileContainer").load(_UrlPath, function () {
        window.location.hash = "rankorder";
        $("#liRankOrder").css("color", "red");
    });
}

