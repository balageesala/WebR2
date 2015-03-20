<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_criteriaedit.ascx.cs" Inherits="IntelliWebR1.web.ko.template_criteriaedit" %>

<script type="text/html" id="template_criteriaedit">

    <!--ko if:ShowEditItem-->
    <div class="criteriatemp">
        <div class="editcriterianame" data-bind="text: CriteriaName"></div>
        <div class="critriaqtnname" data-bind="text: QuestionName"></div>
        <div class="QuestionArea" style="border: 0px solid; margin-top: 4px;width: 96%;">
            <div class="SelectionArea" style="width: 48%; float: left; margin-top: 10px;">
                <div class="SelectionQuestion editselectionqtn" data-bind="text: CriteriaQuestion"></div>

                <div class="SelectionQuestion SelectionQuestionMargins editcriteriafont">
                    <!--ko if:CriteriaType()=='1'-->
                    <!--ko foreach:CriteriaOptions-->
                    <div class="paddingfont">
                        <input type="radio" data-bind="attr: { id: OptionCheckID, value: _id }" class="criteriaOptions" name="criteriaOptions" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label>
                    </div>
                    <!--/ko-->
                    <!--/ko-->

                    <!--ko if:CriteriaType()=='2'-->
                    <!--ko foreach:CriteriaOptions-->
                    <div class="paddingfont">
                        <input type="checkbox" data-bind="attr: { id: OptionCheckID, value: _id }" class="criteriaOptions" name="criteriaOptions" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label>
                    </div>
                    <!--/ko-->
                    <!--/ko-->

                    <!--ko if:CriteriaType()=='7'-->
                    <div class="editleftfloat">
                        <select class="two_dates Month" data-bind="event: { change: CheckSubmitDisable }">
                            <asp:Literal ID="ltMonths" runat="server"></asp:Literal>
                        </select>

                    </div>
                    <div class="editleftfloat" style="margin-left:10px;">
                        <select class="two_dates Day" data-bind="event: { change: CheckSubmitDisable }">
                            <asp:Literal ID="ltDays" runat="server"></asp:Literal>
                        </select>
                    </div>
                    <div class="editleftfloat" style="margin-left:10px;">
                        <select class="two_dates Year" data-bind="event: { change: CheckSubmitDisable }">
                            <asp:Literal ID="ltYears" runat="server"></asp:Literal>
                        </select>
                    </div>
                    <div id="lblCriteriaDobError"></div>
                    <!--/ko-->

                    <!--ko if:CriteriaType()=='8'-->
                    <div class="paddingfont">
                        <input type="text" id="txtSalary"  class="CriteriatextField" placeholder="$" />
                    </div>
                    <div id="lblCriteriaSalaryError"></div>
                    <!--/ko-->

                    <!--ko if:CriteriaType()=='9'-->
                    <div class="paddingfont">
                        <input type="text" id="txtZipCode" class="CriteriatextField" maxlength="5" placeholder="Zipcode" />
                    </div>
                    <div id="lblCriteriaZipCodeError"></div>
                    <!--/ko-->


                </div>
            </div>
            <div class="SelectionArea editselectionarea">
                <!--ko if:ShowPartTwo-->
                <div class="SelectionQuestion editptwoqtn" data-bind="text: CriteriaPreferenceQuestion"></div>
                <div class="SelectionQuestion SelectionQuestionMargins editcriteriafont" >

                    <!--ko if: CriteriaPreferenceType()=='1'-->
                    <!--ko foreach:CriteriaPreferenceOptions-->
                    <div class="paddingfont">
                        <input type="checkbox" data-bind="attr: { id: OptionPrefCheckID, value: _id }" class="criteriaPrefOptions" name="criteriaPrefOptions" /><label data-bind="    attr: { 'for': OptionPrefCheckID }, text: OptionText"></label>
                    </div>
                    <!--/ko-->
                    <!--ko if:PreferenceSelectAllTextEnable_One-->
                    <div class="paddingfont">
                        <input type="checkbox" id="chkSelectAll" /><label for="chkSelectAll" data-bind="text: PreferenceSelectAllText_One"></label>
                    </div>
                    <!--/ko-->
                    <!--/ko-->

                    <!--ko if:CriteriaPreferenceType()=='3'-->
                    <div class="editleftfloat">
                        <select class="two_dates SelectOptionsOne" data-bind="event: { change: CheckSubmitDisable }">
                            <option selected class="selectOption" value="0">From</option>
                            <!--ko foreach:CriteriaPreferenceOptions_One-->
                            <option class="selectOption" data-bind="attr: { value: _id }, text: OptionText"></option>
                            <!--/ko-->
                        </select>
                    </div>
                    <div class="editleftfloat" style="margin-left:10px;">
                        <select class="two_dates SelectOptionsTwo" data-bind="event: { change: CheckSubmitDisable }">
                            <option selected class="selectOption" value="0">To</option>
                            <!--ko foreach:CriteriaPreferenceOptions_Two-->
                            <option class="selectOption" data-bind="attr: { value: _id }, text: OptionText"></option>
                            <!--/ko-->
                        </select>
                    </div>
                    <!--/ko-->
                    <!--ko if:CriteriaPreferenceType()=='4'-->

                    <!--ko if:CriteriaType()=='9'-->
                    <div class="paddingfont">
                        <input type="text" id="txtDistanceRange" style="width:140px;"  maxlength="9" class="clsDistanceRange CriteriatextField"  placeholder="Distance in miles" />
                    </div>
                    <div id="lblCriteriaDistanceeError"></div>
                    <!--/ko-->

                    <!--ko ifnot:CriteriaType()=='9'-->
                    <div class="editleftfloat">
                        <input type="text" id="txtSalaryFrom" class="CriteriatextField"  placeholder="$" />
                    </div>
                    <div class="editleftfloat">&nbsp; To &nbsp; </div>
                    <div class="editleftfloat">
                        <input type="text" id="txtSalaryTo" class="CriteriatextField" placeholder="$" />
                    </div>
                    <!--/ko-->
                    <!--/ko-->
                    <div style="clear: both;"></div>
                    <div style="margin-top: 20px; display: none;">
                        <textarea id="txtComment" class="txtComment" placeholder="Comment (optional)" data-bind="value: Comment" ></textarea>
                    </div>
                </div>
                <!--/ko-->
            </div>

        </div>
    </div>
    <div style="clear: both;"></div>
    <div class="ButtonsArea" style="padding-right: 30px;">
        <div class="SubmitButton FloatRight Disabled" id="btnSubmit" data-bind="event: { click: SubmitClick }">
            <div>Submit</div>
        </div>
        <!--ko if:ShowSkipButton-->
        <div class="BackButton FloatRight" data-bind="event: { click: SkipClick }">
            <div>skip</div>
        </div>
        <!--/ko-->
    </div>
      <div class="FloatLeft">
            <div id="btnClearAnswer" style="cursor:pointer;text-decoration:underline;margin-left: 30px;margin-top: 20px;font-family: 'Open Sans', sans-serif;" data-bind="event: { click: ClearAnswer }">Clear Answer</div>
        </div>

    <!--/ko-->

</script>
