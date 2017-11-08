$(function () {

    $id = $.getParameterByName("id", window.location);
    $hemocentro = $("#doador-hemocentro");
    $nome = ("#doador-nome");
    $sobrenome = ("#doador-sobrenome");
    $peso = ("#doador-peso");
    $altura = ("#doador-altura");
    $dataNascimento = ("#doador-data-nascimento");
    $tipoSanguineo = ("#doador-tipo-sanguineo");
    $fatorRH = ("#doador-fator-rh");

    //Datemask dd/mm/yyyy
    $('.data-nascimento').inputmask('dd/mm/yyyy', {'placeholder': 'dd/mm/aaaa'});

    $("#administrador-cadastro").on("click", function () {
       if(!$.validacaoFormulario()){
            return;
        }

        $.ajax({
            url: "http://localhost:52378/doador",
            type: "POST",
            data: {
                "idHemocentro": $($hemocentro).val(),
                "nome": $($nome).val(),
                "sobrenome": $($sobrenome).val(),
                "peso": $($peso).val(),
                "altura": $($altura).val(),
                "dataNascimento": $($dataNascimento).val(),
                "tipoSanguineo": $($tipoSanguineo).val(),
                "fatorRH": $($fatorRH).val()
            },
            success: function (data) {
                window.location.replace("doador_editar.html?id=" + data);
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        });
    });

});