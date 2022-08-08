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
public abstract class _PropertyItems : SqlClientEntity
{
public _PropertyItems()
{
      this.QuerySource = "Ciemesus_tPropertyItems";
      this.MappingName = "Ciemesus_tPropertyItems";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tPropertyItemsLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDPropertyItem)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDPropertyItem, IDPropertyItem);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tPropertyItemsLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDPropertyItem
{
get
{
return new SqlParameter("@IDPropertyItem", SqlDbType.Int, 0);}
}
public static SqlParameter IDProperty
{
get
{
return new SqlParameter("@IDProperty", SqlDbType.Int, 0);}
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
public const string IDPropertyItem = "IDPropertyItem";
public const string IDProperty = "IDProperty";
public const string Title = "Title";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDPropertyItem] = _PropertyItems.PropertyNames.IDPropertyItem;
ht[IDProperty] = _PropertyItems.PropertyNames.IDProperty;
ht[Title] = _PropertyItems.PropertyNames.Title;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDPropertyItem = "pIDPropertyItem";
public const string IDProperty = "pIDProperty";
public const string Title = "pTitle";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDPropertyItem] = _PropertyItems.ColumnNames.IDPropertyItem;
ht[IDProperty] = _PropertyItems.ColumnNames.IDProperty;
ht[Title] = _PropertyItems.ColumnNames.Title;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDPropertyItem = "s_IDPropertyItem";
public const string IDProperty = "s_IDProperty";
public const string Title = "s_Title";
}
#endregion

#region Properties
public virtual int pIDPropertyItem
{
get
{
return base.Getint(ColumnNames.IDPropertyItem);
}
set
{
base.Setint(ColumnNames.IDPropertyItem, value);
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
public virtual string s_IDPropertyItem
{
get
{
return this.IsColumnNull(ColumnNames.IDPropertyItem) ? string.Empty : base.GetintAsString(ColumnNames.IDPropertyItem);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDPropertyItem);
else
this.pIDPropertyItem = base.SetintAsString(ColumnNames.IDPropertyItem, value);
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

public WhereParameter IDPropertyItem
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDPropertyItem, Parameters.IDPropertyItem);
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

public WhereParameter IDPropertyItem
{
get
{
if(_IDPropertyItem_W == null)
{
_IDPropertyItem_W = TearOff.IDPropertyItem;
}
return _IDPropertyItem_W;
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


private WhereParameter _IDPropertyItem_W = null;
private WhereParameter _IDProperty_W = null;
private WhereParameter _Title_W = null;

public void WhereClauseReset()
{
_IDPropertyItem_W = null;
_IDProperty_W = null;
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

public AggregateParameter IDPropertyItem
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDPropertyItem, Parameters.IDPropertyItem);
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

public AggregateParameter IDPropertyItem
{
get
{
if(_IDPropertyItem_W == null)
{
_IDPropertyItem_W = TearOff.IDPropertyItem;
}
return _IDPropertyItem_W;
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

private AggregateParameter _IDPropertyItem_W = null;
private AggregateParameter _IDProperty_W = null;
private AggregateParameter _Title_W = null;

public void AggregateClauseReset()
{
_IDPropertyItem_W = null;
_IDProperty_W = null;
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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPropertyItemsInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPropertyItemsUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tPropertyItemsDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDPropertyItem);
p.SourceColumn = ColumnNames.IDPropertyItem;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDPropertyItem);
p.SourceColumn = ColumnNames.IDPropertyItem;
p.SourceVersion = DataRowVersion.Current;
p.Direction = ParameterDirection.Output;

p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDPropertyItem);
p.SourceColumn = ColumnNames.IDPropertyItem;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.IDProperty);
p.SourceColumn = ColumnNames.IDProperty;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.Title);
p.SourceColumn = ColumnNames.Title;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
