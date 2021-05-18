// global variables
let taDueTime:string = ""; 
let taTask:String    = "";
let taskArray: Array<string | string > = < "" | "">;
let myTaskList: any =
        (document.getElementById('myTaskList'));

    

function addTask() {
    let systemTime: string = timeNow();
    let myTask: string =
        (<HTMLInputElement>document.getElementById("task")).value;
    let dueTime: string =
        (<HTMLInputElement>document.getElementById("dueTime")).value;
    if (dueTime < systemTime) {
        alert("This task occurs in the past");
        return;
    }
    taskArray.push(dueTime);
    taskArray.push(myTask);
    
    let myButton : Element = 
        document.createElement("<button type=\"button\">Click Me!</button>");
    myTaskList.appendChild(myButton);
    let button : any = myTaskList.createElement('button');
    button.type = 'button';
    button.innerHTML = 'Press me';
    button.className = 'btn-styled';

    for (var i = 0; i < taskArray.length; i++) {

        let button : any = document.createElement('button');
        button.type = 'button';
        button.innerHTML = 'Press me';
        button.className = 'btn-styled';
        
        // …
    };
       
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

function timeNow(): string {
    let d: Date = new Date();
    let h: number = d.getHours();
    let m: number = d.getMinutes();
    return h + ":" + m;
}

/*function addButton() {
    //Create an input type dynamically.   
    var element = document.createElement("input");
    //Assign different attributes to the element. 
    element.type = type;
    element.value = type; // Really? You want the default value to be the type string?
    element.name = type; // And the name too?
    element.onclick = function() { // Note this is a function
      alert("blabla");
    };
  
    var foo = document.getElementById("fooBar");
    //Append the element in page (in span).  
    foo.appendChild(element);
  }
  document.getElementById("btnAdd").onclick = function() {
    add("text");*/
