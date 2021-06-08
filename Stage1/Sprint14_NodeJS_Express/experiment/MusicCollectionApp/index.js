const port = 5000;
const domainPrefix = "http://localhost:";
var errorFound = false;

function doMenu() {
    var menuOption = document.getElementById("menuOption").value;
    var albumId = document.getElementById("albumId").value;
    var groupName = document.getElementById("groupName").value;
    var albumName = document.getElementById("albumName").value;

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

async function showAlbums(albumId) {
    // send the API call string by starting with the URL
    var apiString;
    if (albumId == "" || isNaN(albumId)) {
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

}


async function addAlbums(albumId, groupName, albumName) {
    // send the API call string by starting with the URL
    var apiString = domainPrefix + port + "/api/albums";

    // Converting JSON data to string
    // albumID is optional and can be empty
    if (albumId == "" || isNaN(albumId)) {
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

    const response = await fetch(apiString, {
        headers: { "Content-Type": "application/json" },
        method: 'POST',
        body: data,
    });
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }

    var result = await response.text();
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }
    alert(result);
    showAlbums();
}

async function updateAlbums(albumId, groupName, albumName) {
    // send the API call string by starting with the URL
    var apiString = domainPrefix + port + "/api/albums/" + albumId;
    // Converting JSON data to string
    var data = JSON.stringify({ "group": groupName, "albumName": albumName });

    const response = await fetch(apiString, {
        headers: { "Content-Type": "application/json" },
        method: 'PUT',
        body: data,
    });
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }

    var result = await response.text();
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }
    alert(result);
    showAlbums();
}

async function deleteAlbums(albumId) {
    // send the API call string by starting with the URL
    var apiString = domainPrefix + port + "/api/albums/" + albumId;

    const response = await fetch(apiString, {
        headers: { "Content-Type": "application/json" },
        method: 'Delete',
    });
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }

    var result = await response.text();
    if (!response.ok) {
        const message = `an error has occurred: ${response.status}`
        throw new Error(message);
    }
    alert(result);
    showAlbums();
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