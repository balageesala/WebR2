<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="multiplephotoupload.aspx.cs" Inherits="IntelliWebR1.web.inner.multiplephotoupload" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/knockout/knockout-3.0.0.js" type="text/javascript"></script>
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <style>
        body {
            margin: 0px;
            font-family: Verdana;
            font-size: 14px;
        }

        .imgObject {
            float: left;
            width: 100px;
            height: 120px;
            margin: 4px;
        }

        .uploadStatus {
            font-size: 12px;
            text-align: center;
            color: gray;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <div style="width: 700px; height: 500px; background-color: #E3E3E3;">
             <div style="float:left;margin-left:34px;margin-top:6px;"> Avilable photos : <div id="divAvilable" style="float:right;" runat="server"></div> </div>
            <div style="height: 30px; text-align: right;">
                <div style="margin: 2px; cursor: pointer;" id="btnClose">
                    <img src="../images/close.png" />
                </div>
            </div>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#btnClose").click(function () {
                        window.parent.location.reload();
                        window.parent.CloseIntelliWindow();
                    });
                });
            </script>
            <div style="margin: 30px; margin-top: 0px; width: 640px; min-height: 430px; background-color: #fff; border: 1px solid #C0C0C0; border-radius: 4px 4px; max-height: 430px; overflow-y: auto;">
                <div style="margin: 6px;" id="imgPreviews">

                    <div style="float: left; width: 100px; height: 120px; margin: 4px;">
                        <img src="../images/browse.jpg" id="imgBrowse" style="cursor: pointer;" />
                    </div>
                </div>
            </div>
             <div style="float:left;margin-left:34px;margin-top:-20px;color:red;" id="divErrorMsg"></div>
      
         </div>
        <script type="text/javascript">
            var _counter = 0;
            $(document).ready(function () {
                $("#objFile").change(function (e) {
                    if (this.files.length == 0) {
                        return;
                    }

                    var _avilablePhotos = $("#divAvilable").html();

                    if (this.files.length > parseInt(_avilablePhotos)) {
                        $("#divErrorMsg").html("You can't select more then " + _avilablePhotos + " photos.");
                        return;
                    }
                    var _uploadImageObject = new Object();
                    var _listOfUploadObjects = new Array();

                    for (var i = 0; i < this.files.length; i++) {

                        _uploadImageObject = new Object();
                        _uploadImageObject.File = this.files[i];
                        _uploadImageObject.divID = "preview_" + _counter;
                        _listOfUploadObjects.push(_uploadImageObject);
                    }

                    AppendFile(_listOfUploadObjects, 0);

                });
            });
        </script>
        <input type="file" name="files[]" id="objFile" multiple="multiple" accept="image/x-png, image/gif, image/jpeg" style="display: none;" />
        <script type="text/javascript">
            $(document).ready(function () {
                $("#imgBrowse").click(function () {
                    $("#objFile").trigger("click");
                });
            });
        </script>
        <script type="text/javascript">
            function AppendFile(_array, _position) {
                if (_position == 1) {
                    AsynchUpload(_array, 0);
                }

                if (_position >= _array.length) {
                    return;
                }
                var loadingImage = loadImage(
                            _array[_position].File,
                            function (img) {
                                var _divTemplate = $("<div class=\"imgObject\" id=\"" + _array[_position].divID + "\"></div>");
                                $("#imgPreviews").append(_divTemplate);
                                $(_divTemplate).append(img);
                                var _uploading = $("<div class=\"uploadStatus\">pending</div>");
                                $(_divTemplate).append(_uploading);
                                AppendFile(_array, eval(_position + 1));
                            },
                            { canvas: false, crop: true, maxWidth: 100, maxHeight: 100 }
                        );
            }

            function AsynchUpload(_array, _position) {
                var sUrl = _SitePath + "web/service/PhotoUpload";

                if (_position >= _array.length) {
                    return;
                }

                var formdata = new FormData();
                if (formdata) {
                    formdata.append("files[]", _array[_position].File);
                }

                $("#" + _array[_position].divID + " div").html("uploading...");

                sUrl = sUrl;
                $.ajax({
                    type: 'POST',
                    paramName: 'files',
                    url: sUrl,
                    data: formdata,
                    beforeSend: function () {

                    },
                    success: function (msg) {
                        if (msg.ResponseCode == 1) {
                            $("#" + _array[_position].divID + " div").html("done");
                            AsynchUpload(_array, eval(_position + 1));
                        } else {
                            $("#" + _array[_position].divID + " div").html(msg.ErrorMessage);
                            AsynchUpload(_array, eval(_position + 1));
                        }
                       
                    },
                    processData: false,
                    contentType: false
                });
            }

        </script>
    </form>
</body>
</html>
