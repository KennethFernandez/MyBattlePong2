var i = 0;

function button() {

    var td = document.getElementById("tableCellID");

    if(i==0){
        td.setAttribute("colspan", 2);

        i=1;
    }else{
        td.setAttribute("colspan", 1);

        i=0;
    }
}
