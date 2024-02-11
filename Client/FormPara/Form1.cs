using Newtonsoft.Json;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace FormPara
{
    public partial class Form1 : Form
    {
        private int Gelen_Para;
        private int Giden_Para;

        public Form1()
        {
            InitializeComponent();

        }





        public class MoneyClass
        {          
            public int DegisenPara { get; set; }
            public int Banknot_200 { get; set; }
            public int Banknot_100 { get; set; }
            public int Banknot_50 { get; set; }
            public int Banknot_20 { get; set; }
            public int Banknot_10 {get; set; }
            public int Banknot_5 { get; set; }
        }


        public static void ParaCekme(int aktarilanpara)
    {


            int[] banknotlar = { 200, 100, 50, 20, 10, 5 };
            int[] banknotAdetleri = new int[banknotlar.Length];

            for (int i = 0; i < banknotlar.Length; i++)
            {
                banknotAdetleri[i] = aktarilanpara / banknotlar[i];
                aktarilanpara %= banknotlar[i];
            }

            int ikiYuz = banknotAdetleri[0];
            int Yuz = banknotAdetleri[1];
            int Elli = banknotAdetleri[2];
            int Yirmi = banknotAdetleri[3];
            int On = banknotAdetleri[4];
            int Bes = banknotAdetleri[5];


            string jsonFilePath = @"D:\VS22 PROJELER\ATM_Server_Deneme_2\FormPara\Jsons.json";

            // Step 1: Read JSON data from the file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Step 2: Parse JSON data into a C# object
            MoneyClass _money = JsonConvert.DeserializeObject<MoneyClass>(jsonContent);

            // Step 3: Update the object with the desired changes

            _money.Banknot_200 = _money.Banknot_200 - ikiYuz;

            _money.Banknot_100 = _money.Banknot_100 - Yuz;

            _money.Banknot_50 = _money.Banknot_50 - Elli;

            _money.Banknot_20 = _money.Banknot_20 - Yirmi;

            _money.Banknot_10 = _money.Banknot_10 - On;

            _money.Banknot_5 = _money.Banknot_5 - Bes;

            // Step 4: Serialize the updated object back to JSON
            string updatedJsonContent = JsonConvert.SerializeObject(_money, Formatting.Indented);

            // Step 5: Write the JSON data back to the file
            File.WriteAllText(jsonFilePath, updatedJsonContent);

            Console.WriteLine("JSON data updated successfully!");

        }

        public static void ParaYukleme(int aktarilanpara)
        {


            int[] banknotlar = { 200, 100, 50, 20, 10, 5 };
            int[] banknotAdetleri = new int[banknotlar.Length];

            for (int i = 0; i < banknotlar.Length; i++)
            {
                banknotAdetleri[i] = aktarilanpara / banknotlar[i];
                aktarilanpara %= banknotlar[i];
            }

            int ikiYuz = banknotAdetleri[0];
            int Yuz = banknotAdetleri[1];
            int Elli = banknotAdetleri[2];
            int Yirmi = banknotAdetleri[3];
            int On = banknotAdetleri[4];
            int Bes = banknotAdetleri[5];


            string jsonFilePath = @"D:\VS22 PROJELER\ATM_Server_Deneme_2\FormPara\Jsons.json";

            // Step 1: Read JSON data from the file
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Step 2: Parse JSON data into a C# object
            MoneyClass _money = JsonConvert.DeserializeObject<MoneyClass>(jsonContent);

            // Step 3: Update the object with the desired changes

            _money.Banknot_200 = _money.Banknot_200 + ikiYuz;

            _money.Banknot_100 = _money.Banknot_100 + Yuz;

            _money.Banknot_50 = _money.Banknot_50 + Elli;

            _money.Banknot_20 = _money.Banknot_20 + Yirmi;

            _money.Banknot_10 = _money.Banknot_10 + On;

            _money.Banknot_5 = _money.Banknot_5 + Bes;

            // Step 4: Serialize the updated object back to JSON
            string updatedJsonContent = JsonConvert.SerializeObject(_money, Formatting.Indented);

            // Step 5: Write the JSON data back to the file
            File.WriteAllText(jsonFilePath, updatedJsonContent);

            Console.WriteLine("JSON data updated successfully!");

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Yenile_Click(object sender, EventArgs e)
        {


            try
            {
                // JSON dosyasýnýn yolunu belirleyin
                string jsonFilePath = @"D:\VS22 PROJELER\ClientDeneme_1\FormPara\Jsons.json";

                // JSON dosyasýnýn içeriðini bir string olarak okuyun
                string jsonContent = File.ReadAllText(jsonFilePath);

                // JSON verilerini bir nesneye dönüþtürün
                // Örnek olarak, JSON dosyasýnda bir dizi olsun ve her elemaný bir Person class'ýnýn özellikleri temsil etsin.
                
                
                JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
                JsonElement root = jsonDocument.RootElement;
                JsonElement IkýYuzL = root.GetProperty("Banknot_200");
                JsonElement YuzL = root.GetProperty("Banknot_100");
                JsonElement ElliL = root.GetProperty("Banknot_50");
                JsonElement YirmiL = root.GetProperty("Banknot_20");
                JsonElement OnL = root.GetProperty("Banknot_10");
                JsonElement BesL = root.GetProperty("Banknot_5");





                    ikiyuz.Text = IkýYuzL.ToString();
                    txtyuz.Text = YuzL.ToString();
                    txtelli.Text = ElliL.ToString();
                    txtyirmi.Text = YirmiL.ToString();
                    txton.Text = OnL.ToString();
                    txtbes.Text = BesL.ToString();

                
                
                txttoplam.Text = (

                    (Convert.ToInt32(IkýYuzL) * 200) + (Convert.ToInt32(YuzL) * 100) + (Convert.ToInt32(ElliL) * 50) + (Convert.ToInt32(OnL) * 10) + (Convert.ToInt32(BesL) * 5)
                    
                    ).ToString();  
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluþtu: " + ex.Message);
            }
        }




        class Paralar
        {
            public int ikiyuz { get; set; }
            public int yuz { get; set; }
            public int elli { get; set; }
            public int yirmi { get; set; }
            public int on { get; set; }
            public int bes { get; set; }


        }










    }
}
