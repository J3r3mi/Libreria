using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Inventario_Libreria.Modelos
{
    internal class inventario_model
    {
        public int id_inventario { get; set; }
        public int id_libro { get; set; }
        public int stock_disponible { get; set; }
        public decimal precio { get; set; }
    }
}
