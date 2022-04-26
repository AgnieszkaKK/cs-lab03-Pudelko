using System;

namespace PudelkoLibrary
{
    class Pudelko
    {
        private double a;
        private double b;
        private double c;
        private UnitOfMeasure unit;

        public double A => calculate_To_Scale(a);
        /* public double A
          { 
              get{ return calculate_To_Scale(a);}
              

          public double B
          { 
              get{ return b;}
             } 
              
        public double C
        { 
            get{ return c;}
            
            }

         */

        public double B => calculate_To_Scale(b);
        public double C => calculate_To_Scale(c);

       

        public Pudelko(double a=double.NaN , double b= double.NaN, double c= double.NaN, UnitOfMeasure unit= UnitOfMeasure.meter)
        {
            this.unit = unit;
            if(Double.IsNaN(a))
            {
                this.a = 100;
            }
            else 
            {
                double _a = calculate_To_Milimeters(a);

                if (_a > 0 && _a <= 10000) { this.a = _a; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            if (Double.IsNaN(b))
            {
                this.b = 100;
            }
            else
            {
                double _b = calculate_To_Milimeters(b);

                if (_b > 0 && _b <= 10000) { this.b = _b; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            if (Double.IsNaN(c))
            {
                this.c = 100;
            }
            else
            {
                double _c = calculate_To_Milimeters(c);

                if (_c > 0 && _c <= 10000) { this.c = _c; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private double calculate_To_Milimeters(double value)
        {
            if(UnitOfMeasure.meter.Equals(this.unit))
            {
                return value * 1000;
            }
            else if(UnitOfMeasure.centimeter.Equals(this.unit))
            {
                return value * 10;
            }
            else 
            {
                return value;
            }
        }
        private double calculate_To_Scale(double value)
        {
            if(UnitOfMeasure.meter.Equals(this.unit))
            {
                return value/1000;
            }
            else if(UnitOfMeasure.centimeter.Equals(this.unit))
            {
                return value/10;
            }
            else
            {
                return value;
            }
        }
        public override string ToString()
        {
            return base.ToString();
            //Console.WriteLine($"{a} {unit} \u00D7 {b} {unit} \u00D7 {c} {unit}")
        }
        public string ToString(string Format = "{a} {unit} \u00D7 {b} {unit} \u00D7 {c} {unit}")
        {
            /*if(UnitOfMeasure=meter)
            { String.Format("{0:#,#.000}", a)}*/
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
