var connection = new signalR.HubConnectionBuilder().withUrl("/message").build();
if (connection.on("accept_call")) {
    console.log("accepted");
    const peerconnection = new RTCPeerConnection();
    const to = $("#user").attr("Value");
    const video = document.getElementById('usko_video');
    navigator.mediaDevices.getUserMedia({ video: true, audio: true }).
        then(function (stream) {
            peerconnection.addStream(stream);
            document.getElementById('mero_video').srcObject = new MediaStream(stream.getVideoTracks());
            peerconnection.createOffer()
                .then(sdp => peerconnection.setLocalDescription(sdp))
                .then(function () {
                    connection.invoke('Call_Request', to, peerconnection.localDescription);
                    //console.log(peerconnection.localDescription);
                })
        })
    connection.on('call_accepted', function (sdp) {
        console.log(sdp);
        peerconnection.setRemoteDescription(sdp);
    }
    );
    peerconnection.onaddstream = function (event) {
        video.srcObject = event.stream;
    }
    connection.start().then(function () {
    }).catch(function (err) {
        return console.error(err.toString());
    });
}