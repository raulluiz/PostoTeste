var empresa_global;
//Notification
toastr.options = {
    "closeButton": true,
    "debug": false,
    "progressBar": true,
    "preventDuplicates": false,
    "positionClass": "toast-top-right",
    "onclick": null,
    "showDuration": "400",
    "hideDuration": "1000",
    "timeOut": "7000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};

$(document).ready(function () {

    ConfigurarComboEmpresaGlobal();

    if ($('.i-checks')[0] !== undefined) {
        $('.i-checks').iCheck({
            checkboxClass: 'icheckbox_square-green',
            radioClass: 'iradio_square-green'
        });
    }

    if ($("#messagem")[0] !== undefined) {
        toastr.success($("#messagem").val());
    }

    if ($("#error")[0] !== undefined) {
        toastr.error($("#error").val());
    }

    //if ($(".select2")[0] !== undefined) {
    //    $(".select2").select2();
    //}
});

function ConfigurarComboEmpresaGlobal() {
    $.ajax({
        type: "GET",
        url: document.location.origin + "/Empresa/GetByUser",
        async: true,
        success: function (json) {

            $.each(json, function (index, item) {
                $("#empresa_global").append($("<option></option>").val(item.id).html(item.text));
            });

            if (getCookie("empresa_global") !== undefined && getCookie("empresa_global") !== "") {
                $("#empresa_global").val(getCookie("empresa_global"));
            } else {
                setCookie("empresa_global", $("#empresa_global option:selected").val(), 7);
            }
        },
        error: function () {
            return "error";
        }
    });
}

function getCookie(cName) {
    var i, x, y;
    const ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x === cName) {
            return unescape(y);
        }
    }
}

function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");

    const regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)");
    const results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return "";
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function setCookie(cName, value, exdays) {
    const exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    const cValue = escape(value) + (exdays === null ? "" : "; expires=" + exdate.toUTCString() + "; path=/;");
    document.cookie = cName + "=" + cValue;
}

$(document).on("change", "#empresa_global", function () {
    empresa_global = $("#empresa_global option:selected").val();
    setCookie("empresa_global", empresa_global, 1);

    window.location.href = window.location.href; //redireciona pro mesmo endereço
});