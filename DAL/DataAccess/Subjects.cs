using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 3/11/2014 3:03 PM
/// <summary>
namespace DAL.DataAccess
{
    public abstract class _Subjects : SqlClientEntity
    {
        public _Subjects()
        {
            this.QuerySource = "Ciemesus_tSubjects";
            this.MappingName = "Ciemesus_tSubjects";
        }

        //=================================================================
        //  public Overrides void AddNew()
        //=================================================================
        //
        //=================================================================
        public override void AddNew()
        {
            base.AddNew();
        }

        public override void FlushData()
        {
            this._whereClause = null;
            this._aggregateClause = null;
            base.FlushData();
        }

        //=================================================================
        //  	public Function LoadAll() As Boolean
        //=================================================================
        //  Loads all of the records in the database, and sets the currentRow to the first row
        //=================================================================
        public override bool LoadAll()
        {
            ListDictionary parameters = null;

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectsLoadAll]", parameters);
        }

        //=================================================================
        // public Overridable Function LoadByPrimaryKey()  As Boolean
        //=================================================================
        //  Loads a single row of via the primary key
        //=================================================================
        public override bool LoadByPrimaryKey(object IDSubject)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectsLoadByPrimaryKey]", parameters);
        }

        #region Parameters
        protected class Parameters
        {
            public static SqlParameter IDSubject
            {
                get
                {
                    return new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier, 0);
                }
            }
            public static SqlParameter IDSubjectType
            {
                get
                {
                    return new SqlParameter("@IDSubjectType", SqlDbType.TinyInt, 0);
                }
            }
            public static SqlParameter IDParent
            {
                get
                {
                    return new SqlParameter("@IDParent", SqlDbType.UniqueIdentifier, 0);
                }
            }
            public static SqlParameter IDLanguage
            {
                get
                {
                    return new SqlParameter("@IDLanguage", SqlDbType.TinyInt, 0);
                }
            }
            public static SqlParameter IDGallery
            {
                get
                {
                    return new SqlParameter("@IDGallery", SqlDbType.UniqueIdentifier, 0);
                }
            }
            public static SqlParameter Title
            {
                get
                {
                    return new SqlParameter("@Title", SqlDbType.NVarChar, 255);
                }
            }
            public static SqlParameter Body
            {
                get
                {
                    return new SqlParameter("@Body", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter Alias
            {
                get
                {
                    return new SqlParameter("@Alias", SqlDbType.NVarChar, 128);
                }
            }
            public static SqlParameter Date
            {
                get
                {
                    return new SqlParameter("@Date", SqlDbType.DateTime, 0);
                }
            }
            public static SqlParameter IsActive
            {
                get
                {
                    return new SqlParameter("@IsActive", SqlDbType.Bit, 0);
                }
            }
            public static SqlParameter BannerType
            {
                get
                {
                    return new SqlParameter("@BannerType", SqlDbType.NVarChar, 50);
                }
            }
            public static SqlParameter Priority
            {
                get
                {
                    return new SqlParameter("@Priority", SqlDbType.Int, 0);
                }
            }
        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string IDSubject = "IDSubject";
            public const string IDSubjectType = "IDSubjectType";
            public const string IDParent = "IDParent";
            public const string IDLanguage = "IDLanguage";
            public const string IDGallery = "IDGallery";
            public const string Title = "Title";
            public const string Body = "Body";
            public const string Alias = "Alias";
            public const string Date = "Date";
            public const string IsActive = "IsActive";
            public const string BannerType = "BannerType";
            public const string Priority = "Priority";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDSubject] = _Subjects.PropertyNames.IDSubject;
                    ht[IDSubjectType] = _Subjects.PropertyNames.IDSubjectType;
                    ht[IDParent] = _Subjects.PropertyNames.IDParent;
                    ht[IDLanguage] = _Subjects.PropertyNames.IDLanguage;
                    ht[IDGallery] = _Subjects.PropertyNames.IDGallery;
                    ht[Title] = _Subjects.PropertyNames.Title;
                    ht[Body] = _Subjects.PropertyNames.Body;
                    ht[Alias] = _Subjects.PropertyNames.Alias;
                    ht[Date] = _Subjects.PropertyNames.Date;
                    ht[IsActive] = _Subjects.PropertyNames.IsActive;
                    ht[BannerType] = _Subjects.PropertyNames.BannerType;
                    ht[Priority] = _Subjects.PropertyNames.Priority;
                }
                return (string)ht[columnName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region PropertyNames
        public class PropertyNames
        {

            public const string IDSubject = "pIDSubject";
            public const string IDSubjectType = "pIDSubjectType";
            public const string IDParent = "pIDParent";
            public const string IDLanguage = "pIDLanguage";
            public const string IDGallery = "pIDGallery";
            public const string Title = "pTitle";
            public const string Body = "pBody";
            public const string Alias = "pAlias";
            public const string Date = "pDate";
            public const string IsActive = "pIsActive";
            public const string BannerType = "pBannerType";
            public const string Priority = "pPriority";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDSubject] = _Subjects.ColumnNames.IDSubject;
                    ht[IDSubjectType] = _Subjects.ColumnNames.IDSubjectType;
                    ht[IDParent] = _Subjects.ColumnNames.IDParent;
                    ht[IDLanguage] = _Subjects.ColumnNames.IDLanguage;
                    ht[IDGallery] = _Subjects.ColumnNames.IDGallery;
                    ht[Title] = _Subjects.ColumnNames.Title;
                    ht[Body] = _Subjects.ColumnNames.Body;
                    ht[Alias] = _Subjects.ColumnNames.Alias;
                    ht[Date] = _Subjects.ColumnNames.Date;
                    ht[IsActive] = _Subjects.ColumnNames.IsActive;
                    ht[BannerType] = _Subjects.ColumnNames.BannerType;
                    ht[Priority] = _Subjects.ColumnNames.Priority;

                }
                return (string)ht[propertyName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region StringPropertyNames
        public class StringPropertyNames
        {
            public const string IDSubject = "s_IDSubject";
            public const string IDSubjectType = "s_IDSubjectType";
            public const string IDParent = "s_IDParent";
            public const string IDLanguage = "s_IDLanguage";
            public const string IDGallery = "s_IDGallery";
            public const string Title = "s_Title";
            public const string Body = "s_Body";
            public const string Alias = "s_Alias";
            public const string Date = "s_Date";
            public const string IsActive = "s_IsActive";
            public const string BannerType = "s_BannerType";
            public const string Priority = "s_Priority";
        }
        #endregion

        #region Properties
        public virtual Guid pIDSubject
        {
            get
            {
                return base.GetGuid(ColumnNames.IDSubject);
            }
            set
            {
                base.SetGuid(ColumnNames.IDSubject, value);
            }
        }
        public virtual byte pIDSubjectType
        {
            get
            {
                return base.Getbyte(ColumnNames.IDSubjectType);
            }
            set
            {
                base.Setbyte(ColumnNames.IDSubjectType, value);
            }
        }
        public virtual Guid pIDParent
        {
            get
            {
                return base.GetGuid(ColumnNames.IDParent);
            }
            set
            {
                base.SetGuid(ColumnNames.IDParent, value);
            }
        }
        public virtual byte pIDLanguage
        {
            get
            {
                return base.Getbyte(ColumnNames.IDLanguage);
            }
            set
            {
                base.Setbyte(ColumnNames.IDLanguage, value);
            }
        }
        public virtual Guid pIDGallery
        {
            get
            {
                return base.GetGuid(ColumnNames.IDGallery);
            }
            set
            {
                base.SetGuid(ColumnNames.IDGallery, value);
            }
        }
        public virtual string pTitle
        {
            get
            {
                return base.Getstring(ColumnNames.Title);
            }
            set
            {
                base.Setstring(ColumnNames.Title, value);
            }
        }
        public virtual string pBody
        {
            get
            {
                return base.Getstring(ColumnNames.Body);
            }
            set
            {
                base.Setstring(ColumnNames.Body, value);
            }
        }
        public virtual string pAlias
        {
            get
            {
                return base.Getstring(ColumnNames.Alias);
            }
            set
            {
                base.Setstring(ColumnNames.Alias, value);
            }
        }
        public virtual DateTime pDate
        {
            get
            {
                return base.GetDateTime(ColumnNames.Date);
            }
            set
            {
                base.SetDateTime(ColumnNames.Date, value);
            }
        }
        public virtual bool pIsActive
        {
            get
            {
                return base.Getbool(ColumnNames.IsActive);
            }
            set
            {
                base.Setbool(ColumnNames.IsActive, value);
            }
        }
        public virtual string pBannerType
        {
            get
            {
                return base.Getstring(ColumnNames.BannerType);
            }
            set
            {
                base.Setstring(ColumnNames.BannerType, value);
            }
        }
        public virtual int pPriority
        {
            get
            {
                return base.Getint(ColumnNames.Priority);
            }
            set
            {
                base.Setint(ColumnNames.Priority, value);
            }
        }
        #endregion

        #region String Properties
        public virtual string s_IDSubject
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDSubject) ? string.Empty : base.GetGuidAsString(ColumnNames.IDSubject);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDSubject);
                else
                    this.pIDSubject = base.SetGuidAsString(ColumnNames.IDSubject, value);
            }
        }

        public virtual string s_IDSubjectType
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDSubjectType) ? string.Empty : base.GetbyteAsString(ColumnNames.IDSubjectType);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDSubjectType);
                else
                    this.pIDSubjectType = base.SetbyteAsString(ColumnNames.IDSubjectType, value);
            }
        }

        public virtual string s_IDParent
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDParent) ? string.Empty : base.GetGuidAsString(ColumnNames.IDParent);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDParent);
                else
                    this.pIDParent = base.SetGuidAsString(ColumnNames.IDParent, value);
            }
        }

        public virtual string s_IDLanguage
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDLanguage) ? string.Empty : base.GetbyteAsString(ColumnNames.IDLanguage);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDLanguage);
                else
                    this.pIDLanguage = base.SetbyteAsString(ColumnNames.IDLanguage, value);
            }
        }

        public virtual string s_IDGallery
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDGallery) ? string.Empty : base.GetGuidAsString(ColumnNames.IDGallery);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDGallery);
                else
                    this.pIDGallery = base.SetGuidAsString(ColumnNames.IDGallery, value);
            }
        }

        public virtual string s_Title
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Title) ? string.Empty : base.GetstringAsString(ColumnNames.Title);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Title);
                else
                    this.pTitle = base.SetstringAsString(ColumnNames.Title, value);
            }
        }

        public virtual string s_Body
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Body) ? string.Empty : base.GetstringAsString(ColumnNames.Body);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Body);
                else
                    this.pBody = base.SetstringAsString(ColumnNames.Body, value);
            }
        }

        public virtual string s_Alias
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Alias) ? string.Empty : base.GetstringAsString(ColumnNames.Alias);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Alias);
                else
                    this.pAlias = base.SetstringAsString(ColumnNames.Alias, value);
            }
        }

        public virtual string s_Date
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Date) ? string.Empty : base.GetDateTimeAsString(ColumnNames.Date);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Date);
                else
                    this.pDate = base.SetDateTimeAsString(ColumnNames.Date, value);
            }
        }

        public virtual string s_IsActive
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IsActive) ? string.Empty : base.GetboolAsString(ColumnNames.IsActive);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IsActive);
                else
                    this.pIsActive = base.SetboolAsString(ColumnNames.IsActive, value);
            }
        }

        public virtual string s_BannerType
        {
            get
            {
                return this.IsColumnNull(ColumnNames.BannerType) ? string.Empty : base.GetstringAsString(ColumnNames.BannerType);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.BannerType);
                else
                    this.pBannerType = base.SetstringAsString(ColumnNames.BannerType, value);
            }
        }

        public virtual string s_Priority
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Priority) ? string.Empty : base.GetintAsString(ColumnNames.Priority);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Priority);
                else
                    this.pPriority = base.SetintAsString(ColumnNames.Priority, value);
            }
        }

        #endregion

        #region Where Clause
        public class WhereClause
        {
            public WhereClause(CoreEntity entity)
            {
                this._entity = entity;
            }

            public TearOffWhereParameter TearOff
            {
                get
                {
                    if (_tearOff == null)
                    {
                        _tearOff = new TearOffWhereParameter(this);
                    }

                    return _tearOff;
                }
            }

            #region WhereParameter TearOff's
            public class TearOffWhereParameter
            {
                public TearOffWhereParameter(WhereClause clause)
                {
                    this._clause = clause;
                }

                public WhereParameter IDSubject
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDSubject, Parameters.IDSubject);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IDSubjectType
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDSubjectType, Parameters.IDSubjectType);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IDParent
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDParent, Parameters.IDParent);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IDLanguage
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDLanguage, Parameters.IDLanguage);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IDGallery
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDGallery, Parameters.IDGallery);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Title
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Title, Parameters.Title);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Body
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Body, Parameters.Body);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Alias
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Alias, Parameters.Alias);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Date
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Date, Parameters.Date);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter IsActive
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IsActive, Parameters.IsActive);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter BannerType
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.BannerType, Parameters.BannerType);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Priority
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Priority, Parameters.Priority);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }



                private WhereClause _clause;
            }
            #endregion

            public WhereParameter IDSubject
            {
                get
                {
                    if (_IDSubject_W == null)
                    {
                        _IDSubject_W = TearOff.IDSubject;
                    }
                    return _IDSubject_W;
                }
            }

            public WhereParameter IDSubjectType
            {
                get
                {
                    if (_IDSubjectType_W == null)
                    {
                        _IDSubjectType_W = TearOff.IDSubjectType;
                    }
                    return _IDSubjectType_W;
                }
            }

            public WhereParameter IDParent
            {
                get
                {
                    if (_IDParent_W == null)
                    {
                        _IDParent_W = TearOff.IDParent;
                    }
                    return _IDParent_W;
                }
            }

            public WhereParameter IDLanguage
            {
                get
                {
                    if (_IDLanguage_W == null)
                    {
                        _IDLanguage_W = TearOff.IDLanguage;
                    }
                    return _IDLanguage_W;
                }
            }

            public WhereParameter IDGallery
            {
                get
                {
                    if (_IDGallery_W == null)
                    {
                        _IDGallery_W = TearOff.IDGallery;
                    }
                    return _IDGallery_W;
                }
            }

            public WhereParameter Title
            {
                get
                {
                    if (_Title_W == null)
                    {
                        _Title_W = TearOff.Title;
                    }
                    return _Title_W;
                }
            }

            public WhereParameter Body
            {
                get
                {
                    if (_Body_W == null)
                    {
                        _Body_W = TearOff.Body;
                    }
                    return _Body_W;
                }
            }

            public WhereParameter Alias
            {
                get
                {
                    if (_Alias_W == null)
                    {
                        _Alias_W = TearOff.Alias;
                    }
                    return _Alias_W;
                }
            }

            public WhereParameter Date
            {
                get
                {
                    if (_Date_W == null)
                    {
                        _Date_W = TearOff.Date;
                    }
                    return _Date_W;
                }
            }

            public WhereParameter IsActive
            {
                get
                {
                    if (_IsActive_W == null)
                    {
                        _IsActive_W = TearOff.IsActive;
                    }
                    return _IsActive_W;
                }
            }

            public WhereParameter BannerType
            {
                get
                {
                    if (_BannerType_W == null)
                    {
                        _BannerType_W = TearOff.BannerType;
                    }
                    return _BannerType_W;
                }
            }

            public WhereParameter Priority
            {
                get
                {
                    if (_Priority_W == null)
                    {
                        _Priority_W = TearOff.Priority;
                    }
                    return _Priority_W;
                }
            }


            private WhereParameter _IDSubject_W = null;
            private WhereParameter _IDSubjectType_W = null;
            private WhereParameter _IDParent_W = null;
            private WhereParameter _IDLanguage_W = null;
            private WhereParameter _IDGallery_W = null;
            private WhereParameter _Title_W = null;
            private WhereParameter _Body_W = null;
            private WhereParameter _Alias_W = null;
            private WhereParameter _Date_W = null;
            private WhereParameter _IsActive_W = null;
            private WhereParameter _BannerType_W = null;
            private WhereParameter _Priority_W = null;

            public void WhereClauseReset()
            {
                _IDSubject_W = null;
                _IDSubjectType_W = null;
                _IDParent_W = null;
                _IDLanguage_W = null;
                _IDGallery_W = null;
                _Title_W = null;
                _Body_W = null;
                _Alias_W = null;
                _Date_W = null;
                _IsActive_W = null;
                _BannerType_W = null;
                _Priority_W = null;

                this._entity.Query.FlushWhereParameters();
            }

            private CoreEntity _entity;
            private TearOffWhereParameter _tearOff;

        }

        public WhereClause Where
        {
            get
            {
                if (_whereClause == null)
                {
                    _whereClause = new WhereClause(this);
                }

                return _whereClause;
            }
        }

        private WhereClause _whereClause = null;
        #endregion

        #region Aggregate Clause
        public class AggregateClause
        {
            public AggregateClause(CoreEntity entity)
            {
                this._entity = entity;
            }

            public TearOffAggregateParameter TearOff
            {
                get
                {
                    if (_tearOff == null)
                    {
                        _tearOff = new TearOffAggregateParameter(this);
                    }

                    return _tearOff;
                }
            }

            #region AggregateParameter TearOff's
            public class TearOffAggregateParameter
            {
                public TearOffAggregateParameter(AggregateClause clause)
                {
                    this._clause = clause;
                }

                public AggregateParameter IDSubject
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDSubject, Parameters.IDSubject);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IDSubjectType
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDSubjectType, Parameters.IDSubjectType);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IDParent
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDParent, Parameters.IDParent);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IDLanguage
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDLanguage, Parameters.IDLanguage);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IDGallery
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDGallery, Parameters.IDGallery);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Title
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Title, Parameters.Title);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Body
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Body, Parameters.Body);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Alias
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Alias, Parameters.Alias);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Date
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Date, Parameters.Date);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter IsActive
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IsActive, Parameters.IsActive);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter BannerType
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.BannerType, Parameters.BannerType);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Priority
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Priority, Parameters.Priority);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                private AggregateClause _clause;
            }
            #endregion

            public AggregateParameter IDSubject
            {
                get
                {
                    if (_IDSubject_W == null)
                    {
                        _IDSubject_W = TearOff.IDSubject;
                    }
                    return _IDSubject_W;
                }
            }

            public AggregateParameter IDSubjectType
            {
                get
                {
                    if (_IDSubjectType_W == null)
                    {
                        _IDSubjectType_W = TearOff.IDSubjectType;
                    }
                    return _IDSubjectType_W;
                }
            }

            public AggregateParameter IDParent
            {
                get
                {
                    if (_IDParent_W == null)
                    {
                        _IDParent_W = TearOff.IDParent;
                    }
                    return _IDParent_W;
                }
            }

            public AggregateParameter IDLanguage
            {
                get
                {
                    if (_IDLanguage_W == null)
                    {
                        _IDLanguage_W = TearOff.IDLanguage;
                    }
                    return _IDLanguage_W;
                }
            }

            public AggregateParameter IDGallery
            {
                get
                {
                    if (_IDGallery_W == null)
                    {
                        _IDGallery_W = TearOff.IDGallery;
                    }
                    return _IDGallery_W;
                }
            }

            public AggregateParameter Title
            {
                get
                {
                    if (_Title_W == null)
                    {
                        _Title_W = TearOff.Title;
                    }
                    return _Title_W;
                }
            }

            public AggregateParameter Body
            {
                get
                {
                    if (_Body_W == null)
                    {
                        _Body_W = TearOff.Body;
                    }
                    return _Body_W;
                }
            }

            public AggregateParameter Alias
            {
                get
                {
                    if (_Alias_W == null)
                    {
                        _Alias_W = TearOff.Alias;
                    }
                    return _Alias_W;
                }
            }

            public AggregateParameter Date
            {
                get
                {
                    if (_Date_W == null)
                    {
                        _Date_W = TearOff.Date;
                    }
                    return _Date_W;
                }
            }

            public AggregateParameter IsActive
            {
                get
                {
                    if (_IsActive_W == null)
                    {
                        _IsActive_W = TearOff.IsActive;
                    }
                    return _IsActive_W;
                }
            }

            public AggregateParameter BannerType
            {
                get
                {
                    if (_BannerType_W == null)
                    {
                        _BannerType_W = TearOff.BannerType;
                    }
                    return _BannerType_W;
                }
            }

            public AggregateParameter Priority
            {
                get
                {
                    if (_Priority_W == null)
                    {
                        _Priority_W = TearOff.Priority;
                    }
                    return _Priority_W;
                }
            }

            private AggregateParameter _IDSubject_W = null;
            private AggregateParameter _IDSubjectType_W = null;
            private AggregateParameter _IDParent_W = null;
            private AggregateParameter _IDLanguage_W = null;
            private AggregateParameter _IDGallery_W = null;
            private AggregateParameter _Title_W = null;
            private AggregateParameter _Body_W = null;
            private AggregateParameter _Alias_W = null;
            private AggregateParameter _Date_W = null;
            private AggregateParameter _IsActive_W = null;
            private AggregateParameter _BannerType_W = null;
            private AggregateParameter _Priority_W = null;

            public void AggregateClauseReset()
            {
                _IDSubject_W = null;
                _IDSubjectType_W = null;
                _IDParent_W = null;
                _IDLanguage_W = null;
                _IDGallery_W = null;
                _Title_W = null;
                _Body_W = null;
                _Alias_W = null;
                _Date_W = null;
                _IsActive_W = null;
                _BannerType_W = null;
                _Priority_W = null;

                this._entity.Query.FlushAggregateParameters();
            }

            private CoreEntity _entity;
            private TearOffAggregateParameter _tearOff;

        }

        public AggregateClause Aggregate
        {
            get
            {
                if (_aggregateClause == null)
                {
                    _aggregateClause = new AggregateClause(this);
                }

                return _aggregateClause;
            }
        }

        private AggregateClause _aggregateClause = null;
        #endregion

        protected override IDbCommand GetInsertCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectsInsert]";

            CreateInsertParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetUpdateCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectsUpdate]";

            CreateUpdateParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetDeleteCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectsDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.IDSubject);
            p.SourceColumn = ColumnNames.IDSubject;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDSubject);
            p.SourceColumn = ColumnNames.IDSubject;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDSubjectType);
            p.SourceColumn = ColumnNames.IDSubjectType;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDParent);
            p.SourceColumn = ColumnNames.IDParent;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDLanguage);
            p.SourceColumn = ColumnNames.IDLanguage;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDGallery);
            p.SourceColumn = ColumnNames.IDGallery;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Title);
            p.SourceColumn = ColumnNames.Title;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Body);
            p.SourceColumn = ColumnNames.Body;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Alias);
            p.SourceColumn = ColumnNames.Alias;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Date);
            p.SourceColumn = ColumnNames.Date;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IsActive);
            p.SourceColumn = ColumnNames.IsActive;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.BannerType);
            p.SourceColumn = ColumnNames.BannerType;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Priority);
            p.SourceColumn = ColumnNames.Priority;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDSubject);
            p.SourceColumn = ColumnNames.IDSubject;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDSubjectType);
            p.SourceColumn = ColumnNames.IDSubjectType;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDParent);
            p.SourceColumn = ColumnNames.IDParent;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDLanguage);
            p.SourceColumn = ColumnNames.IDLanguage;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDGallery);
            p.SourceColumn = ColumnNames.IDGallery;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Title);
            p.SourceColumn = ColumnNames.Title;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Body);
            p.SourceColumn = ColumnNames.Body;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Alias);
            p.SourceColumn = ColumnNames.Alias;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Date);
            p.SourceColumn = ColumnNames.Date;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IsActive);
            p.SourceColumn = ColumnNames.IsActive;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.BannerType);
            p.SourceColumn = ColumnNames.BannerType;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Priority);
            p.SourceColumn = ColumnNames.Priority;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }
    }
}
