<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_philosophyquestion.ascx.cs" Inherits="IntelliWebR1.web.ko.template_philosophyquestion" %>
<script type="text/html" id="template_philosophyquestion">
    <!--ko if:ShowThisQuestion-->
    <div style="width: 96%; margin: 20px; min-height: 360px; background-color: #ECECEC; border-radius: 4px 6px;">
        <div style="height: 40px; text-align: center; padding: 4px;">
            <div style="margin: 10px; font-size: 16px;" data-bind="text: PhilosophyName"></div>
        </div>
        <div style="width: 96%; background-color: #fff; min-height: 120px; display: inline-block; margin-left: 14px; border-radius: 4px 6px;">
            <div>
                <div style="float: left; width: 50%;">
                    <div style="font-size: 14px; padding: 16px;" data-bind="text: PhilosophyQuestion"></div>
                    <!--ko if:PhilosophyType()=='1'-->
                    <!--ko foreach:PhilosophyOptions-->
                    <div style="font-size: 14px; padding: 8px; padding-left: 16px;">
                        <input type="radio"  data-bind="attr: { id: OptionCheckID, value: _id }" class="philosophyOptions" name="philosophyOptions" /><label data-bind="attr: { 'for': OptionCheckID }, text: OptionText"></label>
                    </div>
                    <!--/ko-->
                    <!--/ko-->
                    
                </div>
                <div style="float: left; width: 50%;">
                    <div style="font-size: 14px; padding: 16px;" data-bind="text: PhilosophyPreferenceQuestion"></div>
                    <!--ko if: PhilosophyPreferenceType()=='1'-->
                    <!--ko foreach:PhilosophyPreferenceOptions-->
                    <div style="font-size: 14px; padding: 8px; padding-left: 16px;">
                        <input type="checkbox"  data-bind="attr: { id: OptionPrefCheckID, value: _id }" class="philosophyPrefOptions" name="philosophyPrefOptions" /><label data-bind="attr: { 'for': OptionPrefCheckID }, text: OptionText"></label>
                    </div>
                    <!--/ko-->
                    <!--ko if:PreferenceSelectAllTextEnable_One-->
                    <div style="font-size: 14px; padding: 8px; padding-left: 16px;">
                        <input type="checkbox" id="chkSelectAll" /><label for="chkSelectAll" data-bind="text: PreferenceSelectAllText_One"></label>
                    </div>
                    <!--/ko-->
                    <!--/ko-->
                </div>
            </div>
            <div style="clear: both;"></div>
            <div style="height: 10px; width: 100%; margin-top: 10px;">
                <div style="float: left; width: 90%; background-color: #ccc;" id="divSlider">&nbsp;</div>
                <div style="float: left; width: 10%; margin-top: -3px;">
                    <input type="text" style="width: 30px;" value="0" maxlength="3" /></div>
            </div>
            <div style="clear: both;"></div>
            <div style="margin: 10px;">
                <div style="float: left;">
                    <textarea style="width: 360px; height: 80px; border-radius: 4px 4px; resize: none; font-family: Tahoma;" placeholder="Comments (optional)"></textarea>
                </div>
                <div style="float: left; border: 0px solid; margin-left: 125px; text-align: right;">
                    <div style="font-size: 14px;">
                        <input type="checkbox" id="chkAnswerPrivately" /><label for="chkAnswerPrivately">Answer Privately&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    </div>
                    <div style="border: 0px solid; margin-top: 20px; height: 45px;">
                        <div style="float: left;">
                            <div class="SubmitButtonSmall FloatRight Disabled" id="btnSkip">
                                <div>Skip</div>
                            </div>
                        </div>
                        <div style="float: left;">
                            <div class="SubmitButtonSmall FloatRight" id="btnSubmit">
                                <div>Submit</div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!--/ko-->
   <!--ko ifnot:AllAnswred-->
    <div>You have answred all questions.</div>
    <!--/ko-->

</script>


