async function getLocations() {
    // first build the API call string by starting with the URL
    var apiString = "http://stapi.co/api/v1/rest/season/search";
    var response = await fetch(apiString);

    var series = [];
    var titles = [];
    var episodes = [];

    // build the initial option
    document.getElementById("MySelect").innerHTML +=
        "<option selected disabled value=>Select a Series</option>"
    if (response.status >= 200 && response.status <= 299) { // success
        var jsonData = await response.json();               // read the JSON

        // convert json to array for sorting
        for (var i = 0; i < jsonData.seasons.length; i++) {
            series[i] = jsonData.seasons[i];
            titles[i] = series[i].title;
            episodes[i] = jsonData.seasons[i].numberOfEpisodes;
 
        }
        series.sort();
        titles.sort();
        for (var i = 0; i < titles.length; i++) {
            document.getElementById("MySelect").innerHTML +=
                "<option value=" + "\"" + titles[i] + "\"" + "> "
                + titles[i] + "</option>";

        }
    } else {
        var jsonData = await response.json();
        document.getElementById("myEpisodes").innerHTML +=
            "<p> <Strong>" + "unable to retrieve locations - try again later" +
            "</Strong > <p>";
    }
}

async function getNumberEpisodes() {

    // first build the API call string by starting with the URL
    // now make the API call to the web service using the string 
    // and store what is returned in response
    var apiString = "http://stapi.co/api/v1/rest/season/search";
    var response = await fetch(apiString);

    // next add the parameters to the string using the drop down lists
    var mySeries = document.getElementById("MySelect").value;

    // clear the old data
    document.getElementById("myEpisodes").innerHTML = "";
    

    if (response.status >= 200 && response.status <= 299) {          // success
        var jsonData = await response.json();  // read the response as JSON
   
        for (var i = 0; i < jsonData.seasons.length; i++) {
            if (mySeries == jsonData.seasons[i].title){
                document.getElementById("myEpisodes").innerHTML +=
                "<p>" +
                jsonData.seasons[i].numberOfEpisodes + "</p>";
            } 
        }
    } else {
        var jsonData = await response.json();
        document.getElementById("myEpisodes").innerHTML +=
            "<p> <Strong>" + "unable to retrieve the number of episodes - try again later" +
            "</Strong > <p>";
    }

    return true;
}