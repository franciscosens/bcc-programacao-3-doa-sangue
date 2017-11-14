$(function () {

    $id = $.getParameterByName("id", window.location);
    $nome = ("#administrador-nome");
    $sobrenome = ("#administrador-sobrenome");
    $login = ("#administrador-login");
    $senha = ("#administrador-senha");
    $dataNascimento = ("#administrador-data-nascimento");
    $privilegio = ("#administrador-privilegio");

    //Datemask dd/mm/yyyy
    $('.data-nascimento').inputmask('dd/mm/yyyy', {'placeholder': 'dd/mm/aaaa'});

    $("#administrador-cadastro").on("click", function () {
       if(!$.validacaoFormulario()){
            return;
        }

        $.ajax({
            url: "http://localhost:52378/usuario",
            type: "POST",
            data: {
                "nome": $($nome).val(),
                "sobrenome": $($sobrenome).val(),
                "login": $($login).val(),
                "senha": $($senha).val(),
                "privilegio": $($privilegio).val(),
                "dataNascimento": $($dataNascimento).val()
            },
            success: function (data) {
                window.location.replace("administrador_editar.html?id=" + data);
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        });
    });

});