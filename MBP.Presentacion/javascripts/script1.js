/*jslint white: true, browser: true, undef: true, nomen: true, eqeqeq: true, plusplus: false, bitwise: true, regexp: true, strict: true, newcap: true, immed: true, maxerr: 14 */
/*global window: false, REDIPS: true */

/* enable strict mode */
"use strict";

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
	// single element per cell
	rd.dropMode = 'single';
	// after element is cloned define dropping rule for last row (only for clones of A or B element)
	rd.event.cloned = function () {
		// define variables
		var clonedId = rd.obj.id; // cloned id

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