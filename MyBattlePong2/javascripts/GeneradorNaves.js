$(function(){
   

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
        imagenPre.setAttribute("id", "n10");
        imagenPre.style.top = baseY + movimientoY  + "px";
        imagenPre.style.right = baseX + movimientoX + "px";
        imagenPre.style.width = 20 + "px";
        imagenPre.style.height = 20 + "px";

    });

});