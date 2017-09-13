using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace ViewStateViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                Thread thread = new Thread(() =>
                {
                    try
                    {
                        throw new Exception();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
                thread.Start();

            //LosFormatter formatter = new LosFormatter();
            //Pair pair = formatter.Deserialize(richTextBox1.Text) as Pair;
        }
    }
}
