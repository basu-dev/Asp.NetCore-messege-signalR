connection.on("initial_call_request", function (name, to, from) {

    if (from != c_userid) {
        var a = confirm(name + "is calling you. Accept?");
        if (a) {

            connection.invoke("Accept_Call", to, from).catch(function (err) {
                return console.error(err.toString);

            })
        }
        else {
            connection.invoke("Reject_Call", from).catch(function (err) {
                return console.error(err.toString);
            })
        }

    }
    else {
        console.log("call request sent");

    }
})
connection.on("Accept_Call", function (to, from) {

    if (from != c_userid) {
        console.log("receiver");
        window.open("/videocall/incomingcall/"+from)
    }
    else {
        console.log("sender");
        window.open("/videocall/index/" + to);

    };
});