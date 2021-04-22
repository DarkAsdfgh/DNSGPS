// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    function clickMe() {
        $("#click_me_button").bind("click", function () {
            console.log("HOLA");
        });
    }

    function myFunction() {
        document.getElementById("demo").innerHTML = "Paragraph changed.";
}

    function httpGet(theUrl) {
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", theUrl, false); // false for synchronous request
        xmlHttp.send(null);
        return xmlHttp.responseText;
    }

    function login() {
        var user,
            pass;
        user = document.getElementById("user_textBox");
        pass = document.getElementById("password_textBox");

        if (user.value.length > 0 && pass.value.length > 0) {
            var succes = JSON.parse(httpGet('https://localhost:44313/weatherforecast/login'));
            console.log("");
        }
    }
