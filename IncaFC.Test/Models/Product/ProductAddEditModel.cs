using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncaFC.Test.Models.Product
{
    public class ProductAddEditModel
    {
        public string Nombre { set; get; }
        public int MarcaId { set; get; }
        public int CategoriaId { set; get; }
        public decimal Precio { set; get; }
        public int UnidadMedidaId { set; get; }
        public int ProveedorId { set; get; }
    }
}