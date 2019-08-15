var connection = new signalR.HubConnectionBuilder()
    .withUrl("/test"
).build()
$(document).ready(function () {
    $(".button_request").click(function (e) {
        e.preventDefault();
        var userid = $(this).attr("Id");
        var fn = $(this).attr("Value");
        if (fn === "disconnect") {
            connection.invoke("Unfriend", userid).catch(function (err) {
                return console.error(err.toString());
            });
                
        }
       
        else if (fn === "connect") {
            connection.invoke("Send_Request", userid).catch(function (err) {
                return concole.error(err.toString());
            });

        }
        else if (fn === "accept") {
            connection.invoke("Accept_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
        else if (fn === "decline") {
            connection.invoke("Decline_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
        else if (fn === "cancel") {
            connection.invoke("Cancel_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
    });

    
})
connection.start();
