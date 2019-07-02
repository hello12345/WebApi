namespace WebApiModel
{
    using System;
    public class ErrorLog
    {
        public enum ApplicationName
        {
            BAL, Common, DAL, Prototype, utility, AlluviaDynamicRazor, Web, API, Controller,ZohoBookMethod
        }

        public long ErrorId { get; set; }
        public ApplicationName Application { get; set; }
        public string ErrorMsg { get; set; }
        public string StatckTrace { get; set; }
        public string ProcName { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; } //= System.DateTime.UtcNow;
        public int IsEmailSent { get; set; }
        public Nullable<long> CreatedBy { get; set; }
    }


    [Serializable]
    public class LogedInMemberDtlPT
    {
        public Int64 ID { get; set; }
    }
}
