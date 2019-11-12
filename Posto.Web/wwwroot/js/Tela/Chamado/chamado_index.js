$(document).ready(function () {

    $('.chamados').DataTable({
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
        ],
        "columnDefs": [
            {
                // The `data` parameter refers to the data for the cell (defined by the
                // `data` option, which defaults to the column being worked with, in
                // this case `data: 0`.
                "data": 3,
                "render": function (data, type, row) {
                    if (row[3] === "Aberto") {
                        return "Aberto";
                    }
                    return row[3];
                },
                "targets": 3
            }
        ]

    });
});

function FinalizarChamado(id) {
    location.href = document.location.origin + "/Chamado/FinalizarChamado?id_chamado=" + id;
}

function RemoverChamado(id) {
    $.ajax({
        type: "POST",
        url: document.location.origin + "/Chamado/Remove?id=" + id,
        async: true,
        success: function (json) {
            toastr.success("Chamado", json);
        },
        error: function () {
            return "error";
        }
    });
}

function AdicionarTecnico(id) {
    $("#id_Chamado").val(id);
    $.ajax({
        type: "GET",
        url: document.location.origin + "/Chamado/GetAllTecnicos",
        async: true,
        success: function (json) {
            $('#tecnicos').val(null).trigger('change');
            $('#tecnicos').empty().trigger("change");
            $.each(json, function (i, item) {
                $('#tecnicos').append($('<option>', {
                    value: item.value,
                    text: item.text
                }));
            });
        },
        error: function () {
            return "error";
        }
    });
}

function SalvarTecnico() {
    $.ajax({
        type: "POST",
        url: document.location.origin + "/Chamado/SalvarTecnico?id_Tecnico=" + $("#tecnicos option:selected").val() + "&id_Chamado=" + $("#id_Chamado").val(),
        async: true,
        success: function (json) {
            toastr.success(json, "Chamado");
        },
        error: function () {
            return "error";
        }
    });
}