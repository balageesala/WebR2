<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="theirpassport.aspx.cs" Inherits="IntelliWebR1.web.inner.theirpassport" %>

<div>
    <div class="student fl">
        <div class="photo">
            <img id="ImgProfilePicture" runat="server" width="68" height="67"/>
        </div>
        <div class="text">
            <ul>
                <li class="point">Overall</li>
                <li class="line_bar"><span class="over" id="OverallPercentWidth" runat="server">&nbsp;</span></li>
                <li class="percent" id="liOverallPercentText" runat="server" ></li>
            </ul>
            <span class="clear"></span>
            <ul>
                <li class="point">Criteria</li>
                <li class="line_bar"><span class="home" id="CriteriaPercentWidth"  runat="server" >&nbsp;</span></li>
                <li class="percent" id="liCriteriaPercentText" runat="server" ></li>
            </ul>
            <span class="clear"></span>
            <ul>
                <li class="point">Questions</li>
                <li class="line_bar"><span class="exam" id="QuestionsPercentWidth"  runat="server">&nbsp;</span></li>
                <li class="percent" id="liQuestionsPercentText" runat="server"></li>
            </ul>
            <span class="clear"></span>
        </div>
        <span class="clear"></span>
        <p id="divUserName" runat="server"></p>
    </div>

    <div class="thirteen_seen fl">
        <h5>Last seen in online: <span id="spnLastOnlineTime" class="time" runat="server"></span>.</h5>
        <h6>He is yet to see your profile</h6>
    </div>
    <span class="clear"></span>
</div>
