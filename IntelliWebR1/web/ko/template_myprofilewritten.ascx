<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_myprofilewritten.ascx.cs" Inherits="IntelliWebR1.web.ko.template_myprofilewritten" %>


<script type="text/html" id="template_myprofilewritten">
    <input type="text" class="txt-area txtPriority" data-bind="value: Priority, valueUpdate: 'keyup', attr: { 'data-questionid': QuestionId, 'data-priority': OldPriority }, event: { keyup: ValidateNumber, blur: UpDatePriority }" placeholder="0">
    <div class="question">
        <h3 data-bind="text: GetQuestion"></h3>
        <!--ko ifnot:ShowEdit -->
        <p style="float: left; word-break: break-all;" data-bind="html: AnswerHtml, event: { click: ShowEditBox }"></p>
        <!--/ko-->
        <!--ko if:ShowEdit -->
        <textarea class="profileAnswer" style="resize: none;" data-bind="event: { keyup: ValidateMaxAnswerLength }, attr: { 'data-questionid': QuestionId, 'maxlength': MaxAnswerLength }"></textarea>
        <div class="seven_button">
            <input type="button" class="update" style="border: 0px; margin-top: 0px; line-height: 0px;" data-bind="event: { click: SaveEdit }, value: SubmitText" />
            <input type="button" class="cancel" style="border: 0px; margin: 0px; line-height: 0px;" value="Cancel" data-bind="event: { click: CancelEdit }" />
        </div>
        <!--/ko-->
    </div>
    <span class="clear"></span>
</script>
