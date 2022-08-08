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
public abstract class _Logs : SqlClientEntity
{
public _Logs()
{
      this.QuerySource = "Ciemesus_tLogs";
      this.MappingName = "Ciemesus_tLogs";
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

      return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tLogsLoadAll]", parameters);
}

//=================================================================
// public Overridable Function LoadByPrimaryKey()  As Boolean
//=================================================================
//  Loads a single row of via the primary key
//=================================================================
public override bool LoadByPrimaryKey(object IDLog)
{
ListDictionary parameters = new ListDictionary();
parameters.Add(Parameters.IDLog, IDLog);

return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Ciemesus_tLogsLoadByPrimaryKey]", parameters);
}

#region Parameters
protected class Parameters
{
public static SqlParameter IDLog
{
get
{
return new SqlParameter("@IDLog", SqlDbType.BigInt, 0);}
}
public static SqlParameter ModuleName
{
get
{
return new SqlParameter("@ModuleName", SqlDbType.NVarChar, 128);}
}
public static SqlParameter XML
{
get
{
return new SqlParameter("@XML", SqlDbType.Xml, 1073741823);}
}
public static SqlParameter CreationDate
{
get
{
return new SqlParameter("@CreationDate", SqlDbType.DateTime, 0);}
}
public static SqlParameter UserID
{
get
{
return new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, 0);}
}
public static SqlParameter UserFullName
{
get
{
return new SqlParameter("@UserFullName", SqlDbType.NVarChar, 50);}
}
}
#endregion

#region ColumnNames
public class ColumnNames
{
public const string IDLog = "IDLog";
public const string ModuleName = "ModuleName";
public const string XML = "XML";
public const string CreationDate = "CreationDate";
public const string UserID = "UserID";
public const string UserFullName = "UserFullName";

static public string ToPropertyName(string columnName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDLog] = _Logs.PropertyNames.IDLog;
ht[ModuleName] = _Logs.PropertyNames.ModuleName;
ht[XML] = _Logs.PropertyNames.XML;
ht[CreationDate] = _Logs.PropertyNames.CreationDate;
ht[UserID] = _Logs.PropertyNames.UserID;
ht[UserFullName] = _Logs.PropertyNames.UserFullName;
}
return (string)ht[columnName];
}

static private Hashtable ht = null;
}
#endregion

#region PropertyNames
public class PropertyNames
{

public const string IDLog = "pIDLog";
public const string ModuleName = "pModuleName";
public const string XML = "pXML";
public const string CreationDate = "pCreationDate";
public const string UserID = "pUserID";
public const string UserFullName = "pUserFullName";

static public string ToColumnName(string propertyName)
{
if(ht == null)
{
ht = new Hashtable();
ht[IDLog] = _Logs.ColumnNames.IDLog;
ht[ModuleName] = _Logs.ColumnNames.ModuleName;
ht[XML] = _Logs.ColumnNames.XML;
ht[CreationDate] = _Logs.ColumnNames.CreationDate;
ht[UserID] = _Logs.ColumnNames.UserID;
ht[UserFullName] = _Logs.ColumnNames.UserFullName;

}
return (string)ht[propertyName];
}

static private Hashtable ht = null;
}
#endregion

#region StringPropertyNames
public class StringPropertyNames
{
public const string IDLog = "s_IDLog";
public const string ModuleName = "s_ModuleName";
public const string XML = "s_XML";
public const string CreationDate = "s_CreationDate";
public const string UserID = "s_UserID";
public const string UserFullName = "s_UserFullName";
}
#endregion

#region Properties
public virtual long pIDLog
{
get
{
return base.Getlong(ColumnNames.IDLog);
}
set
{
base.Setlong(ColumnNames.IDLog, value);
}
}
public virtual string pModuleName
{
get
{
return base.Getstring(ColumnNames.ModuleName);
}
set
{
base.Setstring(ColumnNames.ModuleName, value);
}
}
public virtual string pXML
{
get
{
return base.Getstring(ColumnNames.XML);
}
set
{
base.Setstring(ColumnNames.XML, value);
}
}
public virtual DateTime pCreationDate
{
get
{
return base.GetDateTime(ColumnNames.CreationDate);
}
set
{
base.SetDateTime(ColumnNames.CreationDate, value);
}
}
public virtual Guid pUserID
{
get
{
return base.GetGuid(ColumnNames.UserID);
}
set
{
base.SetGuid(ColumnNames.UserID, value);
}
}
public virtual string pUserFullName
{
get
{
return base.Getstring(ColumnNames.UserFullName);
}
set
{
base.Setstring(ColumnNames.UserFullName, value);
}
}
#endregion

#region String Properties
public virtual string s_IDLog
{
get
{
return this.IsColumnNull(ColumnNames.IDLog) ? string.Empty : base.GetlongAsString(ColumnNames.IDLog);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.IDLog);
else
this.pIDLog = base.SetlongAsString(ColumnNames.IDLog, value);
}
}

public virtual string s_ModuleName
{
get
{
return this.IsColumnNull(ColumnNames.ModuleName) ? string.Empty : base.GetstringAsString(ColumnNames.ModuleName);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.ModuleName);
else
this.pModuleName = base.SetstringAsString(ColumnNames.ModuleName, value);
}
}

public virtual string s_XML
{
get
{
return this.IsColumnNull(ColumnNames.XML) ? string.Empty : base.GetstringAsString(ColumnNames.XML);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.XML);
else
this.pXML = base.SetstringAsString(ColumnNames.XML, value);
}
}

public virtual string s_CreationDate
{
get
{
return this.IsColumnNull(ColumnNames.CreationDate) ? string.Empty : base.GetDateTimeAsString(ColumnNames.CreationDate);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.CreationDate);
else
this.pCreationDate = base.SetDateTimeAsString(ColumnNames.CreationDate, value);
}
}

public virtual string s_UserID
{
get
{
return this.IsColumnNull(ColumnNames.UserID) ? string.Empty : base.GetGuidAsString(ColumnNames.UserID);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.UserID);
else
this.pUserID = base.SetGuidAsString(ColumnNames.UserID, value);
}
}

public virtual string s_UserFullName
{
get
{
return this.IsColumnNull(ColumnNames.UserFullName) ? string.Empty : base.GetstringAsString(ColumnNames.UserFullName);
}
set
{
if(string.Empty == value)
this.SetColumnNull(ColumnNames.UserFullName);
else
this.pUserFullName = base.SetstringAsString(ColumnNames.UserFullName, value);
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

public WhereParameter IDLog
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.IDLog, Parameters.IDLog);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter ModuleName
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.ModuleName, Parameters.ModuleName);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter XML
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.XML, Parameters.XML);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter CreationDate
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.CreationDate, Parameters.CreationDate);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter UserID
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.UserID, Parameters.UserID);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}

public WhereParameter UserFullName
{
get
{
WhereParameter where = new WhereParameter(ColumnNames.UserFullName, Parameters.UserFullName);
this._clause._entity.Query.AddWhereParameter(where);
return where;
}
}



private WhereClause _clause;
}
#endregion

public WhereParameter IDLog
{
get
{
if(_IDLog_W == null)
{
_IDLog_W = TearOff.IDLog;
}
return _IDLog_W;
}
}

public WhereParameter ModuleName
{
get
{
if(_ModuleName_W == null)
{
_ModuleName_W = TearOff.ModuleName;
}
return _ModuleName_W;
}
}

public WhereParameter XML
{
get
{
if(_XML_W == null)
{
_XML_W = TearOff.XML;
}
return _XML_W;
}
}

public WhereParameter CreationDate
{
get
{
if(_CreationDate_W == null)
{
_CreationDate_W = TearOff.CreationDate;
}
return _CreationDate_W;
}
}

public WhereParameter UserID
{
get
{
if(_UserID_W == null)
{
_UserID_W = TearOff.UserID;
}
return _UserID_W;
}
}

public WhereParameter UserFullName
{
get
{
if(_UserFullName_W == null)
{
_UserFullName_W = TearOff.UserFullName;
}
return _UserFullName_W;
}
}


private WhereParameter _IDLog_W = null;
private WhereParameter _ModuleName_W = null;
private WhereParameter _XML_W = null;
private WhereParameter _CreationDate_W = null;
private WhereParameter _UserID_W = null;
private WhereParameter _UserFullName_W = null;

public void WhereClauseReset()
{
_IDLog_W = null;
_ModuleName_W = null;
_XML_W = null;
_CreationDate_W = null;
_UserID_W = null;
_UserFullName_W = null;

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

public AggregateParameter IDLog
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.IDLog, Parameters.IDLog);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter ModuleName
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.ModuleName, Parameters.ModuleName);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter XML
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.XML, Parameters.XML);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter CreationDate
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.CreationDate, Parameters.CreationDate);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter UserID
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.UserID, Parameters.UserID);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

public AggregateParameter UserFullName
{
get
{
AggregateParameter aggregate = new AggregateParameter(ColumnNames.UserFullName, Parameters.UserFullName);
this._clause._entity.Query.AddAggregateParameter(aggregate);
return aggregate;
}
}

private AggregateClause _clause;
}
#endregion

public AggregateParameter IDLog
{
get
{
if(_IDLog_W == null)
{
_IDLog_W = TearOff.IDLog;
}
return _IDLog_W;
}
}

public AggregateParameter ModuleName
{
get
{
if(_ModuleName_W == null)
{
_ModuleName_W = TearOff.ModuleName;
}
return _ModuleName_W;
}
}

public AggregateParameter XML
{
get
{
if(_XML_W == null)
{
_XML_W = TearOff.XML;
}
return _XML_W;
}
}

public AggregateParameter CreationDate
{
get
{
if(_CreationDate_W == null)
{
_CreationDate_W = TearOff.CreationDate;
}
return _CreationDate_W;
}
}

public AggregateParameter UserID
{
get
{
if(_UserID_W == null)
{
_UserID_W = TearOff.UserID;
}
return _UserID_W;
}
}

public AggregateParameter UserFullName
{
get
{
if(_UserFullName_W == null)
{
_UserFullName_W = TearOff.UserFullName;
}
return _UserFullName_W;
}
}

private AggregateParameter _IDLog_W = null;
private AggregateParameter _ModuleName_W = null;
private AggregateParameter _XML_W = null;
private AggregateParameter _CreationDate_W = null;
private AggregateParameter _UserID_W = null;
private AggregateParameter _UserFullName_W = null;

public void AggregateClauseReset()
{
_IDLog_W = null;
_ModuleName_W = null;
_XML_W = null;
_CreationDate_W = null;
_UserID_W = null;
_UserFullName_W = null;

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
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tLogsInsert]";

CreateInsertParameters(cmd);

return cmd;
}

protected override IDbCommand GetUpdateCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tLogsUpdate]";

CreateUpdateParameters(cmd);

return cmd;
}

protected override IDbCommand GetDeleteCommand()
{

SqlCommand cmd = new SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "[" + this.SchemaStoredProcedure + "Ciemesus_tLogsDelete]";

SqlParameter p;
p = cmd.Parameters.Add(Parameters.IDLog);
p.SourceColumn = ColumnNames.IDLog;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateInsertParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDLog);
p.SourceColumn = ColumnNames.IDLog;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.ModuleName);
p.SourceColumn = ColumnNames.ModuleName;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.XML);
p.SourceColumn = ColumnNames.XML;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.CreationDate);
p.SourceColumn = ColumnNames.CreationDate;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.UserID);
p.SourceColumn = ColumnNames.UserID;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.UserFullName);
p.SourceColumn = ColumnNames.UserFullName;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}

protected virtual IDbCommand CreateUpdateParameters(SqlCommand cmd)
{
SqlParameter p;

p = cmd.Parameters.Add(Parameters.IDLog);
p.SourceColumn = ColumnNames.IDLog;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.ModuleName);
p.SourceColumn = ColumnNames.ModuleName;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.XML);
p.SourceColumn = ColumnNames.XML;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.CreationDate);
p.SourceColumn = ColumnNames.CreationDate;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.UserID);
p.SourceColumn = ColumnNames.UserID;
p.SourceVersion = DataRowVersion.Current;

p = cmd.Parameters.Add(Parameters.UserFullName);
p.SourceColumn = ColumnNames.UserFullName;
p.SourceVersion = DataRowVersion.Current;

return cmd;
}
}
}
