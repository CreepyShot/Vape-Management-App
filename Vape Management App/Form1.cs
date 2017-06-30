using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Vape_Management_App
{
    public partial class Main_Screen : Form
    {
        public Main_Screen()
        {
            InitializeComponent();
        }


        decimal nicbase, vgbase, pgbase, totalrecipe,flavor1base, flavor2base, flavor3base, flavor4base;
        int i;

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            string filePath = @"C:\Users\Creep\Desktop\Vape-Management-App\Vape Management App\ELiquidManagerDatabase.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');

                Liquids newLiquid = new Liquids();
                newLiquid.brand = entries[0];
                newLiquid.name = entries[1];
                newLiquid.amount = entries[2];
                newLiquid.vgpg = entries[3];
                newLiquid.nicotine = entries[4];
                textBox1.Text = newLiquid.name;
                
            }
        }

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
            flavor3base = NUMERIC_BATCH.Value * (NUMERIC_FLAVOR3.Value / 100);
            flavor4base = NUMERIC_BATCH.Value * (NUMERIC_FLAVOR4.Value / 100);
            pgbase = pgbase - flavor1base - flavor2base - flavor3base - flavor4base - nicbase;
            totalrecipe = vgbase + pgbase + flavor1base + flavor2base + flavor3base + flavor4base + nicbase;
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
            Label_Recipe_Flavor3.Text = flavor3base.ToString();
            Label_Recipe_Flavor4.Text = flavor4base.ToString();


        }

    }
}
