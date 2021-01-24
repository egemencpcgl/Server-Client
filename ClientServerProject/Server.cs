using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ClientServerProject
{
    public partial class Server : Form
    {
        Thread t;
        IPAddress ipadresimiz;
        TcpListener dinle;
        NetworkStream ag;
        StreamWriter yaz;
        StreamReader oku;
        public delegate void ricdegis(string text);
        List<TcpClient> soketler = new List<TcpClient>();
        TcpClient soket;
        bool lampState = false;
        string state = "kapali";

        public Server()
        {
            InitializeComponent();
        }

        //Server'ı oluştur.
        public void ServerConn()
        {

            try
            {
                ipadresimiz = IPAddress.Parse("127.0.0.1");
                dinle = new TcpListener(IPAddress.Any, 1234);
                dinle.Start();
                Thread thread = new Thread(new ThreadStart(Dinle));
                thread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Dinleme baslatilamadi");
            }

        }
        public void Dinle()
        {
            while (true)
            {
                soket = dinle.AcceptTcpClient();
                soketler.Add(soket);
                foreach (var item in soketler)
                {
                    Thread thread = new Thread(new ParameterizedThreadStart(VeriAl));
                    thread.Start(item);
                }

            }
        }

        // Gelen veriyi sorgulara göre uygun yere atayıp gerekli işlemlerin yapılması.
        public void EkranaBas(string s)
        {
            if (s == "acik")
            {
                if (this.InvokeRequired)
                {
                    ricdegis degis = new ricdegis(EkranaBas);
                    this.Invoke(degis, s);
                }
                else
                {
                    lampBox.Image = ClientServerProject.Properties.Resources.acik_lamba;
                    lampBox.Refresh();
                    lampState = true;
                }
            }
            else if (s == "kapali")
            {
                if (this.InvokeRequired)
                {
                    ricdegis degis = new ricdegis(EkranaBas);
                    this.Invoke(degis, s);
                }
                else
                {
                    lampBox.Image = ClientServerProject.Properties.Resources.kapali_lamba;
                    lampBox.Refresh();
                    lampState = false;
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
                    rchTxtBox.Text = s;
                }
            }
        }

        // Client'tan gelen verileri oku ve yolla.
        public void VeriAl(object obj)
        {
            TcpClient client = (TcpClient)obj;
            //Socket skt = (Socket)obj;

            while (true)
            {
                try
                {
                    ag = client.GetStream();
                    oku = new StreamReader(ag);
                    string yazi = oku.ReadLine();
                    EkranaBas(yazi);
                }
                catch
                {
                    return;
                }
            }
        }
        public void VeriVer(string veri)
        {           
            try
            {
                foreach (var item in soketler)
                {
                    ag = item.GetStream();
                    yaz = new StreamWriter(ag);
                    yaz.WriteLine(veri);
                    yaz.Flush();
                }
            }
            catch
            {
                return;
            }
        }

        private void Server_Load(object sender, EventArgs e)
        {
            ServerConn();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            rchTxtBox.Text = rnd.Next().ToString();
            VeriVer(rchTxtBox.Text);

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (lampState != true)
            {
                lampBox.Load("Resources/acik-lamba.png");
                state = "acik";
                lampState = true;
                VeriVer(state.ToString());
            }
            else
            {
                for (int i = 0; i < soketler.Count; i++)
                {
                    lampBox.Load("Resources/kapali-lamba.png");
                    state = "kapali";
                    lampState = false;
                    VeriVer(state.ToString());
                }
            }
        }

        private void rchTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (rchTxtBox.Text == "")
            {
                MessageBox.Show("Boş alan gönderemezsiniz!");
            }
            else
            {
                for (int i = 0; i < soketler.Count; i++)
                {
                    VeriVer(rchTxtBox.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ag.Close();
            this.Close();
        }
    }
}
