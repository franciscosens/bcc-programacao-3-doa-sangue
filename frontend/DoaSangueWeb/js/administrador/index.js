$(function () {

    $hemocentros = null;
    var ft = null;
    $.ajax({
        url: "http://localhost:52378/usuario",
        type: "get",
        success: function (data) {
            $doadores = data;
            ft = FooTable.init(".table-admin", {
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
                        "title": "Login",
                        "name": "Login",
                        "type": "string"
                    },
                    {
                        "name": "NomeCompleto",
                        "title": "Nome Completo",
                        "type": "string"
                    },
                    {
                        "name": "Id",
                        "title": "Ações",
                        "sortable": false,
                        "formatter" : function formatter(value, option, rowData) {
                            return '<a href="admin_editar.html?id=' + rowData.Id + '"><i class="fa fa-pencil"></i></a>';
                        }
                    }
                ],
                "rows": $doadores
            })
        }
    });
});