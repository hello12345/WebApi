namespace ZBMigrator.DAL
{
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using WebApiDAL;

    /// <summary>
    /// Use to add more functionality using sql helper class.
    /// </summary>
    public class SqlHelperWrapper
    {
        /// <summary>
        /// Get the property value from passed object as argument.
        /// </summary>
        /// <param name="src">Source object</param>
        /// <param name="propName">Property Name</param>
        /// <returns></returns>
        public static object GetPropValue(object SourceObject, string PropertyName)
        {
            if (SourceObject.GetType().GetProperty(PropertyName) != null)
            {
                return SourceObject.GetType().GetProperty(PropertyName).GetValue(SourceObject, null);
            }
            else
            {
                return null;
            }
        }

        public static async Task<long> ExectuteScalarSp(object Obj, string StoredProcedureName, string ConnectionString)
        {
            SqlParameter[] arParms = SqlHelperParameterCache.GetSpParameterSet(ConnectionString, StoredProcedureName, false);

            foreach (SqlParameter objSqlParameter in arParms)
            {
                objSqlParameter.Value = GetPropValue(Obj, objSqlParameter.ParameterName.Replace("@", string.Empty));
            }

            long Result = Convert.ToInt64(await SqlHelper.ExecuteScalarAsync(ConnectionString, StoredProcedureName, arParms));
            return Result;
        }


    }
}
