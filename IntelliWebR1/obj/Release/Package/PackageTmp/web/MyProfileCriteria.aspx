<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MyProfileCriteria.aspx.cs" Inherits="IntelliWebR1.web.MyProfileCriteria" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>
<%@ Register Src="~/web/ko/template_myprofilecriteria.ascx" TagPrefix="uc1" TagName="template_myprofilecriteria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <style type="text/css">
        .editCriteria {
            cursor: pointer;
        }

        .Disabled {
            background-color: #999;
        }
        .CriteriaPointsRed{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="ninth">
                <div class="person">
                    <img src="images/person.jpg" width="110" height="108" alt="person" />
                </div>
                <div class="tab_nav ninth_top_right">
                    <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
                    <div class="ninth_field">
                        <span>Points remaining</span>
                        <input type="text" id="txtPointsLeft"  />
                        <input type="button" class="SubmitButton" id="btnUpdate" value="Update" disabled="disabled" />
                        <div id="divPointsResult"></div>
                    </div>
                </div>
                <span class="clear"></span>
                <uc1:template_myprofilecriteria runat="server" ID="template_myprofilecriteria" />
                <div class="ninth_cont" id="divMyProfileCriteria" data-bind="template: { name: 'template_myprofilecriteria' }"></div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>

    <script type="text/javascript">


        $(document).ready(function () {

            $("#liCriteria").addClass("active");
            DesableUpdateButton();
            var APIGET_CRITERIA = _SitePath + "api/GetMyProfileCriteriaList";

            $.getDATA(APIGET_CRITERIA, function (_data) {

                // alert(JSON.stringify(_data));

                //  points assigned
                var _pointsAssigned = 0;
                for (var i = 0; i < _data.length; i++) {
                    _pointsAssigned =eval(_pointsAssigned + _data[i].UserAssignedPoints);
                }
                $("#txtPointsLeft").val(_pointsAssigned);
                ko.applyBindings(new VMMyProfileCriteriaList(_data), document.getElementById("divMyProfileCriteria"));

                setTimeout(function () {
                    $(".points").click(function () {
                        if ($(this).val() == "0") {
                            $(this).val("");
                        }
                        else {
                            $(this).select();
                        }
                    });

                    SetReminingPointsLeft();

                    $(".editCriteria").click(function (e) {
                        SetIntelliWindow(this, e);
                    });

                }, 1000);

            });


            $("#btnUpdate").click(function () {

                DesableUpdateButton();
                $("#btnUpdate").val("Please wait..");
                // get allotted points
                var _pointsAssigned = GetAssignedPoints();
                //console.log(_pointsAssigned);

                var _QuestionIDs = new Array();
                var _Points = new Array();

                for (var i = 0; i < _pointsAssigned.length; i++) {
                    _QuestionIDs.push(_pointsAssigned[i].Criteria_id);
                    _Points.push(_pointsAssigned[i].PointsAssigned);
                }

                var _CriteriaPoints = new Object();

                var _sQuestionIDs = "";
                for (var i = 0; i < _QuestionIDs.length; i++) {
                    _sQuestionIDs = _sQuestionIDs + "," + _QuestionIDs[i];
                }
                _sQuestionIDs = _sQuestionIDs.substr(1);

                var _sPoints = "";
                for (var i = 0; i < _Points.length; i++) {
                    _sPoints = _sPoints + "," + _Points[i];
                }
                _sPoints = _sPoints.substr(1);

                _CriteriaPoints.CriteriaQuestionIDs = _sQuestionIDs;
                _CriteriaPoints.Points = _sPoints;

                //console.log(_CriteriaPoints);

                var _assignPointsAPI = _SitePath + "api/CriteriaPoints";
                $.postDATA(_assignPointsAPI, _CriteriaPoints, function (_return) {
                    $("#divPointsResult").html("Points assigned successfully.");
                    $("#btnUpdate").val("Update");
                });
            });


        });

        function GetAssignedPoints() {
            var _pointsArray = new Array();
            var _pointObject = new Object();

            $(".points").each(function (_pos, _obj) {
                _pointObject = new Object();
                _pointObject.Criteria_id = $(_obj).data("criteriaid");
                _pointObject.PointsAssigned = $(_obj).val();
                _pointsArray.push(_pointObject);
            });

            return _pointsArray;
        }


        function EnableUpdateButton() {
            $("#btnUpdate").removeAttr("disabled");
            $("#btnUpdate").css("background", "#c1292d");
        }

        function DesableUpdateButton() {
            $("#btnUpdate").attr("disabled", "disabled");
            $("#btnUpdate").css("background", "#999");
        }

        function SetRemainingPoints() {
            var _points = 0;
            $('.points').each(function (i, obj) {
                _points = _points + eval($(obj).val());
            });
            var _pointsLeft = 100 - eval(_points);
            _pointsLeft = Math.round(_pointsLeft * 100) / 100

            $("#txtPointsLeft").val(_pointsLeft);

            if (eval(_pointsLeft) != 0) {
                DesableUpdateButton();
            }
            else {
                EnableUpdateButton();
            }
            return _points;
        }

        function SetReminingPointsLeft() {
            $(".points").blur(function () {
                if ($(this).val() == "") {
                    $(this).val("0");
                }

                var _valueEntered = $(this).val();

                if (isNaN(_valueEntered)) {                  
                    $("#divPointsResult").html("Please enter nubers only.");
                    $(this).focus();
                    $(this).val("0");
                }
                else {
                    if (eval(_valueEntered) > 100) {
                        $(this).val("100");
                    }
                }
                var _remainingPoints = SetRemainingPoints();

                if (_remainingPoints < 0) {
                    $("#txtPointsLeft").addClass("CriteriaPointsRed");
                }
                else {
                    $("#txtPointsLeft").removeClass("CriteriaPointsRed");
                }
            });
        }


    </script>



</asp:Content>
