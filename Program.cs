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
            Data.Add(new Tuple<float,float>(0,0.375f));
            Data.Add(new Tuple<float,float>(1,1.123f));
            Data.Add(new Tuple<float,float>(2,0.5f));
            Data.Add(new Tuple<float,float>(3,-0.359f));
            Data.Add(new Tuple<float,float>(4,0.165f));
            Data.Add(new Tuple<float,float>(5,1.078f));
            Data.Add(new Tuple<float,float>(6,0.684f));
            Data.Add(new Tuple<float,float>(7,-0.285f));


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

        //Examine:
        //(sin(x*1.5)+0.5)*0.75
        //Vs:
        //(0+x+sin((x * 1.55200069563091))-x+0.99404109967595+sin((x * 1.44250526998309)))*0.385520038374476
        //Vs:
        //(0+x-x+0.0324822794797282+sin((x * 1.49997493228874))+0.467162608386559)*0.75008695141882
    }
}
