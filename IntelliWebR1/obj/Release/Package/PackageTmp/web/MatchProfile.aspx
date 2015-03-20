<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MatchProfile.aspx.cs" Inherits="IntelliWebR1.web.MatchProfile" %>

<%@ Register Src="~/web/uc/otheruserpic.ascx" TagPrefix="uc1" TagName="otheruserpic" %>
<%@ Register Src="~/web/uc/matchprofilemenu.ascx" TagPrefix="uc1" TagName="matchprofilemenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
      <asp:Literal ID="ltJScripts" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="thirteen">
                <div id="divOtherProfilePic" style="float: left; width: 100%; ">
                    <uc1:otheruserpic runat="server" ID="otheruserpic" />
                </div>
                <uc1:matchprofilemenu runat="server" ID="matchprofilemenu" />
                <div id="divMatchWritten">
                </div>
                <div id="divMatchPhotos">
                </div>
               
            </div>
             <aside></aside>
                <span class="clear"></span>
            </div>
    </div>
</asp:Content>
