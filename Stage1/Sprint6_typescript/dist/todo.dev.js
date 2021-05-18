"use strict"; // global variables

var taskArray = [];
var myTaskList = document.getElementById('myTaskList');

function addTask() {
  var systemTime = timeNow();
  var myTask = document.getElementById("task").value;
  var dueTime = document.getElementById("dueTime").value;

  if (dueTime < systemTime) {
    alert("This task occurs in the past");
    return;
  }

  taskArray.push(dueTime);
  taskArray.push(myTask);
  myTaskList.createButtonElement("<button type=\"button\">Click Me!</button>");
  var button = myTaskList.createElement('button');
  button.type = 'button';
  button.innerHTML = 'Press me';
  button.className = 'btn-styled';

  for (var i = 0; i < taskArray.length; i++) {
    var button_1 = document.createElement('button');
    button_1.type = 'button';
    button_1.innerHTML = 'Press me';
    button_1.className = 'btn-styled'; // …
  }

  ;
  /*
          var row = myTable.insertRow(myTable.rows.length);
          var cell1 = row.insertCell(0);
          var cell2 = row.insertCell(1);
          cell1.innerHTML = taskArray[i];
          i += 1;
          cell2.innerHTML = taskArray[i];
          cell1.style.color = "Black";
          cell2.style.color = "Black";
      }*/
}

function timeNow() {
  var d = new Date();
  var h = d.getHours();
  var m = d.getMinutes();
  return h + ":" + m;
}