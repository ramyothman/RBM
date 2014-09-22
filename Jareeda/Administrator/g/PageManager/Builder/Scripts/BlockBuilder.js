var PositionType = {
    Middle : 1,
    Left : 2,
    Right : 3,
    None : 4
}
var BlockType = {
    Urgent: 2,
    MainNews : 3,
    ImportantNews : 4,
    ImageNews : 5,
    MultipleCategories : 6,
    News : 7,
    MostRead : 8,
    MostComments : 9,
    TitlePicture : 10,
    Columns : 12,
    Ads1 : 13,
    Ads2 : 14
}
var blockEditCounter = 0;
var allNewsBlocks = new Array();
var allNewsBlockSizeSize = 0;

function AddNewItemByWidget(widget) {
    //alert(container);
    //var itemPosition = container.attr('rel-item');
    allNewsBlocks[allNewsBlockSizeSize] = widget;
    allNewsBlockSizeSize++;
    //alert(allQuestionsSize);
}

function AddNewItem(container, blockType, title, imagePreview, itemPosition)
{
    //alert(container);
    //var itemPosition = container.attr('rel-item');
    allNewsBlocks[allNewsBlockSizeSize] = new NewsBlock(container, blockType, allNewsBlockSizeSize, itemPosition, title, imagePreview);
    allNewsBlocks[allNewsBlockSizeSize].CreateItem();
    allNewsBlockSizeSize++;
    //alert(allQuestionsSize);
}

function NewsBlock(container, blockType, locationCounter, positionType, title, imagePath, parentIndex) {
    blockEditCounter++;
    this.currentCounter = blockEditCounter;
    this.locationCounter = locationCounter;
    this.containerDiv = container;
    this.positionType = positionType;
    this.blockType = blockType;
    this.parentIndex = parentIndex;
    this.blockContainerPositions = new Array();
    //var strQuestionId = -1;
    //if (questionId != null)
    //    strQuestionId = questionId;
    this.imageWidth = 940;
    if(positionType == PositionType.Left)
        this.imageWidth = 220;
    else if(positionType == PositionType.Right)
        this.imageWidth = 700;
    this.idTitle = this.currentCounter + "newsBlockContainer";
    var html = '<div id="' + this.idTitle + '" class="widget-item"><div class="block-header"><div class="controllers"><ul><li><a id="' + this.idTitle + 'EditBtn" href="javascript:void(0);">اعدادات</a></li><li><a id="' + this.idTitle + 'RemoveBtn" href="javascript:void(0);">حذف</a></li></ul></div><h2 id="' + this.idTitle + 'Title">' + title + '</h2><input id="' + this.idTitle + 'TitleEntry" style="display:none;"></input></div><div id="' + this.idTitle + 'Content" class="widget-content"><img width="' + this.imageWidth + '" src="' + imagePath + '" /></div></div>';
    this.containerDiv.append(html);
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
    //var $iframe = $("#contentIFrame").contents();
    //this.blockContainerContent = $('#' + this.idTitle + 'Content', $iframe);
    this.blockHolder = $('#' + this.idTitle);
    this.blockContainerContent = $('#' + this.idTitle + 'Content');
    this.removeButton = $('#' + this.idTitle + 'RemoveBtn');
    this.editButton = $('#' + this.idTitle + 'EditBtn');
    var currentObject = this;
    //alert(this.removeButton);
    this.removeButton.click(function () {
      //  alert('test');
        currentObject.RemoveBlock();
    });
    this.editButton.click(function () {
        //  alert('test');
        OpenWidgetPopup(currentObject.id,currentObject);
        
    });
    
    

}

NewsBlock.prototype = {
    idTitle: '',
    id: 0,
    titleContainer: null,
    titleContainerEntry: null,
    positionID: 0,
    orderNumber: 0,
    itemsNumber: 0,
    itemsPerPage: 0,
    IsFullWidth: false,
    isActive: true,
    languageID: 0,
    oldGroup: false,
    currentCounter: 0,
    locationCounter: 0,
    help: '',
    formTemplate: '',
    title: '',
    changed: false,
    containerDiv: null,
    items: new Array(),
    isDeleted: false,
    blockType: null,
    blockContainerContent: null,
    
    imageWidth: 940,
    removeButton: null,
    editButton: null,
    blockHolder: null,
    CreateItem: function () { },
    RemoveBlock: function () {
        this.isDeleted = true;
        //alert('remove');
        this.blockHolder.remove();
    },
    GetJSON: function () {
        var widgetJSON = new Object();
        widgetJSON.ID = this.id;
        widgetJSON.Name = this.titleContainer.text();
        widgetJSON.IsDeleted = this.isDeleted;
        widgetJSON.OldGroup = this.oldGroup;
        widgetJSON.OrderNumber = this.orderNumber;
        widgetJSON.ContentModuleTypeID = this.blockType;
        widgetJSON.PositionID = this.positionID;
        widgetJSON.IsFullWidth = this.IsFullWidth;
        widgetJSON.ItemsNumber = this.itemsNumber;
        widgetJSON.ItemsPerPage = this.itemsPerPage;
        widgetJSON.IsActive = this.isActive;
        widgetJSON.LanguageID = this.languageID;
        return widgetJSON;
    },
    LoadJSON: function (widgetJSON) {
        this.titleContainer.html(widgetJSON.Name);
        this.id = widgetJSON.ID;
        this.isDeleted = false;
        this.oldGroup = true;
        this.orderNumber = widgetJSON.OrderNumber;
        this.blockType = widgetJSON.ContentModuleTypeID;
        this.positionID = widgetJSON.PositionID;
        this.IsFullWidth = widgetJSON.IsFullWidth;
        this.itemsNumber = widgetJSON.ItemsNumber;
        this.itemsPerPage = widgetJSON.ItemsPerPage;
        this.isActive = widgetJSON.IsActive;
        this.languageID = widgetJSON.LanguageID;
    }

}