using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Collections.Generic;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 7/14/2012 3:54 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class SubjectTypes : _SubjectTypes
    {
        #region  "Constructors"

        public SubjectTypes()
        {
        }
        public SubjectTypes(byte IDSubjectType)
        {
            this.LoadByPrimaryKey(IDSubjectType);
        }

        #endregion

        #region  "Properties"

        private Subjects _subjects;
        public Subjects Subjects
        {
            get
            {
                if (_subjects == null || _subjects.pIDSubjectType != this.pIDSubjectType)
                {
                    _subjects = new Subjects();
                    _subjects.LoadByIDSubjectType(this.pIDSubjectType);
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

            base.LoadFromSql("Ciemesus_htSubjectTypesLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByTitle(string Title)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Title, Title);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @Title = Title", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, byte? IDSubjectType, string Title, int? Priority, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDSubjectType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubjectType", SqlDbType.TinyInt), IDSubjectType);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50), Title);
            }

            if (Priority.HasValue)
            {
                parameters.Add(new SqlParameter("@Priority", SqlDbType.Int), Priority);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_htSubjectTypesSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion

        #region  "Enums"

        public enum Enum
        {
            home = 1,
            page,
            list,
            imageGallery,
            videoGallery,
            audioGallery,
            listItem,
            category,
            userPage,
            form,
            contact,
            store
        }      
        #endregion
    }
}