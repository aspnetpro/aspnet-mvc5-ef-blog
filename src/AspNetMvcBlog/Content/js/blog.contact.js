jQuery(function ($) {

    //validate
    $('#form-contact').validate({
        rules: {
            'Name': 'required',
            'Email': {
                'required': true,
                'email': true
            },
            'Message': 'required'
        },
        messages: {
            'Name': 'Nome é obrigatório',
            'Email': {
                'required': 'Email é obrigatório',
                'email': 'Email inválido'
            },
            'Message': 'Mensagem é obrigatório'
        }
    });

});