using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vape_Management_App
{
    public partial class Main_Screen : Form
    {
        public Main_Screen()
        {
            InitializeComponent();
        }


        decimal nicbase, vgbase, pgbase, flavoring, totalrecipe,flavor1base, flavor2base;

        private void NUMERIC_PG_ValueChanged(object sender, EventArgs e)
        {
            NUMERIC_VG.Value = 100 - NUMERIC_PG.Value;
        }

        private void NUMERIC_VG_ValueChanged(object sender, EventArgs e)
        {
            NUMERIC_PG.Value = 100 - NUMERIC_VG.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vgbase = NUMERIC_BATCH.Value * (NUMERIC_VG.Value / 100);
            pgbase = NUMERIC_BATCH.Value * (NUMERIC_PG.Value / 100);
            flavor1base = NUMERIC_BATCH.Value * (NUMERIC_FLAVOR1.Value / 100);
            flavor2base = NUMERIC_BATCH.Value * (NUMERIC_FLAVOR2.Value / 100);
            pgbase = pgbase - flavor1base - flavor2base - nicbase;
            totalrecipe = vgbase + pgbase + flavor1base + flavor2base + nicbase;
            if (NUMERIC_BASE.Value != 0)
            {
                nicbase = NUMERIC_BATCH.Value / NUMERIC_BASE.Value * NUMERIC_TARGET.Value;
            }
            if (NUMERIC_BATCH.Value != totalrecipe)
            {
                MessageBox.Show("Error, this liquid is not do-able");
            }
            // Print Values Onto Labels
            Label_Recipe_Nic.Text = nicbase.ToString();
            Label_Recipe_VG.Text = vgbase.ToString();
            Label_Recipe_Total.Text = totalrecipe.ToString();
            Label_Recipe_Flavor2.Text = flavor2base.ToString();
            Label_Recipe_PG.Text = pgbase.ToString();
            Label_Recipe_Flavor1.Text = flavor1base.ToString();


        }

    }
}
