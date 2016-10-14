using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPabstractFactory
{
    interface IFactory
    {
        IUser CreateUser();
        IDepartment CreateDepartment();
    }
    class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlserverUser();
        }
        public IDepartment CreateDepartment()
        {
            return new SqlserverDepartment();
        }
    }
    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
        public IDepartment CreateDepartment()
        {
            return new AccessDepartment();
        }
    }
}
