$(document).ready(function () {
    $("#txt_usuario,#txt_password").keyup(function (e) {
        if (e.keyCode == 13)
            login();
    });
    $("#btn_login").click(login);

    $("#txt_usuario").keypress(function () {
        $("#txt_usuario").next(".invalid-feedback").css("display", "none");
    });
    $("#txt_password").keypress(function () {
        $("#txt_password").next(".invalid-feedback").css("display", "none");
    });
});

function limpiar() {
    $("#txt_usuario").next(".invalid-feedback").css("display", "none");
    $("#txt_password").next(".invalid-feedback").css("display", "none");
}

function login() {
    limpiar();
    var flgRegistrar = true;

    if ($.trim($("#txt_usuario").val()) == "") {
        $("#txt_usuario").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }
    if ($.trim($("#txt_password").val()) == "") {
        $("#txt_password").next(".invalid-feedback").css("display", "block");
        flgRegistrar = false;
    }

    if (flgRegistrar) {
        var objUsuarioBE = new Object();
        objUsuarioBE.LOG_USU_VC = $("#txt_usuario").val();
        objUsuarioBE.PAS_USU_VC = $("#txt_password").val();

        $.ajax({
            url: ruta_actual + "Seguridad/login",
            data: JSON.stringify(objUsuarioBE),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log(result);
                if (result.objResBE.Key == 1) {
                    window.location = "/Dashboard/Demografico";
                } else {
                    bootbox.alert(result.objResBE.Value);
                }
            },
            error: function (errormessage) {
                bootbox.alert(errormessage.responseText);
            }
        });
    }
}
