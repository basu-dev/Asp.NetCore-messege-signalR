"use strict";

$(document).ready(function () {
    connectionStart();
    Call();
});

var state = 0;


var connection = new signalR.HubConnectionBuilder()
    .withUrl("/message", {
        accessTokenFactory: () => "testing"
    })
    .build();

$("#button").click(function () {
    Call();
});
connection.on("connect_by_receiver", function () {
    Call();
});
navigator.mediaDevices.getUserMedia({ video: true }).then(stream =>
    document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks()));

const to = $("#user").attr("Value");
const video = document.getElementById('usko_video');
var configuration = {
    "iceServers": [{ "url": "stun:stun.1.google.com:19302" }]
};
const peerconnection = new RTCPeerConnection(configuration);
async function Call() {
    navigator.mediaDevices.getUserMedia({ video: true, audio: true }).
        then(async function (stream) {
             peerconnection.addStream(stream);
           /* document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks());*/
           await peerconnection.createOffer().catch(error => console.log(error))
                .then(sdp => peerconnection.setLocalDescription(sdp))
                .then(function () {
                    connection.invoke('Call_Request', to, peerconnection.localDescription);
                    //console.log(peerconnection.localDescription);
                });
            peerconnection.onaddstream = function (event) {
                video.srcObject = event.stream;
                state = 1;
                console.log(state);
            };
            if (state == 0) {
                setTimeout(Call, 500);

            };
        });
 
    connection.on('call_accepted', function (_sdp) {
        console.log(_sdp);
        peerconnection.setRemoteDescription(_sdp);
    }
    );  
}

 function connectionStart() {
    try {
        connection.start();
        state = 0;
        console.log("connected");
    } catch (err) {
        state = 1;
        console.log(err);
        setTimeout(() => connectionStart(), 5000);
    }
};
connection.onclose(() => {
    state = 1;
     connectionStart();
});

    


    
    

   
