using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncaFC.Test.Models.Product
{
    public class ProductListModel
    {
        public int? ProductoId { set; get; }
        public string Nombre { set; get; }
        public string Marca { set; get; }
        public string Categoria { set; get; }
        public decimal Precio { set; get; }
        public string UnidadMedida { set; get; }
        public string Proveedor { set; get; }
    }
}