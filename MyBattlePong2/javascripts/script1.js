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

	rd.event.moved = function () {

	    var pos = rd.getPosition();

	};

    var listaDeNave = "";

	rd.event.dropped = function () { 
	    // get target and source position (method returns positions as array)
	    var pos = rd.getPosition();
	    var idObject = rd.obj.id;
	    idObject = idObject.split("c")[0];

	    console.log(idObject);

	    var tamanoX = 2;
	    var tamanoY = 4;

	    var desplazarX = -1;
	    var desplazarY = -1;

	    if (pos[1] + tamanoY-1< 10) { desplazarX = 1; }
	    if (pos[2] + tamanoX - 1 < 10) { desplazarY = 1; }

	    for (var i = 0; i < tamanoY; i++) {
            for (var j = 0; j < tamanoX; j++) {
                REDIPS.table.mark(true, 'table2',
                    pos[1] + i*desplazarX,
                    pos[2] + j*desplazarY);
            }
	            REDIPS.table.merge('h', true, 'table2');
	    }

	    for (var i = 0; i < tamanoY; i++) {
	        for (var j = 0; j < tamanoX; j++) {
	            REDIPS.table.mark(true, 'table2',
                    pos[1] + i*desplazarX,
                    pos[2] + j*desplazarY);
	        }
	    }

	    var Xinicial= pos[2];
	    var Yinicial= pos[1];

	    if (desplazarX == -1) {Xinicial = pos[2] + ((tamanoX-1)*desplazarX);}
	    if (desplazarX == -1) {Yinicial = pos[1] + ((tamanoY - 1) * desplazarY);}

	    listaDeNave += Xinicial.toString() + ",";
	    listaDeNave += Yinicial.toString() + ",";
	    listaDeNave += idObject.toString() + ",";

	    console.log(listaDeNave);

	    REDIPS.table.merge('v', true, 'table2');

	    rd.enableDrag(false, rd.obj);
	    
	};
};


// add onload event listener
if (window.addEventListener) {
	window.addEventListener('load', redips.init, false);
}
else if (window.attachEvent) {
	window.attachEvent('onload', redips.init);
}