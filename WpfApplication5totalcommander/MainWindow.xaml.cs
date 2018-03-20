using WpfApplication5totalcommander.DataModels;
using WpfApplication5totalcommander.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace WpfApplication5totalcommander
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathLeft;
        string pathRight;
        string pathLastClick;

        public MainWindow()
        {
            InitializeComponent();
            pathLeft = Directory.GetDirectoryRoot(System.Reflection.Assembly.GetExecutingAssembly().Location);
            pathRight = Directory.GetDirectoryRoot(System.Reflection.Assembly.GetExecutingAssembly().Location);
            pathLastClick = Directory.GetDirectoryRoot(System.Reflection.Assembly.GetExecutingAssembly().Location);
            loadElements(pathLeft);
            loadElements2(pathRight);

        }

        public void MainWindow2(string path)
        {
            InitializeComponent();
            this.pathLeft = path;
            this.pathLastClick = path;
            loadElements(path);

        }

        public void MainWindow3(string path)
        {
            InitializeComponent();
            this.pathRight = path;
            this.pathLastClick = path;
            loadElements2(path);

        }

        private void loadElements(string path)
        {
            try
            {
                MyDir dirs = new MyDir(path);
                List<DiscElements> discElements = dirs.GetSubDiscElements();
                LeftStackPanel.Children.Clear();

                string parentPath = dirs.Parent;
                if (dirs.Path != Directory.GetDirectoryRoot(dirs.Path))
                {
                    MyDir Parent = new MyDir(parentPath);
                    ParentDirectoryView parentUser = new ParentDirectoryView(Parent);
                    parentUser.GetNewViewEvent += MainWindow2;
                    LeftStackPanel.Children.Add(parentUser);
                }


                foreach (DiscElements discElement in discElements)
                {
                    DiscElementsView something = new DiscElementsView(discElement);

                    LeftStackPanel.Children.Add(something);

                    if (discElement is MyDir)
                    {
                        something.GetNewViewEvent += MainWindow2;

                    }
                }

            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("You don't have an access!!!");
            }
            }
            

        private void loadElements2(string path)
        {
            try
            {
                MyDir dirs = new MyDir(path);
                List<DiscElements> discElements = dirs.GetSubDiscElements();
                RightStackPanel.Children.Clear();

                string parentPath = dirs.Parent;
                if (dirs.Path != Directory.GetDirectoryRoot(dirs.Path))
                {
                    MyDir Parent = new MyDir(parentPath);
                    ParentDirectoryView parentUser = new ParentDirectoryView(Parent);
                    parentUser.GetNewViewEvent += MainWindow3;
                    RightStackPanel.Children.Add(parentUser);
                }


                foreach (DiscElements discElement in discElements)
                {
                    DiscElementsView something = new DiscElementsView(discElement);

                   RightStackPanel.Children.Add(something);

                    if (discElement is MyDir)
                    {
                        something.GetNewViewEvent += MainWindow3;

                    }
                }

            }
            catch (UnauthorizedAccessException )
            {
                MessageBox.Show("You don't have an access!!!");
            }

        }

        private void RefreshFilesList()
        {
            MyDir myDirectory = new MyDir(pathLeft);
            LeftStackPanel.Children.Clear();

            string parentPath = myDirectory.Parent;

            if(myDirectory.Path != Directory.GetDirectoryRoot(myDirectory.Path))
            {
                MyDir Parent = new DataModels.MyDir(parentPath);
                ParentDirectoryView parentUser = new ParentDirectoryView(Parent);
                parentUser.GetNewViewEvent += MainWindow2;
                LeftStackPanel.Children.Add(parentUser);
            }
            List<DiscElements> subElements = myDirectory.GetSubDiscElements();

            foreach (DiscElements discElement in subElements)
            {
                DiscElementsView discElementView = new DiscElementsView(discElement);

                LeftStackPanel.Children.Add(discElementView);

                discElementView.GetNewViewEvent += MainWindow2;

            }
        }

        private void RefreshFilesListR()
        {
            MyDir myDirectory = new MyDir(pathRight);
            RightStackPanel.Children.Clear();
            
            string parentPath = myDirectory.Parent;
            if (myDirectory.Path != Directory.GetDirectoryRoot(myDirectory.Path))
            {
                MyDir Parent = new MyDir(parentPath);
                ParentDirectoryView parentUser = new ParentDirectoryView(Parent);
                parentUser.GetNewViewEvent += MainWindow3;
                RightStackPanel.Children.Add(parentUser);
            }

            List<DiscElements> subElements = myDirectory.GetSubDiscElements();

            foreach (DiscElements discElement in subElements)
            {
                DiscElementsView discElementView = new DiscElementsView(discElement);

                RightStackPanel.Children.Add(discElementView);

                discElementView.GetNewViewEvent += MainWindow3;

            }
        }

        private void buttonCreateNewDirectory_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(pathLastClick + "//" + textBoxName.Text);

            RefreshFilesList();
            RefreshFilesListR();
        }

        private void buttonDeleteClick(object sender, RoutedEventArgs e)
        {
            foreach (UserControl ob in LeftStackPanel.Children)
            {
                if (ob is DiscElementsView)
                {
                    DiscElementsView discElementView = (DiscElementsView)ob;

                    if (discElementView.checkBox.IsChecked.Value)
                    {
                        if (discElementView.returnDiscElements is MyFile)
                        {
                            System.IO.File.Delete(discElementView.returnPath);
                        }

                        else if (discElementView.returnDiscElements is MyDir)
                        {
                            System.IO.Directory.Delete(discElementView.returnPath, true);
                        }

                    }
                }
            }

            RefreshFilesList();
            foreach (UserControl ob in RightStackPanel.Children)
            {
                if (ob is DiscElementsView)
                {
                    DiscElementsView discElementView = (DiscElementsView)ob;

                    if (discElementView.checkBox.IsChecked.Value)
                    {
                        if (discElementView.returnDiscElements is MyFile)
                        {
                            System.IO.File.Delete(discElementView.returnPath);
                        }

                        else if (discElementView.returnDiscElements is MyDir)
                        {
                            DeleteDirectory(discElementView.returnPath);
                        }

                    }
                }
            }
            RefreshFilesListR();

        }
        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        /// <summary>
        /// copy dir leftStackPanel to rightStackPanel
        /// </summary>
        /// <param name="pathLeft"></param>
        /// <param name="pathRight"></param>
        static public void CopyFolderLtR(string pathLeft, string pathRight)
        {
            if (!Directory.Exists(pathRight))
                Directory.CreateDirectory(pathRight);
            string[] files = Directory.GetFiles(pathLeft);

            foreach (string file in files)
            {
                string name = System.IO.Path.GetFileName(file);
                string dest = System.IO.Path.Combine(pathRight, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(pathLeft);

            foreach (string folder in folders)
            {
                string name = System.IO.Path.GetFileName(folder);
                string dest = System.IO.Path.Combine(pathRight, name);
                CopyFolderLtR(folder, dest);
            }
        }

        ///// <summary>
        ///// copy dir rightStackPanel to leftStackPanel
        ///// </summary>
        ///// <param name="pathLeft"></param>
        ///// <param name="pathRight"></param>
        //static public void CopyFolderRtL(string pathRight, string pathLeft)
        //{
        //    if (!Directory.Exists(pathLeft))
        //        Directory.CreateDirectory(pathLeft);
        //    string[] files = Directory.GetFiles(pathRight);

        //    foreach (string file in files)
        //    {
        //        string name = System.IO.Path.GetFileName(file);
        //        string dest = System.IO.Path.Combine(pathLeft, name);
        //        File.Copy(file, dest);
        //    }
        //    string[] folders = Directory.GetDirectories(pathRight);

        //    foreach (string folder in folders)
        //    {
        //        string name = System.IO.Path.GetFileName(folder);
        //        string dest = System.IO.Path.Combine(pathLeft, name);
        //        CopyFolderRtL(folder, dest);
        //    }
        //}

        private void buttonCopyClick(object sender, RoutedEventArgs e)
        {
            foreach (UserControl ob in LeftStackPanel.Children)
            {
                if (ob is DiscElementsView)
                {
                    DiscElementsView discElementView = (DiscElementsView)ob;

                    if (discElementView.checkBox.IsChecked.Value)
                    {
                        if (discElementView.returnDiscElements is MyFile)
                        {
                            try
                            {
                                System.IO.File.Copy(discElementView.returnPath, pathRight + "//" + textBoxName.Text);
                            }

                            catch
                            {
                                MessageBox.Show("Can't copy file, try rename!");
                            }

                        }

                        else if (discElementView.returnDiscElements is MyDir)
                        {
                            try
                            {
                                CopyFolderLtR(discElementView.returnPath, pathRight + "//" + textBoxName.Text);
                            }
                            catch
                            {
                                MessageBox.Show("Can't copy dir, try rename!");
                            }
                        }
                    }
                }
            }

            RefreshFilesList();

            foreach (UserControl ob in RightStackPanel.Children)
            {
                if (ob is DiscElementsView)
                {
                    DiscElementsView discElementView = (DiscElementsView)ob;

                    if (discElementView.checkBox.IsChecked.Value)
                    {
                        if (discElementView.returnDiscElements is MyFile)
                        {
                            //try
                            //{
                                System.IO.File.Copy(discElementView.returnPath, pathLeft + "//" + textBoxName.Text);
                            //}
                            //catch
                            //{
                            //    MessageBox.Show("Can't copy file, try rename!");
                            //}
                        }

                        else if (discElementView.returnDiscElements is MyDir)
                        {
                            try
                            {
                                CopyFolderLtR(discElementView.returnPath, pathLeft + "//" + textBoxName.Text);
                            }
                            catch
                            {
                                MessageBox.Show("Can't copy dir, try rename!");
                            }
                            
                        }
                    }
                }
            }

            RefreshFilesListR();
        }

        private void buttonSearchClick(object sender, RoutedEventArgs e)
        {

            string searchPattern = textBoxName.Text;
            comboBox.Items.Clear();

            DirectoryInfo di = new DirectoryInfo(pathLastClick);
            DirectoryInfo[] directories =
                di.GetDirectories(searchPattern, SearchOption.TopDirectoryOnly);

            FileInfo[] files =
                di.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

            foreach (var dir in directories)
            {
                MyDir cos = new MyDir(dir.FullName);
                DiscElementsView cos2 = new DiscElementsView(cos);
                comboBox.Items.Add(cos2);
                cos2.GetNewViewEvent += MainWindow3;
            }

            foreach (var fil in files)
            {
                MyFile cos = new MyFile(fil.FullName);
                DiscElementsView cos2 = new DiscElementsView(cos);
                comboBox.Items.Add(cos2);

            }

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonSortedByCreationTimeClick(object sender, RoutedEventArgs e)
        {
            MyDir myDir = new MyDir(pathLeft);
            LeftStackPanel.Children.Clear();

            List<DiscElements> subElements = myDir.GetSubDiscElements();
            var orderedFiles = subElements.OrderBy(f => f.CreationTime);

            foreach (DiscElements discElement in orderedFiles)
            {
                DiscElementsView discElementView = new DiscElementsView(discElement);

                LeftStackPanel.Children.Add(discElementView);
                discElementView.GetNewViewEvent += MainWindow2;

            }
           

            MyDir myDirR = new MyDir(pathRight);
            RightStackPanel.Children.Clear();

            List<DiscElements> subElementsR = myDirR.GetSubDiscElements();
            var orderedFilesR = subElementsR.OrderBy(f => f.CreationTime);

            foreach (DiscElements discElement in orderedFilesR)
            {
                DiscElementsView discElementView = new DiscElementsView(discElement);

                RightStackPanel.Children.Add(discElementView);
                discElementView.GetNewViewEvent += MainWindow3;


            }
           

        }

        private void buttonSortedNameClick(object sender, RoutedEventArgs e)
        {
            MyDir myDir = new MyDir(pathLeft);
            LeftStackPanel.Children.Clear();

            List<DiscElements> subElements = myDir.GetSubDiscElements();
            var orderedFiles = subElements.OrderBy(f => f.Name);

            foreach (DiscElements discElement in orderedFiles)
            {
                DiscElementsView discElementView = new DiscElementsView(discElement);

                LeftStackPanel.Children.Add(discElementView);
                discElementView.GetNewViewEvent += MainWindow2;

            }

            MyDir myDirR = new MyDir(pathRight);
            RightStackPanel.Children.Clear();

            List<DiscElements> subElementsR = myDirR.GetSubDiscElements();
            var orderedFilesR = subElementsR.OrderBy(f => f.Name);

            foreach (DiscElements discElement in orderedFilesR)
            {
                DiscElementsView discElementView = new DiscElementsView(discElement);

                RightStackPanel.Children.Add(discElementView);
                discElementView.GetNewViewEvent += MainWindow3;

            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            
                foreach (UserControl ob in LeftStackPanel.Children)
                {
                if (ob is DiscElementsView)
                {
                    DiscElementsView discElementView = (DiscElementsView)ob;

                    if (discElementView.checkBox.IsChecked.Value)

                        if (discElementView.returnDiscElements is MyFile)

                            System.Diagnostics.Process.Start("notepad.exe", discElementView.returnPath);

                        else if (discElementView.returnDiscElements is MyDir)
                            MessageBox.Show("You can't edit directory!!!!");
                }
                 }
            RefreshFilesList();


            foreach (UserControl ob in RightStackPanel.Children)
            {
                if (ob is DiscElementsView)
                {
                    DiscElementsView discElementView = (DiscElementsView)ob;

                    if (discElementView.checkBox.IsChecked.Value)
                        if (discElementView.returnDiscElements is MyFile)

                            System.Diagnostics.Process.Start("notepad.exe", discElementView.returnPath);

                        else if (discElementView.returnDiscElements is MyDir)
                            MessageBox.Show("You can't edit directory!!!!");
                }
            }
            RefreshFilesListR();
        }

        private void buttonSortedByNameClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
    

