/*globals $, jQuery, CSPhotoSelector */


//Facebook 
$(document).ready(function () {
    window.fbAsyncInit = function () {
        FB.init({ appId: '364688787022470', cookie: true, status: true, xfbml: true, oauth: true });
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
		    $("#hdnSetMethod").val("");
		    $("#hdnSetMethod").val("DI");
		    var _photos = GetSelectedPhotos();
		    for (var i = 0; i < _photos.length; i++) {
		        //_Array.push(_photos[i].source)
		        AddImageViewFromSocialSites(_photos[i].source, i);
		    }
		    return false;


			//var photo;
			//photo = CSPhotoSelector.getPhotoById(photoId);
			//logActivity('<br><strong>Submitted</strong><br> Photo ID: ' + photo.id + '<br>Photo URL: ' + photo.source + '<br>');
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
			maxSelection			: 10,
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
	            
	        } else {
	            $("#login-status").html("Not logged in");
	        }
	    }, { scope: 'user_photos, friends_photos' });
		
	});

	logActivity = function (message) {
	   
	};
});