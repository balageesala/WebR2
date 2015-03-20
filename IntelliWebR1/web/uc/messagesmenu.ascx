<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="messagesmenu.ascx.cs" Inherits="IntelliWebR1.web.uc.messagesmenu" %>
<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
   <style type="text/css">
        .nomessagesdiv {
            margin-top: 20px;
            text-align: center;
            min-height: 50px;
        }
    </style>
<div class="tab_nav">
    <ul>
        <li><a id="liReceived">Received</a></li>
        <li><a id="liFiltered">Filtered</a></li>
        <li><a id="liSentBox">Sent</a></li>
        <li><a id="liInstantMessage">Chats</a></li>
        <li><a id="liTrash">Trash</a></li>
    </ul>
    <span class="clear"></span>
</div>


