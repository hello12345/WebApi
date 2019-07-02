namespace WebApiBAL
{
    using System;
    using System.Threading.Tasks;
    using WebApiDAL;
     
    using WebApiModel;
    using ZBMigrator.DAL;

    public class ErrorLogBAL : IDisposable
    {
        /// <summary>
        /// Flag: Has Dispose already been called?
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Implementation of IDisposable.Dispose method.
        /// Performs application-defined tasks associated with freeing, releasing, 
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //// We start by calling Dispose(bool) with true
            this.Dispose(true);
            //// This object will be cleaned up by the Dispose method. 
            //// Therefore, you should call GC.SupressFinalize to 
            //// take this object off the finalization queue 
            //// and prevent finalization code for this object 
            //// from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.</param>
        /// <remarks>
        /// If the main class was marked as sealed, we could just make this a private void Dispose(bool).  
        /// Alternatively, we could (in this case) put
        /// all of our logic directly in Dispose().  I prefer sticking to the same pattern for sealed classes, however.
        /// </remarks>
        protected void Dispose(bool disposing)
        {
            //// Check to see if Dispose has already been called. 
            if (!this.disposed)
            {
                //// If disposing equals true, dispose all managed 
                //// and unmanaged resources. 
                if (disposing)
                {
                    //// Dispose managed resources.                    
                }

                //// Call the appropriate methods to clean up 
                //// unmanaged resources here. 
                //// If disposing is false, 
                //// only the following code is executed.                

                // Note disposing has been done.
                this.disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Txn_DocFilesBAL"/> is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>We must implement a finalizer to guarantee that our unmanaged resource is cleaned up</remarks>
        ~ErrorLogBAL()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Call Add method to insert Error Log 
        /// </summary>
        /// <param name="obj">ErrorLog class object pass</param>
        public static async Task<long> Add(ErrorLog obj)
        {
            using (ErrorLogDAL objErrorLogDAL = new ErrorLogDAL())
            {
                return await objErrorLogDAL.Add(obj);
            }
        }

        /// <summary>
        /// Use to add error
        /// </summary>
        /// <param name="ApplicationName">Application name</param>
        /// <param name="SysRefMethodBase">Use to pass ref for System.Reflection.MethodBase</param>
        /// <param name="ex">Use to pass ref for System.Exception</param>
        /// <param name="StoreID">Use to pass Store ID</param>
        /// <param name="MctID">Use to pass Merchant ID</param>
        /// <param name="TmplID">Use to pass Template ID</param>
        /// <param name="DocId">Use to pass Document ID</param>
        /// <param name="DocNumber">Use to pass Document Number</param>
        /// <param name="CreatedBy">Use to pass User ID</param>
        /// <returns>ErrorID</returns>
        public long Add(ErrorLog.ApplicationName ApplicationName, System.Reflection.MethodBase SysRefMethodBase, Exception ex, long CreatedBy = 0)
        {
            ErrorLog oErrorLog = new ErrorLog
            {
                Application = ApplicationName,
                ProcName = SysRefMethodBase.Name,
                ErrorMsg = ex.HResult + "-" + ex.Message + "-" + ex.InnerException ?? string.Empty,
                StatckTrace = ex.StackTrace,
                CreatedBy = CreatedBy
            };

            using (ErrorLogDAL objErrorLogDAL = new ErrorLogDAL())
            {
                long Result = objErrorLogDAL.AddError(oErrorLog);
                return Result;
            }
        }

        /// <summary>
        /// Log error message into the database by creating object and calling BAL method
        /// </summary>
        /// <param name="ApplicationName">Application name</param>
        /// <param name="ProcessName">Process name</param>
        /// <param name="ErrorMessage">Custom error message</param>
        /// <param name="StackTrace">Detailed error message</param>
        /// <param name="StoreID">Store ID</param>
        /// <param name="MctID">Merchant ID</param>
        /// <param name="TmplID">Template ID</param>
        /// <param name="DocId">Document ID</param>
        /// <param name="DocNumber">Document Number</param>
        public async Task<long> LogErrorAsync(ErrorLog.ApplicationName ApplicationName, string ProcessName, string ErrorMessage, string StackTrace = "", long CreatedBy = 0)
        {
            ErrorLog oErrorLog = new ErrorLog
            {
                Application = ApplicationName,
                ProcName = ProcessName,
                ErrorMsg = ErrorMessage,
                StatckTrace = StackTrace,
                CreatedBy = CreatedBy,
                CreatedDate = DateTime.UtcNow
            };
            return await Add(oErrorLog);
        }

        /// <summary>
        /// Log error message into the database by creating object and calling BAL method
        /// </summary>
        /// <param name="ApplicationName">Use to pass application name</param>
        /// <param name="SysRefMethodBase">Use to pass System.Reflection.MethodBase</param>
        /// <param name="ex">Use to pass System.Exception</param>
        /// <param name="StoreID">Use to pass Store ID</param>
        /// <param name="MctID">Use to pass Merchant ID</param>
        /// <param name="TmplID">Use to pass Template ID</param>
        /// <param name="DocId">Use to pass Document ID</param>
        /// <param name="DocNumber">Use to pass Document Number</param>
        /// <param name="CreatedBy">Use to pass User ID</param>
        public async Task LogErrorAsync(ErrorLog.ApplicationName ApplicationName, System.Reflection.MethodBase SysRefMethodBase, Exception ex, long CreatedBy = 0)
        {
            string InnerException = !string.IsNullOrEmpty(Convert.ToString(ex.InnerException)) ? " InnerException : " + ex.InnerException : string.Empty;
            ErrorLog oErrorLog = new ErrorLog
            {
                Application = ApplicationName,
                ProcName = SysRefMethodBase.Name,
                ErrorMsg = "Message : " + ex.Message + InnerException,
                StatckTrace = ex.StackTrace,
                CreatedBy = CreatedBy,
                CreatedDate = DateTime.UtcNow
                
            };
            await Add(oErrorLog);
        }
    }
}
