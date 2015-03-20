<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcontact.aspx.cs" Inherits="IntelliWebR1.web.inner.addcontact" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<style type="text/css">


    .textField {
    width: 230px;
    font-size: 14px;
}
    .fields {
    margin: 8px;
    margin-top: 10px;
}

    .fields div {
        float: left;
        margin-right: 4px;
    }

        .fields div select {
            border: 0px;
            font-size: 16px;
            height: 28px;
            border-radius: 2px 2px;
            width: 93px;
        }


    .fields input {
        border: 0px;
        font-size: 14px;
        width: 280px;
        height: 28px;
        border-radius: 2px 2px;
        padding: 4px;
    }

    .submitContact {
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

}

</style>

<div style="width: 600px; border: 0px solid #ccc; margin: 0 auto; border-radius: 2px 4px;" >
    <div style="float:left;width:100%;padding-top:10px;">
    <div style="float: right;">
        <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
    </div>
    </div>
   
   <div>
    <div style="float: left; width: 100%;">
        <div class="fields">Add new contact</div> 
        <div style="padding:4px;border:1px solid #ccc;margin-top:10px;border-radius:6px 6px;">
          <div class="fields"> <input type="text" id="txtFirstName" placeholder="Enter Firstname" class="textField" />*</div> 
          <div class="fields"> <input type="text" id="txtLastName" placeholder="Enter Lastname" class="textField" />*</div> 
          <div class="fields"> <input type="text" id="txtEmailAddress" placeholder="Enter email address" class="textField" />*</div> 
          <div class="fields"> <input type="text" id="txtMobileNoOne" maxlength="12" placeholder="Enter mobile number" class="textField" />(Optional)</div> 
          <div class="fields"> <input type="text" id="txtMobileNoTwo" maxlength="12" placeholder="Enter secondary mobile number" class="textField" />(Optional)</div> 
          <div class="fields"> <input type="text" id="txtCityName" maxlength="30" placeholder="Enter city name" class="textField" />(Optional)</div> 
          <div class="fields"> <input type="text" id="txtZipCode" maxlength="5" placeholder="Enter zip-code" class="textField" />(Optional)</div> 
        <div class="fields">
        <input type="button" id="btnAddContact" class="submitContact" value="Add Contact"  />
    </div>
         </div>
    </div>
   
    <div id="lblMessageResponse" style="min-height: 20px; float: left; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin-left: 20px; padding-top: 10px;">
   
    </div>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {

            $(".imgClose").click(function () {
                window.parent.CloseIntelliWindow();
            });


            $("#txtMobileNoOne").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#lblMessageResponse").html("Enter numbers only.").show().fadeOut(5000);
                    return false;
                }
            });

            $("#txtMobileNoTwo").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#lblMessageResponse").html("Enter numbers only.").show().fadeOut(5000);
                    return false;
                }
            });

            $("#txtZipCode").keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $("#lblMessageResponse").html("Enter numbers only.").show().fadeOut(5000);
                    return false;
                }
            });


            $("#btnAddContact").click(function () {

              
                var _FirstName = $("#txtFirstName").val().trim();
                var _LastName = $("#txtLastName").val().trim();
                var _EmailAddress = $("#txtEmailAddress").val().trim();
                var _MobileNoOne = $("#txtMobileNoOne").val().trim();
                var _MobileNoTwo = $("#txtMobileNoTwo").val().trim();
                var _CityName = $("#txtCityName").val().trim();
                var _ZipCode = $("#txtZipCode").val().trim();

                if (_FirstName == "") {
                    $("#lblMessageResponse").html("First name should not be empty.").show().fadeOut(5000);
                    return;
                }
                if (_LastName == "") {
                    $("#lblMessageResponse").html("Last name should not be empty.").show().fadeOut(5000);
                    return;
                }
                if (_EmailAddress == "") {
                    $("#lblMessageResponse").html("Email address should not be empty.").show().fadeOut(5000);
                    return;
                }

                var _EmailAddressPattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
                if (!_EmailAddressPattern.test(_EmailAddress)) {
                    $("#lblMessageResponse").html("Email address not valid.").show().fadeOut(5000);
                    return;
                }

                var _ContactObj = new Object();
                _ContactObj.FirstName = _FirstName;
                _ContactObj.LastName = _LastName;
                _ContactObj.EmailAddress = _EmailAddress;
                _ContactObj.PhoneNoOne = _MobileNoOne;
                _ContactObj.PhoneNoTwo = _MobileNoTwo;
                _ContactObj.CityName = _CityName;
                _ContactObj.ZipCode = _ZipCode;
                var _apiAddContact = _SitePath + "API/AddContact";
                $("#btnAddContact").attr("disabled", "disabled");
                $.postDATA(_apiAddContact, _ContactObj, function (_return) {
                    if (_return) {
                        $("#lblMessageResponse").html("Your new contact successfully added.").show().fadeOut(5000);
                      //  window.parent.CloseIntelliWindow();
                    }
                    else {
                        $("#lblMessageResponse").html("Opp's error!.").show().fadeOut(5000);
                    }
                });


            });



        });

    </script>


</div>