using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class EmployeesDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for EmployeesDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		public Int32 ID{get;set;}
		[Display(Name = "Name")]
		public String Name{get;set;}
		[Display(Name = "Gender")]
		public String Gender{get;set;}
		[Display(Name = "Salary")]
		public String Salary{get;set;}

        #endregion

	}
}
