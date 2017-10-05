using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Refactored.Models;

namespace Refactored.Controllers
{
    //public class ProductsOptionsController : ApiController
    //{
    //    private ProductsDatabaseEntities db = new ProductsDatabaseEntities();

    //    // GET: api/ProductsOptions
    //    public IQueryable<ProductOption> GetProductOptions()
    //    {
    //        return db.ProductOptions;
    //    }

    //    // GET: api/ProductsOptions/5
    //    [ResponseType(typeof(ProductOption))]
    //    public IHttpActionResult GetProductOption(Guid id)
    //    {
    //        ProductOption productOption = db.ProductOptions.Find(id);
    //        if (productOption == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(productOption);
    //    }


        


    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    private bool ProductOptionExists(Guid id)
    //    {
    //        return db.ProductOptions.Count(e => e.Id == id) > 0;
    //    }
    //}
}