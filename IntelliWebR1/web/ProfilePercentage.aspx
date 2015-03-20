<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="ProfilePercentage.aspx.cs" Inherits="IntelliWebR1.web.ProfilePercentage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <style type="text/css">
        .toggle_text
        {
           width:97%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="complete">
                <div class="complete_cont">
                    <h1 id="hprofile" runat="server"></h1>
                    <h5>Please conplete your profile to get better matches and also to get matched better</h5>
                    <div class="toggle">
                        <div id="divAccordion" runat="server">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">

        $(".btnupdate").click(function () {
            var _Link = $(this).data("link");
            alert(_Link);
        });



    </script>

</asp:Content>
