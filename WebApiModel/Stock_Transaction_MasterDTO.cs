using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Stock_Transaction_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Stock_Transaction_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "St_ Trans_ Id")]
		public Int64 St_Trans_Id{get;set;}
		[Required]
		[Display(Name = "Product_ Id")]
		public Int32 Product_Id{get;set;}
		[Required]
		[Display(Name = "Trans_ Qty")]
		public Double Trans_Qty{get;set;}
		[Required]
		[Display(Name = "Trans_ Base_ Amount")]
		public Double Trans_Base_Amount{get;set;}
		[Required]
		[Display(Name = "Trans_ Total_ Amount")]
		public Double Trans_Total_Amount{get;set;}
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
