using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Purchase_DetailsDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Purchase_DetailsDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Purchase_ Details_ Id")]
		public Int64 Purchase_Details_Id{get;set;}
		[Required]
		[Display(Name = "Purchase_ Id")]
		public Int32 Purchase_Id{get;set;}
		[Required]
		[Display(Name = "Product_ Id")]
		public Int32 Product_Id{get;set;}
		[Required]
		[Display(Name = "Qty")]
		public Double Qty{get;set;}
		[Required]
		[Display(Name = "Amount")]
		public Double Amount{get;set;}
		[Required]
		[Display(Name = "C G S T_ Per")]
		public Double CGST_Per{get;set;}
		[Display(Name = "C G S T_ Amount")]
		public Double CGST_Amount{get;set;}
		[Display(Name = "S G S T_ Per")]
		public Double SGST_Per{get;set;}
		[Display(Name = "S G S T_ Amount")]
		public Double SGST_Amount{get;set;}
		[Display(Name = "I G S T_ Per")]
		public Double IGST_Per{get;set;}
		[Display(Name = "I G S T_ Amount")]
		public Double IGST_Amount{get;set;}
		[Display(Name = "Total_ Amount")]
		public Double Total_Amount{get;set;}
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
