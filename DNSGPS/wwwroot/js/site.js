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

        var myHeaders = new Headers();
        myHeaders.append("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");

        var requestOptions = {
            method: 'GET',
            headers: myHeaders,
            redirect: 'follow'
        };

        fetch("https://api-dnsgps.azurewebsites.net/WeatherForecast/login", requestOptions)
            .then(
                function (response) {
                    resolve(response.text());
                }
            )
            .catch(error => reject(error));
    });

    return promise;
}

    async function login() {
        var user,
            pass;
        user = document.getElementById("user_textBox");
        pass = document.getElementById("password_textBox");

        if (user.value.length > 0 && pass.value.length > 0) {
            var succes = await httpGet('https://api-dnsgps.azurewebsites.net/WeatherForecast')
                .then(
                    function (response) {
                        document.getElementById("user_textBox").innerHTML = "SUCCESS";
                    }
                ).catch(
                    function (error) {
                        document.getElementById("user_textBox").innerHTML = "ERROR";
                    }
                );

        }
    }
