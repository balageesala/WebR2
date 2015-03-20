<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofilecriteria.aspx.cs" Inherits="IntellidateR1Web.web.inner.myprofilecriteria" %>

<%@ Register Src="~/web/ko/template_myprofilecriteria.ascx" TagPrefix="uc1" TagName="template_myprofilecriteria" %>

 
<asp:literal id="ltScripts" runat="server"></asp:literal>
<div style="padding-top: 10px;">
    <div style=" padding-top: 10px;display:inline-block;text-align:right;position: absolute;margin-top: -69px;pointer-events:none;">
        <div style="float:left;width:952px;">&nbsp;</div>
        <div style="float:left;width: 340px; height: 60px; border: 0px solid;">
            <div style="float: left; font-size: 22px;margin:15px;">Points Remaining</div>
            <div style="float: left;margin:18px;margin-left:-10px;margin-top:14px;">
                <input type="text" id="txtPointsLeft" value="0" disabled="disabled" style="width: 50px;height: 24px;font-size: 20px;" /></div>
            <div style="float: left;margin-left: -20px;margin-top: 2px;pointer-events:all;">
                <div class="SubmitButtonSmall FloatRight Disabled" id="btnSubmit">
                    <div>Submit</div>
                </div>
            </div>
        </div>
    </div>
    <div style="height:10px;font-size:12px;text-align:center;width:1320px;" id="divPointsResult">&nbsp;</div>
    <div style="width: 1320px; min-height: 500px; border-top: 0px solid #B6B6B6; padding-top: 10px;">
        <div style="width: 100%; height: 32px; background-color: #C1282D">
            <div style="float: left; width: 68px; color: #F7F9FF; padding: 4px; text-align: center;">Points</div>
            <div style="float: left; width: 200px; color: #F7F9FF; padding: 4px; text-align: center;">Category</div>
            <div style="float: left; width: 300px; color: #F7F9FF; padding: 4px; text-align: center;">My Answer</div>
            <div style="float: left; width: 300px; color: #F7F9FF; padding: 4px; text-align: center;">Acceptable Answer(s)</div>
            <div style="float: left; width: 300px; color: #F7F9FF; padding: 4px; text-align: center;">Unacceptable Answer(s)</div>
        </div>
        <div style="clear:both;"></div>
        
        <div id="divMyProfileCriterias" data-bind="template: { name: 'template_myprofilecriteria', foreach: AllQuestions }"></div>
    </div>
</div>
<uc1:template_myprofilecriteria runat="server" ID="template_myprofilecriteria" />
