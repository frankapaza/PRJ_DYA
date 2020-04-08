using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_DYA
{
    public class BE_MENU
    {
        public BE_MENU(){
            lstMenuBE = new List<BE_MENU>();
        }
        public int ID_MEN_IN { get; set; }
        public int ID_NIV_IN { get; set; }
        public string DES_IMA_VC { get; set; }
        public string DES_URL_VC { get; set; }
        public string DES_NOM_VC { get; set; }
        public string DES_TIT_VC { get; set; }
        public int ID_PAD_IN { get; set; }
        public bool FLG_VIS_BO { get; set; }
        public List<BE_MENU> lstMenuBE { get; set; }
    }
}
