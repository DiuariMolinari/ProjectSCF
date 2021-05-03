function SugeriInvestimento(periodo, valorInvestido) {

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Investimento/SugerirTipoInvestimento/",
        data: { valor: valorInvestido, periodo: periodo },
        success: function (data) {
            console.log(data);
            Swal.fire({
                icon: 'success',
                title: `Melhor Investimento: <Br> <label style="color:lightgreen; padding-left: 15px;"> ${data.tipoInvestimento}</label> <Br> <Br> Valor ao final do período: <Br> <label style="color:lightgreen; padding-left: 15px;">${data.detalhesInvestimento}</label> <Br>  <Br>  <Br> Demais Investimentos: <label style="color:lightcoral; padding-left: 15px;">${data.outrosInvestimentos} </label>`,
                text: "",
                customClass: 'swal-wide'
            })
        },
        error: function (x, y, z) {
            console.log(x);
            console.log(y);
            console.log(z);
        }
    });
}

$(window).on('load', function () {
    var valorInvestido = $('#valorInvestido');
    var periodo = $('#periodo');

    valorInvestido.focusout(function (eventObj) {
        var valorInvestidoValue = valorInvestido.val();
        var periodoValue = periodo.val();

        if (valorInvestidoValue !== "" && periodoValue !== "") {
            SugeriInvestimento(periodoValue, valorInvestidoValue);
        }
    });

    periodo.focusout(function (eventObj) {
        var valorInvestidoValue = valorInvestido.val();
        var periodoValue = periodo.val();

        if (valorInvestidoValue !== "" && periodoValue !== "") {
            SugeriInvestimento(periodoValue, valorInvestidoValue);
        }
    });
});
 