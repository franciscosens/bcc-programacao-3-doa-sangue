$(function () {
    $language = {
        "zeroRecords": "Nenhum registro cadastrado",
        "infoEmpty": "Nenhum registro disponível",
        "paginate": {
            "first": "Primerio",
            "last": "Ultímo",
            "next": "Próximo",
            "previous": "Anterior"
        },
        "sSearch": "Pesquisa:  ",
        "processing": "Processando...",
        "loadingRecords": "Carregando...",
        "info": "Mostrando página _PAGE_ de _PAGES_",
        "infoFiltered": "(filtrado de _MAX_ registros totais)",
        "lengthMenu": '<span>Apresentar:</span> _MENU_'
    };

    $(".table-hemocentro").DataTable({
        'paging'      : true,
        'lengthChange': false,
        'searching'   : true,
        'ordering'    : true,
        'info'        : false,
        'autoWidth'   : false,
        "aoColumns": [
            {"bSortable": true, "width": "30%", "data" : "Nome"},
            {"bSortable": true, "width": "50%", "data": "Cidade"},
            {"bSortable": true, "width": "20%", "data": function (data) {
                return '<a href="hemocentro_editar.html?id=' + data.Id + '"><i class="fa fa-pencil"></i></a>';
            }}
        ],
        "ajax": "http://localhost:52378/hemocentro",
        "language" : $language
    });

});