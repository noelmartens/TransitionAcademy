function Clearlist(a) {
    var table = document.getElementById(a);
    table.innerHTML = "";
}

function addToList() {
    var theWord = document.forms["myForm"]["theWord"].value;
    var theCol = document.forms["myForm"]["listcol"].value;

    if (theWord <= " ") {
        alert("A word must be entered");
    }
    if (theCol == null) {
        alert("You must choose a list   ");
    }
    if (theCol < 1) {
        alert("the list must be either 1 or 2");
    }
    if (theCol > 2) {
        alert("the list must be either 1 or 2");
    }

    if (theCol == 1) {
        myResult = theWord + " " + palindrome1(theWord);
        var table = document.getElementById("listOne");
        (table.insertRow()).innerHTML = myResult;
    }

    if (theCol == 2) {
        var thisWord = reverseTheString(theWord);

        myResult = theWord + " " + false;
        if (theWord == thisWord) {
            myResult = theWord + " " + true;
        }
        var table = document.getElementById("listTwo");
        (table.insertRow()).innerHTML = myResult;
    }
}

function palindrome1(theWord) {
    //  this reverses the word and returns a boolean if 
    //  parm = reverse word
    thisWord = theWord;
    var thisWord = theWord.split("").reverse().join("");
    if (theWord == thisWord) {
        return true;
    }
    if (theWord != thisWord) {
        return false;
    }
}

function reverseTheString(theWord) {
    //  this reverses a string working backward char by char
    //  appending to the end of the string
    var returnVal = "";
    for (var i = theWord.length - 1 ; i >= 0; i--) { 
        returnVal += theWord[i]; 
    }
    return returnVal;
}

