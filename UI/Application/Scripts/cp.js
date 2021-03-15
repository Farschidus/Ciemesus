
$(document).ready(function () {
    // Create variables (in this case two arrays) representing our bubbles and pages 
    var MenuItem = $('.MenuItem');
    var Desc = $('.Desc');

    // Set bubbles opacity to zero so they're hidden initially
    Desc.css('opacity', '0');
    // and toggle visibility on for their container back on  
    $('#Desc').css('display', 'block')

    // Add our events to the pages 
    MenuItem.each(function (i, el) {
        $(el).bind({
            'mouseenter': function () {
                $(Desc[i]).stop().animate({ opacity: 1, top: '40' }, 1000);
            },
            'mouseleave': function () {
                $(Desc[i]).stop().animate({ opacity: 0, top: '60' }, 1000);
            }
        });

    });

    $('span#StartButton').click(function () {
        if ($('#StartMenu').is(':hidden'))
            $('#StartMenu').stop().show('slide', { direction: 'down' }, 'slow');       
        else
            $('#StartMenu').stop().hide('slide', { direction: 'down' }, 'slow');        
    });

    $('html').click(function () {
        if (!$('#StartMenu').is(':hidden')) {
            $('#StartMenu').stop().hide('slide', { direction: 'down' }, 'slow');
        }
    });
    $('#StartMenu').click(function (event) {
        event.stopPropagation();
    });

    $('span#StartButton').click(function (event) {
        event.stopPropagation();
    });

    buildThumbs($('.StartMenu'));
});

function buildThumbs($elem) {
    var $wrapper = $elem;
    var inactiveMargin = 50;

    /* when moving the mouse up or down, the wrapper moves (scrolls) up or down */
    $wrapper.bind('mousemove', function (e) {
        var canvas = 1100 - 500;
        var viewport = 379;
        var mousePosition = e.pageY - $wrapper.offset().top;

        var top = (canvas / viewport) * mousePosition;
        $wrapper.scrollTop(top);
    });
}

//  TODO:  Set CSS .StartMenu min-Height then get the actual height of .StartMenu after data-binding
//         move the div as the mouse move in the acurate steps.