<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receivedmsgs.aspx.cs" Inherits="IntelliWebR1.web.inner.receivedmsgs" %>

<%@ Register Src="~/web/ko/template_receivedmessage.ascx" TagPrefix="uc1" TagName="template_receivedmessage" %>



<asp:literal id="ltScripts" runat="server"></asp:literal>

<div id="divRecivedMsgs" data-bind="template: { name: 'template_receivedmessage' }"></div>

<uc1:template_receivedmessage runat="server" ID="template_receivedmessage" />
<script type="text/javascript">

    var _GetInboxAPI = _SitePath + "api/Inbox";
    $(document).ready(function () {
        $.getDATA(_GetInboxAPI, function (_data) {
            if (_data == null || _data.length == 0) {
                $("#divRecivedMsgs").html("No messages found.");
                $("#divRecivedMsgs").addClass("nomessagesdiv");
            } else {
                // alert(JSON.stringify(_data));
                ko.applyBindings(new VMRecivedConversationSnapShotList(_data), document.getElementById("divRecivedMsgs"));
                setTimeout(function () {
                    $(".InoxloadUrl").each(function (_pos, _obj) {
                        var _loadUrl = $(_obj).data("loadurl");
                        $(_obj).load(_loadUrl, function () {
                        });
                    });
                }, 500);
                $(".divloadingimg").hide();
                $(".RecivedConversation").click(function () {
                    window.location.href = "ConversationView?page=inbox&id=" + $(this).data("conv");
                });
            }
        }, function () { });
    });


</script>