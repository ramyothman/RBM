var layoutTestArray = new Array();
var layoutTestCounter = 0;
var dt;
var LayoutType = {
    Layout1: 1,
    Layout2: 2,
    Layout3: 3,
    Layout4: 4
}

var layoutBlocksCounter = 0;
function AddElement(s) {
    var x = s.GetSelectedItem();
    if (x == null) return;
    var id = x.GetColumnText(0);
    var title = x.GetColumnText(1);
    var code = new String(x.GetColumnText(2));
    var className = x.GetColumnText(3);
    var find = '&quot;';
    var re = new RegExp(find, 'g');

    
    var n = code.replace(re, '\"');
   // alert(n);
    //var z = '<div class="block block-type-widget-area grid-width-6"><div class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يسار</span></h3></div><div  class="block block-type-content grid-width-18 align-right"><div  class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يمين</span></h3></div>';
    //alert(z);
    //var $iframe = $("#contentIFrame").contents();
    var dt = new LayoutBlock(id, layoutTestCounter, 0, title, n,className);
    //'<div class="block block-type-widget-area grid-width-6"><div class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يسار</span></h3></div><div  class="block block-type-content grid-width-18 align-right"><div  class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يمين</span></h3></div>'
    //$("#ContainerDiv").append(myString);
    //HideAllQuestionEdit();
    dt.CreateView();
    layoutTestArray[layoutTestCounter] = dt;
    layoutTestCounter++;
}

function SaveLayout()
{
    //alert('saveing');
    var groupsJSON = new Array();
    //alert(layoutTestArray.length);
    for(h = 0;h < layoutTestArray.length; h++)
    {
        //alert(layoutTestArray.length + ';' + i);
        //alert(h);
        var g = layoutTestArray[h].GetJSON();
        //alert(g.Name + ';' + layoutTestArray.length);
        var obj = layoutTestArray[h];
            var orderCheck = 1;
            g.SectionID = cmbSection.GetValue();
            g.PageType = cmbPageType.GetValue();
            g.IsMain = chkIsMain.GetValue();
            $("#grid-container").children("div").each(function () {
                if (this.id == obj.idTitle) {
                    g.OrderNumber = orderCheck;
                }
                orderCheck++;
            });
            //alert(g.Name + ';' + layoutTestArray.length + ';i=' + h);
            groupsJSON.push(g);
    }
    
    var jasonText = JSON.stringify(groupsJSON, function (key, value) {
        return value;
    });
    //alert(jasonText);
    for (i = 0; i < layoutTestArray.length; i++) {
        layoutTestArray[i].oldGroup = true;
    }
    LoadingPanel.Show();
    saveCallBack.PerformCallback(jasonText);
}
function LoadLayout() {
    allNewsBlocks = new Array();
    allNewsBlockSizeSize = 0;
    blockEditCounter = 0;
    var jsonString = hiddenJSONLoad.Get('JSONLayout');
    if (jsonString == "")
    {
        layoutTestArray = new Array();
        layoutTestCounter = 0;
        $('#grid-container').html('');
        
        layoutBlocksCounter = 0;
        return;
    }
    var groupObjects = JSON.parse(jsonString, function (key, value) {
        return value;
    });
    //alert(jsonString);
    
    layoutTestArray = new Array();
    layoutTestCounter = 0;
    $('#grid-container').html('');
    layoutBlocksCounter = 0;
    if(groupObjects != null)
    {
        
        
        var i = 0;
        var isMainSet = false;
        for(i = 0; i < groupObjects.length; i++){
            var x = cmbPosition.FindItemByValue(groupObjects[i].LayoutID);
            //alert(x + '-' + groupObjects[i].LayoutID);
            if (!isMainSet)
            {
                chkIsMain.SetValue(groupObjects[i].IsMain);
                isMainSet = true;
            }
            if (x == null) return;
            var id = x.GetColumnText(0);
            var title = groupObjects[i].Name;
            var code = new String(x.GetColumnText(2));
            var className = x.GetColumnText(3);
            var find = '&quot;';
            var re = new RegExp(find, 'g');
            
    
            var n = code.replace(re, '\"');
            // alert(n);
            //var z = '<div class="block block-type-widget-area grid-width-6"><div class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يسار</span></h3></div><div  class="block block-type-content grid-width-18 align-right"><div  class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يمين</span></h3></div>';
            //alert(z);
            //var $iframe = $("#contentIFrame").contents();
            var dt = new LayoutBlock(id, layoutTestCounter, groupObjects[i].ID, title, n,className);
            
            //'<div class="block block-type-widget-area grid-width-6"><div class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يسار</span></h3></div><div  class="block block-type-content grid-width-18 align-right"><div  class="block-content-fade block-content block-drop" style="min-height: 320px;"></div><h3 class="block-type"><span >يمين</span></h3></div>'
            //$("#ContainerDiv").append(myString);
            //HideAllQuestionEdit();
            dt.CreateView();
            dt.LoadJSON(groupObjects[i]);
            layoutTestArray[layoutTestCounter] = dt;
            layoutTestCounter++;
            //alert(groupObjects[i].Widgets.length);
            //if(groupObjects[i].Widgets.length > 0)
            //    alert(groupObjects[i].Widgets[0].ContentModuleTypeID);
            //dt.LoadWidgetJSON(groupObjects[i].Widgets);
            //var mainObject = this;
            
            for (j = 0; j < groupObjects[i].Widgets.length; j++) {
                //alert(groupObjects[i].Widgets.length + ',' + groupObjects[i].Widgets[i].Name);
                
                var container = dt.GetContainerByPositionID(groupObjects[i].Widgets[j].PositionID);
                if (container != null) {
                    var widget = new NewsBlock($(container), groupObjects[i].Widgets[j].ContentModuleTypeID, allNewsBlockSizeSize, groupObjects[i].Widgets[j].PositionID, groupObjects[i].Widgets[j].Name, groupObjects[i].Widgets[j].ImagePath);
                    widget.CreateItem();
                    widget.LoadJSON(groupObjects[i].Widgets[j]);
                    AddNewItemByWidget(widget);
                }
            }
        }
    }
}
function AddElement2() {

    //var $iframe = $("#contentIFrame").contents();
    var dt = new LayoutBlock('option1', layoutTestCounter, 0, 'نموذج', '');
    //$("#ContainerDiv").append(myString);
    //HideAllQuestionEdit();
    dt.CreateView();
    
    layoutTestArray[layoutTestCounter] = dt;
    layoutTestCounter++;
}


function NewsBlockItem(index,item)
{
    this.index = index;
    this.item = item;
}


NewsBlockItem.prototype = {
    index: -1,
    item: null
}

function LayoutBlock(layoutType, locationCounter, layoutBlockId,title,templateLayout,className) {
    layoutBlocksCounter++;
    this.currentCounter = layoutBlocksCounter;
    this.locationCounter = locationCounter;
    this.templateLayout = templateLayout;
    this.className = className;
    this.layoutContainerContent = new Array();
    this.layoutContainerPositions = new Array();
    this.containerCount = 0;
    this.title = title;
    //var $iframe = $("#contentIFrame").contents();
    
    //this.containerDiv = $('#grid-container', $iframe);
    this.containerDiv = $('#grid-container');
    
    this.layoutType = layoutType;
    
    var strQuestionId = -1;
    if (layoutBlockId != null)
        strQuestionId = layoutBlockId;
    this.currentLayoutId = strQuestionId;
    
    this.idTitle = this.currentCounter + "mainLayoutBlockContainer";
    var html = '<div id="' + this.currentCounter + 'mainLayoutBlockContainer" class="block block-type-navigation grid-width-24"  rel="' + strQuestionId + '"><div class="block-header"><div class="controllers"><ul><li><a id="' + this.idTitle + 'RemoveBtn" href="javascript:void(0);">حذف</a></li></ul></div><h2 id="' + this.idTitle + 'Title">' + title + '</h2><input id="' + this.idTitle + 'TitleEntry" style="display:none;"></input></div><div id="' + this.currentCounter + 'mainLayoutBlockContainerMain" rel="' + this.layoutType + '" class="block-content-fade block-content block-drop" style="min-height: 80px;">' + this.templateLayout + '</div></div>';
    //alert(html);
    this.containerDiv.append(html);
    this.removeButton = $('#' + this.idTitle + 'RemoveBtn');
    
    var mainCursor = this;
    this.titleContainer = $('#' + this.idTitle + 'Title');
    this.titleContainerEntry = $('#' + this.idTitle + 'TitleEntry');
    this.titleContainer.click(function () {
        //alert('test');
        mainCursor.titleContainer.css('display', 'none');
        mainCursor.titleContainerEntry
            .val(mainCursor.titleContainer.text())
            .css('display', '')
            .focus();
    });

    this.titleContainerEntry.blur(function () {
        mainCursor.titleContainerEntry.css('display', 'none');
        mainCursor.titleContainer
            .text(mainCursor.titleContainerEntry.val())
            .css('display', '');
    });
    this.currentQuestionId = strQuestionId;
    //this.layoutContainer = $('#' + this.currentCounter + 'mainLayoutBlockContainer', $iframe);
    this.layoutContainer = $('#' + this.currentCounter + 'mainLayoutBlockContainer');
    //this.layoutContainerContent[this.containerCount] = $('#' + this.currentCounter + 'mainLayoutBlockContainerMain', $iframe);
    this.layoutContainerContent[this.containerCount] = $('#' + this.currentCounter + 'mainLayoutBlockContainerMain');
    this.layoutContainerPositions[this.containerCount] = 0;
    this.containerCount++;
    //alert('layoutcontainer finale length: ' + this.layoutContainerContent.length + ' count:' + this.containerCount);
    //alert('layout:' + templateLayout);
    this.removeButton.click(function () {
        //  alert('test');
        mainCursor.RemoveLayout();
    });
    //alert(this.layoutContainerContent[0].children('div').length);
    var items = this.layoutContainerContent[0].children('div');
    for (var i = 0; i < items.length; i++)
    {
        var items2 = $(items[i]).children('div');
        //alert('length: ' + items2.length + ' - count:' + this.containerCount + ' - ' + $(items[i]).attr('class'));
        
        for(var j = 0; j < items2.length;j++)
        {
            
            this.hasChilds = true;
            
            this.layoutContainerContent[this.containerCount] = $(items2[j]);
            this.layoutContainerPositions[this.containerCount] = this.layoutContainerContent[this.containerCount].attr('rel');
            //alert('container sub id: ' + this.layoutContainerContent[this.containerCount].attr('class'));
            this.layoutContainerContent[this.containerCount].sortable({
                placeholder: "ui-state-highlight"
            });

            this.layoutContainerContent[this.containerCount].disableSelection();

            //mainCursor.layoutContainerContent[mainCursor.containerCount].disableSelection();
            this.layoutContainerContent[this.containerCount].droppable({

                accept: ".module-s-box",
                drop: function (event, ui) {
                    //alert($(this).attr('id'));
                    var rel = new String($(ui.draggable).attr('rel'));
                    var split = rel.split(';');
                    //id,name,image
                    AddNewItem($(this), split[0], split[1], split[2], split[3]);
                    //alert(ui.position.clientX + ' - ' + ui.position.clientY + ' - ' + ui.position.left + ' - ' + ui.position.top);
                    //var item = $(RbmElementFromPoint(ui.position.left, ui.position.top, document.getElementById("contentIFrame").contentDocument, document.getElementById("contentIFrame").contentWindow));
                    //alert($(item).attr('class'));
                    //AddItem($(this));
                    //document.getElementById("contentIFrame").contentWindow.
                }
            });

            this.containerCount++;
            
            //alert(this.containerCount);
        }
        

    }
    

    if(this.containerCount == 1)
    {

        this.layoutContainerContent[0].sortable({
            placeholder: "ui-state-highlight"
        });
        //alert('test');
        this.layoutContainerContent[0].disableSelection();
        this.layoutContainerContent[0].droppable({

            accept: ".module-s-box",
            drop: function (event, ui) {
                //alert($(this).attr('id'));
                var rel = new String($(ui.draggable).attr('rel'));
                if (rel != null)
                {
                    var split = rel.split(';');
                    //id,name,image
                    AddNewItem($(this), split[0], split[1], split[2], split[3]);
                }
                //alert(ui.position.clientX + ' - ' + ui.position.clientY + ' - ' + ui.position.left + ' - ' + ui.position.top);
                //var item = $(RbmElementFromPoint(ui.position.left, ui.position.top, document.getElementById("contentIFrame").contentDocument, document.getElementById("contentIFrame").contentWindow));
                //alert($(item).attr('class'));
                
                //document.getElementById("contentIFrame").contentWindow.
            }
        });
        
    }
    //alert(this.layoutContainerContent.length);
    //alert('layoutcontainer finale length: ' + this.layoutContainerContent.length + ' - ' + this.containerCount);
 
}

LayoutBlock.prototype = {
    containerCount: 0,
    currentLayoutId: -1,
    className: '',
    idTitle: '',
    currentCounter: 0,
    locationCounter: 0,
    hasChilds: false,
    help: '',
    formTemplate: '',
    title: '',
    titleContainerEntry: null,
    titleContainer: null,
    newsBlocksArray: new Array(),
    changed: false,
    containerDiv: null,
    oldGroup: false,
    items: new Array(),
    isDeleted: false,
    blockType: null,
    layoutContainerContent: new Array(),
    layoutContainerPositions: new Array(),
    layoutContainer: null,
    templateLayout: '',
    AddItem: function () { },
    RemoveLayout: function () {
        this.isDeleted = true;
        this.layoutContainer.remove();
    },
    CreateView: function () {
        var asterisk = '';
        
        

        /*
        <div class="block block-type-widget-area grid-width-6"style="min-height: 320px;">
				<div class="block-content-fade block-content">
					
				</div>
				
				<h3 class="block-type"><span ></span></h3>
			</div>
                    <div  class="block block-type-content grid-width-18 align-right"style="min-height: 320px; ">
				<div  class="block-content-fade block-content">
					
				</div>
                        <h3 class="block-type"><span ></span></h3>
				
				
			</div>
        */
    },
    GetJSON: function () {
        var groupJSON = new Object();
        //alert(this.idTitle);
        groupJSON.ID = this.currentLayoutId;
        groupJSON.Name = this.titleContainer.text();
        groupJSON.GroupClass = this.className;
        groupJSON.OrderNumber = 0;
        groupJSON.LayoutID = this.layoutType;
        groupJSON.OldGroup = this.oldGroup;
        groupJSON.IsDeleted = this.isDeleted;
        groupJSON.Widgets = this.GetWidgetsJSON();
        return groupJSON;
        //TODO: Widgets
    },
    GetWidgetsJSON: function(){
        var widgets = new Array();
        var mainObject = this;
        if (this.hasChilds) {
            for (i = 1; i < this.layoutContainerContent.length; i++) {
                var orderCheck = 0;
                /*
                $("#grid-container").children("div").each(function () {
                if (this.id == obj.idTitle) {
                    g.OrderNumber = orderCheck;
                }
                orderCheck++;
            });
                */
                //if (this.layoutContainerContent[i] == null) continue;
                
                this.layoutContainerContent[i].children("div").each(function () {
                    orderCheck++;
                    for (j = 0; j < allNewsBlocks.length; j++) {
                        //alert('ids: ' + $(this).attr('id') + ',' + $(this).attr('class') + '-' + allNewsBlocks[j].idTitle);
                        if (allNewsBlocks[j] == null) continue;
                        if (this.id == allNewsBlocks[j].idTitle) {
                            allNewsBlocks[j].orderNumber = orderCheck;
                            
                            var block = allNewsBlocks[j].GetJSON();
                            //alert(block.OrderNumber + ',' + block.OldGroup);
                            
                            allNewsBlocks[j].oldGroup = true;
                            //alert(mainObject.layoutContainerPositions[i]);
                            block.PositionID = mainObject.layoutContainerPositions[i];
                            
                            widgets.push(block);
                        }
                    }
                    

                });
            }
        }
        else {
            var orderCheck = 1;

            //if (this.layoutContainerContent[i] == null) continue;
            this.layoutContainerContent[0].children("div").each(function () {

                for (j = 0; j < allNewsBlocks.length; j++) {
                    //alert('ids: ' + $(this).attr('id') + ',' + $(this).attr('class') + '-' + allNewsBlocks[j].idTitle);
                    if (allNewsBlocks[j] == null) continue;
                    if (this.id == allNewsBlocks[j].idTitle) {
                        allNewsBlocks[j].orderNumber = orderCheck;
                        
                        widgets.push(allNewsBlocks[j].GetJSON());
                        allNewsBlocks[j].oldGroup = true;
                    }

                }
                orderCheck++;

            });
        }
        
        //alert(widgets.length);
        return widgets;
    },
    LoadJSON: function (groupObject) {
        this.titleContainer.html(groupObject.Name);
        this.currentLayoutId = groupObject.ID;
        this.className = groupObject.GroupClass;
        this.layoutType = groupObject.LayoutID;
        this.oldGroup = groupObject.OldGroup;
        this.isDeleted = groupObject.isDeleted;
        
    },
    LoadWidgetJSON: function(widgets){
        
        
        
        
    },
    GetContainerByPositionID: function(positionId){
        var container = null;
        for(i = 0;i < this.layoutContainerPositions.length;i++){
            if(positionId == this.layoutContainerPositions[i])
                container = this.layoutContainerContent[i];
        }
        return container;
    },
    AddWidget: function (id,item) {
        var widget = new NewsBlockItem(id, item);
        
    }

};