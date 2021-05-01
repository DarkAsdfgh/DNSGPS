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
    var promise;


    promise = new Promise(
        function (resolve, reject) {

        fetch(theUrl)

            .then(function (response) {
                resolve(response);
            })
           /* .catch(function (error) {
                reject(error);
            })*/;
    });

    return promise;
}

    async function login() {
        var user,
            pass;
        user = document.getElementById("user_textBox");
        pass = document.getElementById("password_textBox");

        if (user.value.length > 0 && pass.value.length > 0) {
            //var succes = httpGet('https://api-dnsgps.azurewebsites.net/WeatherForecast')
            var succes = await httpGet('https://localhost:44313/weatherforecast')
                .then(
                    function (response) {
                        document.getElementById("user_textBox").innerHTML = "SUCCESS";
                    }
                )/*.catch(
                    function (error) {
                        document.getElementById("user_textBox").innerHTML = "ERROR";
                    }
                )*/;

        }
    }
