﻿var filterOptions = $('#filterOptions');
var sortBy = filterOptions.data('sort-by');
var timeSpan = filterOptions.data('timespan');
var searchQuery = filterOptions.data('search-query');

// Initialize Masonry grid
var $grid = $('.grid').masonry({
    itemSelector: '.grid-item',       // Class selector for grid items
    columnWidth: '.grid-sizer',       // Class selector for column width
    percentPosition: true,            // Use percentage-based widths
    transitionDuration: 0             // Disable default animation
});

// Retrieve Masonry instance
var msnry = $grid.data('masonry');

// Flag to prevent multiple simultaneous requests
var isLoading = false;

// Initialize Infinite Scroll
$grid.infiniteScroll({
    path: function () {
        isLoading = true; // Set flag to true when starting to load
        return `/Artwork/LoadMoreArtworks?page=${this.pageIndex}&sortBy=${encodeURIComponent(sortBy)}&timeSpan=${encodeURIComponent(timeSpan)}&searchQuery=${encodeURIComponent(searchQuery)}`;
    },
    responseBody: 'json',             // Expect JSON response
    outlayer: msnry,                  // Use Masonry for layout
    status: '.page-load-status',      // Element for status updates
    history: false,                   // Disable history for the url
    loadOnScroll: false               // Disable automatic loading on scroll
});

// Function to manually load the next page
function loadNextPage() {
    if (isLoading) return; // Prevent if already loading
    $grid.infiniteScroll('loadNextPage');
}

// Function to check if user is near the bottom of the page
function checkScroll() {
    var scrollThreshold = 300; // Distance from bottom to trigger load
    if ($(window).scrollTop() + $(window).height() > $(document).height() - scrollThreshold) {
        loadNextPage();
    }
}

// Attach scroll event listener to window
$(window).on('scroll', checkScroll);

// Event listener for when new items are loaded
$grid.on('load.infiniteScroll', function (event, body) {
    let itemsHTML = body.map(getItemHTML).join(''); // Generate HTML for new items
    let $items = $(itemsHTML); // Convert HTML to jQuery object

    // Wait for images to load before appending to grid
    $items.imagesLoaded(function () {
        $grid.append($items).masonry('appended', $items).masonry('layout');
        isLoading = false; // Reset flag after loading is complete
    });
});

// Event listener for click on grid items
$grid.on('click', '.grid-item', function () {
    var artworkid = $(this).data('artwork-id'); // retrieve artwork id
    $('#artworkdetailsmodal .modal-content').html(''); // clear previous content
    $.get('/artwork/getartworkdetails', { id: artworkid }, function (response) {
        $('#artworkdetailsmodal .modal-content').html(response);
        $('#artworkdetailsmodal').modal('show');
    });
});


// Load initial page of items
$grid.infiniteScroll('loadNextPage');

// Function to generate HTML for a grid item
function getItemHTML({ title, imageUrl, price, creationDate }) {
    return `<div class="grid-item visible" style="cursor: pointer;" data-artwork-id="${imageUrl}">
                <div class="img-container">
                    <img src="${imageUrl}" alt="${title}"/>
                </div>
                <div class="grid-item-overlay">
                    <div class="overlay-row">
                        <div class="title" title="${title}">${title}</div>
                        <div class="text">${price} kr</div>
                    </div>
                    <div class="overlay-row">
                        <a class="text highlight" href="#">Artist Name</a>
                        <div class="text">${new Date(creationDate).toLocaleDateString('en-US', { month: 'long', day: 'numeric', year: 'numeric' })}</div>
                    </div>
                </div>
            </div>`;
}
