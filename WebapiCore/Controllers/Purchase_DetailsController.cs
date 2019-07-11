using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBAL;
using WebApiModel;

namespace WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Purchase_DetailsController : ControllerBase
    {
        // GET: api/ProfileMaster
        [HttpGet]
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result;
            using (Purchase_DetailsBAL Purchase_DetailsBAL = new Purchase_DetailsBAL())
            {
                result = await Purchase_DetailsBAL.GetAllAsync();
            }
            return result;
        }

        // GET: api/ProfileMaster/5
       [HttpGet("{id}")]
        public async Task<ResultPT> GetAsync(int id)
        {

            ResultPT result;
            using (Purchase_DetailsBAL Purchase_DetailsBAL = new Purchase_DetailsBAL())
            {
                result = await Purchase_DetailsBAL.GetByIDAsync(id);
            }
            return result;
        }

        // POST: api/ProfileMaster
        [HttpPost]
        public async Task<ResultPT> PostAsync([FromBody] List<Purchase_DetailsDTO> values)
        {
            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Purchase_DetailsBAL Purchase_DetailsBAL = new Purchase_DetailsBAL())
                {
                    foreach (var value in values)
                    {
                        result = await Purchase_DetailsBAL.InsertAsync(value);
                    }
                }
            }
            return result;
        }

        // PUT: api/ProfileMaster/5
        [HttpPut("{id}")]
        public async Task<ResultPT> PutAsync(int id, [FromBody] Purchase_DetailsDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Purchase_DetailsBAL Purchase_DetailsBAL = new Purchase_DetailsBAL())
                {
                    result = await Purchase_DetailsBAL.UpdateAsync(value);
                }
            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResultPT> DeleteAsync(int id)
        {
            ResultPT result;
            using (Purchase_DetailsBAL Purchase_DetailsBAL = new Purchase_DetailsBAL())
            {
                result = await Purchase_DetailsBAL.DeleteAsync(id);
            }
            return result;
        }
    }
}