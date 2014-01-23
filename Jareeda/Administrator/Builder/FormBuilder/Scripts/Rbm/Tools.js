/*
************************************************************************************************************************************
***                                                                                                                              ***
*** Tools File v1.0                                                                                                              ***
*** By Ramy Mostafa -							                                                                                 ***
*** 13/01/2009                                                                                                                   ***
*** Last Modified January 15 2009                                                                                                ***                                                                                                        ***
************************************************************************************************************************************
*/

/*********************** Global Variables ***********************************************************************************************/
///
/// These are the key constants they are intended to be used instead of using the key numbers
/// within the code.
///
var RbmKeyConsts =
{    
    KEY_F1           :112,
    KEY_F2           :113,
    KEY_F3           :114,
    KEY_F4           :115,
    KEY_F5           :116,
    KEY_F6           :117,
    KEY_F7           :118,
    KEY_F8           :119,
    KEY_F9           :120,
    KEY_F10          :121,
    KEY_F11          :122,
    KEY_F12          :123,
    KEY_CTRL         :17,
    KEY_SHIFT        :16,
    KEY_ALT          :18,
    KEY_ENTER        :13,
    KEY_HOME         :36,
    KEY_END          :35,
    KEY_LEFT         :37,
    KEY_RIGHT        :39,
    KEY_UP           :38,
    KEY_DOWN         :40,
    KEY_PAGEUP       :33,
    KEY_PAGEDOWN     :34,
    KEY_ESC          :27,
    KEY_SPACE        :32,
    KEY_TAB          :9,
    KEY_ENTER        :13,
    KEY_BACK         :8,
    KEY_DELETE       :46,
    KEY_INSERT       :45,
    KEY_CONTEXT_MENU :93,
    KEY_CTRL_V       :86    
};

var RbmBrowserTypeString = navigator.userAgent.toLowerCase(); // Gets the user agent type string
//
// Get The Browser Type
//
var RbmBrowserType = 
{
    Opera    : (RbmStringContains(RbmBrowserTypeString,"opera")),
    Opera9   : (RbmStringContains(RbmBrowserTypeString,"opera/9") || RbmStringContains(RbmBrowserTypeString,"opera 9")),
    Safari   : (RbmStringContains(RbmBrowserTypeString,"safari")),
    Safari3  : (RbmStringContains(RbmBrowserTypeString,"version/3") && RbmStringContains(RbmBrowserTypeString,"safari")),
    IE       : (RbmStringContains(RbmBrowserTypeString,"msie")),
    IE5      : (RbmStringContains(RbmBrowserTypeString,"msie") && RbmStringContains(RbmBrowserTypeString,"5.5")),
    IE7      : (RbmStringContains(RbmBrowserTypeString,"msie") && RbmStringContains(RbmBrowserTypeString,"7.")),
    IE8      : (RbmStringContains(RbmBrowserTypeString,"msie") && RbmStringContains(RbmBrowserTypeString,"8.")),
    Firefox  : (RbmStringContains(RbmBrowserTypeString,"firefox")),
    Firefox3 : (RbmStringContains(RbmBrowserTypeString,"firefox/3.") && RbmStringContains(RbmBrowserTypeString,"firefox")),
    Mozilla  : (RbmStringContains(RbmBrowserTypeString,"mozilla")),
    NetScape : (RbmStringContains(RbmBrowserTypeString,"netscape")),
    WebTV    : (RbmStringContains(RbmBrowserTypeString,"WebTV")),
    ICab     : (RbmStringContains(RbmBrowserTypeString,"iCab")),
    Omniweb  : (RbmStringContains(RbmBrowserTypeString,"OmniWeb"))
}


var RbmOperatingSystemType = 
{
    Linux    : (RbmStringContains(RbmBrowserTypeString,"linux")),
    Unix   : (RbmStringContains(RbmBrowserTypeString,"x11")),
    Mac   : (RbmStringContains(RbmBrowserTypeString,"mac")),
    Windows  : (RbmStringContains(RbmBrowserTypeString,"win"))
}

//
// Get Operating System Type
//

/************************************************************************************************************************************/

/*********************** Global Methods ***********************************************************************************************/
///
/// Convert pixel to integer
///
function RbmPxToInt(px) {
    var result = 0;
    if (px != null && px != "") {
        try {
            var indexOfPx = px.indexOf("px");
            if (indexOfPx > -1)
                result = parseInt(px.substr(0, indexOfPx));
        } catch(e) { }
    }
    return result;
}
///
/// This function is used to check if a sub string exists in the main string or not
///
function RbmStringContains(mainStringstr,subString) {
    var mainString = new String(mainStringstr);
	place = mainString.indexOf(subString) > -1;
	return place;
}
///
/// This function is used to insert HTML in a control
///
function RbmInsertHtml(control,html){
    control.innerHTML = "<em>&nbsp;</em>" + html;
    control.removeChild(control.firstChild);
}
///
/// This function is used to append HTML in a control
///
function RbmAppendHtml(control,html){
    control.innerHTML = control.innerHTML + html;
}
///
/// This function is used to Encapsulate the given text in to an Html tag
///
function RbmEncapsulateHtml(content,htmlStartTag,htmlEndTag){
    return htmlStartTag + ' ' + content + ' ' + htmlEndTag;
}
///
/// This function is used to get the Inner Text of a container from different browsers.
///
function RbmGetInnerText(container) {
    if (RbmBrowserType.Mozilla)
        return container.textContent;
    else if (RbmBrowserType.Safari) {
        var filter = document.createElement("DIV");
        filter.innerHTML = container.innerHTML;
        var innerText = filter.innerText;
        return innerText;
    } else
        return container.innerText;
}

///
/// This function is used to Check whether a parent element contains the child element or not.
///
function RbmCheckParent(parent,child){
    while(child != null){
        if(child == parent) return true;
        child = child.parentNode;
        
    }
    return false;
}
///
/// This function is used to Check whether a parent element contains the child element or not using the parentId.
///
function RbmCheckParentById(parentId,child){   
    
    //alert('parent ' + parentId);
    while(child != null){
        if(child.id == parentId) return true;
       // alert('child ' + child.id);
        child = child.parentNode;
    }
    return false;
}
///
/// This function is used to get the parent element of a child element using the parentId.
///
function RbmGetParentById(parentId,child){   
    while(child != null){
        if(child.id == parentId) return child;
        child = child.parentNode;
    }
    return null;
}
function RbmGetChildByTagName(element, tagName, index) {
    if(element != null){                
        var collection = RbmGetElementsByTagName(element, tagName);
        if(collection != null){
            if(index < collection.length)
                return collection[index];
        }
    }
    return null;
}
///
/// This function is used to get if the selected range in the required parent in firefox.
///
function RbmRangeCompareNode(range, node) {
  var nodeRange = node.ownerDocument.createRange();
  try {
    nodeRange.selectNode(node);
  }
  catch (e) {
    nodeRange.selectNodeContents(node);
  }
  var nodeIsBefore = range.compareBoundaryPoints(Range.START_TO_START, nodeRange) == 1;
  var nodeIsAfter = range.compareBoundaryPoints(Range.END_TO_END, nodeRange) == -1;

  if (nodeIsBefore && !nodeIsAfter)
    return false;
  if (!nodeIsBefore && nodeIsAfter)
    return false;
  if (nodeIsBefore && nodeIsAfter)
    return true;

  return false;
}
function RbmIsTextNode(node) {
	return node.nodeType==3;
}

function RbmRightPart(node, ix) {
	return node.splitText(ix);
}
function RbmLeftPart(node, ix) {
	node.splitText(ix);
	return node;
}
///
/// This function is used to get the selected Range.
///
function RbmGetSelectedRange(controlContent){
    var selectedRange = null;
    if(document.selection)
        selectedRange = document.selection.createRange();
    else if(window.selection)
        selectedRange = window.selection.createRange();
    if(selectedRange == null){
        if(window.getSelection() != null)
        {
            if (RbmIsExists(window.getSelection().getRangeAt))
		        selectedRange = window.getSelection().getRangeAt(0);
        	else { // Safari!
		        var range = document.createRange();
		        range.setStart(window.getSelection().anchorNode,window.getSelection().anchorOffset);
		        range.setEnd(window.getSelection().focusNode,window.getSelection().focusOffset);
		        selectedRange = range;
	        }       
        }
    }
    var t = null;
    
    if(selectedRange != null && RbmBrowserType.IE)
    {
       t = RbmCheckParentById(controlContent.id,selectedRange.parentElement()); 
//       if(t == false)
//        t = RbmCheckParent(controlContent.parentNode,selectedRange.parentElement()); 
    }
    else{
        t = RbmRangeCompareNode(selectedRange,controlContent);
    }
    if(!t  && controlContent != null)
        selectedRange = null;
    return selectedRange;
}

///
/// Object is null
///
function RbmIsNull(control)
{
    if(control != null && control != 'undefined')
    {
        return false;
    }
    return true;
}
function RbmIFrameWindow(name) {
    if(RbmBrowserType.IE)
        return window.frames[name].window;
    else{
        var frameElement = document.getElementById(name);
        return (frameElement != null) ? frameElement.contentWindow : null;
    }
}
function RbmIFrameDocument(name) {
    if(RbmBrowserType.IE)
        return window.frames[name].document;
    else{
        var frameElement = document.getElementById(name);
        return (frameElement != null) ? frameElement.contentDocument : null;
    }
}
function RbmIsExists(obj){
    return (typeof(obj) != "undefined") && (obj != null);
}
function RbmGetElementById(id){
    if(RbmIsExists(document.getElementById))
        return document.getElementById(id);
    else
        return document.all[id];
}
///
/// This method get an element by its tagName
///
function RbmGetElementsByTagName(element, tag){
    
    var tagName = new String(tag);
    
    if(element != null){        
        tagName = tagName.toUpperCase();
        if (RbmIsExists(element.all) && !RbmBrowserType.Firefox3)
            return RbmBrowserType.NetScape ? element.all.tags[tagName] : element.all.tags(tagName);
        else
            return element.getElementsByTagName(tagName);
    }
    return null;
}

function RbmGetHeadElementOrCreateIfNotExist(doc) {
    var elements = RbmGetElementsByTagName(doc, "head");
    var head = null;
    // The Head element might not exist in the Safari browser, if the document content 
    // was created via the document.write() method. In this situation, we must create it.
    if (elements.length == 0) {
        head = doc.createElement("head");
        head.visibility = "hidden";
        doc.insertBefore(head, doc.body);
    } else
        head = elements[0];
    return head;
}
function RbmGetPointerCursor() {
    return RbmBrowserType.IE ? "hand" : "pointer";
}
function RbmSetPointerCursor(element) {
    if(element.style.cursor == "")
        element.style.cursor = RbmGetPointerCursor();
}
///
/// Get the attribute value of an object in a safe way
///
function RbmGetAttribute(obj, attrName){
    if(RbmIsExists(obj.getAttribute))
        return obj.getAttribute(attrName);
    else if(RbmIsExists(obj.getPropertyValue))
        return obj.getPropertyValue(attrName);
    return null;
}
///
/// Set the attribute value of an object in a safe way
///
function RbmSetAttribute(obj, attrName, value){
    if(RbmIsExists(obj.setAttribute))
        obj.setAttribute(attrName, value);
    else if(RbmIsExists(obj.setProperty))
        obj.setProperty(attrName, value, "");
}
function RbmBindEvent(target, eventName, fun) {
    //alert('iam in');
	if (target.addEventListener) {
		target.addEventListener(eventName, fun, false);
	} else {
		target.attachEvent("on" + eventName, function(){ fun(event); });
	} 
}
function RbmGetDotNetCtrl(idstr,parentidstr,tagstr)
{
    var id = new String(idstr);
    var tag = new String(tagstr);
    var parentId = new String(parentidstr);
    var arObj = RbmGetElementsByTagName(document,tag);
    
    var serverCtrlName = id.replace(/_/g,'$');
    
    var regExId = new RegExp(id+"$", "ig");

    for (var i = 0; i < arObj.length; i++)
    {
        if (RbmIsExists(arObj[i].id))
        {
            
            if (arObj[i].id.match(regExId) && RbmStringContains(arObj[i].id,parentId))
                return arObj[i];
        }
        else if (RbmIsExists(arObj[i].name))
        {
            
            if (arObj[i].name == serverCtrlName && RbmStringContains(arObj[i].name,parentId))
               return arObj[i];
        }
    }
    return false;
}
function PrintTestSelected(controlContent)
{   
    var oDiv = RbmGetElementById(controlContent);
    var x = RbmGetSelectedRange(oDiv);
    if(RbmBrowserType.IE && x != null)
    {
            var ret = "";
		    var rng = x;
		    if (rng.length)
			    ret = rng.item(0).outerHTML;
		    else if (rng.htmlText)
			    ret = rng.htmlText;
	        
            alert(ret);
    }
    else
    {
           var ret = "";
		  var rng = x;
			    var tempDiv = document.createElement("span");                    
			    var tempDiv1 = document.createElement("span");
			    //var tempDiv1 = document.createElement("span");
			    var clonedFragment = rng.cloneContents();			
//			    
			    if (RbmIsExists(clonedFragment)) {
			        //clonedFragment.surroundContents(tempDiv);
			        //alert(window.getSelection().anchorNode.innerHTML);
			        tempDiv.appendChild(clonedFragment);
			        //tempDiv1.appendChild(tempDiv);
			        ret = tempDiv.innerHTML;
			    }
		    
            alert(ret);
    }
}

/************************************************************************************************************************************/

/*********************** Stylesheet Methods******************************************************************************************/
///
/// Add Stylesheet Reference To Document
///
function RbmAddStyleSheetLinkToDocument(doc, linkUrl) {
    var newLink = RbmCreateStyleLink(doc, linkUrl);    
    var head = RbmGetHeadElementOrCreateIfNotExist(doc);
    head.appendChild(newLink);
}
///
/// Remove Stylesheet link from document
///
function RbmRemoveStyleSheetLinkFromDocument(filename){
     var allsuspects= RbmGetElementsByTagName("link")
     for (var i=allsuspects.length; i>=0; i--){ //search backwards within nodelist for matching elements to remove
      var attrValue = RbmGetAttribute(allsuspects[i],"href");
      if (RbmIsExists(allsuspects[i])  && !RbmIsNull(attrValue) && attrValue.indexOf(filename)!= -1)
        allsuspects[i].parentNode.removeChild(allsuspects[i]) //remove element by calling parentNode.removeChild()
     }
}
///
/// Create a style sheet Link object
///
function RbmCreateStyleLink(doc, url) {
    var link = doc.createElement("link");
    RbmSetAttribute(link, "href", url);
    RbmSetAttribute(link, "type", "text/css");
    RbmSetAttribute(link, "rel", "stylesheet");
    return link;
}
///
/// Create a style sheet rule
///
function RbmAddStyleSheetRule(styleSheet, selector, cssText){
    if(!RbmIsExists(cssText) || cssText == "") return;
    if(RbmBrowserType.IE)
        styleSheet.addRule(selector, cssText);
    else
        styleSheet.insertRule(selector + " { " + cssText + " }", styleSheet.cssRules.length);
}
///
/// Remove style sheet rule
/// 
function RbmRemoveStyleSheetRule(styleSheet, index){
    var rules = RbmGetStyleSheetRules(styleSheet);
    if(rules != null && rules.length > 0 && rules.length >= index){
        if(RbmBrowserType.IE)
            styleSheet.removeRule(index);
        else            
            styleSheet.deleteRule(index);     
    }                
}
///
/// Get a stylesheet rule
///
function RbmGetStyleSheetRule(className){
    for(var i = 0; i < document.styleSheets.length; i ++){
        var styleSheet = document.styleSheets[i];
        var rules = RbmGetStyleSheetRules(styleSheet);
        if(rules != null){
            for(var j = 0; j < rules.length; j ++){
                if(rules[j].selectorText == "." + className){
                    return rules[j];
                }
            }
        }
    }
    return null;
}
///
/// Get Stylesheet Rules
///
function RbmGetStyleSheetRules(styleSheet){
    try {
        return RbmBrowserType.IE ? styleSheet.rules : styleSheet.cssRules;
    }
    catch(e) {
        return null;
    }
}
///
/// Create style sheet in given document
///
function RbmCreateStyleSheetInDocument(doc) {
    if(RbmBrowserType.IE)
        return doc.createStyleSheet();
    else {
        var styleSheet = doc.createElement("STYLE");
        RbmGetChildByTagName(doc, "HEAD", 0).appendChild(styleSheet);
        return doc.styleSheets[doc.styleSheets.length - 1];
    }
}
///
/// Create style sheet
///
function RbmCreateStyleSheet(){
    return RbmCreateStyleSheetInDocument(document);
}

/************************************************************************************************************************************/


/*********************** Position Methods********************************************************************************************/
/*********************** Helping Methods********************************************************************************************/
function RbmGetDocumentScrollLeft(){
    if(RbmBrowserType.Safari || RbmBrowserType.IE5 || document.documentElement.scrollLeft == 0)
        return document.body.scrollLeft;
    return document.documentElement.scrollLeft;
}

function RbmGetDocumentScrollTop(){
    if(RbmBrowserType.Safari || RbmBrowserType.IE5 || document.documentElement.scrollTop == 0)
        return document.body.scrollTop;
    return document.documentElement.scrollTop;
}

function RbmGetIEDocumentClientOffsetInternal(IsX){
    var clientOffset = 0;
    if(RbmBrowserType.IE){
        if(RbmIsExists(document.documentElement))
            clientOffset = IsX ? document.documentElement.clientLeft : document.documentElement.clientTop;
        if(clientOffset == 0 && RbmIsExists(document.body))
            var clientOffset = IsX ? document.body.clientLeft : document.body.clientTop;
    }
    return clientOffset;
}
function RbmGetCurrentStyle(element){
    if (RbmBrowserType.IE)
        return element.currentStyle;
    else if (RbmBrowserType.Opera && !RbmBrowserType.Opera9)
        return window.getComputedStyle(element, null);
    else
        return document.defaultView.getComputedStyle(element, null);
}

function RbmGetDocumentScrollTop(){
    if(RbmBrowserType.Safari || RbmBrowserType.IE5 || document.documentElement.scrollTop == 0)
        return document.body.scrollTop;
    return document.documentElement.scrollTop;
}
/************************************************************************************************************************************/
/*********************** Absolute Position X Methods ********************************************************************************/
function RbmGetAbsolutePositionX(curEl){
    if (RbmBrowserType.IE)
        return RbmGetAbsolutePositionX_IE(curEl);
    if (RbmBrowserType.Opera)
        return RbmGetAbsolutePositionX_Opera(curEl);
    if(RbmBrowserType.NetScape)
        return RbmGetAbsolutePositionX_NS(curEl);
    if(RbmBrowserType.Safari)
        return RbmGetAbsolutePositionX_Safari(curEl);
    return RbmGetAbsolutePositionX_Other(curEl);
}
function RbmGetAbsolutePositionX_Opera(curEl){
    var pos = RbmGetAbsoluteOffsetX_OperaFFSafari(curEl);
    while (curEl != null) {
        pos += curEl.offsetLeft;
        pos -= curEl.scrollLeft;
        curEl = curEl.offsetParent;
    }
    pos += document.body.scrollLeft;
    return pos;
}
function RbmGetAbsolutePositionX_IE(curEl){
    if(curEl == null) return 0;
    return curEl.getBoundingClientRect().left + RbmGetDocumentScrollLeft() - RbmGetIEDocumentClientOffsetInternal(true);
}
function RbmGetAbsolutePositionX_NS(curEl){
    var pos = RbmGetAbsoluteOffsetX_OperaFFSafari(curEl);
    var isFirstCycle = true;
    while (curEl != null) {
        pos += curEl.offsetLeft;
        if (!isFirstCycle && curEl.offsetParent != null)
            pos -= curEl.scrollLeft;
        if (!isFirstCycle && RbmBrowserType.Firefox){
            var tagName = curEl.tagName.toUpperCase();
            var style = RbmGetCurrentStyle(curEl);
            if(tagName == "DIV" && style.overflow.toUpperCase() != "visible")
                pos += RbmPxToInt(style.borderLeftWidth);
        }
        isFirstCycle = false;
        curEl = curEl.offsetParent;
    }
    return pos;
}
function RbmGetAbsolutePositionX_Safari(curEl){
    var pos = RbmGetAbsoluteOffsetX_OperaFFSafari(curEl);
    while (curEl != null) {
        pos += curEl.offsetLeft;
        curEl = curEl.offsetParent;
    }
    return pos;
}
function RbmGetAbsoluteOffsetX_OperaFFSafari(curEl){ // B91523
    var pos = 0;
    while (curEl != null) {
        var tagname = curEl.tagName.toUpperCase();
        if(tagname == "BODY") break;
        
        var style = RbmGetCurrentStyle(curEl);
        if(!RbmBrowserType.Safari && style.position == "absolute") break;
        
        if(tagname == "DIV" && (RbmBrowserType.Safari || style.position == "" || style.position == "static")){
            pos -= curEl.scrollLeft;
        }
        curEl = curEl.parentNode;
    }
    return pos;
}
function RbmGetAbsolutePositionX_Other(curEl){
    var pos = 0;
    var isFirstCycle = true;
    while (curEl != null) {
        pos += curEl.offsetLeft;
        if (!isFirstCycle && curEl.offsetParent != null)
            pos -= curEl.scrollLeft;
        isFirstCycle = false;
        curEl = curEl.offsetParent;
    }
    return pos;
}
/************************************************************************************************************************************/
/*********************** Absolute Position Y Methods ********************************************************************************/

function RbmGetAbsolutePositionY(curEl){
    if (RbmBrowserType.IE)
        return RbmGetAbsolutePositionY_IE(curEl);
    if (RbmBrowserType.Opera)
        return RbmGetAbsolutePositionY_Opera(curEl);
    if(RbmBrowserType.NetScape)
        return RbmGetAbsolutePositionY_NS(curEl);
    if(RbmBrowserType.Safari)
        return RbmGetAbsolutePositionY_Safari(curEl);
    return RbmGetAbsolutePositionY_Other(curEl);
}

function RbmGetAbsolutePositionY_Opera(curEl){
	if(curEl && curEl.tagName == "TR" && curEl.cells.length > 0)
		curEl = curEl.cells[0];
    var pos = RbmGetAbsoluteOffsetY_OperaFFSafari(curEl);
    while (curEl != null) {
        pos += curEl.offsetTop;
        pos -= curEl.scrollTop;
        curEl = curEl.offsetParent;
    }
    pos += document.body.scrollTop;
    return pos;
}

function RbmGetAbsolutePositionY_IE(curEl){
    if(curEl == null) return 0;
    return curEl.getBoundingClientRect().top + RbmGetDocumentScrollTop() - RbmGetIEDocumentClientOffsetInternal(false);
}
function RbmGetAbsolutePositionY_NS(curEl){
    var pos = RbmGetAbsoluteOffsetY_OperaFFSafari(curEl);
    var isFirstCycle = true;
    while (curEl != null) {
        pos += curEl.offsetTop;
        if (!isFirstCycle && curEl.offsetParent != null)
            pos -= curEl.scrollTop;
        if (!isFirstCycle && RbmBrowserType.Firefox){
            var tagName = curEl.tagName.toUpperCase();
            var style = RbmGetCurrentStyle(curEl);
            if(tagName == "DIV" && style.overflow.toUpperCase() != "visible")
                pos += RbmPxToInt(style.borderTopWidth);
        }
        isFirstCycle = false;
        curEl = curEl.offsetParent;
    }
    return pos;
}
function RbmGetAbsolutePositionY_Safari(curEl){
    var pos = RbmGetAbsoluteOffsetY_OperaFFSafari(curEl);
    while (curEl != null) {
        pos += curEl.offsetTop;
        curEl = curEl.offsetParent;
    }
    return pos;
}
function RbmGetAbsoluteOffsetY_OperaFFSafari(curEl){ // B91523
    var pos = 0;   
    while (curEl != null) {
        var tagname = curEl.tagName.toUpperCase();
        if(tagname == "BODY") break;
        var style = RbmGetCurrentStyle(curEl);
        if(!RbmBrowserType.Safari &&style.position == "absolute") break;
        
        if(tagname == "DIV" && (RbmBrowserType.Safari || style.position == "" || style.position == "static")){
            pos -= curEl.scrollTop;
        }
        curEl = curEl.parentNode;
    }
    return pos; 
}

function RbmGetAbsolutePositionY_Other(curEl){
    var pos = 0;
    var isFirstCycle = true;
    while (curEl != null) {
        pos += curEl.offsetTop;
        if (!isFirstCycle && curEl.offsetParent != null)
            pos -= curEl.scrollTop;
        
        isFirstCycle = false;
        curEl = curEl.offsetParent;
    }
    return pos;
}

/************************************************************************************************************************************/
/************************************************************************************************************************************/