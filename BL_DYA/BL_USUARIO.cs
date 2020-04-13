using BE_DYA;
using DA_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_DYA
{
    public class BL_USUARIO
    {
        private DA_USUARIO objUsuarioDA;
        public BL_USUARIO() {
            objUsuarioDA = new DA_USUARIO();
        }

        public bool registrar(BE_USUARIO objUsuarioBE)
        {
            bool resultado = false;
            try
            {
                resultado = objUsuarioDA.registrar(objUsuarioBE);
            }
            catch (Exception ex) {

            }
            return resultado;
        }

        public void login(BE_USUARIO objUsuarioBE)
        {
            objUsuarioDA.login(objUsuarioBE);
        }

        public void loguearsePorIdUsuario(BE_USUARIO objUsuarioBE)
        {
            objUsuarioDA.loguearsePorIdUsuario(objUsuarioBE);
        }
        
        public List<BE_USUARIO> listar(BE_FILTRO objFiltroBE)
        {
            return objUsuarioDA.listar(objFiltroBE);
        }

        public bool eliminar(BE_USUARIO objUsuarioBE)
        {
            bool resultado = false;
            try
            {
                resultado = objUsuarioDA.eliminar(objUsuarioBE);
            }
            catch (Exception ex)
            {

            }
            return resultado;
        }

        public bool registrarVerificacion(BE_USUARIO objUsuarioBE)
        {
            return objUsuarioDA.registrarVerificacion(objUsuarioBE);
        }

        public bool verificarCorreo(string p)
        {
            return objUsuarioDA.verificarCorreo(p);
        }
    }
}
