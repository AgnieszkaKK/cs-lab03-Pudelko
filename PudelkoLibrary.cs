using System;
using System.Collections.Generic;

namespace PudelkoLibrary
{
    class Pudelko :IFormattable
    {
        private long a;
        private long b;
        private long c;
        private UnitOfMeasure unit;

        public double A => calculate_To_Scale(UnitOfMeasure.meter, a);
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

        public double B => calculate_To_Scale(UnitOfMeasure.meter, b);
        public double C => calculate_To_Scale(UnitOfMeasure.meter, c);

        public double Objetosc => Math.Round(A * B * C, 9);
        public double Pole => Math.Round(2 * ((A * B) + (A * C) + (B * C)), 6);
       

        public Pudelko(double a=double.NaN , double b= double.NaN, double c= double.NaN, UnitOfMeasure unit= UnitOfMeasure.meter)
        {
            this.unit = unit;
            if(double.IsNaN(a))
            {
                this.a = 100;
            }
            else 
            {
                long _a = calculate_To_Milimeters(a);

                if (_a > 0 && _a <= 10000) { this.a = _a; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            if (double.IsNaN(b))
            {
                this.b = 100;
            }
            else
            {
                long _b = calculate_To_Milimeters(b);

                if (_b > 0 && _b <= 10000) { this.b = _b; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            if (double.IsNaN(c))
            {
                this.c = 100;
            }
            else
            {
                long _c = calculate_To_Milimeters(c);

                if (_c > 0 && _c <= 10000) { this.c = _c; }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private long calculate_To_Milimeters(double value)
        {
            if(UnitOfMeasure.meter.Equals(this.unit))
            {
                return (long)(value * 1000);
            }
            else if(UnitOfMeasure.centimeter.Equals(this.unit))
            {
                return (long)(value * 10);
            }
            else 
            {
                return (long)value;
            }
        }
        private double calculate_To_Scale(long value)
        {
            return calculate_To_Scale(this.unit, value);
        }
        /*private string getScale()
        {
            if (meter)
            {
                return "m";
            }
            else if(centimeter)
        {
         return "cm";
        }
        else
        {
            "mm";
        }
        }*/
        public override string ToString()
        {
           return this.ToString("m");

        }

        public string ToString(string format, IFormatProvider formatProvider=null)
        {
            if(format==null)
            {
                return this.ToString();
            }

            if(format.Equals("m"))
            {
                return String.Format("{0:N3} m × {1:N3} m × {2:N3} m",
                    calculate_To_Scale(UnitOfMeasure.meter, this.a),
                    calculate_To_Scale(UnitOfMeasure.meter, this.b),
                    calculate_To_Scale(UnitOfMeasure.meter, this.c));
            }
            else if (format.Equals("cm"))
                {
                    return String.Format("{0:N1} cm × {1:N1} cm × {2:N1} cm",
                    calculate_To_Scale(UnitOfMeasure.centimeter, this.a),
                    calculate_To_Scale(UnitOfMeasure.centimeter, this.b),
                    calculate_To_Scale(UnitOfMeasure.centimeter, this.c));
                }
            else if(format.Equals("mm"))
            {
                return String.Format("{0} mm × {1} mm × {2} mm",
                    calculate_To_Scale(UnitOfMeasure.milimeter, this.a),
                    calculate_To_Scale(UnitOfMeasure.milimeter, this.b),
                    calculate_To_Scale(UnitOfMeasure.milimeter, this.c));
            }

            throw new FormatException();
        }

        private double calculate_To_Scale(UnitOfMeasure unit, long value)
        {
            if (UnitOfMeasure.meter.Equals(unit))
            {
                return ((double)value) / 1000;
            }
            else if (UnitOfMeasure.centimeter.Equals(unit))
            {
                return ((double)value) / 10;
            }
            else
            {
                return (double)value;
            }
        }

        public override bool Equals(object obj)
        {
            if(this == obj)
            { return true; }
            
            if(!(obj is Pudelko))
            {
                return false;
            }

            Pudelko other = (Pudelko)obj;
            
            HashSet<long> edges = new HashSet<long>();
            edges.Add(this.a);
            edges.Add(this.b);
            edges.Add(this.c);

            HashSet<long> other_edges = new HashSet<long>();
            other_edges.Add(other.a);
            other_edges.Add(other.b);
            other_edges.Add(other.c);
            return edges.SetEquals(other_edges)
            && this.unit == other.unit;
        }

        public static bool operator == (Pudelko p1, Pudelko p2)
        {
            if(p1==null && p2==null)
            { return true; }

            if (p1== null)
            {
                return false;
            }

            return p1.Equals(p2);
        }
        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            if (p1 == null && p2 == null)
            { return false; }

            if (p1 == null)
            {
                return true;
            }

            return !p1.Equals(p2);
        }
    }

    //IFormatable
    public enum UnitOfMeasure
         {
            meter,
            centimeter,
            milimeter

    }

}
