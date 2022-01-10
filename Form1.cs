using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inheritance
{
    public partial class Form1 : Form
    {
        List<Instruments> instrumentsList = new List<Instruments>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.instrumentsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; i++)
            {
                switch(rnd.Next() % 3)
                {
                    case 0:
                        this.instrumentsList.Add(Strings.Generate());
                        break;
                    case 1:
                        this.instrumentsList.Add(Keyboards.Generate());
                        break;
                    case 2:
                        this.instrumentsList.Add(Drums.Generate());
                        break;
                }
            }
            ShowInfo();
        }

        private void ShowInfo()
        {
            int stringCount = 0;
            int keyboardCount = 0;
            int drumCount = 0;

            foreach (var instruments in this.instrumentsList)
            {
                if (instruments is Strings)
                {
                    stringCount += 1;
                }
                else if (instruments is Keyboards)
                {
                    keyboardCount += 1;
                }
                else if (instruments is Drums)
                {
                    drumCount += 1;
                }
            }

            txtInfo.Text = "Струнные\tКлавишные\tУдарные";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", stringCount, keyboardCount, drumCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (this.instrumentsList.Count == 0)
            {
                txtOut.Text = "Пусто! ПУСТОТЕНЬ! \nМышь повесилась!";
                return;
            }

            var instrument = this.instrumentsList[0];
            this.instrumentsList.RemoveAt(0);

            txtOut.Text = instrument.GetInfo();

            ShowInfo();
        }
    }
}
