using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 10/25/2012 2:32 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class SubjectPlugins : _SubjectPlugins
    {
        #region  "Constructors"

        public SubjectPlugins()
        {
        }
        public SubjectPlugins(Guid IDSubject, int IDPlugin)
        {
            this.LoadByPrimaryKey(IDSubject, IDPlugin);
        }

        #endregion

        #region  "Properties"

        private Plugins _plugins;
        public Plugins Plugins
        {
            get
            {
                if (_plugins == null || _plugins.pIDPlugin != this.pIDPlugin)
                {
                    _plugins = new Plugins();
                    _plugins.LoadByPrimaryKey(this.pIDPlugin);
                }
                return _plugins;
            }
            set
            {
                _plugins = value;
            }
        }

        private Subjects _subjects;
        public Subjects Subjects
        {
            get
            {
                if (_subjects == null || _subjects.pIDSubject != this.pIDSubject)
                {
                    _subjects = new Subjects();
                    _subjects.LoadByPrimaryKey(this.pIDSubject);
                }
                return _subjects;
            }
            set
            {
                _subjects = value;
            }
        }

        #endregion

        #region  "Methods"

        public bool LoadAll(int pageIndex, int pageSize, ref int totalRecords, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tSubjectPluginsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByIDSubject(Guid IDSubject)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDSubject, IDSubject);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDSubject = IDSubject", parameters, System.Data.CommandType.Text);
        }
        public bool LoadByIDPlugin(int IDPlugin)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDPlugin, IDPlugin);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDPlugin = IDPlugin", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, Guid? IDSubject, int? IDPlugin, string Options, string CSS, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDSubject.HasValue)
            {
                parameters.Add(new SqlParameter("@IDSubject", SqlDbType.UniqueIdentifier), IDSubject);
            }

            if (IDPlugin.HasValue)
            {
                parameters.Add(new SqlParameter("@IDPlugin", SqlDbType.Int), IDPlugin);
            }

            if (!string.IsNullOrEmpty(Options))
            {
                parameters.Add(new SqlParameter("@Options", SqlDbType.NVarChar), Options);
            }

            if (!string.IsNullOrEmpty(CSS))
            {
                parameters.Add(new SqlParameter("@CSS", SqlDbType.NVarChar), CSS);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tSubjectPluginsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
