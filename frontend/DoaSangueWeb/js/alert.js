$(function () {

    $.criarMensagensValidacao = function ($conteudo) {
        $conteudo = $conteudo.replaceAll("\"", "");
        $conteudo = $conteudo.replaceAll("|", "<br />");
        $.alertError($conteudo);
    };

    $.removerAspas = function ($conteudo) {
        $conteudo = $conteudo.replaceAll("\"", "");
        return $conteudo;
    };

    String.prototype.replaceAll = function (toReplace, replaceWith) {
        return this.split(toReplace).join(replaceWith);
    };

    $.alert = function ($tipo, $texto) {
        $alertaClasse = ".alert-" + $tipo;
        $($alertaClasse + " > .alert-descricao").html($texto);
        $alerta = $($alertaClasse);
        $alerta.slideDown(800).delay(500);
        $alerta.delay(5000).slideUp(800);
    };

    $.alertError = function ($texto) {
        $.alert("danger", $texto);
    };

    $.alertSuccess = function ($texto) {
        $.alert("success", $texto);
    };


});