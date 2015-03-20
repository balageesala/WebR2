<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intellidate.Master" AutoEventWireup="true" CodeBehind="ConversationView.aspx.cs" Inherits="IntellidateR1Web.web.ConversationView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    
    <div id="divToatalBox" style="margin-top:-50px;">
          <div id="divConversationView" style="float:left;width:60%;"></div>

    <div class="divMesagesBlockBox" >
        &nbsp;
    </div>

    </div>

  

    <script type="text/javascript">

        $(document).ready(function () {
          
            var _backPage = getParameterByPageName("page")
           // alert(_backPage);
            var _pathname = "";
            if (_backPage == "trash") {
                 _pathname = _SitePath + "web/inner/trashconversationview";
            } else if (_backPage == "trashchat") {
                _pathname = _SitePath + "web/inner/trashchatview";
            }else if (_backPage == "chat") {
                 _pathname = _SitePath + "web/inner/chatconversationview";
            } else {
                _pathname = _SitePath + "web/inner/conversationview?id=" + _OtherUserID;
            }

            $("#divConversationView").load(_pathname,function(){

            });

        });


        function getParameterByPageName(name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        }


    </script>


</asp:Content>
