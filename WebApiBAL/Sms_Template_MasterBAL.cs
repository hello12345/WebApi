using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Threading.Tasks;
 
using WebApiModel;
using WebApiDAL;
using WebApiCommon;
using WebApiHelper;

/// <summary>
/// Summary description for Sms_Template_MasterBAL
/// </summary>
namespace WebApiBAL
{
    public class Sms_Template_MasterBAL  : IBaseBAL<Sms_Template_MasterDTO>,IDisposable
    {
    	#region Private Variables
		//readonly Sms_Template_MasterDAL objSms_Template_MasterDAL;
		ResultPT objResultPT;
		#endregion
		
        #region Public Constructors
        public Sms_Template_MasterBAL()
        {
            //
            // TODO: Add constructor logic here
            //
            //objSms_Template_MasterDAL=new Sms_Template_MasterDAL();
        }
        #endregion       

        #region Public Methods
        public async Task<ResultPT> InsertAsync(Sms_Template_MasterDTO objSms_Template_MasterDTO)
        { 
			try
            {
				objResultPT = new ResultPT();
				using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
                {
                    objResultPT.ReturnObject = await objSms_Template_MasterDAL.InsertAsync(objSms_Template_MasterDTO);
                    if (Convert.ToInt32(objResultPT.ReturnObject) == 2)
                    {
                        objResultPT.ResultMsg = string.Format(Messages.ObjectExist, "Sms_Template_Master");
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

        public async Task<ResultPT> UpdateAsync(Sms_Template_MasterDTO objSms_Template_MasterDTO)
        {
			try
            {
				objResultPT = new ResultPT();
				using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
                {
                    objResultPT.ReturnObject = await objSms_Template_MasterDAL.UpdateAsync(objSms_Template_MasterDTO);
                    if (Convert.ToInt32(objResultPT.ReturnObject) == 2)
                    {
                        objResultPT.ResultMsg = string.Format(Messages.ObjectExist, "Sms_Template_Master");
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
				using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
                {
                    objResultPT.ReturnObject = await objSms_Template_MasterDAL.DeleteAsync(ID);
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
////			using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
////            {
////                 objResultPT.ReturnObject = objSms_Template_MasterDAL.DeleteAll();
////                objResultPT.TransactionStatus = Enums.ResultStatus.Success;
////                objResultPT.ResultMsg = "success";
////            }
////			return objResultPT;
////		}
////        catch (Exception Ex)
////        {
////            ////log error message into database.                
////            await this.LogError(ErrorLog.ApplicationName.BAL, System.Reflection.MethodBase.GetCurrentMethod().Name, Ex.Message, Ex.StackTrace);
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
				using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
                {                    
					DataSet dset = await objSms_Template_MasterDAL.GetByIDAsync(ID);
					if (dset.Tables.Count > 0 && dset.Tables[0].Rows.Count>0)
					{
                        DataTable dt = dset.Tables[0];
						objResultPT.ReturnObject = CommonFunctions.FillProperties<Sms_Template_MasterDTO>(dt.Rows[0]);
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
				using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
                {
                    objResultPT.ReturnObject = await objSms_Template_MasterDAL.GetAllAsync();                   
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

		//public async Task<ResultPT> FilterAsync(SortingNPagingPT param)
  //      {
  //          using (Sms_Template_MasterDAL objSms_Template_MasterDAL = new Sms_Template_MasterDAL())
  //          {
  //              return await objSms_Template_MasterDAL.FilterAsync(param);
  //          }
  //      }

		#endregion          
    
		#region Destructor
        /// <summary>
        /// Log error message into the database by creating object and calling BAL method
        /// </summary>
        /// <param name="ApplicationName">ApplicationName name</param>
        /// <param name="ProcessName">Process name</param>
        /// <param name="ErrorMessage">Custom error message</param>
        /// <param name="StackTrace">Detailed error message</param>
        /// <param name="StoreID">Store ID</param>
        /// <param name="MctID">Merchant ID</param>
        /// <param name="TmplID">Template ID</param>
        /// <param name="DocId">Document ID</param>
        /// <param name="DocNumber">Document Number</param>
        public async Task<long> LogErrorAsync(ErrorLog.ApplicationName ApplicationName, string ProcessName, string ErrorMessage, string StackTrace = "")
        {
            using (ErrorLogBAL objErrorLogBAL = new ErrorLogBAL())
            {
                return await objErrorLogBAL.LogErrorAsync(ApplicationName, ProcessName, ErrorMessage, StackTrace);
            }
        }

        /// <summary>
        /// Flag: Has Dispose already been called?
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Implementation of IDisposable.Dispose method.
        /// Performs ApplicationName-defined tasks associated with freeing, releasing,
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
        ~Sms_Template_MasterBAL()
        {
            this.Dispose(false);
        }
        #endregion
    }

}
