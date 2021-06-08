const Joi = require('joi');
const cors = require('cors');
const { response } = require('express');
const express = require('express');
const app = express();


// use it before all route definitions
app.use(cors({ origin: '*' }));
app.use(express.json());
// Add headers
/*app.use(function (req, res, next) {

    // Website you wish to allow to connect
    res.setHeader('Access-Control-Allow-Origin', '*');

    // Request methods you wish to allow
    //res.setHeader('Access-Control-Allow-Methods', 'GET, POST, OPTIONS, PUT, PATCH, DELETE');

    // Request headers you wish to allow
    //res.setHeader('Access-Control-Allow-Headers', 'X-Requested-With,content-type');

    // Set to true if you need the website to include cookies in the requests sent
    // to the API (e.g. in case you use sessions)
    //res.setHeader('Access-Control-Allow-Credentials', true);

    // Pass to next layer of middleware
    next();
});*/

const albums = [
    { id: 1, group: 'Fleetwood Mac', albumName: 'Rumours          ' },
    { id: 2, group: 'Head East    ', albumName: 'Flat as a pancake' },
    { id: 3, group: 'Bob Seger    ', albumName: 'Greatest Hits    ' },
]

app.get('/', (req, res) => {
    res.send('Welcome to your music collection');
});




app.get('/api/albums', (req, res) => {
    console.log("GET - got to server");
    //list = albums.sort(compare);
    console.log("sending json array");
    res.send(albums.sort(compare));
    console.log(albums.sort(compare));
})




app.get('/api/albums/:id', (req, res) => {
    console.log("GET/ID - got to server");
    const myAlbum = [];
    album = albums.find(c => c.id === parseInt(req.params.id));
    if (!album) return res.status(404).send('the album with the given id was not found');
    myAlbum.push(album);
    console.log("sending json " + JSON.stringify(myAlbum));
    res.send(JSON.stringify(myAlbum));  // returns parms on url

})


//   post = add
app.post('/api/albums', (req, res) => {
    console.log("POST - got to server");
    // is the album valid?
    const { error } = validateAlbum(req.body);  //  if returns error  400
    if (error) {
        console.log("Errors - adding album");
        return res.status(400).send(error.details[0].message);
    }

    //  adds a new item to album array
    console.log("Post validated - adding album");
    var album;
    if (!req.body.id) {
        album = {
            id: albums.length + 1,
            group: req.body.group,
            albumName: req.body.albumName,
        }
    } else {
        album = {
            id: req.body.id,
            group: req.body.group,
            albumName: req.body.albumName,
        }
    }

    //console.log(`album is ${req.body.name}`);
    albums.push(album);
    res.send(JSON.stringify(album) + ' album has been added to collection');  // returns parms on url
})


//   put = update
app.put('/api/albums/:id', (req, res) => {
    console.log("PUT - got to server");
    // does the album exist?
    const album = albums.find(c => c.id === parseInt(req.params.id));
    if (!album) return res.status(404).send('the album with the given id was not found');


    console.log("update validated - processing");
    const { error } = validateAlbum(req.body);  //  if returns error  400
    if (error) return res.status(400).send(error.details[0].message);

    // update
    album.group = req.body.group;
    album.albumName = req.body.albumName;
    res.send(JSON.stringify(album)  + ' album has been updated');
})



app.delete('/api/albums/:id', (req, res) => {
    console.log("DELETE - got to server");
    // does the album exist?
    const album = albums.find(c => c.id === parseInt(req.params.id));
    if (!album) return res.status(404).send('the album with the given id was not found');

    //delete 
    console.log("delete validated - processing");
    const index = albums.indexOf(album);
    albums.splice(index, 1);

    res.send(JSON.stringify(album)  + ' album has been removed from the collection');
})




// port environment variable
const port = process.env.PORT || 3000;
app.listen(port, () => console.log(`listening on port ${port}....`));



function validateAlbum(myObject) {
    //  is the album valid?
    //console.log(myObject);
    const schema = Joi.object(myObject).keys({
        id: Joi.number().min(1).optional(),
        group: Joi.string().min(1).required(),
        albumName: Joi.string().min(3).required()
    })
    //console.log(schema);
    return Joi.validate(myObject, schema);
}



function compare(a, b) {
    // Use toUpperCase() to ignore character casing
    // used for sorting the array
    const id1 = a.id;
    const id2 = b.id;

    let comparison = 0;
    if (id1 > id2) {
        comparison = 1;
    } else if (id1 < id2) {
        comparison = -1;
    }
    return comparison;
}
