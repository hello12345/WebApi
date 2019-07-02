using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCommon;

namespace WebApiModel
{
    public  class ResultPT
    {
        public object ReturnObject { get; set; } //= null;
        public Enums.ResultStatus TransactionStatus { get; set; }

        /// <summary>
        /// Result Message is the message use to disply the message on screen.
        /// If its a error then result status should be Error and ResultMsg is the error message to display on screen
        /// same way if the result status is success then ResultMsg should be the success message to display
        /// </summary>
        public string ResultMsg { get; set; }
    }
}
