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
using System.Net.Http;
using Azure;
using System.Text.Json;
using System.Net.Http.Headers;

namespace ClientWPF
{
    /// <summary>
    /// AnaMenu_.xaml etkileşim mantığı
    /// </summary>
    public partial class AnaMenu_ : Window
    {
        


        private int _kart;
        private string _istenilen;
        private string _Cevap;
        private int _id;
        private string _url;
        public AnaMenu_(int kart, string _cevap, string url)
        {
            InitializeComponent();
            
            this._kart = kart;
            this._Cevap = _cevap;
            this._url = url;
            
            BilgilendirmeAsync(_kart);

        }

        
        async Task BilgilendirmeAsync(int kartno)
        {
            using (HttpClient client1 = new HttpClient())
            {
                client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _Cevap);
                var bilgi = await client1.GetAsync($"{_url}api/musteri/getmusteribykartno/{_kart}");
                
                await bilgi.Content.ReadAsStringAsync();

                string istenilenler = await bilgi.Content.ReadAsStringAsync();

                 _istenilen = istenilenler;

            }

        }
        
        




        private void btniade_Click(object sender, RoutedEventArgs e)
        {
            Application application = Application.Current;
            application.Shutdown();
            
           

        }

        private void btnbakiye_Click(object sender, RoutedEventArgs e)
        {

            JsonDocument jsonDocument = JsonDocument.Parse(_istenilen);

            JsonElement root = jsonDocument.RootElement;
            JsonElement IdElement = root.GetProperty("id");
            JsonElement BakiyeElement = root.GetProperty("bakiye");

            int id = IdElement.GetInt32();
            decimal istenilenBakiye = BakiyeElement.GetDecimal();
            _id = id;

            BakiyeGosterme bakiyeGosterme = new BakiyeGosterme(istenilenBakiye);

            bakiyeGosterme.Show();

            

        }

        private async void btnparacekme_Click(object sender, RoutedEventArgs e)
        {
            TutarGir tutarGir = new TutarGir(_kart,_Cevap,_url);

            tutarGir.Show();
            this.Hide();


        }

        private void btnparayatırma_Click(object sender, RoutedEventArgs e)
        {
            TutarGirmeIki tutarGirmeIki = new TutarGirmeIki(_kart,_Cevap,_url);

            tutarGirmeIki.Show();
            this.Hide();




        }
    }
}

