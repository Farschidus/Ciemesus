using System;
//using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Net.Mail;
//using System.IO;

namespace Farschidus.Web.Security
{
    [System.ComponentModel.DataObject]
    public static class Membership
    {

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public static System.Web.Security.MembershipUserCollection GetAllUsers(String UsernameStartString,
                                                    String IsInRole,
                                                    String IsApproved,
                                                    String IsLockedOut,
                                                    String IsOnline)
        {
            System.Web.Security.MembershipUserCollection MUC0 = new System.Web.Security.MembershipUserCollection();
            if (UsernameStartString == "")
            {
                MUC0 = System.Web.Security.Membership.GetAllUsers();
            }
            else
            {
                MUC0 = System.Web.Security.Membership.FindUsersByName(UsernameStartString + "%");
            }

            if (MUC0.Count > 0)
            {
                System.Web.Security.MembershipUserCollection MUC1 = new System.Web.Security.MembershipUserCollection();
                foreach (System.Web.Security.MembershipUser aUser in MUC0)
                {
                    if ((String.IsNullOrEmpty(IsInRole) || (System.Web.Security.Roles.IsUserInRole(aUser.UserName, IsInRole)))
                        && ((String.IsNullOrEmpty(IsApproved)) || (aUser.IsApproved == (IsApproved == Boolean.TrueString)))
                        && ((String.IsNullOrEmpty(IsLockedOut)) || (aUser.IsLockedOut == (IsLockedOut == Boolean.TrueString)))
                        && ((String.IsNullOrEmpty(IsOnline)) || (aUser.IsOnline == (IsOnline == Boolean.TrueString))))
                    {
                        MUC1.Add(aUser);
                    }
                }
                return MUC1;
            }
            else
            {
                return MUC0;
            }

        }
    }
}
