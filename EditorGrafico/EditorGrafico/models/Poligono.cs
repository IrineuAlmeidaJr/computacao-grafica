using EditorGrafico.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorGrafico.models
{
    public class Poligono
    {
        public List<Ponto> PontosOriginais { get; set; }
        public List<Ponto> Pontos { get; set; }

        public double[,] MatrizAcumulada { get; set; }

        public Poligono(List<Ponto> pontos)
        {
            Pontos = new List<Ponto>(pontos);
            PontosOriginais = new List<Ponto>(pontos);
            this.MatrizAcumulada = new double[3,3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                this.MatrizAcumulada[i, i] = 1;
            }
        }

        public void DesenharPoligono(Bitmap imagem, PictureBox pictureBoxPoligono)
        {
            if (this.Pontos.Count > 1)
            {
                int ate = this.Pontos.Count - 1;
                for (int i = 0; i < ate; i++)
                {
                    Ponto.PontoMedio(this.Pontos[i].X, this.Pontos[i].Y,
                    this.Pontos[i + 1].X, this.Pontos[i + 1].Y, imagem);
                }

                pictureBoxPoligono.Image = imagem;
            }

        }

        public double[] Centroide()
        {
            double cX, cY;
            cX = cY = 0;
            foreach (var ponto in PontosOriginais)
            {
                cX += ponto.X;
                cY += ponto.Y;
            }
            cX /= PontosOriginais.Count;
            cY /= PontosOriginais.Count;

            return new double[2] { cX , cY };
        }

        public void MatrizAcumuladaPontos()
        {
            int x, y;
            Pontos.Clear();
            foreach (var ponto in PontosOriginais)
            {
                x = (int)(ponto.X * MatrizAcumulada[0, 0] + ponto.Y * MatrizAcumulada[0, 1] + MatrizAcumulada[0, 2]);
                y = (int)(ponto.X * MatrizAcumulada[1, 0] + ponto.Y * MatrizAcumulada[1, 1] + MatrizAcumulada[1, 2]);
                Pontos.Add(new Ponto(x, y));
            }
        }

        public void Rotacao(int graus)
        {
            double radiano = (Math.PI / 180) * graus;
            double[,] matrizRotacao;
            matrizRotacao = new double[3, 3];
            double[,] novaMatrizAcumulada;
            novaMatrizAcumulada = new double[3, 3];
            // Matriz Acumulada
            for (int i = 0; i < 3; i++)
            {
                matrizRotacao[i, i] = 1;
            }
            // Matriz Rotacao
            matrizRotacao[0, 0] = Math.Cos(radiano);
            matrizRotacao[0, 1] = -Math.Sin(radiano);
            matrizRotacao[1, 0] = Math.Sin(radiano);
            matrizRotacao[1, 1] = Math.Cos(radiano);

            // Nova_Matriz = R * MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizRotacao[linha, i] * MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();
        }

        
        public void RotacaoCentro(int graus, double eixoX=0, double eixoY=0)
        {
            double[] coordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                coordenadasXY = Centroide();
            }
            else
            {
                coordenadasXY = new double[] { eixoX, eixoY };
            }            
            double radiano = (Math.PI / 180) * graus;
            double[,] matrizRotacao = new double[3,3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide= new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];

            // Matriz Identidade
            for (int i=0; i < 3; i++)
            {
                matrizRotacao[i, i] = 1;
                matrizTranslacao_origem[i, i] = 1;
                matrizTranslacao_centroide[i, i] = 1;
            }

            matrizRotacao[0,0] = Math.Cos(radiano);
            matrizRotacao[0,1] = -Math.Sin(radiano);
            matrizRotacao[1,0] = Math.Sin(radiano);
            matrizRotacao[1,1] = Math.Cos(radiano);

            matrizTranslacao_origem[0,2] = -coordenadasXY[0];
            matrizTranslacao_origem[1,2] = -coordenadasXY[1];

            matrizTranslacao_centroide[0, 2] = coordenadasXY[0];
            matrizTranslacao_centroide[1, 2] = coordenadasXY[1];


            // MA_Nova = T(cent) * R * T(ori) * P(MA)
            // matrizResultante_1 = T(cent) * R 
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_1[linha, coluna] += matrizTranslacao_centroide[linha,i] * matrizRotacao[i, coluna];
                    }                        
                }
            }
            // matrizResultante_2 = matrizResultante_1 * T(ori)
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_2[linha, coluna] += matrizResultante_1[linha, i] * matrizTranslacao_origem[i, coluna];
                    }
                }
            }
            // Nova Matriz Acumulada
            // Nova_MatrizAcumulada = matrizResultante_2 * MatrizAcumulada
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante_2[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }
            
            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();


        }

        public void Translacao(int dX, int dY)
        {
            double[,] matrizTranslacao = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizTranslacao[i, i] = 1;
            }
            // Matriz Translação
            matrizTranslacao[0, 2] = dX;
            matrizTranslacao[1, 2] = dY;
            //  NovaMA = T * MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizTranslacao[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();

        }

        public void Escala(double sX, double sY)
        {
            double[,] matrizEscala = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizEscala[i, i] = 1;
            }
            // Matriz Escala
            matrizEscala[0, 0] = sX;
            matrizEscala[1, 1] = sY;
            //  NovaMA = E * MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizEscala[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();

        }

        public void EscalaCentro(double sX, double sY, int eixoX = 0, int eixoY = 0)
        {
            double[] cordenadasXY;
            if (eixoX == 0 && eixoY == 0)
            {
                cordenadasXY = Centroide();
            }
            else
            {
                cordenadasXY = new double[] { eixoX, eixoY };
            }

            double[,] matrizEscala = new double[3, 3];
            double[,] matrizTranslacao_origem = new double[3, 3];
            double[,] matrizTranslacao_centroide = new double[3, 3];
            double[,] matrizResultante_1 = new double[3, 3];
            double[,] matrizResultante_2 = new double[3, 3];
            double[,] novaMatrizAcumulada = new double[3, 3];

            double[,] matrizAcumulada = new double[3, 1];
            // Matriz Identidade
            for (int i = 0; i < 3; i++)
            {
                matrizEscala[i, i] = 1;
                matrizTranslacao_origem[i, i] = 1;
                matrizTranslacao_centroide[i, i] = 1;
            }

            matrizEscala[0, 0] = sX;
            matrizEscala[1, 1] = sY;

            matrizTranslacao_origem[0, 2] = -cordenadasXY[0]; // X
            matrizTranslacao_origem[1, 2] = -cordenadasXY[1]; // Y

            matrizTranslacao_centroide[0, 2] = cordenadasXY[0]; // X
            matrizTranslacao_centroide[1, 2] = cordenadasXY[1]; // Y


            // NovaMA = T(cent) * E * T(ori) * MA
            // matrizResultante_1 = T(cent) * E
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_1[linha, coluna] += matrizTranslacao_centroide[linha, i] * matrizEscala[i, coluna];
                    }
                }
            }
            // matrizResultante_2 = matrizResultante_1 *  T(ori)
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        matrizResultante_2[linha, coluna] += matrizResultante_1[linha, i] * matrizTranslacao_origem[i, coluna];
                    }
                }
            }
            // NovaMA = matrizResultante_2 *  MA
            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        novaMatrizAcumulada[linha, coluna] += matrizResultante_2[linha, i] * this.MatrizAcumulada[i, coluna];
                    }
                }
            }

            this.MatrizAcumulada = novaMatrizAcumulada;

            MatrizAcumuladaPontos();


        }



    }
}
