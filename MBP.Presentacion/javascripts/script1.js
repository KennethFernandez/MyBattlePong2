/*jslint white: true, browser: true, undef: true, nomen: true, eqeqeq: true, plusplus: false, bitwise: true, regexp: true, strict: true, newcap: true, immed: true, maxerr: 14 */
/*global window: false, REDIPS: true */

/* enable strict mode */
"use strict";

var board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]], // board array
	xo = { x: 1, o: -1 },	// define values for X and O elements
	redipsInit,		// define redipsInit variable
	rd,				// reference to the REDIPS.drag library
	divO,			// reference to the O DIV element
	// methods
	toggleXO,		// toggle X and O clone elements on the left
	checkBoard,		// method checks board
	checkLine;		// method checks line (row, column or diagonal) for value 3 or -3

// create redips container
var redips = {};

// redips initialization
redips.init = function () {
	// reference to the REDIPS.drag
	var rd = REDIPS.drag;
	// initialization
	rd.init();
	// set hover color
	rd.hover.colorTd = '#9BB3DA';
    // define border for disabled element (default is dotted)
	rd.style.borderDisabled = 'none';
    // dragged elements can be placed to the empty cells only
	rd.dropMode = 'single';
	// after element is cloned define dropping rule for last row (only for clones of A or B element)
	rd.event.cloned = function () {
    // define variables
	var clonedId = rd.obj.id; // cloned id


	    
	    // set reference to the O div element (needed in toggleXO() method)
	    divO = document.getElementById('o');
	    // toggle X and O elements on the left side
	    toggleXO();
	    // declare tasks after element is dropped
	    rd.event.dropped = function () {
	        var obj = rd.obj,		// current element (cloned element)
                objOld = rd.objOld,	// previous element (this is clone element)
                tac = rd.td.target;	// target cell
	        // disable dropped DIV element
	        rd.enableDrag(false, obj);
	        // toggle X and O elements on the left
	        toggleXO();
	        // check board (objOld.id can be 'x' or 'o')
	        checkBoard(objOld.id, tac.parentNode.rowIndex, tac.cellIndex);

	};



	rd.event.changed = function () {

	    var pos = rd.getPosition();
	    // display current row and current cell
	    REDIPS.table.mark(true, 'table2', pos[1], pos[2]);
	    REDIPS.table.mark(true, 'table2', pos[1], pos[2] - 1);
	    // and then split marked cell in table2
	    REDIPS.table.split('h', 'table2');


	};

	rd.event.moved = function () {

	    var pos = rd.getPosition();
	    // display current row and current cell
	    REDIPS.table.mark(true, 'table2', pos[1], pos[2]);
	    REDIPS.table.mark(true, 'table2', pos[1], pos[2] - 1);
	    // and then split marked cell in table2
	    REDIPS.table.split('h', 'table2');


	};

	


	rd.event.dropped = function () { 
	    // get target and source position (method returns positions as array)
	    var pos = rd.getPosition();
	    // display current row and current cell
	    REDIPS.table.mark(true, 'table2', pos[1], pos[2]);
	    REDIPS.table.mark(true, 'table2', pos[1], pos[2] -1);
	    // merge cells:
	    // 'h' - horizontally
	    // true - clear mark after merging
	    // 'table1' - table id
	    REDIPS.table.merge('h', true, 'table2');
	};

	// or cloned elements can be defined one by one
//	rd.only.div.ac0 = 'last';
//	rd.only.div.bc0 = 'last';
};


// add onload event listener
if (window.addEventListener) {
	window.addEventListener('load', redips.init, false);
}
else if (window.attachEvent) {
	window.attachEvent('onload', redips.init);
}


//*jslint white: true, browser: true, undef: true, nomen: true, eqeqeq: true, plusplus: false, bitwise: true, regexp: true, strict: true, newcap: true, immed: true, maxerr: 14 */
/*global window: false, REDIPS: true */

// toggle X and O clone elements on the left
toggleXO = function () {
    // references to the X and O elements
    if (divO.redips.enabled) {
        rd.enableDrag(false, '#o');
        rd.enableDrag(true, '#x');
    }
    else {
        rd.enableDrag(true, '#o');
        rd.enableDrag(false, '#x');
    }
};


// method checks board (KISS - keep it simple and stupid;)
checkBoard = function (id, row_idx, cell_idx) {
    // set value for current cell (1 or -1)
    board[row_idx][cell_idx] = xo[id];
    // test rows
    checkLine(board[0][0] + board[0][1] + board[0][2]);
    checkLine(board[1][0] + board[1][1] + board[1][2]);
    checkLine(board[2][0] + board[2][1] + board[2][2]);
    // test columns
    checkLine(board[0][0] + board[1][0] + board[2][0]);
    checkLine(board[0][1] + board[1][1] + board[2][1]);
    checkLine(board[0][2] + board[1][2] + board[2][2]);
    // test diagonals
    checkLine(board[0][0] + board[1][1] + board[2][2]);
    checkLine(board[0][2] + board[1][1] + board[2][0]);
};


// method checks line (row, column or diagonal) for value 3 or -3
checkLine = function (value) {
    if (value === 3) {
        document.getElementById('message').innerHTML = 'X is the Winner!';
        rd.enableDrag(false); // disable all drag elements
    }
    else if (value === -3) {
        document.getElementById('message').innerHTML = 'O is the Winner!';
        rd.enableDrag(false); // disable all drag elements
    }
};