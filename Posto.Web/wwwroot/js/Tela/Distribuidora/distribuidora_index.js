$(document).ready(function () {

    $('.distribuidora').DataTable({
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

function Series(id) {
    location.href = document.location.origin + "/ClienteSerie/SeriesCliente?Id=" + id;
}

function EditarDistribuidora(id) {
    location.href = document.location.origin + "/Distribuidora/Edit?id=" + id;
}

function RemoverDistribuidora(id) {
    $.ajax({
        type: "POST",
        url: document.location.origin + "/Distribuidora/Remover?id=" + id,
        async: true,
        success: function (json) {
            toastr.success("Distribuidora", json);
        },
        error: function () {
            return "error";
        }
    });
}