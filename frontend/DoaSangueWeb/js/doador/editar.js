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

    $.ajax({
        url: "http://localhost:52378/doador/" + $id,
        type: "GET",
        error: function (data) {
            alert("Não foi possível se conectar ao servidor");
            location.reload();
        },
        success: function (data) {
            $($nome).val(data.Nome);
            $($sobrenome).val(data.Sobrenome);
            $($peso).val(data.Peso);
            $($altura).val(data.Altura);
            $($tipoSanguineo).val(data.TipoSanguineo);
            $($hemocentro).val(data.IdHemocentro);
            $('#doador-fator-rh option[value=' + data.FatorRH + ']').prop('selected', true);
            $($dataNascimento).val($.formatarDataPadraoBR(data.DataNascimento));

            ft = FooTable.init(".table-doacoes", {
                "paging": {
                    "enabled": true,
                    "size": 10,
                    "position": "right",
                    "countFormat": "{CP}ª página de {TP} páginas"
                },
                "columns": [
                    {
                        "name": "DataCriacao",
                        "title": "Data",
                        "formatter" : function formatter(value, option, rowData) {
                            return $.formatarDataHoraPadraoBR(value);
                        },
                        "sortable": false
                    },
                    {
                        "title": "Litros",
                        "name": "Litros"
                    },
                    {
                        "title": "Atendente",
                        "name": "Atendente"
                    },
                    {
                        "name": "StatusExtenso",
                        "title": "Status"
                    }

                ],
                "rows": data.Doacoes
            })


        }
    });


    $("#doador-cadastro").on("click", function () {

        // TODO validações dos campos antes de submitar o form
        $.ajax({
            url: "http://localhost:52378/doador",
            type: "PUT",
            data: {
                "id": $id,
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