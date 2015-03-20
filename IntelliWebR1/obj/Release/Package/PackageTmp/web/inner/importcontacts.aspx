<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="importcontacts.aspx.cs" Inherits="IntelliWebR1.web.inner.importcontacts" %>


<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<style type="text/css">
    .textField {
        width: 230px;
        font-size: 14px;
    }

    .fields {
        margin: 8px;
        margin-top: 10px;
    }

        .fields div {
            float: left;
            margin-right: 4px;
        }

            .fields div select {
                border: 0px;
                font-size: 16px;
                height: 28px;
                border-radius: 2px 2px;
                width: 93px;
            }


        .fields input {
            border: 0px;
            font-size: 14px;
            width: 280px;
            height: 28px;
            border-radius: 2px 2px;
            padding: 4px;
        }

    .submitContact {
        padding: 8px 28px;
        border-radius: 3px;
        background-color: #c1272d;
        height: 34px;
        font-size: 0.9em;
        font-weight: 400;
        letter-spacing: 1px;
        color: #fff;
        text-align: center;
        border: none;
        cursor: pointer;
    }
</style>
<form runat="server">

    <div style="width: 600px; border: 0px solid #ccc; margin: 0 auto; border-radius: 2px 4px;">
        <div style="float: left; width: 100%; padding-top: 10px;">
            <div style="float: right;">
                <img src="../images/close.png" class="imgClose" style="cursor: pointer;" />
            </div>
        </div>

        <div>
            <div style="float: left; width: 100%;">
                <div class="fields">Import contacts</div>
                <div style="padding: 4px; border: 1px solid #ccc; margin-top: 10px; border-radius: 6px 6px;">
                    <div class="fields">
                        <select runat="server" id="ddlOptions">
                            <option value="0">Select..</option>
                            <option value="1">G-Mail</option>
                            <option value="2">Yahoo</option>
                            <option value="3">Facebook</option>
                            <option value="4">Hotmail or outlook.com</option>
                        </select>
                    </div>
                    <div class="fields" id="divBrowseCsv">
                        <input type="file" id="browseExcel" runat="server" accept=".csv" />
                    </div>
                    <div class="fields" id="divFaceBook">
                        <input type="button" id="FBLogin" value="Login to Facebook" class="submitContact" />
                    </div>
                    <div class="fields" id="divSubmit">
                        <input type="button" id="btnAddContact" class="submitContact" value="Submit" runat="server" onserverclick="btnAddContact_ServerClick" />
                    </div>
                </div>
            </div>

            <div id="lblMessageResponse" runat="server" style="min-height: 20px; float: left; font-family: Arial; font-size: 14px; color: #000; font-weight: bold; margin-left: 20px; padding-top: 10px;">
            </div>

            <div id="divExistingContacts" runat="server">

                <div style="float: left; width: 100%; margin-left: 6px;">Existing Contacts</div>
                <div>
                     <div style="float: left; width: 100%; border: 1px solid #ccc; text-align: center; padding-bottom: 4px; margin-top: 4px;height:220px;overflow-y:auto;">
                <asp:repeater id="rptContacts" runat="server">
                <ItemTemplate>
                    <div style="float: left; width: 99%; margin-left: 6px;" id="DivContactID" runat="server">
                            <div id="DivContactEmail" runat="server" style="float: left; width: 82%; text-align: left; margin-top: 4px; font-weight: bold; font-family: Arial;padding-left: 4px;"></div>
                            <div style="float: right;margin-top:4px;">
  
                                <input type="button" id="btnDelete" class="DivDelete" value="Delete" runat="server" />
                            </div>
                        </div>
                 
                </ItemTemplate>
              
              </asp:repeater>
                         </div>
                </div>
            </div>
        </div>






        <script type="text/javascript">


            $(document).ready(function () {
                window.fbAsyncInit = function () {
                    FB.init({ appId: '364688787022470', cookie: true, status: true, xfbml: true, oauth: true });
                };
                (function (d) {
                    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
                    if (d.getElementById(id)) { return; }
                    js = d.createElement('script'); js.id = id; js.async = true;
                    js.src = "//connect.facebook.net/en_US/all.js";
                    ref.parentNode.insertBefore(js, ref);
                }(document));


                $("#FBLogin").click(function (e) {
                    e.preventDefault();
                    FB.login(function (response) {
                        if (response.authResponse) {
                            FB.api('/me/friends', function (response) {
                                alert(JSON.stringify(response));
                            });

                        } else {
                            $("#lblMessageResponse").html("Not logged in");
                        }
                    }, { scope: 'user_friends', auth_type: 'rerequest' });

                });

                logActivity = function (message) {

                };

            });



            $(document).ready(function () {

                $("#divBrowseCsv").show();
                $("#divSubmit").show();
                $("#divFaceBook").hide();

                $(".imgClose").click(function () {
                    window.parent.CloseIntelliWindow();
                });

                $("#ddlOptions").change(function () {

                    var _SelectedValue = $("#ddlOptions").val();
                    if (_SelectedValue == "3") {
                        $("#divFaceBook").show();
                        $("#divBrowseCsv").hide();
                        $("#divSubmit").hide();
                    } else {
                        $("#divBrowseCsv").show();
                        $("#divSubmit").show();
                        $("#divFaceBook").hide();
                    }

                });

                $(".DivDelete").click(function () {
                    var _ChildDiv = $(this).closest("div");
                    var _RemoveDiv = $(_ChildDiv).parent("div");
                    var _ContactID = $(_RemoveDiv).data("id");
                    //alert(_ContactID);
                    var _postContactApi = _SitePath + "api/DeleteUserContact";
                    var _ContactObject = new Object();
                    _ContactObject.ContactID = _ContactID;
                    $.postDATA(_postContactApi, _ContactObject, function () {
                        $(_RemoveDiv).remove();
                    });
                });

            });

        </script>

    </div>
</form>
