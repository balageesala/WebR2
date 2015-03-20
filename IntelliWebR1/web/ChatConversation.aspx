<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="ChatConversation.aspx.cs" Inherits="IntelliWebR1.web.ChatConversation" %>

<%@ Register Src="~/web/ko/template_chatconversation.ascx" TagPrefix="uc1" TagName="template_chatconversation" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="article17.1">
                <div class="seventeen_one seventeen_two">
                    <div class="back_btn">
                        <img class="back fl" id="Btnback" src="images/back_btn.png" alt="" />
                        <span class="clear"></span>
                    </div>
                    <div id="divChatView" data-bind="template: { name: 'template_chatview' }"></div>
                    <uc1:template_chatconversation runat="server" ID="template_chatconversation" />
                </div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>
    <script type="text/javascript">
        var _ChatViewAPI = _SitePath + "api/GetIM";
        $(document).ready(function () {
            var _ViewObject = new Object();
            _ViewObject.OtherUserID = _OtherUserID;
            $.postDATA(_ChatViewAPI, _ViewObject, function (_data) {
               // console.log(JSON.stringify(_data));
                ko.applyBindings(new VMChatList(_data), document.getElementById("divChatView"));
            });


            $("#Btnback").click(function () {
                window.history.back();
            });


        });
    </script>
</asp:Content>
