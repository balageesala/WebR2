function VMPhoto(_in, _position) {
    var self = this;
    self._id = ko.observable(_in._id);
    self.PhotoID = ko.observable(_in.PhotoID);
    self.UserID = ko.observable(_in.UserID);
    self.PhotoSize = ko.observable(_in.PhotoSize);
    self.PhotoPath = ko.observable(_in.PhotoPath);
    self.IsDefaultUserPhoto = ko.observable(_in.IsDefaultUserPhoto);
    self.Width = ko.observable(_in.Width);
    self.Height = ko.observable(_in.Height);
    self.Caption = ko.observable(_in.Caption);
    self.Status = ko.observable(_in.Status);
    self.PhotoCropDetails = ko.observable(_in.PhotoCropDetails);
    self.Position = ko.observable(_position);
    self.EncryptPath = ko.observable(_in.EncryptPath);
    self.IsMouseOver = ko.observable(false);
   
    self.toggle = function () {
        self.IsMouseOver(!self.IsMouseOver());
    }

    window.helpers = {
        onMouseOver: function onMouseOver(data, event) {
            var $el = $(event.target);
            data.IsMouseOver(true);
        },
        onMouseLeave: function onMouseLeave(data, event) {
            var $el = $(event.currentTarget);
            data.IsMouseOver(false);
        }
    }
    
    self.DivBoxStyle = ko.computed(function () {
        var _style = "";
        _style = "width:" + self.Width() + "px; height:" + self.Height() + "px;";
        return _style;
    }, this);

    self.PopupWidth = ko.observable(0);
    self.PopupHeight = ko.observable(0);

    self.CalculateDimensions = ko.computed(function () {
        var _photodetails = new Object();
        _photodetails.PhotoID = self.PhotoID();
        var _photoDimensionApi = _SitePath + "api/CalculateDimensions";

        $.postDATA(_photoDimensionApi, _photodetails, function (_return) {
            self.PopupWidth(_return.Width);
            self.PopupHeight(_return.Height);
        });

    }, this);

    self.PhotoFullView = ko.computed(function () {
        return _SitePath + "web/inner/photofullview?pid=" + self.PhotoID();
    }, this);

   

}

function VMPhotoList(_list) {
    var self = this;
    self.AllPhotos = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllPhotos.push(new VMPhoto(_list[i], _pos));
        _pos = _pos + 1;
    }





}

var _pos = 0;
function GridColumn(_list) {
    var self = this;
    self.AllPhotos = ko.observableArray();
    for (var i = 0; i < _list.Photos.length; i++) {
        self.AllPhotos.push(new VMPhoto(_list.Photos[i], _pos));
        _pos = _pos + 1;
    }
 }


function VMIntelliPinGrid(_listOfColumns) {
    var self = this;
    self.GridColums = ko.observableArray();

    for (var i = 0; i < _listOfColumns.length; i++) {
        self.GridColums.push(new GridColumn(_listOfColumns[i]));
    }


    ReportPhotoCall = function (_data) {
     
        var _reportUrl = _SitePath + "web/inner/reportphoto?pid=" + _data.PhotoID() + "&path="+_data.PhotoPath();
        SetUrlIntelliWindow(_reportUrl, "700", "330");


    }

    ShowLinks = function (_data) {
        _data.IsMouseOver(true);
    }

    hideLinks = function (_data) {
        _data.IsMouseOver(false);
    }



}

$(document).ready(function () {
    var _api = _SitePath + "api/GetOtherUserPhotos";
    var _postData = new Object();
    var _PathName = window.location.href;
    var _LoginName = _PathName.split('?')[1].split('#')[0];


    _postData.LoginName = _LoginName;

    $.postDATA(_api, _postData, function (_return) {

        var _noData = JSON.stringify(_return).trim();
        
        if (_noData == "[]" || _return == "") {
            $("#divPhotosGrid").html(" &nbsp;&nbsp; No photos find.");
            return;
        }

        _return = SetImageGridRelativeHeight(_return);

        var _listOfColumns = GetFourColumnGrid(_return, 4);
        ko.applyBindings(new VMIntelliPinGrid(_listOfColumns), document.getElementById("divPhotosGrid"));

        $(".photoThumb").click(function (e) {
            SetIntelliWindowWithToolbar(this, e, _return, $(this).data("pos"));
        });

    });
});

function SetImageGridRelativeHeight(_allPhotos) {
    
    for (var i = 0; i < _allPhotos.length; i++) {

        var _currentWidth = _allPhotos[i].Width;
        var _currentHeight = _allPhotos[i].Height;

        var _calculatedHeight = eval((_currentHeight * 240) / _currentWidth);

        _allPhotos[i].Height = _calculatedHeight;
    }

    return _allPhotos;
}

function ShowPhotoInthisPos(_pos) {
    $(".photoThumb").each(function (_p, _obj) {
        if ($(_obj).data("pos") == _pos) {
            $(_obj).trigger("click");
        }
    });
}