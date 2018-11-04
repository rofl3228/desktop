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
        public class Responce
        {
            public string Token { get; private set; }
            public string Code { get; private set; }
            public string Type { get; private set; }

            public Responce(string input)
            {
                string[] pairs = input.Split(new char[] { ';' });
                int size = 0;
                foreach (var q in pairs)
                    size++;
                string[,] parsed = new string[2, size];
                for (int i = 0; i < size; i++)
                {
                    string[] wear = pairs[i].Split(new char[] { ' ' });
                    parsed[0, i] = wear[0]; parsed[1, i] = wear[1];
                }
                for (int i = 0; i < size; i++)
                {
                    if (parsed[0, i] == "token") Token = parsed[1, i];
                    if (parsed[0, i] == "code") Code = parsed[1, i];
                    if (parsed[0, i] == "type") Type = parsed[1, i];
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            
        }

        Responce answer;

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

        public string GetToken() => answer.Token;

        public string GetUserType() => answer.Type;

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        string code;
        static int port = 1500;
        static string addres = "185.227.111.201";
        

        private void Form1_Load(object sender, EventArgs e)
        {
            loginPanel.BackColor = Color.Transparent;
            authPanel.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.Text = "";
            StatusLable.Text = "";

            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(addres), port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(ipPoint);
            //if(socket.Connected) Consist.Text = "Connected";
            string authData = "login " + LoginBox.Text + "; password " + CalculateMD5Hash(PassBox.Text);
            byte[] data = Encoding.Unicode.GetBytes(authData);
            socket.Send(data);
            //if(socket.SendBufferSize > 0)Consist.Text = "Recived";

            data = new byte[256];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = socket.Receive(data, data.Length, 0);
                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
            }
            while (socket.Available > 0);
            answer = new Responce(builder.ToString());

            if(answer.Token != "null")
            {
                //StatusLable.Text = "Вход выполнен";
                code = answer.Code;
                loginPanel.Visible = false;
                loginPanel.Enabled = false;
                authPanel.Enabled = true;
                authPanel.Visible = true;
            }
            else
            {
                Consist.Text = "Ошибка входа";
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        private void Authication_TextChanged(object sender, EventArgs e)
        {
            if(Authication.Text == code)
            {
                authPanel.Visible = false;
                authPanel.Enabled = false;
                
                Hide();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void authPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
