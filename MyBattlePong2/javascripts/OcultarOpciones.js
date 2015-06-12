$(function(){

    $('.Administrador').hide();
    
    $('#TipoDeUsuario').change(function(){
    
    
        var value = $(this).val();

             if (value == "1") { $('.Administrador').hide();}
        else if (value == "2") { $('.Administrador').show();
                                 $('.Moderador').show();
                                 $('.Jugador').hide();
        
        } else {                 $('.Administrador').show();
                                 $('.Jugador').show();
                                 $('.Moderador').hide();
        }
    
    });

});