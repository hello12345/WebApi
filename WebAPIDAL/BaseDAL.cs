using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebApiDAL;
using ZBMigrator.Constants;
using ZBMigrator.DAL;

/// <summary>
/// Summary description for BaseDAL
/// </summary>
namespace WebApiDAL
{
    public abstract class BaseDAL<T>
        where T : class
    {
        private readonly string className;
        private static string _ConnectionString = string.Empty;
        AppConfiguration appConfiguration = new AppConfiguration();
        public BaseDAL()
        {
            this.className = typeof(T).Name.Replace("PT", "").Replace("DTO", "");
        }

        public async Task<long> InsertAsync(T obj)
        {
            return await SqlHelperWrapper.ExectuteScalarSp(obj, this.className + SPConstant.SP_Insert, this.DBConStr);
        }

        public async Task<long> UpdateAsync(T obj)
        {
            return await SqlHelperWrapper.ExectuteScalarSp(obj, this.className + SPConstant.SP_UpdateByID, this.DBConStr);
        }

        public async Task<long> DeleteAsync(long ID)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt)
            {
                Value = ID
            };
            return Convert.ToInt64(await SqlHelper.ExecuteScalarAsync(DBConStr, className + "DeleteByID", arParms));
            //return SqlHelperWrapper.ExectuteScalarSp(ID, className + "DeleteByID", DBConStr);
        }

        public async Task<DataSet> GetAllAsync(long UserId)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@UserId", SqlDbType.BigInt)
            {
                Value = UserId
            };
            return await SqlHelper.ExecuteDatasetAsync(DBConStr, this.className + SPConstant.SP_GetAll, arParms);
        }
        public async Task<DataSet> GetAllAsync()
        {
            return await SqlHelper.ExecuteDatasetAsync(DBConStr, this.className + SPConstant.SP_GetAll);
        }
        public long DeleteAll()
        {
            return SqlHelper.ExecuteNonQuery(DBConStr, this.className + SPConstant.SP_DeleteAll);
        }

        public async Task<DataSet> GetByIDAsync(long ID)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@ID", SqlDbType.BigInt)
            {
                Value = ID
            };
            return await SqlHelper.ExecuteDatasetAsync(DBConStr, this.className + SPConstant.SP_GetByID, arParms);
        }
        public async Task<DataSet> GetByEamilAsync(string Email)
        {
            SqlParameter[] arParms = new SqlParameter[1];
            arParms[0] = new SqlParameter("@Email", SqlDbType.NVarChar)
            {
                Value = Email
            };
            return await SqlHelper.ExecuteDatasetAsync(DBConStr, this.className + SPConstant.SP_GetByEmail, arParms);
        }
        public async Task<DataSet> CheckLoginAsync(string Email, string password)
        {
            SqlParameter[] arParms = new SqlParameter[2];
            arParms[0] = new SqlParameter("@Email", SqlDbType.NVarChar)
            {
                Value = Email
            };
            arParms[1] = new SqlParameter("@PasswordHas", SqlDbType.NVarChar)
            {
                Value = password
            };
            return await SqlHelper.ExecuteDatasetAsync(DBConStr, this.className + SPConstant.sp_checklogin, arParms);
        }
        protected string DBConStr
        {
            get
            {
                if (_ConnectionString == string.Empty)
                {
                    _ConnectionString = appConfiguration.ConnectionString;/* ConfigurationManager.ConnectionStrings[SPConstant.ConnectionString].ConnectionString;*/
                }
                return _ConnectionString;
            }
        }

    }
}

