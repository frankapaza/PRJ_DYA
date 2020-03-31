google.charts.load("current", { packages: ["corechart"] });

var lstTelecomunicacionMarketshareBE = null;

$(document).ready(function () {
    ListarTelecomunicacionMarketshare();
});

function ListarTelecomunicacionMarketshare() {
    $("#dt-tabla-marketshare").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/TelecomunicacionesMarketshare",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Marketshare', 'Porcentaje']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-marketshare").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_POR_DO
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_POR_DO]);
                    });

                    lstTelecomunicacionMarketshareBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardTelecomunicacionMarketshare);
                }
            }
        }
    });
}



function DashboardTelecomunicacionMarketshare() {
    var data = google.visualization.arrayToDataTable(lstTelecomunicacionMarketshareBE);
    
    var options = {
        title: 'Soat Seguro',
        is3D: true,
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-marketshare'));
    chart.draw(data, options);
}