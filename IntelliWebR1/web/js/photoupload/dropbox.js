

$(document).ready(function () {

    $("#btndropbox").click(function () {

        $("#divPhotoPreview").empty();
        $("#btnSubmit").addClass("Disabled");
        _loadingimg = " <img src='images/loading-bar-gif.gif' style='height:362px;' />";
        $("#divPhotoPreview").append(_loadingimg);

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

                         $("#btnSubmit").removeClass("Disabled");

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
