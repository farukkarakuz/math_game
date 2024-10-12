namespace MatematikOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabControl1.SelectedTab = tabPage1;

            // Form kapanýrken seviyeyi kaydet
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Seviye dosyasýný oku
            if (File.Exists("seviye.txt"))
            {
                using (StreamReader reader = new StreamReader("seviye.txt"))
                {
                    string seviyeStr = reader.ReadLine();
                    if (int.TryParse(seviyeStr, out int kaydedilenSeviye))
                    {
                        seviye = kaydedilenSeviye;
                    }
                    else
                    {
                        seviye = 1; // Dosya bozulmuþsa veya bir hata varsa varsayýlan seviye 1
                    }
                }
            }
            else
            {
                seviye = 1; // Dosya yoksa oyuna seviye 1'den baþla
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("seviye.txt"))
            {
                writer.WriteLine(seviye);
            }
        }

        int seviye = 0;
        int duzey = 0;
        int puan = 0;
        int dogru = 0;
        int yanlis = 0;
        int pas = 0;
        string[] operators = { "+", "-", "*", "/" };
        List<string> pasList = new List<string>();
        string yildiz;
        int time;
        Soru s1 = new Soru();
        Soru s2 = new Soru();
        Soru s3 = new Soru();
        Soru s4 = new Soru();
        Soru s5 = new Soru();
        Player player1 = new Player();


        // baþla butonu oyuncu isim girdikten sonra basýlýr
        private void button1_Click(object sender, EventArgs e)
        {
            player1.name = textBox1.Text;
            tabControl1.SelectedTab = tabPage2;
            label3.Text = player1.name.ToUpper();
            duzey = 1;
            label7.Text = duzey + "/4";
            label5.Text = puan.ToString();

            if (seviye == 1)
            {
                time = 60;
            }
            else if (seviye == 2)
            {
                time = 90;
            }
            else if (seviye == 3)
            {
                time = 120;
            }
            else if (seviye == 4)
            {
                time = 150;
            }
            else if (seviye == 5)
            {
                time = 180;
            }
            timer1.Start();
            label11.Text = time.ToString();
            label9.Text = seviye.ToString();
            button3.Visible = false;

            islemolustur();
        }


        // sayi üretip nesne oluþturma fonksiyonu
        void islemolustur()
        {
            s1.Sayi1 = Islem.sayiuret(seviye);
            s1.Sayi2 = Islem.sayiuretsifirsiz(seviye);
            s1.op = Islem.operatoruret(operators);

            s2.Sayi1 = Islem.sayiuret(seviye);
            s2.Sayi2 = Islem.sayiuretsifirsiz(seviye);
            s2.op = Islem.operatoruret(operators);

            s3.Sayi1 = Islem.sayiuret(seviye);
            s3.Sayi2 = Islem.sayiuretsifirsiz(seviye);
            s3.op = Islem.operatoruret(operators);

            s4.Sayi1 = Islem.sayiuret(seviye);
            s4.Sayi2 = Islem.sayiuretsifirsiz(seviye);
            s4.op = Islem.operatoruret(operators);

            s5.Sayi1 = Islem.sayiuret(seviye);
            s5.Sayi2 = Islem.sayiuretsifirsiz(seviye);
            s5.op = Islem.operatoruret(operators);

            label12.Text = s1.Sayi1.ToString() + " " + s1.op + " " + s1.Sayi2;
            label15.Text = s2.Sayi1.ToString() + " " + s2.op + " " + s2.Sayi2;
            label17.Text = s3.Sayi1.ToString() + " " + s3.op + " " + s3.Sayi2;
            label19.Text = s4.Sayi1.ToString() + " " + s4.op + " " + s4.Sayi2;
            label21.Text = s5.Sayi1.ToString() + " " + s5.op + " " + s5.Sayi2;
        }

        // cevapla butonu, sorulara cevap verildikten sonra yapýlýr
        private void button2_Click(object sender, EventArgs e)
        {
            check();
            time += 20;
            islemolustur();
            if (duzey == 4)
            {
                button2.Visible = false;
                button3.Visible = true;

            }

        }



        // verilen cevaplarýn puanlarýný hesapla kýsmý, eðer iþlem operatörü çarpma veya bölmeyse seviye kadar
        // puan verir. deðilse her doðru soruya 1 puan verir.
        void check()
        {
            if (checkBox1.Checked)
            {
                pasList.Add(s1.Sayi1.ToString());
                pasList.Add(s1.op);
                pasList.Add(s1.Sayi2.ToString());

                pas++;
            }
            else if (textBox2.Text == Islem.sonuccikar(s1.Sayi1, s1.Sayi2, s1.op).ToString())
            {
                if (s1.op == "*" || s1.op == "/")
                {
                    dogru += seviye;
                }
                else
                {
                    dogru++;
                }
            }
            else
            {
                yanlis++;
            }

            if (checkBox2.Checked)
            {
                pasList.Add(s2.Sayi1.ToString());
                pasList.Add(s2.op);
                pasList.Add(s2.Sayi2.ToString());
                pas++;
            }
            else if (textBox3.Text == Islem.sonuccikar(s2.Sayi1, s2.Sayi2, s2.op).ToString())
            {
                if (s2.op == "*" || s2.op == "/")
                {
                    dogru += seviye;
                }
                else
                {
                    dogru++;
                }
            }
            else
            {
                yanlis++;
            }

            if (checkBox3.Checked)
            {
                pasList.Add(s3.Sayi1.ToString());
                pasList.Add(s3.op);
                pasList.Add(s3.Sayi2.ToString());
                pas++;
            }
            else if (textBox4.Text == Islem.sonuccikar(s3.Sayi1, s3.Sayi2, s3.op).ToString())
            {
                if (s3.op == "*" || s3.op == "/")
                {
                    dogru += seviye;
                }
                else
                {
                    dogru++;
                }
            }
            else
            {
                yanlis++;
            }

            if (checkBox4.Checked)
            {
                pasList.Add(s4.Sayi1.ToString());
                pasList.Add(s4.op);
                pasList.Add(s4.Sayi2.ToString());
                pas++;
            }
            else if (textBox5.Text == Islem.sonuccikar(s4.Sayi1, s4.Sayi2, s4.op).ToString())
            {
                if (s4.op == "*" || s4.op == "/")
                {
                    dogru += seviye;
                }
                else
                {
                    dogru++;
                }
            }
            else
            {
                yanlis++;
            }

            if (checkBox5.Checked)
            {
                pasList.Add(s5.Sayi1.ToString());
                pasList.Add(s5.op);
                pasList.Add(s5.Sayi2.ToString());
                pas++;
            }
            else if (textBox6.Text == Islem.sonuccikar(s5.Sayi1, s5.Sayi2, s5.op).ToString())
            {
                if (s5.op == "*" || s5.op == "/")
                {
                    dogru += seviye;
                }
                else
                {
                    dogru++;
                }
            }
            else
            {
                yanlis++;
            }

            duzey++;
            label7.Text = duzey + "/4";
            puan = dogru - yanlis;
            label5.Text = puan.ToString();

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }



        // burada seviyemiz bitiyor ve ilgili seviyenin sonuçlarý karþýmýza çýkýyor
        private void button3_Click(object sender, EventArgs e)
        {
            check();
            tabControl1.SelectedTab = tabPage3;
            label23.Text = player1.name;
            if (pas == 0)
            {
                button6.Visible = false;
            }
            else
            {
                button6.Visible = true;
            }


            // eðer pas sayýmýz 1'den fazlaysa puaný düþürüyoruz
            if (pas > 1)
            {
                puan -= pas - 1;
            }

            // yýldýz hesaplamasý için puan 20 den fazlaysa puaný 20ye çekiyoruz
            if (puan > 20)
            {
                puan = 20;
            }

            if (puan < 11)
            {
                button5.Visible = true;
                button4.Visible = false;
            }
            else
            {
                button4.Visible = true;
                button5.Visible = false;
            }


            if (11 <= puan && puan <= 15)
            {
                yildiz = "*";
            }
            else if (15 < puan && puan <= 18)
            {
                yildiz = "* *";
            }
            else if (18 < puan && puan <= 20)
            {
                yildiz = "* * *";
            }
            label26.Text = yildiz;
            label25.Text = puan.ToString();
            label27.Text = seviye.ToString();
        }

        // eðer baþarýsýz olursa baþa dön fonksiyonu
        private void button5_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = false;
            tabControl1.SelectedTab = tabPage2;
            puan = 0;
            seviye = 1;
            dogru = 0;
            yanlis = 0;
            label5.Text = puan.ToString();
            duzey = 1;
            label7.Text = duzey.ToString() + "/4";
            pasList.Clear();
        }


        // baþarýlý olursa diðer seviyeye geçme butonu
        private void button4_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = false;

            label9.Text = seviye.ToString();
            puan = 0;
            dogru = 0;
            yanlis = 0;
            label5.Text = puan.ToString();
            duzey = 1;
            label7.Text = duzey.ToString() + "/4";
            tabControl1.SelectedTab = tabPage2;
            pasList.Clear();
            if (seviye == 5)
            {
                MessageBox.Show("Tebrikler kazandýnýz !!!!!");
            }
            seviye++;
            Close();

        }


        void PasSorulariniGoster()
        {

            label29.Text = "";
            int toplamEleman = pasList.Count;


            for (int i = 0; i < toplamEleman; i += 3)
            {

                string satir = "";


                for (int j = 0; j < 3; j++)
                {
                    if (i + j < toplamEleman)
                    {
                        satir += pasList[i + j] + " ";
                    }
                }


                label29.Text += satir.Trim() + Environment.NewLine;
            }
        }



        // pas sorularýný gösteren butonun fonksiyonu
        private void button6_Click(object sender, EventArgs e)
        {
            PasSorulariniGoster();
            tabControl1.SelectedTab = tabPage4;

        }

        // pas sorularýndan geri dönme butonu
        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            label11.Text = time.ToString();
            if (time == 0)
            {
                timer1.Stop();
                MessageBox.Show("Süreniz doldu!");
                Close();

            }
            timer1.Interval = 1000;
        }

    
    }

}