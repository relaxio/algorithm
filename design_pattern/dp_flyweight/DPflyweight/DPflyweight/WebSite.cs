using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPflyweight
{
    abstract class WebSite
    {
        public abstract void Use(User user);
    }

    public class User
    {
        private string name;
        public User(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }
    class ConcreteWebSite : WebSite
    {
        private string name = "";
        public ConcreteWebSite(string name)
        {
            this.name = name;
        }
        public override void Use(User user)
        {
            Console.WriteLine("网站分类：" + name + " 用户：" + user.Name);
        }
    }
    class WebSiteFactory
    {
        private Hashtable flyweights = new Hashtable();
        public WebSite GetWebSiteCategory(string key)
        {
            if (!flyweights.ContainsKey(key))
                flyweights.Add(key, new ConcreteWebSite(key));
            return ((WebSite)flyweights[key]);
        }
        public int GetWebSiteCount()
        {
            return flyweights.Count;
        }
    }  
}
