namespace WebApiDAL
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using ZBMigrator.Constants;
    using WebApiModel;
    public class ErrorLogDAL : BaseDAL<ErrorLog>, IDisposable
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
        ~ErrorLogDAL()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Call Add method to insert Error Log 
        /// </summary>
        /// <param name="obj">ErrorLog class object pass</param>
        public async Task<long> Add(ErrorLog obj)
        {
            SqlParameter[] arParms = new SqlParameter[6];
            arParms[0] = new SqlParameter("@Application", SqlDbType.NVarChar)
            {
                Value = obj.Application
            };
            arParms[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar)
            {
                Value = obj.ErrorMsg
            };
            arParms[2] = new SqlParameter("@StatckTrace", SqlDbType.NVarChar)
            {
                Value = obj.StatckTrace
            };
            arParms[3] = new SqlParameter("@ProcName", SqlDbType.NVarChar)
            {
                Value = obj.ProcName
            };
            arParms[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt)
            {
                Value = obj.CreatedBy ?? 0
            };
            arParms[5] = new SqlParameter("@CreatedDate", SqlDbType.DateTime)
            {
                Value = obj.CreatedDate 
            };
            //arParms[5] = new SqlParameter("@ErrorLogID", SqlDbType.BigInt);
            //arParms[5].Direction = ParameterDirection.Output;
            return Convert.ToInt64(await SqlHelper.ExecuteScalarAsync(DBConStr, SPConstant.SP_InsertErrorLog, arParms));
        }

        /// <summary>
        /// Call Add method to insert Error Log 
        /// </summary>
        /// <param name="obj">ErrorLog class object pass</param>
        /// <returns>ErrorLogID</returns>
        public long AddError(ErrorLog obj)
        {
            SqlParameter[] arParms = new SqlParameter[11];
            arParms[0] = new SqlParameter("@Application", SqlDbType.NVarChar)
            {
                Value = obj.Application
            };
            arParms[1] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar)
            {
                Value = obj.ErrorMsg
            };
            arParms[2] = new SqlParameter("@StatckTrace", SqlDbType.NVarChar)
            {
                Value = obj.StatckTrace
            };
            arParms[3] = new SqlParameter("@ProcName", SqlDbType.NVarChar)
            {
                Value = obj.ProcName
            };
            arParms[4] = new SqlParameter("@CreatedBy", SqlDbType.BigInt)
            {
                Value = obj.CreatedBy ?? 0
            };
            arParms[5] = new SqlParameter("@ErrorLogID", SqlDbType.BigInt);
            arParms[10].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(DBConStr, CommandType.StoredProcedure, SPConstant.SP_InsertErrorLog, arParms);
            long ErrorLogID = !string.IsNullOrEmpty(Convert.ToString(arParms[10].Value)) ? (long)arParms[10].Value : 0;
            return ErrorLogID;
        }
    }
}
