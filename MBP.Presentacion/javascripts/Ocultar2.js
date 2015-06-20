$(function () {
    var mode = document.getElementById('mode').value;
    if (mode == "1") {
        $('.Administrador').show();
        $('.Moderador').show();
        $('.Jugador').hide();
    }
    else if (mode == "2") {
        $('.Administrador').show();
        $('.Jugador').show();
        $('.Moderador').hide();

    } else {
        $('.Administrador').hide();
    }

});

