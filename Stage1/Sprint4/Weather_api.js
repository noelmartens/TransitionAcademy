async function getLocations() {
    // first build the API call string by starting with the URL
    var apiString = "https://api.weather.gov/products/locations";
    var response = await fetch(apiString);
    var myLoc = " ";
    var myCode = [];
    // build the initial option
    document.getElementById("MySelect").innerHTML +=
        "<option selected disabled value=>Select a location</option>"
    if (response.status >= 200 && response.status <= 299) { // success
        var jsonData = await response.json();               // read the JSON
        for (const [myKey, myValue] of Object.entries(jsonData.locations)) {
            if (myValue != null) {
                document.getElementById("MySelect").innerHTML +=
                    "<option value=" + myKey + ">" + myValue + "</option>"
            }
        }
    } else {
        var jsonData = await response.json();
        document.getElementById("myForecast").innerHTML +=
            "<p> <Strong>" + "unable to retrieve locations - try again later" +
            "</Strong > <p>";
    }
}

async function getForecast() {

    // first build the API call string by starting with the URL
    var apiString = "https://api.weather.gov/gridpoints/";

    // next add the parameters to the string using the drop down lists
    var myLocation = document.getElementById("MySelect").value;
    var apiString = apiString + myLocation + "/30,50/forecast?units=us";
    //alert(apiString);     // show the API string


    // clear the old data
    document.getElementById("myForecast").innerHTML = "";
    document.getElementById("myFCTable").innerHTML = "";
    // now make the API call to the web service using the string 
    // and store what is returned in response
    var response = await fetch(apiString);

    if (response.status >= 200 && response.status <= 299) {          // success
        var jsonData = await response.json();  // read the response as JSON
        var numDays = jsonData.properties.periods.length
        var table = document.getElementById("myFCTable");
        for (var i = 0; i < numDays; i++) {
            var row = table.insertRow(i);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            myDay = jsonData.properties.periods[i].name;
            myShortFc = jsonData.properties.periods[i].shortForecast;
            cell1.innerHTML = myDay;
            cell2.innerHTML = myShortFc;
            cell1.style.color = "Black";
            cell2.style.color = "Black";
            /*document.getElementById("myForecast").innerHTML +=
                "<p>" +
                (cell1 += myDay) + (cell2 += myShortFc) + "</p>";*/
        }
    } else {
        var jsonData = await response.json();
        document.getElementById("myForecast").innerHTML +=
            "<p> <Strong>" + "unable to retrieve forecast - try again later" +
            "</Strong > <p>";
    }

    return true;
}