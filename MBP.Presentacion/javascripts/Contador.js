function startTimer(duration, display) {
    var timer = duration, seconds;
    $("#mensaje").val("False");
     setInterval(function () {

        seconds = parseInt(timer % 60, 10);
        seconds = seconds < 10 ? "0" + seconds : seconds;

        $.get("heartbeat", null, function (data) {
        console.log(data);
         var datos = data.toString().split(",");
         if (datos[0] != "0") {
             if (datos[0] == "t") {
                 $("#turno").html("Turno: " + datos[0]);
                 $("#restantes").html("Tiros restantes: " + datos[1]);
                 $("#puntos").html("Puntos: " + datos[2]);
             } else {
                 $("#turno").html("Turno: " + datos[0]);
                 $("#restantes").html("Tiros restantes: " + datos[1]);
             }
         } else {
             console.log($("#mensaje").val().toString());
             if ($("#mensaje").val().toString() == "False") {
                 $("#mensaje").val("True");
                 var url2 = "DesbloquearPoderes";
                 $.get(url2, null, function (data) {
                     $.msgBox({
                         title: "Partida Perdia",
                         content: data,
                         type: "error",
                         buttons: [{ value: "Ok" }],
                         success: function (result) {
                             var url = "../Inicio/Inicio";
                             var form = $('<form action="' + url + '" method="post">' +
                               '<input type="text" name="api_url" value="' + url + '" />' +
                               '</form>');
                             $('body').append(form);
                             form.submit();
                         }
                     });
                 });
             }

         }
        });

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