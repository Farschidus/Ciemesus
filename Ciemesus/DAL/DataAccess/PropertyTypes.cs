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
public abstract class _PropertyTypes : SqlClientEntity
{
public _PropertyTypes()
{
      this.QuerySource = "Ciemesus_htPropertyTypes";
      this.MappingName = "Ciemesus_htPropertyTypes";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htPropertyTypesLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDType)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDType, IDType);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_htPropertyTypesLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDType
{
get
{
return new SqlParameter("@IDType", SqlDbType.TinyInt, 0);}
}
public static SqlParameter Name
{
get
{
return new SqlParameter("@Name", SqlDbType.NVarChar, 50);}
}
}
#endregion

#region ColumnNames
public class ColumnNames
{
public const string IDType = "IDType";
public const string Name = "Name";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDType] = _PropertyTypes.PropertyNames.IDType;
ht[Name] = _PropertyTypes.PropertyNames.Name;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDType = "pIDType";
public const string Name = "pName";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDType] = _PropertyTypes.ColumnNames.IDType;
ht[Name] = _PropertyTypes.ColumnNames.Name;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDType = "s_IDType";
public const string Name = "s_Name";
}
#endregion

#region Properties
public virtual byte pIDType
{
get
{
return base.Getbyte(ColumnNames.IDType);
}
set
{
base.Setbyte(ColumnNames.IDType, value);
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
#endregion

#region String Properties
public virtual string s_IDType
{
get
{
return this.IsColumnNull(ColumnNames.IDType) ? string.Empty : base.GetbyteAsString(ColumnNames.IDType);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDType);
else
this.pIDType = base.SetbyteAsString(ColumnNames.IDType, value);
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
if(string.Empty == value)
this.SetColumnNull(ColumnNames.Name);
else
this.pName = base.SetstringAsString(ColumnNames.Name, value);
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

public WhereParameter IDType
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDType, Parameters.IDType);
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



private WhereClause _clause;
}
#endregion

public WhereParameter IDType
{
get
{
if(_IDType_W == null)
{
_IDType_W = TearOff.IDType;
}
return _IDType_W;
}
}

public WhereParameter Name
{
get
{
if(_Name_W == null)
{
_Name_W = TearOff.Name;
}
return _Name_W;
}
}


private WhereParameter _IDType_W = null;
private WhereParameter _Name_W = null;

public void WhereClauseReset()
{
_IDType_W = null;
_Name_W = null;

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

public AggregateParameter IDType
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDType, Parameters.IDType);
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

private AggregateClause _clause;
}
#endregion

public AggregateParameter IDType
{
get
{
if(_IDType_W == null)
{
_IDType_W = TearOff.IDType;
}
return _IDType_W;
}
}

public AggregateParameter Name
{
get
{
if(_Name_W == null)
{
_Name_W = TearOff.Name;
}
return _Name_W;
}
}

private AggregateParameter _IDType_W = null;
private AggregateParameter _Name_W = null;

public void AggregateClauseReset()
{
_IDType_W = null;
_Name_W = null;

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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htPropertyTypesInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htPropertyTypesUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_htPropertyTypesDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDType);
p.SourceColumn = ColumnNames.IDType;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDType);
p.SourceColumn = ColumnNames.IDType;
p.SourceVersion = DataRowVersion.Current;
p.Direction = ParameterDirection.Output;

p = cmd.Parameters.Add(Parameters.Name);
p.SourceColumn = ColumnNames.Name;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDType);
p.SourceColumn = ColumnNames.IDType;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Name);
p.SourceColumn = ColumnNames.Name;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
