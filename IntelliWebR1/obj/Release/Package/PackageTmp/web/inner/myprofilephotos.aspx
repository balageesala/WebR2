<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myprofilephotos.aspx.cs" Inherits="IntelliWebR1.web.inner.myprofilephotos" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div>
    <div id="divPhotosGrid" data-bind="template: { name: 'template_myprofilephotos', foreach: GridColums }"></div>
</div>
<script type="text/html" id="template_myprofilephotos">
    <div style="float: left;margin-left:0px;">
        <!--ko foreach:AllPhotos-->
        <div data-bind="event: { mouseover: helpers.onMouseOver, mouseleave: helpers.onMouseLeave }">
            <div style="margin: 2px;border:1px solid #ccc;">
                <img data-bind="attr: { src: PhotoPath, 'data-url': PhotoFullView, 'data-width': PopupWidth, 'data-height': PopupHeight, 'data-pos':  Position }" style="width: 174px;min-height:80px; cursor: pointer;" class="photoThumb" />   
                <div style="color: #000;font-size:10px;text-align:center;width: 172px; " data-bind="text:ReviewText "> </div>
                <!--ko if:AprovedMouseOver -->
                <div style="float: left; width: 10%; background: #fff; position: absolute; margin-top: -60px; font-size: 14px; opacity: 0.7; margin-left: 10px; border-radius: 4px 4px; padding: 4px;">
                    <div style="cursor: pointer; color: #000;" data-bind="event: { click: DeletePhotoCall }">Delete   </div>
                    <div style="height: 4px;">&nbsp;   </div>
                    <div style="cursor: pointer; color: #000;" data-bind="event: { click: MakeCoverPhoto } , text:MakeCoverText" > </div>
                </div>
                <!--/ko-->
                <!--ko if : NotAprovedMouseOver-->
                <div style="float: left; width: 8%; background: #fff; position: absolute; margin-top: -60px; font-size: 14px; opacity: 0.7; margin-left: 10px; border-radius: 4px 4px; padding: 4px;">
                    <div style="cursor: pointer; color: #000;" data-bind="event: { click: DeletePhotoCall }">Delete   </div>
                </div>
                <!--/ko-->

            </div>
        </div>
        <!--/ko-->
    </div>
</script>

<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>