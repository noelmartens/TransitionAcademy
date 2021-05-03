function resetForm() {
    document.getElementById("quoteLength").value = "";
    document.getElementById("myQuote").innerHTML = "";
}

async function getQuote() {

    // first build the API call string by starting with the URL
    var apiString = "https://api.quotable.io/random";

    // next add the parameters to the string using the drop down lists
    var quotelgth = document.getElementById("quoteLength").value;
    if (quotelgth === 'Short'){
        quotelgth = "?minLength=1&maxLength=50";        
    } else if (quotelgth === 'Medium'){
        quotelgth= "?minLength=51&maxLength=300";
    } else if (quotelgth === 'Long'){
        quotelgth= "?minLength=301&maxLength=500";
    } else {
        alert("You must select a quote length");
    };

    var apiString = apiString + quotelgth + "?author";

    alert(apiString );     // show the API string

    // now make the API call to the web service using the string and store what is returned in response
    var response = await fetch(apiString);

    
    // finally, print the response in the various formats
    document.getElementById("myQuote").innerHTML = "";         // clear what was previously shown
    document.getElementById("quoteLength").value = "" ;
    var jsonData = await response.json();  // read the response as JSON

    myQuote = jsonData["content"];
    myAuthor = jsonData["author"];

    // stringify and print out the JSON object in the RawData section
    document.getElementById("myQuote").innerHTML += "<p>" + jsonData["content"] + "</p>"
       + "<br>" + "<br>" + "<p>" + jsonData["author"] + "</p>"
    ;

/*
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
    } */

    return true;
}