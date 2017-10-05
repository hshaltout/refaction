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
    public class ProductsController : ApiController
    {
        private ProductsDatabaseEntities db = new ProductsDatabaseEntities();

        // GET: api/Products
        [ActionName("Products")]
        [HttpGet]
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ActionName("ProductsID")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(Guid id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products?name=samsung
        [ActionName("ProductsName")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProductName(string name)
        {
            //Product product = db.Products.FirstOrDefault((p) => p.Name == name);
            var list = from g in db.Products where g.Name == name select g;

            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // GET: api/Products/5/Options
        [ActionName("Options")]
        [HttpGet]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult GetProductOptions(Guid id)
        {
            //ProductOption productOption = db.ProductOptions.FirstOrDefault((p) => p.ProductId == id);
            var list = from g in db.ProductOptions where g.ProductId == id select g;

            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }

        // GET: api/Products/5/Options/6
        [ActionName("OptionsID")]
        [HttpGet]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult GetProductOptionsID(Guid id, Guid optionid)
        {
            ProductOption productOption = db.ProductOptions.FirstOrDefault((p) => p.Id == optionid && p.ProductId == id);
            if (productOption == null)
            {
                return NotFound();
            }
            return Ok(productOption);
        }
        //}

        // PUT: api/Products/5
        [ActionName("UpdateProduct")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(Guid id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ActionName("AddProduct")]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductExists(product.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ActionName("DeleteProduct")]
        [HttpDelete]
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(Guid id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        // POST: api/ProductsOptions
        [ActionName("AddOption")]
        [HttpPost]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult PostProductOption(Guid id, ProductOption productOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.ProductOptions.Add(productOption);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductOptionExists(productOption.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productOption.Id }, productOption);
        }

        // PUT: api/ProductsOptions/5
        [ActionName("UpdateOption")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductOption(Guid productid, Guid optionid, ProductOption productOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product product = db.Products.Find(productid);
            if (product == null)
            {
                return NotFound();
            }

            if (optionid != productOption.Id)
            {
                return BadRequest();
            }

            db.Entry(productOption).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductOptionExists(optionid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/ProductsOptions/5
        [ActionName("DeleteOptionID")]
        [HttpDelete]
        [ResponseType(typeof(ProductOption))]
        public IHttpActionResult DeleteProductOption(Guid productid,Guid optionid)
        {
            Product product = db.Products.Find(productid);
            if (product == null)
            {
                return NotFound();
            }

            var list = from g in db.ProductOptions where g.ProductId == productid && g.Id == optionid select g ;
            if (list == null)
            {
                return NotFound();
            }

            foreach (var lproductOption in list)
            {
                db.ProductOptions.Remove(lproductOption);
                db.SaveChanges();
            }            
            
            return Ok(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(Guid id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }

        private bool ProductOptionExists(Guid id)
        {
            return db.ProductOptions.Count(e => e.Id == id) > 0;
        }
    }
}