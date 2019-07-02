using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Product_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Product_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Product_ Id")]
		public Int32 Product_Id{get;set;}
		[Required]
		[Display(Name = "Product_ Name")]
		[StringLength(255)]
		public String Product_Name{get;set;}
		[Required]
		[Display(Name = "Cat_ Id")]
		public Int32 Cat_Id{get;set;}
		[Required]
		[Display(Name = "Amount")]
		public Double Amount{get;set;}
		[Display(Name = "C G S T")]
		public Double CGST{get;set;}
		[Display(Name = "S G S T")]
		public Double SGST{get;set;}
		[Display(Name = "I G S T")]
		public Double IGST{get;set;}
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
