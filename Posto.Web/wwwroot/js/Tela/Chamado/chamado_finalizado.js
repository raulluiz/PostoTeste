$(document).ready(function () {
    $(".select2").select2();

    $("#Series").val($("#Id_Serie").val());

    $("#Series").prop("disabled", true);
    $('#Series').trigger('change');

    $("#SubConjuntosCliente").prop("disabled", true);
    $('#SubConjuntosCliente').trigger('change');

    $("#ProdutosCliente").prop("disabled", true);
    $('#ProdutosCliente').trigger('change');
    
});