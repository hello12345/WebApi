using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiModel;

namespace WebApiBAL
{
    public class Login
    {
        public async Task<User_MasterDTO> GetAccess(string username,string password)
        {
            User_MasterDTO User_MasterDTO = null;
            using(User_MasterBAL user_Master =new User_MasterBAL())
            {
                WebApiHelper.Crypt common = new WebApiHelper.Crypt();
                //var encpassword=common.EncryptText(password, "password");
                var reuslt=await user_Master.LogIN(username, password);
                if (reuslt.TransactionStatus == WebApiCommon.Enums.ResultStatus.Success)
                {
                     User_MasterDTO =(User_MasterDTO) reuslt.ReturnObject;
                }
            }
            return User_MasterDTO;
        }
    }
}
