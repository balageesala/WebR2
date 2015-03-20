$(document).ready(function () {
    CheckIsUserOnline();
    var _api = _SitePath + "api/GetAllQuestions";
    $.getDATA(_api, function (_data) {
        ko.applyBindings(new QuestionListVM(_data), document.getElementById("divPhilosophyQuestion"));
        setTimeout(function () {
            ShowFirstUnAnswered();
        }, 1000);

    }, function () { });
});