$(document).ready(function () {
    $(".select2").select2();
});

function getProdutosSubConjuntos() {
    $.ajax({
        type: "GET",
        url: document.location.origin + "/Produto/GetProdutosBySerie?id_Serie=" + $("#Series option:selected").val(),
        async: true,
        success: function (json) {
            $('#Produtos').val(null).trigger('change');
            $('#Produtos').empty().trigger("change");
            $.each(json, function (i, item) {
                $('#Produtos').append($('<option>', {
                    value: item.id_Produto,
                    text: item.nome
                }));
            });
        },
        error: function () {
            return "error";
        }
    });

    $.ajax({
        type: "GET",
        url: document.location.origin + "/SubConjunto/GetSubConjuntosBySerie?id_Serie=" + $("#Series option:selected").val(),
        async: true,
        success: function (json) {
            $('#SubConjuntos').val(null).trigger('change');
            $('#SubConjuntos').empty().trigger("change");
            $.each(json, function (i, item) {
                $('#SubConjuntos').append($('<option>', {
                    value: item.id_SubConjunto,
                    text: item.nome
                }));
            });
        },
        error: function () {
            return "error";
        }
    });
}