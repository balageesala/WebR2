<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionssinglematch.aspx.cs" Inherits="IntelliWebR1.web.inner.questionssinglematch" %>

<div>
<style type="text/css">
    .redColor {
        color: red;
    }
</style>

<script src="//code.jquery.com/jquery-1.10.2.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<div style="float: left; min-height: 200px; border: 0px solid #ccc; border-radius: 4px 4px; margin: 4px; padding-left: 10px;">
    <div style="margin: 4px; font-family: Arial; font-size: 16px; font-weight: bold;" id="lblQuestion" runat="server"></div>
    <div style="margin: 4px;">
        <div style="float: left; width: 60px; height: 60px; border: 1px solid;">
            <img id="imgOtherUserIcon" runat="server" style="width: 60px; height: 60px;" />
        </div>
        <div style="float: left;">
            <div style="margin: 4px; padding: 4px; font-family: Arial; font-size: 12px;">
                <div id="lblOtherUserAnswer" style="font-size: 14px; min-height: 52px;" runat="server"></div>
                <div style="min-height: 20px; width: 350px;" id="lblOtherUserComment" runat="server"></div>
                <div id="divAnswerNow" visible="false" style="font-size: 14px; margin-top: -20px; margin-left: 100px;" runat="server">
                    <a id="lnkAnswerNow" class="lnkAnswerNow" style="font-size: 18px;" runat="server">Answer Now</a>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;"></div>
    <div style="margin: 4px;">
        <div style="float: left; width: 60px; height: 60px; border: 1px solid;">
            <img id="imgUserIcon" runat="server" style="width: 60px; height: 60px;" />
        </div>
        <div style="float: left;">
            <div style="margin: 4px; padding: 4px; font-family: Arial; font-size: 12px;">
                <div id="lblUserAnswer" style="font-size: 14px; min-height: 52px;" runat="server"></div>
                <div style="min-height: 20px; width: 350px;" id="lblUserComment" runat="server"></div>
            </div>
        </div>

        <div id="divDiscuss" runat="server" visible="false">
        <input type="button" id="btnDiscuss" class="DbuttonSubmit DiscussAboutIt" runat="server" value="Discuss" style="margin-left:460px;" />
        </div>
    </div>
    <div style="clear: both;"></div>
    <div style="text-align: right; margin-right: 20px;">
    </div>
</div>
</div>