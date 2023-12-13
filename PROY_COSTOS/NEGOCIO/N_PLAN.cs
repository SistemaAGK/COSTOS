using MANEJO_DATOS;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace NEGOCIO
{
    public class N_PLAN
    {
        MD_PLAN oMD = new MD_PLAN();
        public string insert_Plan(string anio, int periodo, int cod_ver, int cod_material, decimal material_USD)
        {
            return oMD.insertPlan(anio, periodo, cod_ver, cod_material, material_USD);
        }
        public DataTable bsc_Plan(string dato)
        {
            return oMD.bscPlan(dato);
        }
    }
}
