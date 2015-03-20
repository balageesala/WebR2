<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilecriteria.aspx.cs" Inherits="IntelliWebR1.web.inner.profilecriteria" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<style type="text/css">
    .paddingcss td {
        padding-top: 6px;
        padding-left: 6px;
    }

     .paddingcss tr {
        border-top: 1px solid #ffffff;
        border-left: 1px solid #ffffff;
        border-right: 1px solid #ffffff;
    }

    .paddingleft td {
        padding-left: 6px;
    }

    .paddingleft tr {
        border-bottom: 1px solid #000000;
        border-top: 1px solid #ffffff;
        border-left: 1px solid #ffffff;
        border-right: 1px solid #ffffff;
    }


    table{

        border-top: 1px solid #ffffff;
        border-left: 1px solid #ffffff;
        border-right: 1px solid #ffffff;
    }
</style>

<div style="margin: 0px; float: left;">
    <div style="font-family: Tahoma; font-size: 20px; display: none; font-weight: bold; margin-top: 30px;" id="lblMutualMatch" runat="server"></div>

    <div style="font-family: Tahoma; font-size: 14px; margin-top: 10px; width: 940px;">
        <asp:datagrid id="dgCriteriaTable" runat="server" cellpadding="4" cellspacing="4" gridlines="Horizontal" headerstyle-backcolor="#C1272D" headerstyle-forecolor="White" headerstyle-font-bold="false" autogeneratecolumns="false" onitemdatabound="dgCriteriaTable_ItemDataBound" width="98%">
            <HeaderStyle Height="22" Font-Bold="false" VerticalAlign="Bottom" CssClass="paddingcss" />
            <ItemStyle Height="20" CssClass="paddingleft"  />
            <Columns>
                <asp:BoundColumn DataField="CriteriaName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"  HeaderText="Category" ItemStyle-Width="240"></asp:BoundColumn>
                <asp:BoundColumn DataField="UserPreferences" HeaderText="Your Preference" ItemStyle-Width="240" ></asp:BoundColumn>
                <asp:BoundColumn DataField="OtherUserValue" HeaderText="Their Answer" ItemStyle-Width="240" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ></asp:BoundColumn>
                <asp:BoundColumn DataField="PointsAssigned" HeaderText="Assigned" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundColumn>
                <asp:BoundColumn DataField="PointsAwarded" HeaderText="Earned" ItemStyle-Width="55" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundColumn>
                <asp:BoundColumn DataField="IsMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HasAllPreferencesSelected" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="ShowMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="CriteriaType" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HideCriteriaInUserMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HideCriteriaInOtherUserMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HideOtherUserValue" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="MatchSuccessText" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="MatchFailText" Visible="false"></asp:BoundColumn>
            </Columns>
        </asp:datagrid>
    </div>
    <div style="font-family: Tahoma; font-size: 14px; margin-top: 20px; width: 940px;padding-bottom:30px;">
        <asp:datagrid id="dgOtherUserCriteriaTable" runat="server" cellpadding="4" cellspacing="4" gridlines="Horizontal" headerstyle-backcolor="#C1272D" headerstyle-forecolor="White" headerstyle-font-bold="false" autogeneratecolumns="false" onitemdatabound="dgOtherUserCriteriaTable_ItemDataBound" width="98%">
            <HeaderStyle Height="22" Font-Bold="false" CssClass="paddingcss" />
            <AlternatingItemStyle BackColor="White" Height="20" />
            <ItemStyle Height="20" CssClass="paddingleft" />
            <Columns>
                <asp:BoundColumn DataField="CriteriaName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="240" HeaderText="Category"></asp:BoundColumn>
                <asp:BoundColumn DataField="UserPreferences" HeaderText="Their Preference" ItemStyle-Width="240" ></asp:BoundColumn>
                <asp:BoundColumn DataField="OtherUserValue" HeaderText="Your Answer" ItemStyle-Width="240" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ></asp:BoundColumn>
                <asp:BoundColumn DataField="PointsAssigned" HeaderText="Assigned" ItemStyle-Width="70" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"></asp:BoundColumn>
                <asp:BoundColumn DataField="PointsAwarded" HeaderText="Earned" ItemStyle-Width="55" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"  ></asp:BoundColumn>
                <asp:BoundColumn DataField="IsMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HasAllPreferencesSelected" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="ShowMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HideCriteriaInUserMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HideCriteriaInOtherUserMatch" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="HideOtherUserValue" Visible="false"></asp:BoundColumn>
                <asp:BoundColumn DataField="Criteria_id" Visible="false"></asp:BoundColumn>
            </Columns>
        </asp:datagrid>
    </div>
</div>

<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>
