
async function getRepos() {

    // first build the API call string by starting with the URL
    var apiString = "https://api.github.com/users/";

    // next add the parameters to the string using the drop down lists
    var userName = document.getElementById("userName").value;
    var apiString = apiString + userName + "/repos";

    alert(apiString);     // show the API string


    // clear the old data
    document.getElementById("myRepos").innerHTML = "";
    document.getElementById("userName").value = "";

    // now make the API call to the web service using the string 
    // and store what is returned in response
    var response = await fetch(apiString);
    if (response.status >= 200 && response.status <= 299) {          // success
        var jsonData = await response.json();  // read the response as JSON
        for (var para in jsonData) {
            myURL = jsonData[para].html_url;
            myRepoName = jsonData[para].name;
            document.getElementById("myRepos").innerHTML +=
                "<p>" +
                "<a href=\"" + myURL + "\">" + myRepoName + "</a>" + "</p>";
        }

    } else if (response.status >= 300 && response.status <= 399) {   // redirects
        var jsonData = await response.json();  
        document.getElementById("myRepos").innerHTML +=
            "<p>" + "user " + userName + " " + jsonData.message + "<p>";

    } else if (response.status >= 400 && response.status <= 499) {   // bad request - client
        var jsonData = await response.json();  
        document.getElementById("myRepos").innerHTML +=
            "<p> <Strong>" + "user " + userName + " " + jsonData.message + "</Strong> <p>";

    } else if (response.status >= 500 && response.status <= 599) {   // bad response  - server
        var jsonData = await response.json();  
        document.getElementById("myRepos").innerHTML +=
            "<p>" + "user " + userName + " " + jsonData.message + "<p>";
    };

    return true;
}