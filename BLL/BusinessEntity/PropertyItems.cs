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
    public class PropertyItems : _PropertyItems
    {
        #region  "Constructors"

        public PropertyItems()
        {
        }

        public PropertyItems(int IDPropertyItem)
        {
            this.LoadByPrimaryKey(IDPropertyItem);
        }

        #endregion

        #region  "Properties"

        private Properties _properties;
        public Properties Properties
        {
            get
            {
                if (_properties == null || _properties.pIDProperty != this.pIDProperty)
                {
                    _properties = new Properties();
                    _properties.LoadByPrimaryKey(this.pIDProperty);
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

            base.LoadFromSql("Ciemesus_tPropertyItemsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        public bool LoadByIDProperty(int IDProperty)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDProperty, IDProperty);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDProperty = IDProperty", parameters, System.Data.CommandType.Text);
        }

        public bool LoadByIDPropertyItem(int IDPropertyItem)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDPropertyItem, IDPropertyItem);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDPropertyItem = IDPropertyItem", parameters, System.Data.CommandType.Text);
        }

        public bool Search(int pageIndex, int pageSize, ref int totalRecords, int? IDPropertyItem, int? IDProperty, string Title, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDPropertyItem.HasValue)
            {
                parameters.Add(new SqlParameter("@IDPropertyItem", SqlDbType.Int), IDPropertyItem);
            }

            if (IDProperty.HasValue)
            {
                parameters.Add(new SqlParameter("@IDProperty", SqlDbType.Int), IDProperty);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50), Title);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tPropertyItemsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
