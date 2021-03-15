using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 9/6/2012 4:32 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Subjects : _Subjects
    {
        #region  "Constructors"

        public Subjects()
        {
        }
        public Subjects(Guid IDSubject)
        {
            this.LoadByPrimaryKey(IDSubject);
        }

        #endregion

        #region  "Properties"

        private Subjects _parents;
        public Subjects Parents
        {
            get
            {
                if (_parents == null || _parents.pIDSubject != this.pIDParent)
                {
                    _parents = new Subjects();
                    _parents.LoadByPrimaryKey(this.pIDParent);
                }
                return _parents;
            }
            set
            {
                _parents = value;
            }
        }

        private Subjects _childs;
        public Subjects Childs
        {
            get
            {
                if (_childs == null || _childs.pIDSubject != this.pIDSubject)
                {
                    _childs = new Subjects();
                    _childs.LoadByIDParent(this.pIDSubject);
                }
                return _childs;
            }
            set
            {
                _childs = value;
            }
        }

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

        private MediaSubjects _mediaSubjects;
        public MediaSubjects MediaSubjects
        {
            get
            {
                if (_mediaSubjects == null || _mediaSubjects.pIDSubject != this.pIDSubject)
                {
                    _mediaSubjects = new MediaSubjects();
                    _mediaSubjects.LoadByIDSubject(this.pIDSubject);
                }
                return _mediaSubjects;
            }
            set
            {
                _mediaSubjects = value;
            }
        }

        private GalleryPlugins _GalleryPlugins;
        public GalleryPlugins GalleryPlugins
        {
            get
            {
                if (_GalleryPlugins == null || _GalleryPlugins.pIDSubject != this.pIDSubject)
                {
                    _GalleryPlugins = new GalleryPlugins();
                    _GalleryPlugins.LoadByIDSubject(this.pIDSubject);
                }
                return _GalleryPlugins;
            }
            set
            {
                _GalleryPlugins = value;
            }
        }

        private SubjectPlugins _SubjectPlugins;
        public SubjectPlugins SubjectPlugins
        {
            get
            {
                if (_SubjectPlugins == null || _SubjectPlugins.pIDSubject != this.pIDSubject)
                {
                    _SubjectPlugins = new SubjectPlugins();
                    _SubjectPlugins.LoadByIDSubject(this.pIDSubject);
                }
                return _SubjectPlugins;
            }
            set
            {
                _SubjectPlugins = value;
            }
        }

        private SubjectProperties _subjectProperties;
        public SubjectProperties SubjectProperties
        {
            get
            {
                if (_subjectProperties == null || _subjectProperties.pIDSubject != this.pIDSubject)
                {
                    _subjectProperties = new SubjectProperties();
                    _subjectProperties.LoadByIDSubject(this.pIDSubject);
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
                if (_subjectPropertyValues == null || _subjectPropertyValues.pIDSubject != this.pIDSubject)
                {
                    _subjectPropertyValues = new SubjectPropertyValues();
                    _subjectPropertyValues.LoadByIDSubject(this.pIDSubject);
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

            base.LoadFromSql("Ciemesus_tSubjectsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadAllLists(int pageIndex, int pageSize, ref int totalRecords, byte IDLanguage, string sortExpression)
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

            parameters.Add(Parameters.IDLanguage, IDLanguage);

            base.LoadFromSql("Ciemesus_tSubjectsLoadAllLists", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadListByAlias(string Alias)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Alias, Alias);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @Alias = Alias AND IDSubjectType = " + ((byte)SubjectTypes.Enum.list).ToString(), parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectType(byte IDSubjectType)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubjectType = IDSubjectType", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDParent(Guid IDParent)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDParent, IDParent);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDParent = IDParent", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDLanguage(byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDGallery(Guid IDGallery)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDGallery, IDGallery);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDGallery = IDGallery", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectAndIDLanguage(Guid IDSubject, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubject = IDSubject AND @IDLanguage = IDLanguage", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDSubjectTypeAndIDLanguage(byte IDSubjectType, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND @IDSubjectType = IDSubjectType", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDParentAndIDLanguage(Guid IDParent, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDParent, IDParent);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND IsActive = 1 AND @IDParent = IDParent", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDParentAndIDLanguage(Guid IDParent, byte IDLanguage, int Count)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDParent, IDParent);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT TOP " + Count.ToString() + " * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND IsActive = 1 AND @IDParent = IDParent ORDER BY DATE DESC", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDParentAndIDSubjectTypeAndIDLanguage(Guid IDParent, byte IDSubjectType, byte IDLanguage, bool? IsActive)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDParent, IDParent);
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);
            parameters.Add(Parameters.IDLanguage, IDLanguage);
            if (IsActive.HasValue)
            {
                parameters.Add(Parameters.IsActive, IsActive);
                return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND @IsActive = IsActive AND @IDParent = IDParent AND @IDSubjectType = IDSubjectType", parameters, System.Data.CommandType.Text);
            }
            else
            {
                return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND @IDParent = IDParent AND @IDSubjectType = IDSubjectType", parameters, System.Data.CommandType.Text);
            }
            
        }
        public bool LoadBySubjectAliasAndIDLanguage(string Alias, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Alias, Alias);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND @Alias = Alias", parameters, System.Data.CommandType.Text);
        }
        public bool LoadBySubjectAliasAndIDSubjectType(string Alias, byte IDSubjectType)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Alias, Alias);
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubjectType = IDSubjectType AND @Alias = Alias", parameters, System.Data.CommandType.Text);
        }
        public bool LoadBySubjectAliasAndIDSubjectTypeAndIDLanguage(string Alias, byte IDSubjectType, byte IDLanguage, bool IsActive)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Alias, Alias);
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);
            parameters.Add(Parameters.IDLanguage, IDLanguage);
            parameters.Add(Parameters.IsActive, IsActive);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubjectType = IDSubjectType AND @IDLanguage = IDLanguage AND @Alias = Alias AND @IsActive = IsActive", parameters, System.Data.CommandType.Text);
        }
        public bool LoadAllBySubjectAliasAndIDSubjectTypeAndIDLanguage(string Alias, byte IDSubjectType, byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.Alias, Alias);
            parameters.Add(Parameters.IDSubjectType, IDSubjectType);
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubjectType = IDSubjectType AND @IDLanguage = IDLanguage AND @Alias = Alias", parameters, System.Data.CommandType.Text);
        }
        public bool LoadAllListByIDLanguage(byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDLanguage = IDLanguage AND IDSubjectType = 3", parameters, System.Data.CommandType.Text);
        }
        public bool LoadAllListItemByIDLanguage(byte IDLanguage)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IDParent IN (SELECT IDSubject FROM " + QuerySource + " WHERE IDSubjectType = 3 AND @IDLanguage = IDLanguage)", parameters, System.Data.CommandType.Text);
        }
        public bool LoadTopListItemByIDLanguage(byte IDLanguage, int Count)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);

            return base.LoadFromSql("SELECT TOP " + Count.ToString() + " * FROM " + QuerySource + " WHERE IDParent IN (SELECT IDSubject FROM " + QuerySource + " WHERE IDSubjectType = 3 AND @IDLanguage = IDLanguage)", parameters, System.Data.CommandType.Text);
        }
        public bool LoadAllListItemByIDLanguageAndFromToDate(byte IDLanguage, DateTime From, DateTime To)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDLanguage, IDLanguage);
            parameters.Add(new SqlParameter("@From", SqlDbType.DateTime), From);
            parameters.Add(new SqlParameter("@To", SqlDbType.DateTime), To);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE IDParent IN (SELECT IDSubject FROM " + QuerySource + " WHERE IDSubjectType = 3 AND @IDLanguage = IDLanguage) AND Date > @From AND Date < @To", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, Guid? IDSubject, byte? IDSubjectType, Guid? IDParent, byte? IDLanguage, Guid? IDGallery, string Title, string Body, string Alias, DateTime? DateFrom, DateTime? DateTo, bool? IsActive, string BannerType, int? Priority, string sortExpression)
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

            if (IDSubjectType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubjectType", SqlDbType.TinyInt), IDSubjectType);
            }

            if (IDParent.HasValue)
            {
                parameters.Add(new SqlParameter("@IDParent", SqlDbType.UniqueIdentifier), IDParent);
            }

            if (IDLanguage.HasValue)
            {
                parameters.Add(new SqlParameter("@IDLanguage", SqlDbType.TinyInt), IDLanguage);
            }

            if (IDGallery.HasValue)
            {
                parameters.Add(new SqlParameter("@IDGallery", SqlDbType.UniqueIdentifier), IDGallery);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 255), Title);
            }

            if (!string.IsNullOrEmpty(Body))
            {
                parameters.Add(new SqlParameter("@Body", SqlDbType.NVarChar), Body);
            }

            if (!string.IsNullOrEmpty(Alias))
            {
                parameters.Add(new SqlParameter("@Alias", SqlDbType.NVarChar, 128), Alias);
            }

            if (DateFrom.HasValue)
            {
                parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime), DateFrom);
            }

            if (DateTo.HasValue)
            {
                parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime), DateTo);
            }

            if (IsActive.HasValue)
            {
                parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit), IsActive);
            }

            if (!string.IsNullOrEmpty(BannerType))
            {
                parameters.Add(new SqlParameter("@BannerType", SqlDbType.NVarChar, 50), BannerType);
            }

            if (Priority.HasValue)
            {
                parameters.Add(new SqlParameter("@Priority", SqlDbType.Int), Priority);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tSubjectsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool SearchSite(int pageIndex, int pageSize, ref int totalRecords, Guid? IDSubject, byte? IDSubjectType, Guid? IDParent, byte? IDLanguage, Guid? IDGallery, string Title, string Body, string Alias, DateTime? DateFrom, DateTime? DateTo, bool? IsActive, string BannerType, int? Priority, string sortExpression)
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

            if (IDSubjectType.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubjectType", SqlDbType.TinyInt), IDSubjectType);
            }

            if (IDParent.HasValue)
            {
                parameters.Add(new SqlParameter("@IDParent", SqlDbType.UniqueIdentifier), IDParent);
            }

            if (IDLanguage.HasValue)
            {
                parameters.Add(new SqlParameter("@IDLanguage", SqlDbType.TinyInt), IDLanguage);
            }

            if (IDGallery.HasValue)
            {
                parameters.Add(new SqlParameter("@IDGallery", SqlDbType.UniqueIdentifier), IDGallery);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                parameters.Add(new SqlParameter("@Title", SqlDbType.NVarChar, 255), Title);
            }

            if (!string.IsNullOrEmpty(Body))
            {
                parameters.Add(new SqlParameter("@Body", SqlDbType.NVarChar), Body);
            }

            if (!string.IsNullOrEmpty(Alias))
            {
                parameters.Add(new SqlParameter("@Alias", SqlDbType.NVarChar, 128), Alias);
            }

            if (DateFrom.HasValue)
            {
                parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime), DateFrom);
            }

            if (DateTo.HasValue)
            {
                parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime), DateTo);
            }

            if (IsActive.HasValue)
            {
                parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit), IsActive);
            }

            if (!string.IsNullOrEmpty(BannerType))
            {
                parameters.Add(new SqlParameter("@BannerType", SqlDbType.NVarChar, 50), BannerType);
            }

            if (Priority.HasValue)
            {
                parameters.Add(new SqlParameter("@Priority", SqlDbType.Int), Priority);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tSearchSite", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion

        public enum BannerTypes
        {
            inActive = 0,
            picture,
            gallery
        }
    }
}