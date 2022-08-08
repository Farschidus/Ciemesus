using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 9/6/2012 4:32 PM
/// <summary>
namespace DAL.DataAccess
{
    public abstract class _Medias : SqlClientEntity
    {
        public _Medias()
        {
            this.QuerySource = "Ciemesus_tMedias";
            this.MappingName = "Ciemesus_tMedias";
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

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tMediasLoadAll]", parameters);
        }

        //=================================================================
        // public Overridable Function LoadByPrimaryKey()  As Boolean
        //=================================================================
        //  Loads a single row of via the primary key
        //=================================================================
        public override bool LoadByPrimaryKey(object IDMedia)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDMedia, IDMedia);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tMediasLoadByPrimaryKey]", parameters);
        }

        #region Parameters
        protected class Parameters
        {
            public static SqlParameter IDMedia
            {
                get
                {
                    return new SqlParameter("@IDMedia", SqlDbType.Int, 0);
                }
            }
            public static SqlParameter FileName
            {
                get
                {
                    return new SqlParameter("@FileName", SqlDbType.NVarChar, 128);
                }
            }
            public static SqlParameter FileExtention
            {
                get
                {
                    return new SqlParameter("@FileExtention", SqlDbType.NVarChar, 50);
                }
            }
            public static SqlParameter Description
            {
                get
                {
                    return new SqlParameter("@Description", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter Date
            {
                get
                {
                    return new SqlParameter("@Date", SqlDbType.DateTime, 0);
                }
            }
            public static SqlParameter Url
            {
                get
                {
                    return new SqlParameter("@Url", SqlDbType.NVarChar, 256);
                }
            }
        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string IDMedia = "IDMedia";
            public const string FileName = "FileName";
            public const string FileExtention = "FileExtention";
            public const string Description = "Description";
            public const string Date = "Date";
            public const string Url = "Url";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDMedia] = _Medias.PropertyNames.IDMedia;
                    ht[FileName] = _Medias.PropertyNames.FileName;
                    ht[FileExtention] = _Medias.PropertyNames.FileExtention;
                    ht[Description] = _Medias.PropertyNames.Description;
                    ht[Date] = _Medias.PropertyNames.Date;
                    ht[Url] = _Medias.PropertyNames.Url;
                }
                return (string)ht[columnName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region PropertyNames
        public class PropertyNames
        {

            public const string IDMedia = "pIDMedia";
            public const string FileName = "pFileName";
            public const string FileExtention = "pFileExtention";
            public const string Description = "pDescription";
            public const string Date = "pDate";
            public const string Url = "pUrl";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDMedia] = _Medias.ColumnNames.IDMedia;
                    ht[FileName] = _Medias.ColumnNames.FileName;
                    ht[FileExtention] = _Medias.ColumnNames.FileExtention;
                    ht[Description] = _Medias.ColumnNames.Description;
                    ht[Date] = _Medias.ColumnNames.Date;
                    ht[Url] = _Medias.ColumnNames.Url;

                }
                return (string)ht[propertyName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region StringPropertyNames
        public class StringPropertyNames
        {
            public const string IDMedia = "s_IDMedia";
            public const string FileName = "s_FileName";
            public const string FileExtention = "s_FileExtention";
            public const string Description = "s_Description";
            public const string Date = "s_Date";
            public const string Url = "s_Url";
        }
        #endregion

        #region Properties
        public virtual int pIDMedia
        {
            get
            {
                return base.Getint(ColumnNames.IDMedia);
            }
            set
            {
                base.Setint(ColumnNames.IDMedia, value);
            }
        }
        public virtual string pFileName
        {
            get
            {
                return base.Getstring(ColumnNames.FileName);
            }
            set
            {
                base.Setstring(ColumnNames.FileName, value);
            }
        }
        public virtual string pFileExtention
        {
            get
            {
                return base.Getstring(ColumnNames.FileExtention);
            }
            set
            {
                base.Setstring(ColumnNames.FileExtention, value);
            }
        }
        public virtual string pDescription
        {
            get
            {
                return base.Getstring(ColumnNames.Description);
            }
            set
            {
                base.Setstring(ColumnNames.Description, value);
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
        public virtual string pUrl
        {
            get
            {
                return base.Getstring(ColumnNames.Url);
            }
            set
            {
                base.Setstring(ColumnNames.Url, value);
            }
        }
        #endregion

        #region String Properties
        public virtual string s_IDMedia
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDMedia) ? string.Empty : base.GetintAsString(ColumnNames.IDMedia);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDMedia);
                else
                    this.pIDMedia = base.SetintAsString(ColumnNames.IDMedia, value);
            }
        }

        public virtual string s_FileName
        {
            get
            {
                return this.IsColumnNull(ColumnNames.FileName) ? string.Empty : base.GetstringAsString(ColumnNames.FileName);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.FileName);
                else
                    this.pFileName = base.SetstringAsString(ColumnNames.FileName, value);
            }
        }

        public virtual string s_FileExtention
        {
            get
            {
                return this.IsColumnNull(ColumnNames.FileExtention) ? string.Empty : base.GetstringAsString(ColumnNames.FileExtention);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.FileExtention);
                else
                    this.pFileExtention = base.SetstringAsString(ColumnNames.FileExtention, value);
            }
        }

        public virtual string s_Description
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Description) ? string.Empty : base.GetstringAsString(ColumnNames.Description);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Description);
                else
                    this.pDescription = base.SetstringAsString(ColumnNames.Description, value);
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

        public virtual string s_Url
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Url) ? string.Empty : base.GetstringAsString(ColumnNames.Url);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Url);
                else
                    this.pUrl = base.SetstringAsString(ColumnNames.Url, value);
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

                public WhereParameter IDMedia
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDMedia, Parameters.IDMedia);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter FileName
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.FileName, Parameters.FileName);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter FileExtention
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.FileExtention, Parameters.FileExtention);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Description
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Description, Parameters.Description);
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

                public WhereParameter Url
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Url, Parameters.Url);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }



                private WhereClause _clause;
            }
            #endregion

            public WhereParameter IDMedia
            {
                get
                {
                    if (_IDMedia_W == null)
                    {
                        _IDMedia_W = TearOff.IDMedia;
                    }
                    return _IDMedia_W;
                }
            }

            public WhereParameter FileName
            {
                get
                {
                    if (_FileName_W == null)
                    {
                        _FileName_W = TearOff.FileName;
                    }
                    return _FileName_W;
                }
            }

            public WhereParameter FileExtention
            {
                get
                {
                    if (_FileExtention_W == null)
                    {
                        _FileExtention_W = TearOff.FileExtention;
                    }
                    return _FileExtention_W;
                }
            }

            public WhereParameter Description
            {
                get
                {
                    if (_Description_W == null)
                    {
                        _Description_W = TearOff.Description;
                    }
                    return _Description_W;
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

            public WhereParameter Url
            {
                get
                {
                    if (_Url_W == null)
                    {
                        _Url_W = TearOff.Url;
                    }
                    return _Url_W;
                }
            }


            private WhereParameter _IDMedia_W = null;
            private WhereParameter _FileName_W = null;
            private WhereParameter _FileExtention_W = null;
            private WhereParameter _Description_W = null;
            private WhereParameter _Date_W = null;
            private WhereParameter _Url_W = null;

            public void WhereClauseReset()
            {
                _IDMedia_W = null;
                _FileName_W = null;
                _FileExtention_W = null;
                _Description_W = null;
                _Date_W = null;
                _Url_W = null;

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

                public AggregateParameter IDMedia
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDMedia, Parameters.IDMedia);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter FileName
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.FileName, Parameters.FileName);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter FileExtention
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.FileExtention, Parameters.FileExtention);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Description
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Description, Parameters.Description);
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

                public AggregateParameter Url
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Url, Parameters.Url);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                private AggregateClause _clause;
            }
            #endregion

            public AggregateParameter IDMedia
            {
                get
                {
                    if (_IDMedia_W == null)
                    {
                        _IDMedia_W = TearOff.IDMedia;
                    }
                    return _IDMedia_W;
                }
            }

            public AggregateParameter FileName
            {
                get
                {
                    if (_FileName_W == null)
                    {
                        _FileName_W = TearOff.FileName;
                    }
                    return _FileName_W;
                }
            }

            public AggregateParameter FileExtention
            {
                get
                {
                    if (_FileExtention_W == null)
                    {
                        _FileExtention_W = TearOff.FileExtention;
                    }
                    return _FileExtention_W;
                }
            }

            public AggregateParameter Description
            {
                get
                {
                    if (_Description_W == null)
                    {
                        _Description_W = TearOff.Description;
                    }
                    return _Description_W;
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

            public AggregateParameter Url
            {
                get
                {
                    if (_Url_W == null)
                    {
                        _Url_W = TearOff.Url;
                    }
                    return _Url_W;
                }
            }

            private AggregateParameter _IDMedia_W = null;
            private AggregateParameter _FileName_W = null;
            private AggregateParameter _FileExtention_W = null;
            private AggregateParameter _Description_W = null;
            private AggregateParameter _Date_W = null;
            private AggregateParameter _Url_W = null;

            public void AggregateClauseReset()
            {
                _IDMedia_W = null;
                _FileName_W = null;
                _FileExtention_W = null;
                _Description_W = null;
                _Date_W = null;
                _Url_W = null;

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
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tMediasInsert]";

            CreateInsertParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetUpdateCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tMediasUpdate]";

            CreateUpdateParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetDeleteCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tMediasDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.IDMedia);
            p.SourceColumn = ColumnNames.IDMedia;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDMedia);
            p.SourceColumn = ColumnNames.IDMedia;
            p.SourceVersion = DataRowVersion.Current;
            p.Direction = ParameterDirection.Output;

            p = cmd.Parameters.Add(Parameters.FileName);
            p.SourceColumn = ColumnNames.FileName;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.FileExtention);
            p.SourceColumn = ColumnNames.FileExtention;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Description);
            p.SourceColumn = ColumnNames.Description;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Date);
            p.SourceColumn = ColumnNames.Date;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Url);
            p.SourceColumn = ColumnNames.Url;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDMedia);
            p.SourceColumn = ColumnNames.IDMedia;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.FileName);
            p.SourceColumn = ColumnNames.FileName;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.FileExtention);
            p.SourceColumn = ColumnNames.FileExtention;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Description);
            p.SourceColumn = ColumnNames.Description;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Date);
            p.SourceColumn = ColumnNames.Date;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Url);
            p.SourceColumn = ColumnNames.Url;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }
    }
}
