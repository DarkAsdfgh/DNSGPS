// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



async function httpGet(theUrl) {
    var promise;


    promise = new Promise(
        function (resolve, reject) {

        var myHeaders = new Headers();
        myHeaders.append("Cookie", "ARRAffinity=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17; ARRAffinitySameSite=22a7daa836b64a8ce56c907737553d08297ff2e76cd06a1f52c29956b9a85c17");

        var requestOptions = {
            mode: 'no-cors',
            method: 'GET',
            headers: myHeaders,
            redirect: 'follow'
        };

            fetch('https://api.weatherbit.io/v2.0/current?lat=35.7796&lon=-78.6382&key=f40ed5a72f5940f0975c7e30a0889ea4&include=minutely%27', requestOptions)
            .then(
                async function (response) {
                    resolve(await response.text());
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
            var success = await httpGet('https://api-dnsgps.azurewebsites.net/DNSGPSController')
                .then(
                    function (response) {
                        document.getElementById("user_textBox").innerHTML = "SUCCESS";
                    }
                ).catch(
                    function (error) {
                        document.getElementById("user_textBox").innerHTML = "ERROR";
                    }
                );
            console.log(success);
        }
    }
