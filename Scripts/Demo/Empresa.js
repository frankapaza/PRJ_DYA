google.charts.load('current', {
    'packages': ['geochart'],
    // Note: you will need to get a mapsApiKey for your project.
    // See: https://developers.google.com/chart/interactive/docs/basic_load_libs#load-settings
    'mapsApiKey': 'AIzaSyD-9tSrke72PouQMnMX-a7eZSW0jkFMBWY'
});

google.charts.load("current", { packages: ["corechart"] });

var lstEmpresaUbicacionBE = null;
var lstEmpresaTipoBE = null;
var lstEmpresaGiroBE = null;
var lstEmpresaEstadoBE = null;

$(document).ready(function () {
    ListarEmpresaUbicacion();
    ListarEmpresaTipo();
    ListarEmpresaGiro();
    ListarEmpresaEstado();
});

function ListarEmpresaUbicacion() {
    $("#dt-tabla-ubicacion").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/EmpresaUbicacion",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Provinces', 'Cantidad']);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-ubicacion").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([{ v: obj.ABR_DAT_VC, f: obj.DES_DAT_VC }, obj.NU_CAN_SI]);
                    });

                    lstEmpresaUbicacionBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardEmpresaUbicacion);
                }
            }
        }
    });
}

function ListarEmpresaTipo() {
    $("#dt-tabla-tipo").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/EmpresaTipo",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Tipo', 'Cantidad']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-tipo").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI]);
                    });
                    lstEmpresaTipoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardEmpresaTipo);
                }
            }
        }
    });
}

function ListarEmpresaGiro() {
    $("#dt-tabla-giro").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/EmpresaGiro",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Giro', 'Cantidad']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-giro").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI]);
                    });
                    lstEmpresaGiroBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardEmpresaGiro);
                }
            }
        }
    });
}

function ListarEmpresaEstado() {
    $("#dt-tabla-estado").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/EmpresaEstado",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Estado', 'Cantidad', { role: "style" }]);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-estado").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI, "#36c"]);
                    });
                    lstEmpresaEstadoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardEmpresaEstado);
                }
            }
        }
    });
}



function DashboardEmpresaUbicacion() {
    var data = google.visualization.arrayToDataTable(lstEmpresaUbicacionBE);

    var options = {
        region: 'PE',
        //'#e8e8e8','#4164ab','#23b7e5'
        sizeAxis: { minValue: 0, maxValue: 100 },
        colorAxis: { colors: ['#f5f5f5', '#23b7e5', '#52a7c1'/*,'#9c9','#fe9a67','#ffcc99','#ff6','#fd6698'*/] },
        resolution: 'provinces',
        backgroundColor: '#fff',
        datalessRegionColor: '#fff'/*,
          defaultColor: '#f5f5f5',
          colorAxis: {
            minValue: 0,
            maxValue: 400
          }*/
    };

    var chart = new google.visualization.GeoChart(document.getElementById('dashboard-ubicacion'));
    chart.draw(data, options);
}

function DashboardEmpresaTipo() {
    var data = google.visualization.arrayToDataTable(lstEmpresaTipoBE);

    var options = {
        title: '',
        pieHole: 0.5
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-tipo'));
    chart.draw(data, options);
}

function DashboardEmpresaGiro() {
    var data = google.visualization.arrayToDataTable(lstEmpresaGiroBE);

    var options = {
        title: '',
        pieHole: 0.5
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-giro'));
    chart.draw(data, options);
}

function DashboardEmpresaEstado() {
    var data = google.visualization.arrayToDataTable(lstEmpresaEstadoBE);

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
    var chart = new google.visualization.BarChart(document.getElementById("dashboard-estado"));
    chart.draw(view, options);
}