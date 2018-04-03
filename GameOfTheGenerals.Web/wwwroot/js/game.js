//var b = jsboard.board({ attach: "game", size: "8x9", style: "checkerboard" });
//b.style({ borderSpacing: "1px", margin: "0 auto", marginTop: "6px", });
//b.cell("each").style({ width: "70px", height: "60px" });
var b = jsboard.board({ attach: "game", size: "8x9" });
b.style({ borderSpacing: "1px", margin: "0 auto", marginTop: "6px", borderCollapse: "separate" });
b.cell("each").style({ width: "70px", height: "60px" });

var pieces = [];

// setup pieces
pieces.push(generatePiece("1LT"));
pieces.push(generatePiece("2LT"));
pieces.push(generatePiece("BRG"));
pieces.push(generatePiece("COL"));
pieces.push(generatePiece("CPT"));
pieces.push(generatePiece("FLG"));
pieces.push(generatePiece("GEN"));
pieces.push(generatePiece("GOA"));
pieces.push(generatePiece("LTC"));
pieces.push(generatePiece("LTG"));
pieces.push(generatePiece("MAG"));
pieces.push(generatePiece("MAJ"));
pieces.push(generatePiece("SGT"));
pieces.push(generatePiece("SPY"));
pieces.push(generatePiece("SPY"));
for (var i = 0; i < 6; i++) {
    pieces.push(generatePiece("PVT"));
}

for (var i = 71; i > 50; i--) {
    b.cell([Math.floor(i / 9), i % 9]).place(pieces[71 - i]);
}
// create pieces to place in DOM

// place pieces on board
//b.cell([5, 5]).place(lt1);
//b.cell([6, 1]).place(lt2);
//b.cell([7, 8]).place(brg);


    function generatePiece(piece) {
        return jsboard.piece({ text: piece }).clone();
    }