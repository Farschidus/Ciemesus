using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 7/14/2012 3:54 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Medias : _Medias
    {
        #region  "Constructors"

        public Medias()
        {
        }
        public Medias(int IDMedia)
        {
            this.LoadByPrimaryKey(IDMedia);
        }

        #endregion

        #region  "Properties"

        private MediaSubjects _mediaSubjects;
        public MediaSubjects MediaSubjects
        {
            get
            {
                if (_mediaSubjects == null || _mediaSubjects.pIDMedia != this.pIDMedia)
                {
                    _mediaSubjects = new MediaSubjects();
                    _mediaSubjects.LoadByIDMedia(this.pIDMedia);
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

            base.LoadFromSql("Ciemesus_tMediasLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool loadAllImages(int pageIndex, int pageSize, ref int totalRecords, string sortExpression)
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

            base.LoadFromSql("Ciemesus_tMediasLoadAllImages", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByIDSubject(Guid IDSubject)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IDMedia IN (SELECT IDMedia FROM Ciemesus4_tMediaSubjects WHERE @IDSubject = IDSubject)", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectAndIDSubjectContent(Guid IDSubject, long IDSubjectContent)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);
            parameters.Add(new SqlParameter("@IDSubjectContent", SqlDbType.BigInt), IDSubjectContent);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IDMedia IN (SELECT IDMedia FROM Ciemesus4_tMediaSubjects WHERE @IDSubject = IDSubject AND @IDSubjectContent = IDSubjectContent)", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, int? IDMedia, string FileName, string FileExtention, string Description, DateTime? DateFrom, DateTime? DateTo, string Url, string sortExpression)
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

            if (!string.IsNullOrEmpty(FileName))
            {
                parameters.Add(new SqlParameter("@FileName", SqlDbType.NVarChar, 128), FileName);
            }

            if (!string.IsNullOrEmpty(FileExtention))
            {
                parameters.Add(new SqlParameter("@FileExtention", SqlDbType.NVarChar, 50), FileExtention);
            }

            if (!string.IsNullOrEmpty(Description))
            {
                parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar, 1073741823), Description);
            }

            if (DateFrom.HasValue)
            {
                parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime), DateFrom);
            }

            if (DateTo.HasValue)
            {
                parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime), DateTo);
            }

            if (!string.IsNullOrEmpty(Url))
            {
                parameters.Add(new SqlParameter("@Url", SqlDbType.NVarChar, 256), Url);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tMediasSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
