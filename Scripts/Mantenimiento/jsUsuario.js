$(document).ready(function () {
    $("#btn_registrar").click(registrar);
    $("#btn_buscar").click(buscar);    
});

function registrar() {
    var objUsuarioBE = new Object();
    objUsuarioBE.ID_USU_IN = $("#txt_codigo_usuario").val();
    objUsuarioBE.objRolBE = new Object();
    objUsuarioBE.objRolBE.ID_ROL_IN = $("#slt_perfil").val();
    objUsuarioBE.objTipoCuentaBE = new Object();
    objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN = $("#slt_tipo_cuenta").val();
    objUsuarioBE.LOG_USU_VC = $("#txt_usuario").val();
    objUsuarioBE.PAS_USU_VC = $("#txt_password").val();
    objUsuarioBE.NRO_DOC_VC = $("#txt_documento").val();
    objUsuarioBE.NOM_PER_VC = $("#txt_nombre").val();
    objUsuarioBE.APE_PER_VC = $("#txt_apellidos").val();
    objUsuarioBE.COR_COR_VC = $("#txt_email_corporativa").val();
    objUsuarioBE.TEL_PER_VC = $("#txt_celular_personal").val();
    objUsuarioBE.CEL_COR_VC = $("#txt_celular_corporativo").val();

    $.ajax({
        url: ruta_actual + "Usuario/registrar",
        data: JSON.stringify(objUsuarioBE),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#bs-modal-usuario').modal('hide');
            if (result) {
                buscar();
                msj_satisfactorio("Registro de usuario realizado correctamente.");
            } else {
                msj_peligro("Ocurrio un error, volver a intentar nuevamente.");
            }
        },
        error: function (errormessage) {
            msj_error("Ocurrio un error, por favor contactar con soporte.");
        }
    });
}

function buscar() {
    $("#dt-tabla-lista").dataTable().fnClearTable();

    var objFiltroBE = new Object();
    objFiltroBE.LOG_USU_VC = $("#txt_buscar_usuario").val();
    objFiltroBE.NRO_DOC_VC = $("#txt_buscar_documento").val();
    objFiltroBE.NOM_PER_VC = $("#txt_buscar_nombres").val();
    objFiltroBE.APE_PER_VC = $("#txt_buscar_apellidos").val();
    objFiltroBE.COR_COR_VC = $("#txt_buscar_correo_corporativo").val();

    $.ajax({
        url: ruta_actual + "Usuario/listar",
        type: 'POST',
        cache: false,
        data: objFiltroBE,
        success: function (data) {
            if (data) {
                if (data.length > 0) {
                    var htmlOption = "";

                    $.each(data, function (i, obj) {
                        htmlOption = "<div class='demo'>" +
                            "<a href='javascript:void(0);' onclick='editar(" + JSON.stringify(obj) + ");' class='btn btn-warning btn-sm btn-icon waves-effect waves-themed' title='Editar' data-toggle='modal' data-target='.bs-modal-usuario'>" +
                                "<i class='fal fa-edit'></i>" +
                            "</a>" +
                            "<a href='javascript:void(0);' onclick='eliminar(" + JSON.stringify(obj) + ");' class='btn btn-danger btn-sm btn-icon waves-effect waves-themed' title='Eliminar'>" +
                                "<i class='fal fa-eraser'></i>" +
                            "</a>" +
                        "</div>";

                        $("#dt-tabla-lista").dataTable().fnAddData([
                            (i + 1),
                            obj.LOG_USU_VC,
                            obj.NRO_DOC_VC,
                            obj.NOM_PER_VC,
                            obj.APE_PER_VC,
                            obj.COR_COR_VC,
                            obj.TEL_PER_VC,
                            obj.CEL_COR_VC,
                            obj.DES_EST_VC,
                            obj.DES_UPD_VC,
                            obj.USU_CRE_VC,
                            obj.FEC_CRE_VC,
                            htmlOption
                        ]);
                    });
                }
            }
        }
    });
}

function editar(data) {
    $("#txt_codigo_usuario").val(data.ID_USU_IN);
    $("#txt_usuario").val(data.LOG_USU_VC);
    $("#txt_password").val(data.PAS_USU_VC);
    $("#txt_documento").val(data.NRO_DOC_VC);
    $("#txt_nombre").val(data.NOM_PER_VC);
    $("#txt_apellidos").val(data.APE_PER_VC);
    $("#txt_email_corporativa").val(data.COR_COR_VC);
    $("#txt_celular_personal").val(data.TEL_PER_VC);
    $("#txt_celular_corporativo").val(data.CEL_COR_VC);
    $("#slt_perfil").val(data.objRolBE.ID_ROL_IN);
    $("#slt_tipo_cuenta").val(data.objTipoCuentaBE.ID_TIP_CUE_IN);
}

function eliminar(data) {
    Swal.fire(
        {
            title: "CONFIRMACIÓN",
            text: "¿Est+a seguro que desea eliminar el registro?",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "¡Si, realizar la eliminación!"
        }).then(function (result) {
            if (result.value) {
                $.ajax({
                    url: ruta_actual + "Usuario/eliminar",
                    type: 'POST',
                    cache: false,
                    data: data,
                    success: function (data) {
                        if (data) {
                            buscar();
                            msj_satisfactorio("Registro de usuario eliminado correctamente.");
                        } else {
                            msj_peligro("Ocurrio un error, volver a intentar nuevamente.");
                        }
                    }, error: function (errormessage) {
                        msj_error("Ocurrio un error, por favor contactar con soporte.");
                    }
                });
            }
        }
    );
}