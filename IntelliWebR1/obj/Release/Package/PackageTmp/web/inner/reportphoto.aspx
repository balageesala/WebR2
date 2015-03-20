<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reportphoto.aspx.cs" Inherits="IntelliWebR1.web.inner.reportphoto" %>

 <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
 <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
 <div>
        <div style="width: 680px; min-height: 320px; background-color: #fff; font-family: Arial; font-size: 14px;border-radius:6px 6px;">
             <div style="float: right;">
             <img src="../images/close.png" class="imgClose"  style="cursor:pointer;" />
              </div>
            <div style="font-weight: bold; padding: 10px;">Report Photo</div>
            <div style="float: left; width: 300px;">
                <img id="imgPhoto" runat="server" style="max-width: 300px; max-height: 250px; margin-left:10px;" />
            </div>
            <div style="float: left;">
                <div style="padding: 10px;">
                    <div id="divOptions" runat="server">
                    <div>
                        <input type="radio" id="rdoOption_Offensive" value="1" checked="checked" name="rdoOption" /><label for="rdoOption_Offensive">Offensive Material</label>
                    </div>
                    <div>
                        <input type="radio" id="rdoOption_Nudity" value="2" name="rdoOption" /><label for="rdoOption_Nudity">Contains Nudity</label>
                    </div>
                    <div>
                        <input type="radio" id="rdoOption_Celebrity" value="3" name="rdoOption" /><label for="rdoOption_Celebrity">Celebrity Photo</label>
                    </div>
                    <div>
                        <input type="radio" id="rdoOption_Other" value="4" name="rdoOption" /><label for="rdoOption_Other">Other</label>
                    </div>
                    <div style="margin-top: 10px;">
                        <textarea id="txtComment" placeholder="Please enter your comments" style="resize: none; font-family: Arial; font-size: 14px; width: 320px; height: 60px;"></textarea>
                    </div>
                    <div style="margin-top: 4px;">
                        <div>
                            <input type="button" id="btnReport" value="Report" />
                        </div>
                    </div>
                        </div>
                    <div style="margin-top: 4px; font-weight: bold; color: red;" id="divAlreadyReported" runat="server" visible="false">
                        You have already reported this photo.
                    </div>
                    <div style="clear: both;"></div>
                    <div id="lblMessage" style="margin-top: 10px;">
                        You have successfully reported this photo.
                    </div>
                </div>
            </div>

        </div>
      
        <script type="text/javascript">
            $(document).ready(function () {
                $("#divButtonsConfirm").hide();
                $("#lblMessage").hide();
                $("input[name*='rdoOption']").click(function () {
                    //
                });

                $("#btnReport").click(function () {
                    $("#btnReport").prop("disabled", true);
                    $("#btnReport").val("Please wait...");
                    var _ReportPhotoObj = new Object();
                    _ReportPhotoObj.PhotoID = _PhotoID;
                    _ReportPhotoObj.PhotoUserID = window.parent._OtherUserID;
                    _ReportPhotoObj.ReportType = $("input[name*='rdoOption']:checked").val();
                    _ReportPhotoObj.Comment = $("#txtComment").val();

                    var _ReportPhotoAPI = _SitePath + "api/ReportPhoto";

                    $.postDATA(_ReportPhotoAPI, _ReportPhotoObj, function () {
                        $("#btnReport").hide();
                        $("#lblMessage").show();
                    });
                });


                $(".imgClose").click(function () {
                    window.parent.CloseIntelliWindow();
                });


            });
  </script>
</div>