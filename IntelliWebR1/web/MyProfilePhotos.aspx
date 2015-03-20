<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MyProfilePhotos.aspx.cs" Inherits="IntelliWebR1.web.MyProfilePhotos" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <form enctype="multipart/form-data" method="post" id="frmPhotoUpload">
    <div class="center_content">
        <div class="middle_content">
            <div class="eight">
                <div class="tab_nav ninth_top_nav">
                    <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
                    <ul class="fr">
                        <li><a class="magnal" id="btnPhotoUpload">Upload</a></li>
                    </ul>
                    <span class="clear"></span>
                </div>
                <div class="eight_cont" id="divPhotos"></div>
                 <input type="file" id="flBrowse" multiple="multiple" style="display: none;" accept="image/x-png, image/gif, image/jpeg" />
                 <input type="button" id="btnDropBox" style="display:none;"/>
                 <input type="button" id="btnInstagram" style="display:none;"/>
            </div>
             <span class="clear"></span>
        </div>
    </div>
  </form>
    <script type="text/javascript">

        $(document).ready(function () {

            var _photosUrl = _SitePath + "web/inner/myprofilephotos";
            $("#divPhotos").load(_photosUrl,function () {
                $("#liPhotos").addClass("active");
            });


            $("#btnPhotoUpload").click(function () {
                var popupUrl = _SitePath + "web/inner/photopopup";
                SetUrlIntelliWindow(popupUrl, "620", "410");
            });


            $("#flBrowse").change(function () {
                var formdata = new FormData();
                if (formdata) {
                    //formdata.append("files", this.files[0]);
                     formData = new FormData($('#frmPhotoUpload')[0]);

                    alert(JSON.stringify(formdata));
                }
                sendFile(formdata);
                CloseIntelliWindow();
            });

           

        });


        function sendFile(fdata) {
            var sUrl = _SitePath + "web/service/MultiPhotoUpload";
            $.ajax({
                type: 'POST',
                paramName: 'files',
                url: sUrl,
                data: fdata,
                success: function (msg) {
                    alert(JSON.stringify(msg));
                    if (msg.ResponseCode == 1) {

                    }
                },
                processData: false,
                contentType: false
            });
        }


    </script>


</asp:Content>
