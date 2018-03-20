using System;
using WpfApplication5totalcommander.DataModels;
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

namespace WpfApplication5totalcommander.View
{
    /// <summary>
    /// Interaction logic for ParentDirectoryView.xaml
    /// </summary>
    public partial class ParentDirectoryView : UserControl
    {

        DiscElements discElements;

        public ParentDirectoryView(DiscElements discElements)
        {
            InitializeComponent();

            this.discElements = discElements;

        }

        public DiscElements returnDiscElements
        {
            get
            {
                return discElements;
            }
        }

        public string returnPath
        {
            get
            {
                return discElements.Path;
            }
        }

        public delegate void GetNewView(string path);
        public event GetNewView GetNewViewEvent;

        private void buttonOpenClick(object sender, RoutedEventArgs e)
        {
            if (discElements is MyDir)
            {
                GetNewViewEvent.Invoke(discElements.Path);
            }
            if (discElements is MyFile)
            {
                System.Diagnostics.Process.Start(discElements.Path);
            }
        }
    }
}
