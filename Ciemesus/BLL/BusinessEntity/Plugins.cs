using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 9/21/2012 1:59 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Plugins : _Plugins
    {
        #region  "Constructors"

        public Plugins()
        {
        }
        public Plugins(int IDPlugin)
        {
            this.LoadByPrimaryKey(IDPlugin);
        }

        #endregion

        #region  "Properties"

        private GalleryPlugins _GalleryPlugins;
        public GalleryPlugins GalleryPlugins
        {
            get
            {
                if (_GalleryPlugins == null || _GalleryPlugins.pIDPlugin != this.pIDPlugin)
                {
                    _GalleryPlugins = new GalleryPlugins();
                    _GalleryPlugins.LoadByIDPlugin(this.pIDPlugin);
                }
                return _GalleryPlugins;
            }
            set
            {
                _GalleryPlugins = value;
            }
        }

        private SubjectPlugins _SubjectPlugins;
        public SubjectPlugins SubjectPlugins
        {
            get
            {
                if (_SubjectPlugins == null || _SubjectPlugins.pIDPlugin != this.pIDPlugin)
                {
                    _SubjectPlugins = new SubjectPlugins();
                    _SubjectPlugins.LoadByIDPlugin(this.pIDPlugin);
                }
                return _SubjectPlugins;
            }
            set
            {
                _SubjectPlugins = value;
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

            base.LoadFromSql("Ciemesus_tPluginsLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, int? IDPlugin, string Name, string JSfileName, string Version, string Description, string Settings, string Css, string JSinit, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDPlugin.HasValue)
            {
                parameters.Add(new SqlParameter("@IDPlugin", SqlDbType.Int), IDPlugin);
            }

            if (!string.IsNullOrEmpty(Name))
            {
                parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 128), Name);
            }

            if (!string.IsNullOrEmpty(JSfileName))
            {
                parameters.Add(new SqlParameter("@JSfileName", SqlDbType.NVarChar, 256), JSfileName);
            }

            if (!string.IsNullOrEmpty(Version))
            {
                parameters.Add(new SqlParameter("@Version", SqlDbType.NVarChar, 128), Version);
            }

            if (!string.IsNullOrEmpty(Description))
            {
                parameters.Add(new SqlParameter("@Description", SqlDbType.NVarChar), Description);
            }

            if (!string.IsNullOrEmpty(Settings))
            {
                parameters.Add(new SqlParameter("@Settings", SqlDbType.NVarChar), Settings);
            }

            if (!string.IsNullOrEmpty(Css))
            {
                parameters.Add(new SqlParameter("@Css", SqlDbType.NVarChar), Css);
            }

            if (!string.IsNullOrEmpty(JSinit))
            {
                parameters.Add(new SqlParameter("@JSinit", SqlDbType.NVarChar), JSinit);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tPluginsSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
