using MANEJO_DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEGOCIO
{
    public class N_RECETA
    {
        MD_RECETA oMD = new MD_RECETA();
        public string insert_Receta(int cod_ver_rec, int cod_sku, string sku_descripcion, int alternativa,
                                    int cod_material, string material, decimal cantidad, string unidad, decimal precio_USD)
        {
            return oMD.insertReceta( cod_ver_rec,  cod_sku,  sku_descripcion,  alternativa,
                                     cod_material,  material,  cantidad,  unidad,  precio_USD);
        }
    }
}
