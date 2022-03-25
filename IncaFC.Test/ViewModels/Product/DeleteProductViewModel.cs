using IncaFC.Helpers;
using IncaFC.Test.Controllers;
using IncaFC.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace IncaFC.Test.ViewModels.Product
{
    public class DeleteProductViewModel
    {
        public CustomResultModel DeleteProduct(CargarDatosContext ctx, int? id)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    if (id.HasValue)
                    {
                        var producto = ctx.context.Producto.FirstOrDefault(x => x.ProductoId == id);
                        producto.Estado = ConstantHelpers.ESTADO.INACTIVO;
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