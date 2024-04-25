const container = document.querySelector('.seat-container');
const seats = document.querySelectorAll('.row .seat:not(.occupied)');
const count = document.getElementById('count');
const total = document.getElementById('total');
const movieSelect = document.getElementById('movie');



populateUI();

let ticketPrice = +movieSelect.value;

// Save selected movie index and price
function setMovieData(movieIndex, moviePrice) {
    localStorage.setItem('selectedFoodIndex', movieIndex);
    localStorage.setItem('selectedMoviePrice', moviePrice);
}

// Update total and count
function updateSelectedCount() {
    const selectedSeatId = localStorage.getItem('selectedSeatId');

    if (selectedSeatId) {
        count.innerText = 1;
        total.innerText = ticketPrice;
    } else {
        count.innerText = 0;
        total.innerText = 0;
    }
}

// Get data from localstorage and populate UI
function populateUI() {
    const selectedSeatId = localStorage.getItem('selectedSeatId');

    if (selectedSeatId) {
        const selectedSeat = document.querySelector(`.seat[seatid="${selectedSeatId}"]`);
        if (selectedSeat) {
            selectedSeat.classList.add('selected');
        }
    }

    const selectedFooddIndex = localStorage.getItem('selectedFooddIndex');

    if (selectedFooddIndex !== null) {
        movieSelect.selectedIndex = selectedFooddIndex;
    }
}

// Movie select event
movieSelect.addEventListener('change', e => {
    ticketPrice = +e.target.value;
    setMovieData(e.target.selectedIndex, e.target.value);
    updateSelectedCount();
});

// Seat click event
// Seat click event
container.addEventListener('click', e => {
    if (
        e.target.classList.contains('seat') &&
        !e.target.classList.contains('occupied')
    ) {
        const seatId = e.target.getAttribute('seatid'); // Get the seatId attribute

        const selectedSeats = document.querySelectorAll('.row .seat.selected');

        // Deselect all seats
        selectedSeats.forEach(seat => {
            seat.classList.remove('selected');
        });

        // Select the clicked seat
        e.target.classList.add('selected');

        // Store the selected seatId
        localStorage.setItem('selectedSeatId', seatId);

        updateSelectedCount();
    }
});

// Initial count and total set
updateSelectedCount();

document.addEventListener('DOMContentLoaded', function () {
    // Get the movie ID from the query string
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);
    var movieId = urlParams.get('movieId');

    if (movieId) {
        // Store the movie ID in localStorage
        localStorage.setItem('movieId', movieId);
    }
});

document.getElementById('confirmBtn').addEventListener('click', function (e) {
    e.preventDefault();
    debugger
    const selectedSeatId = localStorage.getItem('selectedSeatId');
    const selectedFoodIndex = localStorage.getItem('selectedFoodIndex');
    const movieId = localStorage.getItem('movieId');
    const accountId = document.querySelector('.btn-confirm').getAttribute('accountid');
  

    if (selectedSeatId !== null) {
        const xhr = new XMLHttpRequest();
        xhr.open('GET', `/MovieDetail?handler=ConfirmPurchase&seatId=${selectedSeatId}&movieId=${movieId}&foodIndex=${selectedFoodIndex}&uid=${accountId}`);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');

        xhr.onload = function () {
            if (xhr.status === 200) {
                // Handle success
                console.log(xhr.responseText);
                alert('Purchase confirmed!');
            } else {
                // Handle error
                console.error('Error:', xhr.statusText);
                alert('Error occurred while confirming purchase');
            }
        };

        xhr.send();
    } else {
        alert('Please select a seat before confirming purchase');
    }
});

