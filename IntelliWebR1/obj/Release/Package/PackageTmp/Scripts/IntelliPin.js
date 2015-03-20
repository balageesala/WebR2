function GetFiveColumnGrid(_AllPhotos, margin) {
    var _ListOfColumns = new Array();
    var _EachColumn = new Object();

    for (var i = 0; i < 5; i++) {
        _EachColumn = new Object();
        _EachColumn.Photos = new Array();
        _EachColumn.TotalHeight = 0;
        _ListOfColumns.push(_EachColumn);
    }

    //console.log(_AllPhotos);

    for (var i = 0; i < _AllPhotos.length; i++) {
        AddPhotoInTheSmallestColumn(_AllPhotos[i], _ListOfColumns, margin);
    }
    return _ListOfColumns;
}


function GetFourColumnGrid(_AllPhotos, margin) {
    var _ListOfColumns = new Array();
    var _EachColumn = new Object();

    for (var i = 0; i < 4; i++) {
        _EachColumn = new Object();
        _EachColumn.Photos = new Array();
        _EachColumn.TotalHeight = 0;
        _ListOfColumns.push(_EachColumn);
    }

    for (var i = 0; i < _AllPhotos.length; i++) {
        AddPhotoInTheSmallestColumn(_AllPhotos[i], _ListOfColumns, margin);
    }
    return _ListOfColumns;
}

function AddPhotoInTheSmallestColumn(_Photo, _AllColumns, margin) {
    var _sortedArray = _.sortBy(_AllColumns, function (o) { return eval(o.TotalHeight); })
    var _leastHeighted = _sortedArray[0];
    _leastHeighted.Photos.push(_Photo);
    //console.log(eval(_Photo.Height));
    _leastHeighted.TotalHeight = eval(eval(_leastHeighted.TotalHeight) + eval(_Photo.Height) + eval(margin));
    
}