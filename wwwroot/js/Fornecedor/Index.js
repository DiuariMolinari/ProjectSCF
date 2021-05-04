$(document).ready(function () {
    var cpfCnpj = $('#CpfCnpj')
    cpfCnpj.inputmask("99.999.999/9999-99", { autoUnmask: true, removeMaskOnSubmit: true });

    validateFields(true);
    cpfCnpj.focusout(function () {
        validateFields(true);
    });

    cpfCnpj.keypress(function () {
        validateFields(false);
    });

    function validateFields(onEnter) {
        var tamanho = cpfCnpj.val().length;
        if (onEnter) {
            if (tamanho <= 11)
                addCpfMask();
            else
                addCnpjMask();
        }
        else {
            if (tamanho < 11)
                addCpfMask();
            else
                addCnpjMask();
        }
    }

    function addCpfMask() {
        cpfCnpj.inputmask("999.999.999-99", { autoUnmask: true, removeMaskOnSubmit: true });
    }
    function addCnpjMask() {
        cpfCnpj.inputmask("99.999.999/9999-99", { autoUnmask: true, removeMaskOnSubmit: true });
    }

    $("#btnClear").click(function () {
        $("#maxData").val("");
        $("#minData").val("");
        $("#Nome").val("");
        cpfCnpj.val("");
        $("#btnFilter").click();
    });

    var btnSalvar = $("#btnFilter");
    btnSalvar.click(function () {
        var value = cpfCnpj.val();
        cpfCnpj.val(value.replace(".", "").replace("/", "").replace("-", "").replace("_", ""));
    })
});
