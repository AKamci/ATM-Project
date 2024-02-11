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
using System.ComponentModel.Design;
using System.Threading;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Media.Animation;
using System.IO;

namespace ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string _url = "";
        private HttpResponseMessage httpClientResponse;
        private bool _virginCard=true;
        public MainWindow()
        {
            InitializeComponent();

           
            
        }

        private async void txtKartNoGir_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtKartNoGir.Text.Length == 4)   
            {


                for (int i = 0; i < 100; i++)
                {
                    txtKartNoGir.Opacity -= 0.01;
                    imgbeklemek.Opacity += 0.01;
                    myMediaElement.Opacity -= 0.01;
                }
                


                Thread.Sleep(2000);
                txtKartNoGir.IsReadOnly = true;
              //  txtKartNoGir.IsKeyboardFocused();

                int istek = Convert.ToInt32(txtKartNoGir.Text);
                using (HttpClient client3 = new HttpClient())
                {
                    var response1 = await client3.GetAsync($"https://localhost:7264/api/switch/kartyonlendirme/{istek}");

                    await response1.Content.ReadAsStringAsync();
                    string Url_Tasiyici2 = await response1.Content.ReadAsStringAsync();

                    _url = Url_Tasiyici2;
                    httpClientResponse = response1;

                }

                if (httpClientResponse.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                {
                    using (HttpClient client4 = new HttpClient())
                    {
                        await client4.GetAsync("https://localhost:7264/api/switch/yonlendirmebasari/1");
                    }
                }
                else
                {
                    using (HttpClient client4 = new HttpClient())
                    {
                        await client4.GetAsync("https://localhost:7264/api/switch/yonlendirmebasari/0");
                    }
                }

               


                using (HttpClient client = new HttpClient())
                {
                    
                    if (httpClientResponse.IsSuccessStatusCode)
                    {


                        var response = await client.GetAsync($"{_url}api/giriskontrolleri/getmusteribyonlykartno/{istek}");

                        string DosyaKonum_Req = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\Log.txt";
                        using (StreamWriter sw = File.AppendText(DosyaKonum_Req))
                        {
                            sw.WriteLine($"{DateTime.Now} Tarihinde Sistemden Kart Numarasını Doğrulama İsteği Gönderildi");
                        }

                        if (response.IsSuccessStatusCode)
                        {
                            using (HttpClient client8 = new HttpClient())
                            {
                                var response8 = await client8.GetAsync($"https://localhost:7058/api/kullanicidogruluk/karttablokontrol/{istek}");
                                if (response8.IsSuccessStatusCode)
                                {
                                    _virginCard = true;
                                    await response.Content.ReadAsStringAsync();
                                    string mesaj = await response.Content.ReadAsStringAsync();

                                    double opacity_wait = lblwait.Opacity;

                                    double oapcity_media = myMediaElement.Opacity;

                                    int GirilenKartNo = Convert.ToInt32(mesaj);
                                    // MessageBox.Show(GirilenKartNo.ToString());

                                    // response Content content = await response.Content.ReadAsStringAsync();

                                    string DosyaKonum = @$"D:\VS22 PROJELER\AtmUygulamasıDeneme\Kayıtlar\{GirilenKartNo}.txt";

                                    using (StreamWriter sw = File.AppendText(DosyaKonum))
                                    {
                                        sw.WriteLine($"Kullanıcı,{GirilenKartNo} Numaralı Kart İle {DateTime.Now} Tarihinde Sisteme Giriş İzni İstedi");
                                    }
                                    _virginCard = true;
                                    // lblwait.Visibility = Visibility.Visible;
                                    Thread.Sleep(3000);

                                    YuklenmeSayfa yuklenmeSayfa = new YuklenmeSayfa(GirilenKartNo, _url, _virginCard);

                                    yuklenmeSayfa.Show();

                                    this.Hide();
                                }
                                else
                                {

                                    int GirilenKartNo = Convert.ToInt32(txtKartNoGir.Text);
                                    _virginCard = false;

                                    MessageBox.Show("Kart Sisteme Kayıt Olmamıştır Lütfen Kaydınızı Açılacak Ekranda Tamamlayınız.   ");

                                    YuklenmeSayfa yuklenmeSayfa = new YuklenmeSayfa(GirilenKartNo, _url, _virginCard);

                                    yuklenmeSayfa.Show();

                                    this.Hide();

                                }
                            }

                            
                        }
                        else
                        {
                            txtKartNoGir.IsReadOnly = false;
                            txtKartNoGir.Text = "";

                            imgbeklemek.Opacity = 0;
                            myMediaElement.Opacity = 1;
                            txtKartNoGir.Opacity = 0.12;
                            Thread.Sleep(2000);
                            String HataMesaj = "SİSTEM BU KARTI TANIYAMADI";
                            MessageBox.Show(HataMesaj);
                        }
                    }
                    
                    else
                    {
                        txtKartNoGir.IsReadOnly = false;
                        txtKartNoGir.Text = "";
                        
                        imgbeklemek.Opacity = 0;
                        myMediaElement.Opacity = 1;
                        txtKartNoGir.Opacity = 0.12;
                        Thread.Sleep(2000);
                        String HataMesaj = "SİSTEM BU KARTI TANIYAMADI";
                        MessageBox.Show(HataMesaj);

                    }

                }




               
            }
        }

        private void txtKartNoGir_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox txtKartNoGir)
            {
                string input = txtKartNoGir.Text;
                string numericInput = new string(input.Where(char.IsDigit).ToArray());

                if (input != numericInput)
                {
                    txtKartNoGir.Text = numericInput;
                    txtKartNoGir.CaretIndex = numericInput.Length;
                }
            }
        }
    }
}
