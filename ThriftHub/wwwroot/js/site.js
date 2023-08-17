document.addEventListener("DOMContentLoaded", function () {
    const searchInput = document.getElementById("searchInput");
    const sortSelect = document.getElementById("sortSelect");
    const searchButton = document.getElementById("searchButton");
    const resultsList = document.getElementById("resultsList");
    const imageSlider = document.querySelector(".image-slider");
    const images = imageSlider.querySelectorAll("img");
    let currentImageIndex = 0;

    // Function to show next image in the slider
    function showNextImage() {
        images[currentImageIndex].style.display = "none";
        currentImageIndex = (currentImageIndex + 1) % images.length;
        images[currentImageIndex].style.display = "block";
    }

    // Start the image slider
    setInterval(showNextImage, 3000); // Change image every 3 seconds (adjust as needed)

    searchButton.addEventListener("click", function () {
        const searchTerm = searchInput.value.toLowerCase();
        const selectedSort = sortSelect.value;

        // Clear previous results
        resultsList.innerHTML = "";

        // Implement AJAX call to fetch and display filtered results
        fetch(`/Index/GetFilteredResults?searchTerm=${searchTerm}&selectedSort=${selectedSort}`)
            .then(response => response.json())
            .then(data => {
                // Populate the resultsList with the fetched data
                data.forEach(product => {
                    const resultItem = document.createElement("li");
                    resultItem.textContent = `${product.name} - Price: ${product.price} - Date: ${product.dateAdded}`;
                    resultsList.appendChild(resultItem);
                });
            });
    });
});
