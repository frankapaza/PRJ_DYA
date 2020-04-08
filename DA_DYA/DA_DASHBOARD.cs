using BE_DYA;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA_DYA
{
    public class DA_DASHBOARD : DA_BASE
    {
        public List<BE_DATO> DemograficoUbicacion()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_DEMOGRAFIA_UBICACION");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.ABR_DAT_VC = Convert.ToString(sdr["ABR_DEP_VC"]);
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_DEP_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_POB_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> DemograficoSexo()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_DEMOGRAFIA_SEXO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_SEX_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> AutomotorAnioFabricacion()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_AUTOMOTOR_ANIO_FABRICACION");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["ANIO_FAB_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> TelecomunicacionesMarketshare()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_TELECOMUNICACIONES_MARKETSHARE");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_OPE_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NU_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> MedicosGrado()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_MEDICOS_GRADO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_GRA_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    //objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NU_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> MedicosEspecialidad()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_MEDICOS_ESPECIALIDAD");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_ESP_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    //objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NU_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> MedicosEstado()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_MEDICOS_ESTADO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_EST_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    //objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NU_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> MedicosUbicacion()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_MEDICOS_UBICACION");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.ABR_DAT_VC = Convert.ToString(sdr["ABR_DEP_VC"]);
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_DEP_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> SoatSeguro()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_SOAT_SEGURO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["NOM_COM_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NUM_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> SoatTipoVehiculo()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_SOAT_TIPO_VEHICULO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_TIP_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NU_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> SoatVencimiento()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_SOAT_VENCIMIENTO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["FEC_VEN_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NUM_CAN_IN"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> SoatTipo()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_SOAT_TIPO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["NOM_TIP_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NUM_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> AutomotorUbicacion()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_AUTOMOTOR_UBICACION");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.ABR_DAT_VC = Convert.ToString(sdr["ABR_DEP_VC"]);
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["NOM_DEP_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NUM_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> AutomotorTipoVehiculo()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_AUTOMOTOR_TIPO_VEHICULO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["NOM_TIP_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["DEC_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> AutomotorTipoPersona()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_AUTOMOTOR_TIPO_PERSONA");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_TIP_PER_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NU_POR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> AutomotorMarca()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_AUTOMOTOR_MARCA");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["NOM_MAR_VC"]);
                    objDatoBE.NU_POR_DO = Convert.ToDecimal(sdr["NUM_PAR_DO"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> DemograficoEdad()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_DEMOGRAFIA_EDAD");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_RAN_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> EmpresaGiro()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_EMPRESAS_GIRO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_GIR_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> EmpresaTipo()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_EMPRESAS_TIPO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_TIP_RUC_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> EmpresaEstado()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_EMPRESAS_ESTADO");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_EST_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }

        public List<BE_DATO> EmpresaUbicacion()
        {
            try
            {
                List<BE_DATO> lstDatoBE = new List<BE_DATO>();

                sdr = SqlHelper.ExecuteReader(constr_dya, "DASHBOARD.SP_EMPRESAS_UBICACION");

                BE_DATO objDatoBE = null;
                while (sdr.Read())
                {
                    objDatoBE = new BE_DATO();
                    objDatoBE.ABR_DAT_VC = Convert.ToString(sdr["ABR_DEP_VC"]);
                    objDatoBE.DES_DAT_VC = Convert.ToString(sdr["DES_DEP_VC"]);
                    objDatoBE.NU_CAN_SI = Convert.ToInt32(sdr["NU_CAN_SI"]);
                    lstDatoBE.Add(objDatoBE);
                }

                return lstDatoBE;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null) { sdr.Close(); }
            }
        }
    }
}
