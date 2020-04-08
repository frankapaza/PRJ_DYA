$(document).ready(function () {
    $("#btn_registrar").click(registrar);

    $("#txt_nombre").keypress(function () {
        $("#txt_nombre").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_apellido").keypress(function () {
        $("#txt_apellido").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_documento").keypress(function () {
        $("#txt_documento").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_email").keypress(function () {
        $("#txt_email").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_celular").keypress(function () {
        $("#txt_celular").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_usuario").keypress(function () {
        $("#txt_usuario").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_password").keypress(function () {
        $("#txt_password").next(".invalid-feedback").css("display", "none");
    });
    $("#chk_terminos_condiciones").change(function () {
        $("label[for=chk_terminos_condiciones]").next(".invalid-feedback").css("display", "none");
    });
});

function limpiar() {
    $("#txt_nombre").next(".invalid-feedback").css("display", "none");
    $("#txt_apellido").next(".invalid-feedback").css("display", "none");
    $("#txt_documento").next(".invalid-feedback").css("display", "none");
    $("#txt_email").next(".invalid-feedback").css("display", "none");
    $("#txt_celular").next(".invalid-feedback").css("display", "none");
    $("#txt_usuario").next(".invalid-feedback").css("display", "none");
    $("#txt_password").next(".invalid-feedback").css("display", "none");
    $("label[for=chk_terminos_condiciones]").next(".invalid-feedback").css("display", "none");
}

function registrar() {
    limpiar();

    var flgRegistrar = true;

    if ($.trim($("#txt_nombre").val()) == "") {
        $("#txt_nombre").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($.trim($("#txt_apellido").val()) == "") {
        $("#txt_apellido").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($.trim($("#txt_documento").val()) == "") {
        $("#txt_documento").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($.trim($("#txt_email").val()) == "") {
        $("#txt_email").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($.trim($("#txt_celular").val()) == "") {
        $("#txt_celular").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($.trim($("#txt_usuario").val()) == "") {
        $("#txt_usuario").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($.trim($("#txt_password").val()) == "") {
        $("#txt_password").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if ($("#chk_terminos_condiciones").is(":checked") == false) {
        $("label[for=chk_terminos_condiciones]").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if (flgRegistrar) {
        var objUsuarioBE = new Object();
        objUsuarioBE.objRolBE = new Object();
        objUsuarioBE.objRolBE.ID_ROL_IN = 2;
        objUsuarioBE.objTipoCuentaBE = new Object();
        objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN = 1;
        objUsuarioBE.LOG_USU_VC = $("#txt_usuario").val();
        objUsuarioBE.PAS_USU_VC = $("#txt_password").val();
        objUsuarioBE.NRO_DOC_VC = $("#txt_documento").val();
        objUsuarioBE.NOM_PER_VC = $("#txt_nombre").val();
        objUsuarioBE.APE_PER_VC = $("#txt_apellido").val();
        objUsuarioBE.COR_COR_VC = $("#txt_email").val();
        objUsuarioBE.TEL_PER_VC = $("#txt_telefono").val();
        objUsuarioBE.CEL_COR_VC = $("#txt_celular").val();

        $.ajax({
            url: ruta_actual + "Usuario/registrarVerificacion",
            data: JSON.stringify(objUsuarioBE),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result) {
                    Swal.fire(
                    {
                        title: "¡Registro Exitoso!",
                        text: "Registro de usuario realizado correctamente, por favor haga su verificación en su correo electrónnico.",
                        type: "success",
                        showCancelButton: true,
                        confirmButtonText: "¿Desea ir a la pagina de ingreso?"
                    }).then(function (result) {
                        if (result.value) {
                            window.location = "/Seguridad/IngresoSistema";
                        }
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