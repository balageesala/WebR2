<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilequestionsfilter.aspx.cs" Inherits="IntelliWebR1.web.inner.profilequestionsfilter" %>

<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
<asp:literal id="ltScripts" runat="server"></asp:literal>

<div class="popup checks" style="padding:0px;margin:0px;">
    	<a id="btnClose" class="close" style="cursor:pointer;">x</a>
        <span class="clear"></span>
        <div class="checks_conta">
        	<div class="tabs_matter">
                <h2></h2>
                <div class="tabs_left_3" style="width: 270px;">
                    <ul>
                     <li><label><input type="radio" id="radioZero" value="1" name="radioFilter">The order in which they appear to them</label></li>
                        <li><label><input type="radio" id="radioOne" value="2" name="radioFilter">Their answers are unacceptable</label> </li>
                        <li><label><input type="radio" id="radioThree" value="3" name="radioFilter">My answers are unacceptable</label></li>
                        <li><label><input type="radio" id="radioFive" value="4" name="radioFilter">Both of our answers are unacceptable</label></li>
                        <li><label><input type="radio" id="radioSeven" value="5" name="radioFilter">We both agree</label></li>
                        <li><label><input type="radio" id="radioEight" value="6" name="radioFilter">Unanswered by me</label></li>
                        <li><label><input type="radio" id="radioNine" value="7" name="radioFilter">Answers with comments</label></li>
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
            });

            $("#btnFilter").click(function () {
                var _type = $('input[name=radioFilter]:checked').val();
                window.parent.FilterQuestions(_type);
                window.parent.CloseIntelliWindow();
            });

        });



    </script>


    </div>