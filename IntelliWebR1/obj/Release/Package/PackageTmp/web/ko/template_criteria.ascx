<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="template_criteria.ascx.cs" Inherits="IntelliWebR1.web.ko.template_criteria" %>
<script type="text/html" id="template_criteriaquestion">
    <div  data-bind="attr: { id: _id }" class="one displayNone">
           <!--ko if:ShowThisQuestion-->
        <div class="one_top">
            <div class="one_numbering">
                <p>1</p>
                <span>of</span>
                <p>23</p>
                <span class="clear"></span>
            </div>
            <img src="images/01_line-shadow.jpg" height="1" alt="line" />
            <p>
                Vivamus ultricies fermentum mattis. Cras vitae ex nibh. Aliquam facilisis, Cras vitae ex nibh. 
    Aliquam facilisis,
            </p>
        </div>
        <div class="one_matter">
            <div class="tabs_matter">
                <h2>Have Children</h2>
                <h3>How many children you wish to have?</h3>
                <div class="tabs_left">
                    <h5>Your Answer </h5>
                    <ul>
                        <li>
                            <label>
                                <input type="radio" name="a" height="50" width="50"><span>No Children</span></label></li>
                        <li>
                            <label>
                                <input type="radio" name="a"><span>Yes Children</span></label></li>
                        <li>
                            <label>
                                <input type="radio" name="a"><span>2 children</span></label></li>
                        <li>
                            <label>
                                <input type="radio" name="a"><span>More than 2 childred</span></label></li>
                    </ul>
                </div>
                <div class="tabs_left marg_no">
                    <h5>Their Answer</h5>
                    <ul>
                        <li>
                            <label>
                                <input type="checkbox" name="a"><span>No Children</span></label></li>
                        <li>
                            <label>
                                <input type="checkbox" name="a"><span>Yes Children</span></label>
                        </li>
                        <li>
                            <label>
                                <input type="checkbox" name="a"><span>2 children</span></label></li>
                        <li>
                            <label>
                                <input type="checkbox" name="a"><span>More than 2 children</span></label></li>
                        <li>
                            <label>
                                <input type="checkbox" name="a"><span>Any of the above</span></label></li>
                    </ul>
                </div>
                <!--<div class="tabs_right"></div>-->
                <span class="clear"></span>


            </div>

            <div class="one_buttons">
                <a href="" class="skip">Skip</a>
                <a href="" class="submit">Next</a>
            </div>
            <span class="clear"></span>
        </div>
          <!--/ko-->
    </div>

</script>
<script type="text/javascript">
    $(document).ready(function () {
        $.getDATA(_SitePath + "api/GetCriteriaList", function (_return) {
            ko.applyBindings(new VMCriteriaQuestionList(_return), document.getElementById("divCriteriaQuetion"));
            $(document).keydown(function (e) {
                if (e.keyCode == 13) {
                    //check foucs button
                    var _submitFacus = $("#btnSubmit").is(":focus");
                    var _skipFacus = $("#btnSkip").is(":focus");
                    if (_submitFacus) {
                        var isBtnDisabled = $("#btnSubmit").hasClass('Disabled');
                        if (!isBtnDisabled) {
                            $("#btnSubmit").trigger("click");
                        }
                    }
                    if (_skipFacus) {
                        $("#btnSkip").trigger("click");
                    }
                }
            });
            ShowFirstUnAnswered();
        }, function () { });
    });
</script>
