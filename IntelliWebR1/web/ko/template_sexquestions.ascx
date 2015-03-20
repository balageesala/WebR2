<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_sexquestions.ascx.cs" Inherits="IntelliWebR1.web.ko.template_sexquestions" %>

<script type="text/html" id="template_sexquestions">
      <!--ko if:ShowThisQuestion-->
    <div class="tabs_matter tableft"  data-bind="animate: position()">
        <h2 data-bind="text: QuestionText"></h2>
        <div class="tabs_left marg_no"  style="width: 280px;">
            <h5 data-bind="text: OptionsQuestion"></h5>
            <ul>
                <!--ko foreach:OptionElements().Options-->
                <li  style="width: 280px;">
                    <input type="radio" data-bind="attr: { id: OptionCheckID, value: _id }" class="philosophyOptions" name="philosophyOptions" /><label data-bind="    attr: { 'for': OptionCheckID }, text: OptionText"></label>
                </li>
                <!--/ko-->

            </ul>
        </div>
        <div class="tabs_left marg_no">
            <h5 data-bind="text: PreferenceQuestion"></h5>
            <ul>
                <!--ko foreach:PreferenceElements().Options-->
                <li  style="width: 280px;">
                    <input type="checkbox" data-bind="attr: { id: OptionPrefCheckID, value: _id }" class="philosophyPrefOptions" name="philosophyPrefOptions" /><label data-bind="    attr: { 'for': OptionPrefCheckID }, text: OptionText"></label>
                </li>
                <!--/ko-->
                <!--ko if:PreferenceElements().HasSelectAllText-->
                <li  style="width: 280px;">
                    <input type="checkbox" id="chkSelectAll" /><label for="chkSelectAll" data-bind="text: PreferenceElements().SelectAllText"></label>
                </li>
                <!--/ko-->
            </ul>
        </div>
        <div class="clear"></div>
        <div class="input select rating-c">
            <select id="example-c" class="selectexample-c" name="rating">
                <option value=""></option>
                <option value="0">0</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
                <option value="8">8</option>
                <option value="9">9</option>
                <option value="10">10</option>
            </select>
        </div>
        <!--ko if:QuestionCategory() == '0'-->
        <div class="comment">
            <textarea id="txtComment" placeholder="Comments (optional)" onkeyup="autoGrow(this);"></textarea>
        </div>
        <div class="check">
            <label>
                <input type="checkbox" id="chkAnswerPrivately">
                Keep Private
            </label>
        </div>
        <!--/ko-->
        <div class="clear"></div>
    </div>
    <div class="buttons">
        <div class="skip" style="cursor:pointer;" id="btnSkip" data-bind="event: { click: SkipClick }" >
            Skip
        </div>
        <input type="button" class="btnSubmitN Disabled" disabled="disabled" style="border: 0px;cursor:pointer;" value="Submit" id="btnSubmit" data-bind="event: { click: SubmtClick }" />
    </div>
    <!--/ko-->
</script>