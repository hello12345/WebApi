using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiModel;
using WebApiBAL;
 

namespace WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sms_Template_MasterController : ControllerBase
    {
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result;
            using (Sms_Template_MasterBAL Sms_Template_MasterBAL = new Sms_Template_MasterBAL())
            {
                result = await Sms_Template_MasterBAL.GetAllAsync();
            }
            return result;
        }

        // GET: api/ProfileMaster/5
       [HttpGet("{id}")]
        public async Task<ResultPT> GetAsync(int id)
        {

            ResultPT result;
            using (Sms_Template_MasterBAL Sms_Template_MasterBAL = new Sms_Template_MasterBAL())
            {
                result = await Sms_Template_MasterBAL.GetByIDAsync(id);
            }
            return result;
        }

        // POST: api/ProfileMaster
        [HttpPost]
        public async Task<ResultPT> PostAsync([FromBody] Sms_Template_MasterDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Sms_Template_MasterBAL Sms_Template_MasterBAL = new Sms_Template_MasterBAL())
                {
                    result = await Sms_Template_MasterBAL.InsertAsync(value);
                }
            }
            return result;
        }

        // PUT: api/ProfileMaster/5
        [HttpPut("{id}")]
        public async Task<ResultPT> PutAsync(int id, [FromBody] Sms_Template_MasterDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (Sms_Template_MasterBAL Sms_Template_MasterBAL = new Sms_Template_MasterBAL())
                {
                    result = await Sms_Template_MasterBAL.UpdateAsync(value);
                }
            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResultPT> DeleteAsync(int id)
        {
            ResultPT result;
            using (Sms_Template_MasterBAL Sms_Template_MasterBAL = new Sms_Template_MasterBAL())
            {
                result = await Sms_Template_MasterBAL.DeleteAsync(id);
            }
            return result;
        }
    }
}