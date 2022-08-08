using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 9/6/2012 5:43 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class MediaSubjectTypes : _MediaSubjectTypes
    {
        #region  "Constructors"

        public MediaSubjectTypes()
        {
        }

        public MediaSubjectTypes(byte IDMediaSubjectType)
        {
            this.LoadByPrimaryKey(IDMediaSubjectType);
        }

        #endregion

        #region  "Properties"

        private MediaSubjects _mediaSubjects;
        public MediaSubjects MediaSubjects
        {
            get
            {
                if (_mediaSubjects == null || _mediaSubjects.pIDMediaSubjectType != this.pIDMediaSubjectType)
                {
                    _mediaSubjects = new MediaSubjects();
                    _mediaSubjects.LoadByIDMediaSubjectType(this.pIDMediaSubjectType);
                }
                return _mediaSubjects;
            }
            set
            {
                _mediaSubjects = value;
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

            base.LoadFromSql("Ciemesus_htMediaSubjectTypesLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, byte? IDMediaSubjectType, string Title, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDMediaSubjectType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDMediaSubjectType", SqlDbType.TinyInt), IDMediaSubjectType);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 50), Title);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_htMediaSubjectTypesSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion

        #region  "Enums"

        public enum Enum
        {
            attachment = 1,
            headerImage,
            imageAttachment,
            thumbnail
        }

        #endregion
    }
}
