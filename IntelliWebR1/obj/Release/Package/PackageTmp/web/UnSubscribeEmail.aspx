<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnSubscribeEmail.aspx.cs" Inherits="IntellidateR1Web.web.UnSubscribeEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="float:left;width:100%;margin-left:10px;">Email Notifications :<label style="padding-top:4px;"><input type="checkbox" id="chkSelectAll" />Check All</label></div>
            <label>
                <input type="checkbox" id="chkNewMessages" class="chkemail" value="1"/>New messages</label><br />
            <label>
                <input type="checkbox" id="chkDaily"  class="chkemail" value="2" />Daily top matches</label><br />
            <label>
                <input type="checkbox" id="chknotifications"  class="chkemail" value="3" />Other Intellidate notifications</label><br />
            <label>
                <input type="checkbox" id="chkFilterMessages"  class="chkemail" value="4" />Filter messages</label><br />
            <label>
                <input type="checkbox" id="chkPwdChange"  class="chkemail" value="5" />Password change information</label><br />
            <label>
                <input type="checkbox" id="chkWeeaklyMatchs"  class="chkemail" value="6" />All weeakly top matches</label><br />
              <input type="button" value="Save All" id="btnSaveAll"/>
        </div>

        <script type="text/javascript">

            $(document).ready(function () {

                $("#chkSelectAll").change(function () {
                    var IsSeleted = $(this).is(':checked');
                    if (IsSeleted) {
                        $(".chkemail").each(function () {
                            $(this).prop("checked", true);
                        });
                    } else {
                        $(".chkemail").each(function () {
                            $(this).prop("checked", false);
                        });
                    }
                });

                $(".chkemail").change(function () {

                    var _allChecked = true;
                    $(".chkemail").each(function (_pos, _obj) {
                        if ($(_obj).is(":checked") == false) {
                            _allChecked = false;

                        } else {

                        }
                    });

                    if (_allChecked) {
                        $("#chkSelectAll").prop("checked", true);
                    } else {
                        $("#chkSelectAll").prop("checked", false);
                    }


                });
              
                $("#btnSaveAll").click(function () {

                    var _selecdArray = new Array();
                    $(".chkemail").each(function (_pos, _obj) {
                        if ($(_obj).is(":checked") == true) {
                            _selecdArray.push($(_obj).val());
                        }
                    });
                   
                    //do back end save 


                });


            });




        </script>




    </form>
</body>
</html>
