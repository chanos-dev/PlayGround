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

namespace _21_0801
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread th1 { get; set; }
        private Thread th2 { get; set; }
        private Foo FooInstance { get; set; } = null;

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 100000;

            richTextBox1.AppendText($"th1 is {th1?.ThreadState}.\n IsAlive: {th1?.IsAlive}\n");

            if (th1?.ThreadState == ThreadState.Running)
                return;

            if (th1 is null)
            {
                richTextBox1.AppendText("Create Th1\n");

                th1 = new Thread(() =>
                {
                    //th2 = new Thread(() =>
                    //{
                        try
                        {

                            foreach (var i in Enumerable.Range(1, total))
                            {
                                // Control.Invoke로 인해 UI Thread) th1.State -> WaitSleepJoin.
                                //if (progressBar1.InvokeRequired)
                                //{
                                //    progressBar1.Invoke(new Action(() =>
                                //    {
                                //        progressBar1.Value = i;
                                //        richTextBox1.AppendText($"th1 is {th1?.ThreadState}.\n IsAlive: {th1?.IsAlive}\n");
                                //    }));
                                //}
                                //else
                                {
                                    progressBar1.Value = i;
                                    richTextBox1.AppendText($"th1 is {th1?.ThreadState}.\n IsAlive: {th1?.IsAlive}\n");
                                }

                                // null exception
                                //if (i == total / 2)
                                //    MessageBox.Show($"{FooInstance.Value}");
                            }
                        }
                        catch (ThreadInterruptedException iex)
                        {
                            MessageBox.Show($"{iex.Message}");
                        }
                    //});

                    //th2.Start();
                }); 
            }

            progressBar1.Maximum = total;  

            
            th1.Start(); 
            //th1.Join();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //th1.Interrupt();
            th1.Join();

            MessageBox.Show("Test");
        }
    }

    internal class Foo
    {
        internal object Value { get; set; }
    } 
}
