
function ShowThisQuestions(_sUrl) {

    $("#divOtherProfileQuestions").load(_sUrl, function () {
      
    });
}



$(document).ready(function () {



    var _pathurl = window.location.href;

    if (_pathurl.indexOf('#') != "-1") {
        var _tabSection = _pathurl.split('#')[1];
        if (_tabSection == "criteria") {
            NoBlockBar();
            $("#divOtherProfileCriteria").load(_criteriaPath, function () {
                //divLoadCriteriaMatchp
                var _CmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=c";
                $("#divLoadCriteriaMatchp").load(_CmatchpPath, function () {
                   
                });

            });
        }
        if (_tabSection == "questions") {
            NoBlockBar();
            $("#divOtherProfileQuestions").load(_questionsPath, function () {
                var _QmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=q";
                $("#divLoadProfileMatchp").load(_QmatchpPath, function () {

                });

            });
        }
    }



    //hide all divs here
    $("#divOtherProfileContainer").hide();
    $("#divOtherProfilePhotos").hide();
    $("#divOtherProfileCriteria").hide();
    $("#divOtherProfileQuestions").hide();
    $("#divLoadCriteriaMatchp").hide();
    //load all tabs here
    var _writtenPath = _SitePath + "web/inner/profilewritten";
    var _photosPath = _SitePath + "web/inner/profilephotos";
    var _criteriaPath = _SitePath + "web/inner/profilecriteria?OtherUserID=" + _OtherUserID + "&OtherUserGender=" + _OtherUserGender;
    var _questionsPath = _SitePath + "web/inner/profilequestions?u=" + _OtherUserID;


    $("#divOtherProfileContainer").load(_writtenPath, function () {
       
    });
    $("#divOtherProfilePhotos").load(_photosPath, function () {
    });


    $("#divOtherProfileCriteria").load(_criteriaPath, function () {
        //divLoadCriteriaMatchp
        var _CmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=c";
        $("#divLoadCriteriaMatchp").load(_CmatchpPath, function () {
        });
    });

    $("#divOtherProfileQuestions").load(_questionsPath, function () {
        var _QmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=q";
        $("#divLoadProfileMatchp").load(_QmatchpPath, function () {
        });
    });


    var _passportUrl = _SitePath + "web/inner/theirpassport?uid=" + _OtherUserID;
    $("#divPassPort").load(_passportUrl, function () {
    });



      var API_ResetMatchp = _SitePath + "api/ResetMatchPercentages";
      var _MatchpObject = new Object();
      _MatchpObject.OtherUserID = _OtherUserID;
      $.postDATA(API_ResetMatchp, _MatchpObject, function (_ret) {
      });



    $("#liOtherWritten").click(function (event) {

        showAboutUs();

     });

     $("#liOtherPhotos").click(function (event) {

         showPhotos();
        
        
     });

     $("#liOtherCriteria").click(function (event) {

         NoBlockBar();
         showCriteria();
         
      });

     $("#liOtherQuestions").click(function (event) {
         NoBlockBar();
         showQuestions();
         LoadGenaralQuestions();

      });

});


//external functions

function CrearAllActiveClasses() {

    $("#liOtherWritten").removeClass("active");
    $("#liOtherPhotos").removeClass("active");
    $("#liOtherCriteria").removeClass("active");
    $("#liOtherQuestions").removeClass("active");

}


function showAboutUs() {
    yesBlockBar();
    $("#divOtherProfileContainer").show();
    $("#divOtherProfilePhotos").hide();
    $("#divOtherProfileCriteria").hide();
    $("#divOtherProfileQuestions").hide();
    CrearAllActiveClasses();
    $("#liOtherWritten").addClass("active");
    $("#divPassPort").show();
    $("#divLoadProfileMatchp").hide();
    $("#divLoadCriteriaMatchp").hide();
    $("#divLoadProfileMatchp").hide();
    window.location.hash = "aboutme";
    $("#divprofilemenu").addClass("widthchange1");
    $("#divprofilemenu").removeClass("widthchange2");
}

function showPhotos() {
    yesBlockBar();
    $("#divOtherProfileContainer").hide();
    $("#divOtherProfilePhotos").show();
    $("#divOtherProfileCriteria").hide();
    $("#divOtherProfileQuestions").hide();
    CrearAllActiveClasses();
    $("#liOtherPhotos").addClass("active");

    $("#divprofilemenu").addClass("widthchange2");
    $("#divprofilemenu").removeClass("widthchange1");
    $("#topmenustrip_imgUserIcon").show();
    $("#divPassPort").show();
    $(".divBlockBox").hide();
    $("#divLoadProfileMatchp").hide();
    $("#divLoadCriteriaMatchp").hide();
    $("#divLoadProfileMatchp").hide();
    window.location.hash = "photos";

}

function showCriteria() {

    $("#divOtherProfileContainer").hide();
    $("#divOtherProfilePhotos").hide();
    $("#divOtherProfileCriteria").show();
    $("#divOtherProfileQuestions").hide();
    CrearAllActiveClasses();
    $("#divprofilemenu").addClass("widthchange2");
    $("#divprofilemenu").removeClass("widthchange1");
    $("#topmenustrip_imgUserIcon").hide();
    $(".divBlockBox").hide();
    $("#divPassPort").hide();
    $("#liOtherCriteria").addClass("active");
    $("#divLoadCriteriaMatchp").show();
    $("#divLoadProfileMatchp").hide();
    window.location.hash = "criteria";
}

function showQuestions() {

    $("#divOtherProfileContainer").hide();
    $("#divOtherProfilePhotos").hide();
    $("#divOtherProfileCriteria").hide();
    $("#divOtherProfileQuestions").show();
    CrearAllActiveClasses();
    $("#divprofilemenu").addClass("widthchange2");
    $("#divprofilemenu").removeClass("widthchange1");
    $("#topmenustrip_imgUserIcon").hide();
    $("#divPassPort").hide();
    $("#liOtherQuestions").addClass("active");
    $("#divLoadCriteriaMatchp").hide();
    $("#divLoadProfileMatchp").show();
    window.location.hash = "questions";

}






$(document).ready(function () {

    ShowAvilableTabsOnly();
    var _pathurl = window.location.href;

        if (_pathurl.indexOf('#') != "-1") {
            var _tabSection = _pathurl.split('#')[1];
            if (_tabSection == "aboutme") {
                showAboutUs();
            }
            if (_tabSection == "photos") {
                showPhotos();
            }
            if (_tabSection == "criteria") {
                showCriteria();
            }
            if (_tabSection == "questions") {
               showQuestions();
            }
        } else {
            showAboutUs();
        }
});






function ShowAvilableTabsOnly() {
    
        $("#liOtherWritten").hide();
        $("#liOtherPhotos").hide();
        $("#liOtherCriteria").hide();
        $("#liOtherQuestions").hide();
        var API_OTHERUSER_PROFILE = _SitePath + "api/GetTabNames";
        var _Object = new Object();
        _Object.OtherUserID = _OtherUserID;
        $.postDATA(API_OTHERUSER_PROFILE, _Object, function (_ret) {
            for (var i = 0; i < _ret.length; i++) {
                if (_ret[i] == "aboutme") {
                    $("#liOtherWritten").show();
                }
                if (_ret[i] == "photos") {
                    $("#liOtherPhotos").show();
                }
                if (_ret[i] == "criteria") {
                    $("#liOtherCriteria").show();
                }
                if (_ret[i] == "questions") {
                    $("#liOtherQuestions").show();
                }
            }
           
        });
}


function NoBlockBar() {
    $(".thirteen").addClass("increasewd");
    $(".thirteen_top_nav").addClass("tabwidth");
}

function yesBlockBar() {
    $(".thirteen").removeClass("increasewd");
    $(".thirteen_top_nav").removeClass("tabwidth");
}