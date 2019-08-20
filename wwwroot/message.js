
"use strict";
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/message", {
        accessTokenFactory: () => "testing"
    })
    .build();
var userid = $("#userid").attr("value");
var c_userid = $("#cuserid").attr("value");

$("#video_call").click(function () {
    connection.invoke("Initial_Call_Request", userid,c_userid).catch(function (err) {
        return console.error(err.toString);
        console.log(userid);
    });

});
    
    $(".more_messages").click(function () {
        var lowest_id = $(this).attr("value");
        console.log(lowest_id);
    });
    var value = 0;
    $(function () {
        $("div.friend_message a").hover(function () {
            value = $(this).attr("Id");

        });
    });
    $("div.friend_message a").click(function (e) {
        if (value === userid) {
            e.preventDefault();
            $("#frnmsg_update").css("display", "none");
            $("#messagebox").css("display", "block");
        }
        else {
            $(this).unbind("click").click();
        }

    });

    $("#back").click(function () {
        document.getElementById("frnmsg_update").style.display = "block";
        document.getElementById("messagebox").style.display = "none";

    });

    $(document).ready(function () {
        $("#scrollanimate").stop().animate({ scrollTop: $("#scrollanimate")[0].scrollHeight });


    })


    connection.on("PrivateMessage", function (message, recid, senid, senfirstName, recfirstName, senlastName, reclastName, senprofilePicture, recprofilePicture) {

        var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
        var myid = $("#cuserid").attr("value");
        var userid = $("#userid").attr("value");
        if (senid == myid) {
            var div = document.createElement("div");
            div.className = "ml-auto";
            var img = document.createElement("img");
            img.className = "rounded-circle";
            img.height = "30"; img.width = "30"; img.src = "/" + senprofilePicture;
            var span = document.createElement("span");
            span.className = "alert alert-danger alert-sm mt-1";
            span.innerHTML = msg;
            div.appendChild(span);
            div.appendChild(img);
            $("#scrollanimate").stop().animate({ scrollTop: $("#scrollanimate")[0].scrollHeight })

            document.getElementById("scrollanimate").append(div);
        }
        else if (senid == userid) {
            var div = document.createElement("div");
            div.className = "mr-auto";
            var img = document.createElement("img");
            img.className = "rounded-circle";
            img.height = "30"; img.width = "30"; img.src = "/" + senprofilePicture;
            var span = document.createElement("span");
            span.className = "alert alert-info mt-1 alert-sm";
            span.innerHTML = msg;
            div.appendChild(img);
            div.appendChild(span);
            $("#scrollanimate").stop().animate({ scrollTop: $("#scrollanimate")[0].scrollHeight })
            document.getElementById("scrollanimate").append(div);;
        }
        if (senid == myid) {
            var a = document.createElement("a");
            a.href = "/Home/Message/" + recid;
            var div = document.createElement("div");
            div.className = "card"; div.id = recid;
            var img = document.createElement("img");
            var div1 = document.createElement("div");
            var span = document.createElement("span");
            var div2 = document.createElement("div");
            var div3 = document.createElement("div");
            div3.className = "ml-3";
            img.src = "/" + recprofilePicture;
            img.height = "30"; img.width = "30";
            img.className = "rounded-circle ml-1";

            span.innerHTML = recfirstName + " " + reclastName;


            div3.innerHTML = "You" + ":" + msg;
            div2.appendChild(div3);
            div1.appendChild(img);
            div1.appendChild(span);
            div.appendChild(div1);
            div.appendChild(div2);
            a.appendChild(div);
            if (document.getElementById(recid)) {
                document.getElementById(recid).remove();
            }
            document.getElementById("frnmsg_update").prepend(a);
        }
        else {
            var a = document.createElement("a");
            a.href = "/Home/Message/" + senid;
            var div = document.createElement("div");
            div.className = "card"; div.id = senid;
            var img = document.createElement("img");
            var div1 = document.createElement("div");
            var div2 = document.createElement("div");
            var div3 = document.createElement("div");
            div3.className = "ml-3";
            img.src = "/" + senprofilePicture;
            img.height = "30"; img.width = "30";
            img.className = "rounded-circle ml-1";
            var span = document.createElement("span");
            span.innerHTML = senfirstName + " " + senlastName;


            div3.innerHTML = senfirstName + ":" + msg;
            div2.appendChild(div3);
            div1.appendChild(img);
            div1.appendChild(span);
            div.appendChild(div1);
            div.appendChild(div2);
            a.appendChild(div);
            if (document.getElementById(senid)) {
                document.getElementById(senid).remove();
            }
            document.getElementById("frnmsg_update").prepend(a);
        }


    });
    connection.start().catch(function (err) {
        return console.error(err.toString());
    });
    function sendMessage() {
      
        var message = document.getElementById("message").value;

        var userid = $("#userid").attr("value");

        if (message != '\n') {
            console.log("Message "+message);
            connection.invoke("PrivateMessage", message, userid).catch(function (err) {
                return console.error(err.toString());
            });
            document.getElementById("message").value = "";
        }
    };

    document.getElementById("send").addEventListener("click",
        sendMessage
    );
    $("#message").keyup(function () {
        var vaal = document.getElementById("message").value;

        for (var i = 0; i < vaal.length; i++) {
            if (vaal[i] == '\n') {
                sendMessage();
            };
        };
    });

