google.charts.load("current", { packages: ["corechart"] });
google.charts.load("current", { packages: ["line"] });

var lstSoatSeguroBE = null;
var lstSoatTipoBE = null;
var lstSoatTipoVehiculoBE = null;
var lstSoatVencimientoBE = null;

$(document).ready(function () {
    ListarSoatSeguro();
    ListarSoatTipo();
    ListarSoatTipoVehiculo();
    ListarSoatVencimiento();
});

function ListarSoatSeguro() {
    $("#dt-tabla-seguro").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/SoatSeguro",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Seguro', 'Porcentaje']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-seguro").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_POR_DO
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_POR_DO]);
                    });

                    lstSoatSeguroBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardSoatSeguro);
                }
            }
        }
    });
}

function ListarSoatTipo() {
    $("#dt-tabla-tipo").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/SoatTipo",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Tipo', 'Porcentaje']);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-tipo").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_POR_DO
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_POR_DO]);
                    });

                    lstSoatTipoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardSoatTipo);
                }
            }
        }
    });
}

function ListarSoatTipoVehiculo() {
    $("#dt-tabla-tipo-vehiculo").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/SoatTipoVehiculo",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Tipo Vehiculo', 'Porcentaje']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-tipo-vehiculo").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_POR_DO
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_POR_DO]);
                    });

                    lstSoatTipoVehiculoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardTipoVehiculo);
                }
            }
        }
    });
}

function ListarSoatVencimiento() {
    $("#dt-tabla-vencimiento").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/SoatVencimiento",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Fecha Vencimiento', 'Cantidad']);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-vencimiento").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI]);
                    });

                    lstSoatVencimientoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardSoatVencimiento);
                }
            }
        }
    });
}



function DashboardSoatSeguro() {
    var data = google.visualization.arrayToDataTable(lstSoatSeguroBE);
    
    var options = {
        title: 'Soat Seguro',
        is3D: true,
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-seguro'));
    chart.draw(data, options);
}

function DashboardSoatTipo() {
    var data = google.visualization.arrayToDataTable(lstSoatTipoBE);

    var options = {
        title: 'Soat Tipo',
        is3D: true,
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-tipo'));
    chart.draw(data, options);
}

function DashboardTipoVehiculo() {
    var data = google.visualization.arrayToDataTable(lstSoatTipoVehiculoBE);

    var options = {
        title: 'Soat Tipo Vehiculo',
        is3D: true,
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-tipo-vehiculo'));
    chart.draw(data, options);
}

function DashboardSoatVencimiento() {
    var data = google.visualization.arrayToDataTable(lstSoatVencimientoBE);

    /*var options = {
        chart: {
            title: 'Vehiculos vendidos por año'//,
            //subtitle: 'in millions of dollars (USD)'
        },
        width: 900,
        height: 500
    };*/

    var chartVencimiento = new google.charts.Line(document.getElementById('dashboard-vencimiento'));

    chartVencimiento.draw(data);
}