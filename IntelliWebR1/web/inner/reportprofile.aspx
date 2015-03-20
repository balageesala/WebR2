<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportprofile.aspx.cs" Inherits="IntelliWebR1.web.inner.reportprofile" %>

<!DOCTYPE html>

 <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
 <asp:Literal ID="ltScripts" runat="server"></asp:Literal>

<div class="reportuser">
    	<a style="cursor:pointer;" class="close" id="btnClose">x</a>
        <span class="clear"></span>
        <div class="reportuser_cont">
        	<h3>Report this user</h3>
            <div class="match_detail">
                <img id="imgPhoto" runat="server" width="99" height="116"  />
                <div class="match_detail_type" id="divReport">
                <ul>
                	<li><input type="radio" id="rdoOption_Reason1" value="1" checked="checked" name="rdoOption" /><label for="rdoOption_Reason1">Reason 1</label></li>
                    <li><input type="radio" id="rdoOption_Reason2" value="2" name="rdoOption" /><label for="rdoOption_Reason2">Reason 2</label></li>
                    <li><input type="radio" id="rdoOption_Reason3" value="3" name="rdoOption" /><label for="rdoOption_Reason3">Reason 3</label></li>
                    <li> <input type="radio" id="rdoOption_Other" value="4" name="rdoOption" /><label for="rdoOption_Other">Other</label></li>
                    <li>
                        <textarea id="txtComment" rows="3" cols="40" placeholder="Please enter your comments"></textarea>
                    </li>
                </ul>
                </div>

                 <div style="margin-top: 60px;" id="divAlreadyReported" >
                        You have already reported this user.
                    </div>

                <span class="clear"></span>
               
            </div>
        </div>
      <div id="lblMessage" style="margin-top: 10px;margin-bottom:10px; margin-left: 30px;">
                        You have successfully reported this user.
                    </div>
        <input type="button" class="send" id="btnReport" value="Report"/>
        <span class="clear"></span>
    </div>
      
        <script type="text/javascript">
            $(document).ready(function () {
               

                $("#lblMessage").hide();
                $("#btnClose").click(function () {
                    window.parent.CloseIntelliWindow();
                });

                $("#btnReport").click(function () {
                    $("#btnReport").prop("disabled", true);
                    $("#btnReport").val("Please wait...");

                    var _ReportUserObj = new Object();
                    _ReportUserObj.ReportedUserID = window.parent._OtherUserID;
                    _ReportUserObj.ReportType = $("input[name*='rdoOption']").val();
                    _ReportUserObj.Comment = $("#txtComment").val();

                    var _ReportUserAPI = window.parent._SitePath + "api/ReportUserProfile";

                    $.postDATA(_ReportUserAPI, _ReportUserObj, function (_ret) {
                        $("#btnReport").hide();
                        $("#lblMessage").show();
                    });
                });

            });
        </script>

<script type="text/javascript">

    $(document).ready(function () {

       

        var SESSION_API = window.parent._SitePath + "api/SessionCheck";
        $.getDATA(SESSION_API, function (_IsOnline) {
            if (!_IsOnline) {
                window.location.href = _SitePath + "web/LogOut";
                window.parent.CloseIntelliWindow();
            } else {
                return true;
            }
        }, function () { });


        var _HasReportedUserAPI = window.parent._SitePath + "api/HasUserReportedAlready";
        var _OtherUserObject = new Object();
        _OtherUserObject.OtherUserID = window.parent._OtherUserID;

        $.postDATA(_HasReportedUserAPI, _OtherUserObject, function (_ret) {
            if (_ret) {
                $("#divAlreadyReported").show();
                $("#divReport").hide();
                $("#btnReport").hide();
                $("#imgPhoto").hide();
                $("#divTitle").hide();
            } else {
                $("#divTitle").show();
                $("#divAlreadyReported").hide();
                $("#divReport").show();
                $("#imgPhoto").show();
               
            }

        });

    });

</script>