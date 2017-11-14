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

    $.ajax({
        url: "http://localhost:52378/usuario/" + $id,
        type: "GET",
        error: function (data) {
            alert("Não foi possível se conectar ao servidor");
            location.reload();
        },
        success: function (data) {
            $($nome).val(data.Nome);
            $($sobrenome).val(data.Sobrenome);
            $($login).val(data.Login);
            $('#administrador-privilegio option[value=' + data.Privilegio + ']').prop('selected', true);
            $($dataNascimento).val($.formatarDataPadraoBR(data.DataNascimento));
        }
    });


    $("#administrador-cadastro").on("click", function () {

        if(!$.validacaoFormulario()){
            return;
        }

        // TODO validações dos campos antes de submitar o form
        $.ajax({
            url: "http://localhost:52378/usuario",
            type: "PUT",
            data: {
                "nome": $($nome).val(),
                "sobrenome": $($sobrenome).val(),
                "login": $($login).val(),
                "senha": $($senha).val(),
                "privilegio": $($privilegio).val(),
                "dataNascimento": $($dataNascimento).val()
            },
            success: function (data) {
                $.alertSuccess("Doador alterado com sucesso");
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        });
    });


});