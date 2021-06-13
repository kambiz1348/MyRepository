using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace nikanClient.Classes
{
    public class otherClasses
    {
    }
    public class configClass
    {
        public string BaseUriGet()
        {
            return ConfigurationManager.AppSettings["BaseURI"].ToString();
        }
    }
    public class convertClass
    {
    }
}
