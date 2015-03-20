

$(document).ready(function () {

    $("#btndropbox").click(function () {

        Dropbox.choose({
            multiselect: true,
            extensions: ["images"],
            linkType: "direct",
            success: function (files) {
                for (var i = 0; i < files.length; i++) {
                   // var _imgUrl = files[i].link;
                    //post data
                   // alert(JSON.stringify(files[i]));
                    _FileObj = new Object();
                    _FileObj.PhotoUrl = files[i].link;
                    _FileObj.PhotoFileName = files[i].name;
                    _FileObj.IsDefaultPhoto = false;
                  
                    var _postUrl = _SitePath + "web/service/UrlUpload";

                    var _Crop = "?crop=y";
                    _Crop = _Crop + "&X1=50";
                    _Crop = _Crop + "&X2=50";
                    _Crop = _Crop + "&Y1=50";
                    _Crop = _Crop + "&Y2=50";

                    _postUrl = _postUrl + _Crop;
                    $.postDATA(_postUrl, _FileObj, function () {

                    });



                }             
            },
        });

    });

});
