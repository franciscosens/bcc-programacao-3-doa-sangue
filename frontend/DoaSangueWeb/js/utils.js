$(function () {
    $.login = localStorage.getItem("usuarioLogadoLogin");
    $.nome =  localStorage.getItem("usuarioLogadoNome");
    $.sobrenome = localStorage.getItem("usuarioLogadoSobrenome");
    $.token = localStorage.getItem("usuarioLogadoToken");
    $.nomeCompleto = $.nome + " " + $.sobrenome;

    if(localStorage.getItem("usuarioLogadoToken") === null){
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
            $("#nome-administrador-logado").html($.nomeCompleto);
            $('input,textarea').attr('autocomplete', 'off');

        }
    });

    $('input').attr('autocomplete', 'off');

    $.formatarDataPadraoBR = function (data) {
        var dataNascimentoServidor = new Date(data);
        var dia = (dataNascimentoServidor.getDate() < 10 ? "0" : "") + dataNascimentoServidor.getDate();
        var mes = (dataNascimentoServidor.getMonth() < 10 ? "0" : "") + (dataNascimentoServidor.getMonth() + 1);
        var ano = dataNascimentoServidor.getFullYear();
        return dia + "/" + mes + "/" + ano;
    };

    $.formatarDataHoraPadraoBR = function (dataHora) {
      dataHora = dataHora.split("T");
      console.log(dataHora);

      return $.formatarDataPadraoBR(dataHora[0]) + " " + dataHora[1];
    };

    $("#administrador-logout").on("click", function () {
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

    $.getParameterByName = function(name, url) {
        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    };

    function limparSessao(){
        localStorage.removeItem("usuarioLogadoToken");
        localStorage.removeItem("usuarioLogadoNome");
        localStorage.removeItem("usuarioLogadoSobrenome");
        localStorage.removeItem("usuarioLogadoLogin");
    }

    $.validacaoFormulario = function(){
        $campos = $(".validacao");
        var texto = "";
        $campos.each(function (){
            if($(this).val() === null || $(this).val() === ""){
                texto += $(this).data("nome");
                if($(this).is("input")) {
                    texto += " deve ser informado(a).<br/>";
                }else if($(this).is("select")){
                    texto += " deve ser selecionado(a).<br/>";
                }else if($(this).is("textarea")){
                    texto += " deve ser preenchido(a).<br/>";
                }
            }
        });
        $.alertError(texto);
        return texto === "";
    }
});