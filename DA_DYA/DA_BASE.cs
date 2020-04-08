using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_DYA
{
    public class DA_BASE
    {
        public string key_crypt = null;
        public string constr_dya = null;
        public SqlDataReader sdr=null;

        public DA_BASE()
        {
            key_crypt = ConfigurationManager.AppSettings["KEY_CRYPT"].ToString();
            constr_dya = ConfigurationManager.ConnectionStrings["CN_DYA"].ConnectionString;
        }
    }
}
