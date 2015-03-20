<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilematchp.aspx.cs" Inherits="IntelliWebR1.web.inner.profilematchp" %>



<div class="person_details" style="margin:18px auto;width:592px;">
    <div style="float:left;width: 100px;padding-right:10px;margin-top: 10px;">
        <img id="OtherUserPic" runat="server" style="float:left;width: 91px; height: 91px;" />
        <small style="float:left;width: 91px;text-align:center;font-size: 16px;font-weight: 400;color:#000;margin-top:4px;" id="DivOtherUserNane" runat="server"></small>
    </div>
    <div class="profile_info_rt" id="divCriteria" runat="server" visible="false">
        <div class="work">
            <div class="teacher_wrkflow" id="DivCriteriaTheyMatchYou" runat="server">
                <div class="circliful" style="width: 110px;">
                    <img id="imgCriteriaTheyMatchYou" runat="server" style="width: 99px; height: 99px;border:0px;" />
                </div>
                <h4>They match you</h4>
            </div>
            <div class="teacher_wrkflow" id="DivCriteriaOverall" runat="server">
                <div class="circliful" style="width: 110px;">
                    <img id="imgCriteriaTotal" runat="server" style="width: 99px; height: 99px;border:0px;" />
                </div>
                <h4>Criteria match</h4>
            </div>
            <div class="teacher_wrkflow" id="DivCriteriaYouMatchThem" runat="server">
                <div class="circliful" style="width: 110px;">
                    <img id="imgCriteriaYouMatchThem" runat="server" style="width: 99px; height: 99px;border:0px;" />
                </div>
                <h4>You match them</h4>
            </div>
        </div>
    </div>

    <div class="profile_info_rt" id="divQuestions" runat="server" visible="false">
        <div class="work">
            <div class="teacher_wrkflow" id="DivPhilosophyTheyMatchYou" runat="server">
                <div class="circliful" style="width: 110px;">
                    <img id="imgPhilosophyTheyMatchYou" runat="server" style="width: 99px; height: 99px;border:0px;" />
                </div>
                <h4>They match you</h4>
            </div>
            <div class="teacher_wrkflow" id="Div3" runat="server">
                <div class="circliful" style="width: 110px;">
                    <img id="imgPhilosophyTotal" runat="server" style="width: 99px; height: 99px;border:0px;" />
                </div>
                <h4>Questions match</h4>
            </div>
            <div class="teacher_wrkflow" id="DivPhilosophyYouMatchThem" runat="server">
                <div class="circliful" style="width: 110px;">
                    <img id="imgPhilosophyYouMatchThem" runat="server" style="width: 99px; height: 99px;border:0px;" />
                </div>
                <h4>You match them</h4>
            </div>
        </div>
    </div>
    <div class="teacher" style="margin:0px;margin-left:10px;margin-top: 10px;">
        <img id="UserPic" runat="server" width="92" height="92" alt="teacher" style="cursor:pointer;" class="goMyProfile" />
        <small id="DivThisUserName" runat="server"></small>
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




















