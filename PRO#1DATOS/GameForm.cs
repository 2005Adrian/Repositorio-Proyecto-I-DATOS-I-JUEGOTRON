﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace PRO_1DATOS
{
    public partial class GameForm : Form
    {
        private ListaEnlazadaRectangulos listaEnlazada;
        private Jugador jugador;
        private int gridWidth;
        private int gridHeight;

        public GameForm()
        {
            InitializeComponent();
            InicializarJuego();
            this.BackColor = Color.Black;

            // Crear la imagen de la moto programáticamente
            Image motoImagen = CrearImagenMoto(40, 40); // Tamaño de 40x40 píxeles

            // Calcular la posición para que la moto aparezca en el centro inferior del mapa
            int startX = (this.ClientSize.Width / 2) - 20;  // Centro horizontal, ajustado al tamaño de la moto
            int startY = gridHeight - 60; // Cerca del borde inferior de la cuadrícula

            // Crear instancia del jugador en el centro inferior de la cuadrícula
            jugador = new Jugador(startX, startY, motoImagen);

            this.DoubleBuffered = true; // Para reducir el parpadeo durante el movimiento

            // Manejar eventos de teclado
            this.KeyDown += new KeyEventHandler(OnKeyDown);
        }
        

        private void GameForm_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica que quieras ejecutar cuando se cargue GameForm.
        }

        private void InicializarJuego()
        {
            // Definir el tamaño de la cuadrícula en celdas
            int filas = this.ClientSize.Height / 20;
            int columnas = 25; // Ajustar a un tamaño más pequeño, menos ancho

            // Calcular el ancho y alto de la cuadrícula en píxeles
            gridWidth = columnas * 20; // 20 píxeles por celda
            gridHeight = filas * 20;

            // Crear la cuadrícula centrada en el formulario
            int offsetX = (this.ClientSize.Width - gridWidth) / 2; // Centrar horizontalmente
            int offsetY = 0; // No cambiar la posición vertical

            listaEnlazada = new ListaEnlazadaRectangulos(60, 65);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen neonPen = new Pen(Color.Cyan, 2);

            // Dibujar la cuadrícula con el desplazamiento
            foreach (var nodo in listaEnlazada.Matriz)
            {
                e.Graphics.DrawRectangle(neonPen, nodo.Rectangulo);
            }
            // Dibujar la moto
            e.Graphics.DrawImage(jugador.MotoImagen, jugador.X, jugador.Y, 40, 40);

        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            // Mover el jugador según la tecla presionada
            switch (e.KeyCode)
            {
                case Keys.Left:
                    jugador.MoverIzquierda();
                    break;
                case Keys.Right:
                    jugador.MoverDerecha();
                    break;
                case Keys.Up:
                    jugador.MoverArriba();
                    break;
                case Keys.Down:
                    jugador.MoverAbajo();
                    break;
            }

            // Forzar el redibujado del formulario para que la moto se mueva
            Invalidate();
        }

        private Image CrearImagenMoto(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);

                // Dibujar la moto (puedes personalizar el diseño aquí)
                Brush brush = new SolidBrush(Color.Red); // Color de la moto
                g.FillRectangle(brush, 5, 5, width - 10, height - 10); // Un rectángulo en el centro

                // Puedes agregar más detalles a la imagen si lo deseas
            }
            return bmp;
        }
    }
}
