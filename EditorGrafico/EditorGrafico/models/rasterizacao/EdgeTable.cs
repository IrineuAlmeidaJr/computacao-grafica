using EditorGrafico.utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditorGrafico.models.rasterizacao
{
    public class EdgeTable
    {
        public List<ItemEdgeTable>[] ET { get; set; }

        public EdgeTable(int maxY)
        {
            ET = new List<ItemEdgeTable>[maxY];
            for (int i=0; i < maxY; i++)
            {
                ET[i] = new List<ItemEdgeTable>();
            }
        }

        public void Inicializar(List<Ponto> pontos)
        {
            double Ymax, Ymin, Xmin, IncX;
            Ponto atual, prox;
            for (int i = 0; i < pontos.Count - 1; i++)
            {
                atual = pontos[i];
                prox = pontos[i + 1];
                if (atual.Y > prox.Y)
                {
                    Ymax = atual.Y;
                    Xmin = prox.X;
                    Ymin = prox.Y;
                    IncX = (atual.X - prox.X) / (atual.Y - prox.Y);
                }
                else
                {
                    Ymax = prox.Y;
                    Xmin = atual.X;
                    Ymin = atual.Y;
                    IncX = (prox.X - atual.X) / (prox.Y - atual.Y);
                }

                Adicionar((int)Ymin, Ymax, Xmin, IncX);
            }

            atual = pontos[0];
            prox = pontos[pontos.Count-1];
            if (atual.Y > prox.Y)
            {
                Ymax = atual.Y;
                Xmin = prox.X;
                Ymin = prox.Y;
                IncX = (atual.X - prox.X) / (atual.Y - prox.Y);
            }
            else
            {
                Ymax = prox.Y;
                Xmin = atual.X;
                Ymin = atual.Y;
                IncX = (prox.X - atual.X) / (prox.Y - atual.Y);
            }

            Adicionar((int)Ymin, Ymax, Xmin, IncX);
        }

        public void Adicionar(int Y, double Ymax, double Xmin, double IncX)
        {
            ET[Y].Add(new ItemEdgeTable(Ymax, Xmin, IncX));
        }

        public void Preencher(Bitmap imagem, Color cor)
        {
            List<ItemEdgeTable> AET = new List<ItemEdgeTable>();
            for (int y = 0; y < ET.Length; y++)
            {
                if (ET[y].Count > 0)
                {
                    foreach (var item in ET[y])
                    {
                        AET.Add(new ItemEdgeTable(item.Ymax, item.Xmin, item.IncX));
                    }

                    // Retirar Ymax == Y
                    for (int pos = 0; pos < AET.Count; pos++)
                    {
                        if (AET[pos].Ymax == y)
                        {
                            AET.RemoveAt(pos);
                        }
                    }
                    // Ordenar pelo Xmin
                    if (ET[y].Count > 0)
                    {
                        AET.Sort((Cx1, Cx2) => Cx1.Xmin.CompareTo(Cx2.Xmin));
                    }
                    // Desenha se tive ao menor 2 caixas
                    for (int pos = 0; pos < AET.Count - 1; pos++)
                    {
                        for (int x = (int)AET[pos].Xmin; x < (int)AET[pos + 1].Xmin; x++)
                        {
                            imagem.SetPixel(x, y, cor);
                        }
                    }
                    // Incrementar o Xmin
                    foreach (var item in AET)
                    {
                        item.Incrementa();
                    }

                }
            }
        }

    }
}
