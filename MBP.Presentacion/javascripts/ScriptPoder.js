$(function () {
    $('#NombrePoder').change(function () {
        var value = $(this).val();

        var url = "RefrescarPoderes";
        $.get(url, { nombre: value }, function (info) {

            var listaInfo = info.toString().split(",");
            $("#ExpPoder").attr("value", listaInfo[0]);
            $("#VictPoder").attr("value", listaInfo[1]);
            $("#PuntPoder").attr("value", listaInfo[2]);
            $("#DerrPoder").attr("value", listaInfo[3]);
            $("#RankPoder").attr("value", listaInfo[4]);

        }); 


    });

});