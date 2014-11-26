jQuery(function ($) {
	var custom = {
		focusCleanup: false,
		wrapper: 'div',
		errorElement: 'span',
		highlight: function (element) {
			$(element).parents('.form-group').addClass('error');
		},
		success: function (element) {
		    $(element).parents('.form-group').removeClass('error');
		    $(element).parents('.form-group:not(:has(.clean))').find('div:last').remove();
		},
		errorPlacement: function (error, element) {
		    error.appendTo(element.parents('.form-group'));
		}
	};
	if ($.fn.validate) {
	    $.validator.setDefaults(custom);
	}
});