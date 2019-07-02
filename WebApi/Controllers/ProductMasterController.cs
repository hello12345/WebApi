using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiModel;
using WebApiBAL;
 

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        // GET: api/ProfileMaster
        [HttpGet]
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result;
            using (Product_MasterBAL Product_MasterBAL = new Product_MasterBAL())
            {
                result = await Product_MasterBAL.GetAllAsync();
            }
            return result;
        }

        // GET: api/ProfileMaster/5
        [HttpGet("{id}")]
        public async Task<ResultPT> GetAsync(int id)
        {

            ResultPT result;
            using (Product_MasterBAL Product_MasterBAL = new Product_MasterBAL())
            {
                result = await Product_MasterBAL.GetByIDAsync(id);
            }
            return result;
        }

        // POST: api/ProfileMaster
        [HttpPost]
        public async Task<ResultPT> PostAsync([FromBody] Product_MasterDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Product_MasterBAL Product_MasterBAL = new Product_MasterBAL())
                {
                    result = await Product_MasterBAL.InsertAsync(value);
                }
            }
            return result;
        }

        // PUT: api/ProfileMaster/5
        [HttpPut("{id}")]
        public async Task<ResultPT> PutAsync(int id, [FromBody] Product_MasterDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Product_MasterBAL Product_MasterBAL = new Product_MasterBAL())
                {
                    result = await Product_MasterBAL.UpdateAsync(value);
                }
            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResultPT> DeleteAsync(int id)
        {
            ResultPT result;
            using (Product_MasterBAL Product_MasterBAL = new Product_MasterBAL())
            {
                result = await Product_MasterBAL.DeleteAsync(id);
            }
            return result;
        }
    }
}