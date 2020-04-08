using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_DYA;
using Microsoft.ApplicationBlocks.Data;

namespace DA_DYA
{
    public class DA_TIPO_CUENTA : DA_BASE
    {
        public BE_COMBO listarRolCombo()
        {
            BE_COMBO objComboBE = new BE_COMBO();
            try
            {
                List<KeyValuePair<string, string>> lstDataBE = new List<KeyValuePair<string, string>>();
                sdr = SqlHelper.ExecuteReader(constr_dya, "SEGURIDAD.SP_TIPO_CUENTA_LISTAR_COMBO");
                lstDataBE.Add(new KeyValuePair<string, string>("-Seleccione-", "0"));
                while (sdr.Read())
                {
                    lstDataBE.Add(new KeyValuePair<string, string>(
                        Convert.ToString(sdr["DES_TIP_CUE_VC"]),
                        Convert.ToString(sdr["ID_TIP_CUE_IN"])
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
