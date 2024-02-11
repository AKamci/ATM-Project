using Newtonsoft.Json;
using System.IO;
using System.IO.Pipes;
using System.Text;
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





        public class Person
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
            Person person = JsonConvert.DeserializeObject<Person>(jsonContent);

            // Step 3: Update the object with the desired changes
            
            person.Banknot_200 = person.Banknot_200 - ikiYuz;

            person.Banknot_100 = person.Banknot_100 - Yuz;

            person.Banknot_50 = person.Banknot_50 - Elli;

            person.Banknot_20 = person.Banknot_20 - Yirmi;

            person.Banknot_10 = person.Banknot_10 - On; 

            person.Banknot_5 = person.Banknot_5 - Bes;

            // Step 4: Serialize the updated object back to JSON
            string updatedJsonContent = JsonConvert.SerializeObject(person, Formatting.Indented);

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
            Person person = JsonConvert.DeserializeObject<Person>(jsonContent);

            // Step 3: Update the object with the desired changes

            person.Banknot_200 = person.Banknot_200 + ikiYuz;

            person.Banknot_100 = person.Banknot_100 + Yuz;

            person.Banknot_50 = person.Banknot_50 + Elli;

            person.Banknot_20 = person.Banknot_20 + Yirmi;

            person.Banknot_10 = person.Banknot_10 + On;

            person.Banknot_5 = person.Banknot_5 + Bes;

            // Step 4: Serialize the updated object back to JSON
            string updatedJsonContent = JsonConvert.SerializeObject(person, Formatting.Indented);

            // Step 5: Write the JSON data back to the file
            File.WriteAllText(jsonFilePath, updatedJsonContent);

            Console.WriteLine("JSON data updated successfully!");
           

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnyenile_Click(object sender, EventArgs e)
        {

            try
            {
                // JSON dosyasýnýn yolunu belirleyin
                string jsonFilePath = @"D:\VS22 PROJELER\ATM_Server_Deneme_2\FormPara\Jsons.json";

                // JSON dosyasýnýn içeriðini bir string olarak okuyun
                string jsonContent = File.ReadAllText(jsonFilePath);

                // JSON verilerini bir nesneye dönüþtürün
                // Örnek olarak, JSON dosyasýnda bir dizi olsun ve her elemaný bir Person class'ýnýn özellikleri temsil etsin.
                List<Paralar> paralars = JsonConvert.DeserializeObject<List<Paralar>>(jsonContent);

                // Verileri ekrana yazdýrýn
                foreach (Paralar paralar in paralars)
                {
                    ikiyuz.Text = paralar.ikiyuz.ToString();
                    txtyuz.Text = paralar.yuz.ToString();
                    txtelli.Text = paralar.elli.ToString();
                    txtyirmi.Text = paralar.yirmi.ToString();
                    txton.Text = paralar.on.ToString();
                    txtbes.Text = paralar.bes.ToString();


                }
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
