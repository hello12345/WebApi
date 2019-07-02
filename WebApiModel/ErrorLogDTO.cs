using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class ErrorLogDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for ErrorLogDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		public Int64 ID{get;set;}
		[Required]
		[Display(Name = "Application")]
		[StringLength(200)]
		public String Application{get;set;}
		[Required]
		[Display(Name = "Error Msg")]
		public String ErrorMsg{get;set;}
		[Required]
		[Display(Name = "Statck Trace")]
		public String StatckTrace{get;set;}
		[Required]
		[Display(Name = "Proc Name")]
		[StringLength(1000)]
		public String ProcName{get;set;}
		public Int64 CreatedBy{get;set;}
		[Required]
		public DateTime CreatedDate{get;set;}

        #endregion

	}
}
