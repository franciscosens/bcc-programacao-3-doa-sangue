$(function () {

    $hemocentros = null;
    var ft = null;
    $.ajax({
        url: "http://localhost:52378/doador",
        type: "get",
        success: function (data) {
            $doadores = data;
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
                            return $.formatarDataPadraoBR(value);
                        },
                        "sortable": false
                    },
                    {
                        "name": "Id",
                        "title": "Ações",
                        "sortable": false,
                        "formatter" : function formatter(value, option, rowData) {
                            return '<a href="doador_editar.html?id=' + rowData.Id + '"><i class="fa fa-pencil"></i></a>';
                        }
                    }
                ],
                "rows": $doadores
            })
        }
    });
});