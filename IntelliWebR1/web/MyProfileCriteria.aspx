<%@ Page Title="" Language="C#" MasterPageFile="~/web/Site.Master" AutoEventWireup="true" CodeBehind="MyProfileCriteria.aspx.cs" Inherits="IntelliWebR1.web.MyProfileCriteria" %>

<%@ Register Src="~/web/uc/myprofilemenu.ascx" TagPrefix="uc1" TagName="myprofilemenu" %>
<%@ Register Src="~/web/ko/template_myprofilecriteria.ascx" TagPrefix="uc1" TagName="template_myprofilecriteria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ObjHead" runat="server">
    <style type="text/css">
        .editCriteria {
            cursor: pointer;
        }

        .Disabled {
            background-color: #999;
        }
        .CriteriaPointsRed{
            color:red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ObjContent" runat="server">
    <div class="center_content">
        <div class="middle_content">
            <div class="ninth">
                <div class="person">
                    <img src="images/person.jpg" width="110" height="108" alt="person" />
                </div>
                <div class="tab_nav ninth_top_right">
                    <uc1:myprofilemenu runat="server" ID="myprofilemenu" />
                    <div class="ninth_field">
                        <input type="button" class="SubmitButton" id="btnUpdate" value="Change Points"  />
                        <div id="divPointsResult"></div>
                    </div>
                </div>
                <span class="clear"></span>
                <uc1:template_myprofilecriteria runat="server" ID="template_myprofilecriteria" />
                <div class="ninth_cont" id="divMyProfileCriteria" data-bind="template: { name: 'template_myprofilecriteria' }"></div>
            </div>
            <aside></aside>
            <span class="clear"></span>
        </div>
    </div>

    <script type="text/javascript">


        $(document).ready(function () {

            $("#liCriteria").addClass("active");
            var APIGET_CRITERIA = _SitePath + "api/GetMyProfileCriteriaList";

            $.getDATA(APIGET_CRITERIA, function (_data) {

              
                ko.applyBindings(new VMMyProfileCriteriaList(_data), document.getElementById("divMyProfileCriteria"));

                setTimeout(function () {
                    $(".editCriteria").click(function (e) {
                        SetIntelliWindow(this, e);
                    });

                }, 1000);

            });


            $("#btnUpdate").click(function () {

                window.location.href = _SitePath + "web/ChangePoints";
               
            });


        });

   

       


    </script>



</asp:Content>
