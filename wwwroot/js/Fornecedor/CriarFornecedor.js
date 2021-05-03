$(document).ready(function () {

    var cpfCnpj = $('#CpfCnpj')
    $('#Rg').maxLength = 15;

    cpfCnpj.keypress(function () {
        var tamanho = cpfCnpj.val().length;
        
        if (tamanho < 11) {
            cpfCnpj.inputmask("999.999.999-99", { autoUnmask: true, removeMaskOnSubmit: true });
        } else {
            cpfCnpj.inputmask("99.999.999/9999-99", { autoUnmask: true, removeMaskOnSubmit: true });
        }
    });

    var btnSalvar = $("#btnSalvar");
    btnSalvar.click(function () {
        var today = new Date();
        var dia = String(today.getDate()).padStart(2, '0');
        var mes = String(today.getMonth() + 1).padStart(2, '0');
        var year = today.getFullYear();
        today = year + '-' + mes + '-' + dia;

        $("#CadastradoEm").val(today);

        var value = $("#CpfCnpj").val();
        $("#CpfCnpj").val(value.replace(".", "").replace("/", "").replace("-", "").replace("_", ""));
    })
});


