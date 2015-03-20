<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intellidate.Master" AutoEventWireup="true" CodeBehind="EmailVerification.aspx.cs" Inherits="IntellidateR1Web.web.EmailVerification" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div style="float: left;">
        <div>Please Enter Code : </div>
        <div>
            <input type="text" id="txtScode" />
        </div>
        <div>
            <input type="button" value="Submit" id="btnSubmit" />

        </div>
        <div>
            <div id="divMsg"></div>
        </div>

        <div id="divGoHome" style="display: none">
            <div>Email verification is sucessfully compleated. click <a href="Home">Here </a>to go to home page. </div>
        </div>


    </div>

    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnSubmit").click(function () {
                var _Scode = $("#txtScode").val().trim();
                if (_Scode != "") {

                    var VerfyApi = _SitePath + "api/VerifyEmailAddress";
                    var EmailObj = new Object();

                    EmailObj.SCode = _Scode;

                    $.postDATA(VerfyApi, EmailObj, function (_return) {
                        if (_return) {
                            $("#divGoHome").css("display", "block");
                        }
                        else {
                            $("#divMsg").text("Please check your verification code");
                        }
                    });
                } else {
                    $("#divMsg").text("Please enter your verification code.");
                }
            });


        });
    </script>


</asp:Content>

