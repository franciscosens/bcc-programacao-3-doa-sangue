$(function () {

    $hemocentros = null;
    var ft = null;
    $.ajax({
        url: "http://localhost:52378/doador",
        type: "get",
        success: function (data) {
            $hemocentros = data;
            ft = FooTable.init(".table-doador", {
                "paging": {
                    "enabled": true,
                    "size": 10,
                    "position": "right",
                    "countFormat": "{CP}ª página de {TP} páginas"
                },
                "sorting": {
                    "enabled": true
                },
                "filtering": {
                    "enabled": true,
                    "ignoreCase": true,
                    "min": 4,
                    "placeholder": "Pesquisa",
                    "footable-empty": "aos"
                },
                "columns": [
                    {
                        "title": "Hemocentro",
                        "name": "Hemocentro",
                        "formatter": function formatter(value, options, rowData) {
                            return rowData.Hemocentro.Nome
                        },
                        "type": "object"
                    },
                    {
                        "title": "Cidade",
                        "name": "Hemocentro",
                        "formatter": function formatter(value, options, rowData) {
                            return rowData.Hemocentro.Cidade
                        },
                        "type": "object"
                    },
                    {
                        "name": "NomeCompleto",
                        "title": "Nome Completo",
                        "type": "string"
                    },
                    {
                        "name": "TipoSanguineoFatorRH",
                        "title": "Tipo Sanguíneo",
                        "type": "string"
                    },
                    {

                        "name": "DataNascimento",
                        "title": "Data Nascimento",
                        "type": "string",
                        "formatter" : function formatter(value, option, rowData) {
                            return formatarDataPadraoBR(value);
                        },
                        "sortable": false
                    },
                    {
                        "name": "Nome",
                        "title": "Ações",
                        "sortable": false
                    }
                ],
                "rows": $hemocentros
            })
        }
    });


    function formatarDataPadraoBR(data) {
        var dataNascimentoServidor = new Date(data);
        var dia = (dataNascimentoServidor.getDate() < 10 ? "0" : "") + dataNascimentoServidor.getDate();
        var mes = (dataNascimentoServidor.getMonth() < 10 ? "0" : "") + dataNascimentoServidor.getMonth();
        var ano = dataNascimentoServidor.getFullYear();
        return dia + "/" + mes + "/" + ano;
    }
});