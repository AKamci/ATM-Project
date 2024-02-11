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
using System.Windows.Shapes;

namespace ClientWPF
{
    /// <summary>
    /// BakiyeGosterme.xaml etkileşim mantığı
    /// </summary>
    public partial class BakiyeGosterme : Window
    {
        public BakiyeGosterme(decimal bakiye)
        {
            InitializeComponent();
            lblbakiye.Content = bakiye.ToString() + "TRY";
        }

        private void btnKartiade_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            
        }

        private void btnAnaMenu_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
