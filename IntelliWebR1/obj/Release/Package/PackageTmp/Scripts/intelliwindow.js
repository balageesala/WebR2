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