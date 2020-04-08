using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_DYA;
using Microsoft.ApplicationBlocks.Data;

namespace DA_DYA
{
    public class DA_MENU : DA_BASE
    {
        public List<BE_MENU> listarMenu(BE_USUARIO objUsuarioBE)
        {
            try
            {
                List<BE_MENU> lstMenuBE = new List<BE_MENU>();
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = new SqlParameter("@ID_ROL_IN", SqlDbType.Int);
                parametros[0].Value = objUsuarioBE.objRolBE.ID_ROL_IN;
                parametros[1] = new SqlParameter("@ID_TIP_CUE_IN", SqlDbType.Int);
                parametros[1].Value = objUsuarioBE.objTipoCuentaBE.ID_TIP_CUE_IN;

                sdr = SqlHelper.ExecuteReader(constr_dya, "SEGURIDAD.SP_MENU_LISTAR", parametros);

                BE_MENU objMenuBE = null;
                while (sdr.Read())
                {
                    objMenuBE = new BE_MENU();
                    objMenuBE.ID_MEN_IN = Convert.ToInt32(sdr["ID_MEN_IN"]);
                    objMenuBE.ID_NIV_IN = Convert.ToInt32(sdr["ID_NIV_IN"]);
                    objMenuBE.DES_IMA_VC = Convert.ToString(sdr["DES_IMA_VC"]);
                    objMenuBE.DES_URL_VC = Convert.ToString(sdr["DES_URL_VC"]);
                    objMenuBE.DES_NOM_VC = Convert.ToString(sdr["DES_NOM_VC"]);
                    objMenuBE.DES_TIT_VC = Convert.ToString(sdr["DES_TIT_VC"]);
                    objMenuBE.ID_PAD_IN = Convert.ToInt32(sdr["ID_PAD_IN"]);
                    objMenuBE.FLG_VIS_BO = Convert.ToBoolean(sdr["FLG_VIS_BO"]);

                    switch (objMenuBE.ID_NIV_IN) {
                        case 0:
                            lstMenuBE.Add(objMenuBE);
                            break;
                        case 1:
                            foreach (BE_MENU objMenuPadBE in lstMenuBE) {
                                if (objMenuPadBE.ID_MEN_IN == objMenuBE.ID_PAD_IN) {
                                    objMenuPadBE.lstMenuBE.Add(objMenuBE);
                                }
                            }
                            break;
                        case 2:
                            foreach (BE_MENU objMenuPadBE in lstMenuBE)
                            {
                                foreach (BE_MENU objMenuPad2BE in objMenuPadBE.lstMenuBE) {
                                    if (objMenuPad2BE.ID_MEN_IN == objMenuBE.ID_PAD_IN)
                                    {
                                        objMenuPad2BE.lstMenuBE.Add(objMenuBE);
                                    }
                                }
                            }
                            break;
                    }
                    
                }

                return lstMenuBE;
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
