
(function ($) {
    $.postDATA = function (serviceurl, formData, successcallback, errorcallback) {
        $.ajax({
            url: serviceurl,
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            type: "POST",
            dataType: "JSON",
            data: formData,
            success: successcallback,
            error: errorcallback
        });
    };
}(jQuery));

(function ($) {
    $.getDATA = function (serviceurl, successcallback, errorcallback) {
        $.ajax({
            url: serviceurl,
            type: "GET",
            dataType: "JSON",
            success: successcallback,
            error: errorcallback
        });
    };
}(jQuery));

(function ($) {
    $.getIMAGE = function (serviceurl, successcallback, errorcallback) {
        $.ajax({
            url: serviceurl,
            type: "GET",
            success: successcallback,
            error: errorcallback
        });
    };
}(jQuery));

