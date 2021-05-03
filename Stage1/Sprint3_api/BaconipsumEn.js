function resetForm() {
    document.getElementById("numPara").value = "";
    document.getElementById("myRawData").innerHTML = "";
    document.getElementById("myFormattedData").innerHTML = "";
    document.getElementById("myEncryptedData").innerHTML = "";
}

async function restBacon() {

    // first build the API call string by starting with the URL
    var apiString = "https://baconipsum.com/api/";

    // next add the parameters to the string using the drop down lists
    //var theNewType = document.getElementById("newType").value;
    var theNewType = "meat"
    var theNewParagraphs = document.getElementById("numPara").value;
    var theEncryptionType = document.getElementById("encryptionType").value;
    var apiString = apiString + "?type=" + theNewType + "&paras=" + theNewParagraphs;

    alert(apiString + ' encryption type= ' + theEncryptionType);     // show the API string

    // now make the API call to the web service using the string and store what is returned in response
    var response = await fetch(apiString);

    // finally, print the response in the various formats
    document.getElementById("myRawData").innerHTML = "";         // clear what was previously shown
    document.getElementById("myFormattedData").innerHTML = "";   // clear what was previously shown
    document.getElementById("myEncryptedData").innerHTML = "";   // clear what was previously shown

    var jsonData = await response.json();  // read the response as JSON

    // stringify and print out the JSON object in the RawData section
    document.getElementById("myRawData").innerHTML = JSON.stringify(jsonData);


    // loop through the JSON object one paragraph at a time and print each in the FormattedData section
    for (var para in jsonData) {
        document.getElementById("myFormattedData").innerHTML += "<p>" + jsonData[para] + "</p>";
    }

    // determine which algorithm to use, encrypt the data using that algorithm, and print in the 
    // myEncryptedData section

    //var newEncryptedData = JSON.stringify(jsonData);
    newEncryptedData = [];
    if (theEncryptionType === "1") {
        newEncryptedData = cipher1(jsonData);   // apply the first cipher algorithm
    } else {
        newEncryptedData = cipher2(jsonData);   // apply the second cipher algorithm
    }

    // loop through the encrypted JSON object one paragraph at a time and print each in the 
    // EncryptedData section
    for (var para in newEncryptedData) {
        document.getElementById("myEncryptedData").innerHTML += 
                "<p>" + newEncryptedData[para] + "</p>";
    }

    return true;
}

function cipher1(newEncryptedData) {
    // receives an array and returns an array
    thisEncryptedData = newEncryptedData;
    var newCharCode;
    var newJson= [];
    var newPara= "";
    for (var para in thisEncryptedData) {
        for (char in thisEncryptedData[para]) {
            newChar = thisEncryptedData[para][char]
            newCharCode = newChar.charCodeAt(0);
            if ((newCharCode >= 65) && (newCharCode <= 77)) {         //ascii A - M
                newChar = String.fromCharCode(newCharCode + 13)
            } else if ((newCharCode >= 78) && (newCharCode <= 90)) {  //ascii N - Z
                newChar = String.fromCharCode(newCharCode - 13)
            } else if ((newCharCode >= 97) && (newCharCode <= 109)) { //ascii a - m
                newChar = String.fromCharCode(newCharCode + 13)
            } else if ((newCharCode >= 110) && (newCharCode <= 122)) {//ascii n - z
                newChar = String.fromCharCode(newCharCode - 13)
            }
            newPara += newChar;   // add new char to para
        }  //end of each char
        newJson[para] = newPara;
    }
    return newJson;
}

function cipher2(newEncryptedData) {
   // receives an array and returns an array
   thisEncryptedData = newEncryptedData;
   var newCharCode;
   var newJson= [];
   var newPara= "";
   var charPos= 0;
   for (var para in thisEncryptedData) {
       for (char in thisEncryptedData[para]) {
           newChar = thisEncryptedData[para][char]
           newCharCode = newChar.charCodeAt(0);
           if (charPos === 0){
                newChar = String.fromCharCode(newCharCode + 1)
                charPos = 1;
           } else {
                newChar = String.fromCharCode(newCharCode - 1)
                charPos = 0;
           }
           newPara += newChar;   // add new char to para
       }  //end of each char
       newJson[para] = newPara;
   }
   return newJson;
}
