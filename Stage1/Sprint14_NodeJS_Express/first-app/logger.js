const EventEmmitter = require('events');  // class
var url = 'http:mylogger.io/log';

class Logger extends EventEmmitter{
    log(message) {
        //send an http request
        console.log(message);
    
        // raised event
        this.emit('messageLogged', { id: 1, url: 'http://' });
    }
}

module.exports = Logger;

