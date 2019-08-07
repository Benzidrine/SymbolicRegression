namespace symbolicregression1.Models
{
    public class Gene
    {
        public Gene(Geneset operation, double value)
        {
            Operation = operation;
            Value = value;
        }
        public Geneset Operation {get; set;}
        public double Value {get; set;}
    }
}