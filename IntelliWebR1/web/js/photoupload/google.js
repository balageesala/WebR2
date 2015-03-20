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

        var docid = data.docs[0].id;
        
        var _imageName = data.docs[0].name;
        var _thumburl = "https://docs.google.com/uc?authuser=0&id=" + docid + "&export=download";;
        var _fullUrl = "https://googledrive.com/thumb/" + docid + "?access_token=" + accessToken;

        var loadingImage = loadImage(
                  _thumburl,
                  function (img) {

                      var _ImageWidth = img.width;
                      var _ImageHeight = img.height;

                      if (_ImageWidth < 200 || _ImageHeight < 200) {
                          alert("Please use a larger picture");
                          return;
                      }


                      $(".hdnX1").val(0);
                      $(".hdnY1").val(0);
                      $(".hdnX2").val(200);
                      $(".hdnY2").val(200);

                      $(img).attr("id", "imgPreview200");

                      $(".imgareaselect-selection").parent().remove();
                      $(".imgareaselect-outer").remove();

                      $(img).removeAttr("width");
                      $(img).removeAttr("height");
                      $("#divPhotoPreview").empty();
                      $("#divPhotoPreview").append(img);

                      $("#btnSubmit").removeClass("Disabled");

                      $(img).imgAreaSelect({
                          enable: true,
                          handles: true,
                          aspectRatio: "1:1",
                          x1: 0,
                          y1: 0,
                          x2: eval(_ImageWidth/2),
                          y2: eval(_ImageWidth/2),
                          imageHeight: _ImageHeight,
                          imageWidth: _ImageWidth,
                          onSelectEnd: function (_img, selection) {
                              $("#hdnX1").val(selection.x1);
                              $("#hdnY1").val(selection.y1);
                              $("#hdnX2").val(selection.width);
                              $("#hdnY2").val(selection.height);

                              $("#hdnImageUrl").val(_fullUrl);
                              $("#hdnImageName").val(_imageName);
                          }
                      });
                  },
                  { canvas: false, crop: false }
              );

           
    }
    
}





