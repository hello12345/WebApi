using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Purchase_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Purchase_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Purchase_ Id")]
		public Int32 Purchase_Id{get;set;}
		[Required]
		[Display(Name = "Purchase_ Date")]
		public DateTime Purchase_Date{get;set;}
		[Required]
		[Display(Name = "Supplier_ Id")]
		public Int32 Supplier_Id{get;set;}
		[Display(Name = "C G S T")]
		public Double CGST{get;set;}
		[Display(Name = "S G S T")]
		public Double SGST{get;set;}
		[Display(Name = "I G S T")]
		public Double IGST{get;set;}
		[Display(Name = "Total In Words")]
		[StringLength(500)]
		public String TotalInWords{get;set;}
		[Display(Name = "Total Amount")]
		public Double TotalAmount{get;set;}
		[Display(Name = "Field1")]
		[StringLength(50)]
		public String Field1{get;set;}
		[Display(Name = "Field2")]
		[StringLength(50)]
		public String Field2{get;set;}
		[Display(Name = "Field3")]
		[StringLength(50)]
		public String Field3{get;set;}
		[Display(Name = "Is Active")]
		public Boolean IsActive{get;set;}
		[StringLength(50)]
		public String CreatedBy{get;set;}
		public DateTime CreatedDate{get;set;}
		[StringLength(50)]
		public String ModifiedBy{get;set;}
		public DateTime ModifiedDate{get;set;}
		[Display(Name = "Row_ Version")]
		public object Row_Version{get;set;}
		[Required]
		[Display(Name = "Profile_ Id")]
		public Int64 Profile_Id{get;set;}

        #endregion

	}
}
