// master.js
// Contains all Javascript for the web application

// Author: Jimmy Swanbeck
// Endicott College
// 12/31/14

// This Javascript file contributes to the view layer of the web application:
//		Adds extra functionality to web pages

// FUNCTIONS

// Load the homepage
function loadIndex(){
	// Load the page
	window.onload = function(){
		normalizeHeights("colStoreDocuments", "colViewDocuments", "colSearchDocuments");
	}

	// Resize the page
	window.onresize = function(){
		resizeHeights("colStoreDocuments", "hStore", "pStore", "colViewDocuments", "hView", "pView", "colSearchDocuments", "hSearch", "pSearch")
		normalizeHeights("colStoreDocuments", "colViewDocuments", "colSearchDocuments");
	}
}

// Load a popup window
function loadPopup(w, h){
	// Resize the page
	window.resize = function(){
		window.width = w;
		window.height = h;
	}
}

// Retrieve the value of a style on a specified element
// Borrowed from The JavaScript Anthology by James Edwards and Cameron Adams
// (Accessed via http://www.impressivewebs.com/equal-height-columns-with-javascript-full-version/)
function retrieveComputedStyle(element, styleProperty){
		var computedStyle = null;
		
		if (typeof element.currentStyle != "undefined")
		{
			computedStyle = element.currentStyle;
		}
		else
		{
			computedStyle = document.defaultView.getComputedStyle(element, null);
		}
		return computedStyle[styleProperty];
}

// Get a value from the query string
// Borrowed from http://css-tricks.com/snippets/javascript/get-url-variables/
function getQueryVariable(variable)
{
       var query = window.location.search.substring(1);
       var vars = query.split("&");
       for (var i=0;i<vars.length;i++) {
               var pair = vars[i].split("=");
               if(pair[0] == variable){return pair[1];}
       }
       return(false);
}

// Resize blocks to the height of their contents
function resizeHeights(left, hLeft, pLeft, mid, hMid, pMid, right, hRight, pRight){
	// Get columns and contents
	left = document.getElementById(left);
	hLeft = document.getElementById(hLeft);
	pLeft = document.getElementById(pLeft);

	right = document.getElementById(right);
	hRight = document.getElementById(hRight);
	pRight = document.getElementById(pRight);

	mid = document.getElementById(mid);
	hMid = document.getElementById(hMid);
	pMid = document.getElementById(pMid);

	// Get heights of individual styles for each element
	var leftBorderTopPixels = retrieveComputedStyle(left, "borderTopWidth");
	var leftBorderBottomPixels = retrieveComputedStyle(left, "borderBottomWidth");
	var leftPaddingTopPixels = retrieveComputedStyle(left, "paddingTop");
	var leftPaddingBottomPixels = retrieveComputedStyle(left, "paddingBottom");
	var leftBorderNumber = Number(leftBorderTopPixels.replace("px", "")) + Number(leftBorderBottomPixels.replace("px", ""));
	var leftPaddingNumber = Number(leftPaddingTopPixels.replace("px", "")) + Number(leftPaddingBottomPixels.replace("px", ""));
	var leftExtras = leftBorderNumber + leftPaddingNumber + 24;

	var midBorderTopPixels = retrieveComputedStyle(mid, "borderTopWidth");
	var midBorderBottomPixels = retrieveComputedStyle(mid, "borderBottomWidth");
	var midPaddingTopPixels = retrieveComputedStyle(mid, "paddingTop");
	var midPaddingBottomPixels = retrieveComputedStyle(mid, "paddingBottom");
	var midBorderNumber = Number(midBorderTopPixels.replace("px", "")) + Number(midBorderBottomPixels.replace("px", ""));
	var midPaddingNumber = Number(midPaddingTopPixels.replace("px", "")) + Number(midPaddingBottomPixels.replace("px", ""));
	var midExtras = midBorderNumber + midPaddingNumber + 24;

	var rightBorderTopPixels = retrieveComputedStyle(right, "borderTopWidth");
	var rightBorderBottomPixels = retrieveComputedStyle(right, "borderBottomWidth");
	var rightPaddingTopPixels = retrieveComputedStyle(right, "paddingTop");
	var rightPaddingBottomPixels = retrieveComputedStyle(right, "paddingBottom");
	var rightBorderNumber = Number(rightBorderTopPixels.replace("px", "")) + Number(rightBorderBottomPixels.replace("px", ""));
	var rightPaddingNumber = Number(rightPaddingTopPixels.replace("px", "")) + Number(rightPaddingBottomPixels.replace("px", ""));
	var rightExtras = rightBorderNumber + rightPaddingNumber + 24;

	left.style.height = (leftExtras + hLeft.offsetHeight + pLeft.offsetHeight + "px");
	mid.style.height = (midExtras + hMid.offsetHeight + pMid.offsetHeight + "px");
	right.style.height = (rightExtras + hRight.offsetHeight + pRight.offsetHeight + "px");
}

// Make all columns in any row with three columns the same height
function normalizeHeights(left, mid, right){
	// Get columns
	var leftCol = document.getElementById(left);
	var midCol = document.getElementById(mid);
	var rightCol = document.getElementById(right);

	// Get total heights
	var leftHeight = leftCol.offsetHeight;
	var midHeight = midCol.offsetHeight;
	var rightHeight = rightCol.offsetHeight;

	// Get heights of individual styles for each element
	var leftBorderTopPixels = retrieveComputedStyle(leftCol, "borderTopWidth");
	var leftBorderBottomPixels = retrieveComputedStyle(leftCol, "borderBottomWidth");
	var leftPaddingTopPixels = retrieveComputedStyle(leftCol, "paddingTop");
	var leftPaddingBottomPixels = retrieveComputedStyle(leftCol, "paddingBottom");
	var leftBorderNumber = Number(leftBorderTopPixels.replace("px", "")) + Number(leftBorderBottomPixels.replace("px", ""));
	var leftPaddingNumber = Number(leftPaddingTopPixels.replace("px", "")) + Number(leftPaddingBottomPixels.replace("px", ""));
	var leftExtras = leftBorderNumber + leftPaddingNumber;

	var midBorderTopPixels = retrieveComputedStyle(midCol, "borderTopWidth");
	var midBorderBottomPixels = retrieveComputedStyle(midCol, "borderBottomWidth");
	var midPaddingTopPixels = retrieveComputedStyle(midCol, "paddingTop");
	var midPaddingBottomPixels = retrieveComputedStyle(midCol, "paddingBottom");
	var midBorderNumber = Number(midBorderTopPixels.replace("px", "")) + Number(midBorderBottomPixels.replace("px", ""));
	var midPaddingNumber = Number(midPaddingTopPixels.replace("px", "")) + Number(midPaddingBottomPixels.replace("px", ""));
	var midExtras = midBorderNumber + midPaddingNumber;

	var rightBorderTopPixels = retrieveComputedStyle(rightCol, "borderTopWidth");
	var rightBorderBottomPixels = retrieveComputedStyle(rightCol, "borderBottomWidth");
	var rightPaddingTopPixels = retrieveComputedStyle(rightCol, "paddingTop");
	var rightPaddingBottomPixels = retrieveComputedStyle(rightCol, "paddingBottom");
	var rightBorderNumber = Number(rightBorderTopPixels.replace("px", "")) + Number(rightBorderBottomPixels.replace("px", ""));
	var rightPaddingNumber = Number(rightPaddingTopPixels.replace("px", "")) + Number(rightPaddingBottomPixels.replace("px", ""));
	var rightExtras = rightBorderNumber + rightPaddingNumber;

	// Find the largest height
	var largest = 0;
	if (leftHeight > (largest + leftExtras)){
		largest = leftHeight - leftExtras;
	}
	if (midHeight > (largest + midExtras)){
		largest = midHeight - midExtras;
	}
	if (rightHeight > (largest + rightExtras)){
		largest = rightHeight - rightExtras;
	}

	// Set all columns heights to that of the largest
	leftCol.style.height = (largest + leftExtras) + "px";
	midCol.style.height = (largest + midExtras) + "px";
	rightCol.style.height = (largest + rightExtras) + "px";
}

// Open a popup window
function popupWindow(url, title, w, h){
  var left = (screen.width/2)-(w/2);
  var top = (screen.height/2)-(h/2);
  return window.open(url, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+top+', left='+left);
} 

// Download the client
function downloadClient(version){
	if (version == 0){
		alert("Windows");
	}
	if (version == 1){
		alert("Mac");
	}

	window.close();
}

// Populate list of documents
function populateDocuments(documents){
	for (var i = 0; i < documents.length; i++){
		var x = document.createElement("option");
		x.value = documents[i][0];
		var y = document.createTextNode(documents[i][1]);
		x.appendChild(y);
		document.getElementById('lstDocuments').appendChild(x);
	}
}

// Remove special characters from input box
function valid(f){
	f.value = f.value.replace(',', '');
	f.value = f.value.replace(':', '');
}

// Select an email to display
function selectEmail(id, bodyTexts){
	for(var i = 0; i < bodyTexts.length; i++){
		if (bodyTexts[i][0] == id){
			txtBody = document.getElementById('txtBody');
			while (txtBody.firstChild){
				txtBody.removeChild(txtBody.firstChild);
			}
			txtBody.appendChild(document.createTextNode(bodyTexts[i][1]));
		}
	}
}

// Confirm Delete a document
function confirmDelete(id, documents){
	subject = ""
	for(var i = 0; i < documents.length; i++){
		if (documents[i][0] == id){
			subject = documents[i][1];
		}
	}

	var r = confirm("Are you sure you would like to delete this document: \n\n" + subject + "\n");
	return r;
}
