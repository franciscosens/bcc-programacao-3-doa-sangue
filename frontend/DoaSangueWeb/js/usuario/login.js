$(function () {


    $("#btn-login").on("click", function () {
        $(this).attr("disabled", "disabled");
        $.ajax({
            url: "http://localhost:52378/usuario/login",
            type: "POST",
            data: {
                "login" : $("#usuario-login").val(),
                "senha": $("#usuario-senha").val()
            },
            success: function (data) {
                sessionStorage.setItem("usuarioLogado", data);
                sessionStorage.setItem("usuarioLogadoNome", data);
                sessionStorage.setItem("usuarioLogadoSobrenome", data["sobrenome"]);
                sessionStorage.setItem("usuarioLogadoLogin", $("#usuario-login").val());
                console.log(data);
            },
            error: function(request, status, error){
                // if(request.status === 400){
                    console.log(request.responseText);
                // }
            }
        });
    })
});