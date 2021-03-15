using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections.Generic;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 8/7/2012 3:46 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class SubjectTypeContents : _SubjectTypeContents
    {
        #region  "Constructors"

        public SubjectTypeContents()
        {
        }
        public SubjectTypeContents(int IDSubjectTypeContent)
        {
            this.LoadByPrimaryKey(IDSubjectTypeContent);
        }

        #endregion

        #region  "Properties"

        private Languages _languages;
        public Languages Languages
        {
            get
            {
                if (_languages == null || _languages.pIDLanguage != this.pIDLanguage)
                {
                    _languages = new Languages();
                    _languages.LoadByPrimaryKey(this.pIDLanguage);
                }
                return _languages;
            }
            set
            {
                _languages = value;
            }
        }

        private SubjectTypes _subjectTypes;
        public SubjectTypes SubjectTypes
        {
            get
            {
                if (_subjectTypes == null || _subjectTypes.pIDSubjectType != this.pIDSubjectType)
                {
                    _subjectTypes = new SubjectTypes();
                    _subjectTypes.LoadByPrimaryKey(this.pIDSubjectType);
                }
                return _subjectTypes;
            }
            set
            {
                _subjectTypes = value;
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

            base.LoadFromSql("Ciemesus2_tSubjectTypeContentsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByIDParent(byte IDParent, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@IDParent", SqlDbType.NVarChar, 128), IDParent);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND IDSubjectType IN (SELECT IDSubjectType FROM Ciemesus2_htSubjectTypes WHERE IDParent = @IDParent)", parameters, System.Data.CommandType.Text);
        }
        public bool LoadAllModules(byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND IDSubjectType IN (SELECT IDSubjectType FROM Ciemesus2_htSubjectTypes WHERE IDParent IS NULL)", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByTitle(string Title)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Title, Title);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @Title = Title", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectType(byte IDSubjectType)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubjectType = IDSubjectType", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDLanguage(byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectTypeAndIDLanguage(byte IDSubjectType, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND @IDSubjectType = IDSubjectType", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, int? IDSubjectTypeContent, byte? IDSubjectType, byte? IDLanguage, string Title, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDSubjectTypeContent.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubjectTypeContent", SqlDbType.Int), IDSubjectTypeContent);
            }

            if (IDSubjectType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubjectType", SqlDbType.TinyInt), IDSubjectType);
            }

            if (IDLanguage.HasValue)
            {
                parameters.Add(new SqlParameter("@IDLanguage", SqlDbType.TinyInt), IDLanguage);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 512), Title);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus2_tSubjectTypeContentsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public List<Hardcodes.Item> LoadListChilds(byte IDLanguage)
        {
            List<Hardcodes.Item> output = new List<Hardcodes.Item>();
            mLoadRecursivly(output, IDLanguage, (byte)SubjectTypes.Enum.list, string.Empty);
            return output;
        }
        private bool mLoadRecursivly(List<Hardcodes.Item> parent,byte IDLanguage, byte subjectTypeID, string prefix)
        {
            SubjectTypeContents types = new SubjectTypeContents();
            types.LoadByIDParent(subjectTypeID, IDLanguage);

            if (types.RowCount > 0)
            {
                do
                {
                    Hardcodes.Item child = new Hardcodes.Item(types.pIDSubjectType, prefix + types.pTitle);
                    byte tempTypeID = types.pIDSubjectType;
                    parent.Add(child);
                    mLoadRecursivly(parent,IDLanguage, tempTypeID, prefix + types.pTitle + "\\");
                }
                while (types.MoveNext());
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}