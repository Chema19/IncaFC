using IncaFC.Test.Models.Product;
using IncaFC.Test.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IncaFC.Test.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("v1/productapi")]
    public class ProductController : BaseApiController
    {
        [HttpGet]
        [Route("productslist")]
        public IHttpActionResult GetProducts()
        {
            try
            {
                ListProductViewModel vm = new ListProductViewModel();
                var result = vm.GetProducts(CargarDatosContext());
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("productsadd")]
        public IHttpActionResult AddProduct(ProductAddEditModel model)
        {
            try
            {
                AddEditProductViewModel vm = new AddEditProductViewModel();
                var result = vm.AddProduct(CargarDatosContext(), model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpPut]
        [Route("productedit/{id}")]
        public IHttpActionResult EditProduct(int id, ProductAddEditModel model)
        {
            try
            {
                AddEditProductViewModel vm = new AddEditProductViewModel();
                var result = vm.EditProduct(CargarDatosContext(), id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
        [HttpDelete]
        [Route("productdelete/{id}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                DeleteProductViewModel vm = new DeleteProductViewModel();
                var result = vm.DeleteProduct(CargarDatosContext(), id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
