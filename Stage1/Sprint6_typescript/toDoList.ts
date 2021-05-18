// Create a "close" button and append it to each list item
let myNodelist = document.getElementsByTagName("LI");

for (let i = 0; i < myNodelist.length; i++) {
    var span = document.createElement("SPAN");
    var txt = document.createTextNode("\u00D7");
    span.className = "close";
    span.appendChild(txt);
    myNodelist[i].appendChild(span);
}

// Click on a close button to hide the current list item
var close =
    document.getElementsByClassName("close");
for (let i = 0; i < close.length; i++) {
    close[i].onclick = function () {
        var div = this.parentElement;
        div.class = "li.checked";
        div.style.display = "none";
    }
}

// Add a "checked" symbol when clicking on a list item
let list: any = document.querySelector('ul');
list.addEventListener('click', function (ev : any) {
    if (ev.target.tagName === 'LI') {
        ev.target.classList.toggle('checked');
    }
}, false);

// Create a new list item when clicking on the "Add" button
function newElement(): void {
    let li: any = document.createElement("li");
    let inputValue: any =
        (<HTMLInputElement>document.getElementById("myInput")).value;
    let t: any = document.createTextNode(inputValue);
    li.appendChild(t);
    if (inputValue === '') {
        alert("You must write something!");
    } else {
        (<HTMLElement>document.getElementById("myUL")).appendChild(li);
    }
    
    (<HTMLInputElement>document.getElementById("myInput")).value = "";

    let span: any = document.createElement("SPAN");
    let txt: any = document.createTextNode("\u00D7");
    span.className = "close";
    span.appendChild(txt);
    li.appendChild(span);

    for (let i = 0; i < close.length; i++) {
        close[i].onclick = function () {
            var div = this.parentElement;
            div.class = "li.checked";
            div.style.display = "none";
        }
    }
}
