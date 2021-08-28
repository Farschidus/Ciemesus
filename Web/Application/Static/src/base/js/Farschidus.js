var Farschidus = {
    confirmDelete: function confirmDelete(element, message, buttons) {
        $.prompt(message, {
            submit: function (o, v, m) {
                if (v) { document.location.href = element.href; } else { return; }
            },
            zIndex: 2000,
            buttons: buttons
        });
        return false;
    },

    tooltip: function tooltip(element) {
        $(element).contents("div:last-child").css({ position: "absolute" });
        $(element).hover(function () { $(this).contents("div:last-child").show() }, function () { $(this).contents("div:last-child").hide() });
    },

    jsonToString: function jsonToString(json) {
        return JSON.stringify(json).replace(/}/g, '').replace(/{/g, '');
    },

    getRequestParam: function getRequestParam() {
        var urlParams = {};
        var e,
        a = /\+/g,  // Regex for replacing addition symbol with a space
        r = /([^&;=]+)=?([^&;]*)/g,
        d = function (s) { return decodeURIComponent(s.replace(a, " ")); },
        q = window.location.search.substring(1);

        while (e = r.exec(q))
            urlParams[d(e[1])] = d(e[2]);
        return urlParams;
    }
}

jQuery.fn.horizentalCenter = function () {
    this.css("left", ($(window).width() - this.width()) / 2 + $(window).scrollLeft() + "px");
    return this;
}

var timer;
function closeNotification() {
    $('.Notification').removeClass('notyEffect');
}