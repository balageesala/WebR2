<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="matchprofilemenu.ascx.cs" Inherits="IntelliWebR1.web.uc.matchprofilemenu" %>


<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
<div class="tab thirteen_top_nav" style="height:32px;">
    <div class="tab_nav thirteen_nav" style="margin: -2px !important;height:0px;">
        <ul>
            <li><a id="liMatchWritten">About me</a></li>
            <li><a id="liMatchPhotos">Photos</a></li>
        </ul>
    </div>

    <ul class="tab-legend2 fr">
     <li>
        <img src="images/15_doubt.png" id="imgReport" alt="doubt" title="Report this user" /></li>
    <li>
        <img src="images/15_eye.png" id="imgBlock" alt="eye" title="Block this user" /></li>
   </ul>

</div>


<script type="text/javascript">

    var ISUSERBLOCKED = false;

    $(document).ready(function () {

        var _writtenPath = _SitePath + "web/inner/profilewritten";
        var _photosPath = _SitePath + "web/inner/profilephotos";
        $("#divMatchWritten").load(_writtenPath, function () {
        });
        $("#divMatchPhotos").load(_photosPath, function () {
        });


        $("#divMatchWritten").show();
        $("#liMatchWritten").addClass("active");
        $("#divMatchPhotos").hide();

        var _APIISBLOCKED = _SitePath + "api/HasUserBlocked";
        var _BlockedObj = new Object();
        _BlockedObj.BlockedUserID = _OtherUserID;
        $.postDATA(_APIISBLOCKED, _BlockedObj, function (_BlakObject) {
            ISUSERBLOCKED = _BlakObject;
        });


        $("#liMatchWritten").click(function () {
            ClearActiveClass();
            $("#divMatchWritten").show();
            $("#divMatchPhotos").hide();
            $("#liMatchWritten").addClass("active");
        });

        $("#liMatchPhotos").click(function () {
            ClearActiveClass();
            $("#divMatchWritten").hide();
            $("#divMatchPhotos").show();
            $("#liMatchPhotos").addClass("active");
        });




        $("#imgBlock").click(function () {
            if (ISUSERBLOCKED) {
                IntelliConfirmWindow("Are you want to block this user?", 300, 0);
            } else {
                IntelliAlertWindow("You have already blocked this user.", 300, 0);
            }
        });


        $("#imgReport").click(function () {

            var _Reporturl = _SitePath + "web/inner/reportprofile?uid=" + _OtherUserID;
            SetUrlIntelliWindow(_Reporturl, "650", "350");

        });




    });


    function ClearActiveClass() {
        $("#liMatchPhotos").removeClass("active");
        $("#liMatchWritten").removeClass("active");
    }

    function YesClicked() {
        var _BlockAPI = _SitePath + "api/BlockUserProfile";
        var _BlockObj = new Object();
        _BlockObj.BlockedUserID = _OtherUserID;
        $.postDATA(_BlockAPI, _BlockObj, function (_retObject) {
            ISUSERBLOCKED = false;
            IntelliAlertWindow("This user blocked sucessfully.", 300, 0);
        });
    }

    function NoClicked() {
        return false;
    }
    


</script>