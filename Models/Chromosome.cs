using System;
using System.Collections.Generic;
using symbolicregression1.Manager;

namespace symbolicregression1.Models
{
    public class Chromosome
    {
        List<Gene> genes {get; set;}
        //Generates a random parent with length being the number of operations
        public void GenerateParent(int Length)
        {
            genes = new List<Gene>();
            for(int i = 0; i < Length; i++)
            {
                genes.Add(GenerateGene());
            }
        }
        public Chromosome Clone()
        {
            Chromosome chromosome = new Chromosome();
            chromosome.genes = new List<Gene>();
            foreach(Gene g in genes)
                chromosome.genes.Add(new Gene(g.Operation,g.Value));
            return chromosome;
        }

        public Gene GenerateGene()
        {
            Random rnd = new Random();
            //Get number of values defined in Gene Set
            int GenesetCount = Enum.GetNames(typeof(Geneset)).Length;
            //Random value between 0 - 2
            double geneValue = (rnd.NextDouble() * 2);
            //Get random sample from Geneset
            Geneset geneset = (Geneset)rnd.Next(0,GenesetCount);
            return new Gene(geneset,geneValue);
        }
 
        public void Mutate()
        {
            Random rnd = new Random();
            int Index = rnd.Next(0,genes.Count);
            genes[Index] = GenerateGene();
        }

        public double GetFitness(List<Tuple<Single,Single>> LineValues)
        {
            double Fitness = 0;
            foreach (var item in LineValues)
            {
                Fitness -= Math.Abs((item.Item2 - ComputationManager.Compute(genes,item.Item1)));
            }
            return Fitness;
        }

        public string Display ()
        {
            string Result = "";
            //Prefix allows for brackets which correct the order of operations for the statement 
            string Prefix = "";
            foreach (Gene g in genes)
            {
                switch(g.Operation)
                {
                    case Geneset.Add:
                        Result += "+" + g.Value;
                        break;
                    case Geneset.AddX:
                        Result += "+x";
                        break;
                    case Geneset.Subtract:
                        Result += "-" + g.Value;
                        break;
                    case Geneset.SubtractX:
                        Result += "-x";
                        break;
                    case Geneset.Multiply:
                        Prefix += "(";
                        Result += ")*" + g.Value;
                        break;
                    case Geneset.MultiplyX:
                        Prefix += "(";
                        Result += ")*x";
                        break;
                    case Geneset.Cosine:
                        Result += "+cos((x * " + g.Value + "))";
                        break;
                    case Geneset.Sine:
                        Result += "+sin((x * " + g.Value + "))";
                        break;
                    default:
                        break;
                }
            }

            return Prefix + "0" + Result;
        }
    }
}