using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 9/3/2012 5:53 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Logs : _Logs
    {
        #region  "Constructors"

        public Logs()
        {
        }
        public Logs(long IDLog)
        {
            this.LoadByPrimaryKey(IDLog);
        }

        #endregion

        #region  "Properties"

        #endregion

        #region  "Methods"

        public bool LoadAll(int pageIndex, int pageSize, ref int totalRecords, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tLogsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, long? IDLog, string ModuleName, DateTime? CreationDateFrom, DateTime? CreationDateTo, Guid? UserID, string UserFullName, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDLog.HasValue)
            {
                parameters.Add(new SqlParameter("@IDLog", SqlDbType.BigInt), IDLog);
            }

            if (!string.IsNullOrEmpty(ModuleName))
            {
                parameters.Add(new SqlParameter("@ModuleName", SqlDbType.NVarChar, 128), ModuleName);
            }

            if (CreationDateFrom.HasValue)
            {
                parameters.Add(new SqlParameter("@CreationDateFrom", SqlDbType.DateTime), CreationDateFrom);
            }

            if (CreationDateTo.HasValue)
            {
                parameters.Add(new SqlParameter("@CreationDateTo", SqlDbType.DateTime), CreationDateTo);
            }

            if (UserID.HasValue)
            {
                parameters.Add(new SqlParameter("@UserID", SqlDbType.UniqueIdentifier), UserID);
            }

            if (!string.IsNullOrEmpty(UserFullName))
            {
                parameters.Add(new SqlParameter("@UserFullName", SqlDbType.NVarChar, 50), UserFullName);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tLogsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
