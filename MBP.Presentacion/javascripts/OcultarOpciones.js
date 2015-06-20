$(function () {

    $('.Administrador').hide();

    $('#TipoDeUsuario').change(function () {


        var value = $(this).val();
        console.log(value);
        if (value == "1") {
            $('.Administrador').show();
            $('.Moderador').show();
            $('.Jugador').hide();
        }
        else if (value == "2") {
            $('.Administrador').show();
            $('.Jugador').show();
            $('.Moderador').hide();

        } else {
            $('.Administrador').hide();
        }

    });

});