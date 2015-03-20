<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compatibilityreportcart.aspx.cs" Inherits="IntelliWebR1.web.inner.compatibilityreportcart" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<form runat="server">
    <div style="width: 600px; min-height: 310px; border: 0px solid #ccc; margin: 0 auto; font-family: Arial; border-radius: 2px 4px;" id="divCanSend" runat="server" visible="true">
        <div style="float: right;">
            <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
        </div>

        <div style="float: left; width: 100%;">

            <div style="width: 96%; height: 230px; border: 1px solid #ccc; margin: 0 auto; border-radius: 8px 8px; padding: 10px;">
                <div>
                    <div style="float: left; font-weight: bold; padding: 6px; width: 100%; font-family: Arial;">
                       Compatibility report
                    </div>
                </div>
                <div style="float: left; margin-left: 20px;">
                    <div>
                        <img id="imgReMatchImage" class="previousMatch" runat="server" style="width: 160px; height: 160px; cursor: pointer; margin: 0 auto; border: 1px solid #000; border-radius: 6px 6px;">
                    </div>
                    <div style="text-align: center; margin-top: 4px;" id="divRematchName" runat="server"></div>
                </div>
                <div style="float: left; text-align: left; margin-top: 10px; margin-left: 20px; width: 374px">
                    <div><b>Compatibility report details: </b></div>
                    <br />
                    <div>1.Compatibility report Compatibility report</div>
                    <div>2.Compatibility report.</div>
                    <div>3.Compatibility report Compatibility report .</div>
                    <div>4.Just 1$ only.</div>
                </div>

            </div>
        </div>
        <div style="margin-bottom: 16px; margin-right: 8px; float: right; margin-top: 10px;" id="divPayUser" runat="server">
            <input type="button" id="btnReport" class="composeSend" value="View/Download report"  />
        </div>

          <div style="margin-bottom: 16px; margin-right: 8px; float: right; margin-top: 10px;" id="divSubscriber" runat="server">
            <input type="button" id="btnFreeReport" class="composeSend" value="View/Download report"  />
        </div>


        <div id="lblMessageResponse" style="min-height: 20px; float: left; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin-left: 20px; padding-top: 10px;">
        </div>


    </div>
</form>


<script type="text/javascript">

    $(document).ready(function () {

        $(".imgClose").click(function () {
            window.parent.CloseIntelliWindow();
        });

        $("#btnReport").click(function () {
            window.parent.location.href = window.parent._SitePath + "web/AlaCartePayment";
            window.parent.CloseIntelliWindow();
        });

        $("#btnFreeReport").click(function () {
            var _OtherUserID = getParameterByName("RematchID");
            window.open(window.parent._SitePath + "web/CompatibilityReport?OtherUserID=" + _OtherUserID);
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
