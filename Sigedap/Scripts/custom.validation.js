/// <reference path="../Content/js/jquery-1.10.2.min.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="jquery.validate.unobtrusive.js" />


jQuery.validator.addMethod("mayor", function (value, element, param) {
    return Date.parse(value) >= Date.parse($(param).val());
});

jQuery.validator.unobtrusive.adapters.add("mayor", ["otro"], function(options) {
    options.rules["mayor"] = "#" + options.params.otro;
    options.messages["mayor"] = options.message;
});