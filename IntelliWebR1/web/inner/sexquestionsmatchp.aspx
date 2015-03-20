<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sexquestionsmatchp.aspx.cs" Inherits="IntelliWebR1.web.inner.sexquestionsmatchp" %>

<div class="person_details" style="margin:18px auto;">
    <div style="float:left;width: 100px;padding-right:10px;margin-top: 10px;">
        <img id="OtherSexUserPic" runat="server" width="91" height="91">
        <small id="lblOtherUserName" runat="server" style="float:left;width: 91px;text-align:center;font-size: 16px;font-weight: 400;color:#000;margin-top:4px;" ></small>
    </div>
    <div class="profile_info_rt" id="divSexQuestions" runat="server" visible="false">
        <div class="work">
            <div class="teacher_wrkflow" id="DivPhilosophyTheyMatchYou" runat="server">
                <img id="imgSexPhilosophyTheyMatchYou" runat="server" style="border:0px;width:99px;"  />
                <h4>They match you</h4>
            </div>
            <div class="teacher_wrkflow">
                &nbsp;
            </div>
            <div class="teacher_wrkflow" id="DivPhilosophyOverall" runat="server">
                <img id="imgSexPhilosophyTotal" runat="server" style="border:0px;width:99px;" />
                <h4>Questions match</h4>
            </div>
            <div class="teacher_wrkflow">
                <h4>&nbsp;</h4>
            </div>
        </div>
    </div>
    <div class="teacher">
        <img id="UserSexPic" runat="server" width="92" height="92" style="cursor:pointer;" class="goMyProfile" />
        <small id="lblThisUserName" runat="server"></small>
    </div>
    <span class="clear"></span>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".goMyProfile").click(function () {
                window.location.href = _SitePath + "web/MyProfileAboutme";
            });
        });
    </script>
</div>




















