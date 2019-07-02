using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Profile_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Profile_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Profile_ Id")]
		public Int32 Profile_Id{get;set;}
		[Required]
		[Display(Name = "Profile_ Name")]
		[StringLength(100)]
		public String Profile_Name{get;set;}
		[Display(Name = "Mobile")]
		[StringLength(100)]
		public String Mobile{get;set;}
		[Display(Name = "Email")]
		[EmailAddress]
		[StringLength(100)]
		public String Email{get;set;}
		[Display(Name = "Website")]
		[Url]
		[StringLength(100)]
		public String Website{get;set;}
		[Display(Name = "G S T")]
		[StringLength(50)]
		public String GST{get;set;}
		[Display(Name = "Is Sms")]
		public Boolean IsSms{get;set;}
		[Display(Name = "Is Email")]
		[EmailAddress]
		public Boolean IsEmail{get;set;}
		[Display(Name = "Is Whats App")]
		public Boolean IsWhatsApp{get;set;}
		[Display(Name = "Is Miss Call")]
		public Boolean IsMissCall{get;set;}
		[Display(Name = "Created_ I P")]
		[StringLength(50)]
		public String Created_IP{get;set;}
		public DateTime CreatedDate{get;set;}
		[StringLength(50)]
		public String ModifiedBy{get;set;}
		public DateTime ModifiedDate{get;set;}
		[Display(Name = "Is Active")]
		public Boolean IsActive{get;set;}
		[Display(Name = "Is Verified")]
		public Boolean IsVerified{get;set;}
		[Display(Name = "Verified Date")]
		public DateTime VerifiedDate{get;set;}
		[Display(Name = "Valid From")]
		public DateTime ValidFrom{get;set;}
		[Display(Name = "Valid Till")]
		public DateTime ValidTill{get;set;}

        #endregion

	}
}
