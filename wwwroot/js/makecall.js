"use strict";
setTimeout(Call, 100);
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

const to = $("#user").attr("Value");
const video = document.getElementById('usko_video');

const peerconnection = new RTCPeerConnection();
peerconnection.createOffer()
   .then(sdp =>console.log(sdp))


function Call() {  

    navigator.mediaDevices.getUserMedia({ video: true, audio: true }).
        then(function (stream) {
            createOffer();
            peerconnection.addStream(stream);
            document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks());
            function createOffer() {
                peerconnection.createOffer()
                    .then(function (sdp) {
                        console.log("mysdp:  "+sdp)
                        peerconnection.setLocalDescription(sdp);
                        connection.invoke("Call_Request", to, peerconnection.localDescription);
                    })
                    .catch(function (error) {
                        console.log("errors: " +error)
                    }
                );
        }
        });
    peerconnection.onaddstream = function (event) {
        video.srcObject = event.stream;

    }
    connection.on('call_accepted', function (sdp) {
        console.log("utabata aako sdp: "+sdp);
        peerconnection.setRemoteDescription(sdp);  
    }
    );
    console.log("connectionState  " + peerconnection.connectionState);  
  
}; 


connection.start().then(function () {
}).catch(function (err) {

    return console.error(err.toString());

});

    


    
    

   
