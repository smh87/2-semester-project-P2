using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;


namespace Project
{
    
    public partial class P2 : Form
    {
        private string nameOfFile;
        public static string passingText;
        public P2()
        {
            InitializeComponent();
        }

        public void AddItemToList(string a, double b )
        {
            string d;
            if (b != 0)
            {
                b = b * 100;
                if (b > 100)
                {
                    b = 100;
                }
                d = String.Format("{0:0.00}", b) + " %";
            }
            else
            {
                d = "";
            }

            var row1 = new string[] {d, a};
            var item1 = new ListViewItem(row1);
            listView1.Items.Add(item1);
        }

        private void Button1_Click(object sender, EventArgs e)//this is the check button
        {
            int i = 0;
            Boolean foundPlagerism = false;
            passingText = textBox1.Text;
            //Kald af Program Class fra UI check knap
            Program MainCode = new Program();
            //Main function
            double[] arrayOfPercantages = MainCode.RunPlagiarismCheck(passingText);
            if (arrayOfPercantages == null) {
                AddItemToList("Text is not long enough", 0);
                return;
            }
            AddItemToList(nameOfFile + " has been checked", 0);
            while (i < arrayOfPercantages.Length)
            {
                if (arrayOfPercantages[i] * 100 > 5)
                {
                    AddItemToList(MainCode.ArrayOfTextsNames[i], arrayOfPercantages[i]);
                    foundPlagerism = true;
                }
                i++;
            }
            if (!foundPlagerism)
            {
                AddItemToList("Found no plagerism", 0);
            }


        }

        private void Button2_Click(object sender, EventArgs e)
        { 
            //this is the upload buttion
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {           
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    nameOfFile = openFileDialog1.FileName;
                    nameOfFile = Path.GetFileName(nameOfFile);
                    string strfilename = openFileDialog1.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    textBox1.Text = filetext;
                }
            }
        }
    }
}
