function convertTo() {


    $.ajax({
        type: 'Get',
        url: 'api/ConvertTo/?moeda=' + $('#Selecao').val() + '&valorEmCentavos=' + $('#valor').val(),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            alert(result);
        }
    });
}

function convertFrom() {


    $.ajax({
        type: 'Get',
        url: 'api/ConvertFrom/?moeda=' + $('#Selecao2').val() + '&valorEmCentavos=' + $('#valor2').val(),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            alert(result);
        }
    });
}