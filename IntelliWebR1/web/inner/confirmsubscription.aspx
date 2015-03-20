<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmsubscription.aspx.cs" Inherits="IntelliWebR1.web.inner.confirmsubscription" %>


<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<form runat="server">
    <div style="width: 600px; min-height: 310px; border: 0px solid #ccc; margin: 0 auto; font-family: Arial; border-radius: 2px 4px;" id="divCanSend" runat="server" visible="true">
        <div style="float: right;">
            <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
        </div>

        <div style="float: left; width: 100%;">

            <div style="width: 96%; height: 210px; border: 1px solid #ccc; margin: 0 auto; border-radius: 8px 8px; padding: 10px;">
                <div id="divBasic">
                    <div>
                        <b>Basic subscription details: </b>
                    </div>
                    <br />
                    <div>1. You can communicate 7 days again.</div>
                    <div>2. Compatibility report.</div>
                    <div>3. You can access recently updated information.</div>
                    <div>4. Just 11$ only.</div>

                   
                </div>

                <div id="divTop">
                    <div>
                        <b>Top subscription details: </b>
                    </div>
                    <br />
                    <div>1. You can communicate 7 days again.</div>
                    <div>2. Compatibility report.</div>
                    <div>3. You can access recently updated information.</div>
                    <div>4. Just 17$ only.</div>
                </div>
                <br />
                 <div id="divNoOfMounths" style="font-weight:bold;"></div><br />
                 <div id="divTotalPrice" style="font-weight:bold;"></div>
            </div>

        </div>
        <div style="margin-bottom: 16px; margin-right: 8px; float: right; margin-top: 10px;">
            <input type="button" id="btnRematch" class="composeSend" value="Confirm and pay" />
        </div>
        <div id="lblMessageResponse" style="min-height: 20px; float: left; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin-left: 20px; padding-top: 10px;">
        </div>

        <script type="text/javascript">
            $(document).ready(function () {
                var _SubType = getParameterByName("type");
                var _Days = getParameterByName("days");
                var _Mounths = eval(_Days / 30);
                if (_SubType == "1") {
                    $("#divTop").show();
                    $("#divBasic").hide();
                    var _TotalPrice = eval(17 * _Mounths);
                    $("#divTotalPrice").html("Total price: " + _TotalPrice + "$");
                } else {
                    $("#divBasic").show();
                    $("#divTop").hide();
                    var _TotalPrice = eval(11 * _Mounths);
                    $("#divTotalPrice").html("Total price: " + _TotalPrice + "$");
                }
                $("#divNoOfMounths").html("No of subscription days: " + _Days);

                $(".imgClose").click(function () {
                    window.parent.CloseIntelliWindow();
                });


                $("#btnRematch").click(function () {
                    window.parent.location.href = window.parent._SitePath + "web/SubscriptionPayment";
                    window.parent.CloseIntelliWindow();
                });



            });

            function getParameterByName(name) {
                name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(location.search);
                return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
            }

        </script>
    </div>
</form>
