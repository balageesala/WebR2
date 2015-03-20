<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="IntelliWebR1.inner.forgotpassword" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltForgotPassword" runat="server"></asp:literal>
<link href="../css/popups.css" rel="stylesheet" />
<div class="popupform">
    <div class="popupHeader">
        <div class="divleft">Forgot Password ?</div>
        <div class="divright">
            <img src="../images/close_white.png" class="imgclose" />
        </div>
    </div>
    <div>
        <input type="text" class="textField" id="txtFpEmailAddress" maxlength="50" placeholder="Email Address" />
    </div>
    <div>                                                    
        <input type="button" id="btnRetreivePassword" value="Retrieve Password" class="submitButton" />
    </div>
    <div class="divcenter">
        <span id="lblForgotPasswordResult" class="lblerr"></span>
    </div>
</div>
