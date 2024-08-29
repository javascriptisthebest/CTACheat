using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace CTACheat
{
    public partial class EZMode : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public EZMode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "CTA 4 (Frozen Tuna)")
            {
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("You must select an action!");
                }
                else
                {
                    string path = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Catto_Boi___The_Quest_for_the_Frozen_Tuna";
                    switch (comboBox2.SelectedItem)
                    {
                        case "Give myself 999 lives":
                            Utils.Utils.decrypt_file(path, "frozen_tuna", "catto", "katto");
                            Console.WriteLine(WritePrivateProfileString("Frozen-Tuna", "Lives", "\"999\"", path + "\\file.ini"));
                            Utils.Utils.encrypt_file(path, "frozen_tuna", "catto", "katto");
                            break;
                        case "Change ACT to 2":
                            Utils.Utils.decrypt_file(path, "frozen_tuna", "catto", "katto");
                            Console.WriteLine(WritePrivateProfileString("Frozen-Tuna", "ACT", "\"2\"", path + "\\file.ini"));
                            Utils.Utils.encrypt_file(path, "frozen_tuna", "catto", "katto");
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a game!");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
