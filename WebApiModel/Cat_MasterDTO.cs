using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApiModel
{
   //[Serializable ]
   public class Cat_MasterDTO
    {

		public string EncID { get; set; }

        /// <summary>
        /// Summary description for Cat_MasterDTO
        /// </summary>
		#region Private Variables

		#endregion

		#region Public Properties
		[Required]
		[Display(Name = "Cat_ Id")]
		public Int32 Cat_Id{get;set;}
		[Required]
		[Display(Name = "Cat_ Name")]
		[StringLength(50)]
		public String Cat_Name{get;set;}
		[Required]
		[Display(Name = "Cat_ Type")]
		public Int32 Cat_Type{get;set;}
		[Required]
		[Display(Name = "Is Active")]
		public Boolean IsActive{get;set;}
		[Required]
		[Display(Name = "Profile_ Id")]
		public Int32 Profile_Id{get;set;}

        #endregion

	}
}
