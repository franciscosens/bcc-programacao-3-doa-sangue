$(function () {
    $.ajax({
        url: "http://localhost:52378/doacao",
        type: "get",
        success: function (data) {
            $hemocentros = data;
            ft = FooTable.init(".table-doacao", {
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
                        "title": "Doador",
                        "name": "Doador",
                        formatter: function formatter(value, option, rowData) {
                            return rowData.Doador.NomeCompleto;
                        },
                        "type": "object"
                    },
                    {
                        "title": "Hemocentro",
                        "name": "Doador",
                        formatter: function formatter(value, option, rowData) {
                            return rowData.Doador.Hemocentro.Nome;
                        },
                        "type": "object"
                    },
                    {
                        "title": "Tipo Sanguíneo",
                        "name": "Doador",
                        formatter: function formatter(value, option, rowData) {
                            return rowData.Doador.TipoSanguineoFatorRH;
                        },
                        "type": "object"
                    },
                    {
                        "name": "Litros",
                        "title": "ML",
                        "formatter" : function formatter(value, option, rowData) {
                            return value * 100 + " ml";
                        },
                    },
                    {
                        "name": "DataCriacao",
                        "title": "Data",
                        "formatter" : function formatter(value, option, rowData) {
                            return $.formatarDataHoraPadraoBR(value);
                        },
                        "sortable": false
                    },
                    {
                        "name": "StatusExtenso",
                        "title": "Status"
                    }
                ],
                "rows": $hemocentros

            });
        }
    });
});