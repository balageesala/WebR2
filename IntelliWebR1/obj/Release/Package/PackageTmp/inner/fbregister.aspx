<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fbregister.aspx.cs" Inherits="IntelliWebR1.inner.fbregister" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<link href="../css/login.css" rel="stylesheet" />
<div class="loginform">
    <div class="divclose">
        <img src="../images/close_white.png" class="imgclose" />
    </div>
  
    <div class="loginbox divfbBox">
        <div class="divusername" style="font-size:13px;margin-top:10px;font-weight:bold">Set your username and password.</div>
        <div class="divusername">
            <label id="lblEmail" ></label>
        </div>
        <div class="divusername">
           <label id="lblGender"></label>
        </div>
        <div class="divusername">
            <label id="lblDob"></label>
        </div>
    <div class="divusername">
        <input type="text" id="txtFbLoginName" maxlength="30" class="textField" placeholder="Login Name" name="off" />
        <div id="divFbLoginNameError"></div>
    </div>
    <div class="divpwd">
        <input type="password" id="txtFbPassword" maxlength="20" class="textField" placeholder="Password" accesskey="l" name="off" />
    <div id="divFbPasswordError"></div>
    </div>
    <div>
        <input type="button" id="btnFbLogin" class="loginbtn" value="Login" accesskey="l" />
    </div>
    <div id="divFbLoginError" class="divloginerr divFbLoginError"></div>
        </div>


    <div id="divEmail" style="text-align:center;margin-top:100px;">
        You have already logged in with this accout.
    </div>


</div>

<script>

  
</script>
