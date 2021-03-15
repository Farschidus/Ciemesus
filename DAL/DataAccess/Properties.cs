using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;
using DAL.DbAdapters;
using DAL.GlobalCore;

/// <summary>
/// Data Access Layer Class By Farschidus
/// Generate Date: 2/12/2014 3:05 AM
/// <summary>
namespace DAL.DataAccess
{
public abstract class _Properties : SqlClientEntity
{
public _Properties()
{
      this.QuerySource = "Ciemesus_tProperties";
      this.MappingName = "Ciemesus_tProperties";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tPropertiesLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDProperty)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDProperty, IDProperty);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tPropertiesLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDProperty
{
get
{
return new SqlParameter("@IDProperty", SqlDbType.Int, 0);}
}
public static SqlParameter IDLanguage
{
get
{
return new SqlParameter("@IDLanguage", SqlDbType.TinyInt, 0);}
}
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
public const string IDProperty = "IDProperty";
public const string IDLanguage = "IDLanguage";
public const string IDType = "IDType";
public const string Name = "Name";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDProperty] = _Properties.PropertyNames.IDProperty;
ht[IDLanguage] = _Properties.PropertyNames.IDLanguage;
ht[IDType] = _Properties.PropertyNames.IDType;
ht[Name] = _Properties.PropertyNames.Name;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDProperty = "pIDProperty";
public const string IDLanguage = "pIDLanguage";
public const string IDType = "pIDType";
public const string Name = "pName";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDProperty] = _Properties.ColumnNames.IDProperty;
ht[IDLanguage] = _Properties.ColumnNames.IDLanguage;
ht[IDType] = _Properties.ColumnNames.IDType;
ht[Name] = _Properties.ColumnNames.Name;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDProperty = "s_IDProperty";
public const string IDLanguage = "s_IDLanguage";
public const string IDType = "s_IDType";
public const string Name = "s_Name";
}
#endregion

#region Properties
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

public WhereParameter IDProperty
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDProperty, Parameters.IDProperty);
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


private WhereParameter _IDProperty_W = null;
private WhereParameter _IDLanguage_W = null;
private WhereParameter _IDType_W = null;
private WhereParameter _Name_W = null;

public void WhereClauseReset()
{
_IDProperty_W = null;
_IDLanguage_W = null;
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

public AggregateParameter IDProperty
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDProperty, Parameters.IDProperty);
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

private AggregateParameter _IDProperty_W = null;
private AggregateParameter _IDLanguage_W = null;
private AggregateParameter _IDType_W = null;
private AggregateParameter _Name_W = null;

public void AggregateClauseReset()
{
_IDProperty_W = null;
_IDLanguage_W = null;
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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPropertiesInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPropertiesUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPropertiesDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;
p.Direction = ParameterDirection.Output;

p = cmd.Parameters.Add(Parameters.IDLanguage);
p.SourceColumn = ColumnNames.IDLanguage;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IDType);
p.SourceColumn = ColumnNames.IDType;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Name);
p.SourceColumn = ColumnNames.Name;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IDLanguage);
p.SourceColumn = ColumnNames.IDLanguage;
p.SourceVersion = DataRowVersion.Current;

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
