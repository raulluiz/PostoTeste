$(document).ready(function () {

    $('.produtos').DataTable({
        pageLength: 10,
        dom: '<"html5buttons"B>ftp',
        buttons: [
            { extend: 'copy' },
            { extend: 'csv' },
            { extend: 'excel', title: 'Perfil' },
            { extend: 'pdf', title: 'Perfil' },

            {
                extend: 'print',
                customize: function (win) {
                    $(win.document.body).addClass('white-bg');
                    $(win.document.body).css('font-size', '10px');

                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', 'inherit');
                }
            }
        ]

    });
});

function NovoProduto() {
    location.href = document.location.origin + "/Produto/NovoProduto?id_Serie=" + getParameterByName("id", document.URL);
}

function EditarProduto(id_Produto, id_Serie) {
    location.href = document.location.origin + "/Produto/Edit?id_Produto=" + id_Produto + "&id_Serie=" + id_Serie;
}

function RemoverProduto(id_Produto, id_Serie) {
    $.ajax({
        type: "POST",
        url: document.location.origin + "/Produto/Remove?id_Produto=" + id_Produto + "&id_Serie=" + id_Serie,
        async: true,
        success: function (json) {
            toastr.success("Produto", json);
        },
        error: function () {
            return "error";
        }
    });
}