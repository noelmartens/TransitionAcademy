export{};
async function getLocations() {
    // first build the API call string by starting with the URL
    let apiString : string = "http://stapi.co/api/v1/rest/season/search";
    let response : Response = await fetch(apiString);

    let series : Array<any> = [];
    let titles : Array<any>= [];
    let episodes : Array<any> = [];

    // build the initial option
    document.getElementById("MySelect").innerHTML +=
        "<option selected disabled value=>Select a Series</option>"
    if (response.status >= 200 && response.status <= 299) { // success
        let jsonData : any = await response.json();               // read the JSON

        // convert json to array for sorting
        for (let i : number = 0; i < jsonData.seasons.length; i++) {
            series[i] = jsonData.seasons[i];
            titles[i] = series[i].title;
            episodes[i] = jsonData.seasons[i].numberOfEpisodes;
        }
        series.sort();
        titles.sort();
        for (let i : number = 0; i < titles.length; i++) {
            document.getElementById("MySelect").innerHTML +=
                "<option value=" + "\"" + titles[i] + "\"" + "> "
                + titles[i] + "</option>";

        }
    } else {
        let jsonData : Response = await response.json();
        document.getElementById("myEpisodes").innerHTML +=
            "<p> <Strong>" + "unable to retrieve locations - try again later" +
            "</Strong > <p>";
    }
}

async function getNumberEpisodes() {

    // first build the API call string by starting with the URL
    // now make the API call to the web service using the string 
    // and store what is returned in response
    let apiString : string = "http://stapi.co/api/v1/rest/season/search";
    let response : Response = await fetch(apiString);

    // next add the parameters to the string using the drop down lists
    let mySeries : string = 
    (<HTMLInputElement> document.getElementById("MySelect")).value;

    // clear the old data
    document.getElementById("myEpisodes").innerHTML = "";
    

    if (response.status >= 200 && response.status <= 299) {          // success
        let jsonData : any = await response.json();  // read the response as JSON
   
        for (let i:number = 0; i < jsonData.seasons.length; i++) {
            if (mySeries == jsonData.seasons[i].title){
                document.getElementById("myEpisodes").innerHTML +=
                "<p>" +
                jsonData.seasons[i].numberOfEpisodes + "</p>";
            } 
        }
    } else {
        let jsonData : any = await response.json();
        document.getElementById("myEpisodes").innerHTML +=
            "<p> <Strong>" + "unable to retrieve the number of episodes - try again later" +
            "</Strong > <p>";
    }

    return true;
}