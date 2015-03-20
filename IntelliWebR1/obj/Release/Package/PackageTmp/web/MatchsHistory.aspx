<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intellidate.Master" AutoEventWireup="true" CodeBehind="MatchsHistory.aspx.cs" Inherits="IntellidateR1Web.web.MatchsHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="float: left; width: 100%; padding: 10px; margin-top: -38px;" id="divCurrentMatchs" runat="server" visible="false">
            <div style="float: left; width: 100%; font-size: large; font-weight: bold;">Current matches</div>
            <asp:Repeater ID="rptCurrentMatches" runat="server">
                <ItemTemplate>
                    <div style="float: left; width: 168px; margin-left: 6px;">
                        <div style="float: left; width: 168px; border: 1px solid #ccc; text-align: center; padding-bottom: 4px; margin-top: 4px;">
                            <div id="divDate" runat="server" style="float: left; width: 168px; text-align: center; margin-top: 4px; font-weight: bold; font-family: Arial"></div>
                            <div style="float: left; width: 168px; min-height: 160px;">
                                <img id="imgMatchImage" runat="server" visible="false" class="currentMatch" style="width: 160px; height: 160px; cursor: pointer; margin: 0 auto; border: 1px solid #000; border-radius: 6px 6px;" tabindex="0" />

                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="float: left; width: 100%; padding: 10px;" id="divRematchedThem" runat="server" visible="false">
            <div style="float: left; width: 100%; font-size: large; font-weight: bold;">You rematched them</div>
            <asp:Repeater ID="rptRematchedThem" runat="server">
                <ItemTemplate>
                    <div style="float: left; width: 168px; margin-left: 6px;">
                        <div style="float: left; width: 168px; border: 1px solid #ccc; text-align: center; padding-bottom: 4px; margin-top: 4px;">
                            <div style="float: left; width: 168px; min-height: 160px;">
                                <img id="imgMatchImage" runat="server" class="currentMatch"  visible="false" style="width: 160px; height: 160px; cursor: pointer; margin: 0 auto; border: 1px solid #000; border-radius: 6px 6px;" tabindex="0" />
                            </div>
                            <div id="divDate" runat="server" style="float: left; width: 168px; text-align: center; margin-top: 4px; font-weight: bold; font-family: Arial"></div>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div style="float: left; width: 100%; padding: 10px;" id="divRematchedYou" runat="server" visible="false">
            <div style="float: left; width: 100%; font-size: large; font-weight: bold;">They rematched you</div>
            <asp:Repeater ID="rptRematchedYou" runat="server">
                <ItemTemplate>
                    <div style="float: left; width: 168px; margin-left: 6px;">
                        <div style="float: left; width: 168px; border: 1px solid #ccc; text-align: center; padding-bottom: 4px; margin-top: 4px;">
                            <div style="float: left; width: 168px; min-height: 160px;">
                                <img id="imgMatchImage" runat="server" class="currentMatch"  visible="false" style="width: 160px; height: 160px; cursor: pointer; margin: 0 auto; border: 1px solid #000; border-radius: 6px 6px;" tabindex="0" />
                            </div>
                            <div id="divDate" runat="server" style="float: left; width: 168px; text-align: center; margin-top: 4px; font-weight: bold; font-family: Arial"></div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <div style="float: left; width: 100%; padding: 10px;margin-bottom:30px;" id="divPostMatchs" runat="server" visible="false">
            <div style="float: left; width: 100%; font-size: large; font-weight: bold;">Post matchs</div>
            <asp:Repeater ID="rptPostMathcs" runat="server">
                <ItemTemplate>
                    <div style="float: left; width: 168px; height: 230px; margin-left: 6px;">
                        <div style="float: left; width: 168px; border: 1px solid #ccc; text-align: center; padding-bottom: 4px; margin-top: 4px;">
                            <div id="divDate" runat="server" style="float: left; width: 168px; text-align: center; margin-top: 4px; font-weight: bold; font-family: Arial"></div>
                            <img id="imgMatchImage" runat="server" class="previousMatch" style="width: 160px; height: 160px; cursor: pointer; margin: 0 auto; border: 1px solid #000; border-radius: 6px 6px;" tabindex="0" />
                            <div id="divRematchedDate" runat="server" visible="false" style="float: left; width: 168px; text-align: center; margin-top: 4px; font-weight: bold; font-family: Arial"></div>
                            <div id="divRematchID" class="btnRematchUser" runat="server">
                                <input type="button" value="Rematch" id="btnRematchUser" class="BtnviewProfile" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
    <script type="text/javascript">

        $(document).ready(function () {
            $(".previousMatch").click(function () {
                var _ThisMatch = $(this).attr("alt");
                window.location.href = _SitePath + "web/MatchProfile?" + _ThisMatch;
            });


            $(".currentMatch").click(function () {
                var _ThisMatch = $(this).attr("alt");
                window.location.href = _SitePath + "web/Profile?" + _ThisMatch + "#criteria";
            });


            $(".btnRematchUser").click(function () {
                var _matchedID = $(this).data("id");
                //alert(_matchedID);
                var _rematchurl = _SitePath + "web/inner/rematchuser?RematchID=" + _matchedID;
                SetUrlIntelliWindow(_rematchurl, "620", "410");
            });


        });
    </script>




</asp:Content>


