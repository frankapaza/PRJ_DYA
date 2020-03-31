google.charts.load('current', {
    'packages': ['geochart'],
    // Note: you will need to get a mapsApiKey for your project.
    // See: https://developers.google.com/chart/interactive/docs/basic_load_libs#load-settings
    'mapsApiKey': 'AIzaSyD-9tSrke72PouQMnMX-a7eZSW0jkFMBWY'
});

google.charts.load("current", { packages: ["corechart"] });

var lstMedicoUbicacionBE = null;
var lstMedicoEspecialidadBE = null;
var lstMedicoGradoBE = null;
var lstMedicoEstadoBE = null;

$(document).ready(function () {
    ListarMedicoUbicacion();
    ListarMedicoEspecialidad();
    ListarMedicoGrado();
    ListarMedicoEstado();
});

function ListarMedicoUbicacion() {
    $("#dt-tabla-ubicacion").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/MedicosUbicacion",
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

                    lstMedicoUbicacionBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardMedicoUbicacion);
                }
            }
        }
    });
}

function ListarMedicoEspecialidad() {
    $("#dt-tabla-especialidad").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/MedicosEspecialidad",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Especialidad', 'Cantidad']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-especialidad").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI]);
                    });
                    lstMedicoEspecialidadBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardMedicoEspecialidad);
                }
            }
        }
    });
}

function ListarMedicoGrado() {
    $("#dt-tabla-grado").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/MedicosGrado",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Grado', 'Cantidad']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-grado").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI]);
                    });
                    lstMedicoGradoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardMedicoGrado);
                }
            }
        }
    });
}

function ListarMedicoEstado() {
    $("#dt-tabla-estado").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/MedicosEstado",
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
                    lstMedicoEstadoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardMedicoEstado);
                }
            }
        }
    });
}



function DashboardMedicoUbicacion() {
    var data = google.visualization.arrayToDataTable(lstMedicoUbicacionBE);

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

function DashboardMedicoEspecialidad() {
    var data = google.visualization.arrayToDataTable(lstMedicoEspecialidadBE);

    var options = {
        title: '',
        pieHole: 0.5
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-especialidad'));
    chart.draw(data, options);
}

function DashboardMedicoGrado() {
    var data = google.visualization.arrayToDataTable(lstMedicoGradoBE);

    var options = {
        title: '',
        pieHole: 0.5
    };

    var chart = new google.visualization.PieChart(document.getElementById('dashboard-grado'));
    chart.draw(data, options);
}

function DashboardMedicoEstado() {
    var data = google.visualization.arrayToDataTable(lstMedicoEstadoBE);

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