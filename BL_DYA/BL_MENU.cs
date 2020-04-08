using BE_DYA;
using DA_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_DYA
{
    public class BL_MENU
    {
        private DA_MENU objMenuDA = null;
        public BL_MENU() {
            objMenuDA = new DA_MENU();
        }

        public List<BE_MENU> listarMenu(BE_USUARIO objUsuarioBE)
        {
            return objMenuDA.listarMenu(objUsuarioBE);
        }
    }
}
