using BE_DYA;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_DYA
{
    public class DA_ROL : DA_BASE
    {
        public BE_COMBO listarRolCombo()
        {
            BE_COMBO objComboBE = new BE_COMBO();
            try
            {
                List<KeyValuePair<string, string>> lstDataBE = new List<KeyValuePair<string, string>>();
                sdr = SqlHelper.ExecuteReader(constr_dya, "SEGURIDAD.SP_ROL_LISTAR_COMBO");
                lstDataBE.Add(new KeyValuePair<string, string>("-Seleccione-", "0"));
                while (sdr.Read())
                {
                    lstDataBE.Add(new KeyValuePair<string, string>(
                        Convert.ToString(sdr["DES_ROL_VC"]),
                        Convert.ToString(sdr["ID_ROL_IN"])
                        )
                    );
                }
                objComboBE.lstDataBE = lstDataBE;
                objComboBE.dataSelect = "0";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
            return objComboBE;
        }
    }
}
