using IncaFC.DataAccess;
using IncaFC.Helpers;
using IncaFC.Test.Controllers;
using IncaFC.Test.Models;
using IncaFC.Test.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncaFC.Test.ViewModels.Product
{
    public class ListProductViewModel
    {
        public CustomResultModel GetProducts(CargarDatosContext ctx)
        {
            var query = ctx.context.Producto.Where(x=>x.Estado == ConstantHelpers.ESTADO.ACTIVO)
                .Select(x=>new ProductListModel() { 
                    ProductoId = x.ProductoId,
                    Nombre = x.Nombre,
                    Marca = x.Marca.Nombre,
                    Categoria = x.Categoria.Nombre,
                    Precio = x.Precio,
                    UnidadMedida = x.UnidadMedida.Nombre,
                    Proveedor = x.Proveedor.Nombres + " " + x.Proveedor.Apellidos
                }).ToList();

            ctx.response.Data = query;
            ctx.response.Error = false;
            ctx.response.Message = "OK";

            return ctx.response;
        }
    }
}