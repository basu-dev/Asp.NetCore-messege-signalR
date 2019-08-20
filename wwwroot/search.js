var connection = new signalR.HubConnectionBuilder()
    .withUrl("/message"
).build()
connection.on("Unfriend", function (status, userid,c_userid) {
    console.log("success");
    if ($("#" + userid)) {

        $("#" + userid).val("Connect");

        $("#" + userid).attr("Value", "connect");
    };
});
connection.on("Send_Request", function (status,userid,c_userid) {
    console.log("success");
    if ($("#connect_"+userid)) {
        console.log("found");
        $("#connect_"+userid).val("Cancel Request");
        
        $("#connect_"+userid).attr("Value", "cancel_request_"+userid);
    };
});
connection.on("Decline_Request", function (status, userid ,c_userid) {
    console.log(status);
    if ($("#" + userid)) {

        $("#" + userid).html("Connect");

        $("#" + userid).attr("Value", "connect");
    }
});
connection.on("Cancel_Request", function (status, userid, c_userid) {
    console.log(status);
    if ($("#" + userid)) {

        $("#" + userid).html("Connect");

        $("#" + userid).attr("Value", "connect");
    }
});
connection.on("Accept_Request", function (status, userid, c_userid) {
    console.log(status);
    if ($("#" + userid)) {

        $("#" + userid).html("Disconnect");

        $("#" + userid).attr("Value", "disconnect");
        $("#"+userid)
    }
});

$(document).ready(function () {
    $(".button_request").click(function () {
        var userid = $(this).attr("name");
        console.log(userid);
        var fn = $(this).attr("value");
        console.log(fn);

        if (fn === "disconnect_"+userid) {
            connection.invoke("Unfriend",userid).catch(function (err) {
                return console.error(err.toString());
            });
 
        } 
        else if (fn == "connect_"+userid) {
            connection.invoke("Send_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
        else if (fn === "accept_"+userid) {
            connection.invoke("Accept_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
        else if (fn === "decline_"+userid) {
            connection.invoke("Decline_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
        else if (fn === "cancel_request_"+userid) {
            connection.invoke("Cancel_Request", userid).catch(function (err) {
                return console.error(err.toString());
            });

        }
    });

    
})
connection.start();
