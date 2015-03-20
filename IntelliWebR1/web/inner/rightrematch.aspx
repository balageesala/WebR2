<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rightrematch.aspx.cs" Inherits="IntelliWebR1.web.inner.rightrematch" %>
<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
<div class="divpassport" style="border:0px;">
     <div class="divuname" id="divUserName" runat="server" style="float:right;margin-right:0px;"></div>
<div style="float:left;width: 230px;">
    <div class="divrow">
        <div class="divrowlabel">Overall</div>
        <div class="divgraph">
            <div class="divOverallp" id="lblOverall" runat="server"></div>
        </div>
        <div class="divoveralllblp" id="lblOverallp" runat="server"></div>
    </div>
    <div class="divrow">
        <div class="divrowlabel">Criteria</div>
        <div class="divgraph">
            <div class="divCriteriap" id="lblCriteria" runat="server"></div>
        </div>
        <div class="criterialbl" id="lblCriteriap" runat="server"></div>
    </div>
    <div class="divrow">
        <div class="divrowlabel">Questions</div>
        <div class="divgraph">
            <div class="divQuestionsp" id="lblQuestions" runat="server"></div>
        </div>
        <div class="divquestionlbl" id="lblQuestionsp" runat="server"></div>
    </div>
</div>
    <div style="float:left;">
    <div class="divimg" style="float:right;">
        <img id="imgOtherProfilePic" runat="server" class="divimg OtherProfilePic" />
    </div> 
        </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".OtherProfilePic").click(function () {
                var _OtherUserName = $(this).attr("alt");
                window.location.href = window.location.href = _SitePath + "web/Profile?" + _OtherUserName + "#criteria";
            });

        });
    </script>
</div>