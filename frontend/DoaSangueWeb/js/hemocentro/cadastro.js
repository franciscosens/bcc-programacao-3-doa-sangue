$(function () {

    $campoEstado = $("#hemocentro-estado");
    $campoCidade = $("#hemocentro-cidade");
    $campoBairro = $("#hemocentro-bairro");
    $campoLogradouro = $("#hemocentro-logradouro");
    $campoNumero = $("#hemocentro-numero");
    $campoNome = $("#hemocentro-nome");
    $campoDescricao = $("#hemocentro-descricao");
    $campoCEP = $("#hemocentro-cep");

    $campoCEP.focusout(function () {
        var cep = $(this).val();
        cep = cep.replace("-", "");
        limparCampos();
        if (cep.length === 8) {
            $.ajax({
                url: "https://viacep.com.br/ws/" + cep + "/json/",
                type: "GET",
                success: function (data) {
                    if (typeof data.erro === "undefined") {
                        $campoEstado.val(data.uf);
                        $campoCidade.val(data.localidade);
                        $campoBairro.val(data.bairro);
                        $campoLogradouro.val(data.logradouro);
                        $campoNumero.focus();
                    } else {
                        $.alertError("CEP inválido");
                        $campoCEP.focus();
                    }
                },
                error: function () {
                    $.alertError("CEP inválido");
                    $campoCEP.focus();
                }
            });
        } else {
            $.alertError("Tamanho do cep é inválido");
            $campoCEP.focus();
        }
    });

    function limparCampos() {
        $campoEstado.val("");
        $campoCidade.val("");
        $campoBairro.val("");
        $campoLogradouro.val("");
    }

    $('.cep-mask').inputmask('99999-999');

    $("#hemocentro-cadastro").on("click", function () {
        if (!$.validacaoFormulario()) {
            return;
        }
        $.ajax({
            url: "http://localhost:52378/hemocentro",
            type: "POST",
            data: {
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
                window.location.replace("hemocentro_editar.html?id=" + data);
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        });
    });

});