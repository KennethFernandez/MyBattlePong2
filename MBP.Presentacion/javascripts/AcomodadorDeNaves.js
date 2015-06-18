$(function(){
    
    $.connection.hub.start().done(function () {
        chatHub.server.join(document.getElementById('name').innerHTML, $("#sala").val() + "cosa", $("#usuario").val());
    });


    $('.botonImagen').click(function () {

    var clicked_id = $(this).attr('id');
    var XY = clicked_id.toString().split(",");

    var baseX = 565;
    var baseY = 54;

        //565 en x y 64 en y son las posiciones iniciales

        // 20 en alto y en ancho por cada casilla

    var movimientoX = -25 * parseInt(XY[0]);
    var movimientoY =  25 * parseInt(XY[1]);

    var disparar = true;

    var imagenPre = document.createElement("IMG");

    var hit = true;

    var locacionImagen;

    if (hit) {
        locacionImagen = "/MyBattlePong2/Images/verde.png";
    } else {
        locacionImagen = "/MyBattlePong2/Images/rojo.jpg";
    }

    document.getElementById(clicked_id.toString()).setAttribute("src", locacionImagen);

    imagenPre.setAttribute("src", "/MyBattlePong2/Upload/Perfil/fondo5.jpg");
    imagenPre.setAttribute("class", "Nave");
    var idDeNave = clicked_id.toString() + "h";
    imagenPre.setAttribute("id", idDeNave);
    imagenPre.style.top = baseY + movimientoY  + "px";
    imagenPre.style.right = baseX + movimientoX + "px";
    imagenPre.style.width = 20 + "px";
    imagenPre.style.height = 20 + "px";

    var Xpos = baseX + movimientoX;
    var Ypos = baseY + movimientoY;

    var html = " <img src=\"" + locacionImagen + "\" class=\"Nave\"id=\"n10\" style=\"top: "
                              + Ypos + "px" + "; right:" + Xpos + "px" +
                              "; width: 20px; height: 20px;\" >";

        // Call the Send method on the hub.
    var lbltext = document.getElementById('name').innerHTML;

    chatHub.server.send(lbltext, html, $("#sala").val() + "cosa", "2");///$("#usuario").val());

    $('#message').val('').focus();

    });

    var chatHub = $.connection.chatHub;

    chatHub.client.addNewMessageToPage = function (name, msg, bool) {

        console.log(bool);
        var chatWin = $("#chatWindow");

        if (bool) {

            chatWin.html("<b>" + name + "</b>:" + msg + "<br/>" + chatWin.html());

        } else {

            if (name != document.getElementById('name').innerHTML) {

                chatWin.html(msg + chatWin.html());

            }
        }
       
    };
});