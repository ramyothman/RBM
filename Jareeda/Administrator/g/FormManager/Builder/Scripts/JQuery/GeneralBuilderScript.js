var myString = "Question Title : <input type=\"text\" id=\"QuestionTitle\" /><br/>Help : <input type=\"text\" id=\"Help\" /><br/>  ";
$(document).ready(function () {
    // Your code here
    LoadSurveyData();
    
    $("#ContainerDiv").sortable({
        revert: true
    });
    //$(".draggable").draggable({
    //    connectToSortable: "#ContainerDiv",
    //    helper: "clone",
    //    revert: "invalid"
    //});
});

var questionsTestArray = new Array();
var questionTestCounter = 0;
var dt;
function AddElement() {

    var dt = new SurveyQuestion($('#QuestionAddOption').attr("value"), questionTestCounter);
    //$("#ContainerDiv").append(myString);
    //HideAllQuestionEdit();
    dt.CreateEdit();
    questionsTestArray[questionTestCounter] = dt;
    questionTestCounter++;
}
function TextChanged(elementName, descriptionText) {

    //document.getElementById(elementName);
    var xz = RbmStringContains($(elementName).attr("value"), descriptionText);
    // alert(xz + '-' + $(elementName).attr("value") + '-' + descriptionText);
    if (RbmStringContains($(elementName).attr("value"), descriptionText)) {
        $(elementName).attr("value", '');
        $(elementName).css('color', '#666666');
    }
    else {
        $(elementName).css('color', '#000000');
    }
}
function TextLeave(elementName, descriptionText) {

    if ($(elementName).attr("value") == '') {
        $(elementName).attr("value", descriptionText);
        $(elementName).css('color', '#666666');
    }
    else {
        $(elementName).css('color', '#000000');
    }

}
function HideAllQuestionEdit() {
    for (i = 0; i < questionsTestArray.length; i++) {
        if (questionsTestArray[i].currentView == "edit") {
            questionsTestArray[i].HideEdit();
        }
    }
}
function LoadSurveyData() {
    var jsonString = hiddenJSONLoad.Get('JSONSurvey');
    var surveyObject = JSON.parse(jsonString, function (key, value) {
        return value;
    });
    if (surveyObject != null) {
        if (surveyObject.Title != null && surveyObject.Title != '')
            $('#TitleText').attr('value', surveyObject.Title);
        if (surveyObject.Description != null && surveyObject.Description != '')
            $('#SubTitleText').attr('value', surveyObject.Description);
        var i = 0;
        for (i = 0; i < surveyObject.Questions.length; i++) {
            var dt = new SurveyQuestion($('#QuestionAddOption').attr("value"), questionTestCounter, surveyObject.Questions[i].Id);
            dt.SetQuestionJsonToDiv(surveyObject.Questions[i]);
            questionsTestArray[questionTestCounter] = dt;
            questionTestCounter++;
        }
    }

}
function SaveData() {
    var surveyObject = new Object();
    surveyObject.Title = $('#TitleText').attr('value');
    surveyObject.Description = $('#SubTitleText').attr('value');
    surveyObject.LanguageCode = 'en-us';
    var Questions = new Array();
    
    for (i = 0; i < questionsTestArray.length; i++) {
        if (!questionsTestArray[i].isDeleted) {
            var q = questionsTestArray[i].GetQuestionJSON('en');
            var orderCheck = 1;
            $("#ContainerDiv").children("div").each(function () {
                if (this.id == questionsTestArray[i].idTitle)
                    q.QuestionOrder = orderCheck;
                orderCheck++;
            });
            Questions.push(q);
            
        }
    }

    


    surveyObject.Questions = Questions;
    var jasonText = JSON.stringify(surveyObject, function (key, value) {
        return value;
    });
    saveCallBack.PerformCallback(jasonText);
}

function UpdateGridCount(id, selectObj) {
    questionsTestArray[id].UpdateGridColumnCount(selectObj);
}