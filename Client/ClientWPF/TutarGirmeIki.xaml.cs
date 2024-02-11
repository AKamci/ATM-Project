using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
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
    /// TutarGirmeIki.xaml etkileşim mantığı
    /// </summary>
    /// 


    
    public partial class TutarGirmeIki : Window

    {
        private int _id;
        private string _name;
        private decimal _bakiye;
        static public int ATM_Degisen_Para2;
        private int _sifre;
        private int _kartno;
        private string _token;
        private int _gelenkart;
        private string _url;



        public TutarGirmeIki(int gelenkartNo, string token, string url)
        {
            InitializeComponent();
            _gelenkart = gelenkartNo;
            _token = token;
            _url = url;
            txtTutarS.IsReadOnly = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            txtTutarS.Text += button.Content.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           txtTutarS.Text = txtTutarS.Text.Remove(txtTutarS.Text.Length - 1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           AnaMenu_ ana = new AnaMenu_(_gelenkart,_token,_url);

            ana.Show();
            this.Close();
        }

        async Task ParaKontrolAsync()
        {
            using (HttpClient client1 = new HttpClient())
            {
                client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var gonderilen_istek = await client1.GetAsync($"{_url}api/musteri/getmusteribykartno/{_gelenkart}");

                await gonderilen_istek.Content.ReadAsStringAsync();

                string kontrol = await gonderilen_istek.Content.ReadAsStringAsync();

                

                JsonDocument jsonDocument = JsonDocument.Parse(kontrol);
                JsonElement root = jsonDocument.RootElement;
                JsonElement IdElement = root.GetProperty("id");
                JsonElement nameElement = root.GetProperty("name");
                JsonElement SifreElement = root.GetProperty("password");
                JsonElement KartElement = root.GetProperty("kartNo");
                JsonElement BakiyeElement = root.GetProperty("bakiye");

                _bakiye = BakiyeElement.GetDecimal();

                _name = nameElement.GetString();

                _id = IdElement.GetInt32();

                _kartno = KartElement.GetInt32();

                _sifre = SifreElement.GetInt32();




            }
            decimal degiskenBakiye = Convert.ToDecimal(txtTutarS.Text);
            _bakiye = _bakiye + degiskenBakiye;


           
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var surl = $"{_url}api/musteri/updatemusteri";
            
            
            string DosyaKonum_Req = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\Log.txt";
            using (StreamWriter sw = File.AppendText(DosyaKonum_Req))
            {
                sw.WriteLine($"{DateTime.Now} Tarihinde Sisteme Müşteri Bilgilerini Güncelleme İsteği Gönderildi");
            }

            var data = new { id = _id, name = $"{_name}", password = _sifre, kartNo = _kartno, bakiye = _bakiye };
            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync(surl, content);
            string basaritext = "İŞLEM BAŞARILI";
            
            string DosyaKonum = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\{_kartno}_{_name}.txt";
            using (StreamWriter sw = File.AppendText(DosyaKonum))
            {
                sw.WriteLine($"{_name} İsimli Kullanıcı,{_kartno} Numaralı Kart İle {DateTime.Now} Tarihinde {degiskenBakiye} TRY Tutarında Para Yükledi");


            }
            ATM_Degisen_Para2 = Convert.ToInt32(degiskenBakiye);



            FormPara.Form1.ParaYukleme(Convert.ToInt32(degiskenBakiye));


            IslemBasarili ıslemBasarili = new IslemBasarili(_kartno,basaritext,_token,_url);
            ıslemBasarili.Show();
            this.Close();

        }








        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            ParaKontrolAsync();


        }
    }
}
