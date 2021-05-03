$(document).ready(function () {

    var Cnpj = $('#Cnpj')
    Cnpj.inputmask("99.999.999/9999-99", { autoUnmask: true, removeMaskOnSubmit: true });

    var btnSalvar = $("#btnSalvar");
    btnSalvar.click(function () {
        var value = Cnpj.val();
        Cnpj.val(value.replace(".", "").replace("/", "").replace("-", "").replace("_", ""));
    })
});


