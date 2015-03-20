<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_trashmessage.ascx.cs" Inherits="IntelliWebR1.web.ko.template_trashmessage" %>



<script type="text/html" id="template_trashmessage">

    <div style="float: right; margin-top: -42px; margin-right: 10px;">
        <!-- ko ifnot: IsDeleteAll -->
        <input type="button" value="DELETE" class="deletebtnenable" data-bind="click: DeleteSelected" />
        <!-- /ko -->
    </div>

    <div class="divTrash">
        <div class="divTrashmsgheader">
            <div class="divtrashmsgcol1">
                <div class="divpadding16">
                    <input type="checkbox" data-bind="checked: SelectAll" />
                </div>
            </div>
            <div class="divtrashmsgcol2">
                <div class="divpadding16">&nbsp;</div>
            </div>
            <div class="divtrashmsgcol3">
                &nbsp;
            </div>
            <div class="divtrashmsgcol4">
                Filtered For
            </div>
            <div class="divtrashmsgcol5">
                Message
            </div>
            <div class="divtrashmsgcol6">
                Conversation
            </div>
            <div class="divtrashmsgcol7">
                Time/Date
            </div>
            <div class="divtrashmsgcol8">
                Read
            </div>
            <div class="divtrashmsgcol9">
                Deleted
            </div>
            <div class="divtrashmsgcol10">
                &nbsp;
            </div>
        </div>
        <div class="divtrashheaderborder"></div>
        <div data-bind="foreach: AllSnapshots">
    <div class="divtrashrow">
        <div class="divtrashmsgcol1">
            <div class="divpadding16"  ><input type="checkbox"  data-bind="checked: Selected"  /> </div>
        </div>
        <div class="divtrashmsgcol2" >
            <img data-bind=" attr: { 'src': MessageTypeImg }" style="width:25px;"/>
        </div>
        <div class="divtrashmsgcol3 loadUrl" data-bind="attr: { id: PassportID, 'data-loadurl': LoadPassportHtml }">
            &nbsp;
        </div>
        <div class="divtrashmsgcol4" data-bind="text: MessageFilter">
        </div>
        <!-- ko ifnot: IsConversation -->
        <div class="divtrashmsgcol5 ViewTrashConversation" data-bind="html: LastConversation().SmallMessage, attr: { 'data-conv': UserID, 'data-ctype': ConversationType }">
          
        </div>
         <div class="divtrashmsgcol6">&nbsp;</div>
         <!-- /ko -->
        <!-- ko if: IsConversation -->
         <div class="divtrashmsgcol5">&nbsp;</div>
        <div class="divtrashmsgcol6 ViewTrashConversation" data-bind="html: LastConversation().SmallMessage, attr: { 'data-conv': UserID, 'data-ctype': ConversationType }">
        </div>
         <!-- /ko -->
         

        <div class="divtrashmsgcol7" data-bind="text: LastConversation().SentTimeString">
        </div>
        <div class="divtrashmsgcol8" data-bind="text: LastConversation().SeenTimeString">
        </div>
        <div class="divtrashmsgcol9" data-bind="text: DeletedTimeString">
        </div>
        <div class="divtrashmsgcol10" >
           <img src="images/del-icon.png" data-bind="click: DeleteConversation"/>
        </div>
    </div>
            </div>
    </div>
</script>
