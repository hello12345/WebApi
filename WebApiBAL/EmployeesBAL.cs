using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Threading.Tasks;
 
using WebApiModel;
using WebApiCommon;
using WebApiDAL;
using WebApiHelper;
using WebApiBAL;
/// <summary>
/// Summary description for EmployeesBAL
/// </summary>
namespace WebApiBAL
{
    public class EmployeesBAL  : IBaseBAL<EmployeesDTO>,IDisposable
    {
    	#region Private Variables
		//readonly EmployeesDAL objEmployeesDAL;
		ResultPT objResultPT;
		#endregion
		
        #region Public Constructors
        public EmployeesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
            //objEmployeesDAL=new EmployeesDAL();
        }
        #endregion       

        #region Public Methods
        public async Task<ResultPT> InsertAsync(EmployeesDTO objEmployeesDTO)
        { 
			try
            {
				objResultPT = new ResultPT();
				using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
                {
                    objResultPT.ReturnObject = await objEmployeesDAL.InsertAsync(objEmployeesDTO);
                    if (Convert.ToInt32(objResultPT.ReturnObject) == 2)
                    {
                        objResultPT.ResultMsg = string.Format(Messages.ObjectExist, "Employees");
                        objResultPT.TransactionStatus = Enums.ResultStatus.Warning;
                    }
                    else if (Convert.ToInt32(objResultPT.ReturnObject) > 0 )
                    {
                        objResultPT.ResultMsg = Messages.Success;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Success;
                    }
                    else if (Convert.ToInt32(objResultPT.ReturnObject) == 0)
                    {
                        objResultPT.ResultMsg = Messages.NoDataFound;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Information;
                    }
                    else
                    {
                        objResultPT.ResultMsg = Messages.Error;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                    }
                }
				return objResultPT;
			}
            catch (Exception Ex)
            {
                ////log error message into database.                
                await this.LogErrorAsync(ErrorLog.ApplicationName.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
                objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                objResultPT.ResultMsg = Ex.Message;
            }

            return objResultPT;
        }

        public async Task<ResultPT> UpdateAsync(EmployeesDTO objEmployeesDTO)
        {
			try
            {
				objResultPT = new ResultPT();
				using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
                {
                    objResultPT.ReturnObject = await objEmployeesDAL.UpdateAsync(objEmployeesDTO);
                    if (Convert.ToInt32(objResultPT.ReturnObject) == 2)
                    {
                        objResultPT.ResultMsg = string.Format(Messages.ObjectExist, "Employees");
                        objResultPT.TransactionStatus = Enums.ResultStatus.Warning;
                    }
                    else if (Convert.ToInt32(objResultPT.ReturnObject) > 0 )
                    {
                        objResultPT.ResultMsg = Messages.Success;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Success;
                    }
                    else if (Convert.ToInt32(objResultPT.ReturnObject) == 0)
                    {
                        objResultPT.ResultMsg = Messages.NoDataFound;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Information;
                    }
                    else
                    {
                        objResultPT.ResultMsg = Messages.Error;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                    }
                }
				return objResultPT;
			}
            catch (Exception Ex)
            {
                ////log error message into database.                
                await this.LogErrorAsync(ErrorLog.ApplicationName.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
                objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                objResultPT.ResultMsg = Ex.Message;
            }
			return objResultPT;
        }

        public async Task<ResultPT> DeleteAsync(long ID)
        {
			try
            {
				objResultPT = new ResultPT();
				using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
                {
                    objResultPT.ReturnObject = await objEmployeesDAL.DeleteAsync(ID);
                    if (Convert.ToInt32(objResultPT.ReturnObject) > 0 )
                    {
                        objResultPT.ResultMsg = Messages.DeleteSuccess;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Success;
                    }
                    else if (Convert.ToInt32(objResultPT.ReturnObject) == 0)
                    {
                        objResultPT.ResultMsg = Messages.NoDataFound;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Information;
                    }
                    else
                    {
                        objResultPT.ResultMsg = Messages.Error;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                    }
                }
				return objResultPT;
			}
            catch (Exception Ex)
            {
                ////log error message into database.                
                await this.LogErrorAsync(ErrorLog.ApplicationName.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
                objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                objResultPT.ResultMsg = Ex.Message;
            }
			return objResultPT;
			
        }

////    public async Task<ResultPT> DeleteAllAsync()
////    {
////		try
////        {
////			objResultPT = new ResultPT();
////			using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
////            {
////                 objResultPT.ReturnObject = objEmployeesDAL.DeleteAll();
////                objResultPT.TransactionStatus = Enums.ResultStatus.Success;
////                objResultPT.ResultMsg = "success";
////            }
////			return objResultPT;
////		}
////        catch (Exception Ex)
////        {
////            ////log error message into database.                
////            await this.LogError(ErrorLog.application.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
////            objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
////            objResultPT.ResultMsg = Ex.Message;
////        }
////		 return objResultPT;
////    }

        public async Task<ResultPT> GetByIDAsync(long ID)
        {
			try
            {
				objResultPT = new ResultPT();
				using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
                {                    
					DataSet dset = await objEmployeesDAL.GetByIDAsync(ID);
					if (dset.Tables.Count > 0 && dset.Tables[0].Rows.Count>0)
					{
                        DataTable dt = dset.Tables[0];
						objResultPT.ReturnObject = CommonFunctions.FillProperties<EmployeesDTO>(dt.Rows[0]);
						objResultPT.ResultMsg = Messages.Success;
                        objResultPT.TransactionStatus = Enums.ResultStatus.Success;
					}
					else 
					{
                        objResultPT.ReturnObject = "";
                        objResultPT.ResultMsg = Messages.NoDataFound;
                        objResultPT.TransactionStatus = Enums.ResultStatus.NodData;
                    }
                }
				return objResultPT;
			}
            catch (Exception Ex)
            {
                ////log error message into database.                
                await this.LogErrorAsync(ErrorLog.ApplicationName.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
                objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                objResultPT.ResultMsg = Ex.Message;
            }
			          
			 return objResultPT;
        }      
        
        public async Task<ResultPT> GetAllAsync( )
        {
			try
            {
                objResultPT = new ResultPT();
                using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
                {
                    objResultPT.ReturnObject = await objEmployeesDAL.GetAllAsync();
                }
                throw new Exception("Error Test");
                return objResultPT;
			}
            catch (Exception Ex)
            {
                ////log error message into database.                
                await this.LogErrorAsync(ErrorLog.ApplicationName.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
                objResultPT.TransactionStatus = Enums.ResultStatus.Failure;
                objResultPT.ResultMsg = Ex.Message;
            }
			          
			 return objResultPT;
        }
        public async Task<long> LogErrorAsync(ErrorLog.ApplicationName ApplicationName, string ProcessName, string ErrorMessage, string StackTrace = "")
        {
            using (ErrorLogBAL objErrorLogBAL = new ErrorLogBAL())
            {
                return  await objErrorLogBAL.LogErrorAsync(ApplicationName, ProcessName, ErrorMessage, StackTrace);
            }
          
        }

        //public async Task<ResultPT> FilterAsync(SortingNPagingPT param)
        //{
        //    using (EmployeesDAL objEmployeesDAL = new EmployeesDAL())
        //    {
        //        return await objEmployeesDAL.FilterAsync(param);
        //    }
        //}

        #endregion

        #region Destructor
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
        //public async Task<long> LogErrorAsync(ErrorLog.application ApplicationName, string ProcessName, string ErrorMessage, string StackTrace = "")
        //{
        //    using (ErrorLogBAL objErrorLogBAL = new ErrorLogBAL())
        //    {
        //        return await objErrorLogBAL.LogErrorAsync(ApplicationName, ProcessName, ErrorMessage, StackTrace);
        //    }
        //}

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

        public Task<ResultPT> GetAllAsync(long UserId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Txn_DocFilesBAL"/> is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>We must implement a finalizer to guarantee that our unmanaged resource is cleaned up</remarks>
        ~EmployeesBAL()
        {
            this.Dispose(false);
        }
        #endregion
    }

}
