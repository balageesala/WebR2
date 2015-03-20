<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="photofullview.aspx.cs" Inherits="IntelliWebR1.web.inner.photofullview" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            margin: 0px;
        }

        .divContainer {
        }

            .divContainer:hover .prevButton .nextButton {
                display: block;
            }


        .prevButton .nextButton {
            cursor: pointer;
            display: none;
        }
    </style>
</head>
<body>
    <div  style="border:0px solid;float:left;">
        <div id="divContainer" class="divContainer" runat="server" style="margin:0 auto;">
            <img id="imgFullView" runat="server" />
        </div>
    </div>
</body>
</html>
