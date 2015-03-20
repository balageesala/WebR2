<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilecompletion.aspx.cs" Inherits="IntelliWebR1.web.inner.profilecompletion" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>

<div>
    <div style="padding-left: 40px; padding-top: 20px;">
        <div>
            <div id="lblProfileComplete" style="float: left; width: 100%; margin-top: 20px;">
                <div class="ProfileCompletion_Section">
                    <span class="profileCompletionTitle">Your Profile is</span>
                    <span style="float: left; margin-top: -30px; margin-left: 20px;">
                        <img id="imgPercentageMeter" runat="server" style="width:88px;height:88px;display:none;" /></span>
                    <span class="profileCompletionTitle" runat="server" id="lblProfileCompletionText"></span>
                </div>
            </div>
        </div>
        <asp:repeater id="rptProfileCompletion" runat="server" onitemdatabound="ProfileCompletion_ItemDataBound">
            <ItemTemplate>
                <div style="width: 100%; float: left; margin-top: 10px;color:#F0FFFF;">
                    <div style="width: 100%;">
                        <div style="padding-top: 0px; width: 400px; margin-left: 6px; cursor: pointer;">
                            <div style="float:left;width:20px;"><img src="images/file-icon.png" style="float:left;width:20px;height:20px;"/> </div>
                            <div style="float:left;" id="divPoints" runat="server"></div>
                            <div style="float:left;font-weight:bold;" id="divAbout" runat="server"></div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:repeater>
    </div>
</div>
