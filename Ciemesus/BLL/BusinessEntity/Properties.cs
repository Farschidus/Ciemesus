using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 2/12/2014 3:05 AM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Properties : _Properties
    {
        #region  "Constructors"

        public Properties()
        {
        }

        public Properties(int IDProperty)
        {
            this.LoadByPrimaryKey(IDProperty);
        }

        #endregion

        #region  "Properties"

        private PropertyTypes _propertyTypes;
        public PropertyTypes PropertyTypes
        {
            get
            {
                if (_propertyTypes == null || _propertyTypes.pIDType != this.pIDType)
                {
                    _propertyTypes = new PropertyTypes();
                    _propertyTypes.LoadByPrimaryKey(this.pIDType);
                }
                return _propertyTypes;
            }
            set
            {
                _propertyTypes = value;
            }
        }

        private PropertyItems _propertyItems;
        public PropertyItems PropertyItems
        {
            get
            {
                if (_propertyItems == null || _propertyItems.pIDProperty != this.pIDProperty)
                {
                    _propertyItems = new PropertyItems();
                    _propertyItems.LoadByIDProperty(this.pIDProperty);
                }
                return _propertyItems;
            }
            set
            {
                _propertyItems = value;
            }
        }

        private SubjectProperties _subjectProperties;
        public SubjectProperties SubjectProperties
        {
            get
            {
                if (_subjectProperties == null || _subjectProperties.pIDProperty != this.pIDProperty)
                {
                    _subjectProperties = new SubjectProperties();
                    _subjectProperties.LoadByIDProperty(this.pIDProperty);
                }
                return _subjectProperties;
            }
            set
            {
                _subjectProperties = value;
            }
        }

        private SubjectPropertyValues _subjectPropertyValues;
        public SubjectPropertyValues SubjectPropertyValues
        {
            get
            {
                if (_subjectPropertyValues == null || _subjectPropertyValues.pIDProperty != this.pIDProperty)
                {
                    _subjectPropertyValues = new SubjectPropertyValues();
                    _subjectPropertyValues.LoadByIDProperty(this.pIDProperty);
                }
                return _subjectPropertyValues;
            }
            set
            {
                _subjectPropertyValues = value;
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

            base.LoadFromSql("Ciemesus_tPropertiesLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByIDType(byte IDType)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDType, IDType);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDType = IDType", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDLanguage(byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDLanguageAndIDTypeAndName(byte IDLanguage, byte IDType, string Name)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);
            parameters.Add(Parameters.IDType, IDType);
            parameters.Add(Parameters.Name, Name);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND @IDType = IDType AND @Name = Name", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectAndIDLanguage(Guid IDSubject, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND IDProperty IN (SELECT IDProperty FROM Ciemesus_tSubjectProperties WHERE @IDSubject = IDSubject)", parameters, System.Data.CommandType.Text);
        }
        public bool LoadPropertyValueByIDSubjectAndIDProperty(Guid IDSubject, int IDProperty)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);
            parameters.Add(Parameters.IDProperty, IDProperty);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IDProperty IN (SELECT IDProperty FROM Ciemesus_tSubjectPropertyValues WHERE @IDProperty = IDProperty)", parameters, System.Data.CommandType.Text);
        }       
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, int? IDProperty, byte? IDLanguage, byte? IDType, string Name, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDProperty.HasValue)
            {
                parameters.Add(new SqlParameter("@IDProperty", SqlDbType.Int), IDProperty);
            }

            if (IDLanguage.HasValue)
            {
                parameters.Add(new SqlParameter("@IDLanguage", SqlDbType.TinyInt), IDLanguage);
            }

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

            base.LoadFromSql("Ciemesus_tPropertiesSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
