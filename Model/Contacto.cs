using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DYA
{
    public class Contacto
    {
        public Contacto(){
        }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }
        public string Sector { get; set; }
        public string Tema { get; set; }
        public string Cuerpo_Contenido { get; set; }
        public List<Contacto> lstContacto { get; set; }
    }
}
