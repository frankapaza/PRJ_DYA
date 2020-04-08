using BE_DYA;
using DA_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_DYA
{
    public class BL_ROL
    {
        private DA_ROL objRolDA = null;

        public BL_ROL() {
            objRolDA = new DA_ROL();
        }


        public BE_COMBO listarRolCombo()
        {
            return objRolDA.listarRolCombo();
        }
    }
}
