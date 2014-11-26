jQuery(function ($) {

	//validate
	$('#form-add-comment').validate({
		rules: {
			'Author': 'required',
			'Email': {
				'required': true,
				'email': true
			},
			'Content': 'required'
		},
		messages: {
			'Author': 'Autor é obrigatório',
			'Email': {
				'required': 'Email é obrigatório',
				'email': 'Email inválido'
			},
			'Content': 'Mensagem é obrigatório'
		}
	});

	//submit form
	$('[data-action=add-comment]').on('click', function () {
		$('#form-add-comment').submit();
	});

    //load comments
	$('#comments-list').on('click', '[data-action=load-comments]', function (e) {
	    var $button = $(this);
	    $button.button('loading');

	    //atrasa a chamada dos posts em 2 segundos
	    setTimeout(function () {

	        //chama os próximos posts via ajax
	        $.get($button.attr('data-url'))
                .done(function (result) {
                    $(result).hide().appendTo("#comments-list").fadeIn();
                    $button.remove();
                })
                .fail(function () {
                    alert("Cannot load comments!");
                });

	    }, 2000);

	});

});