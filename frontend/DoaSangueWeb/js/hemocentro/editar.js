$(function () {
    $id = $.getParameterByName("id", window.location);
    $campoEstado = $("#hemocentro-estado");
    $campoCidade = $("#hemocentro-cidade");
    $campoBairro = $("#hemocentro-bairro");
    $campoLogradouro = $("#hemocentro-logradouro");
    $campoNumero = $("#hemocentro-numero");
    $campoNome = $("#hemocentro-nome");
    $campoDescricao = $("#hemocentro-descricao");
    $campoCEP = $("#hemocentro-cep");



    $.ajax({
        url: "http://localhost:52378/hemocentro/" + $id,
        type: "GET",
        error: function (data) {
            alert("Não foi possível se conectar ao servidor");
            location.reload();
        },
        success: function (data) {
            $($campoNome).val(data.Nome);
            $($campoCidade).val(data.Cidade);
            $($campoBairro).val(data.Bairro);
            $($campoLogradouro).val(data.Logradouro);
            $($campoNumero).val(data.Numero);
            $($campoCEP).val(data.CEP);
            $($campoDescricao).val(data.Descricao);
            $('#hemocentro-estado option[value=' + data.Estado + ']').prop('selected', true);
        }
    });

    $("#hemocentro-editar").on("click", function () {
        if(!$.validacaoFormulario()){
            return;
        }
        $.ajax({
            "url": "http://localhost:52378/hemocentro/update",
            "type": "POST",
            data: {
                "id": $id,
                "estado": $($campoEstado).val(),
                "cidade": $($campoCidade).val(),
                "bairro": $($campoBairro).val(),
                "logradouro": $($campoLogradouro).val(),
                "numero": $($campoNumero).val(),
                "nome": $($campoNome).val(),
                "descricao": $($campoDescricao).val(),
                "cep": $($campoCEP).val()
            },
            success: function (data) {
                $.alertSuccess("Hemocentro alterado com sucesso!");
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        });
    });

    $("#hemocentro-excluir").on("click", function () {
        $.ajax({
            "url": "http://localhost:52378/hemocentro/delete/" + $id,
            "type": "POST",
            success: function (data) {
                window.location.replace("hemocentro.html");
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        })
    });
});