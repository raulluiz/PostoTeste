$(document).ready(function () {
    $(".select2").select2();

    getSeries();
});

function getSeries() {
    $.ajax({
        type: "GET",
        url: document.location.origin + "/Cliente/GetClienteSeries?id=" + getParameterByName("Id", document.URL),
        async: true,
        success: function (json) {
            var itens = new Array();
            for (var i = 0; i < json.length; i++) {
                itens.push(json[i].id_Serie);
            }

            $(".select2").val(itens).trigger("change");
        },
        error: function () {
            return "error";
        }
    });
}
