using System;
using System.Drawing;
using System.Windows.Forms;

namespace PRO_1DATOS
{
    public partial class Form1 : Form
    {
        private List<string> items;

        public Form1()
        {
            InitializeComponent();
            items = new List<string>();

        }

        public void button1_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            this.Hide();
            gameForm.FormClosed += (s, args) => this.Show();

        }

        public void transparentButton1_Click(object sender, EventArgs e)
        {
            // Aqu� puedes agregar cualquier funcionalidad espec�fica que quieras para este bot�n.
        }

        public void label1_Click(object sender, EventArgs e)
        {
            // Aqu� puedes agregar la funcionalidad para el clic en label1 si es necesario.
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // L�gica a ejecutar cuando el texto cambie en textBox1
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    public class TransparentButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 255, 255)), this.ClientRectangle); // Esto hace que el fondo sea completamente transparente
        }
    }
}