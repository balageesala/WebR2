
//sky drive

   

    $(document).ready(function () {
           
      


        $("#btnonedrive").click(function () {

            WL.init({
                client_id: '000000004012AA00',
                redirect_uri: _SitePath + '/web/MyProfile',
                scope: ["wl.signin", "wl.skydrive", "wl.photos"],
                response_type: "token"
            });

                WL.fileDialog({ mode: "open", select: "multi" }).then(function (n) {

                });

        });    

    });


 



       