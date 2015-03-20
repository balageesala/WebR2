<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="passport.ascx.cs" Inherits="IntelliWebR1.web.uc.passport" %>
<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
<div class="passport">
    <div class="thirteen_sutdent_chart">
        <div class="student">
            <div class="photo">
                <img id="imgOtherProfilePic" runat="server" width="68" height="67" alt="student" />
            </div>
            <div class="text">
                <ul>
                    <li class="point">Overall</li>
                    <li class="line_bar"><span class="over" id="lblOverall" runat="server">&nbsp;</span></li>
                    <li class="percent" id="lblOverallp" runat="server"></li>
                </ul>
                <span class="clear"></span>
                <ul>
                    <li class="point">Criteria</li>
                    <li class="line_bar"><span class="home" id="lblCriteria" runat="server">&nbsp;</span></li>
                    <li class="percent" id="lblCriteriap" runat="server"></li>
                </ul>
                <span class="clear"></span>
                <ul>
                    <li class="point">Questions</li>
                    <li class="line_bar"><span class="exam" id="lblQuestions" runat="server">&nbsp;</span></li>
                    <li class="percent" id="lblQuestionsp" runat="server"></li>
                </ul>
                <span class="clear"></span>
            </div>
            <span class="clear"></span>
            <p id="divUserName" runat="server"></p>
        </div>
    </div>
</div>
