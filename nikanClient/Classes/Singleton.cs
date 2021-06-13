using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nikanClient.Classes
{
    public sealed class singleTonClassConfig
    {
        private static Classes.configClass instance = new Classes.configClass();
        private singleTonClassConfig() { }
        public static Classes.configClass Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Classes.configClass();
                }
                return instance;
            }
        }
    }
}
