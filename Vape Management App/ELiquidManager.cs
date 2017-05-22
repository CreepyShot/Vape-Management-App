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
    public partial class ELiquidManager : Form
    {
        public ELiquidManager()
        {
            InitializeComponent();
        }
        string filePath = @"C:\Users\Creep\Desktop\Vape-Management-App\Vape Management App\ELiquidManagerDatabase.txt";

        List<string> lines = File.ReadAllLines(filePath).ToList();
        foreach(string line in lines)
        {
            

    }
}
