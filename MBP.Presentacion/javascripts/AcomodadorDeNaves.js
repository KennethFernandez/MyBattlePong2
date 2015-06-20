$(function () {
    
    $.connection.hub.start().done(function () {
        chatHub.server.join(document.getElementById('name').innerHTML, $("#sala").val() + "cosa", $("#usuario").val());
    });

    $('.botonImagen').click(function () {

    if ($("#turno").html() == "Turno: t") {

    var clicked_id = $(this).attr('id');
    var XY = clicked_id.toString().split(",");

    var baseX = 565;
    var baseY = 54;

        //565 en x y 64 en y son las posiciones iniciales

        // 20 en alto y en ancho por cada casilla

    var movimientoX = -25 * parseInt(XY[0]);
    var movimientoY =  25 * parseInt(XY[1]);

    var locacionImagen = "/MyBattlePong2/Images/rojo.jpg";

    var idDeNave = clicked_id.toString() + "h";

    document.getElementById(clicked_id.toString()).setAttribute("src", locacionImagen);

    var url2 = "Disparo";

    $.get(url2, { x:  parseInt(XY[0]), y:  parseInt(XY[1])}, function (data) {

        var locacionDisparo = "/MyBattlePong2/Images/rojo.jpg";
        var datos = data.toString().split(",");

        console.log("----------------------");
        console.log(datos.length);
        console.log("----------------------");

        console.log(datos[0].toString() == "2");

        $("#puntos").html("Puntos: " + datos[2]);
        $("#restantes").html("Tiros restantes: " + datos[1]);
        $("#turno").html("Turno: " + datos[3]);
        
        //for (var i = 0; i < datos.length -1; i += 5) {
        
        if (datos.length <= 5) {
            if (datos[0].toString() == "2") {
                locacionDisparo = "/MBP.Presentacion/Images/verde.png";
            }

            $("#" + clicked_id.toString()).attr("src", locacionDisparo);
            document.getElementById(clicked_id.toString()).setAttribute("src", locacionDisparo);

        } else {
            console.log("-----------Tiro diferente ------------");
            console.log(datos.length - 1);
            console.log("---------");
            for (var i = 5; i < datos.length - 1; i += 3) {

                console.log(datos[i]);
                console.log(datos[i+1]);
                console.log(datos[i + 2]);
                
                var casilla = datos[i] + "," + datos[i + 1];
                console.log(casilla);

                locacionDisparo = "/MyBattlePong2/Images/rojo.jpg";
                if (datos[i+2].toString() == "2") {
                    locacionDisparo = "/MBP.Presentacion/Images/verde.png";
                }

                $("#" + casilla.toString()).attr("src", locacionDisparo);
                document.getElementById(casilla.toString()).setAttribute("src", locacionDisparo);
            }
        }

        // Finalizo
        if (datos[4] == "True") {

            var url2 = "DesbloquearPoderes";
            $.get(url2, null, function (data) {
                window.alert(data);
                $.post("Termino", null, function (data) { }, "html");
            });

        }

    });

    var Xpos = baseX + movimientoX;
    var Ypos = baseY + movimientoY;

    var html = " <img src=\"" + locacionImagen + "\" class=\"Nave\"id=\"" + idDeNave + "\" style=\"top: "
                              + Ypos + "px" + "; right:" + Xpos + "px" +
                              "; width: 20px; height: 20px;\" >";


        // Call the Send method on the hub.
    var lbltext = document.getElementById('name').innerHTML;

    chatHub.server.send(lbltext, html, $("#sala").val() + "cosa", "2");///$("#usuario").val());

    $('#message').val('').focus();

    }

    });

    var chatHub = $.connection.chatHub;

    chatHub.client.addNewMessageToPage = function (name, msg, bool) {

        //console.log(bool);
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