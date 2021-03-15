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
    public class SubjectPropertyValues : _SubjectPropertyValues
    {
        #region  "Constructors"

        public SubjectPropertyValues()
        {
        }

        public SubjectPropertyValues(Guid IDSubject, int IDProperty)
        {
            this.LoadByPrimaryKey(IDSubject, IDProperty);
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

        private Subjects _subjects;
        public Subjects Subjects
        {
            get
            {
                if (_subjects == null || _subjects.pIDSubject != this.pIDSubject)
                {
                    _subjects = new Subjects();
                    _subjects.LoadByPrimaryKey(this.pIDSubject);
                }
                return _subjects;
            }
            set
            {
                _subjects = value;
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

            base.LoadFromSql("Ciemesus_tSubjectPropertyValuesLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        public bool LoadByIDSubject(Guid IDSubject)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubject = IDSubject", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDProperty(int IDProperty)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDProperty, IDProperty);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDProperty = IDProperty", parameters, System.Data.CommandType.Text);
        }             
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, Guid? IDSubject, int? IDProperty, string Value, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDSubject.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);
            }

            if (IDProperty.HasValue)
            {
                parameters.Add(new SqlParameter("@IDProperty", SqlDbType.Int), IDProperty);
            }

            if (!string.IsNullOrEmpty(Value))
            {
                parameters.Add(new SqlParameter("@Value", SqlDbType.NVarChar, 50), Value);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tSubjectPropertyValuesSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion

        #region  "Enum"
        public enum Enum
        {
            title = 0,
            value,            
        }

        #endregion
    }
}
