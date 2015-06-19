$(function () {
    $('#NombreNave').change(function () {
        var value = $(this).val();

        var url = "RefrescarNaves";
        $.get(url, { nombre: value }, function (info) {

            var listaInfo = info.toString().split(",");
            $("#NomNave").attr("value", listaInfo[0]);
            $("#PuntNave").attr("value", listaInfo[1]);
            $("#XDat").val(listaInfo[2]);
            $("#YDat").val(listaInfo[3]);
            //$("#ImgPath").html(listaInfo[4]);
            $("#myonoffswitch").prop("checked", (listaInfo[5] == "True") ? true : false);
            console.log((listaInfo[5] == "True") ? true : false);
            console.log(listaInfo[5]);

        }); 


    });

});