<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="discusscompose.aspx.cs" Inherits="IntelliWebR1.web.inner.discusscompose" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<style type="text/css">
    .composeSend {
    padding: 8px 28px;
    border-radius: 3px;
    background-color: #c1272d;
    height: 34px;
    font-size: 0.9em;
    font-weight: 400;
    letter-spacing: 1px;
    color: #fff;
    text-align: center;
    border: none;
    cursor: pointer;
    float: right;
}
</style>

<div style="width: 680px; min-height: 400px; border: 0px solid #ccc; margin: 0 auto; border-radius: 2px 4px;background:#fff;" id="divCanSend" runat="server" >

     <div style="float: right;">
            <img src="../images/close.png" class="imgClose" style="cursor:pointer;" />
       
        </div>


    <div id="divLoadQuestion">

    </div>
    <div style="float:left;width:100%;">
        <div style="width:96%;border: 1px solid #ccc;margin:0 auto;border-radius:8px 8px;">
            <textarea id="txtMessage" placeholder="Enter Message" style="border: 0px;resize: none;width: 576px;font-family: 'Open Sans', 'sans-serif', Arial;font-size: 16px;outline: none;height: 100px;border-radius: 8px 8px;padding: 4px;"></textarea>
        </div>
    </div>
    <div style="margin-bottom: 16px;margin-right:8px; float: right;margin-top:10px;">
        <input type="button" id="btnSend" class="composeSend" value="Send" />
    </div>
    <div id="lblMessageResponse" style="min-height: 20px; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin: 20px;float: left;">
    
    </div>
</div>

<div style="width: 680px; min-height: 400px; border: 0px solid #ccc; margin: 0 auto; border-radius: 2px 4px;background:#fff;" id="divCantSend" runat="server" visible="false">
     <div style="float: right;">
            <img src="../images/close.png" class="imgClose"  style="cursor:pointer;" />
        </div>
     <div style="font-family: 'Open Sans', 'sans-serif', Arial; font-size: 16px; font-weight: bold; margin: 10px;padding-top:40px;text-align:center;">You are restricted to send message until you receive a response.</div>
</div>


