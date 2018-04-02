//var b = jsboard.board({ attach: "game", size: "8x9", style: "checkerboard" });
//b.style({ borderSpacing: "1px", margin: "0 auto", marginTop: "6px", });
//b.cell("each").style({ width: "70px", height: "60px" });
var b = jsboard.board({ attach: "game", size: "8x9" });
b.style({ borderSpacing: "1px", margin: "0 auto", marginTop: "6px", borderCollapse: "separate" });
b.cell("each").style({ width: "70px", height: "60px" });

// setup pieces
var knight = jsboard.piece({
    text: "WK", textIndent: "-9999px", background: "gray url(images/1LT.ico) center no-repeat"
    , width: "68px", height: "58px", margin: "0 auto", border: "1px solid black", borderRadius: "6px"
});
var opp = jsboard.piece({
    text: "BK", textIndent: "-9999px", background: "gray url(images/2LT.ico) center no-repeat"
    , width: "68px", height: "58px", margin: "0 auto", border: "1px solid black", borderRadius: "6px"
});

// create pieces to place in DOM
var k = knight.clone();
var o = opp.clone();

// place pieces on board
b.cell([5, 5]).place(k);
b.cell([2, 3]).place(o);