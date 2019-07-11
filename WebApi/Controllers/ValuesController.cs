using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiBAL;
using WebApiModel;

namespace WebApiDAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ResultPT> GetAsync()
        {
            ResultPT result = new ResultPT();
            using (User_MasterBAL user_MasterBAL =new User_MasterBAL())
            {
                result =  await user_MasterBAL.GetAllAsync();
            }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
