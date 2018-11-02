using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        static int port = 1500;
        static string addres = "185.227.111.201";
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Consist.Text = "No conn";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.Text = "";
            StatusLable.Text = "";

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(addres), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(ipPoint);
            if(socket.Connected) Consist.Text = "Connected";
            string authData = "login " + LoginBox.Text + ";password " + PassBox.Text;
            byte[] data = Encoding.Unicode.GetBytes(authData);
            socket.Send(data);
            if(socket.SendBufferSize > 0)Consist.Text = "Recived";

            data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            string answer = builder.ToString();

            Debug.Text = answer;

            string[] input = answer.Split(new char[] { ' ' });
            if(input[0] == "token" && input[1] != "null")
            {
                StatusLable.Text = "Вход выполнен";
                Debug.Visible = false;
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
