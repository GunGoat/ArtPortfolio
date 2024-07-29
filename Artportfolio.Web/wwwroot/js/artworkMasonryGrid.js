$(document).ready(function () {
    var filterOptions = $('#filterOptions');
    var sortBy = filterOptions.data('sort-by');
    var timeSpan = filterOptions.data('timespan');
    var searchQuery = filterOptions.data('search-query');
    var currentPage = 0;
    var loading = false;

    // Define the grid items
    var $grid = $('.grid').masonry({
        itemSelector: '.grid-item',
        columnWidth: '.grid-sizer',
        percentPosition: true,
        transitionDuration: 0 // Disable default animation
    });

    // Load items when the images have finished loading
    $grid.imagesLoaded().progress(function () {
        $grid.masonry('layout');
    });



    // Function to load more items
    function loadMoreItems(page) {
        $.get('/Artwork/LoadMoreArtworks', { page: page, sortBy: sortBy, timeSpan: timeSpan, searchQuery: searchQuery }, function (data) {
            if (data.length === 0) {
                // No more items to load
                return;
            }

            // Create HTML for new items
            var $items = $(data.map(function (item) {
                return `<div class="grid-item visible" style="cursor: pointer;" data-artwork-id="${item.id}">
                            <div class="img-container">
                                <img src="${item.imageUrl}" alt="${item.title}"/>
                            </div>
                            <div class="grid-item-overlay">
                                <div class="overlay-row">
                                    <div class="title" title="${item.title}">${item.title}</div>
                                    <div class="text">${item.price} kr</div>
                                </div>
                                <div class="overlay-row">
                                    <a class="text highlight" href="#">${item.artistFullName}</a>
                                    <div class="text">${new Date(item.creationDate).toLocaleDateString('en-US', { month: 'long', day: 'numeric', year: 'numeric' })}</div>
                                </div>
                            </div>
                        </div>`;
            }).join(''));

            // Append new items to the grid and re-layout Masonry
            $grid.append($items)
                .masonry('appended', $items)
                .imagesLoaded(function () {
                    $grid.masonry('layout');
                    loading = false; // Set loading to false after layout is done
                });

        // Increase page number for next load
        currentPage++;
        }).fail(function () {
            loading = false; // Ensure loading is reset if the request fails
        });
    }



    // Initial call 
    loadMoreItems(currentPage);
    // Call loadMoreItems when scrolling near the bottom of the page
    $(window).scroll(function () {
        if (loading) {
            return; // Exit if already loading
        }

        if ($(window).scrollTop() >= $(document).height() - $(window).height() - 10) {
            loading = true; // Set loading to true before starting request
            loadMoreItems(currentPage);
        }
    });
});
