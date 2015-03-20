<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rematchuser.aspx.cs" Inherits="IntelliWebR1.web.inner.rematchuser" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>



  <div class="buyrematch">
    	<a class="close imgClose">x</a>
        <span class="clear"></span>
        <div class="buyrematch_cont">
        	<h3>This Re-match available date: &nbsp;<span id="divAvilableDate" runat="server"></span></h3>        
            <div class="match_detail">
               <div style="float:left;width:100px;"> 
               <img id="imgReMatchImage" class="previousMatch" width="99" height="99" runat="server" />
                <span id="divRematchName" runat="server" style="float:left;padding-top:10px;text-align:center;"></span></div>
                <div class="match_detail_type" style="padding-left:10px;">
                <h5>Re-match details:</h5>
                <ul>
                	<li>You can communicate 7 days again.</li>
                    <li>Compatibility report</li>
                    <li>You can access recently updated information.</li>
                    <li>Just 2.5$ only.</li>
                </ul>
                </div>
                <span class="clear"></span>
            </div>
        </div>
         <div id="lblMessageResponse"  style="min-height: 20px; float: left;margin-left:30px;">
        </div>
        <input type="button" id="btnRematch" class="send" value="Buy this Re-match"/>
        <span class="clear"></span>
    </div>


<script type="text/javascript">

    $(document).ready(function () {

        $(".imgClose").click(function () {
            window.parent.CloseIntelliWindow();
        });

        $("#btnRematch").click(function () {
            window.parent.location.href = window.parent._SitePath + "web/AlaCartePayment";
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
