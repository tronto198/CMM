using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class Form4 : Form
    {
        Form1 main = new Form1();


        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void bt_normal_Click(object sender, EventArgs e)
        {
            cb_true.Checked = true;
            cb_down_spike.Checked = false;
            cb_up_spike.Checked = false;
            cb_fake.Checked = false;
            cb_false.Checked = false;
            cb_trap.Checked = false;
            cb_spike_false.Checked = false;
        }


        private void cb_false_MouseClick(object sender, MouseEventArgs e)
        {
            cb_trap.Enabled = true;
            cb_true.Checked = false;
            cb_fake.Checked = false;
            cb_fake.Enabled = false;

            cb_spike_false.Checked = true;
            cb_spike_false.Enabled = false;
            cb_down_spike.Checked = false;
            cb_down_spike.Enabled = false;
        }

        private void cb_true_MouseClick(object sender, MouseEventArgs e)
        {
            cb_fake.Enabled = true;
            cb_false.Checked = false;
            cb_trap.Checked = false;
            cb_trap.Enabled = false;
            cb_spike_false.Enabled = true;
            cb_down_spike.Enabled = true;
        }

        private void bt_notspike_Click(object sender, EventArgs e)
        {
            cb_spike_false.Checked = false;
            cb_up_spike.Checked = false;
            cb_down_spike.Checked = false;
        }



        private void cb_trap_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cb_fake_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_fake.Checked == true)
            {
                cb_down_spike.Enabled = false;
                cb_down_spike.Checked = false;
                cb_up_spike.Enabled = false;
                cb_up_spike.Checked = false;
                cb_spike_false.Enabled = false;
                cb_spike_false.Checked = false;
            }
            else
            {
                cb_down_spike.Enabled = true;
                cb_down_spike.Checked = false;
                cb_up_spike.Enabled = true;
                cb_up_spike.Checked = false;
                cb_spike_false.Enabled = true;
                cb_spike_false.Checked = false;
            }
        }

        private void cb_trap_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_trap.Checked == false)
            {
                cb_down_spike.Enabled = true;
            }
        }

        private void cb_false_CheckedChanged(object sender, EventArgs e)
        {
            if(cb_false.Checked == false)
            {
                cb_spike_false.Checked = false;
            }
        }
    }
}
