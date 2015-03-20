function SetIntelliWindow(_ElementID, _click) {
    // get window width
    var _browserHeight = $(window).height();
    var _browserWidth = $(window).width();

    var _iframeWidth = $(_ElementID).data("width");
    var _iframeHeight = $(_ElementID).data("height");

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);
    _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    // Append the iframe
    var _iframe = $("<iframe class=\"intelliWindow-iFrame\"></iframe>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");

    _iframe.attr("src", $(_ElementID).data("url"));
    _iframe.attr("scrolling", "no");
    _iframe.attr("frameborder", "0");

    _intelliWindow.append(_iframe);

    if (_click != 'undefined' && _click != null) {
        _intelliWindow.css("left", _click.clientX + "px");
        _intelliWindow.css("top", _click.clientY + "px");
    }

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }



    /*_intelliWindow.css("width", _iframeWidth + "px");
    _intelliWindow.css("height", _iframeHeight + "px");

    _intelliWindow.css("left", _leftMargin + "px");
    _intelliWindow.css("top", _topMargin + "px");*/

    if (_append) {
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });
    }


    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });


}

function CloseIntelliWindow() {
    $(".intelliWindow").animate({
        top: "-1000px"
    }, 400);

    setTimeout(function () {
        $(".intelliWindow").remove();
        $(".intelliWindow-Shadow").remove();
    }, 400);

}

function SetUrlIntelliWindow(_Url, _Width, _Height) {
    // get window width
    var _browserHeight = window.innerHeight;

    var _browserWidth = window.innerWidth;

    var _iframeWidth = _Width;
    var _iframeHeight = _Height;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = 0;//eval(_browserHeight / 2) - eval(_iframeHeight / 2);

    _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    // Append the iframe
    var _iframe = $("<iframe class=\"intelliWindow-iFrame\"></iframe>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");

    _iframe.attr("src", _Url);
    _iframe.attr("scrolling", "no");
    _iframe.attr("frameborder", "0");

    _intelliWindow.append(_iframe);

    //if (_click != 'undefined' && _click != null) {
    //    _intelliWindow.css("left", _click.clientX + "px");
    //    _intelliWindow.css("top", _click.clientY + "px");
    //}

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }



    /*_intelliWindow.css("width", _iframeWidth + "px");
    _intelliWindow.css("height", _iframeHeight + "px");

    _intelliWindow.css("left", _leftMargin + "px");
    _intelliWindow.css("top", _topMargin + "px");*/

    if (_append) {
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });
    }

    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });



}

function SetIntelliWindowWithToolbar(_ElementID, _click, _photosArray, _photoPosition) {
    // get window width
    var _browserHeight = $(window).height();
    var _browserWidth = $(window).width();

    var _iframeWidth = $(_ElementID).data("width");
    var _iframeHeight = $(_ElementID).data("height");

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);
    _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    // Append the iframe
    var _iframe = $("<img class=\"intelliWindow-iFrame\" />");


    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("max-height","560px");

    _iframe.attr("src", $(_ElementID).data("url"));
    _iframe.attr("scrolling", "no");
    _iframe.attr("frameborder", "0");

    _intelliWindow.append(_iframe);

    if (_click != 'undefined' && _click != null) {
        _intelliWindow.css("left", _click.clientX + "px");
        _intelliWindow.css("top", _click.clientY + "px");
    }

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }



    /*_intelliWindow.css("width", _iframeWidth + "px");
    _intelliWindow.css("height", _iframeHeight + "px");

    _intelliWindow.css("left", _leftMargin + "px");
    _intelliWindow.css("top", _topMargin + "px");*/



    if (_append) {
        $("body").append(_intelliWindow);

        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
            $(".intelliWindowToolBar").remove();
            $(".intelliWindowClose").remove();
        });
    }
    AppendToolbars(_photosArray, _photoPosition);
}
var isProcessingArrows = false;
function AppendToolbars(_itemsArray, _itemPos) {

    //  console.log(_itemPos);
    var _toolBarDiv = $("<div class=\"intelliWindowToolBar\"></div>");
    var _toolBarClose = $("<div class=\"intelliWindowClose\"><img style=\"width:25px;height:25px;\" src=\"../images/sqclose.png\" /></div>");
    //

    var _toolBarPrev = $("<div class=\"intelliWindowToolBarPrev\"><img src=\"../images/left.png\" /></div>");
    var _toolBarNext = $("<div class=\"intelliWindowToolBarNext\"><img src=\"../images/right.png\" /></div>");
    var _toolBarText = $("<div class=\"intelliWindowToolBarText\">" + eval(_itemPos + 1) + " of " + _itemsArray.length + "</div>");

    $(_toolBarDiv).append(_toolBarPrev).append(_toolBarText).append(_toolBarNext).append(_toolBarClose);

    var _browserHeight = $(window).height();
    var _browserWidth = $(window).width();

    var _iframeWidth = 200;
    var _iframeHeight = 40;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _bottomMargin = 20;

    _toolBarDiv.css({
        width: _iframeWidth + "px",
        height: _iframeHeight + "px",
        left: _leftMargin + "px",
        bottom: _bottomMargin + "px"
    });

    $("body").append(_toolBarDiv);



    $(".intelliWindowToolBarPrev").click(function () {
        //alert("prev");
        $(".intelliWindowToolBar").remove();
        var _showPos = 0;
        if (_itemPos == 0) {
            _showPos = _itemsArray.length - 1;
        }
        else {
            _showPos = eval(_itemPos - 1);
        }
        window.parent.ShowPhotoInthisPos(_showPos);
    });

    $(".intelliWindowToolBarNext").click(function () {
        //alert("next");
        $(".intelliWindowToolBar").remove();
        var _showPos = 0;
        if (_itemPos == _itemsArray.length - 1) {
            _showPos = 0;
        }
        else {
            _showPos = eval(_itemPos + 1);
        }
        window.parent.ShowPhotoInthisPos(_showPos);
    });

    $(".intelliWindowClose").click(function () {
        $(".intelliWindow-Shadow").trigger("click");
    });
    KeyboardJS.on('left', function () {

        if (isProcessingArrows) {
            return;
        }
        isProcessingArrows = true;
        setTimeout(function () {
            $(".intelliWindowToolBarPrev").trigger("click");
            isProcessingArrows = false;
        }, 100);

    });
    KeyboardJS.on('right', function () {
        if (isProcessingArrows) {
            return;
        }
        isProcessingArrows = true;

        setTimeout(function () {
            $(".intelliWindowToolBarNext").trigger("click");
            isProcessingArrows = false;
        }, 100);
    });
    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });

}

function SetIntelliWindowWithAnim(_ElementID, _click) {
    // get window width
    var _browserHeight = $(document).height();
    var _browserWidth = $(document).width();

    var _iframeWidth = $(_ElementID).data("width");
    var _iframeHeight = $(_ElementID).data("height");

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    // Append the iframe
    var _iframe = $("<iframe class=\"intelliWindow-iFrame\"></iframe>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");

    _iframe.attr("src", $(_ElementID).data("url"));
    _iframe.attr("scrolling", "no");
    _iframe.attr("frameborder", "0");

    _intelliWindow.append(_iframe);

    if (_click != 'undefined' && _click != null) {
        _intelliWindow.css("left", _click.clientX + "px");
        _intelliWindow.css("top", _click.clientY + "px");
    }

    if (_append == true) {
        _intelliWindow.animate({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        }, 300);
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }



    /*_intelliWindow.css("width", _iframeWidth + "px");
    _intelliWindow.css("height", _iframeHeight + "px");

    _intelliWindow.css("left", _leftMargin + "px");
    _intelliWindow.css("top", _topMargin + "px");*/

    if (_append) {
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });
    }
}


//intelli confirm box
function IntelliConfirmWindow(_CinfirmString, _Width, _Height) {
    // get window width
    var _browserHeight = window.innerHeight;

    var _browserWidth = window.innerWidth;

    var _iframeWidth = _Width;
    var _iframeHeight = _Height;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);

    _topMargin = eval(_topMargin - 100);
  //  _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    //create content div

    var _MainDiv = $("<div class=\"intelliWindow-main\"></div>");

    var _ContentDiv = $("<div class=\"intelliWindow-DivContent\">" + _CinfirmString + " </div>");

    var _CloseButton = $("<div class=\"intelliClose\"><a id='imageClose' class=\"close\">x</a></div>");
    

    //create yes no buttons div

    var _YesNoDiv = $("<div class=\"intelliWindow-ButtonDiv\" ><input type='button' value='Yes'  class=\"intelliYes\" />&nbsp;<input type='button' class=\"intelliNo\" value='No'/></div>");

    // Append the iframe
    var _iframe = $("<div class=\"intelliWindow-iFrame\"> </div>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");
    _MainDiv.append(_CloseButton).append(_ContentDiv).append(_YesNoDiv);
    _intelliWindow.append(_iframe).append(_MainDiv);

    //if (_click != 'undefined' && _click != null) {
    //    _intelliWindow.css("left", _click.clientX + "px");
    //    _intelliWindow.css("top", _click.clientY + "px");
    //}

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }

  


    if (_append) {
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });


        $(".intelliYes").click(function () {
            window.parent.YesClicked();
            CloseIntelliWindow();
        });


        $(".intelliNo").click(function () {
            window.parent.NoClicked();
            CloseIntelliWindow();
        });

        $("#imageClose").click(function () {
            CloseIntelliWindow();
        });

        _callBack = function (_ret) {
            $(".intelliYes").trigger("click");
            return true;
        };
    }

    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });
}


//intelli alert box
function IntelliAlertWindow(_CinfirmString, _Width, _Height) {
    // get window width
    var _browserHeight = window.innerHeight;

    var _browserWidth = window.innerWidth;

    var _iframeWidth = _Width;
    var _iframeHeight = _Height;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);

    _topMargin = eval(_topMargin - 100);
    //  _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    //create content div

    var _MainDiv = $("<div class=\"intelliWindow-main\"></div>");

    var _ContentDiv = $("<div class=\"intelliWindow-DivContent\">" + _CinfirmString + " </div>");

    var _CloseButton = $("<div class=\"intelliClose\"><a id='imageClose' class=\"close\">x</a></div>");


    //create yes no buttons div

    var _YesNoDiv = $("<div class=\"intelliWindow-AlertButtonDiv\" ><input type='button' value='Yes'  class=\"intelliYes\" /></div>");

    // Append the iframe
    var _iframe = $("<div class=\"intelliWindow-iFrame\"> </div>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");
    _MainDiv.append(_CloseButton).append(_ContentDiv).append(_YesNoDiv);
    _intelliWindow.append(_iframe).append(_MainDiv);

    //if (_click != 'undefined' && _click != null) {
    //    _intelliWindow.css("left", _click.clientX + "px");
    //    _intelliWindow.css("top", _click.clientY + "px");
    //}

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }




    if (_append) {
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });


        $(".intelliYes").click(function () {
            CloseIntelliWindow();
        });


        $(".intelliNo").click(function () {
            CloseIntelliWindow();
        });

        $("#imageClose").click(function () {
            CloseIntelliWindow();
        });

        _callBack = function (_ret) {
            $(".intelliYes").trigger("click");
            return true;
        };
    }

    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });
}


function SetScrollIntelliWindow(_Url, _Width, _Height) {
    // get window width
    var _browserHeight = window.innerHeight;

    var _browserWidth = window.innerWidth;

    var _iframeWidth = _Width;
    var _iframeHeight = _Height;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = 0;//eval(_browserHeight / 2) - eval(_iframeHeight / 2);

    _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    // Append the iframe
    var _iframe = $("<iframe class=\"intelliWindow-iFrame\"></iframe>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");

    _iframe.attr("src", _Url);
    _iframe.attr("scrolling", "yes");
    _iframe.attr("frameborder", "0");

    _intelliWindow.append(_iframe);

    //if (_click != 'undefined' && _click != null) {
    //    _intelliWindow.css("left", _click.clientX + "px");
    //    _intelliWindow.css("top", _click.clientY + "px");
    //}

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }



    /*_intelliWindow.css("width", _iframeWidth + "px");
    _intelliWindow.css("height", _iframeHeight + "px");

    _intelliWindow.css("left", _leftMargin + "px");
    _intelliWindow.css("top", _topMargin + "px");*/

    if (_append) {
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });
    }

    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });



}


function IntelliPhotoWindow(_ElementID, _click, _photosArray, _photoPosition) {
    // get window width
    var _browserHeight = window.innerHeight;
    var _browserWidth = window.innerWidth;

    var _iframeWidth = 1008;
    var _iframeHeight = 602;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);
    _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    //create content div

    var _MainDiv = $("<div class=\"photo_showup\"></div>");
    var _toolBarLeftDiv = $("<div class=\"photoup_left\"></div>");
    var _toolBarClose = $("<div><a  class=\"close imgclose\">x</a></div>");
    var _MainImg = $("<img style=\"min-width:250px;max-width:616px;max-height:450px;min-height: 200px;\" />");
    _MainImg.attr("src", $(_ElementID).data("url"));
    var _PhotoArrows = $("<div class=\"photous_arrows\"></div>");
    var _onlyArrows = $("<div style=\"width:170px;margin:0 auto;\"></div>");
    var _toolBarPrev = $("<img class=\"photos_left_arrow\" id=\"imgPrev\" src=\"../images/popup_arrow_left.png\" />");
    var _toolBarPos = $("<p>" + eval(_photoPosition + 1) + " <span>of</span>" + _photosArray.length + "</p>");
    var _toolBarNext = $("<img class=\"photos_left_arrow\" id=\"imgNext\"  src=\"../images/popup_arrow_right.png\" />");
    var _toolBarRightDiv = $("<div class=\"photoup_right\"></div>");
    var _DisscussDiv = $("<div id=\"divDiscuss\" class=\"photoup_right\"  style=\"display:none\" ></div>");
    var _TextArea = $("<textarea id=\"txtPhotoDiscuss\" class=\"discuss\" style=\"min-height:120px;\"></textarea>");
    var _SubmitBtn = $("<input type=\"button\" id=\"btnPhotoSubmit\" value=\"Submit\"/>   <input type=\"button\" id=\"btnCancel\" value=\"Cancel\" style=\"margin-right:10px;\" />");
    var _MessageDiv = $("<div id=\"divErrorMessage\" class=\"errorMessageText\"></div>");
    var _photoTitle;
    if (_photosArray[eval(_photoPosition)].Caption != "") {
        _photoTitle = $("<p>" + _photosArray[eval(_photoPosition)].Caption + "</p>");
    }
    var _discuss = $("<img src=\"images/Discuss94.png\" id=\"btnDiscuss\" class=\"Discuss\" />");

    var _clear = $("<span class=\"clear\"></span>");

    $(_DisscussDiv).append(_TextArea).append(_SubmitBtn).append(_MessageDiv);

    $(_onlyArrows).append(_toolBarPrev).append(_toolBarPos).append(_toolBarNext);

    $(_PhotoArrows).append(_onlyArrows);

    $(_toolBarLeftDiv).append(_MainImg).append(_PhotoArrows);
    $(_toolBarRightDiv).append(_photoTitle).append(_discuss);
    $(_MainDiv).append(_toolBarClose).append(_toolBarLeftDiv).append(_toolBarRightDiv).append(_DisscussDiv).append(_clear);


    // Append the iframe
    var _iframe = $("<div class=\"intelliWindow-iFrame\"> </div>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");
    
    _iframe.append(_MainDiv);

    _intelliWindow.append(_iframe);

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }


   
        $("body").append(_intelliWindow);
        $(".intelliWindow-Shadow").click(function () {
            $(".intelliWindow").remove();
            $(".intelliWindow-Shadow").remove();
        });

        $(".imgclose").click(function () {
            CloseIntelliWindow();
        });


        $("#imgPrev").click(function () {
           // alert("prev");
            var _showPos = 0;
            if (_photoPosition == 0) {
                _showPos = _photosArray.length - 1;
            }
            else {
                _showPos = eval(_photoPosition - 1);
            }
            window.parent.ShowPhotoInthisPos(_showPos);
        });

        $("#imgNext").click(function () {
            //alert("next");
            var _showPos = 0;
            if (_photoPosition == _photosArray.length - 1) {
                _showPos = 0;
            }
            else {
                _showPos = eval(_photoPosition + 1);
            }
            window.parent.ShowPhotoInthisPos(_showPos);
        });



        $("#btnDiscuss").click(function () {
            $(this).hide();
            $("#divDiscuss").show();
        });

        $("#btnCancel").click(function () {
            $("#btnDiscuss").show();
            $("#divDiscuss").hide();
        });

        $("#btnPhotoSubmit").click(function () {
            
            var _PhotoID = _photosArray[eval(_photoPosition)].PhotoID;
            var _Photo_id = _photosArray[eval(_photoPosition)]._id;
          
            var _messageText = $("#txtPhotoDiscuss").val().trim();
            if (_messageText == "") {
                $("#divErrorMessage").html("Please enter message.");
                return;
            }
            var _ComposeAPI = _SitePath + "api/Compose";
            $("#btnPhotoSubmit").attr("disabled", "disabled");
            $("#btnPhotoSubmit").val("Please wait..");
            var _ComposeObj = new Object();
            _ComposeObj.RecipientID = window.parent._OtherUserID;
            _ComposeObj.MessageText = _messageText;
            _ComposeObj.DiscussType = 4;
            _ComposeObj.DiscussType_id = _Photo_id;
            _ComposeObj.DiscussTypeID = parseInt(_PhotoID);
            // alert(JSON.stringify(_ComposeObj));
            $.postDATA(_ComposeAPI, _ComposeObj, function (_ConversationObject) {
                if (_ConversationObject != null) {
                    $("#txtPhotoDiscuss").val("");
                    $("#btnPhotoSubmit").val("Send");
                    $("#divErrorMessage").html("Message has been sent.");
                    setTimeout(function () {
                        setTimeout(function () {
                            try {
                                window.parent.CloseIntelliWindow();
                            } catch (e) {
                                window.parent.CloseIntelliWindow();
                            }
                        }, 2000);
                    }, 2000);
                } else {
                    $("#divErrorMessage").html("You are restricted to send message until you receive a response.");
                }
            });
        });


        $(".intelliWindowClose").click(function () {
            $(".intelliWindow-Shadow").trigger("click");
        });
        KeyboardJS.on('left', function () {

            if (isProcessingArrows) {
                return;
            }
            isProcessingArrows = true;
            setTimeout(function () {
                $("#imgPrev").trigger("click");
                isProcessingArrows = false;
            }, 100);

        });
        KeyboardJS.on('right', function () {
            if (isProcessingArrows) {
                return;
            }
            isProcessingArrows = true;

            setTimeout(function () {
                $("#imgNext").trigger("click");
                isProcessingArrows = false;
            }, 100);
        });

        KeyboardJS.on('esc', function () {
            $(".intelliWindow-Shadow").trigger("click");
        });
    
}




function IntelliMyProfilePhotoWindow(_ElementID, _click, _photosArray, _photoPosition) {
    // get window width
    var _browserHeight = window.innerHeight;
    var _browserWidth = window.innerWidth;

    var _iframeWidth = 1008;
    var _iframeHeight = 602;

    var _leftMargin = eval(_browserWidth / 2) - eval(_iframeWidth / 2);
    var _topMargin = eval(_browserHeight / 2) - eval(_iframeHeight / 2);
    _topMargin = eval(eval(_browserHeight - _iframeHeight) / 2);

    var _intelliWindow;
    var _append = true;

    if ($(".intelliWindow").length) {
        $(".intelliWindow").empty();
        _intelliWindow = $(".intelliWindow");
        _append = false;
    }
    else {
        _intelliWindow = $("<div class=\"intelliWindow\"></div>");
    }

    if ($(".intelliWindow-Shadow").length <= 0) {
        var _intelliWindowShadow = $("<div class=\"intelliWindow-Shadow\"></div>");
        _intelliWindowShadow.css("width", _browserWidth + "px");
        _intelliWindowShadow.css("height", _browserHeight + "px");
        _intelliWindowShadow.css("left", "0px");
        _intelliWindowShadow.css("top", "0px");
        $("body").append(_intelliWindowShadow);
    }

    //create content div

    var _MainDiv = $("<div class=\"photo_showup\"></div>");
    var _toolBarLeftDiv = $("<div class=\"photoup_left\"></div>");
    var _toolBarClose = $("<div><a  class=\"close imgclose\">x</a></div>");
    var _MainImg = $("<img style=\"min-width:250px;max-width:616px;max-height:450px;min-height: 250px;\" />");
    _MainImg.attr("src", $(_ElementID).data("url"));

    var _PhotoArrows = $("<div class=\"photous_arrows\"></div>");
    var _onlyArrows = $("<div style=\"width:170px;margin:0 auto;\"></div>");

    var _toolBarPrev = $("<img class=\"photos_left_arrow\" id=\"imgPrev\" src=\"../images/popup_arrow_left.png\" />");
    var _toolBarPos = $("<p>" + eval(_photoPosition + 1) + " <span>of</span>" + _photosArray.length + "</p>");
    var _toolBarNext = $("<img class=\"photos_left_arrow\" id=\"imgNext\"  src=\"../images/popup_arrow_right.png\" />");
    var _toolBarRightDiv = $("<div class=\"photoup_right\"></div>");
    var _DisscussDiv = $("<div id=\"divDiscuss\" class=\"photoup_right\"  style=\"display:none\" ></div>");
    var _TextArea = $("<textarea id=\"txtPhotoCaption\" class=\"discuss\" style=\"min-height:120px;\"></textarea>");
    var _SubmitBtn = $("<input type=\"button\" id=\"btnPhotoSubmit\" value=\"Submit\"/>   <input type=\"button\" id=\"btnCancel\" value=\"Cancel\" style=\"margin-right:10px;\" />");
    var _MessageDiv = $("<div id=\"divErrorMessage\" class=\"errorMessageText\"></div>");
    var _photoTitle;
    var _AddCaption;
    var _Caption = $(_ElementID).attr("alt");
    if (_Caption != "") {
        _photoTitle = $("<p id='p" + _photosArray[eval(_photoPosition)].PhotoID + "' >" + _Caption + "</p><div class=\"editCaption UpdateCaption\"><img src=\"images/white_edit_icon.png\" ></div>");
    } else {
        _photoTitle = $("<p id='p" + _photosArray[eval(_photoPosition)].PhotoID + "'></p><div class=\"UpdateCaption\"><p>Add a caption <img src=\"images/white_edit_icon.png\" ></p></div>");
    }
    

    var _clear = $("<span class=\"clear\"></span>");

    $(_DisscussDiv).append(_TextArea).append(_SubmitBtn).append(_MessageDiv);

    $(_onlyArrows).append(_toolBarPrev).append(_toolBarPos).append(_toolBarNext);

    $(_PhotoArrows).append(_onlyArrows);

    $(_toolBarLeftDiv).append(_MainImg).append(_PhotoArrows);
    $(_toolBarRightDiv).append(_photoTitle);
    $(_MainDiv).append(_toolBarClose).append(_toolBarLeftDiv).append(_toolBarRightDiv).append(_DisscussDiv).append(_clear);


    // Append the iframe
    var _iframe = $("<div class=\"intelliWindow-iFrame\"> </div>");
    _iframe.css("width", _iframeWidth + "px");
    _iframe.css("height", _iframeHeight + "px");
    
    _iframe.append(_MainDiv);

    _intelliWindow.append(_iframe);

    if (_append == true) {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }
    else {
        _intelliWindow.css({
            width: _iframeWidth + "px",
            height: _iframeHeight + "px",
            left: _leftMargin + "px",
            top: _topMargin + "px"
        });
    }


   
    $("body").append(_intelliWindow);
    $(".intelliWindow-Shadow").click(function () {
        $(".intelliWindow").remove();
        $(".intelliWindow-Shadow").remove();
    });

    $(".imgclose").click(function () {
        CloseIntelliWindow();
    });


    $("#imgPrev").click(function () {
        // alert("prev");
        var _showPos = 0;
        if (_photoPosition == 0) {
            _showPos = _photosArray.length - 1;
        }
        else {
            _showPos = eval(_photoPosition - 1);
        }
        window.parent.ShowPhotoInthisPos(_showPos);
    });

    $("#imgNext").click(function () {
        //alert("next");
        var _showPos = 0;
        if (_photoPosition == _photosArray.length - 1) {
            _showPos = 0;
        }
        else {
            _showPos = eval(_photoPosition + 1);
        }
        window.parent.ShowPhotoInthisPos(_showPos);
    });



    $(".UpdateCaption").click(function () {
        var _PhotoID = _photosArray[eval(_photoPosition)].PhotoID;
        $(this).hide();
        $("#divDiscuss").show();
        $("#txtPhotoCaption").val(_Caption);
        $("#p" + _PhotoID).hide();
    });

    $("#btnCancel").click(function () {
        var _PhotoID = _photosArray[eval(_photoPosition)].PhotoID;
        $(".UpdateCaption").show();
        $("#p" + _PhotoID).show();
        $("#divDiscuss").hide();
    });

    $("#btnPhotoSubmit").click(function () {
            
        var _PhotoID = _photosArray[eval(_photoPosition)].PhotoID;
       
          
        var _PhotoCaption = $("#txtPhotoCaption").val().trim();
        if (_PhotoCaption == "") {
            $("#divErrorMessage").html("Please enter caption.");
            return;
        }
        var _PhotoCaptionAPI = _SitePath + "api/AddCaption";
        $("#btnPhotoSubmit").attr("disabled", "disabled");
        $("#btnPhotoSubmit").val("Please wait..");
        var _CaptionObj = new Object();
        _CaptionObj.PhotoID = parseInt(_PhotoID);
        _CaptionObj.Caption = _PhotoCaption;
       
        $.postDATA(_PhotoCaptionAPI, _CaptionObj, function (_ReturnObject) {
            if (_ReturnObject != null) {
                $("#txtPhotoCaption").val("");
                $("#btnPhotoSubmit").val("Submit");
              //  $("#divErrorMessage").html("Your caption added successfully.");              
                //set caption to data-caption
                $("#p" + _PhotoID).show();
                $("#p" + _PhotoID).text(_PhotoCaption);
                SetPhotoCaptionTemp(_photoPosition, _PhotoCaption);
                //$(_ElementID).attr("data-caption", _PhotoCaption);
                _Caption = _PhotoCaption;
                            $("#btnPhotoSubmit").removeAttr("disabled");

                            if ($(".UpdateCaption").hasClass("editCaption")) {
                                $(".UpdateCaption").show();
                            } else {
                                $(".UpdateCaption").html("<img src=\"images/white_edit_icon.png\" >");
                                $(".UpdateCaption").addClass("editCaption")
                                $(".UpdateCaption").show();
                            }

                            
                            $("#divDiscuss").hide();
                            $("#divErrorMessage").html("");
            }
        });
    });


    $(".intelliWindowClose").click(function () {
        $(".intelliWindow-Shadow").trigger("click");
    });
    KeyboardJS.on('left', function () {

        if (isProcessingArrows) {
            return;
        }
        isProcessingArrows = true;
        setTimeout(function () {
            $("#imgPrev").trigger("click");
            isProcessingArrows = false;
        }, 100);

    });
    KeyboardJS.on('right', function () {
        if (isProcessingArrows) {
            return;
        }
        isProcessingArrows = true;

        setTimeout(function () {
            $("#imgNext").trigger("click");
            isProcessingArrows = false;
        }, 100);
    });

    KeyboardJS.on('esc', function () {
        $(".intelliWindow-Shadow").trigger("click");
    });
    
}
