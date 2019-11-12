window.addEventListener('load', function () {
    var error = document.getElementById("error");
    if (error.value !== undefined && error.value !== "") {
        alert(error.value);
    }
});