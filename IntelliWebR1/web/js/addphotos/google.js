// The Browser API key obtained from the Google Developers Console.
var developerKey = 'AIzaSyBRIEDXoX_eEWfFcSb6UahBY9sDQnoE-4Q';

// The Client ID obtained from the Google Developers Console.
var clientId = '924511688675-1br18n7rhpcasdvtie72m4cimakhdmua.apps.googleusercontent.com';

// Scope to use to access user's photos.
var scope = ["https://www.googleapis.com/auth/photos", "https://www.googleapis.com/auth/drive"];

var pickerApiLoaded = false;
var oauthToken;

// Use the API Loader script to load google.picker and gapi.auth.
function onApiLoad() {
    gapi.load('auth', { 'callback': onAuthApiLoad });
    gapi.load('picker', { 'callback': onPickerApiLoad });
}

function onAuthApiLoad() {
    window.gapi.auth.authorize(
        {
            'client_id': clientId,
            'scope': scope,
            'immediate': false
        },
        handleAuthResult);
}

function onPickerApiLoad() {
    pickerApiLoaded = true;
    createPicker();
}

function handleAuthResult(authResult) {
    if (authResult && !authResult.error) {
        oauthToken = authResult.access_token;
        createPicker();
    }
}

// Create and render a Picker object for picking user Photos.
function createPicker() {
    if (pickerApiLoaded && oauthToken) {
        var picker = new google.picker.PickerBuilder().
            addView(google.picker.ViewId.DOCS_IMAGES).
            setOAuthToken(oauthToken).
            setDeveloperKey(developerKey).
            setCallback(pickerCallback).
             enableFeature(google.picker.Feature.MULTISELECT_ENABLED).
            build();
        picker.setVisible(true);
    }
}

// A simple callback implementation.

function pickerCallback(data) {
    var url = 'nothing';
    $("#divPhotoPreview").empty();
    $("#btnSubmit").addClass("Disabled");
    _loadingimg = " <img src='images/loading-bar-gif.gif' style='height:362px;' />";
    $("#divPhotoPreview").append(_loadingimg);
    var accessToken = gapi.auth.getToken().access_token;

    if (data[google.picker.Response.ACTION] == google.picker.Action.PICKED) {
        var doc = data[google.picker.Response.DOCUMENTS];
        var _FileObj;
        for (var i = 0; i < doc.length; i++) {
            var docid = data.docs[i].id;
            _FileObj = new Object();
            _FileObj.PhotoUrl = "https://googledrive.com/thumb/" + docid + "?access_token=" + accessToken;
            _FileObj.PhotoFileName = doc[i].name;
            _FileObj.IsDefaultPhoto = false;
              // "https://docs.google.com/uc?authuser=0&id=" + docid + "&export=download";
             //  var  _originalurl = "https://googledrive.com/thumb/" + docid + "?access_token=" + accessToken;
            // alert(_originalurl);
           // alert(_fileName);

          // post data here
         var _postUrl = _SitePath + "web/service/UrlUpload";

         var _Crop = "?crop=y";
         _Crop = _Crop + "&X1=50";
         _Crop = _Crop + "&X2=50";
         _Crop = _Crop + "&Y1=50";
         _Crop = _Crop + "&Y2=50";

         _postUrl = _postUrl + _Crop;
         $.postDATA(_postUrl, _FileObj, function () {
            
         });





        }
    }
    
}



$("#btngoogle").click(function () {

    onApiLoad();

});


