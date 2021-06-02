var nodemailer = require('nodemailer');

var transporter = nodemailer.createTransport({
  service: 'gmail',
  auth: {
    user: 'noel.martens@nelnet.net',
    pass: 'yourpassword'
  }
});

var mailOptions = {
  from: 'noelm@abe.midco.net',
  to: 'noel.martens@nelnet.net',
  subject: 'Sending Email using Node.js',
  text: 'That was easy!'
};

transporter.sendMail(mailOptions, function(error, info){
  if (error) {
    console.log(error);
  } else {
    console.log('Email sent: ' + info.response);
  }
});