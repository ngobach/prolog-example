using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SbsSW.SwiPlCs;

namespace PrologExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\Program Files (x86)\swipl");
            Environment.SetEnvironmentVariable("Path", Environment.GetEnvironmentVariable("Path") + @";C:\Program Files (x86)\swipl\bin");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] args = { "-q" };
            PlEngine.Initialize(args);
            using (var query = new PlQuery("member(X, [ngo, xuan, bach])."))
            {
                foreach (var sol in query.SolutionVariables)
                {
                    MessageBox.Show(sol["X"].ToString());
                }
            }
        }
    }
}
