$(function () {

    $botadLogin = $("#btn-login");

    $("#administrador-senha").keypress(function (e) {
       if(e.which === 13){
           $botadLogin.click();
       }
    });

    $('input').attr('autocomplete', 'off');

    $botadLogin.on("click", function () {
        $botadLogin.attr("disabled", "disabled");
        $.ajax({
            url: "http://localhost:52378/usuario/login",
            type: "POST",
            data: {
                "login": $("#usuario-login").val(),
                "senha": $("#usuario-senha").val()
            },
            success: function (data) {
                var resultado = JSON.parse(data);
                localStorage.setItem("usuarioLogadoToken", resultado.token);
                localStorage.setItem("usuarioLogadoNome", resultado.nome);
                localStorage.setItem("usuarioLogadoSobrenome", resultado.sobrenome);
                localStorage.setItem("usuarioLogadoLogin", $("#administrador-login").val());
                window.location.replace("index.html");
            },
            error: function (request, status, error) {
                if(request.status === 403) {
                    $.alertError($.removerAspas(request.responseText));
                    $botadLogin.removeAttr("disabled");
                }
                if (request.status === 400) {
                    $.alertError(request.responseText);
                }
            }
        });
    });
});