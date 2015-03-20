<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="emailprofile.aspx.cs" Inherits="IntelliWebR1.web.inner.emailprofile" %>

<style>
    .textbox {
        width: 200px;
    }

    .button {
        padding: 4px 8px;
        border-radius: 3px;
        background-color: #C1282D;
        font-size: 0.85em;
        font-weight: 400;
        letter-spacing: 1px;
        color: #fff;
        text-align: center;
        border: none;
        cursor: pointer;
        width: 200px;
    }

    .divemailBox {
        float: left;
        width: 220px;
        height: 140px;
        background: #fff;
        padding: 6px;
        color: #000;
        font-family: Tahoma, sans-serif, Arial;
        border-radius: 6px 6px;
        padding-bottom: 20px;
        padding-left: 20px;
    }
</style>

  <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
  <script src="../../Scripts/js_fun.js"></script>
<div class="divemailBox">
    <div style="float: right;">
        <img src="../images/close.png" id="imgClose" />
    </div>
    <div style="float: left; width: 100%;padding-left:1px;">Please enter email address</div>
    <div style="float: left; width: 100%; margin-top: 10px;">
        <input type="text" id="txtEmail" class="textbox" />
    </div>
    <div style="margin-top: 4px; float: left;">
        <input type="button" id="btnSubmit" value="SUBMIT" class="button" />

    </div>

    <div style="margin-top: 4px; float: left;" id="lblerror" ></div>

</div>


<script type="text/javascript">

    $(document).ready(function () {

      $("#imgClose").click(function(){
       
         window.parent.CloseIntelliWindow();

      });

      $("#txtEmail").keyup(function () {
          $("#lblerror").html("");
      });


      $("#btnSubmit").click(function () {

          var _emailaddress = $("#txtEmail").val();
          var _EmailAddressPattern = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
          if (_emailaddress == "") {
              $("#lblerror").html("Please enter email address.");
              return;
          }else  if (!_EmailAddressPattern.test(_emailaddress)) {
              $("#lblerror").html("Invalid email address.");
              return;
          } else {
              $("#lblerror").html("");
              var APIADDRESS = window.parent._SitePath + "api/EmailProfile";
              var _Obj = new Object();
              _Obj.EmailAddress = _emailaddress;
              _Obj.ProfileUserID = window.parent._OtherUserID;
              $.postDATA(APIADDRESS, _Obj , function (_ConversationObject) {
                  $("#lblerror").html("This profile sent sucessfully");
                  setTimeout(function () {
                      $("#lblerror").fadeOut(1000);
                      setTimeout(function () {
                          try {
                              window.parent.CloseIntelliWindow();
                          } catch (e) {
                              window.parent.CloseIntelliWindow();
                          }
                      }, 2000);
                  }, 2000);
              });
          }

      });


    });
</script>