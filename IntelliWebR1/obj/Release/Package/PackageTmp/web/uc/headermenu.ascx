<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="headermenu.ascx.cs" Inherits="IntelliWebR1.web.uc.headermenu" %>
<header>
    <div class="header_center">
        <div class="logo"><a href="Home">Intellidate</a></div>
        <nav>
            <ul>
                <li class="no_bg"><a href="MatchHistory" class="rematch"></a></li>
                <li><a href="Messages" class="envelop"></a></li>
                <li><a href="ProfileView" class="viewed"></a></li>
                <li><a href="Notifications" class="alert"></a></li>
                <li><a href="../Subscribe" class="lock" id="lnkSubscribe" runat="server"></a></li>
                <li class="no_bg space"><a id="lnkHelp" class="legand"></a></li>
                <li><a href="Settings" class="setting"></a></li>
                <li><a href="LogOut" class="logout"></a></li>
                <li class="no_bg no_space">
                    <a href="MyProfileAboutme">
                        <img class="pic" src="images/profile_head.png" id="imgUserIcon" runat="server" width="53" height="52" alt="pic" /></a>
                </li>
            </ul>
            <span class="clear"></span>
        </nav>
        <span class="clear"></span>
    </div>
</header>
