<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MyProfilePhotos.aspx.cs" Inherits="IntelliWebR1.web.MyProfilePhotos" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="eight">
                <div class="tab_nav ninth_top_nav">
                    <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
                    <ul class="fr">
                        <li><a class="magnal">Upload</a></li>
                    </ul>
                    <span class="clear"></span>
                </div>
                <div class="eight_cont" id="divPhotos"></div>
            </div>
             <span class="clear"></span>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

            var _photosUrl = _SitePath + "web/inner/myprofilephotos";
            $("#divPhotos").load(_photosUrl,function () {
                $("#liPhotos").addClass("active");
            });

        });


    </script>


</asp:Content>
