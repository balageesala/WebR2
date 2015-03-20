

$(document).ready(function () {

   
    $("#btninstagram").click(function () {

        $("#divPhotoPreview").empty();

        OAuth.initialize('qb24rqcWu7g5eAUJ2IU6px8WkYE');
        OAuth.popup('instagram', function (error, success) {
           
            var userFeed = new Instafeed({
                get: 'user',
                userId: eval(success.user.id),
                accessToken: success.access_token,
                filter: function (_images) {
                    var _imageUrl = _images.images.standard_resolution.url;
                    var _imgIndex = eval(_imageUrl.split('/').length - 1);
                    var _imgName = _imageUrl.split('/')[_imgIndex];
                    var image = '<div class="imagescls"><img style="height: 100px;width: 100px;" src="' + _imageUrl + '" alt="' + _imgName + '" /></div>';
                        $(image).appendTo(".divinstaImages");
                }
            });
            userFeed.run();

            $(".instagramImages").dialog({ width: 500, height: 500 });
            
        });

    });

    $(".divinstaImages").on('click', 'div', function () {
        $(".imagescls").removeClass("selectimage");
        $(this).addClass("selectimage");

    });

    $("#btnInstaSelect").click(function () {
        
        var _SelectedImage =  $('.selectimage').find('img').attr("src");
        var _ImageName = $('.selectimage').find('img').attr("alt");
        alert(_ImageName);


        var loadingImage = loadImage(
                  _SelectedImage,
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

                              $("#hdnImageUrl").val(_SelectedImage);
                              $("#hdnImageName").val(_ImageName);
                          }
                      });
                  },
                  { canvas: false, crop: false }
              );

        $(".instagramImages").dialog("close");
        $(".divinstaImages").html("");
    });


});


function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}


