using System;
using System.Collections.Generic;
using symbolicregression1.Models;

namespace SymbolicRegression1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set up initial Data Points
            List<Tuple<float,float>> Data = new List<Tuple<float, float>>();
            Data.Add(new Tuple<float,float>(1,3.83f));
            Data.Add(new Tuple<float,float>(2,3.909f));
            Data.Add(new Tuple<float,float>(3,3.141f));
            Data.Add(new Tuple<float,float>(4,2.23f));
            Data.Add(new Tuple<float,float>(5,2.041f));


            string Command = Console.ReadLine();
            if (Command == "run")
            {
                double OptimalFitness = 0;
                Chromosome BestParent = new Chromosome();
                BestParent.GenerateParent(6);
                Console.WriteLine(BestParent.Display());
                for (int i = 0; i < 10000000; i++)
                {
                    Chromosome child = BestParent.Clone();
                    child.Mutate();
                    if (child.GetFitness(Data) > BestParent.GetFitness(Data))
                    {
                        Console.WriteLine("Child Fitness: " + child.GetFitness(Data) + " Parent Fitness " + BestParent.GetFitness(Data));
                        BestParent = child.Clone();
                        Console.WriteLine(BestParent.Display() + " Fitness: " + BestParent.GetFitness(Data));
                        if (OptimalFitness == BestParent.GetFitness(Data))
                            break;
                    }
                }
            }
        }

        
    }
}
