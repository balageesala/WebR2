<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="makeascoverphoto.aspx.cs" Inherits="IntelliWebR1.web.inner.makeascoverphoto" %>

<style type="text/css">
    .SubmitButton {
        padding: 8px 28px;
        border-radius: 3px;
        background-color: #c1272d;
        height: 34px;
        font-size: 0.9em;
        font-weight: 400;
        letter-spacing: 1px;
        color: #fff;
        text-align: center;
        border: none;
        cursor: pointer;
    }

    .CancelButton {
        padding: 8px 28px;
        border-radius: 3px;
        border-radius: 3px;
        background-color: #787878;
        font-size: 0.85em;
        font-weight: 400;
        color: #fff;
        text-align: center;
        border: none;
        cursor: pointer;
        float: right;
        height: 34px;
    }

    img{
        margin:0 auto;
    }

</style>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>


<form enctype="multipart/form-data" method="post" id="frmPhotoUpload">
    <div class="divmyprofile" style="float: left; background: #fff; width: 1000px; height: 620px; border-radius: 6px 6px;">
        <div style="float: right;">
            <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
        </div>
        <div class="divWhiteBox" style="min-height: 500px; background-repeat: no-repeat; background-position-x: center; background-position-y: center;">
            <div style="height:40px;">&nbsp;</div>
            <div id="divPhotoPreview" style="border: 0px solid #ccc;height: 500px;padding:10px;">
            </div>

            <div style="float:right;margin-right:20px;">
                <div style=" margin-top: 2px;">
                    <div style="float:right;">
                        <input id="btnCancel" type="button" value="Cancel" class="CancelButton" />
                    </div>

                    <div style="float: right; margin-right: 10px;">
                        <input id="btnSubmit" type="button" value="Crop and Save" runat="server" class="SubmitButton" />
                    </div>
                </div>

            </div>

        </div>

        <input type="hidden" id="hdnX1" runat="server" />
        <input type="hidden" id="hdnX2" runat="server" />
        <input type="hidden" id="hdnY1" runat="server" />
        <input type="hidden" id="hdnY2" runat="server" />

        <input type="hidden" id="hdnImageUrl" />
        <input type="hidden" id="hdnImageName" />


    </div>

    <script type="text/javascript">

 $(document).ready(function () {

    $("#divPhotoPreview").empty();

    var loadingImage = loadImage(
        _PhotoPath,
        function (img) {

            var _ImageWidth = img.width;
            var _ImageHeight = img.height;

            if (_ImageWidth < 200 || _ImageHeight < 200) {
                alert("Please use a larger picture");
                window.parent.CloseIntelliWindow();
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

            var m_imgheight ;
            var m_imgwidth ;
            if (_ImageWidth > 600 && _ImageWidth < 1000 || _ImageHeight > 600 && _ImageHeight < 1000) { 
                 m_imgheight = _ImageHeight / 2;
                 m_imgwidth = _ImageWidth / 2;
                $(img).attr("width", m_imgwidth);
                $(img).attr("height", m_imgheight);
            } else if (_ImageWidth > 1000 && _ImageWidth < 2000 || _ImageHeight > 1000 && _ImageHeight < 2000) {
                m_imgheight = _ImageHeight / 4;
                m_imgwidth = _ImageWidth / 4;
            } else if (_ImageWidth > 2000 && _ImageWidth < 3000 || _ImageHeight > 2000 && _ImageHeight < 3000) {
                m_imgheight = _ImageHeight / 6;
                m_imgwidth = _ImageWidth / 6;
               
            } else if (_ImageWidth > 3000 && _ImageWidth < 6000 || _ImageHeight > 3000 && _ImageHeight < 6000) {
                m_imgheight = _ImageHeight / 8;
                m_imgwidth = _ImageWidth / 8;
            } else {
                m_imgheight = _ImageHeight ;
                m_imgwidth = _ImageWidth;
            }

            $(img).attr("width", m_imgwidth);
            $(img).attr("height", m_imgheight);
            $(img).attr("margin", "0 auto");

            $("#divPhotoPreview").css("margin", "0 auto");
            $("#divPhotoPreview").css("width", m_imgwidth);
            $("#divPhotoPreview").append(img);

            $(img).imgAreaSelect({
                enable: true,
                handles: true,
                aspectRatio: "1:1",
                x1: 0,
                y1: 0,
                x2: 200,
                y2: 200,
                imageHeight: _ImageHeight,
                imageWidth: _ImageWidth,
                onSelectEnd: function (_img, selection) {
                    $("#hdnX1").val(selection.x1);
                    $("#hdnY1").val(selection.y1);
                    $("#hdnX2").val(selection.width);
                    $("#hdnY2").val(selection.height);
                }
            });
        },
        { canvas: false, crop: false }
    );


    $("#btnSubmit").click(function () {

        var _postDATA = new Object();
        _postDATA.PhotoUrl = $("#hdnImageUrl").val();
        _postDATA.PhotoFileName = $("#hdnImageName").val();

        var _postUrl = _SitePath + "web/service/MakeProfilePhoto";
        var _PhotoID = getParameterByName("pid");
        var _Crop = "?pid=" + _PhotoID + "&crop=y";
        _Crop = _Crop + "&X1=" + $("#hdnX1").val();
        _Crop = _Crop + "&X2=" + $("#hdnX2").val();
        _Crop = _Crop + "&Y1=" + $("#hdnY1").val();
        _Crop = _Crop + "&Y2=" + $("#hdnY2").val();

        _postUrl = _postUrl + _Crop;

        if ($("#hdnX2").val() == 0 || $("#hdnY2").val() == 0) {
            alert("Please crop the photo");
            return;
        } else {

            $.postDATA(_postUrl, _postDATA, function (_result) {
                // alert(JSON.stringify(_result));
                if (_result.ResponseCode == 1) {
                    window.parent.location.reload();
                    window.parent.CloseIntelliWindow();
                }
            });

        }
        


       


    });



    $(".imgClose").click(function () {
        window.parent.CloseIntelliWindow();
    });



    $("#btnCancel").click(function () {
        window.parent.CloseIntelliWindow();
    });


});


 function getParameterByName(name) {
     name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
     var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
         results = regex.exec(location.search);
     return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
 }



  </script>

</form>
