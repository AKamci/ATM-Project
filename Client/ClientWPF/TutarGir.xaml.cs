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
using System.Text.Json.Serialization;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FormPara;
using System.IO.Pipes;

namespace ClientWPF
{
    /// <summary>
    /// TutarGir.xaml etkileşim mantığı
    /// </summary>
    public partial class TutarGir : Window
    {
        private int ada;
        private int _id;
        private string _name;
        static public int ATM_Degisen_Para;
        private int ATM_Para;
        private decimal _bakiye;
        private int _sifre;
        private int _kartno;
        private string _datalar;
        private string _token;
        private string _url;
        public TutarGir(int kart, string token, string url)
        {
            InitializeComponent();
            ada = kart;
            _token = token;
            _url = url;
            txtTutar.IsReadOnly = true;
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            txtTutar.Text += button.Content.ToString();



        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            txtTutar.Text = "";

            txtTutar.Text = btn.Content.ToString();
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            txtTutar.Text = txtTutar.Text.Remove(txtTutar.Text.Length - 1);
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
            
            AnaMenu_ anaMenu = new AnaMenu_(ada,_token,_url);
            anaMenu.Show();
            txtTutar.Text = "";
            this.Hide();
            
        }
        




        async Task GuncellemeHesapEksiltmeAsync()

        {

            using (HttpClient client1 = new HttpClient())
            {
                client1.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var gonderilen_istek = await client1.GetAsync($"{_url}api/musteri/getmusteribykartno/{ada}");

                await gonderilen_istek.Content.ReadAsStringAsync();

                string kontrol = await gonderilen_istek.Content.ReadAsStringAsync();

                _datalar = kontrol;

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

            
            
            decimal degiskenBakiye = Convert.ToDecimal(txtTutar.Text);

            if (degiskenBakiye % 5 == 0)
            {

                ATM_Degisen_Para = Convert.ToInt32(degiskenBakiye);

                if (degiskenBakiye < _bakiye)
                {
                    _bakiye = _bakiye - degiskenBakiye;
                    var client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                    var urls = $"{_url}api/musteri/updatemusteri";

                    string DosyaKonum_Req = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\Log.txt";
                    using (StreamWriter sw = File.AppendText(DosyaKonum_Req))
                    {
                        sw.WriteLine($"{DateTime.Now} Tarihinde Sisteme Müşteri Bilgilerini Güncelleme İsteği Gönderildi");
                    }



                    var data = new { id = _id, name = $"{_name}", password = _sifre, kartNo = _kartno, bakiye = _bakiye };
                    var json = JsonSerializer.Serialize(data);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PutAsync(urls, content);

                    string basarili_text = "İŞLEM BAŞARILI";
                    string DosyaKonum = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\{_kartno}_{_name}.txt";

                    using (StreamWriter sw = File.AppendText(DosyaKonum))
                    {
                        sw.WriteLine($"{_name} İsimli Kullanıcı,{_kartno} Numaralı Kart İle {DateTime.Now} Tarihinde {degiskenBakiye} TRY Tutarında Para Çekti");


                    }

                    //---------------------------/---------------/---------------/--------------------


                    FormPara.Form1.ParaCekme(Convert.ToInt32(degiskenBakiye));
                    
                    


                    //---------------------------/---------------/---------------/--------------------





                    Paralar.Atm_Alan =Convert.ToInt32(degiskenBakiye);
                    

                    IslemBasarili islemBasarili = new IslemBasarili(_kartno, basarili_text,_token,_url);
                    islemBasarili.Show();

                    this.Close();

                }
                else
                {
                    string basarisiz_text = "İŞLEM BAŞARISIZ";
                    IslemBasarili islemBasarili = new IslemBasarili(_kartno, basarisiz_text,_token,_url);
                    islemBasarili.Show();

                    this.Close();
                    MessageBox.Show("Yetersiz Miktar");


                }


                int customerId = _id;

            }
            else
            {
                MessageBox.Show("YALNIZCA 5'İN KATLARINI GİREBİLİRSİNİZ");
            }            

            



            
           

        }


        private void btnOnay_Click(object sender, RoutedEventArgs e)
        {
            GuncellemeHesapEksiltmeAsync();
           
            
        }
    }
}
