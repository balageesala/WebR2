<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photopopup.aspx.cs" Inherits="IntelliWebR1.web.inner.photopopup" %>

<!DOCTYPE html>
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<div class="profilepic">
    <a class="close">x</a>
    <span class="clear"></span>
    <div class="profilepic_cont">
        <h3>Upload Profile pic through:</h3>
        <ul>
            <li>
                <div class="profilepic_harddisk" id="divBrowse"></div>
                My Computer
            </li>
            <li>
                <div class="profilepic_dropbox" id="divDropBox"></div>
                Dropbox
            </li>
            <li>
                <div class="profilepic_instagram" id="divInstagram"></div>
                Instagram
            </li>
        </ul>
        <p>Error Message</p>
        <span class="clear"></span>
    </div>
    <span class="clear"></span>

    <script type="text/javascript">

        $(document).ready(function () {
            $(".close").click(function () {
                window.parent.CloseIntelliWindow();
            });

            //browse button
            $("#divBrowse").click(function () {

                var Pagename = window.parent.location.pathname;
                if (Pagename.indexOf("MyProfilePhotos") != -1) {
                    var popupUrl = _SitePath + "web/inner/multiplephotoupload";
                    window.parent.SetUrlIntelliWindow(popupUrl, "710", "410");
                } else {
                    var _flBrowse = window.parent.document.getElementById("flBrowse");
                    $(_flBrowse).trigger("click");
                }

            });

            $("#divDropBox").click(function () {
                var _ButtonDropBox = window.parent.document.getElementById("btnDropBox");
                $(_ButtonDropBox).trigger("click");
            });

            $("#divInstagram").click(function () {
                var _ButtonInstagram = window.parent.document.getElementById("btnInstagram");
                $(_ButtonInstagram).trigger("click");
            });



        })



      

       

    </script>

</div>
