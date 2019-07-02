using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class User_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for User_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "User_ Id")]
		public Int32 User_Id{get;set;}
		[Required]
		[Display(Name = "User_ Name")]
		[StringLength(50)]
		public String User_Name{get;set;}
		[Required]
		[Display(Name = "Password")]
		[StringLength(50)]
		public String Password{get;set;}
		[Required]
		[Display(Name = "Emp_ Id")]
		public Int32 Emp_Id{get;set;}
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
		public DateTime CreatedDate{get;set;}
		[StringLength(50)]
		public String CreatedBy{get;set;}
		public DateTime ModifiedDate{get;set;}
		[StringLength(50)]
		public String ModifiedBy{get;set;}
		[Display(Name = "Is Active")]
		public Boolean IsActive{get;set;}
		[Required]
		[Display(Name = "Profile_ Id")]
		public Int64 Profile_Id{get;set;}

        public string token { get; set; }
        #endregion

	}
}
