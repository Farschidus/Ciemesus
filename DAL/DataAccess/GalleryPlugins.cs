using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 9/21/2012 2:09 PM
/// <summary>
namespace DAL.DataAccess
{
    public abstract class _GalleryPlugins : SqlClientEntity
    {
        public _GalleryPlugins()
        {
            this.QuerySource = "Ciemesus_tGalleryPlugins";
            this.MappingName = "Ciemesus_tGalleryPlugins";
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

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tGalleryPluginsLoadAll]", parameters);
        }

        //=================================================================
        // public Overridable Function LoadByPrimaryKey()  As Boolean
        //=================================================================
        //  Loads a single row of via the primary key
        //=================================================================
        public override bool LoadByPrimaryKey(object IDSubject, object IDPlugin)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);
            parameters.Add(Parameters.IDPlugin, IDPlugin);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tGalleryPluginsLoadByPrimaryKey]", parameters);
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
            public static SqlParameter IDPlugin
            {
                get
                {
                    return new SqlParameter("@IDPlugin", SqlDbType.Int, 0);
                }
            }
            public static SqlParameter Options
            {
                get
                {
                    return new SqlParameter("@Options", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter CSS
            {
                get
                {
                    return new SqlParameter("@CSS", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter DateFormat
            {
                get
                {
                    return new SqlParameter("@DateFormat", SqlDbType.NVarChar, 50);
                }
            }
            public static SqlParameter GenerateTitle
            {
                get
                {
                    return new SqlParameter("@GenerateTitle", SqlDbType.Bit, 0);
                }
            }
            public static SqlParameter GenerateDesc
            {
                get
                {
                    return new SqlParameter("@GenerateDesc", SqlDbType.Bit, 0);
                }
            }
            public static SqlParameter GenerateDate
            {
                get
                {
                    return new SqlParameter("@GenerateDate", SqlDbType.Bit, 0);
                }
            }
            public static SqlParameter GenerateAnchor
            {
                get
                {
                    return new SqlParameter("@GenerateAnchor", SqlDbType.Bit, 0);
                }
            }
        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string IDSubject = "IDSubject";
            public const string IDPlugin = "IDPlugin";
            public const string Options = "Options";
            public const string CSS = "CSS";
            public const string DateFormat = "DateFormat";
            public const string GenerateTitle = "GenerateTitle";
            public const string GenerateDesc = "GenerateDesc";
            public const string GenerateDate = "GenerateDate";
            public const string GenerateAnchor = "GenerateAnchor";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDSubject] = _GalleryPlugins.PropertyNames.IDSubject;
                    ht[IDPlugin] = _GalleryPlugins.PropertyNames.IDPlugin;
                    ht[Options] = _GalleryPlugins.PropertyNames.Options;
                    ht[CSS] = _GalleryPlugins.PropertyNames.CSS;
                    ht[DateFormat] = _GalleryPlugins.PropertyNames.DateFormat;
                    ht[GenerateTitle] = _GalleryPlugins.PropertyNames.GenerateTitle;
                    ht[GenerateDesc] = _GalleryPlugins.PropertyNames.GenerateDesc;
                    ht[GenerateDate] = _GalleryPlugins.PropertyNames.GenerateDate;
                    ht[GenerateAnchor] = _GalleryPlugins.PropertyNames.GenerateAnchor;
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
            public const string IDPlugin = "pIDPlugin";
            public const string Options = "pOptions";
            public const string CSS = "pCSS";
            public const string DateFormat = "pDateFormat";
            public const string GenerateTitle = "pGenerateTitle";
            public const string GenerateDesc = "pGenerateDesc";
            public const string GenerateDate = "pGenerateDate";
            public const string GenerateAnchor = "pGenerateAnchor";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDSubject] = _GalleryPlugins.ColumnNames.IDSubject;
                    ht[IDPlugin] = _GalleryPlugins.ColumnNames.IDPlugin;
                    ht[Options] = _GalleryPlugins.ColumnNames.Options;
                    ht[CSS] = _GalleryPlugins.ColumnNames.CSS;
                    ht[DateFormat] = _GalleryPlugins.ColumnNames.DateFormat;
                    ht[GenerateTitle] = _GalleryPlugins.ColumnNames.GenerateTitle;
                    ht[GenerateDesc] = _GalleryPlugins.ColumnNames.GenerateDesc;
                    ht[GenerateDate] = _GalleryPlugins.ColumnNames.GenerateDate;
                    ht[GenerateAnchor] = _GalleryPlugins.ColumnNames.GenerateAnchor;

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
            public const string IDPlugin = "s_IDPlugin";
            public const string Options = "s_Options";
            public const string CSS = "s_CSS";
            public const string DateFormat = "s_DateFormat";
            public const string GenerateTitle = "s_GenerateTitle";
            public const string GenerateDesc = "s_GenerateDesc";
            public const string GenerateDate = "s_GenerateDate";
            public const string GenerateAnchor = "s_GenerateAnchor";
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
        public virtual int pIDPlugin
        {
            get
            {
                return base.Getint(ColumnNames.IDPlugin);
            }
            set
            {
                base.Setint(ColumnNames.IDPlugin, value);
            }
        }
        public virtual string pOptions
        {
            get
            {
                return base.Getstring(ColumnNames.Options);
            }
            set
            {
                base.Setstring(ColumnNames.Options, value);
            }
        }
        public virtual string pCSS
        {
            get
            {
                return base.Getstring(ColumnNames.CSS);
            }
            set
            {
                base.Setstring(ColumnNames.CSS, value);
            }
        }
        public virtual string pDateFormat
        {
            get
            {
                return base.Getstring(ColumnNames.DateFormat);
            }
            set
            {
                base.Setstring(ColumnNames.DateFormat, value);
            }
        }
        public virtual bool pGenerateTitle
        {
            get
            {
                return base.Getbool(ColumnNames.GenerateTitle);
            }
            set
            {
                base.Setbool(ColumnNames.GenerateTitle, value);
            }
        }
        public virtual bool pGenerateDesc
        {
            get
            {
                return base.Getbool(ColumnNames.GenerateDesc);
            }
            set
            {
                base.Setbool(ColumnNames.GenerateDesc, value);
            }
        }
        public virtual bool pGenerateDate
        {
            get
            {
                return base.Getbool(ColumnNames.GenerateDate);
            }
            set
            {
                base.Setbool(ColumnNames.GenerateDate, value);
            }
        }
        public virtual bool pGenerateAnchor
        {
            get
            {
                return base.Getbool(ColumnNames.GenerateAnchor);
            }
            set
            {
                base.Setbool(ColumnNames.GenerateAnchor, value);
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

        public virtual string s_IDPlugin
        {
            get
            {
                return this.IsColumnNull(ColumnNames.IDPlugin) ? string.Empty : base.GetintAsString(ColumnNames.IDPlugin);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.IDPlugin);
                else
                    this.pIDPlugin = base.SetintAsString(ColumnNames.IDPlugin, value);
            }
        }

        public virtual string s_Options
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Options) ? string.Empty : base.GetstringAsString(ColumnNames.Options);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Options);
                else
                    this.pOptions = base.SetstringAsString(ColumnNames.Options, value);
            }
        }

        public virtual string s_CSS
        {
            get
            {
                return this.IsColumnNull(ColumnNames.CSS) ? string.Empty : base.GetstringAsString(ColumnNames.CSS);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.CSS);
                else
                    this.pCSS = base.SetstringAsString(ColumnNames.CSS, value);
            }
        }

        public virtual string s_DateFormat
        {
            get
            {
                return this.IsColumnNull(ColumnNames.DateFormat) ? string.Empty : base.GetstringAsString(ColumnNames.DateFormat);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.DateFormat);
                else
                    this.pDateFormat = base.SetstringAsString(ColumnNames.DateFormat, value);
            }
        }

        public virtual string s_GenerateTitle
        {
            get
            {
                return this.IsColumnNull(ColumnNames.GenerateTitle) ? string.Empty : base.GetboolAsString(ColumnNames.GenerateTitle);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.GenerateTitle);
                else
                    this.pGenerateTitle = base.SetboolAsString(ColumnNames.GenerateTitle, value);
            }
        }

        public virtual string s_GenerateDesc
        {
            get
            {
                return this.IsColumnNull(ColumnNames.GenerateDesc) ? string.Empty : base.GetboolAsString(ColumnNames.GenerateDesc);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.GenerateDesc);
                else
                    this.pGenerateDesc = base.SetboolAsString(ColumnNames.GenerateDesc, value);
            }
        }

        public virtual string s_GenerateDate
        {
            get
            {
                return this.IsColumnNull(ColumnNames.GenerateDate) ? string.Empty : base.GetboolAsString(ColumnNames.GenerateDate);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.GenerateDate);
                else
                    this.pGenerateDate = base.SetboolAsString(ColumnNames.GenerateDate, value);
            }
        }

        public virtual string s_GenerateAnchor
        {
            get
            {
                return this.IsColumnNull(ColumnNames.GenerateAnchor) ? string.Empty : base.GetboolAsString(ColumnNames.GenerateAnchor);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.GenerateAnchor);
                else
                    this.pGenerateAnchor = base.SetboolAsString(ColumnNames.GenerateAnchor, value);
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

                public WhereParameter IDPlugin
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDPlugin, Parameters.IDPlugin);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Options
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Options, Parameters.Options);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter CSS
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.CSS, Parameters.CSS);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter DateFormat
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.DateFormat, Parameters.DateFormat);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter GenerateTitle
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.GenerateTitle, Parameters.GenerateTitle);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter GenerateDesc
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.GenerateDesc, Parameters.GenerateDesc);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter GenerateDate
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.GenerateDate, Parameters.GenerateDate);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter GenerateAnchor
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.GenerateAnchor, Parameters.GenerateAnchor);
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

            public WhereParameter IDPlugin
            {
                get
                {
                    if (_IDPlugin_W == null)
                    {
                        _IDPlugin_W = TearOff.IDPlugin;
                    }
                    return _IDPlugin_W;
                }
            }

            public WhereParameter Options
            {
                get
                {
                    if (_Options_W == null)
                    {
                        _Options_W = TearOff.Options;
                    }
                    return _Options_W;
                }
            }

            public WhereParameter CSS
            {
                get
                {
                    if (_CSS_W == null)
                    {
                        _CSS_W = TearOff.CSS;
                    }
                    return _CSS_W;
                }
            }

            public WhereParameter DateFormat
            {
                get
                {
                    if (_DateFormat_W == null)
                    {
                        _DateFormat_W = TearOff.DateFormat;
                    }
                    return _DateFormat_W;
                }
            }

            public WhereParameter GenerateTitle
            {
                get
                {
                    if (_GenerateTitle_W == null)
                    {
                        _GenerateTitle_W = TearOff.GenerateTitle;
                    }
                    return _GenerateTitle_W;
                }
            }

            public WhereParameter GenerateDesc
            {
                get
                {
                    if (_GenerateDesc_W == null)
                    {
                        _GenerateDesc_W = TearOff.GenerateDesc;
                    }
                    return _GenerateDesc_W;
                }
            }

            public WhereParameter GenerateDate
            {
                get
                {
                    if (_GenerateDate_W == null)
                    {
                        _GenerateDate_W = TearOff.GenerateDate;
                    }
                    return _GenerateDate_W;
                }
            }

            public WhereParameter GenerateAnchor
            {
                get
                {
                    if (_GenerateAnchor_W == null)
                    {
                        _GenerateAnchor_W = TearOff.GenerateAnchor;
                    }
                    return _GenerateAnchor_W;
                }
            }


            private WhereParameter _IDSubject_W = null;
            private WhereParameter _IDPlugin_W = null;
            private WhereParameter _Options_W = null;
            private WhereParameter _CSS_W = null;
            private WhereParameter _DateFormat_W = null;
            private WhereParameter _GenerateTitle_W = null;
            private WhereParameter _GenerateDesc_W = null;
            private WhereParameter _GenerateDate_W = null;
            private WhereParameter _GenerateAnchor_W = null;

            public void WhereClauseReset()
            {
                _IDSubject_W = null;
                _IDPlugin_W = null;
                _Options_W = null;
                _CSS_W = null;
                _DateFormat_W = null;
                _GenerateTitle_W = null;
                _GenerateDesc_W = null;
                _GenerateDate_W = null;
                _GenerateAnchor_W = null;

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

                public AggregateParameter IDPlugin
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDPlugin, Parameters.IDPlugin);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Options
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Options, Parameters.Options);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter CSS
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.CSS, Parameters.CSS);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter DateFormat
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.DateFormat, Parameters.DateFormat);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter GenerateTitle
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.GenerateTitle, Parameters.GenerateTitle);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter GenerateDesc
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.GenerateDesc, Parameters.GenerateDesc);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter GenerateDate
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.GenerateDate, Parameters.GenerateDate);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter GenerateAnchor
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.GenerateAnchor, Parameters.GenerateAnchor);
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

            public AggregateParameter IDPlugin
            {
                get
                {
                    if (_IDPlugin_W == null)
                    {
                        _IDPlugin_W = TearOff.IDPlugin;
                    }
                    return _IDPlugin_W;
                }
            }

            public AggregateParameter Options
            {
                get
                {
                    if (_Options_W == null)
                    {
                        _Options_W = TearOff.Options;
                    }
                    return _Options_W;
                }
            }

            public AggregateParameter CSS
            {
                get
                {
                    if (_CSS_W == null)
                    {
                        _CSS_W = TearOff.CSS;
                    }
                    return _CSS_W;
                }
            }

            public AggregateParameter DateFormat
            {
                get
                {
                    if (_DateFormat_W == null)
                    {
                        _DateFormat_W = TearOff.DateFormat;
                    }
                    return _DateFormat_W;
                }
            }

            public AggregateParameter GenerateTitle
            {
                get
                {
                    if (_GenerateTitle_W == null)
                    {
                        _GenerateTitle_W = TearOff.GenerateTitle;
                    }
                    return _GenerateTitle_W;
                }
            }

            public AggregateParameter GenerateDesc
            {
                get
                {
                    if (_GenerateDesc_W == null)
                    {
                        _GenerateDesc_W = TearOff.GenerateDesc;
                    }
                    return _GenerateDesc_W;
                }
            }

            public AggregateParameter GenerateDate
            {
                get
                {
                    if (_GenerateDate_W == null)
                    {
                        _GenerateDate_W = TearOff.GenerateDate;
                    }
                    return _GenerateDate_W;
                }
            }

            public AggregateParameter GenerateAnchor
            {
                get
                {
                    if (_GenerateAnchor_W == null)
                    {
                        _GenerateAnchor_W = TearOff.GenerateAnchor;
                    }
                    return _GenerateAnchor_W;
                }
            }

            private AggregateParameter _IDSubject_W = null;
            private AggregateParameter _IDPlugin_W = null;
            private AggregateParameter _Options_W = null;
            private AggregateParameter _CSS_W = null;
            private AggregateParameter _DateFormat_W = null;
            private AggregateParameter _GenerateTitle_W = null;
            private AggregateParameter _GenerateDesc_W = null;
            private AggregateParameter _GenerateDate_W = null;
            private AggregateParameter _GenerateAnchor_W = null;

            public void AggregateClauseReset()
            {
                _IDSubject_W = null;
                _IDPlugin_W = null;
                _Options_W = null;
                _CSS_W = null;
                _DateFormat_W = null;
                _GenerateTitle_W = null;
                _GenerateDesc_W = null;
                _GenerateDate_W = null;
                _GenerateAnchor_W = null;

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
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tGalleryPluginsInsert]";

            CreateInsertParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetUpdateCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tGalleryPluginsUpdate]";

            CreateUpdateParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetDeleteCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tGalleryPluginsDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.IDSubject);
            p.SourceColumn = ColumnNames.IDSubject;
            p.SourceVersion = DataRowVersion.Current;
            p = cmd.Parameters.Add(Parameters.IDPlugin);
            p.SourceColumn = ColumnNames.IDPlugin;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDSubject);
            p.SourceColumn = ColumnNames.IDSubject;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDPlugin);
            p.SourceColumn = ColumnNames.IDPlugin;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Options);
            p.SourceColumn = ColumnNames.Options;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.CSS);
            p.SourceColumn = ColumnNames.CSS;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.DateFormat);
            p.SourceColumn = ColumnNames.DateFormat;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateTitle);
            p.SourceColumn = ColumnNames.GenerateTitle;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateDesc);
            p.SourceColumn = ColumnNames.GenerateDesc;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateDate);
            p.SourceColumn = ColumnNames.GenerateDate;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateAnchor);
            p.SourceColumn = ColumnNames.GenerateAnchor;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDSubject);
            p.SourceColumn = ColumnNames.IDSubject;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.IDPlugin);
            p.SourceColumn = ColumnNames.IDPlugin;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Options);
            p.SourceColumn = ColumnNames.Options;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.CSS);
            p.SourceColumn = ColumnNames.CSS;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.DateFormat);
            p.SourceColumn = ColumnNames.DateFormat;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateTitle);
            p.SourceColumn = ColumnNames.GenerateTitle;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateDesc);
            p.SourceColumn = ColumnNames.GenerateDesc;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateDate);
            p.SourceColumn = ColumnNames.GenerateDate;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.GenerateAnchor);
            p.SourceColumn = ColumnNames.GenerateAnchor;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }
    }
}
