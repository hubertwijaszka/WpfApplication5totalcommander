using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApplication5totalcommander.DataModels
{
    class MyDir : DiscElements
    {
        string name;
        public MyDir(string dirPath): base(dirPath)
        {
            DirectoryInfo cos = new DirectoryInfo(dirPath);
            this.name = cos.Name;
             
        }

        /// <summary>
        /// </summary>
        /// <returns>files in dir and subdirs</returns>
        public List<DiscElements> GetSubDiscElements()
        {
            List<DiscElements> result = new List<DiscElements>();
            result.AddRange(GetAllFiles());
            result.AddRange(GetSubDirectories());
            return result;
        }

        /// <summary>
        /// </summary>
        /// <returns>all files from dir</returns>
        public List<MyFile> GetAllFiles()
        {
            string[] subFiles = Directory.GetFiles(Path);

            List<MyFile> result = new List<MyFile>();
            foreach (string file in subFiles)
            {
                result.Add(new MyFile(file));
            }
            return result;

        }

        
        public int NumberOfDirs()
        {
            try
            {
                return Directory.GetDirectories(Path).Length;
            }
            catch
            {
                return 0;
            }
            
        }

        /// <summary>
        /// download all subdirs
        /// </summary>
        /// <returns>list of subdirs of the dir</returns>
        public MyDir[] GetSubDirectories()
        {
            string[] subDirs = Directory.GetDirectories(Path);

            List<MyDir> result = new List<MyDir>();
            foreach (string dir in subDirs)
            {
                result.Add(new MyDir(dir));
            }
            return result.ToArray();

        }

        public override DateTime CreationTime
        {
            get
            {

                return Directory.GetCreationTime(Path);
            }
        }

        public override string Name
        {
            get
            {
                return name;
                
                
            }
        }
        /// <summary>
        /// attributes
        /// </summary>
        public override string Atr
        {
            get
            {
                return "";
            }
        }
        /// <summary>
        /// extension
        /// </summary>
        public override string Exten
        {
            get
            {
                return "";
            }
            
        }
        public override long Size
        {
            get
            {
                return NumberOfDirs();
            }
        }
        /// <summary>
        /// download full path
        /// </summary>
        public string Parent
        {
            get
            {
                try
                {
                    return Directory.GetParent(Path).FullName;
                }

                catch
                {
                    return null;
                }
                
            }
        }

    }
}
