using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21_0119
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationToken;
        private Task worker;

        public Form1()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            address add = new address();
            add.City = "Seoul";

            //textBox1.DataBindings.Add("Text", add, "City"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Town town = new Town();

            address address = new address();
            address.City = "Seoul";

            town["Korea"] = address;

            textBox1.DataBindings.Add("Text", town["Korea"], "City");

            Math Math = new Math();

            textBox2.Text = Math[6, 5].ToString();

            cancellationToken = new CancellationTokenSource();

            worker = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (this.cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    Thread.Sleep(500);

                    update();
                }
            }, this.cancellationToken.Token).ContinueWith((t) =>
            {
                listBox1.Items.Add(t.Status);
            });
        }

        private void update()
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => update()));
            }
            else
            {
                listBox1.Items.Add("1");
            }
        }
    }

    class address
    {
        private string city;
        public string City { get; set; }
    }

    class Town
    {
        public address this[string name]
        {
            get { return town[name]; }
            set { town[name] = value; }
        }

        private Dictionary<string, address> town = new Dictionary<string, address>();
    }

    class Math
    {
        public int this[int a, int b] => MUL(a, b);

        private int MUL(int a, int b)
        {
            return a * b;
        }
    }
}
