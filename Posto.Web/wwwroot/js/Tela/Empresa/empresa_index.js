$(document).ready(function () {

    $('.empresas').DataTable({
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

function EditarEmpresa(id) {
    location.href = document.URL + "/EditarEmpresa?Id=" + id;
}

function RemoverEmpresa(id) {
    $.ajax({
        type: "POST",
        url: document.URL + "/RemoverEmpresa?id=" + id,
        async: true,
        success: function (json) {
            toastr.success("Empresa", json);
        },
        error: function () {
            return "error";
        }
    });
}