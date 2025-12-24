using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.RomanovichEN.Sprint7.Project.V13
{
    public partial class FormStats_REN : Form
    {
        public FormStats_REN()
        {
            InitializeComponent();
        }

        public void SetStats(string sum, string avg, string min, string max)
        {
            textBoxSum.Text = sum;
            textBoxAvg.Text = avg;
            textBoxMin.Text = min;
            textBoxMax.Text = max;
        }
    }
}
