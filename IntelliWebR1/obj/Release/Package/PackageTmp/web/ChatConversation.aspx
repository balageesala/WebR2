<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="ChatConversation.aspx.cs" Inherits="IntelliWebR1.web.ChatConversation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="article17.1">
                <div class="seventeen_one seventeen_two">
                    <div class="back_btn">
                        <img class="back fl" src="images/back_btn.png" alt="" />
                        <div class="seventeen_two_achors fr">
                            <ul class="collap">
                                <li>
                                    <input type="button" id="btnCollapse" value="Collapse all" /></li>
                                <li>
                                    <input type="button" value="Delete all" /></li>
                            </ul>
                            <span class="clear"></span>
                        </div>
                        <span class="clear"></span>
                    </div>
                    <div class="seventeen_one_cont">
                        
                    </div>
                </div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>
    <script type="text/javascript">

        $("#btnCollapse").click(function () {
            $header = $(this);
            $content = $(".collapse");
            $(".collapse").slideToggle(500, function () {
                $("#btnCollapse").val(function () {
                    return $content.is(":visible") ? "Collapse all" : "Expand all";
                });
            });
        });


    </script>




</asp:Content>
