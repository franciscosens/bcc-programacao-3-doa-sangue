$(function () {

    //Datemask dd/mm/yyyy
    $('.data-nascimento').inputmask('dd/mm/yyyy', {'placeholder': 'dd/mm/aaaa'});

    $hemocentro = $("#doador-hemocentro");
    $hemocentro.attr("disabled", "disable");
    $.ajax({
        url: "http://localhost:52378/hemocentro",
        type: "GET",
        error: function (data) {
            alert("Não foi possível se conectar ao servidor");
            location.reload();
        },
        success: function (data) {
            $hemocentro.append('<option disabled="disabled" selected="selected"></option>');
            $.each(data, function (i, item) {
                $hemocentro.append($('<option>', {value: item.Id, text: item.Nome}));
            });
            $hemocentro.removeAttr("disabled");
        }
    });

    $("#doador-cadastro").on("click", function () {

        // TODO validações dos campos antes de submitar o form
        $.ajax({
            url: "http://localhost:52378/doador",
            type: "POST",
            data: {
                "idHemocentro": $("#doador-hemocentro").val(),
                "nome": $("#doador-nome").val(),
                "sobrenome": $("#doador-sobrenome").val(),
                "peso": $("#doador-peso").val(),
                "altura": $("#doador-altura").val(),
                "dataNascimento": $("#doador-data-nascimento").val(),
                "tipoSanguineo": $("#doador-tipo-sanguineo").val(),
                "fatorRH": $("#doador-fator-rh").val()
            },
            success: function (data) {
                $.alertSuccess("Doador cadastrado com sucesso");
            },
            error: function (request, status, error) {
                if (request.status === 400) {
                    $.criarMensagensValidacao(request.responseText);
                }
            }
        });
    });


});