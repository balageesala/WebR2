<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="IntelliWebR1.web.Profile" %>

<%@ Register Src="~/web/uc/profilemenu.ascx" TagPrefix="uc1" TagName="profilemenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
     <asp:Literal ID="ltJScripts" runat="server"></asp:Literal>

    <style type="text/css">

        .increasewd{
            width:930px;
        }

        .tabwidth{
            width:920px;
        }

        .decreasewd{

            width:auto;
        }


    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">

    <div class="center_content">
        <div class="middle_content">
            <div class="thirteen">
             <div  class="thirteen_sutdent_chart" id="divPassPort" style="min-height:128px;"></div>
             <div id="divLoadCriteriaMatchp" class="thirteen_sutdent_chart" style="min-height:139px;">&nbsp;</div>
             <div id="divLoadProfileMatchp" class="thirteen_sutdent_chart" style="min-height:139px;">&nbsp;</div>
             <uc1:profilemenu runat="server" ID="profilemenu" />

             <div class="thirteen_cont" id="divOtherProfileContainer"> </div>
             <div class="thirteen_cont" style="margin-left:-4px;" id="divOtherProfilePhotos"> </div>
             <div class="thirteen_cont" style="margin:0px;" id="divOtherProfileCriteria"> </div>
             <div class="thirteen_cont" style="margin:0px;" id="divOtherProfileQuestions"> </div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>


    <script type="text/javascript">

        $(document).ready(function () { 
            var _passportUrl = _SitePath + "web/inner/theirpassport?uid="+_OtherUserID;
            $("#divPassport").load(_passportUrl, function () {

            });
        });


    </script>

</asp:Content>
