function Clearlist(a) {
    var table = document.getElementById(a);
    table.innerHTML = "";
}

function addToList() {
    var theWord = document.forms["myForm"]["theWord"].value;
    var theCol = document.forms["myForm"]["listcol"].value;

    if (theWord <= " "){
        alert("A word must be entered");
    }
    if (theCol == null){
        alert("You must choose a column");
    }
    if (theCol < 1){
        alert("the list must be either 1 or 2");
    }
    if (theCol > 2){
        alert("the list must be either 1 or 2");
    }
    if (theCol == 1) {
        var table = document.getElementById("listOne");
        (table.insertRow()).innerHTML = theWord;
    }

    if (theCol == 2) {
        var table = document.getElementById("listTwo");
        (table.insertRow()).innerHTML = theWord;
    }

}