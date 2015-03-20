<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailVerification.aspx.cs" Inherits="IntelliWebR1.EmailVerification" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Intellidate</title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="web/js/analytics.js"></script>


    <style>
        .emailDiv {
            width: 800px;
            margin: 0 auto;
        }


        .emailBox {
            width: 800px;
            min-height: 450px;
            margin: 0 auto;
            background:#fff;
            padding-top:30px;
            padding:10px;
        }


    </style>


</head>
<body>
    <div class="header">
        <div class="headerContainer">
            <div class="logo">
               
                    <img src="images/logo.png" />
            </div>
        </div>
    </div>
    <div class="container">
        <div class="emailDiv" style="margin-top: 100px;">
            <div class="emailBox" >
                <div id="divMessage" runat="server"></div>
                <br />
                <div id="divLogin">Please click<a href="Default"> here </a> to login</div>

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
