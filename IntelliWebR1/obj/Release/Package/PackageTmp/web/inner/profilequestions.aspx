<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilequestions.aspx.cs" Inherits="IntelliWebR1.web.inner.profilequestions" %>

<%@ Register Src="~/web/uc/profilequestionsmenu.ascx" TagPrefix="uc1" TagName="profilequestionsmenu" %>


<asp:literal id="ltScripts" runat="server"></asp:literal>
<style type="text/css">
    .lnkbutton {
        padding: 5px 10px;
        border-radius: 3px;
        background-color: #c1272d;
        height: 22px;
        font-size: 0.85em;
        font-weight: 400;
        letter-spacing: 1px;
        color: #fff;
        text-align: center;
        border: none;
        cursor: pointer;
        float: right;
        padding-top: 10px;
        text-decoration: none;
    }

    .redColor {
        color: red;
    }
   
    .answerQuestion{
        cursor:pointer;
    }
 

</style>
<span class="clear"></span>
<uc1:profilequestionsmenu runat="server" ID="profilequestionsmenu" />
<div id="divBothAnswered" class="sixteen_cont" style="width:940px;padding-bottom:30px;float: left;" runat="server">
    <asp:repeater id="rptPhilosophyMatch" runat="server" onitemdatabound="rptPhilosophyMatch_ItemDataBound" >
                <ItemTemplate>
                    <asp:Panel ID="pnlAnswered" runat="server">
                        <div class="talking fl" style="margin-left:40px;float:left;min-height: 40vh;">
                            <a style="cursor:pointer;" id="BtnEditQtn" runat="server" class="edit"><img src="images/16_edit.png" width="14" height="14" alt=""/></a>
                            <h3 id="lblQuestion" runat="server"></h3>                      
                                <div class="sixteen_chat">
                                    <img id="imgOtherUserIcon" width="48" height="49"  runat="server" />
                                <div class="sixteen_text">
                                 
                                       <h4 id="lblOtherUserAnswer" runat="server"></h4>
                                        <p  id="lblOtherUserComment" runat="server"></p>
                                        <div id="divAnswerNow" visible="false" style="font-size: 14px; margin-top: -20px; margin-left: 100px;" runat="server">
                                            <a id="lnkAnswerNow" class="lnkAnswerNow" style="font-size: 18px;" runat="server">Answer</a>
                                        </div>
                                  
                                </div>
                               <span class="clear"></span>
                                 </div>
                           
                             <div class="sixteen_chat">
                                    <img id="imgUserIcon" width="46" height="47"  runat="server" />
                               
                                <div  class="sixteen_text">

                                        <h4 id="lblUserAnswer" runat="server"></h4>
                                        <p  id="lblUserComment" runat="server"></p>
                                </div>
                                  <span class="clear"></span>
                            </div>   
                            <div style="text-align: right; margin-right: 20px;">
                                <input type="button" id="btnChatAboutIt" data-width="500" data-height="320" class="discuss ChatAboutIt" style="border:0px;" runat="server" value="Discuss" />
                            </div>
</div>
</asp:Panel>
                    <asp:panel id="pnlNotAnswered" runat="server" visible="false">
                        <div runat="server" id="divLoadMatch" class="sixteen_chat" style="width:700px;float:left;margin: 0 auto;border-bottom: 1px solid;padding: 4px;">
                            <h4 id="lblQuestionText" runat="server" ></h4>
                           <asp:HyperLink ID="lnkAnswerQuestion" runat="server" CssClass="discuss answerQuestion">Answer</asp:HyperLink>
                        </div>
                    </asp:panel>

<asp:panel id="pnlSexQuestions" runat="server" visible="false">
                          <div runat="server" id="DivLoadSexQtn" class="fifteen-b_question">                   
                           <p id="lblSexQuestionText" runat="server"></p>  
                  </div>
                   </asp:panel>

</ItemTemplate>
            </asp:repeater>
    <input type="hidden" id="hdnSubMenu" runat="server" value="0" />
    <input type="hidden" id="hdnSearchText" value="0" runat="server" />

</div>


<div>
    <input type="hidden" id="hdnclass" value="0" />

    <input type="hidden" id="hdnUpdateMatchp" value="0" />
</div>


<script type="text/javascript">
    $(document).ready(function () {

        SetText();
        //$(".lnkAnswerNow").colorbox({ iframe: true, width: "900px", height: "440px" });;

        //$('#form1').bind("keyup keypress", function (e) {
        //    var code = e.keyCode || e.which;
        //    if (code == 13) {
        //        e.preventDefault();
        //        return false;
        //    }
        //});

        $(".edit").click(function () {
            var _questionId = $(this).data("id");
            //alert(_questionId);
            var _Url = _SitePath + "web/inner/questionsedit?qid=" + _questionId;
            SetUrlIntelliWindow(_Url, 700, 520);

        })


        $("#cboDisplayType").change(function () {
            $("#txtSearchText").val($("#cboDisplayType option:selected").text());
            $("#hdnSearchType").val($(this).val());


            var _sUrl = _SitePath + "web/inner/profilequestions.aspx?u=" + _OtherUserID + "&l=" + $(this).val();
            //alert(_sUrl);
            ShowThisQuestions(_sUrl);
        });


        $("#txtSearchText").focus(function () {
            $("#txtSearchText").val("");
            $("#hdnSearchType").val("0");
        });

        $("#txtSearchText").keydown(function (e) {
            if (e.keyCode == 13) {
                // Search with keyword
                var _qtnText = $("#txtSearchText").val();
                var _sUrl = _SitePath + "web/inner/profilequestions.aspx?u=" + _OtherUserID + "&l=9&qt=" + _qtnText;
                ShowThisQuestions(_sUrl);
                _SelectedItem = 9;
            }
        });

        var _subMenuValue = $("#hdnSubMenu").val();
        if (_subMenuValue == "0") {
            $("#lnkGenaralQuestions").css("color", "red");
            $("#divFilter").show();
        } else {
            $("#lnkSexQuestions").css("color", "red");
            $("#divFilter").hide();
        }



    });

    function LoadSexQuestions() {
        var _sUrl = _SitePath + "web/inner/profilequestions.aspx?u=" + _OtherUserID + "&l=8";
        ShowThisQuestions(_sUrl);
        LoadSexMatchp();
    }

    function LoadGenaralQuestions() {
        var _sUrl = _SitePath + "web/inner/profilequestions.aspx?u=" + _OtherUserID + "&l=0";
        ShowThisQuestions(_sUrl);
        LoadGenaralMatchp();
    }

    function LoadSexMatchp() {
        var _SexQmatchpPath = _SitePath + "web/inner/sexquestionsmatchp?OtherUserID=" + _OtherUserID + "&Type=q";
        $("#divLoadProfileMatchp").load(_SexQmatchpPath, function () {
        });
    }

    function LoadGenaralMatchp() {
        var _QmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=q";
        $("#divLoadProfileMatchp").load(_QmatchpPath, function () {
        });
    }




    function LetDiscuss(objUrl) {
        try {
            if (ISUSERBLOCKED) {
                SetUrlIntelliWindow(objUrl, "700", "420");
            } else {
                alert("this user blocked.");
            }
        } catch (ex) {
            //console.log(ex);
        }
    }


    function FilterQuestions(_type) {

        $("#hdnSearchType").val(_type);
        var _sUrl = _SitePath + "web/inner/profilequestions.aspx?u=" + _OtherUserID + "&l=" + _type;
        ShowThisQuestions(_sUrl);
    }




    function SetText() {
        /*The order in which they appear to her
        Her answers are unacceptable
        My answers are unacceptable
        Both of our answers are unacceptable
        We both agree
        Unanswered by me
        Answers with explanations*/
        var _Text = "";
        //alert(_SelectedItem);

        switch (eval(_SelectedItem)) {
            case 1: {
                _Text = "The order in which they appear to them";
                break;
            }
            case 2: {
                _Text = "Their answers are unacceptable";
                break;
            }
            case 3: {
                _Text = "My answers are unacceptable";
                break;
            }
            case 4: {
                _Text = "Both of our answers are unacceptable";
                break;
            }
            case 5: {
                _Text = "We both agree";
                break;
            }
            case 6: {
                _Text = "Unanswered by me";
                break;
            }
            case 7: {
                _Text = "Answers with comments";
                break;
            }
            case 9: {
                _Text = $("#hdnSearchText").val();
                break;
            }

        }



        $("#txtSearchText").val(_Text);
    }
</script>
<script type="text/javascript">
    $(document).ready(function () {

        // Chat about it
        $(".ChatAboutIt").click(function (e) {
            try {
                if (ISUSERBLOCKED) {
                    var _composeUrl = $(this).attr("data-url");
                    SetUrlIntelliWindow(_composeUrl, "700", "420");
                } else {
                    alert("this user blocked.");
                }
            } catch (ex) {
                //console.log(ex);
            }

        });


        $(".answerQuestion").click(function () {
            try {
                var _AnswerQuestionUrl = $(this).attr("data-url");
                //  alert(_AnswerQuestionUrl);
                SetUrlIntelliWindow(_AnswerQuestionUrl, "1000", "658");
            } catch (ex) {

            }

        });

    });



    $(document).ready(
           function () {

               setInterval(function () {

                   var IsUpdateMatch = $("#hdnUpdateMatchp").val();
                   if (IsUpdateMatch == "1") {
                       var _QmatchpPath = _SitePath + "web/inner/profilematchp?OtherUserID=" + _OtherUserID + "&Type=q";
                       $("#divLoadProfileMatchp").load(_QmatchpPath, function () {
                           $("#hdnUpdateMatchp").val("0");
                       });
                   }
               }, 10000);
           });





</script>

<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>
