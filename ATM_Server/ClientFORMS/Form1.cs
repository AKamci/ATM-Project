using ClientWPF;

namespace ClientFORMS
{
    public partial class bank_Form : Form
    {
        public bank_Form()
        {
            InitializeComponent();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


           int Kupur_Update_Eksilen  = ClientWPF.TutarGir.ATM_Degisen_Para;













            int _Sayi5 = Convert.ToInt32(lbl_sayi_5.Text);
            int _Sayi10 = Convert.ToInt32(lbl_sayi_10.Text);
            int _Sayi20 = Convert.ToInt32(lbl_sayi_20.Text);
            int _Sayi50 = Convert.ToInt32(lbl_sayi_50.Text);
            int _Sayi100 = Convert.ToInt32(lbl_sayi_100.Text);
            int _Sayi200 = Convert.ToInt32(lbl_sayi_200.Text);


            //1981 deneme
            int _200_Sayi = Kupur_Update_Eksilen / 200; //9 Adet
            int _200den_Kalan = Kupur_Update_Eksilen % 200; //181 Tl

            int _100_Sayi = _200den_Kalan / 100; //1 Adet
            int _100den_Kalan = _200den_Kalan % 100;//81 Tl

            int _50_Sayi = _100den_Kalan / 50;//1 Adet
            int _50den_Kalan = _100den_Kalan % 50;//31 Tl

            int _20_Sayi = _50den_Kalan / 20;//1 Adet
            int _20den_Kalan = _50den_Kalan % 20;//11 Tl

            int _10_Sayi = _20den_Kalan / 10;//1 Adet
            int _10den_Kalan = _20den_Kalan % 10;//1 Tl

            int _5_Sayi = _10den_Kalan / 5;
            int _5den_Kalan = _10den_Kalan % 5;




















            

























        }
    }
}