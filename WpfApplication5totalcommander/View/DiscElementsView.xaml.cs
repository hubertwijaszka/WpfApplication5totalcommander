using WpfApplication5totalcommander.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
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
    /// Interaction logic for UserControl.xaml
    /// </summary>
    public partial class DiscElementsView : UserControl
    {
        
        DiscElements discElements;

        public string returnPath
        {
            get
            {
                return discElements.Path;
            }
        }

        public DiscElements returnDiscElements
        {
            get
            {
                return discElements;
            }
        }

        public DiscElementsView(DiscElements discElements)
        {
            this.discElements = discElements;

            InitializeComponent();

            labelName.Content = discElements.Name;
            labelExt.Content = discElements.Exten;
            labelSize.Content = discElements.Size;
            labelCreationTime.Content = discElements.CreationTime;
            labelAttributes.Content = discElements.Atr;
        }


        public delegate void GetNewView(string path);
        public event GetNewView GetNewViewEvent;

        private void buttonOpenClick(object sender, RoutedEventArgs e)
        {
            if (discElements is MyDir)
            {
                
                try
                {
                    GetNewViewEvent.Invoke(discElements.Path);
                }
                catch
                {
                    MessageBox.Show("Can't open the dir!");
                }
                
            }
            if (discElements is MyFile)
            {
                
                Process.Start(discElements.Path);
            }
        }

        

    }
}
