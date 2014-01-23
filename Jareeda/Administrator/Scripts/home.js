/// <reference path="knockout-2.2.0.debug.js" />
$(function(){
    var viewModel = {
        firstName: ko.observable("John")
    };
    ko.applyBindings(viewModel);
});