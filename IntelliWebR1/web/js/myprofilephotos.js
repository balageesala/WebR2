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
    self.IsMouseOver = ko.observable(false);
    self.IsApproved = ko.observable(_in.IsApproved);
    self.AcceptCount = ko.observable(_in.AcceptCount);
    self.EncryptPath = ko.observable(_in.EncryptPath);
    
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

    self.ReviewText = ko.computed(function () {
        if (self.IsApproved()) {
            return "";
        } else if (self.AcceptCount() == -1) {
            return "SORRY, THIS PHOTO IS REJECTED.";
        }else{
            return "PENDING REVIEW";
        }
    }, this);

    self.MakeCoverText = ko.computed(function () {
        if (self.IsDefaultUserPhoto()) {
            return "Edit profile photo";
        } else {
            return "Make profile photo";
        }
    }, this);
    

    self.AprovedMouseOver = ko.computed(function () {
        if (self.IsApproved() && self.IsMouseOver()) {
            return true;
        } else {
            return false;
        }
    }, this);

    self.NotAprovedMouseOver = ko.computed(function () {
        if (!self.IsApproved() && self.IsMouseOver()) {
            return true;
        } else {
            return false;
        }
    }, this);


    self.Position = ko.observable(_position);
}
var _pos = 0;
function VMPhotoList(_list) {
    var self = this;
    self.AllPhotos = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllPhotos.push(new VMPhoto(_list[i], _pos));
        _pos = _pos + 1;
    }

    ShowLinks = function (_data) {
        _data.IsMouseOver(true);
    }

    hideLinks = function (_data) {
        _data.IsMouseOver(false);
    }

}

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

    DeletePhotoCall = function (_data) {
        if (confirm("Are you sure you want to delete?")) {
            var _DeletePhotObject = new Object();
            _DeletePhotObject.PhotoID = _data.PhotoID();
            var _DeletePhotoAPI = _SitePath + "api/DeletePhoto";

            $.postDATA(_DeletePhotoAPI, _DeletePhotObject, function (_return) {
                if (_return) {
                    window.location.reload();
                }

            });
        }

    }

    MakeCoverPhoto = function (_data) {

        var _cropPhotoUrl = _SitePath + "web/inner/makeascoverphoto?pid=" + _data.PhotoID();
        SetUrlIntelliWindow(_cropPhotoUrl, "1020", "630");


    }

    ShowLinks = function (_data) {
        _data.IsMouseOver(true);
    }

    hideLinks = function (_data) {
        _data.IsMouseOver(false);
    }


    RebindGrid = function () {

        var _api = _SitePath + "api/GetPhotos";
        $.getDATA(_api, function (_return) {
            var _listOfColumns = GetFiveColumnGrid(_return, 4);

            self.GridColums.removeAll();
            for (var i = 0; i < _listOfColumns.length; i++) {
                self.GridColums.push(new GridColumn(_listOfColumns[i]));
            }

            $(".photoThumb").click(function (e) {
            // SetIntelliWindowWithToolbar(this, e, _return, $(this).data("pos"));
                IntelliMyProfilePhotoWindow(this, e, _return, $(this).data("pos"));
            });


        });
    }


}

$(document).ready(function () {
    var _api = _SitePath + "api/GetPhotos";
    $.getDATA(_api, function (_return) {
        if (_return != "") {
            var _listOfColumns = GetFourColumnGrid(_return, 4);
            ko.applyBindings(new VMIntelliPinGrid(_listOfColumns), document.getElementById("divPhotosGrid"));

            $(".photoThumb").click(function (e) {
              //  SetIntelliWindowWithToolbar(this, e, _return, $(this).data("pos"));
                IntelliMyProfilePhotoWindow(this, e, _return, $(this).data("pos"));
            });
        } else {
            $("#divPhotosGrid").css("text-align", "center");
            $("#divPhotosGrid").html("No photos has been uploaded, please upload photos.");
        }
    }, function () { });
});

function ShowPhotoInthisPos(_pos) {
    $(".photoThumb").each(function (_p, _obj) {
        if ($(_obj).data("pos") == _pos) {
            $(_obj).trigger("click");
        }
    });
}


function SetPhotoCaptionTemp(_pos, caption) {
    $(".photoThumb").each(function (_p, _obj) {
        if ($(_obj).data("pos") == _pos) {
            $(_obj).attr("alt", caption);
        }
    });
}