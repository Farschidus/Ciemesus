using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 7/9/2012 4:10 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Languages : _Languages
    {
        #region  "Constructors"

        public Languages()
        {
        }

        public Languages(byte IDLanguage)
        {
            this.LoadByPrimaryKey(IDLanguage);
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

            base.LoadFromSql("Ciemesus_htLanguagesLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadActiveLanguages()
        {
            ListDictionary parameters = new ListDictionary();

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IsActive = 1", parameters, System.Data.CommandType.Text);
        }
        public bool LoadDefaultLanguage()
        {
            ListDictionary parameters = new ListDictionary();

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IsDefault = 1", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByLanguageCode(string code)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Code, code);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE Code = @Code", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, byte? IDLanguage, string Title, string Code, bool? IsRTL, bool? IsActive, bool? IsDefault, int? Priority, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDLanguage.HasValue)
            {
                parameters.Add(new SqlParameter("@IDLanguage", SqlDbType.TinyInt), IDLanguage);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 100), Title);
            }

            if (!string.IsNullOrEmpty(Code))
            {
                parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 50), Code);
            }

            if (IsRTL.HasValue)
            {
                parameters.Add(new SqlParameter("@IsRTL", SqlDbType.Bit), IsRTL);
            }

            if (IsActive.HasValue)
            {
                parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit), IsActive);
            }

            if (IsDefault.HasValue)
            {
                parameters.Add(new SqlParameter("@IsDefault", SqlDbType.Bit), IsDefault);
            }

            if (Priority.HasValue)
            {
                parameters.Add(new SqlParameter("@Priority", SqlDbType.Int), Priority);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_htLanguagesSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
