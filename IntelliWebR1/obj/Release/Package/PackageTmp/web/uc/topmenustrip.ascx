<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="topmenustrip.ascx.cs" Inherits="IntellidateR1Web.web.uc.topmenustrip" %>
<asp:Literal ID="ltScripts" runat="server"></asp:Literal>
<div class="divmenu" id="divOnlyLogOut" runat="server" visible="false">
    <div class="singleLogOutDiv">
        <div class="twoItems">Log Out</div>
        <div class="twoItems paddingleft6px">
            <img src="images/icon_logout.png" class="fixiconsize" />
        </div>
    </div>
</div>
<div class="divmenu" id="divAllItems" runat="server" visible="false">
    <div class="divmenuitems">

           <div id="lnkSubscribe" runat="server">
            <div style="margin-top: 0px;border-radius: 6px 6px;margin-right: 20px;">
              <a href="SubscribeNow" style="text-decoration:none;color:#fff;"> <img src="images/subscribe.png"  tabindex="0" style="border-radius:6px;" /></a>
            </div>
        </div>

        <div class="iconSection" id="lnkMessages">
            <div class="twoItems"></div>
            <div class="twoItems">
              <a href="Messages"><img src="images/icon_messages.png" class="fixiconsize" tabindex="0" /></a>
            </div>
            <div class="superDiv"><sup class="lblmesage" id="lblMsgsCount" ></sup></div>
        </div>
        <div class="iconSection" id="lnkNotifications">
            <div class="twoItems"></div>
            <div class="twoItems">
                <a href="Notifications"> <img src="images/icon_notificattions.png" class="fixiconsize" tabindex="0"  /></a>
            </div>
            <div class="superDiv"><sup class="lblmesage" id="lblNotificationsCount"></sup></div>
        </div>
          <div class="iconSection" id="lnkRematch">
            <div class="twoItems">
              <a href="MatchsHistory" style="text-decoration:none;color:#fff;"> <img src="images/rematch.png" class="fixiconsize" tabindex="0"  /></a>
            </div>
             <div class="twoItems"></div>
        </div>
       <div class="iconSection" id="lnkViewedMe">
            <div class="twoItems">
              <a href="ProfileView" style="text-decoration:none;color:#fff;"><img src="images/viewedme.png" class="fixiconsize" tabindex="0"  /></a>
            </div>
             <div class="twoItems"></div>
        </div>
        <div class="space30" id="lnkSettings">
            <div class="twoItems" style="padding-left:4px;padding-right:4px;">
             <a href="Settings">   <img src="images/icon_settings.png" class="fixiconsize" tabindex="0" /></a>
            </div>
        </div>
        <div class="iconSection" id="lnkLogOut">
            <div class="twoItems" style="padding-left:4px;padding-right:4px;">
                <a href="LogOut"> <img src="images/icon_logout.png" class="fixiconsize" tabindex="0"/></a>
            </div>
        </div>
    </div>
    <div class="divprofilepic">
       <a href="MyProfile">  <img id="imgUserIcon"  runat="server" tabindex="0" /></a>
    </div>
</div>
