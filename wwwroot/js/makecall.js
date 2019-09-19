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

const to = $("#user").attr("Value");
const video = document.getElementById('usko_video');
const peerconnection = new RTCPeerConnection();
function Call() {  
    navigator.mediaDevices.getUserMedia({ video: true, audio: true }).
        then(function (stream) {
            peerconnection.addStream(stream);
            document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks());
            peerconnection.createOffer()
                .then(sdp => peerconnection.setLocalDescription(sdp))
                .then(function () {
                    connection.invoke('Call_Request', to, peerconnection.localDescription);
                    //console.log(peerconnection.localDescription);
                });
        });
    peerconnection.onaddstream = function (event) {
        video.srcObject = event.stream;

    }
    connection.on('call_accepted', function (sdp) {
            console.log(sdp);
        peerconnection.setRemoteDescription(sdp);
      
        console.log("new state : " + peerconnection.connectionState);
        
    }
    );
    console.log("connectionState  " + peerconnection.connectionState);  
  
}; 


connection.start().then(function () {
}).catch(function (err) {

    return console.error(err.toString());

});


    
    

   
