$(document).ready(function () {
    $(window).bind('scroll', function (e) {
        parallaxScroll();
    });
});

function parallaxScroll() {
    var scrolled = $(window).scrollTop();
    $('.video-container-video').css('top', (0 + (scrolled * .5)) + 'px');
}