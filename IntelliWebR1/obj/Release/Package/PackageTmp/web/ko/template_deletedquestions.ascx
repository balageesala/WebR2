<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_deletedquestions.ascx.cs" Inherits="IntelliWebR1.web.ko.template_deletedquestions" %>

<script type="text/html" id="template_deletedquestions">
    <div style="width: 1280px; display: inline-block; font-size: 0.8em; border-bottom: 1px solid;">
        <div style="padding: 4px;">
            <div style="float: left; width: 40px; padding-left: 4px;">
                <input type="text" class="txtRating" style="width: 30px;" value="0" disabled="disabled"/>
            </div>
            <section style="cursor: pointer;" data-bind="event: { click: EditQuestionAnswer }">
                <div style="float: left; width: 280px; padding-right: 8px;" data-bind="text: QuestionDetails().QuestionText"></div>
                <div style="float: left; width: 150px; padding-right: 4px;">&nbsp;</div>
                <div style="float: left; width: 300px; padding-right: 4px;">&nbsp;</div>
                <div style="float: left; width: 298px; padding-right: 4px; color: red;">&nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;"> &nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;"> &nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;">&nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;">&nbsp;</div>
                <div style="float: left; width: 20px; text-align: center; cursor: pointer;">&nbsp;</div>
            </section>
        </div>
    </div>
</script>
