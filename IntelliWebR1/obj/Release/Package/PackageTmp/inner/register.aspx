<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" EnableViewStateMac="false" CodeBehind="register.aspx.cs" Inherits="IntelliWebR1.inner.register" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div>
    <div class="genderDiv">
        <div>
            <input type="radio" id="rdoGender_Male" name="rdoGender" checked="checked" /><label for="rdoGender_Male">Male</label>
        </div>
        <div>
            <input type="radio" id="rdoGender_Female" name="rdoGender" /><label for="rdoGender_Female">Female</label>
        </div>
    </div>
    <div class="clearBoth"></div>
    <div class="fields">
        <input type="text" id="txtLoginName" maxlength="30" placeholder="Login Name" class="textField" />
    </div>
    <div id="divLoginNameError" class="errorDiv"></div>
    <div class="fields">
        <input type="text" id="txtEmailAddress" maxlength="100" placeholder="Email Address" />
    </div>
    <div id="divEmailAddressError" class="errorDiv"></div>
    <div class="fields">
        <input type="text" id="txtREmailAddress" maxlength="100" placeholder="Retype Email Address" />
    </div>
    <div id="divREmailAddressError" class="errorDiv"></div>
    <div class="fields">
        <input type="password" id="txtPassword" maxlength="20" placeholder="Password" />
    </div>
    <div id="divPasswordError" class="errorDiv"></div>
    <div class="fields">
        <input type="password" id="txtRPassword" maxlength="20" placeholder="Retype Password" />
    </div>
    <div id="divRPasswordError" class="errorDiv"></div>
    <div class="fields">
        <div>
            <select id="cboMonth" runat="server"></select>
        </div>
        <div>
            <select id="cboDate" runat="server"></select>
        </div>
        <div>
            <select id="cboYear" runat="server"></select>
        </div>
    </div>
    <div class="clearBoth"></div>
    <div id="divDateOfBirthError" class="errorDiv"></div>

    <div class="checkBoxField">
        <input type="checkbox" id="chkAcceptTerms" /><label for="chkAcceptTerms">Do you accept the <a id="lnkTerms" runat="server"><u>terms &amp; conditions</u></a></label>
    </div>
    <div id="divAcceptError" class="errorDiv"></div>
    <div>
        <div class="registerButton" tabindex="0">Register</div>
    </div>
    <div id="divRegisterError" class="errorDiv"></div>
    <div class="fields">
        <label>Already have an account ? Login <a style="cursor: pointer" id="lnkLogin" runat="server"  data-width="300" data-height="260" tabindex="0"><u>here</u></a></label>

        <a id="lnkforgotpwd" class="lnkforgotpwd" runat="server" data-width="332" data-height="180" visible="true"></a>

    </div>
     <div class="fields">    
         <div style="float:left;" >
             <div  style="margin-top:6px;">Please login with your facebook</div>
             <div id="divfblogin"> <img src="images/icon-facebook.png" style="width:30px;height:30px;cursor:pointer;" tabindex="0"/></div>
             <a id="lnkFbRegister" class="lnkFbRegister" runat="server" data-width="310" data-height="270" visible="true"></a>     
               </div>
     </div>
</div>
