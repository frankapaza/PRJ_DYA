$(document).ready(function () {
    $("#btn_enviar").click(enviarMail);

    $("#txt_nombre").keypress(function () {
        $("#txt_nombre").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_email").keypress(function () {
        $("#txt_email").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_area").keypress(function () {
        $("#txt_area").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_sector").keypress(function () {
        $("#txt_sector").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_tema").keypress(function () {
        $("#txt_tema").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_cuerpo_contenido").keypress(function () {
        $("#txt_cuerpo_contenido").next(".invalid-feedback").css("display", "none");
    });
});

function limpiar() {
    $("#txt_nombre").next(".invalid-feedback").css("display", "none");
    $("#txt_email").next(".invalid-feedback").css("display", "none");
    $("#txt_area").next(".invalid-feedback").css("display", "none");
    $("#txt_sector").next(".invalid-feedback").css("display", "none");
    $("#txt_tema").next(".invalid-feedback").css("display", "none");
    $("#txt_cuerpo_contenido").next(".invalid-feedback").css("display", "none");
}

function enviarMail() {
    limpiar();

    var flgEnviar = true;

    if ($.trim($("#txt_nombre").val()) == "") {
        $("#txt_nombre").next(".invalid-feedback").css("display", "block");
        flgEnviar = false;
    }

    if ($.trim($("#txt_email").val()) == "") {
        $("#txt_email").next(".invalid-feedback").css("display", "block");
        flgEnviar = false;
    }

    if ($.trim($("#txt_area").val()) === "") {
        $("#txt_area").next(".invalid-feedback").css("display", "block");
        flgEnviar = false;
    }

    if ($.trim($("#txt_sector").val()) === "") {
        $("#txt_sector").next(".invalid-feedback").css("display", "block");
        flgEnviar = false;
    }

    if ($.trim($("#txt_tema").val()) === "") {
        $("#txt_tema").next(".invalid-feedback").css("display", "block");
        flgEnviar = false;
    }

    if ($.trim($("#txt_cuerpo_contenido").val()) == "") {
        $("#txt_cuerpo_contenido").next(".invalid-feedback").css("display", "block");
        flgEnviar = false;
    }

    if (flgEnviar) {
        var objContacto = new Object();
        objContacto.Nombre = $("#txt_nombre").val();
        objContacto.Email = $("#txt_email").val();
        objContacto.Area = $("#txt_area").val();
        objContacto.Sector = $("#txt_sector").val();
        objContacto.Tema = $("#txt_tema").val();
        objContacto.Cuerpo_Contenido = $("#txt_cuerpo_contenido").val();

        $.ajax({
            url: ruta_actual + "Portal/enviarCorreo",
            data: JSON.stringify(objContacto),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result) {
                    Swal.fire(
                        {
                            title: '¡Correo Enviado!',
                            text: 'Su correo fue enviado con éxito, se procederá a responderle en respuesta lo más antes posible. Gracias.',
                            type: 'success'
                        });
                } else {
                    msj_peligro("Ocurrio un error, volver a intentar nuevamente.");
                }
            },
            error: function (errormessage) {
                msj_error("Ocurrio un error, por favor contactar con soporte.");
            }
        });
    }
}