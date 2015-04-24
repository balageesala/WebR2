<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tempalte_conversationview.ascx.cs" Inherits="IntelliWebR1.web.ko.tempalte_conversationview" %>

<script type="text/html" id="template_conversationview">

    <!-- ko if: Discuss().DiscussType() == 0 || Discuss().DiscussType() == 1 -->
    <div class="chat_one">
        <div class="chat_photo loadPhoto" data-bind="attr: { id: SenderID, 'data-loadurl': LoadUserPic }"></div>
        <div class="chat_masage">
            <p data-bind="text: MessageText"></p>
            <ul>
                <li><span data-bind="text: SentDateFormate "></span></li>
                <li><span data-bind="text: SentTimeFormate "></span></li>
            </ul>
            <img src="images/bin-pic.jpg" width="20" height="22" alt="" data-bind="click: DeleteThisConversation "  />
        </div>
        <span class="clear"></span>
    </div>
    <!-- /ko -->
    <!-- ko if: Discuss().DiscussType() == 2 -->
    <div class="chat_one">
        <div class="chat_photo loadPhoto"  data-bind="attr: { id: SenderID, 'data-loadurl': LoadUserPic }"></div>
        <div class="chat_masage">
            <div class="chat_cont fl" style="width: 710px;">
                <div class="talking2 fl chat_conv">
                    <div class="loadDiscuss" data-bind="attr: { 'data-loadurl': LoadDiscuss }"></div>
                    <p data-bind="text: MessageText "></p>
                    <span class="clear"></span>
                </div>
                <span class="clear"></span>
            </div>
            <ul>
                 <li><span data-bind="text: SentDateFormate "></span></li>
                <li><span data-bind="text: SentTimeFormate "></span></li>
            </ul>
            <img src="images/bin-pic.jpg" width="20" height="22" alt="" data-bind="click: DeleteThisConversation "  />
        </div>
        <span class="clear"></span>
    </div>
    <!-- /ko -->
    <!-- ko if: Discuss().DiscussType()  == 4 -->
    <div class="chat_one">
        <div class="chat_photo loadPhoto"  data-bind="attr: { id: SenderID, 'data-loadurl': LoadUserPic }">
        </div>
        <div class="chat_masage">
            <div class="fl">
                <div class="loadDiscuss" data-bind="attr: { 'data-loadurl': LoadDiscuss }" >
                </div>
                <p class="p_top" data-bind="text: MessageText "></p>
            </div>
            <ul>
                 <li><span data-bind="text: SentDateFormate "></span></li>
                <li><span data-bind="text: SentTimeFormate "></span></li>
            </ul>
            <img src="images/bin-pic.jpg" width="20" height="22" alt="" data-bind="click: DeleteThisConversation " />
        </div>
        <span class="clear"></span>
    </div>
    <!-- /ko -->
    <!-- ko if:Discuss().DiscussType()  == 5 -->
    <div class="chat_one">
        <div class="chat_photo loadPhoto"  data-bind="attr: { id: SenderID, 'data-loadurl': LoadUserPic }">
        </div>
        <div class="chat_masage">
            <div class="fl" style="width: 710px;">
                <div class="loadDiscuss" data-bind="attr: { 'data-loadurl': LoadDiscuss }"></div>
                <p class="p_top3" data-bind="text: MessageText "></p>
            </div>
            <ul>
                 <li><span data-bind="text: SentDateFormate "></span></li>
                <li><span data-bind="text: SentTimeFormate "></span></li>
            </ul>
            <img src="images/bin-pic.jpg" width="20" height="22" alt="" data-bind="click: DeleteThisConversation "  />
        </div>
        <span class="clear"></span>
    </div>
    <!-- /ko -->
</script>
