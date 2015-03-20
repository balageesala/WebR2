<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="IntelliWebR1.web.inner.password" %>

<style>

    .buttonSubmit{
	padding:6px 20px;
	border-radius:3px;
	background-color:#000;
	font-size:0.85em;
	font-weight:400;
	letter-spacing:1px;
	color:#fff;
	text-align:center;
	border:none;
	cursor:pointer;
    width: 172px;
	}


</style>

 <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:Literal ID="ltJScripts" runat="server"></asp:Literal>
<div style="width:198px;background:#C1282D;padding-left:20px;padding-top:16px;padding-bottom:20px;padding-right:6px; color:#fff;font-family: Tahoma, sans-serif, Arial;border-radius:6px;">
    <div style="float:right;margin-top:-10px;">
        <img src="../images/close_white.png" id="imgClose" /></div>
    <div style="padding-left:2px;padding-top:2px;padding-bottom:4px;">Please enter password </div>
    <div style="padding-bottom:4px;"><input type="password" id="txtUserPwd" accesskey="E" /></div>
    <div style="margin-left:3px;"><input type="button" id="btnSubmit" value="Submit" class="buttonSubmit" accesskey="E" /></div>

</div>

<script>


    var _UserNameResult = window.parent.document.getElementById("divLoginNameError");
    var _EmailResult = window.parent.document.getElementById("divEmailAddressError");
    var _PasswordResult = window.parent.document.getElementById("divPasswordError");
    
    $(document).ready(function () {
       
        $("#imgClose").click(function () {
            window.parent.CloseIntelliWindow();
        });



        $("#txtUserPwd").keydown(function (e) {
            if (e.keyCode == 13) {
                $("#btnSubmit").trigger("click");
            }
        });



        $("#btnSubmit").click(function () {
            var _setting = window.parent._changeSetting;
            $(this).prop("disabled", true);
            var _ApiPasswordConfirm = _SitePath + "api/PasswordConfirm";
            var _data = new Object();
            _data.Password = $("#txtUserPwd").val();

            $.postDATA(_ApiPasswordConfirm, _data, function (m_return) {
                if (_setting == "U") {
                    ChangeUserName(m_return);
                }
                if (_setting == "E") {
                    ChangeEmailAddress(m_return);
                }
                if (_setting == "P") {
                    ChangePassword(m_return);
                }
            });

        });
           
        });


    function ChangeUserName(_Proceed) {
        if (_Proceed) {
            var _UserName = new Object();
            _UserName.UserNameSelected =window.parent.document.getElementById("txtUserName").value;
            var _UserNameAPI = _SitePath + "api/UserName";
            $.postDATA(_UserNameAPI, _UserName, function (_ret) {
                if (_ret) {
                    $(_UserNameResult).html("User Name changed successfully.");
                    window.parent.CloseIntelliWindow();
                } else {
                    $(_UserNameResult).html("Error changing username please login and try again.");
                    window.parent.CloseIntelliWindow();
                }

            });
        }
        else {
            $(_UserNameResult).html("The password you have entered is incorrect");
            window.parent.CloseIntelliWindow();
        }
        
    }


    function ChangeEmailAddress(_Proceed) {
        if (_Proceed) {
            var _EmailAddressAPI = _SitePath + "api/EmailAddress";
            var _EmailAddress = new Object();
            _EmailAddress.EmailAddressSelected = window.parent.document.getElementById("txtEmil").value;
            $.postDATA(_EmailAddressAPI, _EmailAddress, function (_ret) {
                if (_ret) {
                    $(_EmailResult).html("Email Address changed successfully.");
                    window.parent.CloseIntelliWindow();
                } else {
                    $(_EmailResult).html("Error changing email address please login and try again.");
                    window.parent.CloseIntelliWindow();
                }
            });
        }
        else {
            $(_EmailResult).html("The password you have entered is incorrect");
            window.parent.CloseIntelliWindow();
        }
       
    }


    function ChangePassword(_Proceed) {
        if (_Proceed) {
            var _PasswordAPI = _SitePath + "api/Password";
            var _Password = new Object();
            _Password.PasswordSelected = window.parent.document.getElementById("txtRetypePassword").value;
            $.postDATA(_PasswordAPI, _Password, function (ret) {
                if (ret) {
                    $(_PasswordResult).html("Password changed successfully.");
                    window.parent.CloseIntelliWindow();
                } else {
                    $(_PasswordResult).html("Error changing password please login and try again.");
                    window.parent.CloseIntelliWindow();
                }
            });
        }
        else {
            $(_PasswordResult).html("The password you have entered is incorrect");
            window.parent.CloseIntelliWindow();
        }
        
    }



  



</script>