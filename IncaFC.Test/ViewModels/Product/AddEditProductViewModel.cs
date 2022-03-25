using IncaFC.DataAccess;
using IncaFC.Helpers;
using IncaFC.Test.Controllers;
using IncaFC.Test.Models;
using IncaFC.Test.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace IncaFC.Test.ViewModels.Product
{
    public class AddEditProductViewModel
    {
        public CustomResultModel AddProduct(CargarDatosContext ctx, ProductAddEditModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var product = new Producto();

                    ctx.context.Producto.Add(product);
                    product.Nombre = model.Nombre;
                    product.MarcaId = model.MarcaId;
                    product.CategoriaId = model.CategoriaId;
                    product.Precio = model.Precio;
                    product.UnidadMedidaId = model.UnidadMedidaId;
                    product.ProveedorId = model.ProveedorId;
                    ctx.context.SaveChanges();
                    ts.Complete();
                }
                ctx.response.Data = null;
                ctx.response.Error = false;
                ctx.response.Message = "OK";
                return ctx.response;
            }
            catch (Exception ex)
            {
                ctx.response.Data = null;
                ctx.response.Error = true;
                ctx.response.Message = ex.Message;
                return ctx.response;
            }
        }

        public CustomResultModel EditProduct(CargarDatosContext ctx, int? id, ProductAddEditModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var product = new Producto();
                    if (id.HasValue)
                    {
                        product = ctx.context.Producto.FirstOrDefault(x => x.ProductoId == id);

                        product.Nombre = model.Nombre;
                        product.MarcaId = model.MarcaId;
                        product.CategoriaId = model.CategoriaId;
                        product.Precio = model.Precio;
                        product.UnidadMedidaId = model.UnidadMedidaId;
                        product.ProveedorId = model.ProveedorId;
                        ctx.context.SaveChanges();
                    }

                    ts.Complete();

                }
                ctx.response.Data = null;
                ctx.response.Error = false;
                ctx.response.Message = "OK";
                return ctx.response;
            }
            catch (Exception ex)
            {
                ctx.response.Data = null;
                ctx.response.Error = true;
                ctx.response.Message = ex.Message;
                return ctx.response;
            }
        }
    }
}