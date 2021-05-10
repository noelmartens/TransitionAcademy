//export {}
// global variables
let winningConditions: number[][] = [
    [0, 1, 2],
    [3, 4, 5],
    [6, 7, 8],
    [0, 3, 6],
    [1, 4, 7],
    [2, 5, 8],
    [0, 4, 8],
    [2, 4, 6]
];
let statusDisplay: Element =
    (<HTMLElement>document.querySelector('.game--status'));
let gameActive: boolean = true;
let currentPlayer: string = "X";
let gameState: Array<string> = ["", "", "", "", "", "", "", "", ""];

let winningMessage = function () {
    return "Player " + currentPlayer + " has won!";
};

let drawMessage = function () {
    return "Game ended in a draw!";
};

let currentPlayerTurn = function () {
    return "It's " + currentPlayer + "'s turn";
};

/*
We set the inital message to let the players know whose turn it is
player is toggled on each move and we display who's turn it is
*/
statusDisplay.innerHTML = currentPlayerTurn();



function handleCellPlayed(clickedCell: any, clickedCellIndex: number) {
    /*
    We update our internal game state to reflect the played move,
    as well as update the user interface to reflect the played move
    */
    gameState[clickedCellIndex] = currentPlayer;
    clickedCell.innerHTML = currentPlayer;
}


function handlePlayerChange(curPlayer: string) {
    /*
    This toggles the player from x -> o and back and returns who's turn it is
    */
    currentPlayer = curPlayer === "X" ? "O" : "X";
    statusDisplay.innerHTML = currentPlayerTurn();
}


function handleResultValidation() {
    /*
    this checks the game state array.  if 3 in a row contain x or o, 
    we know the game is won by somebody.  If no moves left, game is a draw
    */
    let roundWon: boolean = false;
    let roundDraw: boolean = true;
    for (let i: number = 0; i <= 7; i++) {
        let winCondition = winningConditions[i];
        let a = gameState[winCondition[0]];
        let b = gameState[winCondition[1]];
        let c = gameState[winCondition[2]];
        if (a === '' || b === '' || c === '') {
            roundDraw = false;
            continue;
        }
        if (a === b && b === c) {
            roundWon = true;
            roundDraw = false;
            break;
        }
    }
    if (roundWon) {
        statusDisplay.innerHTML = winningMessage();
        gameActive = false;
        return;
    }
    if (roundDraw) {
        statusDisplay.innerHTML = drawMessage();
        gameActive = false;
        return;
    }
    handlePlayerChange(currentPlayer);
}


function handleCellClick(clickedCellEvent: any) {
    /*
    We will save the clicked html element in a variable for easier further use
    */
    let clickedCell: any = clickedCellEvent.target;
    /*
    Here we will grab the 'data-cell-index' attribute from the clicked cell to identify where that cell is in our grid.
    Please note that the getAttribute will return a string value. Since we need an actual number we will parse it to an
    integer(number)
    */
    let clickedCellIndex: number =
        parseInt(clickedCell.getAttribute('data-cell-index'));
    /*
    Next up we need to check whether the call has already been played,
    or if the game is paused. If either of those is true we will simply ignore the click.
    */

    if (gameState[clickedCellIndex] !== "" || !gameActive) {
        return;
    }
    /*
    If everything if in order we will proceed with the game flow
    */
    handleCellPlayed(clickedCell, clickedCellIndex);
    handleResultValidation();
}


function handleRestartGame() {
    /* 
    reset for a new game
    */
    gameActive = true;
    currentPlayer = "X";
    gameState = ["", "", "", "", "", "", "", "", ""];
    statusDisplay.innerHTML = currentPlayerTurn();
    document.querySelectorAll('.cell')
        .forEach(function (cell) { return cell.innerHTML = ""; });
}


document.querySelectorAll('.cell').forEach(
    function (cell) { return cell.addEventListener('click', handleCellClick); });

// question mark notation says ignore the message
document.querySelector('.game--restart')!.addEventListener(
    'click', handleRestartGame);