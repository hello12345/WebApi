using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Customer_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Customer_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Customer_ Id")]
		public Int32 Customer_Id{get;set;}
		[Required]
		[Display(Name = "Customer_ First_ Name")]
		[StringLength(255)]
		public String Customer_First_Name{get;set;}
		[Required]
		[Display(Name = "Customer_ Last_ Name")]
		[StringLength(255)]
		public String Customer_Last_Name{get;set;}
		[Display(Name = "Customer_ Address")]
		[StringLength(500)]
		public String Customer_Address{get;set;}
		[Display(Name = "Gender_ Id")]
		public Int32 Gender_Id{get;set;}
		[Required]
		[Display(Name = "Amount")]
		public Double Amount{get;set;}
		[Display(Name = "Customer_ Number")]
		[StringLength(20)]
		public String Customer_Number{get;set;}
		[Display(Name = "Customer_ Email")]
		[EmailAddress]
		[StringLength(100)]
		public String Customer_Email{get;set;}
		[Display(Name = "Send_ Sms")]
		public Boolean Send_Sms{get;set;}
		[Display(Name = "Send_ Email")]
		[EmailAddress]
		public Boolean Send_Email{get;set;}
		[Display(Name = "D O B")]
		public DateTime DOB{get;set;}
		[Display(Name = "D O A")]
		public DateTime DOA{get;set;}
		[Display(Name = "Send_ Greeting_ Sms")]
		public Boolean Send_Greeting_Sms{get;set;}
		[Display(Name = "Send_ Greeting_ Email")]
		[EmailAddress]
		public Boolean Send_Greeting_Email{get;set;}
		[Display(Name = "City")]
		[StringLength(50)]
		public String City{get;set;}
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
		public Int32 Profile_Id{get;set;}

        #endregion

	}
}
