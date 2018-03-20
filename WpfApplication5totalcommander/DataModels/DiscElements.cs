using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication5totalcommander.DataModels
{
    public abstract class DiscElements
    {
        string path;

        public DiscElements(string path)
        {
            this.path = path;
        }

        public string Path
        {
            get
            {
                return path;
            }
        }

        public abstract string Atr
        {
            get;
            
        }

        public abstract string Exten
        {
            get;
            
        }
        public abstract DateTime CreationTime
        {
            get;
        }

        public abstract string Name
        {
            get;
        }

        public abstract long Size
        {
            get;
        }
    }
}
