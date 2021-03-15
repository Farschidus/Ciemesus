using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 2/11/2014 11:47 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class PropertyTypes : _PropertyTypes
    {
        #region  "Constructors"

        public PropertyTypes()
        {
        }

        public PropertyTypes(byte IDType)
        {
            this.LoadByPrimaryKey(IDType);
        }

        #endregion

        #region  "Properties"

        private Properties _properties;
        public Properties Properties
        {
            get
            {
                if (_properties == null || _properties.pIDType != this.pIDType)
                {
                    _properties = new Properties();
                    _properties.LoadByIDType(this.pIDType);
                }
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

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

            base.LoadFromSql("Ciemesus_htPropertyTypesLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, byte? IDType, string Name, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDType", SqlDbType.TinyInt), IDType);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50), Name);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_htPropertyTypesSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion

        #region  "Enums"

        public enum Enum
        {
            text = 1,
            integer,
            floati,
            singleSelect,
            multiSelect,
            trueFalse,
            date,
            time,
            dateTime,
            multilineText,
            image
        }

        #endregion
    }
}
