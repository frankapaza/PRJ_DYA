using BE_DYA;
using DA_DYA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_DYA
{
    public class BL_DASHBOARD
    {
        private DA_DASHBOARD objDashboardDA = null;
        public BL_DASHBOARD() {
            objDashboardDA = new DA_DASHBOARD();
        }

        public List<BE_DATO> DemograficoUbicacion()
        {
            return objDashboardDA.DemograficoUbicacion();
        }

        public List<BE_DATO> DemograficoSexo()
        {
            return objDashboardDA.DemograficoSexo();
        }

        public List<BE_DATO> DemograficoEdad()
        {
            return objDashboardDA.DemograficoEdad();
        }

        public List<BE_DATO> EmpresaUbicacion()
        {
            return objDashboardDA.EmpresaUbicacion();
        }

        public List<BE_DATO> EmpresaEstado()
        {
            return objDashboardDA.EmpresaEstado();
        }

        public List<BE_DATO> EmpresaTipo()
        {
            return objDashboardDA.EmpresaTipo();
        }

        public List<BE_DATO> EmpresaGiro()
        {
            return objDashboardDA.EmpresaGiro();
        }

        public List<BE_DATO> AutomotorAnioFabricacion()
        {
            return objDashboardDA.AutomotorAnioFabricacion();
        }

        public List<BE_DATO> AutomotorMarca()
        {
            return objDashboardDA.AutomotorMarca();
        }

        public List<BE_DATO> AutomotorTipoPersona()
        {
            return objDashboardDA.AutomotorTipoPersona();
        }

        public List<BE_DATO> AutomotorTipoVehiculo()
        {
            return objDashboardDA.AutomotorTipoVehiculo();
        }

        public List<BE_DATO> AutomotorUbicacion()
        {
            return objDashboardDA.AutomotorUbicacion();
        }

        public List<BE_DATO> SoatTipo()
        {
            return objDashboardDA.SoatTipo();
        }

        public List<BE_DATO> SoatTipoVehiculo()
        {
            return objDashboardDA.SoatTipoVehiculo();
        }

        public List<BE_DATO> SoatVencimiento()
        {
            return objDashboardDA.SoatVencimiento();
        }

        public List<BE_DATO> SoatSeguro()
        {
            return objDashboardDA.SoatSeguro();
        }

        public List<BE_DATO> MedicosUbicacion()
        {
            return objDashboardDA.MedicosUbicacion();
        }

        public List<BE_DATO> MedicosEstado()
        {
            return objDashboardDA.MedicosEstado();
        }

        public List<BE_DATO> MedicosEspecialidad()
        {
            return objDashboardDA.MedicosEspecialidad();
        }

        public List<BE_DATO> MedicosGrado()
        {
            return objDashboardDA.MedicosGrado();
        }

        public List<BE_DATO> TelecomunicacionesMarketshare()
        {
            return objDashboardDA.TelecomunicacionesMarketshare();
        }
    }
}
