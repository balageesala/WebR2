<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stub.aspx.cs" Inherits="IntelliWebR1.Stub" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divOut" runat="server">
        </div>
        <div>
            <textarea id="txtInput" runat="server"></textarea>
        </div>
        <div><asp:Button ID="cmdConvert" runat="server" Text="Convert" OnClick="cmdConvert_Click" /> </div>
        <asp:Repeater ID="rpt" runat="server" OnItemDataBound="rpt_ItemDataBound">
            <ItemTemplate></ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
