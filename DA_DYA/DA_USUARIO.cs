using BE_DYA;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DA_DYA
{
    public class DA_USUARIO : DA_BASE
    {
        public void loguearsePorIdUsuario(BE_USUARIO objUsuarioBE)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@ID_USU_IN", SqlDbType.VarChar);
                parametros[0].Value = objUsuarioBE.ID_USU_IN;

                sdr = SqlHelper.ExecuteReader(constr_dya, "SEGURIDAD.SP_USUARIO_OBTENER_ID", parametros);

                if (sdr.Read())
                {
                    objUsuarioBE.ID_USU_IN = Convert.ToInt32(sdr["ID_USU_IN"]);
                    objUsuarioBE.objRolBE.ID_ROL_IN = Convert.ToInt32(sdr["ID_ROL_IN"]);
                    objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN = Convert.ToInt32(sdr["ID_TIP_CUE_IN"]);
                    objUsuarioBE.objRolBE.DES_ROL_VC = Convert.ToString(sdr["DES_ROL_VC"]);
                    objUsuarioBE.objTipoCuentaBE.DES_TIP_CUE_VC = Convert.ToString(sdr["DES_TIP_CUE_VC"]);
                    objUsuarioBE.LOG_USU_VC = Convert.ToString(sdr["LOG_USU_VC"]);
                    objUsuarioBE.objResBE = new KeyValuePair<int, string>(1, "Login realizado correctamente.");
                }
                else {
                    objUsuarioBE.objResBE = new KeyValuePair<int, string>(3, "Error, codigo no aceptado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public bool verificarCorreo(string p)
        {
            try
            {
                int ID_USUARIO = Convert.ToInt32(UTILITARIO.FUNCIONES.DecryptTripleDES(HttpUtility.UrlDecode(p),key_crypt));

                bool resultado = false;
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = new SqlParameter("@ID_USU_IN", SqlDbType.Int);
                parametros[0].Value = ID_USUARIO;

                int nuResultado = SqlHelper.ExecuteNonQuery(constr_dya, "SEGURIDAD.SP_USUARIO_VALIDAR_CORREO", parametros);

                if (nuResultado > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public void login(BE_USUARIO objUsuarioBE)
        {
            try
            {
                objUsuarioBE.PAS_USU_VC = UTILITARIO.FUNCIONES.EncryptTripleDES(objUsuarioBE.PAS_USU_VC, key_crypt);

                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@LOG_USU_VC", SqlDbType.VarChar);
                parametros[0].Value = objUsuarioBE.LOG_USU_VC;
                parametros[1] = new SqlParameter("@PAS_USU_VC", SqlDbType.VarChar);
                parametros[1].Value = objUsuarioBE.PAS_USU_VC;

                sdr = SqlHelper.ExecuteReader(constr_dya, "SEGURIDAD.SP_USUARIO_LOGIN", parametros);

                if (sdr.Read())
                {
                    objUsuarioBE.ID_USU_IN = Convert.ToInt32(sdr["ID_USU_IN"]);
                    objUsuarioBE.objRolBE.ID_ROL_IN = Convert.ToInt32(sdr["ID_ROL_IN"]);
                    objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN = Convert.ToInt32(sdr["ID_TIP_CUE_IN"]);
                    objUsuarioBE.objRolBE.DES_ROL_VC = Convert.ToString(sdr["DES_ROL_VC"]);
                    objUsuarioBE.objTipoCuentaBE.DES_TIP_CUE_VC = Convert.ToString(sdr["DES_TIP_CUE_VC"]);
                    objUsuarioBE.LOG_USU_VC = Convert.ToString(sdr["LOG_USU_VC"]);
                    objUsuarioBE.PAS_USU_VC = null;
                    objUsuarioBE.objResBE = new KeyValuePair<int, string>(1, "Login realizado correctamente.");
                }
                else
                {
                    objUsuarioBE.objResBE = new KeyValuePair<int, string>(2, 
                        "No se ha encontrado su cuenta de DyA debido a:<br/><br/>" +
                        "- Primero debe aceptar la verificación de su cuenta revisando en su correo<br/>electrónico afiliado para que el sistema valide su estadia.<br/><br/>" +
                        "- Ha introducido incorrectamente su nombre de usuario o contraseña.<br/>Volver a intentarlo.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public bool registrar(BE_USUARIO objUsuarioBE)
        {
            try
            {
                bool resultado = false;
                SqlParameter[] parametros = new SqlParameter[13];
                parametros[0] = new SqlParameter("@ID_USU_IN", SqlDbType.Int);
                parametros[0].Value = objUsuarioBE.ID_USU_IN;
                parametros[1] = new SqlParameter("@ID_ROL_IN", SqlDbType.Int);
                parametros[1].Value = objUsuarioBE.objRolBE.ID_ROL_IN;
                parametros[2] = new SqlParameter("@ID_TIP_CUE_IN", SqlDbType.Int);
                parametros[2].Value = objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN;
                parametros[3] = new SqlParameter("@LOG_USU_VC", SqlDbType.VarChar);
                parametros[3].Value = objUsuarioBE.LOG_USU_VC;
                parametros[4] = new SqlParameter("@PAS_USU_VC", SqlDbType.VarChar);
                parametros[4].Value = UTILITARIO.FUNCIONES.EncryptTripleDES(objUsuarioBE.PAS_USU_VC,key_crypt);
                parametros[5] = new SqlParameter("@NRO_DOC_VC", SqlDbType.VarChar);
                parametros[5].Value = objUsuarioBE.NRO_DOC_VC;
                parametros[6] = new SqlParameter("@NOM_PER_VC", SqlDbType.VarChar);
                parametros[6].Value = objUsuarioBE.NOM_PER_VC;
                parametros[7] = new SqlParameter("@APE_PER_VC", SqlDbType.VarChar);
                parametros[7].Value = objUsuarioBE.APE_PER_VC;
                parametros[8] = new SqlParameter("@COR_PER_VC", SqlDbType.VarChar);
                parametros[8].Value = objUsuarioBE.COR_PER_VC;
                parametros[9] = new SqlParameter("@COR_COR_VC", SqlDbType.VarChar);
                parametros[9].Value = objUsuarioBE.COR_COR_VC;
                parametros[10] = new SqlParameter("@TEL_PER_VC", SqlDbType.VarChar);
                parametros[10].Value = objUsuarioBE.TEL_PER_VC;
                parametros[11] = new SqlParameter("@CEL_COR_VC", SqlDbType.VarChar);
                parametros[11].Value = objUsuarioBE.CEL_COR_VC;
                parametros[12] = new SqlParameter("@USU_CRE_IN", SqlDbType.Int);
                parametros[12].Value = objUsuarioBE.USU_CRE_IN;

                int nuResultado = SqlHelper.ExecuteNonQuery(constr_dya, "SEGURIDAD.SP_USUARIO_REGISTRAR", parametros);

                if (nuResultado > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public bool registrarVerificacion(BE_USUARIO objUsuarioBE)
        {
            try
            {
                bool resultado = false;
                SqlParameter[] parametros = new SqlParameter[13];
                parametros[0] = new SqlParameter("@ID_USU_IN", SqlDbType.Int);
                parametros[0].Direction = ParameterDirection.InputOutput;
                parametros[0].Value = objUsuarioBE.ID_USU_IN;
                parametros[1] = new SqlParameter("@ID_ROL_IN", SqlDbType.Int);
                parametros[1].Value = objUsuarioBE.objRolBE.ID_ROL_IN;
                parametros[2] = new SqlParameter("@ID_TIP_CUE_IN", SqlDbType.Int);
                parametros[2].Value = objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN;
                parametros[3] = new SqlParameter("@LOG_USU_VC", SqlDbType.VarChar);
                parametros[3].Value = objUsuarioBE.LOG_USU_VC;
                parametros[4] = new SqlParameter("@PAS_USU_VC", SqlDbType.VarChar);
                parametros[4].Value = UTILITARIO.FUNCIONES.EncryptTripleDES(objUsuarioBE.PAS_USU_VC, key_crypt);
                parametros[5] = new SqlParameter("@NRO_DOC_VC", SqlDbType.VarChar);
                parametros[5].Value = objUsuarioBE.NRO_DOC_VC;
                parametros[6] = new SqlParameter("@NOM_PER_VC", SqlDbType.VarChar);
                parametros[6].Value = objUsuarioBE.NOM_PER_VC;
                parametros[7] = new SqlParameter("@APE_PER_VC", SqlDbType.VarChar);
                parametros[7].Value = objUsuarioBE.APE_PER_VC;
                parametros[8] = new SqlParameter("@COR_PER_VC", SqlDbType.VarChar);
                parametros[8].Value = objUsuarioBE.COR_PER_VC;
                parametros[9] = new SqlParameter("@COR_COR_VC", SqlDbType.VarChar);
                parametros[9].Value = objUsuarioBE.COR_COR_VC;
                parametros[10] = new SqlParameter("@TEL_PER_VC", SqlDbType.VarChar);
                parametros[10].Value = objUsuarioBE.TEL_PER_VC;
                parametros[11] = new SqlParameter("@CEL_COR_VC", SqlDbType.VarChar);
                parametros[11].Value = objUsuarioBE.CEL_COR_VC;
                parametros[12] = new SqlParameter("@USU_CRE_IN", SqlDbType.Int);
                parametros[12].Value = objUsuarioBE.USU_CRE_IN;

                int nuResultado = SqlHelper.ExecuteNonQuery(constr_dya,
                    CommandType.StoredProcedure, 
                    "SEGURIDAD.SP_USUARIO_REGISTRAR_VERIFICACION", 
                    parametros);

                if (nuResultado > 0)
                {
                    objUsuarioBE.ID_USU_IN = Convert.ToInt32(parametros[0].Value);
                    objUsuarioBE.ID_USU_IN_CRYPT = HttpUtility.UrlEncode(UTILITARIO.FUNCIONES.EncryptTripleDES(
                        Convert.ToString(objUsuarioBE.ID_USU_IN), key_crypt));
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public bool eliminar(BE_USUARIO objUsuarioBE)
        {
            try
            {
                bool resultado = false;
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@ID_USU_IN", SqlDbType.Int);
                parametros[0].Value = objUsuarioBE.ID_USU_IN;
                parametros[1] = new SqlParameter("@USU_UPD_IN", SqlDbType.Int);
                parametros[1].Value = objUsuarioBE.USU_UPD_IN;

                int nuResultado = SqlHelper.ExecuteNonQuery(constr_dya, "SEGURIDAD.SP_USUARIO_ELIMINAR", parametros);

                if (nuResultado > 0)
                {
                    resultado = true;
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_USUARIO> listar(BE_FILTRO objFiltroBE)
        {
            try
            {
                List<BE_USUARIO> lstUsuarioBE = new List<BE_USUARIO>();
                SqlParameter[] parametros = new SqlParameter[5];
                parametros[0] = new SqlParameter("@LOG_USU_VC", SqlDbType.VarChar);
                parametros[0].Value = objFiltroBE.LOG_USU_VC;
                parametros[1] = new SqlParameter("@NRO_DOC_VC", SqlDbType.VarChar);
                parametros[1].Value = objFiltroBE.NRO_DOC_VC;
                parametros[2] = new SqlParameter("@NOM_PER_VC", SqlDbType.VarChar);
                parametros[2].Value = objFiltroBE.NOM_PER_VC;
                parametros[3] = new SqlParameter("@APE_PER_VC", SqlDbType.VarChar);
                parametros[3].Value = objFiltroBE.APE_PER_VC;
                parametros[4] = new SqlParameter("@COR_COR_VC", SqlDbType.VarChar);
                parametros[4].Value = objFiltroBE.COR_COR_VC;

                sdr = SqlHelper.ExecuteReader(constr_dya, "SEGURIDAD.SP_USUARIO_LISTAR", parametros);

                BE_USUARIO objUsuarioBE = null;
                while (sdr.Read())
                {
                    objUsuarioBE = new BE_USUARIO();
                    objUsuarioBE.ID_USU_IN = Convert.ToInt32(sdr["ID_USU_IN"]);
                    objUsuarioBE.LOG_USU_VC = Convert.ToString(sdr["LOG_USU_VC"]);
                    objUsuarioBE.PAS_USU_VC = UTILITARIO.FUNCIONES.DecryptTripleDES(Convert.ToString(sdr["PAS_USU_VC"]),key_crypt);
                    objUsuarioBE.NRO_DOC_VC = Convert.ToString(sdr["NRO_DOC_VC"]);
                    objUsuarioBE.NOM_PER_VC = Convert.ToString(sdr["NOM_PER_VC"]);
                    objUsuarioBE.APE_PER_VC = Convert.ToString(sdr["APE_PER_VC"]);
                    objUsuarioBE.COR_COR_VC = Convert.ToString(sdr["COR_COR_VC"]);
                    objUsuarioBE.TEL_PER_VC = Convert.ToString(sdr["TEL_PER_VC"]);
                    objUsuarioBE.CEL_COR_VC = Convert.ToString(sdr["CEL_COR_VC"]);
                    objUsuarioBE.objRolBE.ID_ROL_IN   = Convert.ToInt32(sdr["ID_ROL_IN"]);
                    objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN = Convert.ToInt32(sdr["ID_TIP_CUE_IN"]);
                    objUsuarioBE.FLG_EST_BO = Convert.ToBoolean(sdr["FLG_EST_BO"]);
                    objUsuarioBE.DES_EST_VC = Convert.ToString(sdr["DES_EST_VC"]);
                    objUsuarioBE.DES_UPD_VC = Convert.ToString(sdr["DES_UPD_VC"]);
                    objUsuarioBE.USU_CRE_VC = Convert.ToString(sdr["USU_CRE_VC"]);
                    objUsuarioBE.FEC_CRE_VC = Convert.ToString(sdr["FEC_CRE_VC"]);
                    lstUsuarioBE.Add(objUsuarioBE);
                }

                return lstUsuarioBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }
    }
}
