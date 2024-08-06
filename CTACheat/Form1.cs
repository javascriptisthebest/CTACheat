using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Security.Cryptography;


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
            Utils.Utils.decrypt_file(textBox3.Text, textBox1.Text, "katto", "catto");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Utils.Utils.encrypt_file(textBox3.Text, textBox1.Text, "katto", "catto");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
