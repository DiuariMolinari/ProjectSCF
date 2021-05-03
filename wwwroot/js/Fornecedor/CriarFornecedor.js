$(document).ready(function () {
    var cpfCnpj = $('#CpfCnpj')
    var data = $("#Data");
    var rg = $("#Rg");

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

        rg.prop('required', true);
        rg.removeAttr("disabled");

        data.prop('required', true);
        data.removeAttr("disabled");
    }
    function addCnpjMask() {
        cpfCnpj.inputmask("99.999.999/9999-99", { autoUnmask: true, removeMaskOnSubmit: true });

        rg.prop('required', false);
        rg.attr("disabled", "disabled");
        rg.val("");

        data.prop('required', false);
        data.attr("disabled", "disabled");
        data.val("");
    }

    var btnSalvar = $("#btnSalvar");
    btnSalvar.click(function () {
        var value = cpfCnpj.val();
        cpfCnpj.val(value.replace(".", "").replace("/", "").replace("-", "").replace("_", ""));
    })
});


