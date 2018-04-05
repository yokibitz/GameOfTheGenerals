//var b = jsboard.board({ attach: "game", size: "8x9", style: "checkerboard" });
//b.style({ borderSpacing: "1px", margin: "0 auto", marginTop: "6px", });
//b.cell("each").style({ width: "70px", height: "60px" });
var b = jsboard.board({ attach: "game", size: "8x9" });
b.style({ borderSpacing: "1px", margin: "0 auto", marginTop: "6px", borderCollapse: "separate" });
b.cell("each").style({ width: "70px", height: "60px" });

var ownPieces = [];

// setup pieces
ownPieces.push(generatePiece("1LT"));
ownPieces.push(generatePiece("2LT"));
ownPieces.push(generatePiece("BRG"));
ownPieces.push(generatePiece("COL"));
ownPieces.push(generatePiece("CPT"));
ownPieces.push(generatePiece("FLG"));
ownPieces.push(generatePiece("GEN"));
ownPieces.push(generatePiece("GOA"));
ownPieces.push(generatePiece("LTC"));
ownPieces.push(generatePiece("LTG"));
ownPieces.push(generatePiece("MAG"));
ownPieces.push(generatePiece("MAJ"));
ownPieces.push(generatePiece("SGT"));
ownPieces.push(generatePiece("SPY"));
ownPieces.push(generatePiece("SPY"));
for (var i = 0; i < 6; i++) {
    ownPieces.push(generatePiece("PVT"));
}

for (var i = 71; i > 50; i--) {
    b.cell([Math.floor(i / 9), i % 9]).place(ownPieces[71 - i]);

    // give functionality to pieces
    ownPieces[71 - i].addEventListener("click", function () { showMoves(this); });
}

var opponentPieces = [];

for (var i = 0; i < 21; i++) {
    opponentPieces.push(generatePiece("OPP"));
}

for (var i = 0; i < 21; i++) {
    b.cell([Math.floor(i / 9), i % 9]).place(opponentPieces[i]);
}


function generatePiece(piece) {
    return jsboard.piece({ text: piece }).clone();
}

// show new locations 
function showMoves(piece) {

    // parentNode is needed because the piece you are clicking 
    // on doesn't have access to cell functions, therefore you 
    // need to access the parent of the piece because pieces are 
    // always contained within in cells

    var greenCells = document.getElementsByClassName("green");
    
    for (var i = 0; i < greenCells.length; i) {
        greenCells[0].classList.remove("green");
    }

    var loc = b.cell(piece.parentNode).where();
    var newLocs = [
        //forward
        [loc[0] - 1, loc[1]],
        //right
        [loc[0], loc[1] + 1],
        //left
        [loc[0], loc[1] - 1],
        //down
        [loc[0] + 1, loc[1]]
    ];

    // locations to move to 
    // to use JavaScript DOM functions such as classList you need
    // to get the DOM node from the board which you can do by
    // calling cell([x,y]).DOM() or cell(this).DOM()
    for (var i = 0; i < newLocs.length; i++) {
        var newLocCell = b.cell(newLocs[i]);
        var pieceInCell = newLocCell.get();

        if (pieceInCell == undefined || pieceInCell === "OPP") {
            b.cell(newLocs[i]).DOM().classList.add("green");
            b.cell(newLocs[i]).on("click", movePiece);
        }
    }

    // move piece to new location when clicked
    function movePiece() {
        b.cell(this).place(piece);
        b.removeEvents("click", movePiece);
        for (var i = 0; i < newLocs.length; i++)
            b.cell(newLocs[i]).DOM().classList.remove("green");
    }
}