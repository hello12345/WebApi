using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiModel;

/// <summary>
/// Summary description for EmployeesDAL
/// </summary>
namespace WebApiDAL 
{
    
    public class EmployeesDAL  : BaseDAL<EmployeesDTO>,IDisposable
    {
    	
	#region IDisposable Support
        /// <summary>
        /// DisposedValue is use to check the redundant calls
        /// </summary>
        private bool DisposedValue = false;

		public const string SP_EmployeesFilter = "EmployeesFilter";    


        /// <summary>
        /// Disposed method is used to free the unmanaged resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool Disposing)
        {
            if (!this.DisposedValue)
            {
                if (Disposing)
                {
                    //// TODO: dispose managed state (managed objects).
                    this.ResourceCleanup();
                }

                //// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                //// TODO: set large fields to null.

                this.DisposedValue = true;
            }
        }

        /// <summary>
        /// Destructor use to override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        /// </summary>
        ~EmployeesDAL()
        {
            //// do not change this code. put cleanup code in dispose(bool disposing) above.
            this.Dispose(false);
        }

        /// <summary>
        /// Disposed method to clean up the resources.
        /// </summary>
        public void Dispose()
        {
            //// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);
            //// TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Resource cleanup method to free all resources used in library.
        /// </summary>
        private void ResourceCleanup()
        {
            try
            {
                ////Clean resources used in process of secure connection.                
            }
            catch (Exception Ex)
            {
                ////log error message into database.                                
            }
        }

        #endregion

//		public async Task<ResultPT> FilterAsync(SortingNPagingPT param)
//        {
//            ResultPT objReturnObject = new ResultPT();
//            SqlParameter[] Sqlparam =  {
//                new SqlParameter("@DisplayLength", param.length)
//                ,new SqlParameter("@DisplayStart", param.start)
//                ,new SqlParameter("@SortCol", param.ordercol)
//                ,new SqlParameter("@SortDir", (int)param.orderdirection)
//                ,new SqlParameter("@Search",param.search)
//            };

//            DataSet dset = await SqlHelper.ExecuteDatasetAsync(DBConStr, SPConstant.SP_EmployeesFilter, Sqlparam);
//            DataTableReturn objdtr = new DataTableReturn();
//            objdtr.draw = param.draw;
//            if (dset.Tables.Count > 0)
//            {
//                if (dset.Tables[0].Rows.Count > 0)
//                {
//                    objdtr.recordsTotal = objdtr.recordsFiltered = int.Parse(dset.Tables[0].Rows[0]["TotalCount"].ToString());
					
//					var result = dset.Tables[0].AsEnumerable().Select(x => new string[] {                       
//					   x.Field<string>("Name"),
//x.Field<string>("Gender"),
//x.Field<string>("Salary"),
//LawyerSys.Helper.Crypto.Encrypt(Convert.ToString(x.Field<long>("ID")))
//                    });
//                    objdtr.data = result.ToArray();
//                }
//            }

//            objReturnObject.ReturnObject = objdtr;
//            objReturnObject.ResultMsg = Messages.Success;
//            objReturnObject.TransactionStatus = Enums.ResultStatus.Success;

//            return objReturnObject;
//        }
    
    }

}