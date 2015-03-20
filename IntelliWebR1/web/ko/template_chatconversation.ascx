<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_chatconversation.ascx.cs" Inherits="IntelliWebR1.web.ko.template_chatconversation" %>

<script type="text/html" id="template_chatview">
    <div class="seventeen_one_cont">
        <div class="seventeen_two_achors fr">
            <input type="button" class="delete" value="Delete" />
        </div>
        <span class="clear"></span>
        <div class="seventeen_two_checkall fl">
            <label>
                <input type="checkbox" name="a" />Selecte all</label>
        </div>
        <div class="seventeen_two_cont">
            <!-- ko foreach: AllConversations -->
            <div class="seventeen_cont_block">
                <div class="fr">
                    <div class="kalam  kalam_spa" data-bind="text: SentDateFormate "></div>
                    <span class="clear"></span>
                </div>
                <span class="clear"></span>
                <div class="seventeen_two_chat">
                    <div class="his_check">
                        <input type="checkbox" name="a" />
                    </div>
                    <!-- ko foreach: ThisView().AllChilds  -->
                    <!-- ko if: $index() != 0 -->
                    <div class="his_check">
                        &nbsp;
                    </div>
                    <!-- /ko -->
                    <div>
                        <div style="float: left; width: 86%;" data-bind="html: MessageTextWithSenderName"></div>
                        <small data-bind="html: SentTimeFormate "></small>
                        <!-- ko if: $index() == 0 -->
                        <img src="images/bin-pic.jpg" alt="" />
                        <!-- /ko -->
                        <span class="clear"></span>                     
                    </div>
                     <!-- /ko -->
            </div>           
        </div>
            <!-- /ko -->
    </div>
        </div>
</script>

