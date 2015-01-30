(function ($) {
    'use strict';

    $(function () {

        var $tabs, $newsImages, $search, $searchBtn,$searchForm;

        $('.fancybox').click(function (e) {
            e.preventDefault();
            $.fancybox.open($(this).attr('href'), $(this).data());
        });

        function tabClick(event) {
            event.preventDefault();
            var index = $(this).index();
            $newsImages = $('li[data-image]');
            var $currentImage = $newsImages.closest('.newsImage');
            if ($tabs.eq(index).hasClass('active')) {
                return;
            }
            $currentImage.fadeOut(200, function () {
                $currentImage.removeClass('newsImage');
                $tabs.removeClass('active');
                $tabs.eq(index).addClass('active');
            });
            $newsImages.eq(index).addClass('newsImage').fadeIn(200);
          

        }

        function searchTooltip() {
            $search.tooltip({
                title: 'מינימום 3 תווים',
                html: false,
                placement: 'bottom',
                trigger: 'manual'
            });
        }

        function validSearchForm() {
            if (!$searchForm.valid()) {
                $search.tooltip('show');
                setTimeout(function() { $search.tooltip('hide'); }, 3000);
            }
        }

        function init() {
            $tabs = $('li[data-tab]');
            $newsImages = $('li[data-image]');
            $search = $('#search');
            $searchBtn = $('#searchBtn');
            $searchForm = $('#search-site');

            searchTooltip();
            $tabs.click(tabClick);
            $searchBtn.on('click', validSearchForm);
        }

        init();
    });
})(jQuery);


$(document).ready(function () {
    $('a.back').click(function () {
        parent.history.back();
        return false;
    });
});