using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiCommon
{
   public  class Messages
    {
        public const string Success = "success.";
        public const string update = "update successfully.";
        public const string DeleteSuccess = "deleted successfully.";
        public const string Error = "Error during transaction";
        public const string ObjectExist = "{0} already exist.";
        public const string ObjectNotExist = "{0} not exist.";
        public const string NoDataFound = "No data found";
        public const string NoDataFoundInDb = "{0} No data found";
        public const string DataFound = "User login";
        public const string NotAllowed = "You are not allowed to update this record email already exists";
        public const string loginsucess = "Login successfully";
        public const string UnauthorizedUser = "Unauthorized user access";
        public const string UnauthorizedUser403 = "403 The invoker is not authorized to invoke the operation.";
        public const string UnauthorizedUser401 = "401 Unauthorized, Authorization required.";
        public const string UserNotFound = "Enter valid email and password";
        public const string NotExist = "User is not exists";
        public const string NoActive = "User is not active";
        public const string Novalidemail = "Email address is not valid";
        public const string EamilSend = "Password has send to your email";
        public const string OldPasswordIsWrong = "Old password is wrong";
        public const string SucessString = "Success";
        public const string invalid_grant = "Invalid grant";
        public const string GetSuccess = "Record get successfully";
        public const string requiredEmail = "Must required Email Address";
        public const string RecordSyncSuccessfully = "{0} Record sync successfully";
        public const string RecordnotSyncSuccessfully = "Record not sync successfully";
    }
}
