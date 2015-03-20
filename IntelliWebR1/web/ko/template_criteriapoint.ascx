<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_criteriapoint.ascx.cs" Inherits="IntelliWebR1.web.ko.template_criteriapoint" %>
<script type="text/html" id="template_criteriapoint">
    <div class="CriteriaPointsEach" >
        <div style="margin: 14px;">
            <div class="editCriteria" style="width: 110px; float: left; font-size: 16px;cursor:pointer;" data-bind="text: CriteriaName, attr: { 'data-url': CriteriaEditUrl }"  data-width="920" data-height="620"></div>
            <div style="float: left;">
                <!--ko if:AllowAssigningPoints-->
                <input type="text" style="width: 34px;" class="points" maxlength="5" data-bind="attr: { value: UserAssignedPoints, valueUpdate: 'afterkeydown', 'data-criteriaid': _id }" />
                <!--/ko-->
                <!--ko ifnot:AllowAssigningPoints-->
                <input type="text" style="width: 34px;" class="points" maxlength="5" value="0" data-bind="attr: {  valueUpdate: 'afterkeydown', 'data-criteriaid': _id }" disabled="disabled" />
                <!--/ko-->
            </div>
        </div>
    </div>
</script>
