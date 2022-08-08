using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 9/6/2012 5:43 PM
/// <summary>
namespace DAL.DataAccess
{
public abstract class _MediaSubjectTypes : SqlClientEntity
{
public _MediaSubjectTypes()
{
      this.QuerySource = "Ciemesus_htMediaSubjectTypes";
      this.MappingName = "Ciemesus_htMediaSubjectTypes";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htMediaSubjectTypesLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDMediaSubjectType)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDMediaSubjectType, IDMediaSubjectType);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htMediaSubjectTypesLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDMediaSubjectType
{
get
{
return new SqlParameter("@IDMediaSubjectType", SqlDbType.TinyInt, 0);}
}
public static SqlParameter Title
{
get
{
return new SqlParameter("@Title", SqlDbType.NVarChar, 50);}
}
}
#endregion

#region ColumnNames
public class ColumnNames
{
public const string IDMediaSubjectType = "IDMediaSubjectType";
public const string Title = "Title";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDMediaSubjectType] = _MediaSubjectTypes.PropertyNames.IDMediaSubjectType;
ht[Title] = _MediaSubjectTypes.PropertyNames.Title;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDMediaSubjectType = "pIDMediaSubjectType";
public const string Title = "pTitle";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDMediaSubjectType] = _MediaSubjectTypes.ColumnNames.IDMediaSubjectType;
ht[Title] = _MediaSubjectTypes.ColumnNames.Title;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDMediaSubjectType = "s_IDMediaSubjectType";
public const string Title = "s_Title";
}
#endregion

#region Properties
public virtual byte pIDMediaSubjectType
{
get
{
return base.Getbyte(ColumnNames.IDMediaSubjectType);
}
set
{
base.Setbyte(ColumnNames.IDMediaSubjectType, value);
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
#endregion

#region String Properties
public virtual string s_IDMediaSubjectType
{
get
{
return this.IsColumnNull(ColumnNames.IDMediaSubjectType) ? string.Empty : base.GetbyteAsString(ColumnNames.IDMediaSubjectType);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDMediaSubjectType);
else
this.pIDMediaSubjectType = base.SetbyteAsString(ColumnNames.IDMediaSubjectType, value);
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

public WhereParameter IDMediaSubjectType
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDMediaSubjectType, Parameters.IDMediaSubjectType);
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



private WhereClause _clause;
}
#endregion

public WhereParameter IDMediaSubjectType
{
get
{
if(_IDMediaSubjectType_W == null)
{
_IDMediaSubjectType_W = TearOff.IDMediaSubjectType;
}
return _IDMediaSubjectType_W;
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


private WhereParameter _IDMediaSubjectType_W = null;
private WhereParameter _Title_W = null;

public void WhereClauseReset()
{
_IDMediaSubjectType_W = null;
_Title_W = null;

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

public AggregateParameter IDMediaSubjectType
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDMediaSubjectType, Parameters.IDMediaSubjectType);
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

private AggregateClause _clause;
}
#endregion

public AggregateParameter IDMediaSubjectType
{
get
{
if(_IDMediaSubjectType_W == null)
{
_IDMediaSubjectType_W = TearOff.IDMediaSubjectType;
}
return _IDMediaSubjectType_W;
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

private AggregateParameter _IDMediaSubjectType_W = null;
private AggregateParameter _Title_W = null;

public void AggregateClauseReset()
{
_IDMediaSubjectType_W = null;
_Title_W = null;

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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htMediaSubjectTypesInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htMediaSubjectTypesUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htMediaSubjectTypesDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDMediaSubjectType);
p.SourceColumn = ColumnNames.IDMediaSubjectType;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDMediaSubjectType);
p.SourceColumn = ColumnNames.IDMediaSubjectType;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDMediaSubjectType);
p.SourceColumn = ColumnNames.IDMediaSubjectType;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
