<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="IntelliWebR1.web.Messages" %>
<%@ Register Src="~/web/uc/messagesmenu.ascx" TagPrefix="uc1" TagName="messagesmenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="article17">
                <div class="twenty">
                    <uc1:messagesmenu runat="server" ID="messagesmenu" />
                   <div id="divMessagesList">                      
                   </div>
                </div>
            </div>
            <span class="clear"></span>
        </div>
    </div>
</asp:Content>
