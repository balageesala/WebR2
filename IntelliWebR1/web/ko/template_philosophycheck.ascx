<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_philosophycheck.ascx.cs" Inherits="IntellidateR1Web.web.ko.template_philosophycheck" %>
<script type="text/html" id="template_philosophycheck">
    
    <!--ko if:IsDeleted-->
    <div style="width: 1280px; display: inline-block; font-size: 0.8em; border-bottom: 1px solid;">
        <div style="padding: 4px;">

            <div style="float: left; width: 40px; padding-left: 4px;">
                <input type="text" class="txtRating" style="width: 30px;" value="0" data-bind="attr: { 'data-questionid': Question_id, 'data-currentrating': Rating }, value: Rating, valueUpdate: 'afterkeydown'" />
            </div>
            <section style="cursor: pointer;" data-bind="event: { click: EditQuestionAnswer }">
                <div style="float: left; width: 280px; padding-right: 8px;" data-bind="text: QuestionDetails().QuestionText"></div>
                <div style="float: left; width: 150px; padding-right: 4px;" data-bind="text: OptionAnswerText"></div>
                <div style="float: left; width: 300px; padding-right: 4px;" data-bind="html: PreferenceAnswerTextFixed"></div>
                <div style="float: left; width: 298px; padding-right: 4px; color:red;" data-bind="html: NonPreferenceAnswerTextFixed"></div>
              
              <!--ko if:IsEdited-->
              <div style="float: left; width: 40px;text-align:center;">
                    <img data-bind="attr: { src: CalenderIconPath, title: LocalTime }" />
                </div>
                <!--/ko-->
             <!--ko ifnot:IsEdited-->
              <div style="float: left; width: 40px;text-align:center;">
                    &nbsp;
                </div>
                <!--/ko-->


                <!--ko if:CommentAvailable-->
                <div style="float: left; width: 40px;text-align:center;">
                    <img data-bind="attr: {src : CommentIconPath}" />
                </div>
                <!--/ko-->
                <!--ko ifnot:CommentAvailable-->
                <div style="float: left; width: 40px;text-align:center;">
                    &nbsp;
                </div>
                <!--/ko-->

                <!--ko ifnot:AnsweredPrivately-->
                <div style="float: left; width: 40px;text-align:center;">&nbsp;</div>
                <!--/ko-->
                <!--ko if:AnsweredPrivately-->
                <div style="float: left; width: 40px;text-align:center;">
                    <img data-bind="attr: { src: PrivacyIconPath }" />
                </div>
                <!--/ko-->
                
                <!--ko if:IsSexQuestion-->
                <div style="float: left; width: 40px;text-align:center;">
                    <img data-bind="attr: { src: SexIconPath }" />
                </div>
                <!--/ko-->
                <!--ko ifnot:IsSexQuestion-->
                <div style="float: left; width: 40px;text-align:center;">&nbsp;</div>
                <!--/ko-->
            </section>
             <div style="float: left; width: 20px;text-align:center;cursor: pointer;" data-bind="event: { click: DeleteQuestionAnswer }">
                    <img data-bind="attr: { src: DeleteIconPath }" style="float: left; width: 20px;height:20px; "/>
                </div>
        </div>
    </div>
    <!--/ko-->
    
      <!--ko ifnot:IsDeleted-->
    <div style="width: 1260px; display: inline-block; font-size: 0.8em; border-bottom: 1px solid;">
        <div style="padding: 4px;">
            <div style="float: left; width: 40px; padding-left: 4px;">
                <input type="text" class="txtRating" style="width: 30px;" value="0" disabled="disabled" data-bind="attr: { 'data-questionid': Question_id, 'data-currentrating': Rating }, valueUpdate: 'afterkeydown'" />
            </div>
            <section style="cursor: pointer;" data-bind="event: { click: EditQuestionAnswer }">
                <div style="float: left; width: 280px; padding-right: 8px;" data-bind="text: QuestionDetails().QuestionText"></div>
                <div style="float: left; width: 150px; padding-right: 4px;display:none;" data-bind="text: OptionAnswerText" ></div>
                <div style="float: left; width: 300px; padding-right: 4px;display:none;" data-bind="html: PreferenceAnswerTextFixed"></div>
                <div style="float: left; width: 298px; padding-right: 4px; color:red;display:none;" data-bind="html: NonPreferenceAnswerTextFixed"></div>
                <div style="float: left; width: 40px; text-align: center;">&nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;">&nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;">&nbsp;</div>
                <div style="float: left; width: 40px; text-align: center;">&nbsp;</div>
                <div style="float: left; width: 20px; text-align: center; cursor: pointer;">&nbsp;</div>
            </section>
        </div>
    </div>
     <!--/ko-->







</script>
