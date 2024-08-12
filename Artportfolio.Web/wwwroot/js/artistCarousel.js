// Add an event listener to update the active thumbnail when the carousel slides
var carouselElement = document.getElementById('artistCarousel');
carouselElement.addEventListener('slide.bs.carousel', function (event) {
	// Remove active class from all thumbnails
	document.querySelectorAll('.preview-thumbnail').forEach(function (thumbnail) {
		thumbnail.classList.remove('active-thumbnail');
	});

	// Add active class to the current thumbnail
	var activeThumbnail = document.querySelectorAll('.preview-thumbnail')[event.to];
	if (activeThumbnail) {
		activeThumbnail.classList.add('active-thumbnail');
	}
});