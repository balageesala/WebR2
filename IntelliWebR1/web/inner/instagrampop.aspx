<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="instagrampop.aspx.cs" Inherits="IntelliWebR1.web.inner.instagrampop" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<style type="text/css">
    .imagescls{
        padding:4px;
        float:left;
        height: 150px;
        width: 150px;
        background:#fff;
        border:1px solid #808080;
        cursor:pointer;
    }
    .selectimage{
        background:#034912;
    }

</style>

<div style="width: 780px; min-height: 310px; border: 0px solid #ccc; margin: 0 auto; border-radius: 2px 4px;" >
    <div style="float:left;width:100%;padding-top:10px;">
    <div style="float: right;">
        <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
    </div>
    </div>
   
   <div id="divImagesPopup">
    <div style="float: left; width: 100%;">
        <div style="padding:4px;border:1px solid #ccc;margin-top:10px;height:520px;border-radius:6px 6px;" id="divImstaImages"></div>
    </div>
    <div style="float: right;padding-top:10px;">
        <input type="button" id="btnUploadImages" class="composeSend" value="Upload selected" />
    </div>


    <div id="lblMessageResponse" style="min-height: 20px; float: left; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin-left: 20px; padding-top: 10px;">
    </div>
    </div>

</div>

<script type="text/javascript">

    $(document).ready(function () {

        var SESSION_API = _SitePath + "api/SessionCheck";
        $.getDATA(SESSION_API, function (_IsOnline) {
            if (!_IsOnline) {
                window.location.href = _SitePath + "web/LogOut";
                window.parent.CloseIntelliWindow();
            } else {
                return true;
            }
        }, function () { });

    });

    $(document).ready(function () {

        $(".imgClose").click(function () {
            window.parent.CloseIntelliWindow();
            window.parent.location.reload();
        });

        $("#divImagesPopup").hide();
        var _userID = getParameterByName("userID");
        var access_token = getParameterByName("acckey");

            var userFeed = new Instafeed({
                get: 'user',
                userId: eval(_userID),
                accessToken: access_token,
                filter: function (_images) {
                    // alert(JSON.stringify(_images));
                    $("#divImagesPopup").show();
                    var image = '<div class="imagescls"><img style="height: 150px;width: 150px;" src="' + _images.images.standard_resolution.url + '" alt="" /></div>';
                    $(image).appendTo("#divImstaImages");
                }
            });
            userFeed.run();
      
            $("#divImstaImages").on('click', 'div', function () {
                $(this).toggleClass("selectimage");
            });

            $("#btnUploadImages").click(function () {
                $("#btnUploadImages").attr('disabled', 'disabled');
                $("#btnUploadImages").addClass("disableButton");
                
                var imgUrls = new Array();
                $('.selectimage').find('img').each(function (img) {
                    imgUrls.push($(this).attr("src"));
                })

                 //alert(JSON.stringify(imgUrls));

                for (var i = 0; i < imgUrls.length; i++) {

                    //post data
                    var _photoName = imgUrls[i].split("/")[imgUrls[i].split("/").length - 1];
                    //alert(_photoName);
                    _FileObj = new Object();
                    _FileObj.PhotoUrl = imgUrls[i];
                    _FileObj.PhotoFileName = _photoName;
                    _FileObj.IsDefaultPhoto = false;
                    
                    var _postUrl = _SitePath + "web/service/UrlUpload";

                    var _Crop = "?crop=y";
                    _Crop = _Crop + "&X1=50";
                    _Crop = _Crop + "&X2=50";
                    _Crop = _Crop + "&Y1=50";
                    _Crop = _Crop + "&Y2=50";

                    _postUrl = _postUrl + _Crop;
                    $.postDATA(_postUrl, _FileObj, function () {
                        $("#lblMessageResponse").html( i + " Photo(s) uploaded")
                    });
                }




            });



    });

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

</script>
