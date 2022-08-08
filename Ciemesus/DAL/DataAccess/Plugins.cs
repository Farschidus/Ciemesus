using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 11/1/2012 2:08 PM
/// <summary>
namespace DAL.DataAccess
{
    public abstract class _Plugins : SqlClientEntity
    {
        public _Plugins()
        {
            this.QuerySource = "Ciemesus_tPlugins";
            this.MappingName = "Ciemesus_tPlugins";
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

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tPluginsLoadAll]", parameters);
        }

        //=================================================================
        // public Overridable Function LoadByPrimaryKey()  As Boolean
        //=================================================================
        //  Loads a single row of via the primary key
        //=================================================================
        public override bool LoadByPrimaryKey(object IDPlugin)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDPlugin, IDPlugin);

            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tPluginsLoadByPrimaryKey]", parameters);
        }

        #region Parameters
        protected class Parameters
        {
            public static SqlParameter IDPlugin
            {
                get
                {
                    return new SqlParameter("@IDPlugin", SqlDbType.Int, 0);
                }
            }
            public static SqlParameter Name
            {
                get
                {
                    return new SqlParameter("@Name", SqlDbType.NVarChar, 128);
                }
            }
            public static SqlParameter JSfileName
            {
                get
                {
                    return new SqlParameter("@JSfileName", SqlDbType.NVarChar, 256);
                }
            }
            public static SqlParameter Version
            {
                get
                {
                    return new SqlParameter("@Version", SqlDbType.NVarChar, 128);
                }
            }
            public static SqlParameter Description
            {
                get
                {
                    return new SqlParameter("@Description", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter Settings
            {
                get
                {
                    return new SqlParameter("@Settings", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter Css
            {
                get
                {
                    return new SqlParameter("@Css", SqlDbType.NVarChar, 1073741823);
                }
            }
            public static SqlParameter JSinit
            {
                get
                {
                    return new SqlParameter("@JSinit", SqlDbType.NVarChar, 1073741823);
                }
            }
        }
        #endregion

        #region ColumnNames
        public class ColumnNames
        {
            public const string IDPlugin = "IDPlugin";
            public const string Name = "Name";
            public const string JSfileName = "JSfileName";
            public const string Version = "Version";
            public const string Description = "Description";
            public const string Settings = "Settings";
            public const string Css = "Css";
            public const string JSinit = "JSinit";

            static public string ToPropertyName(string columnName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDPlugin] = _Plugins.PropertyNames.IDPlugin;
                    ht[Name] = _Plugins.PropertyNames.Name;
                    ht[JSfileName] = _Plugins.PropertyNames.JSfileName;
                    ht[Version] = _Plugins.PropertyNames.Version;
                    ht[Description] = _Plugins.PropertyNames.Description;
                    ht[Settings] = _Plugins.PropertyNames.Settings;
                    ht[Css] = _Plugins.PropertyNames.Css;
                    ht[JSinit] = _Plugins.PropertyNames.JSinit;
                }
                return (string)ht[columnName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region PropertyNames
        public class PropertyNames
        {

            public const string IDPlugin = "pIDPlugin";
            public const string Name = "pName";
            public const string JSfileName = "pJSfileName";
            public const string Version = "pVersion";
            public const string Description = "pDescription";
            public const string Settings = "pSettings";
            public const string Css = "pCss";
            public const string JSinit = "pJSinit";

            static public string ToColumnName(string propertyName)
            {
                if (ht == null)
                {
                    ht = new Hashtable();
                    ht[IDPlugin] = _Plugins.ColumnNames.IDPlugin;
                    ht[Name] = _Plugins.ColumnNames.Name;
                    ht[JSfileName] = _Plugins.ColumnNames.JSfileName;
                    ht[Version] = _Plugins.ColumnNames.Version;
                    ht[Description] = _Plugins.ColumnNames.Description;
                    ht[Settings] = _Plugins.ColumnNames.Settings;
                    ht[Css] = _Plugins.ColumnNames.Css;
                    ht[JSinit] = _Plugins.ColumnNames.JSinit;

                }
                return (string)ht[propertyName];
            }

            static private Hashtable ht = null;
        }
        #endregion

        #region StringPropertyNames
        public class StringPropertyNames
        {
            public const string IDPlugin = "s_IDPlugin";
            public const string Name = "s_Name";
            public const string JSfileName = "s_JSfileName";
            public const string Version = "s_Version";
            public const string Description = "s_Description";
            public const string Settings = "s_Settings";
            public const string Css = "s_Css";
            public const string JSinit = "s_JSinit";
        }
        #endregion

        #region Properties
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
        public virtual string pName
        {
            get
            {
                return base.Getstring(ColumnNames.Name);
            }
            set
            {
                base.Setstring(ColumnNames.Name, value);
            }
        }
        public virtual string pJSfileName
        {
            get
            {
                return base.Getstring(ColumnNames.JSfileName);
            }
            set
            {
                base.Setstring(ColumnNames.JSfileName, value);
            }
        }
        public virtual string pVersion
        {
            get
            {
                return base.Getstring(ColumnNames.Version);
            }
            set
            {
                base.Setstring(ColumnNames.Version, value);
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
        public virtual string pSettings
        {
            get
            {
                return base.Getstring(ColumnNames.Settings);
            }
            set
            {
                base.Setstring(ColumnNames.Settings, value);
            }
        }
        public virtual string pCss
        {
            get
            {
                return base.Getstring(ColumnNames.Css);
            }
            set
            {
                base.Setstring(ColumnNames.Css, value);
            }
        }
        public virtual string pJSinit
        {
            get
            {
                return base.Getstring(ColumnNames.JSinit);
            }
            set
            {
                base.Setstring(ColumnNames.JSinit, value);
            }
        }
        #endregion

        #region String Properties
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

        public virtual string s_Name
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Name) ? string.Empty : base.GetstringAsString(ColumnNames.Name);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Name);
                else
                    this.pName = base.SetstringAsString(ColumnNames.Name, value);
            }
        }

        public virtual string s_JSfileName
        {
            get
            {
                return this.IsColumnNull(ColumnNames.JSfileName) ? string.Empty : base.GetstringAsString(ColumnNames.JSfileName);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.JSfileName);
                else
                    this.pJSfileName = base.SetstringAsString(ColumnNames.JSfileName, value);
            }
        }

        public virtual string s_Version
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Version) ? string.Empty : base.GetstringAsString(ColumnNames.Version);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Version);
                else
                    this.pVersion = base.SetstringAsString(ColumnNames.Version, value);
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

        public virtual string s_Settings
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Settings) ? string.Empty : base.GetstringAsString(ColumnNames.Settings);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Settings);
                else
                    this.pSettings = base.SetstringAsString(ColumnNames.Settings, value);
            }
        }

        public virtual string s_Css
        {
            get
            {
                return this.IsColumnNull(ColumnNames.Css) ? string.Empty : base.GetstringAsString(ColumnNames.Css);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.Css);
                else
                    this.pCss = base.SetstringAsString(ColumnNames.Css, value);
            }
        }

        public virtual string s_JSinit
        {
            get
            {
                return this.IsColumnNull(ColumnNames.JSinit) ? string.Empty : base.GetstringAsString(ColumnNames.JSinit);
            }
            set
            {
                if (string.Empty == value)
                    this.SetColumnNull(ColumnNames.JSinit);
                else
                    this.pJSinit = base.SetstringAsString(ColumnNames.JSinit, value);
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

                public WhereParameter IDPlugin
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.IDPlugin, Parameters.IDPlugin);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Name
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Name, Parameters.Name);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter JSfileName
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.JSfileName, Parameters.JSfileName);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Version
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Version, Parameters.Version);
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

                public WhereParameter Settings
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Settings, Parameters.Settings);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter Css
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.Css, Parameters.Css);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }

                public WhereParameter JSinit
                {
                    get
                    {
                        WhereParameter where = new WhereParameter(ColumnNames.JSinit, Parameters.JSinit);
                        this._clause._entity.Query.AddWhereParameter(where);
                        return where;
                    }
                }



                private WhereClause _clause;
            }
            #endregion

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

            public WhereParameter Name
            {
                get
                {
                    if (_Name_W == null)
                    {
                        _Name_W = TearOff.Name;
                    }
                    return _Name_W;
                }
            }

            public WhereParameter JSfileName
            {
                get
                {
                    if (_JSfileName_W == null)
                    {
                        _JSfileName_W = TearOff.JSfileName;
                    }
                    return _JSfileName_W;
                }
            }

            public WhereParameter Version
            {
                get
                {
                    if (_Version_W == null)
                    {
                        _Version_W = TearOff.Version;
                    }
                    return _Version_W;
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

            public WhereParameter Settings
            {
                get
                {
                    if (_Settings_W == null)
                    {
                        _Settings_W = TearOff.Settings;
                    }
                    return _Settings_W;
                }
            }

            public WhereParameter Css
            {
                get
                {
                    if (_Css_W == null)
                    {
                        _Css_W = TearOff.Css;
                    }
                    return _Css_W;
                }
            }

            public WhereParameter JSinit
            {
                get
                {
                    if (_JSinit_W == null)
                    {
                        _JSinit_W = TearOff.JSinit;
                    }
                    return _JSinit_W;
                }
            }


            private WhereParameter _IDPlugin_W = null;
            private WhereParameter _Name_W = null;
            private WhereParameter _JSfileName_W = null;
            private WhereParameter _Version_W = null;
            private WhereParameter _Description_W = null;
            private WhereParameter _Settings_W = null;
            private WhereParameter _Css_W = null;
            private WhereParameter _JSinit_W = null;

            public void WhereClauseReset()
            {
                _IDPlugin_W = null;
                _Name_W = null;
                _JSfileName_W = null;
                _Version_W = null;
                _Description_W = null;
                _Settings_W = null;
                _Css_W = null;
                _JSinit_W = null;

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

                public AggregateParameter IDPlugin
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDPlugin, Parameters.IDPlugin);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Name
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Name, Parameters.Name);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter JSfileName
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.JSfileName, Parameters.JSfileName);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Version
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Version, Parameters.Version);
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

                public AggregateParameter Settings
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Settings, Parameters.Settings);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter Css
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.Css, Parameters.Css);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                public AggregateParameter JSinit
                {
                    get
                    {
                        AggregateParameter aggregate = new AggregateParameter(ColumnNames.JSinit, Parameters.JSinit);
                        this._clause._entity.Query.AddAggregateParameter(aggregate);
                        return aggregate;
                    }
                }

                private AggregateClause _clause;
            }
            #endregion

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

            public AggregateParameter Name
            {
                get
                {
                    if (_Name_W == null)
                    {
                        _Name_W = TearOff.Name;
                    }
                    return _Name_W;
                }
            }

            public AggregateParameter JSfileName
            {
                get
                {
                    if (_JSfileName_W == null)
                    {
                        _JSfileName_W = TearOff.JSfileName;
                    }
                    return _JSfileName_W;
                }
            }

            public AggregateParameter Version
            {
                get
                {
                    if (_Version_W == null)
                    {
                        _Version_W = TearOff.Version;
                    }
                    return _Version_W;
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

            public AggregateParameter Settings
            {
                get
                {
                    if (_Settings_W == null)
                    {
                        _Settings_W = TearOff.Settings;
                    }
                    return _Settings_W;
                }
            }

            public AggregateParameter Css
            {
                get
                {
                    if (_Css_W == null)
                    {
                        _Css_W = TearOff.Css;
                    }
                    return _Css_W;
                }
            }

            public AggregateParameter JSinit
            {
                get
                {
                    if (_JSinit_W == null)
                    {
                        _JSinit_W = TearOff.JSinit;
                    }
                    return _JSinit_W;
                }
            }

            private AggregateParameter _IDPlugin_W = null;
            private AggregateParameter _Name_W = null;
            private AggregateParameter _JSfileName_W = null;
            private AggregateParameter _Version_W = null;
            private AggregateParameter _Description_W = null;
            private AggregateParameter _Settings_W = null;
            private AggregateParameter _Css_W = null;
            private AggregateParameter _JSinit_W = null;

            public void AggregateClauseReset()
            {
                _IDPlugin_W = null;
                _Name_W = null;
                _JSfileName_W = null;
                _Version_W = null;
                _Description_W = null;
                _Settings_W = null;
                _Css_W = null;
                _JSinit_W = null;

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
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPluginsInsert]";

            CreateInsertParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetUpdateCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPluginsUpdate]";

            CreateUpdateParameters(cmd);

            return cmd;
        }

        protected override IDbCommand GetDeleteCommand()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPluginsDelete]";

            SqlParameter p;
            p = cmd.Parameters.Add(Parameters.IDPlugin);
            p.SourceColumn = ColumnNames.IDPlugin;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDPlugin);
            p.SourceColumn = ColumnNames.IDPlugin;
            p.SourceVersion = DataRowVersion.Current;
            p.Direction = ParameterDirection.Output;

            p = cmd.Parameters.Add(Parameters.Name);
            p.SourceColumn = ColumnNames.Name;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.JSfileName);
            p.SourceColumn = ColumnNames.JSfileName;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Version);
            p.SourceColumn = ColumnNames.Version;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Description);
            p.SourceColumn = ColumnNames.Description;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Settings);
            p.SourceColumn = ColumnNames.Settings;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Css);
            p.SourceColumn = ColumnNames.Css;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.JSinit);
            p.SourceColumn = ColumnNames.JSinit;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }

        protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
        {
            SqlParameter p;

            p = cmd.Parameters.Add(Parameters.IDPlugin);
            p.SourceColumn = ColumnNames.IDPlugin;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Name);
            p.SourceColumn = ColumnNames.Name;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.JSfileName);
            p.SourceColumn = ColumnNames.JSfileName;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Version);
            p.SourceColumn = ColumnNames.Version;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Description);
            p.SourceColumn = ColumnNames.Description;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Settings);
            p.SourceColumn = ColumnNames.Settings;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.Css);
            p.SourceColumn = ColumnNames.Css;
            p.SourceVersion = DataRowVersion.Current;

            p = cmd.Parameters.Add(Parameters.JSinit);
            p.SourceColumn = ColumnNames.JSinit;
            p.SourceVersion = DataRowVersion.Current;

            return cmd;
        }
    }
}
