export{};
function resetForm(): void {
    let minValueDisable = <HTMLInputElement>document.getElementById('minValue');
    let maxValueDisable = <HTMLInputElement>document.getElementById('maxValue');
    minValueDisable.disabled = false;
    maxValueDisable.disabled = false;

    let table: any = document.getElementById("listOne");
    let table2: any = document.getElementById("listTwo");
    table.innerHTML = "";
    table2.innerHTML = "";
    let minValue: any =
        document.forms["myForm"]["minValue"];
    let maxValue: any =
        document.forms["myForm"]["maxValue"];
    let myNumber: any =
        document.forms["myForm"]["myNumber"];
    let meanValue: any =
        <HTMLInputElement>document.getElementById("meanValue");
    let medianValue: any =
        <HTMLInputElement> document.getElementById("medianValue");
    let modeValue: any =
        <HTMLInputElement> document.getElementById("modeValue");
    minValue.value = "";
    maxValue.value = "";
    myNumber.value = "";
    meanValue.value = "";
    medianValue.value = "";
    modeValue.value = "";
    //document.forms["myForm"]["minValue"].value = "";
    //document.forms["myForm"]["maxValue"].value = "";
    //document.forms["myForm"]["myNumber"].value = "";
    //document.getElementById("meanValue").value = "";
}

function disableMin(): void {
    //alert ("mouse leave min value");
    let minValueDisable = <HTMLInputElement>document.getElementById('minValue');
    minValueDisable.disabled = true;
}

function disableMax(): void {
    //alert ("mouse leave min value");
    let maxValueDisable = <HTMLInputElement>document.getElementById('maxValue');
    maxValueDisable.disabled = true;
}


function calcValues(): void {
    //document.getElementById('minValue').disabled = true;
    //document.getElementById('maxValue').disabled = true;
    let minValueDisable = 
    (<HTMLInputElement> document.getElementById('minValue')).disabled = true;
    let maxValueDisable = 
    (<HTMLInputElement>document.getElementById('maxValue')).disabled = true;
    //minValueDisable.disabled = true;
    //maxValueDisable.disabled = true;

    let minValue: number = 0;
    let maxValue: number = 0;
    let myNumber: number = 0;
    minValue = parseInt((document.forms["myForm"]["minValue"]).value);
    maxValue = parseInt((document.forms["myForm"]["maxValue"]).value);
    myNumber = parseInt((document.forms["myForm"]["myNumber"]).value);

    //var minValue = document.forms["myForm"]["minValue"].value;
    //var maxValue = document.forms["myForm"]["maxValue"].value;
    //var myNumber = document.forms["myForm"]["myNumber"].value;
    //alert ("min a" + minValue + "  max " + maxValue + "  myNumber " + myNumber);
    //minValue = parseInt(minValue);
    //maxValue = parseInt(maxValue);
    //myNumber = parseInt(myNumber);

    if (minValue > maxValue) {
        alert("Minimum value must be less than maximum value");
        return;
    }
    if (maxValue == minValue) {
        alert("Maximum value must be more than mimimum value");
        return;
    }
    //alert ("min b" + minValue + "  max " + maxValue + "  myNumber " + myNumber);
    if (myNumber < minValue) {
        alert("Your number is less than the minumum");
        return;
    }
    //alert ("min c " + minValue + "  max " + maxValue + "  myNumber " + myNumber);
    if (myNumber > maxValue) {
        alert("Your number is greater than the maximum");
        return;
    }
    let myTable: any = document.getElementById("listOne");
    (myTable.insertRow()).innerHTML = myNumber;

    //alert ("min d " + minValue + "  max " + maxValue + "  myNumber " + myNumber)//;
    //my= document.getElementById("listOne") ;
    //(myTable.insertRow()).innerHTML = myNumber;

    // save the numbers entered
    //var myTable = document.getElementById("listOne");
    //(myTable.insertRow()).innerHTML = myNumber;

    // load up result area
    let meanValue : any = document.getElementById("meanValue");
    let modeValue : any = document.getElementById("modeValue");
    let medianValue : any = document.getElementById("medianValue");

    meanValue.value  = myMean().toString();
    modeValue.value = myMode().toString();
    medianValue.value = myMedian().toString();
    //document.getElementById("meanValue").value = myMean().toString();
    //document.getElementById("modeValue").value   = myMode().toString();
    //document.getElementById("medianValue").value = myMedian().toString();

}


function myMean(): number {
    //  calculate the average of what's entered
    let myTable: any = document.getElementById("listOne");
    //alert ("got to here " + myTable);    

    let rows: any = myTable.rows;
    //alert ("got to here a" );
    let myTotal: number = 0;

    for (let i: number = 0; i < rows.length; i++) {
        myTotal = myTotal + parseInt(rows[i].innerHTML);
    }
    //alert ( "avg is..."  + myTotal / rows.length);
    return myTotal / rows.length;

}


function myMode() {
    // as result can be bimodal or multi-modal,
    // the returned result is provided as an array
    // mode of [3, 5, 4, 4, 1, 1, 2, 3] = [1, 3, 4]
    let myTable: any = document.getElementById("listOne");
    let rows: any = myTable.rows;

    let modes: Array<number> = [];
    let count: Array<number> = [];
    let number: number = 0;
    let maxIndex: number = 0;

    //alert ("mode:  got to here a")

    // iterate thru table counting number of times each number is used
    for (let i: number = 0; i < rows.length; i += 1) {
        number = parseInt(rows[i].innerHTML);
        count[number] = (count[number] || 0) + 1;
        if (count[number] > maxIndex) {
            maxIndex = count[number];
        }
    }
    for (let i in count)
        if (count.hasOwnProperty(i)) {
            if (count[i] === maxIndex) {
                modes.push(Number(i));
            }
        }
    return modes;
}



function myMedian() {
    let myTable: any = document.getElementById("listOne");
    let rows: any = myTable.rows;
    let myArray: Array<number> = [];
    // load up an array for sorting;
    for (let i: number = 0; i < rows.length; i++) {
        myArray[i] = parseInt(rows[i].innerHTML);
    }
    myArray.sort();
    const middle: number = Math.floor(rows.length / 2);

    //  if the remainder is 0, add the numbers together and divide by 2

    if (rows.length % 2 === 0) {
        // console.log("indexex: " + (middle - 1) + " " + middle );
        // console.log(myArray[middle - 1] + " " + myArray[middle] );
        // console.log((myArray[middle - 1] + myArray[middle]) / 2 );
        return ((myArray[middle - 1] + myArray[middle]) / 2);
    }

    // alert("mymeedian:  got to here  a " );

    //var sorted = document.getElementById("listOne").slice();  //.sort((a, b) => a - b);
    /*const middle = Math.floor(rows.length / 2);
  
    if (rows.length % 2 === 0) {
        return (parseInt(rows[middle - 1].innerHTML) + parseInt(rows[middle].innerHTML) / 2);
    }*/

    //alert("mymeedian:  got to here  b " + parseInt(rows[middle].innerHTML));
    return myArray[middle];
}



/* function sortTable() {

    var table, rows, switching, i, x, y, shouldSwitch;
    table = document.getElementById("listOne");
    switching = true;
    //alert("sorttable:  got to here  a " );
    /* Make a loop that will continue until
    no switching has been done: */
/* while (switching) {
    // Start by saying: no switching is done:
    switching = false;
    rows = table.rows;
    //alert("sorttable:  got to here  b " + rows.length);
    /* Loop through all table rows (except the
    first, which contains table headers): */
/*for (i = 1; i < (rows.length - 1); i++) {
    // Start by saying there should be no switching:
    shouldSwitch = false;
    /* Get the two elements you want to compare,
    one from current row and one from the next: */
           // x = parseInt(rows[i].innerHTML)
            //x = rows[i].getElementsByID("listOne").innerHTML[0];
            //alert("sorttable:  got to here  x " + x);
            //y = parseInt(rows[i + 1].innerHTML)
            //y = rows[i + 1].getElementsByID("listOne").innerHTML[0];
            //alert("sorttable:  got to here  y " + y);
            // Check if the two rows should switch place:
/*if (x > y) {
    // If so, mark as a switch and break the loop:
    shouldSwitch = true;
    break;
}
}

if (shouldSwitch) {
/* If a switch has been marked, make the switch
and mark that a switch has been done: */
/*    rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
    switching = true;
}
}
} */



/*
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

} */

/* function palindrome1(theWord) {
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
} */

