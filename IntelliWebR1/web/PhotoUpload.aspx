<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intelli.Master" AutoEventWireup="true" CodeBehind="PhotoUpload.aspx.cs" Inherits="IntelliWebR1.web.PhotoUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="https://www.dropbox.com/static/api/2/dropins.js" id="dropboxjs" data-app-key="jo5l4qk5e82jdna"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="fifth">

                <div class="one_top">
                    <!--<a class="back" id="btnBack" style="cursor:pointer;"><img src="images/back_btn.png" alt="back"/></a> -->
                    <div class="one_numbering">
                        <b id="Numberleft" runat="server"></b><span>of</span> <b id="NumberRight" runat="server"></b>
                        <span class="clear"></span>
                    </div>
                    <img src="images/01_line-shadow.jpg" alt="line" />
                    <p>
                        Vivamus ultricies fermentum mattis. Cras vitae ex nibh. Aliquam facilisis, Cras vitae ex nibh. 
Aliquam facilisis, Cras vitae ex nibh. Aliquam facilisis,
                    </p>
                </div>
                <span class="clear"></span>
                <div class="fifth_matter" style="margin-top:10px;">
                    <img src="images/05_content_pic.png" id="dummyImg" alt="pic" style="opacity:0.1;width:255px; height:300px;" />
                    <div id="divPhotoPreview" style="margin:0 auto;"></div>
                    <span class="clear"></span>
                    <div class="fifth_buttons" style="margin-top:10px;">
                        <input type="file" id="flBrowse" style="display: none;" accept="image/x-png, image/gif, image/jpeg" />
                        <a class="skip" id="btnSkip">Skip</a>
                        <a class="upload" id="btnUpload">Upload</a>
                        <input type="button" id="btnSubmit" value="Submit" class="upload" style="border:0px;" />
                        <input type="button" id="btnDropBox" style="display:none;"/>
                        <input type="button" id="btnInstagram" style="display:none;"/>

                    </div>
                    <span class="clear"></span>
                </div>

            </div>

            <input type="hidden" id="hdnX1" />
            <input type="hidden" id="hdnX2" />
            <input type="hidden" id="hdnY1" />
            <input type="hidden" id="hdnY2" />
            <input type="hidden" id="hdnImageUrl" />
            <input type="hidden" id="hdnImageName" />

            <span class="clear"></span>
        </div>

        <script type="text/javascript">

            $(document).ready(function () {
                $("#btnSubmit").hide();
                $("#btnBack").click(function () {
                    window.history.back();
                });

                $("#btnSkip").click(function () {
                    window.location.href = _SitePath + "web/Home";
                });

                $("#btnSubmit").click(function () {
                    $("#btnSubmit").attr("disabled", "disabled");
                    $("#btnSubmit").val("Please wait..");
                    if ($("#hdnImageUrl").val() != "") {
                        var _postDATA = new Object();
                        _postDATA.PhotoUrl = $("#hdnImageUrl").val();
                        _postDATA.PhotoFileName = $("#hdnImageName").val();

                        var _postUrl = _SitePath + "web/service/UrlUpload";

                        var _Crop = "?crop=y";
                        _Crop = _Crop + "&X1=" + $("#hdnX1").val();
                        _Crop = _Crop + "&X2=" + $("#hdnX2").val();
                        _Crop = _Crop + "&Y1=" + $("#hdnY1").val();
                        _Crop = _Crop + "&Y2=" + $("#hdnY2").val();

                        _postUrl = _postUrl + _Crop;
                        $.postDATA(_postUrl, _postDATA, function () {
                            window.location.href = _SitePath + "web/Home";
                        });
                    }
                    else {
                        
                        formdata = new FormData();
                        if (formdata) {
                            formdata.append("files[]", imgObject);
                           // alert(JSON.stringify(imgObject));
                        }
                        sendFile(formdata);
                    }
                });


                $("#btnUpload").click(function () {

                    var popupUrl = _SitePath + "web/inner/photopopup";
                    SetUrlIntelliWindow(popupUrl, "620", "410");

                });



                var imgObject;
                $("#flBrowse").change(function () {
                    imgObject = this.files[0];

                    $("#divPhotoPreview").empty();
                    $("#hdnImageUrl").val("");
                    var loadingImage = loadImage(
                        imgObject,
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
                            $("#divPhotoPreview").append(img);

                            $("#dummyImg").hide();
                            CloseIntelliWindow();
                            $("#btnSubmit").show();
                            $("#btnUpload").hide();

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
                });

                $("#btnDropBox").click(function () {

                    $("#divPhotoPreview").empty();
                  
                    Dropbox.choose({
                        multiselect: false,
                        extensions: ["images"],
                        linkType: "direct",
                        success: function (files) {
                            var _imgUrl = files[0].link;
                            var _FileName = files[0].name;
                            var loadingImage = loadImage(
                                 _imgUrl,
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

                                     $("#dummyImg").hide();
                                     CloseIntelliWindow();
                                     $("#btnSubmit").show();
                                     $("#btnUpload").hide();

                                     $(img).imgAreaSelect({
                                         enable: true,
                                         handles: true,
                                         aspectRatio: "1:1",
                                         x1: 0,
                                         y1: 0,
                                         x2: eval(_ImageWidth / 2),
                                         y2: eval(_ImageWidth / 2),
                                         imageHeight: _ImageHeight,
                                         imageWidth: _ImageWidth,
                                         onSelectEnd: function (_img, selection) {
                                             $("#hdnX1").val(selection.x1);
                                             $("#hdnY1").val(selection.y1);
                                             $("#hdnX2").val(selection.width);
                                             $("#hdnY2").val(selection.height);
                                             $("#hdnImageUrl").val(_imgUrl);
                                             $("#hdnImageName").val(_FileName);
                                         }
                                     });
                                 },
                                 { canvas: false, crop: false }
                             );
                        },
                    });

                });

            });

            function sendFile(fdata) {
                var sUrl = _SitePath + "web/service/PhotoUpload";

                // Build the crop query string
                var _Crop = "?crop=y";
                _Crop = _Crop + "&X1=" + $("#hdnX1").val();
                _Crop = _Crop + "&X2=" + $("#hdnX2").val();
                _Crop = _Crop + "&Y1=" + $("#hdnY1").val();
                _Crop = _Crop + "&Y2=" + $("#hdnY2").val();

                sUrl = sUrl + _Crop;

                alert(sUrl);

                $.ajax({
                    type: 'POST',
                    paramName: 'files',
                    url: sUrl,
                    data: fdata,

                    success: function (msg) {
                        if (msg.ResponseCode == 1) {
                            window.location.href = _SitePath + "web/Home";
                        }
                    },
                    processData: false,
                    contentType: false
                });
            }

        </script>


    </div>

</asp:Content>
