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
    public class UserMasterController : ControllerBase
    {
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result;
            using (User_MasterBAL User_MasterBAL = new User_MasterBAL())
            {
                result = await User_MasterBAL.GetAllAsync();
            }
            return result;
        }

        // GET: api/ProfileMaster/5
       [HttpGet("{id}")]
        public async Task<ResultPT> GetAsync(int id)
        {

            ResultPT result;
            using (User_MasterBAL User_MasterBAL = new User_MasterBAL())
            {
                result = await User_MasterBAL.GetByIDAsync(id);
            }
            return result;
        }

        // POST: api/ProfileMaster
        [HttpPost]
        public async Task<ResultPT> PostAsync([FromBody] User_MasterDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (User_MasterBAL User_MasterBAL = new User_MasterBAL())
                {
                    result = await User_MasterBAL.InsertAsync(value);
                }
            }
            return result;
        }

        // PUT: api/ProfileMaster/5
        [HttpPut("{id}")]
        public async Task<ResultPT> PutAsync(int id, [FromBody] User_MasterDTO value)
        {

            ResultPT result = null;
            if (ModelState.IsValid)
            {

                using (User_MasterBAL User_MasterBAL = new User_MasterBAL())
                {
                    result = await User_MasterBAL.UpdateAsync(value);
                }
            }
            return result;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ResultPT> DeleteAsync(int id)
        {
            ResultPT result;
            using (User_MasterBAL User_MasterBAL = new User_MasterBAL())
            {
                result = await User_MasterBAL.DeleteAsync(id);
            }
            return result;
        }
    }
}
