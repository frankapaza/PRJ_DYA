google.charts.load('current', {
    'packages': ['geochart'],
    // Note: you will need to get a mapsApiKey for your project.
    // See: https://developers.google.com/chart/interactive/docs/basic_load_libs#load-settings
    'mapsApiKey': 'AIzaSyD-9tSrke72PouQMnMX-a7eZSW0jkFMBWY'
});

google.charts.load("current", { packages: ["corechart"] });

var lstDemografiaUbicacionBE = null;
var lstDemografiaSexoBE = null;
var lstDemografiaEdadBE = null;

//INICIANDO LOS DASHBOARD
$(document).ready(function () {
    ListarDemograficoUbicacion();
    ListarDemograficoSexo();
    ListarDemograficoEdad();
});

function ListarDemograficoUbicacion() {
    $("#dt-tabla-demografia").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/DemograficoUbicacion",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    console.log("UBICACION");
                    console.log(data);
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Provinces', 'Cantidad']);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-demografia").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([{ v: obj.ABR_DAT_VC, f: obj.DES_DAT_VC }, obj.NU_CAN_SI]);
                    });

                    lstDemografiaUbicacionBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardDemograficoUbicacion);
                }
            }
        }
    });
}

function ListarDemograficoSexo() {
    $("#dt-tabla-sexo").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/DemograficoSexo",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Sexo', 'Cantidad']);
                    $.each(data, function (i, obj) {
                        $("#dt-tabla-sexo").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI]);
                    });
                    lstDemografiaSexoBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardDemograficoSexo);
                }
            }
        }
    });
}

function ListarDemograficoEdad() {
    $("#dt-tabla-edad").dataTable().fnClearTable();
    $.ajax({
        url: ruta_actual + "Dashboard/DemograficoEdad",
        type: 'POST',
        cache: false,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var lstDatosBE = new Array();
                    lstDatosBE.push(['Rango edad', 'Cantidad', { role: "style" }]);

                    $.each(data, function (i, obj) {
                        $("#dt-tabla-edad").dataTable().fnAddData([
                            (i + 1),
                            obj.DES_DAT_VC,
                            obj.NU_CAN_SI
                        ]);

                        lstDatosBE.push([obj.DES_DAT_VC, obj.NU_CAN_SI, "#36c"]);
                    });
                    lstDemografiaEdadBE = lstDatosBE;
                    google.charts.setOnLoadCallback(DashboardDemograficoEdad);
                }
            }
        }
    });
}

//google.charts.setOnLoadCallback(drawChartEstado);

function DashboardDemograficoUbicacion() {
    /*var data = google.visualization.arrayToDataTable([
      ['Provinces','Cantidad'],
      [{v: 'PE-LMA', f: 'Municipalidad Metropolitana de Lima'},1],
        [{v: 'PE-AMA', f: 'Amazonas'},251],//CONSEJO REGIONAL XXV AMAZONAS
        [{v: 'PE-ANC', f: 'Ancash'},0],
        [{v: 'PE-APU', f: 'Apurímac'},493],//CONSEJO REGIONAL XXII APURIMAC
        [{v: 'PE-ARE', f: 'Arequipa'},6104],//CONSEJO REGIONAL V AREQUIPA
        [{v: 'PE-AYA', f: 'Ayacucho'},471],//CONSEJO REGIONAL XVI AYACUCHO
        [{v: 'PE-CAJ', f: 'Cajamarca'},947],//CONSEJO REGIONAL XVII CAJAMARCA
        [{v: 'PE-CUS', f: 'Cusco'},2748],//CONSEJO REGIONAL VI CUZCO
        [{v: '', f: '(local variant is Cuzco)'},0],
        [{v: 'PE-CAL', f: 'El Callao'},0],
        [{v: 'PE-HUV', f: 'Huancavelica'},292],//CONSEJO REGIONAL XXIV HUANCAVELICA
        [{v: 'PE-HUC', f: 'Huánuco'},846],//CONSEJO REGIONAL X HUANUCO
        [{v: 'PE-ICA', f: 'Ica'},2284],//CONSEJO REGIONAL IX ICA
        [{v: 'PE-JUN', f: 'Junín'},0],
        [{v: 'PE-LAL', f: 'La Libertad'},0],
        [{v: 'PE-LAM', f: 'Lambayeque'},0],
        [{v: 'PE-LIM', f: 'Lima'},45880],//CONSEJO REGIONAL III LIMA
        [{v: 'PE-LOR', f: 'Loreto'},0],
        [{v: 'PE-MDD', f: 'Madre de Dios'},195],//CONSEJO REGIONAL XXVI MADRE DE DIOS
        [{v: 'PE-MOQ', f: 'Moquegua'},339],//CONSEJO REGIONAL XXI MOQUEGUA
        [{v: 'PE-PAS', f: 'Pasco'},290],//CONSEJO REGIONAL XX PASCO
        [{v: 'PE-PIU', f: 'Piura'},2456],//CONSEJO REGIONAL VII PIURA
        [{v: 'PE-PUN', f: 'Puno'},1646],//CONSEJO REGIONAL XIV PUNO
        [{v: 'PE-SAM', f: 'San Martín'},562],//CONSEJO REGIONAL XV SAN MARTIN
        [{v: 'PE-TAC', f: 'Tacna'},1201],//CONSEJO REGIONAL XII TACNA
        [{v: 'PE-TUM', f: 'Tumbes'},221],//CONSEJO REGIONAL XXIII TUMBES
        [{v: 'PE-UCA', f: 'Ucayali'},0]
    ]);*/
    var data = google.visualization.arrayToDataTable(lstDemografiaUbicacionBE);

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

    var chart = new google.visualization.GeoChart(document.getElementById('geochart-colors'));
    chart.draw(data, options);
};


//POR SEXO
function DashboardDemograficoSexo() {
    var data = google.visualization.arrayToDataTable(lstDemografiaSexoBE);

    var options = {
        title: '',
        pieHole: 0.5
    };

    var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
    chart.draw(data, options);
}

//POR EDAD
function DashboardDemograficoEdad() {
    var data = google.visualization.arrayToDataTable(lstDemografiaEdadBE);

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
    var chart = new google.visualization.ColumnChart(document.getElementById("pieEstado"));
    chart.draw(view, options);
}