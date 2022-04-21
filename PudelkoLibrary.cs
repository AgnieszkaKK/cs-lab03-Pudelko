namespace PudelkoLibrary
{
    class Pudelko
    {
        private double a;
        private double b;
        private double c;

        public double A => a;
        public double B => b;
        public double C => c;

       /* public Pudelko(double a, double b, double c)
        {

        }

        public Pudelko()
        {

        }*/
        public Pudelko(double a=10, double b=10, double c=10, UnitOfMeasure unit= UnitOfMeasure.meter)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
        public string ToString(string Format = "")
        {
            return base.ToString();
        }


    }

    public enum UnitOfMeasure
         {
            meter,
            centimeter,
            milimeter

    }

}
