<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportprofile.aspx.cs" Inherits="IntelliWebR1.web.inner.reportprofile" %>

 <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
 <script src="../../Scripts/js_fun.js"></script>

<style>
    .button {
        padding: 4px 8px;
        border-radius: 3px;
        background-color: #C1282D;
        font-size: 0.85em;
        font-weight: 400;
        letter-spacing: 1px;
        color: #fff;
        text-align: center;
        border: none;
        cursor: pointer;
    }


</style>


 <div style="width: 510px; height: 250px; background-color: #fff; font-family: Arial; font-size: 14px;border-radius:6px 6px;">
     <div style="float:right;cursor:pointer;">
         <img src="../images/close.png" id="btnClose"/>
     </div>

            <div style="font-weight: bold; padding: 10px;" id="divTitle">Report this user</div>
            <div style="float: left; width: 120px;margin-left:20px;">
                <img id="imgPhoto" style="width:100px;height:100px; margin: 4px;" />
            </div>
            <div style="float: left;">
                <div style="padding: 10px;">
                    <div id="divReport">
                    <div>
                        <input type="radio" id="rdoOption_Reason1" value="1" checked="checked" name="rdoOption" /><label for="rdoOption_Reason1">Reason 1</label>
                    </div>
                    <div>
                        <input type="radio" id="rdoOption_Reason2" value="2" name="rdoOption" /><label for="rdoOption_Reason2">Reason 2</label>
                    </div>
                    <div>
                        <input type="radio" id="rdoOption_Reason3" value="3" name="rdoOption" /><label for="rdoOption_Reason3">Reason 3</label>
                    </div>
                    <div>
                        <input type="radio" id="rdoOption_Other" value="4" name="rdoOption" /><label for="rdoOption_Other">Other</label>
                    </div>
                    <div style="margin-top: 10px;">
                        <textarea id="txtComment" placeholder="Please enter your comments" style="resize: none; font-family: Arial; font-size: 14px; width: 320px; height: 60px;"></textarea>
                    </div>
                    <div style="margin-top: 4px;" id="divButtons" runat="server">
                        <div>
                            <input type="button" id="btnReport" value="Report" class="button" />
                        </div>
                    </div>
                        </div>
                    <div style="margin-top: 60px;font-weight: bold;color: red;text-align: center;width: 500px;" id="divAlreadyReported" >
                        You have already reported this user.
                    </div>
                    <div style="clear: both;"></div>
                    <div id="lblMessage" style="margin-top: 10px;">
                        You have successfully reported this user.
                    </div>
                </div>
            </div>

        </div>
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
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
                $("#imgPhoto").hide();
                $("#divTitle").hide();
            } else {
                $("#divTitle").show();
                $("#divAlreadyReported").hide();
                $("#divReport").show();
                var _ImageUrl = $(window.parent.document).find(".OtherProfilePic").attr("src");
                $("#imgPhoto").show();
                $("#imgPhoto").attr("src", _ImageUrl);
            }

        });

    });

</script>