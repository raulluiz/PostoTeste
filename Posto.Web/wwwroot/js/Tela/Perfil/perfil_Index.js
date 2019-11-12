$(document).ready(function () {

    $('.dataTables-example').DataTable({
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

function EditarPerfil(id) {
    location.href = document.URL + "/EditarPerfil?Id=" + id;
}

function RemoverPerfil(id) {
    $.ajax({
        type: "POST",
        url: document.URL + "/RemoverPerfil?Id=" + id,
        async: true,
        success: function (json) {
            toastr.success("Perfil", json);
        },
        error: function () {
            return "error";
        }
    });
}