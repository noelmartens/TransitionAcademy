export { };
async function getWeather() {
    // first build the API call string by starting with the URL
    let apiString: string = "https://api.weather.gov/gridpoints/";

    //var apiString = "https://api.weather.gov/gridpoints/";
    // next add the parameters to the string using the drop down lists
    let theLocation: string =
        (<HTMLInputElement>document.getElementById('location')).value;
    //var theLocation = document.getElementById("location").value;
    apiString = apiString + theLocation + "/47,30/forecast";
    alert(apiString);  // show the API string

    // now make the API call to the web service using the string and store what is returned in response
    // response is data we got back
    let response: Response = await fetch(apiString);

    //var response = await fetch(apiString);
    let theWeather: string = "";  //this string will store what to display to the user

    // now, check the status property of the response object, 200-299 is valid
    if (response.status >= 200 && response.status <= 299) {  // valid status
        // read the response as JSON since it is a JSON file
        let jsonData: any = await response.json();

        let days: number = jsonData.properties.periods.length;

        document.getElementById("myDays").innerHTML = "";   // clear what was previously shown
        document.getElementById("myWeather").innerHTML = "";   // clear what was previously shown
        document.getElementById("myTemp").innerHTML = "";   // clear what was previously shown

        // create the user feedback with the repos and links
        for (let i :number = 0; i < days; i++) {   //loop through paragraphs
            //print out the information for the user and clear the userid
            document.getElementById("myDays").innerHTML +=
                jsonData.properties.periods[i].name + "<br><br>";
            document.getElementById("myWeather").innerHTML +=
                jsonData.properties.periods[i].shortForecast + "<br><br>";
            document.getElementById("myTemp").innerHTML +=
                jsonData.properties.periods[i].temperature +
                "° Farenheit" + "<br><br>";;

        }
    } else {    //invalid status 
        //handle errors
        theWeather = "<p>Error accessing weather API, status: " + response.status + ": " + response.statusText;
        console.log(response.status, response.statusText);
    }

}