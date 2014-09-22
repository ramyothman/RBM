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
    this.containerDiv.append('<div id="' + this.currentCounter + 'mainQuestionContainer" class="mainQuestionContainer" rel="' + strQuestionId + '"></div>');
    this.currentQuestionId = strQuestionId;
    this.questionContainer = $('#' + this.currentCounter + 'mainQuestionContainer');

}
SurveyQuestion.prototype = {
    currentQuestionId: -1,
    formTemplate: '',
    title: 'Title Here',
    changed: false,
    help: '',
    locationCounter: 0,
    containerDiv: null,
    currentView: 'edit',
    items: new Array(),
    required: false,
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
        if (RbmStringContains(this.questionRequired.attr("checked"), 'true'))
            questionJSON.IsRequired = true;
        else
            questionJSON.IsRequired = false;

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
        }
        questionJSON.Answeres = Answeres;
        return questionJSON;
    },
    SetQuestionJsonToDiv: function (questionObject) {

        this.CreateEdit('none');

        this.questionRequired.attr("checked", questionObject.IsRequired);
        this.questionTitle.attr("value", questionObject.Title);
        this.questionHelp.attr("value", questionObject.Help);
        var questionTypeStr = 'Text';
        switch (questionObject.QuestionType) {
            case 3:
                questionTypeStr = 'Text';
                break;
            case 4:
                questionTypeStr = 'Paragraph';
                break;
            case 1:
                questionTypeStr = 'MultipleChoice';
                break;
            case 2:
                questionTypeStr = 'CheckBoxes';
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
        }
        //alert(value);
        this.questionType = value;
        switch (value) {
            case 'Text':
                if (RbmGetElementById(this.currentCounter + 'displayEditText_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditText_div').show();
                }
                break;
            case 'Paragraph':
                if (RbmGetElementById(this.currentCounter + 'displayEditParagraph_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditParagraph_div').show();
                }
                break;
            case 'MultipleChoice':
                if (RbmGetElementById(this.currentCounter + 'displayEditChoice_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditChoice_div').show();
                }
                break;
            case 'CheckBoxes':
                if (RbmGetElementById(this.currentCounter + 'displayEditCheck_div') == null) {
                    $('#' + this.currentCounter + 'displayEdit_div').append(this.GetResults());
                }
                else {
                    $('#' + this.currentCounter + 'displayEditCheck_div').show();
                }
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
        }
    },
    RemoveResult: function (element) {
        this.resultCounter--;
        $(element).parent().remove();
        this.RenameChoices();
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
                            + '            </select>'
                            + '        </td>'
                            + '    </tr>'
                            + '  </table>'
                            + '  <div id="' + this.currentCounter + 'displayEdit_div" class="displayEdit">'
                            + this.GetResults()
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
        this.sumbitButton = $('#' + this.currentCounter + 'Submit_db');
        this.questionRemoveButton = $('#QuestionRemoveBtn' + this.currentCounter);
        this.questionEditButton = $('#QuestionEditBtn' + this.currentCounter);
        this.questionEditController = $('#' + this.currentCounter + 'QuestionEditController');
        var currentObject = this;


        this.questionEditButton.click(function () {
            currentObject.HideEdit();
        });
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