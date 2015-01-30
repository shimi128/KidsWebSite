(function ($) {
    'use strict';

    $(function () {
        var $iframe, $url, $game, $preloader,$iframeWidth,$iframeHeight;

        function setIframe() {
            $iframe.css('display', 'none');
            var width = isNaN(parseInt($iframeWidth)) ? 640 : $iframeWidth;
            var height = isNaN(parseInt($iframeHeight)) ? 480 : $iframeHeight;
            $iframe.attr({ src: $url, id: "game_frame", name: "game_frame", width: width, height: height, align: "middle", scrolling: "No", frameborder: "0" });
            $iframe.appendTo($game);
        };

        function iframeLoad(data) {
            $preloader.fadeOut('slow', function() {
                $preloader.hide();
                $iframe.fadeIn('slow');
            });
           
        };


        function init() {
            $game = $('#game');
            $preloader = $(".loading-img");
            $url = $game.data('url');
            $iframeWidth = $game.data('width');
            $iframeHeight = $game.data('height');
            $iframe = $('<iframe>');
            setIframe();
            $iframe.load(iframeLoad);
        };

        init();
    });
})(jQuery);


//$("#game").load("http://www.knowledgeadventure.com/games/blind-spot/", function (response, status, xhr) {
//     if (status == "error") {
//         var msg = "Sorry but there was an error: ";
//         alert(msg + xhr.status + " " + xhr.statusText);
//     }
//});

//    $.ajax({
//        url: "http://google.com",
//        cach: false,
//        async: true,
//        xhrFields: {
//            withCredentials: true
//        }
//    }).done(function (html) {
//        $("#game").append(html);
//    })
//        .fail(function () {
//            alert("error");
//        })
//        .success(function (xhr) {
//            console.log(xhr);
//        })
//    .always(function () {
//        alert("complete");
//    });

