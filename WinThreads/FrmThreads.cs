using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinThreads
{
    public partial class FrmThreads : Form
    {
        Thread hilo;
        delegate void delegado(int valor);
        delegate void otroDelegado(ProgressBar pb, int valor);
        public FrmThreads()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            hilo = new Thread(new ThreadStart(Proceso1));
            hilo.Start();
            hilo = new Thread(new ThreadStart(Proceso2));
            hilo.Start();
            hilo = new Thread(new ThreadStart(Proceso3));
            hilo.Start();
        }

        private void Proceso(object? parametro)
        {
            int numero = (int)parametro;
            for (int i = 0; i <= 100; i++)
            {
                otroDelegado MD = new otroDelegado(Actualizar);
                this.Invoke(MD, new object[] { pb1, i });
                Thread.Sleep(numero);
            }
        }

        private void Proceso1()
        {
            for (int i = 0; i <= 100; i++)
            {
                delegado MD = new delegado(Actualizar1);
                this.Invoke(MD, new object[] { i });
                Thread.Sleep(70);
            }
        }

        private void Proceso2()
        {
            for (int i = 0; i <= 100; i++)
            {
                delegado MD = new delegado(Actualizar2);
                this.Invoke(MD, new object[] { i });
                Thread.Sleep(40);
            }
        }

        private void Proceso3()
        {
            for (int i = 0; i <= 100; i++)
            {
                delegado MD = new delegado(Actualizar3);
                this.Invoke(MD, new object[] { i });
                Thread.Sleep(100);
            }
        }

        private void Actualizar(ProgressBar pb, int valor)
        {
            pb.Value = valor;
        }

        private void Actualizar1(int valor)
        {
            pb1.Value = valor;
        }

        private void Actualizar2(int valor)
        {
            pb2.Value = valor;
        }

        private void Actualizar3(int valor)
        {
            pb3.Value = valor;
        }
    }
}
