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
using System.Security.Cryptography;

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
        private bool _virginCard;

        public YuklenmeSayfa(int GirilenKart, string url, bool virgin)
        {
            InitializeComponent();

           //GirilenKart_ = GirilenKart;


            this.GirilenKart = GirilenKart;
            this._virginCard = virgin;

            txtSifrePIN.IsReadOnly = true;
            txtYıldiz.IsReadOnly = true;
            this._url = url;
           
            
            if (_virginCard==false)
            {
                MessageBox.Show("Sisteme Kayıta Hoşgeldiniz \n " +
                   "Lütfen Belirleyeceğiniz Şifreyi Giriniz.");
            }

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

        async Task GirisDenemeAsync(int Kart,bool virginControl)
        {

            if (virginControl)
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

                    string GonderSifre2;
                    string GonderSifre = GirilenKart.ToString() + txtSifrePIN.Text;

                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(GonderSifre));

                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        GonderSifre2 = builder.ToString();
                       

                    }

                   




                    

                    var data = new { password = GonderSifre2, kartNo = GirilenKart };
                    var json = JsonSerializer.Serialize(data);
                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


                    var response = await client.PostAsync($"https://localhost:7058/api/kullanicidogruluk/giris", content);





                    var responseString = await response.Content.ReadAsStringAsync();
                    Cevap = responseString;

                    if (response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                    {
                        using (HttpClient client5 = new HttpClient())
                        {
                            await client5.GetAsync($"https://localhost:7058/api/kullanicidogruluk/kontrol");
                        }
                    }
                   


                   


                }



                if (Cevap.Length > 30)
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
                    AnaMenu_ anaMenu_ = new AnaMenu_(GirilenKart, Cevap, _url);

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
            else
            {
               

                using(HttpClient httpClient0 = new HttpClient())
                {
                    Random random = new Random();
                    char[] alfabe = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

                    string randomStringq = "";

                    for (int i = 0; i < 7; i++)
                    {
                        int randomIndex = random.Next(0, alfabe.Length);
                        randomStringq += alfabe[randomIndex];
                    }



                

                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        string YeniKartSifreBirlesim = GirilenKart.ToString() + txtSifrePIN.Text;

                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(YeniKartSifreBirlesim));

                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        //string YeniKartSifreBirlesim = GirilenKart.ToString() + builder.ToString();

                        var dataq = new { password =builder.ToString() , kartNo = GirilenKart };
                        var jsonq = JsonSerializer.Serialize(dataq);
                        var contentq = new StringContent(jsonq, System.Text.Encoding.UTF8, "application/json");
                        var responseq = await httpClient0.PostAsync($"{_url}api/musteri/createmusterisifretablo", contentq);
                        var responseString = await responseq.Content.ReadAsStringAsync();


                        if (responseq.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Şifreniz Onaylandı. \n" +
                           "Lütfen Tekrardan Giriş Yapınız");

                            MainWindow mainWindow3 = new MainWindow();
                            mainWindow3.Show();
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Şifreniz Onaylanmadı. \n" +
                                        "Lütfen Tekrardan Giriş Yapınız");
                        }


                    }








                   


                }



              


            }

          


        }

        private void btnGiris_Click(object sender, RoutedEventArgs e)
        {
            
            GirisDenemeAsync(GirilenKart,_virginCard);


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
