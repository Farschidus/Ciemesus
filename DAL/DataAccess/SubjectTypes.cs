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
public abstract class _SubjectTypes : SqlClientEntity
{
public _SubjectTypes()
{
      this.QuerySource = "Ciemesus_htSubjectTypes";
      this.MappingName = "Ciemesus_htSubjectTypes";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htSubjectTypesLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDSubjectType)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDSubjectType, IDSubjectType);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htSubjectTypesLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDSubjectType
{
get
{
return new SqlParameter("@IDSubjectType", SqlDbType.TinyInt, 0);}
}
public static SqlParameter Title
{
get
{
return new SqlParameter("@Title", SqlDbType.NVarChar, 50);}
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
public const string IDSubjectType = "IDSubjectType";
public const string Title = "Title";
public const string Priority = "Priority";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDSubjectType] = _SubjectTypes.PropertyNames.IDSubjectType;
ht[Title] = _SubjectTypes.PropertyNames.Title;
ht[Priority] = _SubjectTypes.PropertyNames.Priority;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDSubjectType = "pIDSubjectType";
public const string Title = "pTitle";
public const string Priority = "pPriority";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDSubjectType] = _SubjectTypes.ColumnNames.IDSubjectType;
ht[Title] = _SubjectTypes.ColumnNames.Title;
ht[Priority] = _SubjectTypes.ColumnNames.Priority;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDSubjectType = "s_IDSubjectType";
public const string Title = "s_Title";
public const string Priority = "s_Priority";
}
#endregion

#region Properties
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
public virtual string s_IDSubjectType
{
get
{
return this.IsColumnNull(ColumnNames.IDSubjectType) ? string.Empty : base.GetbyteAsString(ColumnNames.IDSubjectType);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDSubjectType);
else
this.pIDSubjectType = base.SetbyteAsString(ColumnNames.IDSubjectType, value);
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

public WhereParameter IDSubjectType
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDSubjectType, Parameters.IDSubjectType);
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

public WhereParameter IDSubjectType
{
get
{
if(_IDSubjectType_W == null)
{
_IDSubjectType_W = TearOff.IDSubjectType;
}
return _IDSubjectType_W;
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


private WhereParameter _IDSubjectType_W = null;
private WhereParameter _Title_W = null;
private WhereParameter _Priority_W = null;

public void WhereClauseReset()
{
_IDSubjectType_W = null;
_Title_W = null;
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

public AggregateParameter IDSubjectType
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDSubjectType, Parameters.IDSubjectType);
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

public AggregateParameter IDSubjectType
{
get
{
if(_IDSubjectType_W == null)
{
_IDSubjectType_W = TearOff.IDSubjectType;
}
return _IDSubjectType_W;
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

private AggregateParameter _IDSubjectType_W = null;
private AggregateParameter _Title_W = null;
private AggregateParameter _Priority_W = null;

public void AggregateClauseReset()
{
_IDSubjectType_W = null;
_Title_W = null;
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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htSubjectTypesInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htSubjectTypesUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htSubjectTypesDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDSubjectType);
p.SourceColumn = ColumnNames.IDSubjectType;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDSubjectType);
p.SourceColumn = ColumnNames.IDSubjectType;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Priority);
p.SourceColumn = ColumnNames.Priority;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDSubjectType);
p.SourceColumn = ColumnNames.IDSubjectType;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Priority);
p.SourceColumn = ColumnNames.Priority;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
