using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using DAL.DataAccess;

/// <summary>
/// Business Logic Layer Class By Farschidus
/// Generate Date: 7/9/2012 4:10 PM
/// <summary>
namespace BLL.BusinessEntity
{
    public class Members : _Members
    {
        #region  "Constructors"

        public Members()
        {
        }
        public Members(Guid IDMember)
        {
            this.LoadByPrimaryKey(IDMember);
        }

        #endregion

        #region  "Properties"

        //private Users _users;
        //public Users Users
        //{
        //    get
        //    {
        //        if (_users == null || _users.pUserId != this.pUserId)
        //        {
        //            _users = new Users();
        //            _users.LoadByUserId(this.pUserId);
        //        }
        //        return _users;
        //    }
        //    set
        //    {
        //        _users = value;
        //    }
        //}

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

            base.LoadFromSql("Ciemesus_tMembersLoadAll", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }
        public bool LoadByIDMember(Guid IDMember)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.IDMember, IDMember);

            return base.LoadFromSql("SELECT * FROM " + QuerySource + " WHERE @IDMember = IDMember", parameters, System.Data.CommandType.Text);
        }
        public bool Search(int pageIndex, int pageSize, ref int totalRecords, Guid? IDMember, string FirstName, string LastName, string sortExpression)
        {
            ListDictionary parameters = new ListDictionary();

            parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int), pageIndex);
            parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int), pageSize);

            SqlParameter sqlParam = new SqlParameter("@TotalRecords", SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.InputOutput;
            parameters.Add(sqlParam, totalRecords);

            if (IDMember.HasValue)
            {
                parameters.Add(new SqlParameter("@IDMember", SqlDbType.UniqueIdentifier), IDMember);
            }

            if (!string.IsNullOrEmpty(FirstName))
            {
                parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 50), FirstName);
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 50), LastName);
            }

            if (!string.IsNullOrEmpty(sortExpression))
            {
                parameters.Add(new SqlParameter("@SortExpression", SqlDbType.NVarChar, 1000), sortExpression);
            }

            base.LoadFromSql("Ciemesus_tMembersSearch", parameters, System.Data.CommandType.StoredProcedure);

            totalRecords = (int)sqlParam.Value;
            return true;
        }

        #endregion
    }
}
