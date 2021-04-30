function resetForm() {
    document.getElementById("numPara").value = "";
    document.getElementById("myRawData").innerHTML = "";
    document.getElementById("myFormattedData").innerHTML = "";
}

async function restBacon() {

    // first build the API call string by starting with the URL
    var apiString = "https://baconipsum.com/api/";
    
    // next add the parameters to the string using the drop down lists
    //var theNewType = document.getElementById("newType").value;
    var theNewType = "meat"
    var theNewParagraphs = document.getElementById("numPara").value; 
    var apiString = apiString + "?type=" + theNewType + "&paras=" + theNewParagraphs;
    alert(apiString);                                           // show the API string

    // now make the API call to the web service using the string and store what is returned in response
    var response = await fetch(apiString);

    // finally, print the response in the various formats
    document.getElementById("myRawData").innerHTML = "";         // clear what was previously shown
    document.getElementById("myFormattedData").innerHTML = "";   // clear what was previously shown
    

    var jsonData = await response.json();  // read the response as JSON

    // stringify and print out the JSON object in the RawData section
    document.getElementById("myRawData").innerHTML = JSON.stringify(jsonData);

    
    // loop through the JSON object one paragraph at a time and print each in the FormattedData section
    for (var para in jsonData) {
        document.getElementById("myFormattedData").innerHTML += "<p>" + jsonData[para] + "</p>";
    }
    /* 
    // determine which algorithm to use, encrypt the data using that algorithm, and print in the myEncryptedData section
    var theNewFormat = document.getElementById("newFormat").value;
    var newJsonData;
    if (theNewFormat === "1")
        newJsonData = cipher1(jsonData);   // apply the first cipher algorithm
    else
        newJsonData = cipher2(jsonData);   // apply the second cipher algorithm

    // loop through the encrypted JSON object one paragraph at a time and print each in the EncryptedData section
    for (var para in newJsonData) {
        document.getElementById("myEncryptedData").innerHTML += "<p>" + newJsonData[para] + "</p>";
    }*/

    //return true;
}

