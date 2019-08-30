"use strict";
var userid = $(".senderid").attr("id");
console.log(userid);

var connection = new signalR.HubConnectionBuilder().withUrl("/message").build();
$("#button").click(function () {
    connection.invoke("Connect_By_Receiver", userid);
})
const peerconnection = new RTCPeerConnection();

    var video = document.getElementById('usko_video');
connection.on('incommingcall', function (from, sdp) {
    console.log("utabata aako sdp:" + sdp);
    if (from == userid) {
    peerconnection.setRemoteDescription(sdp)
        .then(() => peerconnection.createAnswer())
        .then(sdp => peerconnection.setLocalDescription(sdp)).
        then(function () {
            console.log("my answer sdp: "+peerconnection.remoteDescription)

            connection.invoke('Call_Accept', from, peerconnection.localDescription).catch(function (err) {
                return console.error(err.toString());
            });
            navigator.mediaDevices.getUserMedia({ video: true, audio: true })
                .then(stream => {
                    document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks());
                    peerconnection.addStream(stream);
                })
        })
}
});
    peerconnection.onaddstream = function (event) {
        video.srcObject = event.stream;
    }
connection.start();
