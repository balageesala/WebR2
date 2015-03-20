<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yesterdaymatch.aspx.cs" Inherits="IntellidateR1Web.web.inner.yesterdaymatch" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div style="width: 100%;">
 <div style="margin: 10px; text-align: center; font-size: 28px; color: #777175;">Today's Match</div>
    <div id="divTodayMatchNotFound" runat="server" visible="false" style="min-height: 250px; margin-top: 160px; font-size: 22px; text-align: center;">We are sorry. We could not find you a daily match for the moment.</div>
    <div id="divNewUserBefore12" runat="server" visible="false" style="min-height: 250px; margin-top: 160px; font-size: 22px; text-align: center;">Your new match will be comming at today 12pm noon. </div>
    <div id="divNewUserAfter12" runat="server" visible="false" style="min-height: 250px; margin-top: 160px; font-size: 22px; text-align: center;">Your new match will be comming at tomorrow 12pm noon. </div>
    <div id="divTodayMatch" runat="server">
        <div style="float: left; width: 50%;">

            <script type="text/javascript">
                function LoadImage() {
                    var loadingImage = loadImage(
                        _MatchUserPhoto,
                        function (img) {
                            $("#divTodaysMatchImage").append(img);
                        },
                    { canvas: false, crop: true, maxHeight: 360, maxWidth: 360 });
                }
                $(document).ready(function () {
                    LoadImage();
                });
            </script>

            <div style="position: absolute; margin-left: 10px; margin-top: 10px;">
                <img id="imgOtherUser_Online" class="imgOtherUser_Online" runat="server" />
            </div>


            <div style="width: 360px; height: 360px; cursor: pointer;" id="divTodaysMatchImage" runat="server" class="pointUserPhotos">
            </div>

            <div style="width: 360px; min-height: 60px;">
                <div style="font-size: 24px; text-align: center; cursor: pointer;" class="pointUserInfo" id="lblTodaysMatchName" runat="server"></div>
                <div style="font-size: 18px; text-align: center;" id="lblTodaysMatchInfo" runat="server"></div>
            </div>
        </div>
        <div style="float: left; width: 48%; border: 0px solid; height: 400px;">
            <div style="text-align: center;">
                <img id="imgOverallMatch" runat="server" style="cursor: pointer;" class="pointUserInfo"  tabindex="0"/>
            </div>
            <div style="width: 250px; height: 140px; margin: 0 auto;">
                <div style="float: left;">
                    <div>
                        <img id="imgCriteriaMatch" runat="server" class="pointUserCriteria" style="width: 120px; height: 120px; cursor: pointer;" tabindex="0" />
                    </div>
                    <div style="text-align: center; font-size: 14px;">Criteria</div>
                </div>
                <div style="float: left;">
                    <div>
                        <img id="imgPhilosophyMatch" runat="server" class="pointUserPhilosophy" style="width: 120px; height: 120px; cursor: pointer;" tabindex="0"  />
                    </div>
                    <div style="text-align: center; font-size: 14px;">Questions</div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {

            var _OtherUserID = $("#lblTodaysMatchName").data("loginid");

            var _TabNames = new Array();

            var API_OTHERUSER_PROFILE = _SitePath + "api/GetTabNames";
            var _Object = new Object();
            _Object.OtherUserID = _OtherUserID;
            $.postDATA(API_OTHERUSER_PROFILE, _Object, function (_ret) {
                _TabNames = _ret;

            });

            //Reset match percentages
            var API_ResetMatchp = _SitePath + "api/ResetMatchPercentages";
            var _MatchpObject = new Object();
            _MatchpObject.OtherUserID = _OtherUserID;
            $.postDATA(API_ResetMatchp, _MatchpObject, function (_ret) {
            });


            $(".pointUserInfo").click(function () {
                var _loginName = $(this).data("loginname");
                //var _Url = _SitePath + "web/Profile?" + _loginName;
                //for (var i = 0; i < _TabNames.length; i++) {
                //    if (_TabNames[i] == "aboutme") {
                //        _Url = _SitePath + "web/Profile?" + _loginName + "#aboutme";
                //    }
                //}
                window.location.href = _SitePath + "web/Profile?" + _loginName + "#criteria";
            });

            $(".pointUserCriteria").click(function () {
                var _loginName = $(this).data("loginname");
                var _CMatchp = $(this).data("matchp");

                if (_CMatchp != "-1") {
                    window.location.href = _SitePath + "web/Profile?" + _loginName + "#criteria";
                }
            });

            $(".pointUserPhilosophy").click(function () {
                var _loginName = $(this).data("loginname");
                var _QMatchp = $(this).data("matchp");
                if (_QMatchp != "-1") {
                    window.location.href = _SitePath + "web/Profile?" + _loginName + "#questions";
                } else {
                    window.location.href = _SitePath + "web/Profile?" + _loginName + "#criteria";
                }
            });

            $(".pointUserPhotos").click(function () {
                var _loginName = $(this).data("loginname");
                window.location.href = _SitePath + "web/Profile?" + _loginName + "#criteria";
            });

            $(".previousMatch").click(function () {
                var _loginName = $(this).attr('alt');
                window.location.href = _SitePath + "web/Profile?" + _loginName + "#criteria";
            });


        });

    </script>


</div> 