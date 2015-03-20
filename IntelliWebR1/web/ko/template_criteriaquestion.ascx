<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_criteriaquestion.ascx.cs" Inherits="IntelliWebR1.web.ko.template_criteriaquestion" %>
<script type="text/html" id="template_criteriaquestion">
    <div data-bind="attr: { id: _id }" class="displayNone">
        <!--ko if:ShowThisQuestion-->
        <div class="gradientGrey CriteriaGradientBox" data-bind="attr: { id: QuestionDivID }">
            <div style="float: left; width: 100%;height:44px;">
                <div style="float: left; width: 40%;">
                    <!--ko if:ShowBackButton-->
                    <div>                      
                     <img src="images/back_btn.png" alt="back" style="margin-left: -50px;height: 38px;" data-bind="event: { click: BackClick }" />                     
                    </div>
                    <!--/ko-->
                    <!--ko ifnot:ShowBackButton-->
                    &nbsp;
                <!--/ko-->
                </div>
                <div style="float: left; width: 60%;">
                    <div class="CriteriaPositionBox">
                        <div class="CriteriaPositionBoxInner">
                            <div class="CriteriaPositionBoxCricle">
                                <div class="CriteriaPositionBoxText" data-bind="text: Index"></div>
                            </div>
                        </div>
                        <div class="CriteriaPositionBoxOfText">of</div>
                        <div class="CriteriaPositionBoxInner">
                            <div class="CriteriaPositionBoxCricle">
                                <div class="CriteriaPositionBoxText" data-bind="text: (TotalCount()+2)"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="CriteriaDividerLine gradientLine"><img src="images/01_line-shadow.jpg" alt="line" style="width:562px;"></div>
           <div  style="width: 90%; margin:0 auto;clear:both;margin-top:64px;" data-bind="text: Instruction">          
           </div>
             <section>
                <div class="CriteriaSection" data-bind="attr: { id: 'ent' + _id }, animate: position()">
                <div>
                    <div class="QuestionText" data-bind="text: CriteriaName"></div>
                </div>
                <div class="QuestionArea" style="border: 0px solid; float: left;">
                    <div style="padding-left: 4px;float: left;width:100%;padding-bottom:10px;font-size: 14px;color: #2d2929;font-weight: 600;" data-bind="text: QuestionName"></div>
                    <div class="SelectionArea">
                        <div class="SelectionQuestion"  style="padding-left: 4px;font-size: 14px;color: #2d2929;font-weight: 600;font-family: 'Open Sans', sans-serif; margin: 0 0 15px 0;" data-bind="text: CriteriaQuestion"></div>
                        <div class="SelectionQuestion SelectionQuestionMargins">
                            <!--ko if:CriteriaType()=='1'-->
                            <!--ko foreach:CriteriaOptions-->
                            <div style="padding: 4px;padding-left: 0px;">
                                <input type="radio" data-bind="attr: { id: OptionCheckID, value: _id }" class="criteriaOptions" name="criteriaOptions" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label>
                            </div>
                            <!--/ko-->
                            <!--/ko-->

                            <!--ko if:CriteriaType()=='2'-->
                            <!--ko foreach:CriteriaOptions-->
                            <div style="padding: 4px;padding-left: 0px;">
                                <input type="checkbox" data-bind="attr: { id: OptionCheckID, value: _id }" class="criteriaOptions" name="criteriaOptions" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label>
                            </div>
                            <!--/ko-->
                            <!--/ko-->
                            <!--ko if:CriteriaType()=='7'-->
                            <div style="float: left;">
                                <select class="two_dates Month" data-bind="event: { change: CheckSubmitDisable }">
                                    <asp:Literal ID="ltMonths" runat="server"></asp:Literal>
                                </select>
                            </div>
                            <div style="float: left;margin-left:10px;" >
                                <select class="two_dates Day" data-bind="event: { change: CheckSubmitDisable }">
                                    <asp:Literal ID="ltDays" runat="server"></asp:Literal>
                                </select>
                            </div>
                            <div style="float: left;margin-left:10px;">
                                <select class="two_dates Year" data-bind="event: { change: CheckSubmitDisable }">
                                    <asp:Literal ID="ltYears" runat="server"></asp:Literal>
                                </select>
                            </div>
                            <div id="lblCriteriaDobError"></div>
                            <!--/ko-->

                            <!--ko if:CriteriaType()=='8'-->
                            <div style="padding: 4px; font-size: 14px;">
                                <input type="text" id="txtSalary" class="CriteriatextField" placeholder="$8888" maxlength="10" />
                            </div>
                            <div id="lblCriteriaSalaryError"></div>
                            <!--/ko-->

                            <!--ko if:CriteriaType()=='9'-->
                            <div style="padding: 4px; font-size: 14px;">
                                <input type="text" id="txtZipCode" class="CriteriatextField" maxlength="5" placeholder="Zipcode" />
                            </div>
                            <div id="lblCriteriaZipCodeError"></div>
                            <!--/ko-->
                        </div>
                    </div>
                    <div class="SelectionArea">
                        <!--ko if:ShowPartTwo-->
                        <div class="SelectionQuestion" style="padding-left: 4px;font-size: 14px;color: #2d2929;font-weight: 600;font-family: 'Open Sans', sans-serif; margin: 0 0 15px 0;" data-bind="text: CriteriaPreferenceQuestion"></div>
                        <div class="SelectionQuestion SelectionQuestionMargins">

                            <!--ko if: CriteriaPreferenceType()=='1'-->
                            <!--ko foreach:CriteriaPreferenceOptions-->
                            <div style="padding: 4px; padding-left: 0px;">
                                <input type="checkbox" data-bind="attr: { id: OptionPrefCheckID, value: _id }" class="criteriaPrefOptions" name="criteriaPrefOptions" /><label data-bind="    attr: { 'for': OptionPrefCheckID }, text: OptionText"></label>
                            </div>
                            <!--/ko-->
                            <!--ko if:PreferenceSelectAllTextEnable_One-->
                            <div style="padding: 4px; padding-left: 0px;">
                                <input type="checkbox" id="chkSelectAll" /><label for="chkSelectAll" data-bind="text: PreferenceSelectAllText_One"></label>
                            </div>
                            <!--/ko-->
                            <!--/ko-->

                            <!--ko if:CriteriaPreferenceType()=='3'-->
                            <div style="float: left;">
                                <select class="two_dates SelectOptionsOne" data-bind="event: { change: CheckSubmitDisable }">
                                    <option selected class="selectOption" value="0">From </option>
                                    <!--ko foreach:CriteriaPreferenceOptions_One-->
                                    <option class="selectOption" data-bind="attr: { value: _id }, text: OptionText"></option>
                                    <!--/ko-->
                                </select>
                            </div>
                            <div style="float: left;margin-left:10px;">
                                <select class="two_dates SelectOptionsTwo" data-bind="event: { change: CheckSubmitDisable }">
                                    <option selected class="selectOption" value="0">To </option>
                                    <!--ko foreach:CriteriaPreferenceOptions_Two-->
                                    <option class="selectOption" data-bind="attr: { value: _id }, text: OptionText"></option>
                                    <!--/ko-->
                                </select>
                            </div>
                            <!--/ko-->
                            <!--ko if:CriteriaPreferenceType()=='4'-->
                            <!--ko if:CriteriaType()=='9'-->
                            <div style="padding: 4px;">
                                <input type="text" id="txtDistanceRange" class="clsDistanceRange CriteriatextField" style="width:140px;"  maxlength="9" placeholder="Distance in miles" />
                            </div>
                            <div id="lblCriteriaDistanceeError"></div>
                            <!--/ko-->

                            <!--ko ifnot:CriteriaType()=='9'-->
                            <div style="float: left;">
                                <input type="text" id="txtSalaryFrom" class="CriteriatextField" maxlength="10" placeholder="$88888" />
                            </div>
                            <div style="float: left;color: #6b6969;font-size: 16px;font-weight: 400;padding: 1px 12px;">&nbsp; To &nbsp; </div>
                            <div style="float: left;">
                                <input type="text" id="txtSalaryTo" class="CriteriatextField" maxlength="10"  placeholder="$88888" />
                            </div>
   
                            <!--/ko-->
                            <!--/ko-->
                        </div>
                        <!--/ko-->
                    </div>
                </div>
                </div>
            </section>
        </div>
        <div style="clear: both;"></div>
        <div class="ButtonsArea">
            <div class="SubmitButton FloatRight Disabled" id="btnSubmit" tabindex="0" data-bind="event: { click: SubmitClick }">
                <div>Next</div>
            </div>
            <!--ko if:ShowSkipButton-->
            <div class="BackButton FloatRight" tabindex="0" id="btnSkip" data-bind="event: { click: SkipClick }">
                <div>Skip</div>
            </div>
            <!--/ko-->
        </div>
        <!--/ko-->
    </div>
</script>
<script type="text/javascript">
    $(document).ready(function () {
        $.getDATA(_SitePath + "api/GetCriteriaList", function (_return) {
            ko.applyBindings(new VMCriteriaQuestionList(_return), document.getElementById("divCriteriaQuetion"));

            $(document).keydown(function (e) {
                if (e.keyCode == 13) {
                    //check foucs button
                    var _submitFacus = $("#btnSubmit").is(":focus");
                    var _skipFacus = $("#btnSkip").is(":focus");
                    if (_submitFacus) {
                        var isBtnDisabled = $("#btnSubmit").hasClass('Disabled');
                        if (!isBtnDisabled) {
                            $("#btnSubmit").trigger("click");
                        }
                    }
                    if (_skipFacus) {
                        $("#btnSkip").trigger("click");
                    }
                }

            });

            ShowFirstUnAnswered();
        }, function () { });
    });
</script>
