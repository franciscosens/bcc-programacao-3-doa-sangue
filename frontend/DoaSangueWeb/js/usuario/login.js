$(function () {

    $botadLogin = $("#btn-login");

    $("#usuario-senha").keypress(function (e) {
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
                sessionStorage.setItem("usuarioLogadoToken", resultado.token);
                sessionStorage.setItem("usuarioLogadoNome", resultado.nome);
                sessionStorage.setItem("usuarioLogadoSobrenome", resultado.sobrenome);
                sessionStorage.setItem("usuarioLogadoLogin", $("#usuario-login").val());
                window.location.replace("index.html");
            },
            error: function (request, status, error) {
                if(request.status === 403) {
                    $.alertError($.removerAspas(request.responseText));
                    $botadLogin.removeAttr("disabled");
                }
                if (request.status === 400) {
                    console.log(request.responseText);
                }
            }
        });
    });
});