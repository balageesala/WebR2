<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="IntelliWebR1.inner.login" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<link href="../css/login.css" rel="stylesheet" />
<form runat="server">
<div class="loginform">
    <div class="divclose">
        <img src="../images/close_white.png" class="imgclose" />
    </div>
    <center><h3>Login here</h3></center>
    <div class="loginbox">
    <div class="divusername">
        <input type="text" name="username" id="txtLoginName" maxlength="30" class="textField" placeholder="Login Name / Email" runat="server"  />
    </div>
    <div class="divpwd">
        <input type="password" id="txtPassword" name="password" maxlength="20" class="textField" placeholder="Password" accesskey="l" runat="server" />
    </div>
    <div class="divchekbox">
        <label >
            <input type="checkbox" id="chkRemember" checked="checked" />Keep me logged in.</label>
    </div>
    <div>
        <input type="button" id="btnLogin" class="loginbtn" value="Login" accesskey="l" />
    </div>
    <div id="divLoginError" class="divloginerr"></div>
    <div class="divforgotpwd">
        <a href="#" id="lnkForgotPassword" runat="server" style="text-decoration:none;color:white;" class="lnkForgotPassword">Forgot password?</a>
    </div>
        </div>
</div>
</form>