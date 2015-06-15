$(function () {

    var baseX = 565;
    var baseY = 54;

    //565 en x y 64 en y son las posiciones iniciales

    // 20 en alto y en ancho por cada casilla

    var movimientoX = -25;
    var movimientoY = 25;

    var tablero2 = -2;
    var disparar = true;

    if (disparar) { movimientoX += tablero2; }

    var imagenPre = document.createElement("IMG");

    imagenPre.setAttribute("src", "/MyBattlePong2/Upload/Perfil/fondo5.jpg");
    imagenPre.setAttribute("class", "Nave");
    imagenPre.setAttribute("id", "n10");

    document.getElementById('NavesSta').appendChild(imagenPre);

    //var data = @Html.Raw(JsonConvert.SerializeObject(this.Model));
   // var el = document.getElementById('n1');
    imagenPre.style.top = baseY + "px";
    imagenPre.style.right = baseX + "px";
    imagenPre.style.width = 20 + "px";
    imagenPre.style.height = 20 + "px";

    var chatHub = $.connection.chatHub;

    chatHub.client.addNewMessageToPage = function (name, msg, bool) {

        if (bool) {
            var chatWin = $("#chatWindow");
        } else {
            var chatWin = $("#FanWindow");
        }

        if (name != document.getElementById('name').innerHTML) {

            // chatWin.html("<b>" + name + "</b>:" + msg + "<br/>" + chatWin.html());

            // Crear la imagen con el msg

            consol.log(msg);

        }
    };

    $.connection.hub.start().done(function () {
        chatHub.server.join(document.getElementById('name').innerHTML, $("#sala").val(), $("#usuario").val());
    });


    // Para el id de la cuestión
    $('#algo').click(function () {

        // Call the Send method on the hub.
        var lbltext = document.getElementById('name').innerHTML;
        chatHub.server.send(lbltext, $("#message").val(), $("#sala").val(), $("#usuario").val());
        // Clear text box and reset focus for next comment.
        $('#message').val('').focus();

    });



});