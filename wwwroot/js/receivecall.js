"use strict";
var userid = $(".senderid").attr("id");
console.log(userid);
$(document).ready(function () {
    connectionStart();
});
var connection = new signalR.HubConnectionBuilder().withUrl("/message").build();
$("#button").click(function () {
   
    connection.invoke("Connect_By_Receiver", userid);
})
navigator.mediaDevices.getUserMedia({ video: true }).then(stream =>
    document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks()));
var video = document.getElementById('usko_video');
var configuration = {
    "iceServers": [{ "url": "stun:stun.1.google.com:19302" }]
};
const peerconnection = new RTCPeerConnection(configuration);
 
connection.on('incommingcall', function (from, sdp) {
    
    if (from == userid) {
        peerconnection.onaddstream = function (event) {
            video.srcObject = event.stream;
        }
        navigator.mediaDevices.getUserMedia({ video: true, audio: true })
            .then(stream => {
                /*document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks());*/
                peerconnection.addStream(stream);
            });
       
    peerconnection.setRemoteDescription(sdp)
        .then(() => peerconnection.createAnswer())
        .then(sdp => peerconnection.setLocalDescription(sdp)).
        then(function () {
            console.log("my answer sdp: "+peerconnection.localDescription)
           
            connection.invoke('Call_Accept', from, peerconnection.localDescription).catch(function (err) {
                return console.error(err.toString());
            });
            
        })
}
});
  
async function connectionStart() {
    try {
        await connection.start();
        console.log("connected");
    } catch (err) {
        console.log(err);
        setTimeout(() => connectionStart(), 5000);
    }
};

connection.onclose(async () => {
    await connectionStart();
});