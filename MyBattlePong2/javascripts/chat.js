$(function () {

    var chatHub = $.connection.chatHub;

    chatHub.client.addNewMessageToPage = function (name, msg, bool) {

        if (bool) {
            var chatWin = $("#chatWindow");
        } else {
            var chatWin = $("#FanWindow");
        }

            chatWin.html("<b>" + name + "</b>:" + msg + "<br/>" + chatWin.html());
        
    };

    $.connection.hub.start().done(function () {
        chatHub.server.join(document.getElementById('name').innerHTML, $("#sala").val(), $("#usuario").val());
    });


    $('#sendmessage').click(function () {

        // Call the Send method on the hub.
        var lbltext = document.getElementById('name').innerHTML;
        chatHub.server.send(lbltext, $("#message").val(), $("#sala").val(), $("#usuario").val());
        // Clear text box and reset focus for next comment.
        $('#message').val('').focus();

    });

    $('#message').keypress(function (e) {
        if (e.which == 13) {

            // Call the Send method on the hub.
            var lbltext = document.getElementById('name').innerHTML;
            chatHub.server.send(lbltext, $("#message").val(), $("#sala").val(), $("#usuario").val());
            // Clear text box and reset focus for next comment.
            $('#message').val('').focus();

        }
    });


});