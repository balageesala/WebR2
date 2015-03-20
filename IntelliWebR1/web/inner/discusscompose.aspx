<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="discusscompose.aspx.cs" Inherits="IntelliWebR1.web.inner.discusscompose" %>

<!DOCTYPE html>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<style type="text/css">
   .redColor {
  color: red;
}
</style>

    <div class="chatwithme" id="divCanSend" runat="server">
    	<a class="close imgClose" style="cursor:pointer;" >x</a>
        <span class="clear"></span>
        <div class="chatme_cont">
        	<h3 id="hQuestion" runat="server"></h3>
            <div class="chatme_chat">
            	<img id="thisUserImg" runat="server" width="50" height="50" alt=""/>
                <div class="chatme_type">
                <h5 id="hThisAnswer" runat="server"></h5>
                <p id="pThisComment" runat="server"></p>
                </div>
                <span class="clear"></span>
            </div>
            
            <div class="chatme_chat">
            	<img id="otherUserImg" runat="server" width="50" height="50" alt=""/>
                <div class="chatme_type">
                <h5 id="hOtherAnswer" runat="server"></h5>
                <p id="pOtherComment" runat="server"></p>
                </div>
                <span class="clear"></span>
            </div>
            <textarea class="" rows="3" cols="1" name="message" id="txtMessage" placeholder="Enter Message"> </textarea>            
        </div>
        <input id="btnSend" type="button" class="send" value="Send"/>
        <div style="margin-left: 30px;" id="lblMessageResponse"></div>
        <span class="clear"></span>
    </div>

  <div class="chatwithme" id="divCantSend" runat="server">
      <a class="close imgClose" style="cursor:pointer;" >x</a>
        <span class="clear"></span>
       <div style="text-align:center;padding-bottom:20px;">You are restricted to send message until you receive a response.</div>
  </div>



