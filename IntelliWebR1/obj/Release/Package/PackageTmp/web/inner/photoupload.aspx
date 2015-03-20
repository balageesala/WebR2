<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photoupload.aspx.cs" Inherits="IntelliWebR1.web.inner.photoupload" %>
<asp:literal id="ltScripts" runat="server"></asp:literal>
<form enctype="multipart/form-data" method="post" id="frmPhotoUpload">
    <div class="divUploadPics" id="divUploadPics" runat="server">
        <div>
            <div class="divpHeader">Upload your photo using bellow options</div>
            <div class="divpsection">Upload your photos from the below social sites or upload your pictures from my computer hard drive. </div>
        </div>
        <div class="divpcontainer">
            <div class="divprow1" style="border: 0px solid;">
                <div class="divgdrive" id="btngoogle">
                    <div style="width: 80px; height: 120px; z-index: 0;">
                        <img src="images/icon-googledrive.png" id="" style="width: 80px; height: 80px;" class="MarginIcon" />
                    </div>
                    <div class="dvcurvegdrive" style="position: absolute; z-index: 10;">&nbsp;</div>
                </div>
                <div class="divgdrive" id="btnonedrive">
                    <div style="width: 80px; height: 120px; z-index: 0;">
                        <img src="images/icon-onedrive.png" style="width: 80px; height: 80px;" class="MarginIcon" />
                    </div>
                    <div class="dvcurvegdrive" style="position: absolute; z-index: 10;">&nbsp;</div>
                </div>
            </div>
            <div class="divprow1" style="border: 0px solid;">
                <div class="divgdrive" id="btndropbox">
                    <div style="width: 80px; height: 120px; z-index: 0;">
                        <img src="images/icon-dropbox.png" style="width: 80px; height: 80px;" class="MarginIcon" />

                    </div>
                    <div class="dvcurvegdrive" style="position: absolute; z-index: 10;">&nbsp;</div>
                </div>
                <div class="divgdrive" id="btnfacebook">
                    <div style="width: 80px; height: 120px; z-index: 0;">
                        <img src="images/icon-facebook.png" style="width: 80px; height: 80px;" class="MarginIcon" />
                    </div>
                    <div class="dvcurvegdrive" style="position: absolute; z-index: 10;">&nbsp;</div>
                </div>
            </div>
            <div class="divprow1" style="border: 0px solid;">
                <div class="divgdrive" id="btninstagram">
                    <div style="width: 80px; height: 120px; z-index: 0;">
                        <img src="images/icon-instagram.png" style="width: 80px; height: 80px;" class="MarginIcon" />
                        <a id="lnkInstagram" runat="server" data-width="332" data-height="480"></a>
                    </div>
                    <div class="dvcurvegdrive" style="position: absolute; z-index: 10;">&nbsp;</div>
                </div>
                <div class="divgdrive" id="btnBrowse" runat="server" data-width="700" data-height="500">
                    <div style="width: 80px; height: 120px; z-index: 0;">
                        <img src="images/icon-harddisk.png" style="width: 80px; height: 80px;" class="MarginIcon" />

                    </div>
                    <div class="dvcurvegdrive" style="position: absolute; z-index: 10;">&nbsp;</div>
                </div>
                <input type="file" id="flBrowse" style="display: none;" multiple="multiple" accept="image/x-png, image/gif, image/jpeg" />
            </div>
        </div>
        <div style="clear: both;"></div>
        <!-- Markup for Carson Shold's Photo Selector -->
        <div id="CSPhotoSelector">
            <div class="CSPhotoSelector_dialog">
                <a href="#" id="CSPhotoSelector_buttonClose">x</a>
                <div class="CSPhotoSelector_form">
                    <div class="CSPhotoSelector_header">
                        <p>Choose from Photos</p>
                    </div>
                    <div class="CSPhotoSelector_content CSAlbumSelector_wrapper">
                        <p>Browse your albums until you find a picture you want to use</p>
                        <div class="CSPhotoSelector_searchContainer CSPhotoSelector_clearfix">
                            <div class="CSPhotoSelector_selectedCountContainer">Select an album</div>
                        </div>
                        <div class="CSPhotoSelector_photosContainer CSAlbum_container"></div>
                    </div>
                    <div class="CSPhotoSelector_content CSPhotoSelector_wrapper">
                        <p>Select a new photo</p>
                        <div class="CSPhotoSelector_searchContainer CSPhotoSelector_clearfix">
                            <div class="CSPhotoSelector_selectedCountContainer"><span class="CSPhotoSelector_selectedPhotoCount">0</span> / <span class="CSPhotoSelector_selectedPhotoCountMax">0</span> photos selected</div>
                            <a href="#" id="CSPhotoSelector_backToAlbums">Back to albums</a>
                        </div>
                        <div class="CSPhotoSelector_photosContainer CSPhoto_container"></div>
                    </div>
                    <div id="CSPhotoSelector_loader"></div>
                    <div class="CSPhotoSelector_footer CSPhotoSelector_clearfix">
                        <a href="#" id="CSPhotoSelector_pagePrev" class="CSPhotoSelector_disabled">Previous</a>
                        <a href="#" id="CSPhotoSelector_pageNext">Next</a>
                        <div class="CSPhotoSelector_pageNumberContainer">
                            Page <span id="CSPhotoSelector_pageNumber">1</span> / <span id="CSPhotoSelector_pageNumberTotal">1</span>
                        </div>
                        <a href="#" id="CSPhotoSelector_buttonOK">OK</a>
                        <a href="#" id="CSPhotoSelector_buttonCancel">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
        <div id="instafeed" style="display: none;"></div>
        <div class="instagramImages">
            <span style="width: 100%; float: left;">
                <input type="button" value="Submit" id="btnInstaSelect" style="float: left;" />
            </span>
            <div class="divinstagramImages" id="divinstagramImages"></div>
        </div>
    </div>

    <div id="divPhotoValdation" runat="server" visible="false" style="color:#fff;text-align:center;margin-top:50px;">

        Your photo upload limit is reached.

    </div>



</form>
