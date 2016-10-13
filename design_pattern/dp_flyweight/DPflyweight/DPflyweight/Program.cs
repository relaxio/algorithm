using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPflyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSiteFactory f = new WebSiteFactory();

            WebSite fx = f.GetWebSiteCategory("产品展示");
            fx.Use(new User("X"));

            WebSite fy = f.GetWebSiteCategory("产品展示");
            fy.Use(new User("Y"));

            WebSite fz = f.GetWebSiteCategory("产品展示");
            fz.Use(new User("Z"));

            WebSite fl = f.GetWebSiteCategory("博客");
            fl.Use(new User("L"));

            WebSite fm = f.GetWebSiteCategory("博客");
            fm.Use(new User("M"));

            WebSite fn = f.GetWebSiteCategory("博客");
            fn.Use(new User("N"));

            Console.WriteLine("得到网站分类总数为 {0}", f.GetWebSiteCount());

            Console.Read();
        }
    }
}
