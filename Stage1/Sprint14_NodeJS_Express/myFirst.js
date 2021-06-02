var http = require('http');
var dt = require('./myFirstModule');

http.createServer(function (req, res) {
  res.writeHead(200, {'Content-Type': 'text/html'});
  res.write("the date and time is currently: " + dt.myDateTime());
  res.end('Hello World!');
}).listen(8080);