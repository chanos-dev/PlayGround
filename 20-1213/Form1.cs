using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20_1213
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();  
            DataSet ds2 = new DataSet(); 

            Boo(ds);
            Boo(ds);
            Boo(ds);
            Boo(ds);
            Foo(ds2); 

            //MessageBox.Show(ds.Tables.Count.ToString());
            MessageBox.Show(ds2.Tables.Count.ToString());

            TEST t1 = new TEST();
            Qoo(ref t1);
            MessageBox.Show(t1.test);
        }  

        private void Qoo(ref TEST t)
        {
            TEST t2 = new TEST();
            t2.test = "HIHI";
            t = t2;
        }

        private void Boo(DataSet ds)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ColA", typeof(string));
            ds.Tables.Add(dt);
        }

        private void Foo(DataSet ds)
        {
            DataSet newDs = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ColA", typeof(string));
            newDs.Tables.Add(dt); 
            ds = newDs;
        }

        private void Boo(ref DataSet ds)
        {
            DataSet newDs = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ColA", typeof(string));
            newDs.Tables.Add(dt);
            ds = newDs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 10;
            VAL(a);
            MessageBox.Show($"{a}");
            REF(ref a);
            MessageBox.Show($"{a}");
            OUT(out a);
            MessageBox.Show($"{a}");
            IN(in a);
            MessageBox.Show($"{a}");
        }

        private void VAL(int A)
        {
            A += 10;
        }

        private void REF(ref int A)
        {
            A += 10;
        }

        private void OUT(out int A)
        {
            A = 50;
        }

        private void IN(in int A)
        {
            //A = 10; readonly
            MessageBox.Show($"{A}");
        }
    }

    class TEST
    {
        public string test { get; set; }
    }

}
