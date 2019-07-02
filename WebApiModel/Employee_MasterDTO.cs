using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Employee_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Employee_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Emp_ Id")]
		public Int32 Emp_Id{get;set;}
		[Required]
		[Display(Name = "Emp_ Name")]
		[StringLength(255)]
		public String Emp_Name{get;set;}
		[Required]
		[Display(Name = "Emp_ Number")]
		[StringLength(20)]
		public String Emp_Number{get;set;}
		[Required]
		[Display(Name = "Emp_ Address")]
		[StringLength(500)]
		public String Emp_Address{get;set;}
		[Required]
		[Display(Name = "Emp_ Salary")]
		public Double Emp_Salary{get;set;}
		[Display(Name = "Field1")]
		[StringLength(255)]
		public String Field1{get;set;}
		[Display(Name = "Field2")]
		[StringLength(255)]
		public String Field2{get;set;}
		[Display(Name = "Field3")]
		[StringLength(255)]
		public String Field3{get;set;}
		[Display(Name = "Field4")]
		[StringLength(255)]
		public String Field4{get;set;}
		[Display(Name = "Field5")]
		[StringLength(255)]
		public String Field5{get;set;}
		[StringLength(50)]
		public String CreatedBy{get;set;}
		public DateTime CreatedDate{get;set;}
		[StringLength(50)]
		public String ModifiedBy{get;set;}
		public DateTime ModifiedDate{get;set;}
		[Display(Name = "Is Active")]
		public Boolean IsActive{get;set;}
		[Required]
		[Display(Name = "Profile_ Id")]
		public Int64 Profile_Id{get;set;}

        #endregion

	}
}
