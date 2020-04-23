$(document).ready(function () {
    if ($("#txt_usuario,#txt_password") == null) {
        alert("VAlidados");
    } else {
        $("#txt_usuario,#txt_password").keyup(function (e) {
            if (e.keyCode == 13)
                login();
        });

        $("#btn_login").click(login);
    }
});

function login() {
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
                window.location = "/Home/Inicio";
            } else {
                bootbox.alert(result.objResBE.Value);
            }
        },
        error: function (errormessage) {
            bootbox.alert(errormessage.responseText);
        }
    });
}