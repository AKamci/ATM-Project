using System;
using System.Collections.Generic;
using System.IO;
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
    /// IslemBasarili.xaml etkileşim mantığı
    /// </summary>
    public partial class IslemBasarili : Window
    {
        private int _kartno;
        private string GelenToken;
        private string gelen_yazi;
        private int isteksayisi;
        private string _url;
        
       
        public IslemBasarili(int kartno1,string veri,string tokens,string url)
        {
            InitializeComponent();
            _kartno = kartno1;
            gelen_yazi = veri;
            _url = url;
            GelenToken = tokens;
            lblVeri.Content = gelen_yazi;
            
           



        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btniade_Click(object sender, RoutedEventArgs e)
        {
           // System.Windows.Application.Current.Shutdown();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

           
        }

        private void btnana_Click(object sender, RoutedEventArgs e)
        {

            AnaMenu_ anaMenu = new AnaMenu_(_kartno,GelenToken,_url);
            anaMenu.Show();
            this.Close();


        }
    }
}
