using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace img_match
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        int timeLeft = 30;

        Random random = new Random();
        List<string> icons = new List<string>()
    {
        "M", "M", "U", "U", "H", "H", "A", "A",
        "E", "E", "T", "T", "C", "C", "R", "R"
    };
        //private object firstClicked;

        private void AssignIconsToSquares()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                   
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }

            }
        }

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
            Sounds();
            Sounds1();
            Sounds2();
        }

        
        private void label_Click(object sender, EventArgs e)
        {
            Random randomGen = new Random();
          
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {

                if (clickedLabel.ForeColor == Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255)))
                return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));

                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                
                   timer1.Start();
            }
            
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " SANİYE";
                            }
            
            else if (timeLeft == 0)
            {
                timer1.Stop();
                timeLabel.Text = "Z A M A N  D O L D U!";
                MessageBox.Show("B E C E R İ K S İ İ İ Z! P Ü Ü Ü", "AKIL YOKSUNU!");
                
                Close();
            }

        }

        private void Sounds()
        {
            System.Media.SoundPlayer baseSound = new System.Media.SoundPlayer(@"C:\sefect\nowl.wav");
            baseSound.Play();
        }

        private void Sounds1()
        {
            System.Media.SoundPlayer diffSound = new System.Media.SoundPlayer(@"C:\sefect\train.wav");
            //diff.Sound.Play();
        }

        private void Sounds2()
        {
            System.Media.SoundPlayer sameSound = new System.Media.SoundPlayer(@"C:\sefect\shush.wav");
            //sameSound.Play();
        }


        private void CheckForWinner()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }

            }

            MessageBox.Show("A K I L  K Ü P Ü, P Ü Ü. A N A S I N A  Ç E K M İ Ş");
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}