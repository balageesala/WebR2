<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IntelliWebR1.web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
    <asp:fileupload runat="server" ID="FUpload"></asp:fileupload>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <input type="button" id="btnSubmit" value="submit" />
        <script type="text/javascript">       
        </script>
    </div>
    </form>
</body>
</html>
