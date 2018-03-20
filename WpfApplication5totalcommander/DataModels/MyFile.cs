using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApplication5totalcommander.DataModels
{
    class MyFile : DiscElements
    {
        private string name;

        FileInfo Ext;

        public MyFile(string path) : base(path)
        {
            FileInfo Ext = new FileInfo(path);
            this.Ext = Ext;
        }

        /// <summary>
        /// </summary>
        /// <returns>extension of file</returns>
        public override string Exten
        {
            get
            {
                return Ext.Extension;
            }
            
        }
        /// <summary>
        /// return amount of bytes
        /// </summary>
        public override long Size
        {
            get
            {
                return Ext.Length;
            }
        }
        /// <summary>
        /// return attributes of file
        /// </summary>
        public override string Atr
        {
            get
            {
                return Ext.Attributes.ToString();
            }
        }

        public override DateTime CreationTime
        {
            get
            {
                return File.GetCreationTime(Path);
            }
        }

        public override string Name
        {
            get
            {
                return name = System.IO.Path.GetFileName(Path);
            }
        }
    }
}
