<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profilephotos.aspx.cs" Inherits="IntelliWebR1.web.inner.profilephotos" %>

<asp:literal id="ltScripts" runat="server"></asp:literal>
<div>
    <div id="divPhotosGrid" style="width:740px;float: left;margin-bottom:10%" data-bind="template: { name: 'template_profilephotos', foreach: GridColums }"></div>
</div>
<script type="text/html" id="template_profilephotos">
    <div style="float: left;">
        <!--ko foreach:AllPhotos-->
        <div data-bind="event: { mouseover: helpers.onMouseOver, mouseleave: helpers.onMouseLeave }">
            <div style="margin: 4px;">
                <!--ko if:IsMouseOver -->
                <div style="position: absolute;">  
                    <img data-bind="event: { click: ReportPhotoCall }" src="../../images/abuse.png" title="Report this photo" style="width: 25px; height: 25px; cursor: pointer;" class="photoThumb" />
                </div>
                <!--/ko-->
                <img data-bind="attr: { src: PhotoPath, 'data-url': EncryptPath, 'data-width': PopupWidth, 'data-height': PopupHeight, 'data-pos': Position }" style="width: 175px; cursor: pointer;" class="photoThumb" />
            </div>
        </div>
        <!--/ko-->
    </div>
</script>

