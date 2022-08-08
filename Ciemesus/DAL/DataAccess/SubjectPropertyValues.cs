using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 2/11/2014 11:47 PM
/// <summary>
namespace DAL.DataAccess
{
public abstract class _SubjectPropertyValues : SqlClientEntity
{
public _SubjectPropertyValues()
{
      this.QuerySource = "Ciemesus_tSubjectPropertyValues";
      this.MappingName = "Ciemesus_tSubjectPropertyValues";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectPropertyValuesLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDSubject, object IDProperty)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDSubject, IDSubject);
parameters.Add(Parameters.IDProperty, IDProperty);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectPropertyValuesLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDSubject
{
get
{
return new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier, 0);}
}
public static SqlParameter IDProperty
{
get
{
return new SqlParameter("@IDProperty", SqlDbType.Int, 0);}
}
public static SqlParameter Value
{
get
{
return new SqlParameter("@Value", SqlDbType.NVarChar, 50);}
}
}
#endregion

#region ColumnNames
public class ColumnNames
{
public const string IDSubject = "IDSubject";
public const string IDProperty = "IDProperty";
public const string Value = "Value";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDSubject] = _SubjectPropertyValues.PropertyNames.IDSubject;
ht[IDProperty] = _SubjectPropertyValues.PropertyNames.IDProperty;
ht[Value] = _SubjectPropertyValues.PropertyNames.Value;
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
public const string IDProperty = "pIDProperty";
public const string Value = "pValue";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDSubject] = _SubjectPropertyValues.ColumnNames.IDSubject;
ht[IDProperty] = _SubjectPropertyValues.ColumnNames.IDProperty;
ht[Value] = _SubjectPropertyValues.ColumnNames.Value;

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
public const string IDProperty = "s_IDProperty";
public const string Value = "s_Value";
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
public virtual int pIDProperty
{
get
{
return base.Getint(ColumnNames.IDProperty);
}
set
{
base.Setint(ColumnNames.IDProperty, value);
}
}
public virtual string pValue
{
get
{
return base.Getstring(ColumnNames.Value);
}
set
{
base.Setstring(ColumnNames.Value, value);
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
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDSubject);
else
this.pIDSubject = base.SetGuidAsString(ColumnNames.IDSubject, value);
}
}

public virtual string s_IDProperty
{
get
{
return this.IsColumnNull(ColumnNames.IDProperty) ? string.Empty : base.GetintAsString(ColumnNames.IDProperty);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDProperty);
else
this.pIDProperty = base.SetintAsString(ColumnNames.IDProperty, value);
}
}

public virtual string s_Value
{
get
{
return this.IsColumnNull(ColumnNames.Value) ? string.Empty : base.GetstringAsString(ColumnNames.Value);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.Value);
else
this.pValue = base.SetstringAsString(ColumnNames.Value, value);
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

public WhereParameter IDSubject
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDSubject, Parameters.IDSubject);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter IDProperty
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDProperty, Parameters.IDProperty);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter Value
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.Value, Parameters.Value);
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
if(_IDSubject_W == null)
{
_IDSubject_W = TearOff.IDSubject;
}
return _IDSubject_W;
}
}

public WhereParameter IDProperty
{
get
{
if(_IDProperty_W == null)
{
_IDProperty_W = TearOff.IDProperty;
}
return _IDProperty_W;
}
}

public WhereParameter Value
{
get
{
if(_Value_W == null)
{
_Value_W = TearOff.Value;
}
return _Value_W;
}
}


private WhereParameter _IDSubject_W = null;
private WhereParameter _IDProperty_W = null;
private WhereParameter _Value_W = null;

public void WhereClauseReset()
{
_IDSubject_W = null;
_IDProperty_W = null;
_Value_W = null;

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

public AggregateParameter IDSubject
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDSubject, Parameters.IDSubject);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter IDProperty
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDProperty, Parameters.IDProperty);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter Value
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.Value, Parameters.Value);
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
if(_IDSubject_W == null)
{
_IDSubject_W = TearOff.IDSubject;
}
return _IDSubject_W;
}
}

public AggregateParameter IDProperty
{
get
{
if(_IDProperty_W == null)
{
_IDProperty_W = TearOff.IDProperty;
}
return _IDProperty_W;
}
}

public AggregateParameter Value
{
get
{
if(_Value_W == null)
{
_Value_W = TearOff.Value;
}
return _Value_W;
}
}

private AggregateParameter _IDSubject_W = null;
private AggregateParameter _IDProperty_W = null;
private AggregateParameter _Value_W = null;

public void AggregateClauseReset()
{
_IDSubject_W = null;
_IDProperty_W = null;
_Value_W = null;

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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectPropertyValuesInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectPropertyValuesUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tSubjectPropertyValuesDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDSubject);
p.SourceColumn = ColumnNames.IDSubject;
p.SourceVersion = DataRowVersion.Current;
p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDSubject);
p.SourceColumn = ColumnNames.IDSubject;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Value);
p.SourceColumn = ColumnNames.Value;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDSubject);
p.SourceColumn = ColumnNames.IDSubject;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Value);
p.SourceColumn = ColumnNames.Value;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
