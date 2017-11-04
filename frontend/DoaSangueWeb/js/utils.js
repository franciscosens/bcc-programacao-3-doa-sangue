$(function () {
    $.login = sessionStorage.getItem("usuarioLogadoLogin");
    $.nome =  sessionStorage.getItem("usuarioLogadoNome");
    $.sobrenome = sessionStorage.getItem("usuarioLogadoSobrenome");
    $.token = sessionStorage.getItem("usuarioLogadoToken");
    $.nomeCompleto = $.nome + " " + $.sobrenome;

    if(sessionStorage.getItem("usuarioLogadoToken") === null){
        window.location.replace("login.html");
    }

    $.ajax({
        url: "http://localhost:52378/usuario/verificarLogin",
        type: "POST",
        data: {
            "login" : $.login,
            "token" : $.token
        },
        error:  function (request, status, error){
            limparSessao();
            window.location.replace("login.html");
        }, success: function () {
            $("#nome-usuario-logado").html($.nomeCompleto);
            $('input,textarea').attr('autocomplete', 'off');

        }
    });

    $('input').attr('autocomplete', 'off');

    $.formatarDataPadraoBR = function (data) {
        var dataNascimentoServidor = new Date(data);
        var dia = (dataNascimentoServidor.getDate() < 10 ? "0" : "") + dataNascimentoServidor.getDate();
        var mes = (dataNascimentoServidor.getMonth() < 10 ? "0" : "") + dataNascimentoServidor.getMonth();
        var ano = dataNascimentoServidor.getFullYear();
        return dia + "/" + mes + "/" + ano;
    };

    $("#usuario-logout").on("click", function () {
        $.ajax({
            url: "http://localhost:52378/usuario/logout",
            type: "POST",
            data: {
                "token" : $.token
            },
            success: function (data) {
                limparSessao();
                window.location.replace("login.html");
            },
            error: function (request, status, error) {

            }
        });
    });



    function limparSessao(){
        sessionStorage.removeItem("usuarioLogadoToken");
        sessionStorage.removeItem("usuarioLogadoNome");
        sessionStorage.removeItem("usuarioLogadoSobrenome");
        sessionStorage.removeItem("usuarioLogadoLogin");
    }
});