<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_questionscheck.ascx.cs" Inherits="IntelliWebR1.web.ko.template_questionscheck" %>

<script type="text/html" id="template_questionscheck">
    <div class="tenth_matter">
        <div class="tenth_head">
            <ul>
                <li class="grade">Points</li>
                <li class="subject">Question</li>
                <li class="question">Your Answers</li>
                <li class="correct">Acceptable Answer(s)</li>
                <li class="incorrect">Unacceptable Answer(s)</li>
                <li class="note"></li>
            </ul>
            <span class="clear"></span>
        </div>
        <!--ko foreach: AllAnswers -->
        <div class="tenth_info">
            <ul>
                <div style="cursor:pointer;" data-bind="event: { click: EditQuestionAnswer }">
                <li class="grade"><span data-bind="attr: { 'data-questionid': Question_id, 'data-currentrating': Rating }, text: Rating"></span></li>
                <li class="subject" data-bind="html: QuestionDetails().QuestionText"></li>
                <li class="question" data-bind="html: OptionAnswerText"></li>
                <li class="correct" data-bind="html: PreferenceAnswerTextFixed"></li>
                <li class="incorrect" data-bind="html: NonPreferenceAnswerTextFixed"></li>
                </div>
                <li class="note">
                    <div class="to_icon">
                        <img src="images/icon_close.png" alt="" data-bind="event: { click: DeleteQuestionAnswer }" />
                        <!--ko if:IsEdited-->
                        <img src="images/icon_calender.png" alt="calendar" data-bind="attr: { title: LocalTime }" />
                        <!--/ko-->
                        <!--ko if:CommentAvailable-->
                        <img src="images/icon_note.png" alt="note" />
                        <!--/ko-->
                        <!--ko if:AnsweredPrivately-->
                        <img src="images/icon_lock.png" alt="" />
                        <!--/ko-->
                        <!--ko if:IsSexQuestion-->
                        <img src="images/icon_save.png" alt="" />
                        <!--/ko-->
                    </div>
                </li>
            </ul>
        </div>
        <!--/ko-->
    </div>
</script>
