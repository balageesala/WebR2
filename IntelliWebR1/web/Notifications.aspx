<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="IntelliWebR1.web.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
		<div class="middle_content">
    	<div class="notification">
            <div class="back_btn" style="height:40px;">
                &nbsp;
                <span class="clear"></span>
            </div>
            <div class="notification_cont" id="DivNotifications" runat="server" style="padding-bottom:30px;">
            </div>
        </div>
    
   <aside></aside>
    <span class="clear"></span>
    </div>
         <aside></aside>
    <span class="clear"></span>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#btnDeleteAll").hide();

            $("#chkSelectAll").click(function () {
                var IsSeleted = $(this).is(':checked');
                if (IsSeleted) {
                    $(".chknotis").each(function () {
                        $(this).prop("checked", true);
                    });
                    $("#btnDeleteAll").show();
                } else {
                    $(".chknotis").each(function () {
                        $(this).prop("checked", false);
                    });
                    $("#btnDeleteAll").hide();
                }
            });

            $(".chknotis").change(function () {

                var _allChecked = true;
                var _isAnyOne = false;
                $(".chknotis").each(function (_pos, _obj) {
                    if ($(_obj).is(":checked") == false) {
                        _allChecked = false;

                    }
                    if ($(_obj).is(":checked") == true) {
                        _isAnyOne = true;
                    }
                });

                if (_allChecked) {
                    $("#chkSelectAll").prop("checked", true);
                } else {
                    $("#chkSelectAll").prop("checked", false);
                }

                if (_isAnyOne) {
                    $("#btnDeleteAll").show();
                } else {
                    $("#btnDeleteAll").hide();
                }


            });




            $(".imgDelete").click(function () {
                var _notiId = $(this).attr("alt");
                var _ApiDeleteNoti = _SitePath + "Api/DeleteNotification";
                var _NotiObject = new Object();
                _NotiObject.NotificationID = _notiId;
                $.postDATA(_ApiDeleteNoti, _NotiObject, function (_res) {
                    if (_res) {
                        $(".div" + _notiId).remove();
                    }
                });
            });


            $("#btnDeleteAll").click(function () {

                $(".chknotis").each(function (_pos, _obj) {
                    if ($(_obj).is(":checked") == true) {
                        var _notiId = $(_obj).data("id");
                        var _ApiDeleteNoti = _SitePath + "Api/DeleteNotification";
                        var _NotiObject = new Object();
                        _NotiObject.NotificationID = _notiId;
                        $.postDATA(_ApiDeleteNoti, _NotiObject, function (_res) {
                            if (_res) {
                                $(".div" + _notiId).remove();
                            }
                        });
                    }
                });

            });



        });
    </script>

</asp:Content>
