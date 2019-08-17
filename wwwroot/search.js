var connection = new signalR.HubConnectionBuilder()
    .withUrl("/message"
).build()
connection.on("Unfriend", function (userid) {
    console.log("success");
});
connection.on("Send_Request", function (abc) {
    console.log(abc);
});
connection.on("Cancel_Request", function (status, userid ,c_userid) {
    console.log(status);
});

$(document).ready(function () {
    $(".button_request").click(function () {
        console.log("clicked");
        var userid = $(this).attr("Id");
        var fn = $(this).attr("Value");
        if (fn === "disconnect") {
            connection.invoke("Unfriend", userid).catch(function (err) {
                return console.error(err.toString());
            });
 
     
        }
       
        else if (fn === "connect") {
            connection.invoke("Send_Request", userid).catch(function (err) {
                return console.error(err.toString());
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
        else if (fn === "cancel_request") {
            connection.invoke("Cancel_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
    });

    
})
connection.start();
