<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chatmsgs.aspx.cs" Inherits="IntelliWebR1.web.inner.chatmsgs" %>

<%@ Register Src="~/web/ko/template_chatmessage.ascx" TagPrefix="uc1" TagName="template_chatmessage" %>
<%@ Register Src="~/web/uc/passport.ascx" TagPrefix="uc1" TagName="passport" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>

 <div id="divChatMsgs" data-bind="template: { name: 'template_chatmessage' }"> </div>
 <uc1:template_chatmessage runat="server" id="template_chatmessage" />




