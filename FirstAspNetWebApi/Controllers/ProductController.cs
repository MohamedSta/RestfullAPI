using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StoneChallenge.Models;

namespace StoneChallenge.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductContext _repository = new ProductContext();

        // GET api/product
        public IEnumerable<Product> Get()
        {
            return _repository.GetProducts();
        }

        // GET api/product/{id}
        public Product Get(int id)
        {
            Product product = _repository.GetProduct(id);

            if (product == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }
            else
            {
                return product;
            }
        }

        // POST api/product  
        public HttpResponseMessage Post(Product product)
        {
            if (ModelState.IsValid)
            {
                // Setting the ID for the Instance
                product = _repository.AddProduct(product);

                var response = Request.CreateResponse(HttpStatusCode.Created, product);

                string uri = Url.Link("DefaultApi", new {id = product.Id});
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/product/{id}
        public HttpResponseMessage Put(int id, Product product)
        {
            if (ModelState.IsValid && id == product.Id)
            {
                var result = _repository.Update(id, product);
                if (result == false)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/product/{id}
        public HttpResponseMessage Delete(int id)
        {
            Product product = _repository.GetProduct(id);

            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                _repository.Delete(id);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}