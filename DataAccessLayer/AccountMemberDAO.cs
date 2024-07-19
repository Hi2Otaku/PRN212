using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class AccountMemberDAO
    {
        private static AccountMember GetAccountMemberByName(String name)
        {
            AccountMember accountMember = new AccountMember();
            CourseManagementDbContext db = new CourseManagementDbContext();
            accountMember = db.AccountMembers.Find(name);
            return accountMember;
        }
    }
}
