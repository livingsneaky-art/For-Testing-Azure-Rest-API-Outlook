
// Get references to the elements
var eyeslash = document.getElementById('eyeslash');
var eye = document.getElementById('eye');
var visuallyHidden = document.querySelector('.visually-hidden');
var show = document.querySelector('.show');
var password = document.getElementById('password');

// Function to toggle the classes on the visuallyHidden element
function toggleVisibility() {
    visuallyHidden.classList.toggle('visually-hidden');
    visuallyHidden.classList.toggle('show');
    show.classList.toggle('visually-hidden');
    show.classList.toggle('show');
    password.type = password.type === 'password' ? 'text' : 'password';
}

// Add a click event listener to the eyeslash element
eyeslash.addEventListener('click', toggleVisibility);

// Add a click event listener to the eye element
eye.addEventListener('click', toggleVisibility);