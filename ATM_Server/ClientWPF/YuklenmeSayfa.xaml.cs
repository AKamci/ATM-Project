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
using System.Threading;
using System.Timers;
using System.Net.Http;
using System.Text.Json;
using System.IO;


namespace ClientWPF
{
    /// <summary>
    /// YuklenmeSayfa.xaml etkileşim mantığı
    /// </summary>
    public partial class YuklenmeSayfa : Window
    {
        // public int GirilenKart_ { get; }

        private int GirilenKart;
        private string SifreDeger;
        private string NameTxt;
        private string Cevap;
        private string _url;

        public YuklenmeSayfa(int GirilenKart, string url)
        {
            InitializeComponent();

           //GirilenKart_ = GirilenKart;


            this.GirilenKart = GirilenKart;

            txtSifrePIN.IsReadOnly = true;
            txtYıldiz.IsReadOnly = true;
            this._url = url;
        }

        
        
        



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txtSifrePIN.Text.Length < 4)
            {
                Button button = (Button)sender;
                txtSifrePIN.Text += button.Content.ToString();
                txtYıldiz.Text += "  *  ";
            }
        }

        

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            if (txtSifrePIN.Text.Length > 0 )
            {
                txtSifrePIN.Text = txtSifrePIN.Text.Remove(txtSifrePIN.Text.Length - 1);
                txtYıldiz.Text = txtYıldiz.Text.Remove(txtYıldiz.Text.Length - 5);
            }
           
        }

        private void btnIptal_Click(object sender, RoutedEventArgs e)
        {
           MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        async Task GirisDenemeAsync(int Kart)
        {
            
            using (HttpClient client = new HttpClient())
            {
                Random random = new Random();
                char[] alfabe = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
               

              

                string randomString = "";

                for (int i = 0; i < 18; i++)
                {
                    int randomIndex = random.Next(0, alfabe.Length);
                    randomString += alfabe[randomIndex];
                }


                //var response = await client.GetAsync($"https://localhost:44321/api/musteri/getmusteribykartno/{GirilenKart}");

                //string DosyaKonum_Req = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\Log.txt";
                //using (StreamWriter sw = File.AppendText(DosyaKonum_Req))
                //{
                //    sw.WriteLine($"{DateTime.Now} Tarihinde Sistemden Kart Numarasını Doğrulama İsteği Gönderildi");
                //}

                //await response.Content.ReadAsStringAsync();

                //string mesaj = await response.Content.ReadAsStringAsync();


                var data = new {name = $"{randomString}", password = Convert.ToInt32(txtSifrePIN.Text), kartNo = GirilenKart};
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{_url}api/giriskontrolleri/Giris", content);
                var responseString = await response.Content.ReadAsStringAsync();
                Cevap = responseString;
                
                
            }
            
            
            
            if (Cevap.Length >30)
                {

                    this.Opacity = 0;
                    viewBox.Opacity = 0;
                    gridSifre.Opacity = 0; 
                    Pencere2.Opacity = 0;
                    string DosyaKonum = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\{GirilenKart}.txt";

                    using (StreamWriter sw = File.AppendText(DosyaKonum))
                    {
                        sw.WriteLine($"Kullanıcı,{GirilenKart} Numaralı Kart İle {DateTime.Now} Tarihinde Sisteme Giriş Yaptı");
                  
                
                    }
                // string isim = nameElement.ToString();
                MessageBox.Show("Giriş Başarılı Yönlendirme Başlıyor");
                   

                   
                    Thread.Sleep(1000);
                    AnaMenu_ anaMenu_ = new AnaMenu_(GirilenKart,Cevap,_url);

                    anaMenu_.Show();

                    this.Hide();

                }
                else
                {
                this.Opacity = 0;
                viewBox.Opacity = 0;
                gridSifre.Opacity = 0;
                Pencere2.Opacity = 0;
                MessageBox.Show("Giriş Başarısız");
                    txtSifrePIN.Text = "";
                    txtYıldiz.Text = "";

                this.Opacity = 1;
                viewBox.Opacity = 1;
                gridSifre.Opacity = 1;
                Pencere2.Opacity = 1;
            }

        }

        private void btnGiris_Click(object sender, RoutedEventArgs e)
        {
            
            GirisDenemeAsync(GirilenKart);


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
