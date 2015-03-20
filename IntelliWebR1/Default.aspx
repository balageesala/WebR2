<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" EnableViewStateMac="false" ViewStateMode="Disabled" Inherits="IntelliWebR1.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intellidate</title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.js"></script> 
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="web/js/analytics.js"></script>

    <script type="text/javascript">

        window.onpageshow = function () {
            var SESSION_API = _SitePath + "api/SessionCheck";
            $.getDATA(SESSION_API, function (_IsOnline) {
                if (_IsOnline) {
                    //console.log("go forword");
                    window.location.href = _SitePath + "default";
                }
            }, function () { });
        }
    </script>
</head>
<body>
    <div class="header">
        <div class="headerContainer">
            <div class="logo">
                <a href="Default"><img src="images/logo.png" /></a>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="containerBox">
            <div class="innerContainers whiteBox">
                <div class="photoGridBox">
                    <asp:Repeater ID="rptPhotosGrid" runat="server" OnItemDataBound="rptPhotosGrid_ItemDataBound">
                        <ItemTemplate>
                            <div class="photoContainer"><img id="imgGridPhoto" runat="server" class="gridPhoto" /></div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </div>
            <div class="innerContainers blackBox" style="z-index: 1000;">
                <div class="whiteTitle">Register for Free</div>
                <div id="divRegister" class="divRegister">
                </div>
            </div>
        </div>
    </div>
<div class="footer">
        <div class="footerInner">
            <div>&#169 Intellidate INC. 2014</div>
        </div>
</div>
</body>
</html>
