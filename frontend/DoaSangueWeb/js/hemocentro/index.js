$(function () {
    $.ajax({
        url: "http://localhost:52378/hemocentro",
        type: "get",
        success: function (data) {
            $hemocentros = data;
            ft = FooTable.init(".table-hemocentro", {
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
                        "title": "Nome",
                        "name": "Nome"
                    },
                    {
                        "name": "EnderecoCompleto",
                        "title": "Endereço"
                    },
                    {
                        "title": "Ação",
                        "name": "Id",
                        formatter: function formatter(value, option, rowData) {
                            return '<a href="hemocentro_editar.html?id=' + rowData.Id + '"><i class="fa fa-pencil"></i></a>';
                        }

                    }
                ],
                "rows": $hemocentros

            });
        }
    });


});