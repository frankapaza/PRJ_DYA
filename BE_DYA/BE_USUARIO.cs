using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_DYA
{
    public class BE_USUARIO : BE_BASE
    {
        public BE_USUARIO() {
            objRolBE = new BE_ROL();
            objTipoCuentaBE = new BE_TIPO_CUENTA();
            objResBE = new KeyValuePair<int, string>();
        }

        public int ID_USU_IN { get; set; }
        public string ID_USU_IN_CRYPT { get; set; }
        public BE_ROL objRolBE { get; set; }
        public BE_TIPO_CUENTA objTipoCuentaBE { get; set; }
        public string PAS_USU_VC { get; set; }
        public string NRO_DOC_VC { get; set; }
        public string NOM_PER_VC { get; set; }
        public string APE_PER_VC { get; set; }
        public string COR_PER_VC { get; set; }
        public string COR_COR_VC { get; set; }
        public string TEL_PER_VC { get; set; }
        public string CEL_COR_VC { get; set; }
        public KeyValuePair<int, string> objResBE { get; set; }
    }
}
