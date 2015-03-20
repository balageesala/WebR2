


function sendFile(fdata) {
    var sUrl = _SitePath + "web/service/MultiPhotoUpload";
    $.ajax({
        type: 'POST',
        paramName: 'files',
        url: sUrl,
        data: fdata,
        success: function (msg) {
            if (msg.ResponseCode == 1) {
                
            }
        },
        processData: false,
        contentType: false
    });
}





$(document).ready(function () {

    $("#btnBrowse").click(function (e) {
        //$("#flBrowse").trigger("click");
        //alert("here");
        SetIntelliWindow($(this),e);
        // Open the photo upload popup
    });

    var imgObjects;
    $("#flBrowse").change(function () {
       
        formdata = new FormData();
        if (formdata) {
            formdata.append("files", this.files);
        }
     

        sendFile(formdata);
    });
});




