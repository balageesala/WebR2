<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compatibilityreportcart.aspx.cs" Inherits="IntelliWebR1.web.inner.compatibilityreportcart" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<form runat="server">

    <div class="compatible">
    	<a class="close imgClose">x</a>
        <span class="clear"></span>
        <div class="compatible_cont">
        	<h3>Compatibility Report</h3>
            <div class="match_detail">
                <div style="float:left;width:110px;">
                <img id="imgReMatchImage" class="previousMatch" runat="server"  width="99" height="99" alt=""/>
                <span id="divRematchName" runat="server"></span>
                </div>
                <div class="match_detail_type">
                <h5>Compatibility report details:</h5>
                <ul>
                	<li><span>1.</span>Compatibility report Compatibility report </li>
                    <li><span>2.</span>Compatibility report</li>
                    <li><span>3.</span>Compatibility report Compatibility report </li>
                    <li><span>4.</span>Just 1$ only.</li>
                </ul>
                </div>
                <span class="clear"></span>
                <p id="divPayUser" runat="server"></p>
            </div>
            
            
            
        </div>
        <div id="lblMessageResponse" runat="server" style="min-height: 20px; float: left; padding-top: 10px;">
        </div>
        <div id="divSubscriber" runat="server">
        <input type="button" class="send" id="btnReport" value="View/Download report"/>
            </div>
        <input type="button" class="send"  id="btnFreeReport"  value="View/Download report"/>
        <span class="clear"></span>
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
