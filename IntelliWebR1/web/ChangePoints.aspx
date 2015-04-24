<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="ChangePoints.aspx.cs" Inherits="IntelliWebR1.web.ChangePoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
     <asp:literal id="ltScripts" runat="server"></asp:literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">

    <div class="middle_content" style="width: 940px;margin:0 auto;">
        <div class="fourth">
            <div class="fourth_top">
                <div class="one_numbering">
                    <b id="Numberleft" runat="server"></b><span>of</span> <b id="NumberRight" runat="server"></b>
                </div>
                <div class="average">
                    <big>Available Points</big>
                    <small id="AvilablePoints" runat="server" class="smallPointsRemining"></small>
                    <span class="clear"></span>
                </div>
                <span class="clear"></span>
                <img src="images/01_line-shadow.jpg" height="1" alt="line" style="margin-top: 10px;" />
                <p>
                    Vivamus ultricies fermentum mattis. Cras vitae ex nibh. Aliquam facilisis, Cras vitae ex nibh. 
                         Aliquam facilisis, Cras vitae ex nibh. Aliquam facilisis,
                </p>

            </div>
            <div class="fourth_matter" id="divPoints" runat="server">
            </div>
            <div id="lblCriteriaError" style="text-align: center"></div>
            <span class="clear"></span>
            <div class="ButtonsArea">
                <input type="button" class="pointsNextButton" id="btnSubmit" value="Next" />
            </div>

        </div>
        <aside></aside>
        <span class="clear"></span>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {

            SetReminingPoints();


            $(".txtpoints").click(function () {
                var Value = $(this).val();
                if (Value == "0") {
                    $(this).val("");
                }
                SetReminingPoints();
            });
            $(".txtpoints").blur(function () {
                var Value = $(this).val();
                if (Value == "") {
                    $(this).val("0");
                }
                SetReminingPoints();
            });

            $('.txtpoints').keypress(function (e) {
                if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
                    $('#lblCriteriaError').html("Enter numbers only.").show();
                    return false;
                } else {
                    $('#lblCriteriaError').hide();
                }
            });

            $(".pointercss").click(function () {
                var Criteria_id = $(this).attr("id");
                var _EditCriteriaUrl = _SitePath + "web/inner/criteriaedit?c=" + Criteria_id;
                SetUrlIntelliWindow(_EditCriteriaUrl, 700, 400);
            });


            $("#btnSubmit").click(function () {

                //disale button
                $(".pointsNextButton").attr("disabled", "disabled");
                $(".pointsNextButton").css("background-color", "#999");

                // get allotted points
                var _pointsAssigned = GetAssignedPoints();

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

                var _assignPointsAPI = _SitePath + "api/CriteriaPoints";

                $.postDATA(_assignPointsAPI, _CriteriaPoints, function (_return) {
                        window.location.href = _SitePath + "web/Home";
                });


            });



        });


        function GetAssignedPoints() {
            var _pointsArray = new Array();
            var _pointObject = new Object();

            $(".txtpoints").each(function (_pos, _obj) {
                _pointObject = new Object();
                _pointObject.Criteria_id = $(_obj).data("criteriaid");
                _pointObject.PointsAssigned = $(_obj).val();
                _pointsArray.push(_pointObject);
            });

            return _pointsArray;
        }

        function SetReminingPoints() {


            var _points = 0;

            $('.txtpoints').each(function (i, obj) {
                var _eachPoints = eval($(obj).val());
                if (!isNaN(_eachPoints)) {
                    _points = eval(_points + _eachPoints);
                }
            });



            var _pointsLeft = eval(100 - _points);
            _pointsLeft = parseFloat(_pointsLeft.toPrecision(12));


            $(".smallPointsRemining").text(_pointsLeft);

            if (_pointsLeft == 0) {
                $(".pointsNextButton").removeAttr("disabled");
                $(".pointsNextButton").css("background-color", "#C1282D");
            } else {
                $(".pointsNextButton").attr("disabled", "disabled");
                $(".pointsNextButton").css("background-color", "#999");
            }

        }

        function SetUserAnswered(_criteriaid) {
            $("#txt" + _criteriaid).removeAttr("disabled");
            $("#txt" + _criteriaid).removeClass("Disabled");
        }
    </script>

</asp:Content>
