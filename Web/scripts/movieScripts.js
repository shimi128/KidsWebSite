(function ($) {
    'use strict';

        $(function () {

            //Load player api asynchronously.
            var $openPopup, $closeVideo, $tag, $videoId, $player, $movieDiv;

            function start() {
                $tag.src = "https://www.youtube.com/iframe_api";
                var firstScriptTag = document.getElementsByTagName('script')[0];
                firstScriptTag.parentNode.insertBefore($tag, firstScriptTag);
            }

            function onYouTubeIframeAPIReady() {

                $player = new YT.Player('player', {
                    height: '315',
                    width: '420',
                    videoId: $videoId
                });
            }


            function stopVideo() {
                $player.stopVideo();
            }
            function playVideo() {
                $player.playVideo();
            }
            function openMovie() {
                $movieDiv.css("display", "block");
                playVideo();
            }


            function closeMovie() {
                $movieDiv.css("display", "none");
                stopVideo();
            }

            function init() {
                $openPopup = $('.btnMovie');
                $closeVideo = $('.closePopup');
                $tag = document.createElement('script');
                $videoId = $(".movieInner").attr("data-videoId");
                $movieDiv = $('#movieDiv');

                $openPopup.click(openMovie);
                $closeVideo.click(closeMovie);

                start();
            }

            init();
            window.onYouTubeIframeAPIReady = onYouTubeIframeAPIReady;
        });
})(jQuery);