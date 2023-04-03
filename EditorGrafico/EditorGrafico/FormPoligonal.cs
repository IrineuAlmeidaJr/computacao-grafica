using EditorGrafico.models;
using EditorGrafico.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafico
{
    public partial class FormPoligonal : Form
    {
        private int numPoligono;

        private List<Ponto> pontosPoligono;
        private List<Poligono> listaPoligonos;

        private List<Ponto> pontosColoridos;

        private Bitmap _imagem;

        public FormPoligonal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.numPoligono = 1;
            this.pontosPoligono = new List<Ponto>();
            this.listaPoligonos = new List<Poligono>();
            this.pontosColoridos = new List<Ponto>();


            CarregarTela();
        }

        private void CarregarTela()
        {
            int w = pictureBoxPoligono.Height;
            int h = pictureBoxPoligono.Width;
            _imagem =
                new Bitmap(h, w, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(_imagem);
            pictureBoxPoligono.Image = _imagem;

            foreach (var poligono in listaPoligonos)
            {
                poligono.DesenharPoligono(_imagem, pictureBoxPoligono);
            }
        }

        private int PoligonoSelecionado()
        {
            int pos = 0;
            while (pos < listBox.Items.Count && !listBox.GetItemChecked(pos))
            {
                pos++;
            }

            if (pos < listBox.Items.Count)
            {
                return pos;
            }

            return -1;
        }

        private void listBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (listBox.CheckedItems.Count >= 1 && e.CurrentValue != CheckState.Checked)
            {
                e.NewValue = e.CurrentValue;

                MessageBox.Show("Você pode apenas selecionar um item");
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (e.Button == MouseButtons.Right)
            {
                if (pontosPoligono.Count > 2)
                {
                    x = pontosPoligono[0].X;
                    y = pontosPoligono[0].Y;

                    listaPoligonos.Add(new Poligono(pontosPoligono));

                    Poligono poligoAdicionado = listaPoligonos[listaPoligonos.Count - 1];
                    poligoAdicionado.DesenharPoligono(_imagem, pictureBoxPoligono);

                    listBox.Items.Add($"Poligono {numPoligono++}");

                    this.pontosPoligono.Clear();
                }
            }
            else
            {
                pontosPoligono.Add(new Ponto(x, y));
                Ponto.DesenharReta(pontosPoligono, _imagem, pictureBoxPoligono);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int posExcluir = PoligonoSelecionado();
            if (posExcluir != -1)
            {
                listaPoligonos.RemoveAt(posExcluir);
                listBox.Items.RemoveAt(posExcluir);

                CarregarTela();
            }
        }

        private void btnRotacao_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = listaPoligonos[pos];
                try
                {
                    int rotacao = Convert.ToInt32(tbRotacao.Text);
                    int eixoX, eixoY;

                    if (rbCentro.Checked)
                    {
                        // Calcular o Centro 
                        //eixoX = 0;
                        //eixoY = 0;
                        //int[] centroide = poligono.Centroide();
                        //poligono.Translacao(-centroide[0], -centroide[1]);
                        //poligono.Rotacao(rotacao);
                        //poligono.Translacao(centroide[0], centroide[1]);


                        poligono.RotacaoCentro(rotacao);

                    }
                    else if (rbOrigem.Checked)
                    {
                        poligono.Rotacao(rotacao);

                    }
                    else if (rbCoordenada.Checked)
                    {
                        eixoX = Convert.ToInt32(txCordX.Text);
                        eixoY = Convert.ToInt32(txCordY.Text);
                        poligono.RotacaoCentro(rotacao, eixoX, eixoY);
                    }
                    CarregarTela();
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número");
                }
            }
        }

        private void btnTranslacao_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                try
                {
                    int dX = Convert.ToInt32(tbTranslacaoX.Text);
                    int dY = Convert.ToInt32(tbTranslacaoY.Text);

                    Poligono poligono = this.listaPoligonos[pos];
                    poligono.Translacao(dX, dY);

                    CarregarTela();
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número");
                }
            }
        }

        private void btnEscala_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = listaPoligonos[pos];
                try
                {
                    int eixoX, eixoY;
                    double escalaX, escalaY;

                    escalaX = Convert.ToDouble(tbEscalaX.Text);
                    escalaY = Convert.ToDouble(tbEscalaY.Text);

                    if (rbCentro.Checked)
                    {
                        //int[] centroide = poligono.Centroide();
                        //poligono.Translacao(-centroide[0], -centroide[1]);
                        //poligono.Escala(escalaX, escalaY);
                        //poligono.Translacao(centroide[0], centroide[1]);
                        poligono.EscalaCentro(escalaX, escalaY);

                    }
                    else if (rbOrigem.Checked)
                    {
                        // Calcular o Centro 
                        poligono.Escala(escalaX, escalaY);
                    }
                    else if (rbCoordenada.Checked)
                    {
                        eixoX = Convert.ToInt32(txCordX.Text);
                        eixoY = Convert.ToInt32(txCordY.Text);
                        poligono.EscalaCentro(escalaX, escalaY, eixoX, eixoY);
                    }

                    CarregarTela();
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número real");
                }
            }
        }

        private void btnPreencherPoligono_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1 && !comboBox.SelectedIndex.Equals(-1))
            {
                Poligono poligono = listaPoligonos[pos];

                poligono.NomeCor = comboBox.Text;
                poligono.FloodFill(_imagem);

                //poligono.Rasterizacao(pictureBoxPoligono.Height, _imagem);

                CarregarTela();
            }
        }

        private void btnCisalhamento_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = listaPoligonos[pos];
                try
                {
                    double eixoX, eixoY;
                    eixoX = Convert.ToDouble(tbCesilhamentoX.Text);
                    eixoY = Convert.ToDouble(tbCesilhamentoY.Text);

                    if (rbCentro.Checked)
                    {
                        // Calcular o Centro 
                        //eixoX = 0;
                        //eixoY = 0;
                        //int[] centroide = poligono.Centroide();
                        //poligono.Translacao(-centroide[0], -centroide[1]);
                        //poligono.Rotacao(rotacao);
                        //poligono.Translacao(centroide[0], centroide[1]);


                        poligono.CisalhamentoCentro(eixoX, eixoY);

                    }
                    else if (rbOrigem.Checked)
                    {
                        //poligono.Rotacao(rotacao);
                        poligono.Cisalhamento(eixoX, eixoY);

                    }
                    else if (rbCoordenada.Checked)
                    {
                        eixoX = Convert.ToInt32(txCordX.Text);
                        eixoY = Convert.ToInt32(txCordY.Text);
                        poligono.CisalhamentoCentro(eixoX, eixoY);
                    }
                    CarregarTela();
                }
                catch (FormatException)
                {
                    MessageBox.Show("O valor informado deve ser um número");
                }
            }






            //int pos = PoligonoSelecionado();
            //if (pos != -1)
            //{
            //    Poligono poligono = listaPoligonos[pos];
            //    try
            //    {
            //        double eixoX, eixoY;
            //        eixoX = Convert.ToDouble(tbCesilhamentoX.Text);
            //        eixoY = Convert.ToDouble(tbCesilhamentoY.Text);

            //        poligono.Cisalhamento(eixoX, eixoY);

            //        CarregarTela();
            //    }
            //    catch (FormatException)
            //    {
            //        MessageBox.Show("O valor informado deve ser um número real");
            //    }
            //}
        }

        private void btnEspalhamentoX_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = listaPoligonos[pos];
                if (rbCentro.Checked)
                {
                    poligono.Espelhamento("X");
                }
                else if (rbOrigem.Checked)
                {
                    poligono.EspelhamentoOrigem("X");
                }
                else if (rbCoordenada.Checked)
                {

                    poligono.Espelhamento("X");
                }


                CarregarTela();
            }
        }

        private void btnEspalhamentoY_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = listaPoligonos[pos];
                if (rbCentro.Checked)
                {
                    poligono.Espelhamento("Y");
                }
                else if (rbOrigem.Checked)
                {
                    poligono.EspelhamentoOrigem("Y");
                }
                else if (rbCoordenada.Checked)
                {

                    poligono.Espelhamento("Y");
                }


                CarregarTela();
            }
        }

        private void btnEspalhamentoXY_Click(object sender, EventArgs e)
        {
            int pos = PoligonoSelecionado();
            if (pos != -1)
            {
                Poligono poligono = listaPoligonos[pos];
                if (rbCentro.Checked)
                {
                    poligono.Espelhamento("XY");
                }
                else if (rbOrigem.Checked)
                {
                    poligono.EspelhamentoOrigem("XY");
                }
                else if (rbCoordenada.Checked)
                {

                    poligono.Espelhamento("XY");
                }


                CarregarTela();
            }
        }
    }
}
