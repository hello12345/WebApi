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
    public class ProfileMasterController : ControllerBase
    {
        // GET: api/ProfileMaster
        [HttpGet]
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result;
            using (Profile_MasterBAL profile_MasterBAL = new Profile_MasterBAL()) {
                result=await profile_MasterBAL.GetAllAsync();
            }
            return result;
        }

        // GET: api/ProfileMaster/5
        [HttpGet("{id}")]
        public async Task<ResultPT> GetAsync(int id)
        {

            ResultPT result;
            using (Profile_MasterBAL profile_MasterBAL = new Profile_MasterBAL())
            {
                result = await profile_MasterBAL.GetByIDAsync(id);
            }
            return result;
        }

        // POST: api/ProfileMaster
        [HttpPost]
        public async Task<ResultPT> PostAsync([FromBody] Profile_MasterDTO value)
        {

            ResultPT result=null;
            if (ModelState.IsValid)
            {

                using (Profile_MasterBAL profile_MasterBAL = new Profile_MasterBAL())
                {
                    result = await profile_MasterBAL.InsertAsync(value);
                }
            }
            return result;
        }

        // PUT: api/ProfileMaster/5
        [HttpPut("{id}")]
        public async Task<ResultPT> PutAsync(int id, [FromBody] Profile_MasterDTO value)
        {

            ResultPT result = null;
                if (ModelState.IsValid)
                {

                    using (Profile_MasterBAL profile_MasterBAL = new Profile_MasterBAL())
                    {
                        result = await profile_MasterBAL.UpdateAsync(value);
                    }
            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResultPT> DeleteAsync(int id)
        {
            ResultPT result;
            using (Profile_MasterBAL profile_MasterBAL = new Profile_MasterBAL())
            {
                result = await profile_MasterBAL.DeleteAsync(id);
            }
            return result;
        }
    }
}
