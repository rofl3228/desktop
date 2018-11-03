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
using System.Security.Cryptography;

namespace DesktopApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);


            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }



        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        string[] input;
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
            string authData = "login " + LoginBox.Text + ";password " + CalculateMD5Hash(PassBox.Text);
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

            //Debug.Text = answer;

            input = answer.Split(new char[] { ' ' });
            if(input[0] == "token" && input[1] != "null")
            {
                StatusLable.Text = "Вход выполнен";
                loginPanel.Visible = false;
                loginPanel.Enabled = false;
                authPanel.Enabled = true;
                authPanel.Visible = true;
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private void Authication_TextChanged(object sender, EventArgs e)
        {
            if(Authication.Text == input[3])
            {
                authPanel.Visible = false;
                authPanel.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
