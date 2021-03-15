
/* ------------------------------------------------------------------------
PersianGarden
	
Developped By: Farshid A. Ghavanini -> http://www.farschidus.com/
Version: 1.0
File Created: September 3, 2012
	
Copyright: Feel free to redistribute the script/modify it, as
long as you leave my infos at the top.
------------------------------------------------------------------------- */

(function ($) {
    $.fn.extend({
        persianGarden: function (options) {
            var defaults = {
                speed: 'slow'
            };
            var options = $.extend(defaults, options);

            init = function (target) {
                target.find('ul li').hover(function () {
                    $(this).find('div').stop().animate({ height: 100 }, options.speed);
                    $(this).find('span').stop().animate({ opacity: 1 }, options.speed);
                },
                function () {
                    $(this).find('div').stop().animate({ height: 275 }, options.speed);
                    $(this).find('span').stop().animate({ opacity: 0 }, options.speed);
                });
            };

            return this.each(function () {
                var obj = $(this);
                init(obj);
            });
        }
    });
})(jQuery);  