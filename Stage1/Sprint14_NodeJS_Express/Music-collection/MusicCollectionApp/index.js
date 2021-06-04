const port = 5000;
const domainPrefix = "http://localhost:";
var errorFound = false;

function doMenu() {
    var menuOption = document.getElementById("menuOption").value;
    var albumId = document.getElementById("albumId").value;
    var groupName = document.getElementById("groupName").value;
    var albumName = document.getElementById("albumName").value;
    //alert("You selected option " + menuOption);

    // reset the form
    document.getElementById("menuOption").value = "";
    document.getElementById("albumId").value = "";
    document.getElementById("groupName").value = "";
    document.getElementById("albumName").value = "";

    validateOptions(menuOption, albumId, groupName, albumName);

    if (!errorFound) {
        switch (menuOption) {
            case "1":
                showAlbums(albumId);
                //getAlbums(albumId);
                break;

            case "2":
                addAlbums(albumId, groupName, albumName);
                break;

            case "3":
                updateAlbums(albumId, groupName, albumName);
                break;

            case "4":
                deleteAlbums(albumId)
                break;
        }
    }

}

async function showAlbums(albumId ) {
    // send the API call string by starting with the URL
    var apiString;
    if (albumId == "" ||  isNaN(albumId)) {
        apiString = domainPrefix + port + "/api/albums";
    } else {
        apiString = domainPrefix + port + "/api/albums/" + albumId;
    };
    //var apiString = domainPrefix + port + "/api/albums";


    const response = await fetch(apiString);
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }

    var jsonData = await response.json();
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }

    //  reset the collection view
    document.getElementById("myCollection").innerHTML = "";


    // loop through the JSON object one paragraph at a time and print each in the FormattedData section
    document.getElementById("myCollection").innerHTML += "<p>" +
        "<strong>" + "Your collection contains, these albums"
    "</strong>" + "</p>";
    for (var para in jsonData) {
        document.getElementById("myCollection").innerHTML += "<p>" +
            JSON.stringify(jsonData[para]) + "</p>";
    }
    //const myArray = JSON.parse(jsonData);
    //for (var para in myArray) {
    //    document.getElementById("myCollection").innerHTML += "<p>" +
    //        JSON.stringify(myArray[para]) + "</p>";
    //}
}


async function addAlbums(albumId, groupName, albumName) {
    // send the API call string by starting with the URL
    var apiString = domainPrefix + port + "/api/albums";
    // Creating a XHR object
    let http = new XMLHttpRequest();
    // Create a state change callback
    http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            var result = this.responseText;
            alert(result);
            showAlbums();
        }
    };
    let url = apiString;
    http.open("POST", url, true);
    http.setRequestHeader("Content-Type", "application/json");



    // Converting JSON data to string
    // albumID is optional and can be empty
    if (albumId == "") {
        var data = JSON.stringify({
            "group": groupName,
            "albumName": albumName
        });
    } else {
        var data = JSON.stringify({
            "id": parseInt(albumId),
            "group": groupName,
            "albumName": albumName
        })
    };


    // Sending data with the request
    http.send(data);
/*    http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            var result = this.responseText;
            alert(result);

        }
    };*/
    //getAlbums();
    showAlbums();
}

async function updateAlbums(albumId, groupName, albumName) {
    // send the API call string by starting with the URL
    var apiString = domainPrefix + port + "/api/albums/" + albumId;
    // Creating a XHR object
    let http = new XMLHttpRequest();

    // Create a state change callback
    http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            var result = this.responseText;
            alert(result);
            showAlbums();
        }
    };
    let url = apiString;
    http.open("PUT", url, true);
    http.setRequestHeader("Content-Type", "application/json");



    // Converting JSON data to string
    var data = JSON.stringify({ "group": groupName, "albumName": albumName });

    // Sending data with the request
    http.send(data);
 /*   http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            var result = this.responseText;
            alert(result);

        }
    }; */
    showAlbums();
    //getAlbums();
}

async function deleteAlbums(albumId) {
    // send the API call string by starting with the URL
    var apiString = domainPrefix + port + "/api/albums/" + albumId;
    // Creating a XHR object
    let http = new XMLHttpRequest();
    // Create a state change callback
    http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            var result = this.responseText;
            alert(result);
            showAlbums();
        }
    };
    let url = apiString;
    http.open("DELETE", url, true);
    http.setRequestHeader("Content-Type", "application/json");



    // Sending the request no parms needed for delete
    http.send();
   /* http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            var result = this.responseText;
            alert(result);

        }
    };*/
    showAlbums();
    //getAlbums();
}

async function getAlbums(albumId) {
    // send the API call string by starting with the URL
    var apiString;
    if (albumId == "") {
        apiString = domainPrefix + port + "/api/albums";
    } else {
        apiString = domainPrefix + port + "/api/albums/" + albumId;
    };

    // Creating a XHR object
    let http = new XMLHttpRequest();
    var result;
    // Create a state change callback
    http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {

            // Print received data from server
            result = this.responseText;
            alert(result);
            showAlbums();
        }
    };

    let url = apiString;
    http.open("GET", url, true);
    http.setRequestHeader("Content-Type", "application/json");



    // Sending data with the request
    //var result;
    http.send();
    showTheCollection(result);
    /*http.onreadystatechange = function () {
        if (http.readyState === 4 && http.status === 200) {
            // Print received data from server
            result = this.response;
            alert(result);
            showTheCollection(result);
        }
    };*/

    //var jsonData = await response.json();
    //if (!response.ok) {
    //    const message = `an error has occurred: ${response.status}`
    //    throw new Error(message);
    //}

    //  reset the collection view

}


function validateOptions(menuOption, albumId, groupName, albumName) {
    errorFound = false;

    if (menuOption == 1) {
        if (groupName > '') {
            errorFound = true;
            alert('Group name is not allowed now');
        } else if (albumName > '') {
            errorFound = true;
            alert('Album name is not allowed now');
        }
    }

    if (menuOption == 3) {
        if (albumId == '') {
            errorFound = true;
            alert('Album id is required');
        } else if (groupName == '') {
            errorFound = true;
            alert('Group name is required');
        } else if (albumName == '') {
            errorFound = true;
            alert('Album name is required');
        }
    }


    if (menuOption == 4) {
        if (albumId == '') {
            errorFound = true;
            alert('Album id is required');
        } else if (groupName > '') {
            errorFound = true;
            alert('Group name is not allowed now');
        } else if (albumName > '') {
            errorFound = true;
            alert('Album name is not allowed now');
        }
    }
}


function showTheCollection(result) {
    document.getElementById("myCollection").innerHTML = "";


    // loop through the JSON object one paragraph at a time and print each in the FormattedData section
    document.getElementById("myCollection").innerHTML += "<p>" +
        "<strong>" + "Your collection contains, these albums"
    "</strong>" + "</p>";
    const myArray = JSON.parse(result);
    for (var para in myArray) {
        document.getElementById("myCollection").innerHTML += "<p>" +
            JSON.stringify(myArray[para]) + "</p>";
    }
}