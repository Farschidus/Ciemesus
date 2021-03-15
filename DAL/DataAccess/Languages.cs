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
public abstract class _Languages : SqlClientEntity
{
public _Languages()
{
      this.QuerySource = "Ciemesus_htLanguages";
      this.MappingName = "Ciemesus_htLanguages";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htLanguagesLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDLanguage)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDLanguage, IDLanguage);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htLanguagesLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDLanguage
{
get
{
return new SqlParameter("@IDLanguage", SqlDbType.TinyInt, 0);}
}
public static SqlParameter Title
{
get
{
return new SqlParameter("@Title", SqlDbType.NVarChar, 100);}
}
public static SqlParameter Code
{
get
{
return new SqlParameter("@Code", SqlDbType.NVarChar, 50);}
}
public static SqlParameter IsRTL
{
get
{
return new SqlParameter("@IsRTL", SqlDbType.Bit, 0);}
}
public static SqlParameter IsActive
{
get
{
return new SqlParameter("@IsActive", SqlDbType.Bit, 0);}
}
public static SqlParameter IsDefault
{
get
{
return new SqlParameter("@IsDefault", SqlDbType.Bit, 0);}
}
public static SqlParameter Priority
{
get
{
return new SqlParameter("@Priority", SqlDbType.Int, 0);}
}
}
#endregion

#region ColumnNames
public class ColumnNames
{
public const string IDLanguage = "IDLanguage";
public const string Title = "Title";
public const string Code = "Code";
public const string IsRTL = "IsRTL";
public const string IsActive = "IsActive";
public const string IsDefault = "IsDefault";
public const string Priority = "Priority";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDLanguage] = _Languages.PropertyNames.IDLanguage;
ht[Title] = _Languages.PropertyNames.Title;
ht[Code] = _Languages.PropertyNames.Code;
ht[IsRTL] = _Languages.PropertyNames.IsRTL;
ht[IsActive] = _Languages.PropertyNames.IsActive;
ht[IsDefault] = _Languages.PropertyNames.IsDefault;
ht[Priority] = _Languages.PropertyNames.Priority;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDLanguage = "pIDLanguage";
public const string Title = "pTitle";
public const string Code = "pCode";
public const string IsRTL = "pIsRTL";
public const string IsActive = "pIsActive";
public const string IsDefault = "pIsDefault";
public const string Priority = "pPriority";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDLanguage] = _Languages.ColumnNames.IDLanguage;
ht[Title] = _Languages.ColumnNames.Title;
ht[Code] = _Languages.ColumnNames.Code;
ht[IsRTL] = _Languages.ColumnNames.IsRTL;
ht[IsActive] = _Languages.ColumnNames.IsActive;
ht[IsDefault] = _Languages.ColumnNames.IsDefault;
ht[Priority] = _Languages.ColumnNames.Priority;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDLanguage = "s_IDLanguage";
public const string Title = "s_Title";
public const string Code = "s_Code";
public const string IsRTL = "s_IsRTL";
public const string IsActive = "s_IsActive";
public const string IsDefault = "s_IsDefault";
public const string Priority = "s_Priority";
}
#endregion

#region Properties
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
public virtual string pCode
{
get
{
return base.Getstring(ColumnNames.Code);
}
set
{
base.Setstring(ColumnNames.Code, value);
}
}
public virtual bool pIsRTL
{
get
{
return base.Getbool(ColumnNames.IsRTL);
}
set
{
base.Setbool(ColumnNames.IsRTL, value);
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
public virtual bool pIsDefault
{
get
{
return base.Getbool(ColumnNames.IsDefault);
}
set
{
base.Setbool(ColumnNames.IsDefault, value);
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
public virtual string s_IDLanguage
{
get
{
return this.IsColumnNull(ColumnNames.IDLanguage) ? string.Empty : base.GetbyteAsString(ColumnNames.IDLanguage);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDLanguage);
else
this.pIDLanguage = base.SetbyteAsString(ColumnNames.IDLanguage, value);
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
if(string.Empty == value)
this.SetColumnNull(ColumnNames.Title);
else
this.pTitle = base.SetstringAsString(ColumnNames.Title, value);
}
}

public virtual string s_Code
{
get
{
return this.IsColumnNull(ColumnNames.Code) ? string.Empty : base.GetstringAsString(ColumnNames.Code);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.Code);
else
this.pCode = base.SetstringAsString(ColumnNames.Code, value);
}
}

public virtual string s_IsRTL
{
get
{
return this.IsColumnNull(ColumnNames.IsRTL) ? string.Empty : base.GetboolAsString(ColumnNames.IsRTL);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IsRTL);
else
this.pIsRTL = base.SetboolAsString(ColumnNames.IsRTL, value);
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
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IsActive);
else
this.pIsActive = base.SetboolAsString(ColumnNames.IsActive, value);
}
}

public virtual string s_IsDefault
{
get
{
return this.IsColumnNull(ColumnNames.IsDefault) ? string.Empty : base.GetboolAsString(ColumnNames.IsDefault);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IsDefault);
else
this.pIsDefault = base.SetboolAsString(ColumnNames.IsDefault, value);
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
if(string.Empty == value)
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
if(_tearOff == null)
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

public WhereParameter IDLanguage
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDLanguage, Parameters.IDLanguage);
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

public WhereParameter Code
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.Code, Parameters.Code);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter IsRTL
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IsRTL, Parameters.IsRTL);
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

public WhereParameter IsDefault
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IsDefault, Parameters.IsDefault);
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

public WhereParameter IDLanguage
{
get
{
if(_IDLanguage_W == null)
{
_IDLanguage_W = TearOff.IDLanguage;
}
return _IDLanguage_W;
}
}

public WhereParameter Title
{
get
{
if(_Title_W == null)
{
_Title_W = TearOff.Title;
}
return _Title_W;
}
}

public WhereParameter Code
{
get
{
if(_Code_W == null)
{
_Code_W = TearOff.Code;
}
return _Code_W;
}
}

public WhereParameter IsRTL
{
get
{
if(_IsRTL_W == null)
{
_IsRTL_W = TearOff.IsRTL;
}
return _IsRTL_W;
}
}

public WhereParameter IsActive
{
get
{
if(_IsActive_W == null)
{
_IsActive_W = TearOff.IsActive;
}
return _IsActive_W;
}
}

public WhereParameter IsDefault
{
get
{
if(_IsDefault_W == null)
{
_IsDefault_W = TearOff.IsDefault;
}
return _IsDefault_W;
}
}

public WhereParameter Priority
{
get
{
if(_Priority_W == null)
{
_Priority_W = TearOff.Priority;
}
return _Priority_W;
}
}


private WhereParameter _IDLanguage_W = null;
private WhereParameter _Title_W = null;
private WhereParameter _Code_W = null;
private WhereParameter _IsRTL_W = null;
private WhereParameter _IsActive_W = null;
private WhereParameter _IsDefault_W = null;
private WhereParameter _Priority_W = null;

public void WhereClauseReset()
{
_IDLanguage_W = null;
_Title_W = null;
_Code_W = null;
_IsRTL_W = null;
_IsActive_W = null;
_IsDefault_W = null;
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
if(_whereClause == null)
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
if(_tearOff == null)
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

public AggregateParameter IDLanguage
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDLanguage, Parameters.IDLanguage);
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

public AggregateParameter Code
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.Code, Parameters.Code);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter IsRTL
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IsRTL, Parameters.IsRTL);
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

public AggregateParameter IsDefault
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IsDefault, Parameters.IsDefault);
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

public AggregateParameter IDLanguage
{
get
{
if(_IDLanguage_W == null)
{
_IDLanguage_W = TearOff.IDLanguage;
}
return _IDLanguage_W;
}
}

public AggregateParameter Title
{
get
{
if(_Title_W == null)
{
_Title_W = TearOff.Title;
}
return _Title_W;
}
}

public AggregateParameter Code
{
get
{
if(_Code_W == null)
{
_Code_W = TearOff.Code;
}
return _Code_W;
}
}

public AggregateParameter IsRTL
{
get
{
if(_IsRTL_W == null)
{
_IsRTL_W = TearOff.IsRTL;
}
return _IsRTL_W;
}
}

public AggregateParameter IsActive
{
get
{
if(_IsActive_W == null)
{
_IsActive_W = TearOff.IsActive;
}
return _IsActive_W;
}
}

public AggregateParameter IsDefault
{
get
{
if(_IsDefault_W == null)
{
_IsDefault_W = TearOff.IsDefault;
}
return _IsDefault_W;
}
}

public AggregateParameter Priority
{
get
{
if(_Priority_W == null)
{
_Priority_W = TearOff.Priority;
}
return _Priority_W;
}
}

private AggregateParameter _IDLanguage_W = null;
private AggregateParameter _Title_W = null;
private AggregateParameter _Code_W = null;
private AggregateParameter _IsRTL_W = null;
private AggregateParameter _IsActive_W = null;
private AggregateParameter _IsDefault_W = null;
private AggregateParameter _Priority_W = null;

public void AggregateClauseReset()
{
_IDLanguage_W = null;
_Title_W = null;
_Code_W = null;
_IsRTL_W = null;
_IsActive_W = null;
_IsDefault_W = null;
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
if(_aggregateClause == null)
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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htLanguagesInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htLanguagesUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htLanguagesDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDLanguage);
p.SourceColumn = ColumnNames.IDLanguage;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDLanguage);
p.SourceColumn = ColumnNames.IDLanguage;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Code);
p.SourceColumn = ColumnNames.Code;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IsRTL);
p.SourceColumn = ColumnNames.IsRTL;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IsActive);
p.SourceColumn = ColumnNames.IsActive;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IsDefault);
p.SourceColumn = ColumnNames.IsDefault;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Priority);
p.SourceColumn = ColumnNames.Priority;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDLanguage);
p.SourceColumn = ColumnNames.IDLanguage;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Code);
p.SourceColumn = ColumnNames.Code;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IsRTL);
p.SourceColumn = ColumnNames.IsRTL;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IsActive);
p.SourceColumn = ColumnNames.IsActive;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IsDefault);
p.SourceColumn = ColumnNames.IsDefault;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Priority);
p.SourceColumn = ColumnNames.Priority;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
