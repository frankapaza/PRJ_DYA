google.charts.load("current", { packages: ["corechart"] });

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
                    lstDatosBE.push(['Vencimiento', 'Cantidad', { role: "style" }]);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-vencimiento").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI, "#36c"]);
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

    var view = new google.visualization.DataView(data);

    view.setColumns([0, 1,
        {
            calc: "stringify",
            sourceColumn: 1,
            type: "string",
            role: "annotation"
        },
        2]);

    var options = {
        //title: "none",
        //width: 460,
        //height: 250,
        //bar: { groupWidth: "90%" },
        legend: { position: "none" }
    };

    var chart = new google.visualization.BarChart(document.getElementById("dashboard-vencimiento"));
    chart.draw(view, options);
}