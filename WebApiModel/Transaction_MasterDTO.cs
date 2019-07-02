using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Transaction_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Transaction_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Trans_ Id")]
		public Int64 Trans_Id{get;set;}
		[Required]
		[Display(Name = "Trans_ Type")]
		public Int32 Trans_Type{get;set;}
		[Required]
		[Display(Name = "Customer_ Id")]
		public Int32 Customer_Id{get;set;}
		[Required]
		[Display(Name = "Trans_ Amount")]
		public Double Trans_Amount{get;set;}
		[Required]
		[Display(Name = "Unique_ Id")]
		public Int64 Unique_Id{get;set;}
		[Required]
		[Display(Name = "Unique_ For")]
		[StringLength(50)]
		public String Unique_For{get;set;}
		[StringLength(50)]
		public String CreatedBy{get;set;}
		public DateTime CreatedDate{get;set;}
		[StringLength(50)]
		public String ModifiedBy{get;set;}
		public DateTime ModifiedDate{get;set;}
		[Required]
		[Display(Name = "Profile_ Id")]
		public Int64 Profile_Id{get;set;}

        #endregion

	}
}
