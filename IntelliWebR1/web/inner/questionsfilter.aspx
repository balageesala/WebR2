<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="questionsfilter.aspx.cs" Inherits="IntelliWebR1.web.inner.questionsfilter" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<div class="popup checks" style="padding:0px;margin:0px;">
    	<a id="btnClose" class="close" style="cursor:pointer;">x</a>
        <span class="clear"></span>
        <div class="checks_conta">
        	<div class="tabs_matter">
                <h2></h2>
                <div class="tabs_left_3">
                    <ul>
                        <li><label><input type="checkbox" id="chkZero" value="0" name="ChkFilter">0 points</label></li>
                        <li><label><input type="checkbox" id="chkOne" value="1" name="ChkFilter">1 point</label> </li>
                        <li><label><input type="checkbox" id="chkTwo" value="2" name="ChkFilter">2 points</label></li>
                        <li><label><input type="checkbox" id="chkThree" value="3" name="ChkFilter">3 points</label></li>
                        <li><label><input type="checkbox" id="chkFour" value="4" name="ChkFilter">4 points</label></li>
                        <li><label><input type="checkbox" id="chkFive" value="5" name="ChkFilter">5 points</label></li>
                        <li><label><input type="checkbox" id="chkSix" value="6" name="ChkFilter">6 points</label></li>
                        <li><label><input type="checkbox" id="chkSeven" value="7" name="ChkFilter">7 points</label></li>
                        <li><label><input type="checkbox" id="chkEight" value="8" name="ChkFilter">8 points</label></li>
                        <li><label><input type="checkbox" id="chkNine" value="9" name="ChkFilter">9 points</label></li>
                        <li><label><input type="checkbox" id="chkTen" value="10" name="ChkFilter">10 points</label></li>
                    </ul>
                </div>                
                <div class="tabs_left_3">
                    <ul>
                        <li><label><input type="checkbox" id="chkComments" value="11" name="ChkFilter">With Comments</label></li>
                        <li><label><input type="checkbox" id="chkNoComments" value="12" name="ChkFilter">Without Comments</label> </li>
                        <li><label><input type="checkbox" id="chkGenaral" value="13" name="ChkFilter">General</label></li>
                        <li><label><input type="checkbox" id="chkSex" value="14" name="ChkFilter">Sex</label></li>
                        <li><label><input type="checkbox" id="chkPrivate" value="15" name="ChkFilter">Private</label></li>
                        <li><label><input type="checkbox" id="chkPending" value="16" name="ChkFilter">Pending</label></li>
                        <li><label><input type="checkbox" id="chkAnswers" value="17" name="ChkFilter">All Answers Are Acceptable</label> </li>
                        <li><label><input type="checkbox" id="chkAlpha" value="19" name="ChkFilter">Alphabetical Order</label></li>
                        <li><label><input type="checkbox" id="chkDate" value="20" name="ChkFilter">Date Answered</label></li>
                    </ul>
                </div>
                 <div class="tabs_left_3">
                     <div style="height:20px;">&nbsp;</div>
                    <ul>                    
                        <li><label><input type="checkbox" id="chkCleared" value="21" name="chkclear">Cleared</label></li>
                    </ul>
                </div>
                <span class="clear"></span>
            </div>
        </div>
        <input type="button" id="btnFilter" class="send" value="Filter">
        <span class="clear"></span>
    <script type="text/javascript">

        $(document).ready(function () {

            $("#btnClose").click(function () {
                window.parent.CloseIntelliWindow();
            })

            $("#chkCleared").click(function () {
                if ($(this).is(':checked')) {
                    $('input[name="ChkFilter"').removeAttr('checked');
                }
            })

            $('input[name="ChkFilter"').click(function () {
                if ($(this).is(':checked')) {
                    $("#chkCleared").removeAttr('checked');
                }
            })


            $("#btnFilter").click(function () {
                if ($("#chkCleared").is(':checked')) {

                } else {
                    var _filterArray = new Array();
                    $('input[name="ChkFilter"').each(function () {
                        if ($(this).is(':checked')) {
                            _filterArray.push($(this).val());
                        }
                    });

                }
            });

        });



    </script>


</div>