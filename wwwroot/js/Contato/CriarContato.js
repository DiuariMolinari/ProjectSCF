$(document).ready(function () {

    var telefone = $('#Telefone')
    telefone.inputmask("(99) 99999-9999", { autoUnmask: true, removeMaskOnSubmit: true });

    var btnSalvar = $("#btnSalvar");
    btnSalvar.click(function () {
        var value = telefone.val();
        telefone.val(value.replace(".", "").replace("/", "").replace("-", "").replace("_", ""));
    })
});


