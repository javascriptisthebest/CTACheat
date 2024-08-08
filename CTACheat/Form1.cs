using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;
using System.Drawing.Text;
using static System.Windows.Forms.Timer;
namespace CTACheat
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        public Form1()
        {
            InitializeComponent();
            this.Shown += new System.EventHandler(Form1_Shown);
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            while(true)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                ChangeTitle();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 info = new Form2();
            info.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utils.Utils.decrypt_file(textBox3.Text, textBox1.Text, "catto", "katto");

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Utils.Utils.encrypt_file(textBox3.Text, textBox1.Text, "catto", "katto");
        }


        private void button4_Click(object sender, EventArgs e)
        {
            AllocConsole();
            Random RNG = new Random();
            int hate = RNG.Next(100);
            //Console.WriteLine(hate);
            if (hate > 84)
            {
                Console.WriteLine("CTACheat - A cheat tool for the game we all hate");
            }
            else
            {
                Console.WriteLine("CTACheat - A cheat tool for the game we all love");
            }
            Console.WriteLine("Built on " + Properties.Resources.test);
            Console.WriteLine("WARNING: Be careful while editing the decrypted file.ini, improper changes can result in your savegame being unusable!");

        }
        string[] titleNames = ["No more anti-cheat, checkmate", "Can't get past the pre-chase sequence, LOL!", "noodles are tasty", "LINUX SUPREMACY", "testing testing ABCDEFGHIJKLMNOPQRSTUVWYZ 1234567890", ""];
        private void ChangeTitle()
        {
            int randomtitle = RandomNumberGenerator.GetInt32(titleNames.Length);
            button1.FindForm().Text = "CTACheat -- " + titleNames[randomtitle] + " -- v2.0.1";
        }
    }
}
