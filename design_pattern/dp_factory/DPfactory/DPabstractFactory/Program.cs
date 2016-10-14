using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPabstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department dept = new Department();

            IFactory factory = new SqlServerFactory();
            IUser iu = factory.CreateUser();

            iu.Insert(user);
            iu.GetUser(1);

            IFactory f = new AccessFactory();
            IUser u = f.CreateUser();
            u.Insert(user);
            u.GetUser(1);

            IDepartment id = f.CreateDepartment();
            id.Insert(dept);
            id.GetDepartment(1);

            //增加一个Department需要增加三个类IDepartment、SqlserverDepartment、
            //AccessDepartment，还需更改IFactory、SqlServerFactory 、AccessFactory
            
            //简单工厂改造的抽象工厂
            iu = DataAccess.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);

            id = DataAccess.CreateDepartment();
            id.Insert(dept);
            id.GetDepartment(1);

            //反射+抽象工厂 | 配置文件
            iu = DataAccessReflection.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);

            id = DataAccessReflection.CreateDepartment();
            id.Insert(dept);
            id.GetDepartment(1);           

            Console.Read();
        }
    }
}
