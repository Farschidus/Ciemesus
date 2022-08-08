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
    public class MediaSubjects : _MediaSubjects
    {
        #region  "Constructors"

        public MediaSubjects()
        {
        }
        public MediaSubjects(int IDMedia, Guid IDSubject, byte IDMediaSubjectType)
        {
            this.LoadByPrimaryKey(IDMedia, IDSubject, IDMediaSubjectType);
        }

        #endregion

        #region  "Properties"

        private Medias _medias;
        public Medias Medias
        {
            get
            {
                if (_medias == null || _medias.pIDMedia != this.pIDMedia)
                {
                    _medias = new Medias();
                    _medias.LoadByPrimaryKey(this.pIDMedia);
                }
                return _medias;
            }
            set
            {
                _medias = value;
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

        private MediaSubjectTypes _mediaSubjectTypes;
        public MediaSubjectTypes MediaSubjectTypes
        {
            get
            {
                if (_mediaSubjectTypes == null || _mediaSubjectTypes.pIDMediaSubjectType != this.pIDMediaSubjectType)
                {
                    _mediaSubjectTypes = new MediaSubjectTypes();
                    _mediaSubjectTypes.LoadByPrimaryKey(this.pIDMediaSubjectType);
                }
                return _mediaSubjectTypes;
            }
            set
            {
                _mediaSubjectTypes = value;
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

            base.LoadFromSql("Ciemesus_tMediaSubjectsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByIDMedia(int IDMedia)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDMedia, IDMedia);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDMedia = IDMedia", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubject(Guid IDSubject)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubject = IDSubject", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDMediaSubjectType(byte IDMediaSubjectType)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDMediaSubjectType, IDMediaSubjectType);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDMediaSubjectType = IDMediaSubjectType", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectAndIDMediaSubjectType(Guid IDSubject, byte IDMediaSubjectType)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);
            parameters.Add(Parameters.IDMediaSubjectType, IDMediaSubjectType);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubject = IDSubject AND @IDMediaSubjectType = IDMediaSubjectType", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, int? IDMedia, Guid? IDSubject, byte? IDMediaSubjectType, int? Priority, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDMedia.HasValue)
            {
                parameters.Add(new SqlParameter("@IDMedia", SqlDbType.Int), IDMedia);
            }

            if (IDSubject.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);
            }

            if (IDMediaSubjectType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDMediaSubjectType", SqlDbType.TinyInt), IDMediaSubjectType);
            }

            if (Priority.HasValue)
            {
                parameters.Add(new SqlParameter("@Priority", SqlDbType.Int), Priority);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tMediaSubjectsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}