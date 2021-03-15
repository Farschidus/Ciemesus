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
public abstract class _Members : SqlClientEntity
{
public _Members()
{
      this.QuerySource = "Ciemesus_tMembers";
      this.MappingName = "Ciemesus_tMembers";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tMembersLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDMember)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDMember, IDMember);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tMembersLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDMember
{
get
{
return new SqlParameter("@IDMember", SqlDbType.UniqueIdentifier, 0);}
}
public static SqlParameter FirstName
{
get
{
return new SqlParameter("@FirstName", SqlDbType.NVarChar, 50);}
}
public static SqlParameter LastName
{
get
{
return new SqlParameter("@LastName", SqlDbType.NVarChar, 50);}
}
}
#endregion

#region ColumnNames
public class ColumnNames
{
public const string IDMember = "IDMember";
public const string FirstName = "FirstName";
public const string LastName = "LastName";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDMember] = _Members.PropertyNames.IDMember;
ht[FirstName] = _Members.PropertyNames.FirstName;
ht[LastName] = _Members.PropertyNames.LastName;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDMember = "pIDMember";
public const string FirstName = "pFirstName";
public const string LastName = "pLastName";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDMember] = _Members.ColumnNames.IDMember;
ht[FirstName] = _Members.ColumnNames.FirstName;
ht[LastName] = _Members.ColumnNames.LastName;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDMember = "s_IDMember";
public const string FirstName = "s_FirstName";
public const string LastName = "s_LastName";
}
#endregion

#region Properties
public virtual Guid pIDMember
{
get
{
return base.GetGuid(ColumnNames.IDMember);
}
set
{
base.SetGuid(ColumnNames.IDMember, value);
}
}
public virtual string pFirstName
{
get
{
return base.Getstring(ColumnNames.FirstName);
}
set
{
base.Setstring(ColumnNames.FirstName, value);
}
}
public virtual string pLastName
{
get
{
return base.Getstring(ColumnNames.LastName);
}
set
{
base.Setstring(ColumnNames.LastName, value);
}
}
#endregion

#region String Properties
public virtual string s_IDMember
{
get
{
return this.IsColumnNull(ColumnNames.IDMember) ? string.Empty : base.GetGuidAsString(ColumnNames.IDMember);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDMember);
else
this.pIDMember = base.SetGuidAsString(ColumnNames.IDMember, value);
}
}

public virtual string s_FirstName
{
get
{
return this.IsColumnNull(ColumnNames.FirstName) ? string.Empty : base.GetstringAsString(ColumnNames.FirstName);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.FirstName);
else
this.pFirstName = base.SetstringAsString(ColumnNames.FirstName, value);
}
}

public virtual string s_LastName
{
get
{
return this.IsColumnNull(ColumnNames.LastName) ? string.Empty : base.GetstringAsString(ColumnNames.LastName);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.LastName);
else
this.pLastName = base.SetstringAsString(ColumnNames.LastName, value);
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

public WhereParameter IDMember
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDMember, Parameters.IDMember);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter FirstName
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.FirstName, Parameters.FirstName);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter LastName
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.LastName, Parameters.LastName);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}



private WhereClause _clause;
}
#endregion

public WhereParameter IDMember
{
get
{
if(_IDMember_W == null)
{
_IDMember_W = TearOff.IDMember;
}
return _IDMember_W;
}
}

public WhereParameter FirstName
{
get
{
if(_FirstName_W == null)
{
_FirstName_W = TearOff.FirstName;
}
return _FirstName_W;
}
}

public WhereParameter LastName
{
get
{
if(_LastName_W == null)
{
_LastName_W = TearOff.LastName;
}
return _LastName_W;
}
}


private WhereParameter _IDMember_W = null;
private WhereParameter _FirstName_W = null;
private WhereParameter _LastName_W = null;

public void WhereClauseReset()
{
_IDMember_W = null;
_FirstName_W = null;
_LastName_W = null;

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

public AggregateParameter IDMember
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDMember, Parameters.IDMember);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter FirstName
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.FirstName, Parameters.FirstName);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter LastName
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.LastName, Parameters.LastName);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

private AggregateClause _clause;
}
#endregion

public AggregateParameter IDMember
{
get
{
if(_IDMember_W == null)
{
_IDMember_W = TearOff.IDMember;
}
return _IDMember_W;
}
}

public AggregateParameter FirstName
{
get
{
if(_FirstName_W == null)
{
_FirstName_W = TearOff.FirstName;
}
return _FirstName_W;
}
}

public AggregateParameter LastName
{
get
{
if(_LastName_W == null)
{
_LastName_W = TearOff.LastName;
}
return _LastName_W;
}
}

private AggregateParameter _IDMember_W = null;
private AggregateParameter _FirstName_W = null;
private AggregateParameter _LastName_W = null;

public void AggregateClauseReset()
{
_IDMember_W = null;
_FirstName_W = null;
_LastName_W = null;

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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tMembersInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tMembersUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tMembersDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDMember);
p.SourceColumn = ColumnNames.IDMember;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDMember);
p.SourceColumn = ColumnNames.IDMember;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.FirstName);
p.SourceColumn = ColumnNames.FirstName;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.LastName);
p.SourceColumn = ColumnNames.LastName;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDMember);
p.SourceColumn = ColumnNames.IDMember;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.FirstName);
p.SourceColumn = ColumnNames.FirstName;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.LastName);
p.SourceColumn = ColumnNames.LastName;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
