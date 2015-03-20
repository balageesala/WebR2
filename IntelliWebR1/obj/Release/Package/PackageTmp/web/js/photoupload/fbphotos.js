/*globals $, jQuery, CSPhotoSelector */


//Facebook 
$(document).ready(function () {
    window.fbAsyncInit = function () {
        FB.init({ appId: '307474069445356', cookie: true, status: true, xfbml: true, oauth: true });
    };
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    }(document));
});



$(document).ready(function () {
	var selector, logActivity, callbackAlbumSelected, callbackPhotoUnselected, callbackSubmit;
	var buttonOK = $('#CSPhotoSelector_buttonOK');
	var o = this;
	
	
	/* --------------------------------------------------------------------
	 * Photo selector functions
	 * ----------------------------------------------------------------- */
	
	fbphotoSelect = function(id) {
		// if no user/friend id is sent, default to current user
		if (!id) id = 'me';
		
		callbackAlbumSelected = function(albumId) {
			var album, name;
			album = CSPhotoSelector.getAlbumById(albumId);
			// show album photos
			selector.showPhotoSelector(null, album.id);
		};

		callbackAlbumUnselected = function(albumId) {
			var album, name;
			album = CSPhotoSelector.getAlbumById(albumId);
		};

		callbackPhotoSelected = function(photoId) {
			var photo;
			photo = CSPhotoSelector.getPhotoById(photoId);
			buttonOK.show();
			logActivity('Selected ID: ' + photo.id);
		};

		callbackPhotoUnselected = function(photoId) {
			var photo;
			album = CSPhotoSelector.getPhotoById(photoId);
			buttonOK.hide();
		};

		callbackSubmit = function (photoId) {
		 
		    var _photos = GetSelectedPhotos();
		    var _PhotoUrl = _photos[0].source;
		    var _PhtotoPath = _PhotoUrl.split('?')[0];
		    var _PhtotoIndex = eval(_PhtotoPath.split('/').length-1);
		    var _PhtotoName = _PhtotoPath.split('/')[_PhtotoIndex];
		   

		    var loadingImage = loadImage(
                    _PhotoUrl,
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

                                $("#hdnImageUrl").val(_PhotoUrl);
                                $("#hdnImageName").val(_PhtotoName);
                            }
                        });
                    },
                    { canvas: false, crop: false }
                );





		};


		// Initialise the Photo Selector with options that will apply to all instances
		CSPhotoSelector.init({debug: true});

		// Create Photo Selector instances
		selector = CSPhotoSelector.newInstance({
			callbackAlbumSelected	: callbackAlbumSelected,
			callbackAlbumUnselected	: callbackAlbumUnselected,
			callbackPhotoSelected	: callbackPhotoSelected,
			callbackPhotoUnselected	: callbackPhotoUnselected,
			callbackSubmit			: callbackSubmit,
			maxSelection			: 1,
			albumsPerPage			: 200,
			photosPerPage			: 500,
			autoDeselection			: true,

		});

		// reset and show album selector
		selector.reset();
		selector.showAlbumSelector(id);
	}
	

	
	
	/* --------------------------------------------------------------------
	 * Click events
	 * ----------------------------------------------------------------- */
	
	$("#btnfacebook").click(function (e) {
	    e.preventDefault();
	    FB.login(function (response) {
	        if (response.authResponse) {
	            id = null;
	            if ($(this).attr('data-id')) id = $(this).attr('data-id');
	           fbphotoSelect(id);
	           // alert()
	        } else {
	            $("#login-status").html("Not logged in");
	        }
	    }, { scope: 'user_photos, friends_photos' });
		
	});

	logActivity = function (message) {
	   
	};
});