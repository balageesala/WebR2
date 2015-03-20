
//sky drive

   

    $(document).ready(function () {
       

        $(window).load(function () {
            WL.init({
                client_id: '000000004012AA00',
                redirect_uri: _SitePath + '/web/AddPictures',
                scope: ["wl.signin", "wl.skydrive", "wl.photos"],
                response_type: "token"
            });
        });

        $("#divskydrive").click(function () {

            WL.ui({ name: "signin", element: "divskydrive" });

        });    

    });


 


//dropbox
    $(document).ready(function () {


        options = {
            multiselect: true,
            extensions: ["images"],
            linkType: "direct",
            success: function (files) {
                $("#divPreviewBox").html("");
                for (var i = 0; i < files.length; i++) {
                    AddImageViewFromSocialSites(files[i].link, i + 1);
                }
            },
        };

        $("#divdropbox").click(function () {
            $("#hdnSetMethod").val("DI");
            Dropbox.choose(options);
        })


    });



//google 

    $(document).ready(function () {
        $("#divgoogle").click(function () {
            onApiLoad();
        });
    });
   

    //Facebook 
    $(document).ready(function () {
        window.fbAsyncInit = function () {
            FB.init({ appId: '1458773291075231', cookie: true, status: true, xfbml: true, oauth: true });

            FB.getLoginStatus(function (response) {
                if (response.authResponse) {
                    $("#login-status").html("Logged in");
                } else {
                    $("#login-status").html("Not logged in");
                }
            });
        };
        (function (d) {
            var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
            if (d.getElementById(id)) { return; }
            js = d.createElement('script'); js.id = id; js.async = true;
            js.src = "//connect.facebook.net/en_US/all.js";
            ref.parentNode.insertBefore(js, ref);
        }(document));
    });


//Instagram

    $(document).ready(function () {

        $(".instaUserName").hide();
        $(".divinstaImages").html("");
        $("#divinstagram").click(function (s) {
            $(".instaUserName").dialog();
        });

        $(".btninstaUserName").click(function (s) {

            var _instaUserName = $(".txtinstaUserName").val();

            var URL = "http://whateverorigin.org/get?url=" + encodeURIComponent("http://instagram.com/" + _instaUserName + "/media");
            jQuery(function ($) {
                $.ajax({
                    url: URL,
                    dataType: "jsonp", // this is important
                    cache: false,
                    success: function (response) {
                        //  alert(JSON.stringify(response));
                        var data = response.contents;
                        for (var i = 0; i < data.items.length; i++) {
                            var image = '<div class="imagescls"><img style="height: 100px;width: 100px;" src="' + data.items[i].images.low_resolution.url + '" alt="" /></div>';
                            $(image).appendTo(".divinstaImages");
                        }
                        $(".instaUserName").dialog("close");
                        $(".instagramImages").dialog();
                    },
                    error: function () {
                        lert("error");
                        var error = "<p>error processing ajax request</p>";
                        $(".instagramImages").css('display', 'inline');
                        $(error).appendTo(".instagramImages");
                    }
                });
            });
        });
           


        $(".divinstaImages").on('click', 'div', function () {
          //  $(".selectimage").removeClass("selectimage");
            $(this).toggleClass("selectimage");

        });

       

        $("#btnInstaSelect").click(function () {
            //get selected images
            $("#hdnSetMethod").val("DI");
            var imgUrls = new Array();
            $('.selectimage').find('img').each(function (img) {
                imgUrls.push($(this).attr("src"));
            })
            $(".instagramImages").hide();
            $(".divinstaImages").html("");
            $("#divPhotoPreview").empty();
            $(".hdnimgurl").val("");
            $(".hdnimgurl").val(imgUrls[0]);

            $("#divPreviewBox").html("");

            //alert(JSON.stringify(imgUrls));
            for (var i = 0; i < imgUrls.length; i++) {
                AddImageViewFromSocialSites(imgUrls[i], i + 1);
            }

            $(".instagramImages").dialog("close");
        });
    });



    function AddImageViewFromSocialSites(objImageUrl, elementID) {

        var _previewBox = $("<div class=\"previewBox\"></div>");
        var _previewImageBox = $("<div class=\"previewImageBox\"></div>");
        var _previewProgressBarBox = $("<div class=\"previewProgressBox\"></div>");
        var _deleteImageElement = $("<img src=\"#\"></img>");
        var _imageElement = $("<img src=\"#\"></img>");

        $(_previewBox).attr("id", elementID);

     

        $(_deleteImageElement).attr('src', _SitePath + "/web/images/delete.gif");
        $(_deleteImageElement).attr("id", "delimg_" + elementID);
        $(_deleteImageElement).attr("class", "delbtnclass");
        // _deleteImageElement.onclick = "alert('blah')";

        $(_deleteImageElement).attr("onclick", "return removeImage(" + elementID + ")");
        //$(_imageElement).addClass("greyscale");
        $(_imageElement).attr("id", "img_" + elementID);
        $(_imageElement).attr("src", objImageUrl);

        $(_previewImageBox).append(_imageElement);
        $(_previewBox).append(_previewImageBox);
        $(_previewProgressBarBox).append(_deleteImageElement);
        $(_previewBox).append(_previewProgressBarBox);

        $("#divPreviewBox").append(_previewBox);
    }



       