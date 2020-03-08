function msj_satisfactorio(mensaje){
    Swal.fire("SATISFACTORIO", mensaje,  "success");
}

function msj_peligro(mensaje) {
    Swal.fire("PELIGRO", mensaje, "warning");
}

function msj_error(mensaje) {
    Swal.fire("ERROR", mensaje, "error");
}