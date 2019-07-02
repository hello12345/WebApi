using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBAL;
 
using WebApiModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Service_Sales_DetailsController : ControllerBase
    {

        // GET: api/ProfileMaster
        [HttpGet]
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result;
            using (Service_Sales_DetailsBAL Service_Sales_DetailsBAL = new Service_Sales_DetailsBAL())
            {
                result = await Service_Sales_DetailsBAL.GetAllAsync();
            }
            return result;
        }

        // GET: api/ProfileMaster/5
       [HttpGet("{id}")]
        public async Task<ResultPT> GetAsync(int id)
        {

            ResultPT result;
            using (Service_Sales_DetailsBAL Service_Sales_DetailsBAL = new Service_Sales_DetailsBAL())
            {
                result = await Service_Sales_DetailsBAL.GetByIDAsync(id);
            }
            return result;
        }

        // POST: api/ProfileMaster
        [HttpPost]
        public async Task<ResultPT> PostAsync([FromBody] List<Service_Sales_DetailsDTO> values)
        {
            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Service_Sales_DetailsBAL Service_Sales_DetailsBAL = new Service_Sales_DetailsBAL())
                {
                    foreach (var value in values)
                    {
                        result = await Service_Sales_DetailsBAL.InsertAsync(value);
                    }
                }
            }
            return result;
        }

        // PUT: api/ProfileMaster/5
        [HttpPut("{id}")]
        public async Task<ResultPT> PutAsync(int id, [FromBody] Service_Sales_DetailsDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Service_Sales_DetailsBAL Service_Sales_DetailsBAL = new Service_Sales_DetailsBAL())
                {
                    result = await Service_Sales_DetailsBAL.UpdateAsync(value);
                }
            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResultPT> DeleteAsync(int id)
        {
            ResultPT result;
            using (Service_Sales_DetailsBAL Service_Sales_DetailsBAL = new Service_Sales_DetailsBAL())
            {
                result = await Service_Sales_DetailsBAL.DeleteAsync(id);
            }
            return result;
        }
    }
}