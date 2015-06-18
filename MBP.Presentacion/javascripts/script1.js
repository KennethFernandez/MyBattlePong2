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
            REDIPS.table.mark(true, 'table2', pos[1], pos[2] - 1);
            // merge cells:
            // 'h' - horizontally
            // true - clear mark after merging
            // 'table1' - table id
            REDIPS.table.merge('h', true, 'table2');
        };
    };
};