using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE_DYA;
using DA_DYA;

namespace BL_DYA
{
    public class BL_TIPO_CUENTA
    {
        private DA_TIPO_CUENTA objTipoCuentaDA = null;

        public BL_TIPO_CUENTA() {
            objTipoCuentaDA = new DA_TIPO_CUENTA();
        }

        public BE_COMBO listarRolCombo()
        {
            return objTipoCuentaDA.listarRolCombo();
        }
    }
}
