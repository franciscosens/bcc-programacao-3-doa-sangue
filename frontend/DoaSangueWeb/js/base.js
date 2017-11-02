$(function () {
    if(sessionStorage.getItem("usuarioLogadoToken") === null){
        window.location.replace("login.html");
    }

    $("#nome-usuario-logado").html(sessionStorage.getItem("usuarioLogadoToken"));
})