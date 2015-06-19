$(function () {
    $('#1').click(function () {
        console.log("Poder 1");
        $.get("ActivarPoderSencillo", { idPoder: 1 }, function (data) {
            var datos = data.toString().split(",");
            if (datos[0] == "True") {
                window.alert("Poder Activado  \n " + "Tiros restantes: " + datos[1]);
                $("#restantes").html("Tiros restantes: " + datos[1]);
                $("#1").hide("fast");
                $("#2").hide("fast");
                $("#3").hide("fast");
            } else {
                window.alert("Fallo activar el poder");
            }
        });
    });
    $('#2').click(function () {
        console.log("Poder 2");
        $.get("ActivarPoderSencillo", { idPoder: 2 }, function (data) {
            var datos = data.toString().split(",");
            if (datos[0] == "True") {
                window.alert("Poder Activado  \n " + "Tiros restantes: " + datos[1]);
                $("#restantes").html("Tiros restantes: " + datos[1]);
                $("#1").hide("fast");
                $("#2").hide("fast");
                $("#3").hide("fast");
            } else {
                window.alert("Fallo activar el poder");
            }
        });
    });
    $('#3').click(function () {
        console.log("Poder 3");
        $.get("ActivarPoderSencillo", { idPoder: 3 }, function (data) {
            var datos = data.toString().split(",");
            if (datos[0] == "True") {
                window.alert("Poder Activado  \n " + "Tiros restantes: " + datos[1]);
                $("#restantes").html("Tiros restantes: " + datos[1]);
                $("#1").hide("fast");
                $("#2").hide("fast");
                $("#3").hide("fast");
            } else {
                window.alert("Fallo activar el poder");
            }
        });
    });
    $('#4').click(function () {
        console.log("Poder 4");
        $.get("ActivarPoderSencillo", { idPoder: 4 }, function (data) {
            var datos = data.toString().split(",");
            if (datos[0] == "True") {
                window.alert("Casilla de nave: X: " + datos[1] + " Y: " + datos[2]);
                $("#4").hide("fast");
            } else {
                window.alert("Fallo activar el poder");
            }

        });
    });
    $('#5').click(function () {
        console.log("Poder 5");
        $("#5").hide("fast");

    });
    $('#6').click(function () {
        console.log("Poder 6");
        $("#6").hide("fast");

    });
    $('#7').click(function () {
        console.log("Poder 7");
        $("#7").hide("fast");
        $("#8").hide("fast");
    });
    $('#8').click(function () {
        console.log("Poder 8");
        $("#7").hide("fast");
        $("#8").hide("fast");
    });
    $('#9').click(function () {
        console.log("Poder 9");
        $.get("ActivarPoderSencillo", { idPoder: 9 }, function (data) {
            window.alert(data);
            $("#9").hide("fast");
        });
    });
    $('#10').click(function () {
        console.log("Poder 10");
        $.get("ActivarPoderSencillo", { idPoder: 10 }, function (data) {
            window.alert(data);
            $("#10").hide("fast");
        });
    });

    $('#rendirse').click(function () {
        console.log("Poder 10");
        $.get("rendirse", null, function (data) {
            if (data == "True") {
                window.alert("Te has rendido");
            }
        });
    });








});