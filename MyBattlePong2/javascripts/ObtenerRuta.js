$(function () {

    $('input[type=file]').change(function () {

        var path = document.getElementById('upload-input').value;
        var fileName = path.match(/[^\/\\]+$/);
        console.log(fileName);

    });

});