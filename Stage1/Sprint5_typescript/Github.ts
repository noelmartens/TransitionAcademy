export { };
async function getRepos() {
    // first build the API call string by starting with the URL
    let apiString: string = "https://api.github.com/users";
    // next add the parameters to the string using the drop down lists
    let theNewUser: string =
        (<HTMLInputElement>document.getElementById('userName')).value;
    apiString = apiString + "/" + theNewUser + "/repos";
    //alert(apiString);  // show the API string

    // now make the API call to the web service using the string and store what is returned in response
    // response is data we got back
    let response : Response = await fetch(apiString);
    // read the response as JSON since it is a JSON file
    let jsonData : any = await response.json();

    //check to see if the data was returned and provide the proper message or info
    let theRepos : string = "";  //this string will store what to display to the user
    // finally, print the response in the various formats
    if (jsonData.message == "Not Found") {  //github returns this in JSON file if not found
        theRepos = "User was not found."  // display if not found
    }
    else {   //user was found so continue
        for (let aRepos in jsonData) {   //loop through repos 
            theRepos += "<p><a href=" + jsonData[aRepos].html_url + ">" + jsonData[aRepos].name + "</a></p>";
            //alert(theRepos)
        }
    }

    document.getElementById("userName").innerHTML = "";   // clear what was previously shown
    document.getElementById("myRepos").innerHTML = "";   // clear what was previously shown


    //json object can be accessed directly
    document.getElementById("myUser").innerHTML = theNewUser;
    (<HTMLInputElement> document.getElementById("myRepos")).innerHTML = theRepos;
    (<HTMLInputElement> document.getElementById('userName')).value = "";

}