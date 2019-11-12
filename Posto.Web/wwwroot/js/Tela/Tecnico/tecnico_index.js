$(document).ready(function () {

    $('.tecnicos').DataTable({
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

function EditarTecnico(id) {
    location.href = document.URL + "/Edit?Id=" + id;
}

function RemoverTecnico(id) {
    $.ajax({
        type: "POST",
        url: document.URL + "/Remove?id=" + id,
        async: true,
        success: function (json) {
            toastr.success("Tecnico", json);
        },
        error: function () {
            return "error";
        }
    });
}