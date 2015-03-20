<%@ Page Title="" Language="C#" MasterPageFile="~/web/Intellidate.Master" AutoEventWireup="true" CodeBehind="SubscribeNow.aspx.cs" Inherits="IntellidateR1Web.web.SubscribeNow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <label>
            <input type="radio" name="radiogroup" value="1" />Top subcription 17$ per  30 days
        </label>
    </div>
    <div>
        <label>
            <input type="radio" name="radiogroup" value="2" />Basic subcription 11$ per 30 days
        </label>
    </div>
    <div>
        <select id="ddlDays">
            <option value="0">Select Days</option>
            <option value="30">30 Days</option>
            <option value="60">60 Days</option>
            <option value="90">90 Days</option>
            <option value="120">120 Days</option>
            <option value="150">150 Days</option>
            <option value="180">180 Days</option>
        </select>
    </div>
    <div>
        <input type="button" value="Pay" id="btnPay" />
    </div>
    <div id="divMessage"></div>
    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnPay").click(function () {
                var _SelectedValue = $("input[name=radiogroup]:checked").val();
                var _SelectedDays = $("#ddlDays").val();
                var _checkRadioButton = $("input[name=radiogroup]:checked").length;
                if (_checkRadioButton > 0 && _SelectedMounths != "0") {
                    $("#divMessage").html("");
                    var _IntelliUrl = _SitePath + "web/inner/confirmsubscription?type=" + _SelectedValue + "&days=" + _SelectedDays;
                    SetUrlIntelliWindow(_IntelliUrl, 640, 330);
                } else {
                    if (_checkRadioButton == 0) {
                        $("#divMessage").html("Plese select subscription type.");
                    } if (_SelectedMounths == "0") {
                        $("#divMessage").html("Plese select subscription mounths.");
                    }
                }
            });

            });
    </script>


</asp:Content>
