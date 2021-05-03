$(document).ready(function () {
    var cpfCnpj = $('#CpfCnpj')
    var data = $("#Data");
    var rg = $("#Rg");

    validateFields(true);
    cpfCnpj.keypress(function () {
        validateFields(false);
    });

    function validateFields(onEnter) {
        debugger;
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

        rg.removeAttr("disabled");
        data.removeAttr("disabled");
    }
    function addCnpjMask() {
        cpfCnpj.inputmask("99.999.999/9999-99", { autoUnmask: true, removeMaskOnSubmit: true });

        rg.attr("disabled", "disabled");
        rg.val("");

        data.attr("disabled", "disabled");
        data.val("");
    }

    var btnSalvar = $("#btnSalvar");
    btnSalvar.click(function () {
        var today = new Date();
        debugger;
        var dia = String(today.getDate()).padStart(2, '0');
        var mes = String(today.getMonth() + 1).padStart(2, '0');
        var ano = today.getFullYear();
        today = `${ano}-${mes}-${dia} ${today.getHours()}:${today.getMinutes()}:${today.getSeconds()}`

        $("#CadastradoEm").val(today);

        var value = cpfCnpj.val();
        cpfCnpj.val(value.replace(".", "").replace("/", "").replace("-", "").replace("_", ""));
    })
});


