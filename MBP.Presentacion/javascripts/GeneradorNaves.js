$(function () {

    var url2 = "DatosGenerales";
    $.get(url2, null, function (data) {

        var datos = data.toString().split(",");

        $("#puntos").html("Puntos: " + datos[2]);
        $("#restantes").html("Tiros restantes: " + datos[0]);
        $("#turno").html("Turno: " + datos[1]);

    });

    var url = "DataNave";
    $.get(url, null, function (data) {

        var datos = data.toString().split(",");

        var variableX    = "";
        var variableY    = "";
        var tamanoX      = "";
        var tamanoY      = "";
        var direccionimg = "";

        for (var i = 0; i < datos.length -1; i += 5) {

            variableX =     parseInt(datos[i]);
            variableY =     parseInt(datos[i + 1]);
            tamanoX =       parseInt(datos[i + 2]);
            tamanoY =       parseInt(datos[i + 3]);
            direccionimg =  datos[i + 4];

            var baseX = 565;
            var baseY = 53;

            //565 en x y 64 en y son las posiciones iniciales

            // 20 en alto y en ancho por cada casilla

            var movimientoX = -25 * (variableX + tamanoX - 1);
            var movimientoY =  25*variableY;

            var imagenPre = document.createElement("IMG");

            var locacionImagen = "/MBP.Presentacion/Images/LogoMyBattlePong.png";

            imagenPre.setAttribute("src", locacionImagen);
            imagenPre.setAttribute("class", "Nave");
            imagenPre.setAttribute("id", "n10");
            imagenPre.style.top = baseY + movimientoY + "px";
            imagenPre.style.right = baseX + movimientoX + "px";
            imagenPre.style.width =  20*tamanoX + "px";
            imagenPre.style.height = 20*tamanoY + "px";

            var element = document.getElementById("NavesSta");
            element.appendChild(imagenPre);

        }
    });

    });