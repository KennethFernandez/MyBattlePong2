function startTimer(duration, display) {
     var timer = duration, seconds;
     setInterval(function () {

        seconds = parseInt(timer % 60, 10);
        seconds = seconds < 10 ? "0" + seconds : seconds;

         //00
        if (seconds.toString() == "0") {

            $("#TurnoAli").attr("src", "/MBP.Presentacion/Images/rojo.jpg");
            $("#TurnoEne").attr("src", "/MBP.Presentacion/Images/verde.png");

            var url = "PasarTurno";
            $.get(url, null, function (data) { console.log(data); });

            var url2 = "DatosGenerales";
            $.get(url2, null, function (data) {

                var datos = data.toString().split(",");

                $("#puntos").html("Puntos: " + datos[2]);
                $("#restantes").html("Tiros restantes: " + datos[0]);
                $("#turno").html("Turno: " + datos[1]);

            });

        }

        display.text(seconds);
        if (--timer < 0) {timer = duration;}}, 1000);}

jQuery(function ($) {
    var thirtyseconds = 30,
        display = $('#time');
    startTimer(thirtyseconds, display);
});