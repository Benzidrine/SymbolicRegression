using System;
using System.Collections.Generic;
using symbolicregression1.Models;

namespace symbolicregression1.Manager
{
    public class ComputationManager
    {
        public ComputationManager() {}

        public static double Compute(List<Gene> Genes, double x)
        {
            double y = 0;

            foreach(Gene g in Genes)
            {
                switch(g.Operation)
                {
                    case Geneset.Add:
                        y += g.Value;
                        break;
                    case Geneset.AddX:
                        y += x;
                        break;
                    case Geneset.Subtract:
                        y -= g.Value;
                        break;
                    case Geneset.SubtractX:
                        y -= x;
                        break;
                    case Geneset.Multiply:
                        y *= g.Value;
                        break;
                    case Geneset.MultiplyX:
                        y *= x;
                        break;
                    case Geneset.Cosine:
                        y += Math.Cos(x);
                        break;
                    case Geneset.Sine:
                        y += Math.Sin(x);
                        break;
                    default:
                        break;
                }
            }

            return y;
        }
    }
}