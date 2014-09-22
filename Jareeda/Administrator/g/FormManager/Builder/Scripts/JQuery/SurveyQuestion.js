var currentQuestionInEdit = null;
var QuestionType = {
    Text: 'Text',
    ParagraphText: 'Paragraph',
    Radios: 'MultipleChoice',
    CheckBoxes: 'CheckBoxes',
    DropDown: 'DropDown',
    Grid: 'Grid',
    Scale: 'Scale'
};
var questionEditCounter = 0;
function SurveyQuestion(questionType, locationCounter, questionId) {
    
    questionEditCounter++;
    this.currentCounter = questionEditCounter;
    this.locationCounter = locationCounter;
    this.containerDiv = $('#ContainerDiv');
    
    this.questionType = questionType;
    var strQuestionId = -1;
    if (questionId != null)
        strQuestionId = questionId;
    this.idTitle = this.currentCounter + "mainQuestionContainer";
    this.containerDiv.append('<div id="' + this.currentCounter + 'mainQuestionContainer" class="mainQuestionContainer draggable" rel="' + strQuestionId + '"></div>');
    this.currentQuestionId = strQuestionId;
    this.questionContainer = $('#' + this.currentCounter + 'mainQuestionContainer');

}
SurveyQuestion.prototype = {
    idTitle: '',
    currentQuestionId: -1,
    formTemplate: '',
    title: 'Title Here',
    changed: false,
    help: '',
    locationCounter: 0,
    gridColumnCounter: 5,
    gridColumn1Edit: null,
    gridColumn2Edit: null,
    gridColumn3Edit: null,
    gridColumn4Edit: null,
    gridColumn5Edit: null,
    containerDiv: null,
    currentView: 'edit',
    items: new Array(),
    required: false,
    isSection: false,
    isEmail: false,
    isMobile: false,
    regExp: '',
    resultCounter: 0,
    resultCheckCounter: 0,
    currentCounter: 0,
    isDeleted: false,
    questionTitle: null,
    clickOtherChoice: null,
    clickOtherCheck: null,
    questionHelp: null,
    questionType: null,
    questionTypeContainer: null,
    questionDisplayEdit: null,
    questionContainer: null,
    questionEditContainer: null,
    questionViewContainer: null,
    questionRequired: null,
    questionIsSection: null,
    questionIsEmail: null,
    questionIsMobile: null,
    questionRegularExpression: null,
    questionEditController: null,
    questionRemoveButton: null,
    questionEditButton: null,
    sumbitButton: null,
    AddItem: function () {

    },
    /************************************ Start JSON Conversions ******************************************/
    GetQuestionJSON: function (languageCode) {
        var questionJSON = new Object();
        questionJSON.Id = this.currentQuestionId;
        questionJSON.QuestionOrder = this.currentCounter;
       if( this.questionRequired.attr("checked") == "checked")
           questionJSON.IsRequired = true;
        else
           questionJSON.IsRequired = false;
       if(this.questionIsSection != null)
       if (this.questionIsSection.attr("checked") == "checked")
           questionJSON.IsSection = true;
       else
           questionJSON.IsSection = false;
       
       if (this.questionIsEmail != null)
       if (this.questionIsEmail.attr("checked") == "checked")
           questionJSON.IsContactEmail = true;
       else
           questionJSON.IsContactEmail = false;

       if (this.questionIsMobile != null)
       if (this.questionIsMobile.attr("checked") == "checked")
           questionJSON.IsContactMobile = true;
       else
           questionJSON.IsContactMobile = false;

        //alert(this.questionRequired.attr("checked"));
        //alert(this.questionRequired.attr("value"));
        //if (RbmStringContains(this.questionRequired.attr("checked"), 'true'))
        //    questionJSON.IsRequired = true;
        //else
        //    questionJSON.IsRequired = false;

        if (this.questionTitle.attr("value") != "")
            questionJSON.Title = this.questionTitle.attr("value");

        if (this.questionHelp.attr("value") != "")
            questionJSON.Help = this.questionHelp.attr("value");
        var Answeres = new Array();
        switch (this.questionType) {
            case 'Text':
                questionJSON.HasOther = false;
                questionJSON.QuestionType = 3;

                break;
            case 'Paragraph':
                questionJSON.HasOther = false;
                questionJSON.QuestionType = 4;
                break;
            case 'MultipleChoice':
                questionJSON.QuestionType = 1;
                var choiceDiv = $('#' + this.currentCounter + 'displayEditChoice_div ul li');
                var currentObject = this;
                var counter = 0;
                //                var Answeres = new Array();
                choiceDiv.each(function (indexUL, domEleUL) {
                    var questionAnswer = new Object();
                    var relAttribute = RbmGetAttribute(domEleUL, "rel");
                    if (relAttribute == "other") {
                        questionJSON.HasOther = true;
                        questionAnswer.IsOther = true;
                    }
                    questionAnswer.Id = $(RbmGetChildByTagName(domEleUL, 'input', 1)).attr('rbmid');
                    questionAnswer.AnswerText = RbmGetChildByTagName(domEleUL, 'input', 1).value
                    Answeres.push(questionAnswer);
                });
                break;
            case 'CheckBoxes':
                questionJSON.QuestionType = 2;
                var choiceDiv = $('#' + this.currentCounter + 'displayEditCheck_div ul li');
                var currentObject = this;
                var counter = 0;
                //                var Answeres = new Array();
                choiceDiv.each(function (indexUL, domEleUL) {
                    var questionAnswer = new Object();
                    var relAttribute = RbmGetAttribute(domEleUL, "rel");
                    if (relAttribute == "other") {
                        questionJSON.HasOther = true;
                        questionAnswer.IsOther = true;
                    }
                    questionAnswer.Id = $(RbmGetChildByTagName(domEleUL, 'input', 1)).attr('rbmid');

                    questionAnswer.AnswerText = RbmGetChildByTagName(domEleUL, 'input', 1).value
                    Answeres.push(questionAnswer);
                });
                break;
            case 'DropDown':
                questionJSON.QuestionType = 5;
                var choiceDiv = $('#' + this.currentCounter + 'displayEditDropDown_div ul li');
                var currentObject = this;
                var counter = 0;
                //                var Answeres = new Array();
                choiceDiv.each(function (indexUL, domEleUL) {
                    var questionAnswer = new Object();
                    var relAttribute = RbmGetAttribute(domEleUL, "rel");
                    if (relAttribute == "other") {
                        questionJSON.HasOther = true;
                        questionAnswer.IsOther = true;
                    }
                    questionAnswer.Id = $(RbmGetChildByTagName(domEleUL, 'input', 1)).attr('rbmid');
                    questionAnswer.AnswerText = RbmGetChildByTagName(domEleUL, 'input', 1).value
                    Answeres.push(questionAnswer);
                });
                break;
            case 'Grid':
                questionJSON.ColumnCount = this.gridColumnCounter;
                //alert(this.gridColumnCounter);
                questionJSON.Column1 = $('#RbmGridColumn1' + this.currentCounter).val();
                questionJSON.Column2 = $('#RbmGridColumn2' + this.currentCounter).val();
                questionJSON.Column3 = $('#RbmGridColumn3' + this.currentCounter).val();
                questionJSON.Column4 = $('#RbmGridColumn4' + this.currentCounter).val();
                questionJSON.Column5 = $('#RbmGridColumn5' + this.currentCounter).val();
                questionJSON.QuestionType = 6;
                var choiceDiv = $('#' + this.currentCounter + 'displayEditGrid_div ul li');
                var currentObject = this;
                var counter = 0;
                //                var Answeres = new Array();
                choiceDiv.each(function (indexUL, domEleUL) {
                    var questionAnswer = new Object();
                    var relAttribute = RbmGetAttribute(domEleUL, "rel");
                    if (relAttribute == "other") {
                        questionJSON.HasOther = true;
                        questionAnswer.IsOther = true;
                    }
                    questionAnswer.Id = $(RbmGetChildByTagName(domEleUL, 'input', 0)).attr('rbmid');
                    questionAnswer.AnswerText = RbmGetChildByTagName(domEleUL, 'input', 0).value
                    Answeres.push(questionAnswer);
                });
                break;
        }
        questionJSON.Answeres = Answeres;
        return questionJSON;
    },
    SetQuestionJsonToDiv: function (questionObject) {

        this.CreateEdit('none');

        this.questionRequired.attr("checked", questionObject.IsRequired);
        this.questionTitle.attr("value", questionObject.Title);
        this.questionHelp.attr("value", questionObject.Help);
        if (this.questionIsSection != null)
            this.questionIsSection.attr("checked", questionObject.IsSection);

        if (this.questionIsEmail != null)
            this.questionIsEmail.attr("checked", questionObject.IsContactEmail);

        if (this.questionIsMobile != null)
            this.questionIsMobile.attr("checked", questionObject.IsContactMobile);


        var questionTypeStr = 'Text';
        switch (questionObject.QuestionType) {
            case 1:
                questionTypeStr = 'MultipleChoice';
                break;
            case 2:
                questionTypeStr = 'CheckBoxes';
                break;
            case 3:
                questionTypeStr = 'Text';
                break;
            case 4:
                questionTypeStr = 'Paragraph';
                break;
            case 5:
                questionTypeStr = 'DropDown';
                break;
            case 6:
                questionTypeStr = 'Grid';
                break;

        }

        this.SwitchQuestionType(questionTypeStr);
        switch (questionObject.QuestionType) {
            case 1:
                for (i = 0; i < questionObject.Answeres.length; i++) {

                    if (questionObject.Answeres[i].IsOther == false)
                        this.AddChoiceResultItem($('#RbmAddChoiceItem' + this.locationCounter), questionObject.Answeres[i].AnswerText, questionObject.Answeres[i].Id);
                    else
                        this.AddChoiceOtherItem($('#RbmAddChoiceOtherItem' + this.locationCounter), questionObject.Answeres[i].Id);
                }
                //                if (questionObject.HasOther == true) {
                //                    this.AddChoiceOtherItem($('#RbmAddChoiceItem' + this.locationCounter), questionObject.Answeres[i].Id);
                //                }
                break;
            case 2:
                for (i = 0; i < questionObject.Answeres.length; i++) {
                    if (questionObject.Answeres[i].IsOther == false)
                        this.AddCheckResultItem($('#RbmAddCheckboxItem' + this.locationCounter), questionObject.Answeres[i].AnswerText, questionObject.Answeres[i].Id);
                    else
                        this.AddCheckboxOtherItem($('#RbmAddCheckboxOtherItem' + this.locationCounter), questionObject.Answeres[i].Id);
                }
                //                if (questionObject.HasOther == true) {
                //                    this.AddCheckboxOtherItem($('#RbmAddCheckboxItem' + this.locationCounter), questionObject.Answeres[i].Id);
                //                }
                break;
            case 5:
                for (i = 0; i < questionObject.Answeres.length; i++) {

                    if (questionObject.Answeres[i].IsOther == false)
                        this.AddDropDownResultItem($('#RbmAddDropDownItem' + this.locationCounter), questionObject.Answeres[i].AnswerText, questionObject.Answeres[i].Id);
                }
                break;
            case 6:
                //                if (this.comboBoxColumnCounter == null) this.comboBoxColumnCounter = $('#RBMGridColumnCount' + this.currentCounter);
                //                this.comboBoxColumnCounter.val(questionObject.ColumnCount).attr('selected', true);
                //                alert(this.comboBoxColumnCounter.val());

                //this.UpdateGridColumnCount(this.comboBoxColumnCounter);
                var countCombo = document.getElementById('RBMGridColumnCount' + this.currentCounter);
                countCombo.selectedIndex = questionObject.ColumnCount - 1;
                this.gridColumnCounter = questionObject.ColumnCount;
                $('#RbmGridColumn1' + this.currentCounter).val(questionObject.Column1);
                $('#RbmGridColumn2' + this.currentCounter).val(questionObject.Column2);
                $('#RbmGridColumn3' + this.currentCounter).val(questionObject.Column3);
                $('#RbmGridColumn4' + this.currentCounter).val(questionObject.Column4);
                $('#RbmGridColumn5' + this.currentCounter).val(questionObject.Column5);
                for (i = 0; i < questionObject.Answeres.length; i++) {

                    if (questionObject.Answeres[i].IsOther == false)
                        this.AddGridResultItem($('#RbmAddGridItem' + this.locationCounter), questionObject.Answeres[i].AnswerText, questionObject.Answeres[i].Id);
                }
                break;
        }
        this.HideEdit();

    },
    /************************************ End JSON Conversions ******************************************/
    ChangeType: function (questionType) {
    },
    RemoveEdit: function () {
        this.isDeleted = true;
        this.questionContainer = $('#' + this.currentCounter + 'mainQuestionContainer');
        this.questionContainer.remove();
    },
    HideEdit: function () {
        if (this.currentView == 'view') {

            if (currentQuestionInEdit != this && currentQuestionInEdit != null) {
                currentQuestionInEdit.HideEdit();

            }
            currentQuestionInEdit = this;
            this.ShowEdit();
            this.currentView = 'edit';
        }
        else {
            if (currentQuestionInEdit == this) {
                currentQuestionInEdit = null;
            }
            this.questionEditContainer.hide();
            this.questionEditController.hide();
            this.CreateView();
            this.currentView = 'view';
        }
    },
    SwitchQuestionType: function (value) {
        this.questionTypeContainer.val(value).attr('selected', true);
        switch (this.questionType) {
            case 'Text':
                $('#' + this.currentCounter + 'displayEditText_div').hide();
                break;
            case 'Paragraph':
                $('#' + this.currentCounter + 'displayEditParagraph_div').hide();
                break;
            case 'MultipleChoice':
                $('#' + this.currentCounter + 'displayEditChoice_div').hide();
                break;
            case 'CheckBoxes':
                $('#' + this.currentCounter + 'displayEditCheck_div').hide();
                break;
            case 'DropDown':
                $('#' + this.currentCounter + 'displayEditDropDown_div').hide();
                break;
            case 'Grid':
                $('#' + this.currentCounter + 'displayEditGrid_div').hide();
                break;

            /*
            DropDown: 'DropDown',
            Grid: 'Grid',
            */ 
        }
        this.questionType = value;
        switch (value) {
            case 'Text':
                if (RbmGetElementById(this.currentCounter + 'displayEditText_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditText_div').show();
                }
                if ($('#RBMGridColumnTable' + this.currentCounter) != null)
                    $('#RBMGridColumnTable' + this.currentCounter).hide();
                break;
            case 'Paragraph':
                if (RbmGetElementById(this.currentCounter + 'displayEditParagraph_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditParagraph_div').show();
                }
                if ($('#RBMGridColumnTable' + this.currentCounter) != null)
                    $('#RBMGridColumnTable' + this.currentCounter).hide();
                break;
            case 'MultipleChoice':
                if (RbmGetElementById(this.currentCounter + 'displayEditChoice_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditChoice_div').show();
                }
                if ($('#RBMGridColumnTable' + this.currentCounter) != null)
                    $('#RBMGridColumnTable' + this.currentCounter).hide();
                break;
            case 'CheckBoxes':
                if (RbmGetElementById(this.currentCounter + 'displayEditCheck_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditCheck_div').show();
                }
                if ($('#RBMGridColumnTable' + this.currentCounter) != null)
                    $('#RBMGridColumnTable' + this.currentCounter).hide();
                break;
            case 'DropDown':
                if (RbmGetElementById(this.currentCounter + 'displayEditDropDown_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditDropDown_div').show();
                }
                if ($('#RBMGridColumnTable' + this.currentCounter) != null)
                    $('#RBMGridColumnTable' + this.currentCounter).hide();
                break;
            case 'Grid':
                if (RbmGetElementById(this.currentCounter + 'displayEditGrid_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditGrid_div').show();
                }
                //alert($('#DivColumnsView' + this.currentCounter).children().size());
                if ($('#DivColumnsView' + this.currentCounter).children().size() == 0) {
                    $('#DivColumnsView' + this.currentCounter).append(this.GetGridSpecialRows());

                }
                else
                    $('#RBMGridColumnTable' + this.currentCounter).show();
                break;
        }
    },

    GetResults: function () {
        switch (this.questionType) {
            case 'Text':
                return this.GetResultsText();
                break;
            case 'Paragraph':
                return this.GetResultsParagraph();
                break;
            case 'MultipleChoice':
                return this.GetResultsChoice();
                break;
            case 'CheckBoxes':
                return this.GetResultsChecks();
                break;
            case 'DropDown':
                return this.GetResultsDropDown();
                break;
            case 'Grid':
                //this.UpdateGridColumnCountByCount(this.gridColumnCounter);
                return this.GetResultsGrid();
                break;
        }
    },
    RemoveResult: function (element) {
        this.resultCounter--;
        $(element).parent().remove();
        if (this.questionType == "MultipleChoice")
            this.RenameChoices();
        else if (this.questionType == "DropDown")
            this.RenameDropDown();
        else if (this.questionType == "Grid")
            this.RenameGrid();
    },
    RemoveOther: function (element) {
        $(element).parent().remove();
        $(this.clickOtherChoice).show();
    },

    RemoveCheckResult: function (element) {
        this.resultCheckCounter--;
        $(element).parent().remove();
        this.RenameChecks();
    },
    RemoveCheckOther: function (element) {
        $(element).parent().remove();
        $(this.clickOtherCheck).show();
    },
    AddGridResultItem: function (afterElement, itemValue, itemId) {
        this.resultCounter++;
        afterElement = $(afterElement).parent();
        if (itemValue == null)
            itemValue = 'Option' + this.resultCounter;
        if (itemId == null)
            itemId = -1;
        var x = '<li>'
                + '<label style="font-weight:bold;margin-right:10px;">Row ' + this.resultCounter + ' Label</label>'
                + '<input rbmid="' + itemId + '" value="' + itemValue + '" class="label-input-label" style="color:#666666;" type="text" onfocus="TextChanged(this,\'Option\' + $(this).attr(\'rel\'))" onblur="TextLeave(this,\'Option\' + $(this).attr(\'rel\'))" rel="' + this.resultCounter + '" />'
                + '<span class="ss-x-box ImageContainer inline-block" style="" onclick="questionsTestArray[' + this.locationCounter + '].RemoveResult(this)" >  </span>'
                + '</li>';
        $(afterElement).before(x);
    },
    AddDropDownResultItem: function (afterElement, itemValue, itemId) {
        this.resultCounter++;
        afterElement = $(afterElement).parent();
        if (itemValue == null)
            itemValue = 'Option' + this.resultCounter;
        if (itemId == null)
            itemId = -1;
        var x = '<li>'
                + '<input type="radio"/> '
                + '<input rbmid="' + itemId + '" value="' + itemValue + '" class="label-input-label" style="color:#666666;" type="text" onfocus="TextChanged(this,\'Option\' + $(this).attr(\'rel\'))" onblur="TextLeave(this,\'Option\' + $(this).attr(\'rel\'))" rel="' + this.resultCounter + '" />'
                + '<span class="ss-x-box ImageContainer inline-block" style="" onclick="questionsTestArray[' + this.locationCounter + '].RemoveResult(this)" >  </span>'
                + '</li>';
        $(afterElement).before(x);
    },
    AddChoiceResultItem: function (afterElement, itemValue, itemId) {
        this.resultCounter++;
        afterElement = $(afterElement).parent();
        if (itemValue == null)
            itemValue = 'Option' + this.resultCounter;
        if (itemId == null)
            itemId = -1;
        var x = '<li>'
                + '<input type="radio"/> '
                + '<input rbmid="' + itemId + '" value="' + itemValue + '" class="label-input-label" style="color:#666666;" type="text" onfocus="TextChanged(this,\'Option\' + $(this).attr(\'rel\'))" onblur="TextLeave(this,\'Option\' + $(this).attr(\'rel\'))" rel="' + this.resultCounter + '" />'
                + '<span class="ss-x-box ImageContainer inline-block" style="" onclick="questionsTestArray[' + this.locationCounter + '].RemoveResult(this)" >  </span>'
                + '</li>';
        $(afterElement).before(x);
    },
    AddCheckResultItem: function (afterElement, itemValue, itemId) {
        this.resultCheckCounter++;
        afterElement = $(afterElement).parent();
        if (itemValue == null)
            itemValue = 'Option' + this.resultCheckCounter;
        if (itemId == null)
            itemId = -1;
        var x = '<li>'
        + '<input type="checkbox"/> '
        + '<input rbmid="' + itemId + '"  value="' + itemValue + '" class="label-input-label" style="color:#666666;" type="text" onfocus="TextChanged(this,\'Option\' + $(this).attr(\'rel\'))" onblur="TextLeave(this,\'Option\' + $(this).attr(\'rel\'))" rel="' + this.resultCheckCounter + '"/>'
        + '<span class="ss-x-box ImageContainer inline-block" style="" onclick="questionsTestArray[' + this.locationCounter + '].RemoveCheckResult(this)" >  </span>'
        + '</li>';
        $(afterElement).before(x);
    },
    AddChoiceOtherItem: function (clickItem, itemId) {
        this.resultCheckCounter++;
        this.clickOtherChoice = clickItem;
        var afterElement = $(clickItem).parent();
        if (itemId == null)
            itemId = -1;
        var x = '<li rel="other">'
                  + '<input type="radio" name="item_group:g" style="opacity: 1;" />'
                  + '<span>Other:'
                  + '<input rbmid="' + itemId + '" class="ss-formwidget-disabledpreview" type="text" disabled="" />'
                  + '</span>'
                  + '<input class="label-input-label" type="text" style="opacity: 1; display: none;" />'
                  + '<span class="ss-x-box ImageContainer  inline-block" onclick="questionsTestArray[' + this.locationCounter + '].RemoveOther(this)"></span>'
                  + '</li>';
        $(afterElement).after(x);
        $(this.clickOtherChoice).hide();
    },
    AddCheckboxOtherItem: function (clickItem, itemId) {

        this.resultCounter++;
        this.clickOtherCheck = clickItem;
        var afterElement = $(clickItem).parent();
        if (itemId == null)
            itemId = -1;
        var x = '<li rel="other">'
                  + '<input type="checkbox" name="item_group:g" style="opacity: 1;" />'
                  + '<span>Other:'
                  + '<input rbmid="' + itemId + '" class="ss-formwidget-disabledpreview" type="text" disabled="" />'
                  + '</span>'
                  + '<input class="label-input-label" type="text" style="opacity: 1; display: none;" />'
                  + '<span class="ss-x-box ImageContainer  inline-block" onclick="questionsTestArray[' + this.locationCounter + '].RemoveCheckOther(this)"></span>'
                  + '</li>';
        $(afterElement).after(x);
        $(this.clickOtherCheck).hide();
    },
    UpdateGridColumnCountByCount: function (colCount) {
        this.gridColumnCounter = colCount;
        switch (colCount) {
            case '5':
                $('#RBMColumn1Row' + this.currentCounter).show();
                $('#RBMColumn2Row' + this.currentCounter).show();
                $('#RBMColumn3Row' + this.currentCounter).show();
                $('#RBMColumn4Row' + this.currentCounter).show();
                $('#RBMColumn5Row' + this.currentCounter).show();
                break;
            case '4':
                $('#RBMColumn1Row' + this.currentCounter).show();
                $('#RBMColumn2Row' + this.currentCounter).show();
                $('#RBMColumn3Row' + this.currentCounter).show();
                $('#RBMColumn4Row' + this.currentCounter).show();
                $('#RBMColumn5Row' + this.currentCounter).hide();
                break;
            case '3':
                $('#RBMColumn1Row' + this.currentCounter).show();
                $('#RBMColumn2Row' + this.currentCounter).show();
                $('#RBMColumn3Row' + this.currentCounter).show();
                $('#RBMColumn4Row' + this.currentCounter).hide();
                $('#RBMColumn5Row' + this.currentCounter).hide();
                break;
            case '2':
                $('#RBMColumn1Row' + this.currentCounter).show();
                $('#RBMColumn2Row' + this.currentCounter).show();
                $('#RBMColumn3Row' + this.currentCounter).hide();
                $('#RBMColumn4Row' + this.currentCounter).hide();
                $('#RBMColumn5Row' + this.currentCounter).hide();
                break;
            case '1':
                $('#RBMColumn1Row' + this.currentCounter).show();
                $('#RBMColumn2Row' + this.currentCounter).hide();
                $('#RBMColumn3Row' + this.currentCounter).hide();
                $('#RBMColumn4Row' + this.currentCounter).hide();
                $('#RBMColumn5Row' + this.currentCounter).hide();
                break;
        }
    },
    UpdateGridColumnCount: function (selectObj) {

        var idx = selectObj.selectedIndex;

        // get the value of the selected option 
        var which = selectObj.options[idx].text;
        this.UpdateGridColumnCountByCount(which);
    },
    GetGridSpecialRows: function () {
        if (this.questionType != 'Grid') return '';

        var result = '<table id="RBMGridColumnTable' + this.currentCounter + '"><tr>'
                             + '        <td colspan="2">Columns <select onchange="UpdateGridCount(' + this.locationCounter + ',this);" id="RBMGridColumnCount' + this.currentCounter + '"><option>1</option><option>2</option><option>3</option><option>4</option><option  selected="true">5</option></select></td>'
                             + '</tr>'
                             + '<tr id="RBMColumn1Row' + this.currentCounter + '">'
                             + '        <td><span class="fieldlabel">Column 1</span></td>'
                             + '        <td><input type="text" id="RbmGridColumn1' + this.currentCounter + '" /></td>'
                             + '</tr>'
                             + '<tr id="RBMColumn2Row' + this.currentCounter + '">'
                             + '        <td><span class="fieldlabel">Column 2</span></td>'
                             + '        <td><input type="text" id="RbmGridColumn2' + this.currentCounter + '" /></td>'
                             + '</tr>'
                             + '<tr id="RBMColumn3Row' + this.currentCounter + '">'
                             + '        <td><span class="fieldlabel">Column 3</span></td>'
                             + '        <td><input type="text" id="RbmGridColumn3' + this.currentCounter + '" /></td>'
                             + '</tr>'
                             + '<tr id="RBMColumn4Row' + this.currentCounter + '">'
                             + '        <td><span class="fieldlabel">Column 4</span></td>'
                             + '        <td><input type="text" id="RbmGridColumn4' + this.currentCounter + '" /></td>'
                             + '</tr>'
                             + '<tr id="RBMColumn5Row' + this.currentCounter + '">'
                             + '        <td><span class="fieldlabel">Column 5</span></td>'
                             + '        <td><input type="text" id="RbmGridColumn5' + this.currentCounter + '" /></td>'
                             + '</tr></table>';
        return result;
    },
    GetResultsGrid: function () {

        var result = '<div id="' + this.currentCounter + 'displayEditGrid_div" class="displayEdit">'
                    + '<label style="font-weight:bold;">Rows</label>'
                    + '<ul class="ss-magiclist-ul">'
                    + '<li rel="addresult" >'
                    + ' <input id="RbmAddGridItem' + this.locationCounter + '" value="Click to add Row"  class="label-input-label" type="text" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddGridResultItem(this)"/>'
                    + '</li>'
                    + '</ul>'
                   + '  </div>';

        return result;
    },
    GetResultsDropDown: function () {

        var result = '<div id="' + this.currentCounter + 'displayEditDropDown_div" class="displayEdit">'
                    + '<ul class="ss-magiclist-ul">'
                    + '<li rel="addresult" >'
                    + ' <input  type="radio" name="" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddDropDownResultItem(this)"/>'
                    + ' <input id="RbmAddDropDownItem' + this.locationCounter + '"  class="label-input-label" type="text" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddDropDownResultItem(this)"/>'
                    + '</li>'
                    + '</ul>'
                   + '  </div>';

        return result;
    },
    GetResultsChoice: function () {

        var result = '<div id="' + this.currentCounter + 'displayEditChoice_div" class="displayEdit">'
                    + '<ul class="ss-magiclist-ul">'
                    + '<li rel="addresult" >'
                    + ' <input  type="radio" name="" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddChoiceResultItem(this)"/>'
                    + ' <input id="RbmAddChoiceItem' + this.locationCounter + '"  class="label-input-label" type="text" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddChoiceResultItem(this)"/>'
                    + ' <span class="ss-add-other">'
                    + '<a id="RbmAddChoiceOtherItem' + this.locationCounter + '" href="#" onclick="questionsTestArray[' + this.locationCounter + '].AddChoiceOtherItem(this)">add "Other"</a></span>'
                    + '</li>'
                    + '</ul>'
                   + '  </div>';

        return result;
    },
    GetResultsChecks: function () {
        var result = '<div id="' + this.currentCounter + 'displayEditCheck_div" class="displayEdit">'
                    + '<ul class="ss-magiclist-ul">'
                    + '<li rel="addresult">'
                    + ' <input  type="checkbox" name="" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddCheckResultItem(this)"/>'
                    + ' <input id="RbmAddCheckboxItem' + this.locationCounter + '"  class="label-input-label" type="text" style="opacity: 0.5;" onclick="questionsTestArray[' + this.locationCounter + '].AddCheckResultItem(this)"/>'
                    + ' <span class="ss-add-other">'
                    + '<a id="RbmAddCheckboxOtherItem' + this.locationCounter + '" href="#" onclick="questionsTestArray[' + this.locationCounter + '].AddCheckboxOtherItem(this)">add "Other"</a></span>'
                    + '</li>'
                    + '</ul>'
                   + '  </div>';

        return result;
    },
    GetResultsText: function () {
        var result = ' <div id="' + this.currentCounter + 'displayEditText_div" class="displayEdit">'
                   + '    <input class="disabledpreview" value="Answer Here" type="text" disabled="disabled" style="width:250px;"/>'
                   + '  </div>';
        return result;
    },
    GetResultsParagraph: function () {
        var result = '<div id="' + this.currentCounter + 'displayEditParagraph_div" class="displayEdit">'
                       + '    <textarea class="disabledpreview"  disabled="disabled" style="width:100%;height:60px;">Answer Here</textarea>'
                       + '  </div>';
        return result;
    },
    CreateEdit: function (displayEdit) {
        if (currentQuestionInEdit != null) {
            currentQuestionInEdit.HideEdit();
        }
        if (displayEdit == null)
            displayEdit = 'block';
        currentQuestionInEdit = this;
        this.formTemplate = '<div id="' + this.currentCounter + 'QuestionContainerEdit" class="QuestionContainerEdit" display="' + displayEdit + '" >'
                            + '  <table>'
                            + '    <tr>'
                            + '        <td><span class="fieldlabel">Question Title</span></td>'
                            + '        <td><input id="' + this.currentCounter + 'questionTitle_tf" class="inputfield" style="width:350px;"/></td>'
                            + '    </tr>'
                            + '    <tr>'
                            + '        <td><span class="fieldlabel">Help</span></td>'
                            + '        <td><input id="' + this.currentCounter + 'help_tf" class="inputfield" style="width:350px;"/></td>'
                            + '    </tr>'
                            + '    <tr>'
                            + '        <td><span class="fieldlabel">Question Type</span></td>'
                            + '        <td>'
                            + '            <select id="' + this.currentCounter + 'questionType_tdd">'
                            + '                <option value="Text">Text</option>'
                            + '                <option value="Paragraph">Paragraph text</option>'
                            + '                <option value="MultipleChoice">Multiple choice</option>'
                            + '                <option value="CheckBoxes">Checkboxes</option>'
                            + '                <option value="DropDown">DropDown</option>'
                            + '                <option value="Grid">Grid</option>'
                            + '            </select>'
                            + '        </td>'
                            + '    </tr>'
                            + '  </table>'
                            + '<fieldset id="DivColumnsView' + this.currentCounter + '">' + this.GetGridSpecialRows() + '</fieldset>'
                            + '  <div id="' + this.currentCounter + 'displayEdit_div" class="displayEdit">'
                            + this.GetResults()
                            + '  </div>'
                            + '  <div class="formButtons">'
                            + '    <input id="' + this.currentCounter + 'IsSection_rcb" class="ksublockChk" type="checkbox"/>'
                            + '    <label class="fieldlabel">Hide From User</label>'
                            + '  </div>'
                            + '  <div class="formButtons">'
                            + '    <input id="' + this.currentCounter + 'IsEmail_rcb" class="ksublockChk" type="checkbox"/>'
                            + '    <label class="fieldlabel">Is Contact Email</label>'
                            + '  </div>'
                            + '  <div class="formButtons">'
                            + '    <input id="' + this.currentCounter + 'IsMobile_rcb" class="ksublockChk" type="checkbox"/>'
                            + '    <label class="fieldlabel">Is Contact Mobile</label>'
                            + '  </div>'
                            + '  <div class="formButtons">'
                            + '    <input type="button" id="' + this.currentCounter + 'Submit_db" class="ksublockBtn" value="Done"/>'
                            + '    <input id="' + this.currentCounter + 'Required_rcb" class="ksublockChk" type="checkbox"/>'
                            + '    <label class="fieldlabel" for="Required_rcb">Make this a required question</label>'
                            + '  </div>'
                            + ' </div>'
                            + '   <div id="' + this.currentCounter + 'QuestionEditController" class="QuestionEditController">'
                            + '<div class="ImageContainer ss-formwidget-top-button ss-formwidget-pressed ksu-inline-block" id="QuestionEditBtn' + this.currentCounter + '" ><div class="ImageContainer ss-formwidget-edit-icon ksu-inline-block"></div></div>'
                            + '<div class="ImageContainer ss-formwidget-top-button ksu-inline-block" id="QuestionRemoveBtn' + this.currentCounter + '"><div class="ImageContainer ss-formwidget-delete-icon ksu-inline-block"></div></div>'
                            + '</div>';


        this.questionContainer = $('#' + this.currentCounter + 'mainQuestionContainer');
        this.questionContainer.append(this.formTemplate);

        this.questionEditContainer = $('#' + this.currentCounter + 'QuestionContainerEdit');
        this.questionTitle = $('#' + this.currentCounter + 'questionTitle_tf');


        this.questionHelp = $('#' + this.currentCounter + 'help_tf');
        this.questionTypeContainer = $('#' + this.currentCounter + 'questionType_tdd');
        this.questionTypeContainer.attr('value', this.questionType);
        this.questionDisplayEdit = $('#' + this.currentCounter + 'displayEdit_div');
        this.questionContainer = $('#' + this.currentCounter + 'QCE');
        this.questionRequired = $('#' + this.currentCounter + 'Required_rcb');
        this.questionIsSection = $('#' + this.currentCounter + 'IsSection_rcb');
        this.questionIsEmail = $('#' + this.currentCounter + 'IsEmail_rcb');
        this.questionIsMobile = $('#' + this.currentCounter + 'IsMobile_rcb');
        this.sumbitButton = $('#' + this.currentCounter + 'Submit_db');
        this.questionRemoveButton = $('#QuestionRemoveBtn' + this.currentCounter);
        this.questionEditButton = $('#QuestionEditBtn' + this.currentCounter);
        this.questionEditController = $('#' + this.currentCounter + 'QuestionEditController');

        var currentObject = this;


        this.questionEditButton.click(function () {
            currentObject.HideEdit();
        });
        this.comboBoxColumnCounter = $('#RBMGridColumnCount' + this.currentCounter);
        //        this.comboBoxColumnCounter.change(function () {
        //            currentObject.UpdateGridColumnCount(this);
        //        });
        this.sumbitButton.click(function () {
            currentObject.HideEdit();
        });
        this.questionTypeContainer.change(function () {
            currentObject.SwitchQuestionType(this.value);
        });

        this.questionRemoveButton.click(function () {
            currentObject.RemoveEdit();
        });
    },

    ShowEdit: function () {
        this.RemoveView();
        this.questionEditContainer.show();
    },

    CreateView: function () {
        var asterisk = '';
        var currentQuestionTitle = 'Sample Question ' + this.currentCounter;
        if (RbmStringContains(this.questionRequired.attr("checked"), 'true')) {
            asterisk = '*';
        }

        if (this.questionTitle.attr("value") != "")
            currentQuestionTitle = this.questionTitle.attr("value");
        var viewTemplate = '<div id="' + this.currentCounter + 'ViewDisplayContainer" class="QuestionViewContainer">'
                          + '      <span class="viewtitle">' + currentQuestionTitle + '<span class="viewasterik">' + asterisk + '</span> </span>'
                          + '      <span class="viewhelp">' + this.questionHelp.attr("value") + '</span>'
                          + this.GetView();
+'   </div>';
        //        alert(this.questionContainer.attr("id"));
        this.questionContainer = $('#' + this.currentCounter + 'mainQuestionContainer');
        this.questionContainer.append(viewTemplate);
        this.questionDisplayEdit = $('#' + this.currentCounter + 'ViewDisplayContainer');
        var currentContainer = this.questionDisplayEdit;
        var currentHolder = this;
        this.questionEditController = $('#' + this.currentCounter + 'QuestionEditController');
        var currentQuestionEditController = this.questionEditController;

        this.questionContainer.mouseover(function () {
            if (currentHolder.currentView == 'view') {
                currentContainer.attr('class', 'QuestionViewContainerHighlight');
                //currentContainer.css('background-color', '#FFF9DD');
                currentQuestionEditController.show();
                //alert($(this).attr("id"));
            }

        });

        this.questionContainer.mouseout(function () {
            if (currentHolder.currentView == 'view') {
                currentContainer.attr('class', 'QuestionViewContainer');

                //currentHolder.css('background-color', '#FFFFFF');
                currentQuestionEditController.hide();
            }
        });

    },
    GetView: function () {
        switch (this.questionType) {
            case 'Text':
                return this.ViewText();
                break;
            case 'Paragraph':
                return this.ViewParagraph();
                break;
            case 'MultipleChoice':
                return this.ViewChoice();
                break;
            case 'CheckBoxes':
                return this.ViewCheckbox();
                break;
            case 'DropDown':
                return this.ViewDropDown();
                break;
            case 'Grid':
                return this.ViewGrid();
                break;
        }
    },
    ViewText: function () {
        var result = '      <input class="viewgeneratedtextinput" type="text" disabled="disabled" />';
        return result;
    },
    ViewParagraph: function () {
        var result = '    <textarea class="disabledpreview"  disabled="disabled" style="width:100%;height:60px;"></textarea>';
        return result;
    },
    RenameChoices: function () {
        var choiceDiv = $('#' + this.currentCounter + 'displayEditChoice_div ul li');
        var currentObject = this;
        var counter = 1;
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                var itemObject = RbmGetChildByTagName(domEleUL, 'input', 1);
                var itemValue = itemObject.value;
                var relItemValue = RbmGetAttribute(itemObject, "rel");
                var itemCompare = "Option" + relItemValue;
                if (itemValue == itemCompare) {
                    itemObject.value = "Option" + counter;
                    RbmSetAttribute(itemObject, "rel", counter);
                }
            }
            counter++;
        });
    },
    RenameGrid: function () {
        var choiceDiv = $('#' + this.currentCounter + 'displayEditGrid_div ul li');
        var currentObject = this;
        var counter = 1;
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                var itemObject = RbmGetChildByTagName(domEleUL, 'input', 1);
                var itemValue = itemObject.value;
                var relItemValue = RbmGetAttribute(itemObject, "rel");
                var itemCompare = "Option" + relItemValue;
                if (itemValue == itemCompare) {
                    itemObject.value = "Option" + counter;
                    RbmSetAttribute(itemObject, "rel", counter);
                }
            }
            counter++;
        });
    },
    RenameDropDown: function () {
        var choiceDiv = $('#' + this.currentCounter + 'displayEditDropDown_div ul li');
        var currentObject = this;
        var counter = 1;
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                var itemObject = RbmGetChildByTagName(domEleUL, 'input', 1);
                var itemValue = itemObject.value;
                var relItemValue = RbmGetAttribute(itemObject, "rel");
                var itemCompare = "Option" + relItemValue;
                if (itemValue == itemCompare) {
                    itemObject.value = "Option" + counter;
                    RbmSetAttribute(itemObject, "rel", counter);
                }
            }
            counter++;
        });
    },
    RenameChecks: function () {
        var choiceDiv = $('#' + this.currentCounter + 'displayEditCheck_div ul li');
        var currentObject = this;
        var counter = 1;
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                var itemObject = RbmGetChildByTagName(domEleUL, 'input', 1);
                var itemValue = itemObject.value;
                var relItemValue = RbmGetAttribute(itemObject, "rel");

                var itemCompare = "Option" + relItemValue;
                if (itemValue == itemCompare) {
                    itemObject.value = "Option" + counter;
                    RbmSetAttribute(itemObject, "rel", counter);
                }
            }
            counter++;



        });
    },
    ViewChoice: function () {
        //        var divElement = RbmGetElementById(this.currentCounter + 'displayEditChoice_div');
        //        var ulDiv = RbmGetElementsByTagName(divElement, 'ul')[0];
        var choiceDiv = $('#' + this.currentCounter + 'displayEditChoice_div ul li');
        var currentObject = this;
        var counter = 0;
        var result = '<ul class="ss-magiclist-ul">';
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                result += '<li>'
                + '<input id="' + inputId + '" name="' + nameId + '" type="radio" />'
                + '<label for="' + inputId + '" class="ss-choice-label">' + RbmGetChildByTagName(domEleUL, 'input', 1).value + '</label>';
+'</li>';
            }
            else if (relAttribute == "other") {
                result += '<li>'
                + '<input id="' + inputId + '" name="' + nameId + '" type="radio"/>'
                + 'Other: <input class="viewgeneratedtextinput" type="text"  />';
+'</li>';
            }
            counter++;



        });
        result = result + '</ul>';
        return result;
    },
    ViewGrid: function () {

        var tableHeaderString = '<thead><tr>';
        tableHeaderString += '<td class="ss-gridnumbers">'
                            + '</td>'
                            + '<td style="width: 6.25%" class="ss-gridnumbers ss-spacer">'
                            + '</td>';

        for (var i = 1; i <= this.gridColumnCounter; i++) {
            tableHeaderString += '<td style="width: 12.5%" class="ss-gridnumbers">'
                                 + '<label class="ss-gridnumber">'
                                 + $('#RbmGridColumn' + i + this.currentCounter).val() + '</label>'
                                 + '</td>';
        }

        tableHeaderString += '<td style="width: 6.25%" class="ss-gridnumbers ss-spacer">'
                            + '</td>';
        tableHeaderString += '</tr></thead>';

        var choiceDiv = $('#' + this.currentCounter + 'displayEditGrid_div ul li');
        var currentObject = this;
        var counter = 0;
        var result = '<tbody>';
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;


            if (relAttribute != "addresult" && relAttribute != "other") {

                var colClassString = 'ss-grid-row-odd';
                if ((counter % 2) != 0) colClassString = 'ss-grid-row-even';

                result += '<tr class="ss-gridrow ' + colClassString + '">'
                    + '<td class="ss-gridrow ss-leftlabel">'
                    + RbmGetChildByTagName(domEleUL, 'input', 0).value
                    + '</td>'
                    + '<td style="width: 6.25%" class="ss-gridrow ss-spacer">'
                    + '</td>';

                for (var i = 1; i <= currentObject.gridColumnCounter; i++) {

                    result += '<td style="width: 12.5%" class="ss-gridrow">'
                                + '<input type="radio" value="' + $('#RbmGridColumn' + i + currentObject.currentCounter).val() + '" name="' + nameId + counter + '" />'
                                 + '</td>';
                }
                result += '<td style="width: 6.25%" class="ss-gridrow ss-spacer">'
                        + '</td>';
                result += '</tr>';
            }
            counter++;



        });
        result = result + '</tbody>';
        result = '<table cellspacing="0" cellpadding="5" border="0">' + tableHeaderString + result + '</table>'

        return result;
    },
    ViewDropDown: function () {
        //        var divElement = RbmGetElementById(this.currentCounter + 'displayEditChoice_div');
        //        var ulDiv = RbmGetElementsByTagName(divElement, 'ul')[0];
        var choiceDiv = $('#' + this.currentCounter + 'displayEditDropDown_div ul li');
        var currentObject = this;
        var counter = 0;
        var result = '';
        result = result + '<select class="viewgeneratedtextinput" style="width:250px;">';
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                result += '<option>' + RbmGetChildByTagName(domEleUL, 'input', 1).value + '</option>';
            }
            counter++;
        });
        result = result + '</select>';
        result = result + '';
        return result;
    },
    ViewCheckbox: function () {
        var choiceDiv = $('#' + this.currentCounter + 'displayEditCheck_div ul li');
        var currentObject = this;
        var counter = 0;
        var result = '<ul class="ss-magiclist-ul">';
        choiceDiv.each(function (indexUL, domEleUL) {

            var relAttribute = RbmGetAttribute(domEleUL, "rel");
            var inputId = 'group_' + currentObject.currentCounter + '_' + counter;
            var nameId = 'group_' + currentObject.currentCounter;
            if (relAttribute != "addresult" && relAttribute != "other") {

                // domEle == this
                result += '<li>'
                + '<input id="' + inputId + '" name="' + nameId + '" type="checkbox" />'
                + '<label for="' + inputId + '" class="ss-choice-label">' + RbmGetChildByTagName(domEleUL, 'input', 1).value + '</label>';
+'</li>';
            }
            else if (relAttribute == "other") {
                result += '<li>'
                + '<input id="' + inputId + '" name="' + nameId + '" type="checkbox"/>'
                + 'Other: <input class="viewgeneratedtextinput" type="text"  />';
+'</li>';
            }
            counter++;



        });
        result = result + '</ul>';
        return result;
    },
    RemoveView: function () {
        this.questionDisplayEdit.remove();
    },


    DuplicateView: function () {
    },

    CopyView: function () {
    }

};