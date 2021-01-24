using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Net;

namespace Client
{
    public partial class Client : Form
    {
        Thread t;
        TcpClient baglantikur;
        NetworkStream ag;
        StreamReader oku;
        StreamWriter yaz;
        string durum = "kapali";
        public delegate void ricdegis(string text);

        public Client()
        {
            InitializeComponent();
        }

        //Oluşturduğumu server'a bağlantıyı gerçekleştir.
        public void Client_Load(object sender, EventArgs e)
        {
            try
            {
                //Lochalhos üzerinde deneme yapacagim icin 127.0.0.1 verdim.
                baglantikur = new TcpClient("127.0.0.1", 1234);
                t = new Thread(new ThreadStart(OkumayaBasla));
                t.Start();
            }
            catch (Exception)
            {

                MessageBox.Show("Server ile baglanti kurulurken hata olustu !");
            }
        }

        //Server'dan gelen veriyi sorgulara göre atayıp gerekli işlemleri gerçekleştir.
        public void EkranaBas(string s)
        {
            if (s =="acik")
            {
                if (this.InvokeRequired)
                {
                    ricdegis degis = new ricdegis(EkranaBas);
                    this.Invoke(degis, s);
                }
                else
                {
                    btnLamp.BackColor = Color.Orange;
                    btnLamp.Text = "Açık";
                    durum = "acik";
                }
            }
            else if (s =="kapali")
            {
                if (this.InvokeRequired)
                {
                    ricdegis degis = new ricdegis(EkranaBas);
                    this.Invoke(degis, s);
                }
                else
                {
                    btnLamp.BackColor = Color.Gainsboro;
                    btnLamp.Text = "Kapalı";
                    durum = "kapali";
                }
            }
            else
            {
                if (this.InvokeRequired)
                {
                    ricdegis degis = new ricdegis(EkranaBas);
                    this.Invoke(degis, s);
                }
                else
                {
                    btnText.Text = s.ToString();
                }
            }
        }
        //Gelen veriyi oku.
        public void OkumayaBasla()
        {
            ag = baglantikur.GetStream();
            oku = new StreamReader(ag);
            yaz = new StreamWriter(ag);
            while (true)
            {
                try
                {                   
                    string yazi = oku.ReadLine();
                    EkranaBas(yazi);
                }
                catch
                {
                    return;
                }
            }
        }        
        private void btnText_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string randNum = rnd.Next().ToString();
            
            yaz.WriteLine(randNum.ToString());
            yaz.Flush();
            btnText.Text = randNum.ToString();
        }
        public void btnLamp_Click(object sender, EventArgs e)
        {
            
            if (durum=="acik")
            {
                btnLamp.BackColor = Color.Gainsboro;
                btnLamp.Text = "Kapalı";
                durum = "kapali";
                yaz.WriteLine(durum);
                yaz.Flush();

            }
            else if (durum=="kapali")
            {
                btnLamp.BackColor = Color.Orange;
                btnLamp.Text = "Açık";
                durum = "acik";
                yaz.WriteLine(durum);
                yaz.Flush();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglantikur.Client.Close();
            this.Close();
        }
    }
}

