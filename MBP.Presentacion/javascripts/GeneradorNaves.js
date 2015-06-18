$(function(){

    $.ajax({
            url: '',
            type: 'GET',
            dataType: 'json',
            // we set cache: false because GET requests are often cached by browsers
            // IE is particularly aggressive in that respect
            cache: false,
            data: { }, //id: id },
            success: function (person) {

                var posicionX = person[0];

                var baseX = 565;
                var baseY = 53;

                //565 en x y 64 en y son las posiciones iniciales

                // 20 en alto y en ancho por cada casilla

                var movimientoX = -25*posicionX;
                var movimientoY = 25;

                var imagenPre = document.createElement("IMG");

                var locacionImagen = "/MBP.Presentacion/Images/LogoMyBattlePong.png";

                imagenPre.setAttribute("src", locacionImagen);
                imagenPre.setAttribute("class", "Nave");
                imagenPre.setAttribute("id", "n10");
                imagenPre.style.top = baseY + movimientoY + "px";
                imagenPre.style.right = baseX + movimientoX + "px";
                imagenPre.style.width = 20 + "px";
                imagenPre.style.height = 20 + "px";

                var element = document.getElementById("NavesSta");
                element.appendChild(imagenPre);
            }
        });

    });