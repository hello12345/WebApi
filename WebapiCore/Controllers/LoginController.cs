using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBAL;
using WebApiModel;
using WebapiCore.Services;
using WebApiCommon;
using Newtonsoft.Json.Linq;

namespace WebapiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class LoginController : ControllerBase
    {
        private IUserService _userService;
      
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [AllowAnonymous]
        
        public ResultPT Post([FromBody]LoginDTO logindetails)
        {

            ResultPT result = new ResultPT();
            var user = _userService.AuthenticateAsync(logindetails.UserName, logindetails.Passwrod);
            if (user == null)
            {
                result.TransactionStatus = Enums.ResultStatus.Failure;
                result.ReturnObject = null;
                result.ResultMsg = Messages.invalid_grant;
            }
            else
            {
                result.ReturnObject = user;
                result.ResultMsg = Messages.Success;
                result.TransactionStatus = Enums.ResultStatus.Success;
            }


            return result;
        }
        [AllowAnonymous]
        public string getall()
        {
            return "test";
        }
    }
}