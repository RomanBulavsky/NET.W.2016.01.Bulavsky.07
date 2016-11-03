using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Polynomial
    {
        public int Degree { get; private set; }
        public long[] Coefficients { get; private set; }
        public long this[int i]
        {
            get { return Coefficients[i]; }
            private set { Coefficients[i] = value; }
        }

        public Polynomial(long coefficient1)
        {
            Degree = 1;
            Coefficients = new long[1];
            Coefficients[0] = coefficient1;
        }
        public Polynomial(long coefficient1, long coefficient2)
        {
            Degree = 2;
            Coefficients = new long[2];
            Coefficients[0] = coefficient1;
            Coefficients[1] = coefficient2;
        }
        public Polynomial(long coefficient1, long coefficient2, long coefficient3)
        {
            Degree = 3;
            Coefficients = new long[3];
            Coefficients[0] = coefficient1;
            Coefficients[1] = coefficient2;
            Coefficients[2] = coefficient3;

        }
        public Polynomial(params long[] coefficients)
        {
            if(ReferenceEquals(coefficients, null))throw new ArgumentNullException();
            Degree = coefficients.Length;//
            Coefficients = coefficients;
        }
        public Polynomial(Polynomial x)
        {
            if (ReferenceEquals(x, null)) throw new ArgumentNullException();
            Degree = x.Degree;
            Coefficients = new long[Degree];
            x.Coefficients.CopyTo(Coefficients, 0);
        }

        public override bool Equals(object o)
        {
            if (this is Polynomial && o is Polynomial)
            {
                return ((Polynomial)this).Equals((Polynomial)o);
            }
            return false;
        }
        public bool Equals(Polynomial o)
        {
            if (o.Degree != this.Degree)
            {
                if (this.Degree > o.Degree)
                {
                    for (int i = this.Degree - 1; i > this.Degree - o.Degree; i--)
                    {
                        if (this.Coefficients[i] != 0)
                            return false;
                    }
                }
                else
                {

                    for (int i = o.Degree - 1; i > o.Degree - this.Degree; i--)
                    {
                        if (o.Coefficients[i] != 0)
                            return false;
                    }

                }
            }
            //Degree

            for (int i = 0; i < (this.Degree > o.Degree ? o.Degree : this.Degree); i++)
            {
                if (this.Coefficients[i] != o.Coefficients[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Degree; i++)
            {
                hash += this[i].GetHashCode();
            }
            return hash;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            int i = this.Degree - 1;


            foreach (var x in this.Coefficients.Reverse())
            {

                if (i > 0)
                {
                    if (x > 0)
                    {
                        //s.Append(x);
                        s.Append($"{x}x^{i} + ");
                    }
                    else
                    {

                        //s.Append(x);
                        s.Append($"({x}x^{i}) + ");
                    }


                }
                else
                    s.Append($"{x}x^{i}");

                i--;
            }

            return s.ToString();
        }


        public static bool operator ==(Polynomial a, Polynomial b)
        {
            if (a.Degree != b.Degree)
            {
                if (b.Degree > a.Degree)
                {
                    for (int i = b.Degree - 1; i > b.Degree - a.Degree; i--)
                    {
                        if (b.Coefficients[i] != 0)
                            return false;
                    }
                }
                else
                {

                    for (int i = a.Degree - 1; i > a.Degree - b.Degree; i--)
                    {
                        if (a.Coefficients[i] != 0)
                            return false;
                    }

                }
            }
            //Degree
            for (int i = 0; i < (a.Degree > b.Degree ? b.Degree : a.Degree); i++)
            {
                if (b.Coefficients[i] != a.Coefficients[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(Polynomial a, Polynomial b)
        {
            if (a.Degree != b.Degree)
            {
                if (b.Degree > a.Degree)
                {
                    for (int i = b.Degree - 1; i > b.Degree - a.Degree; i--)
                    {
                        if (b.Coefficients[i] != 0)
                            return true;
                    }
                }
                else
                {

                    for (int i = a.Degree - 1; i > a.Degree - b.Degree; i--)
                    {
                        if (a.Coefficients[i] != 0)
                            return true;
                    }

                }
            }
            //Degree
            for (int i = 0; i < (a.Degree > b.Degree ? b.Degree : a.Degree); i++)
            {
                if (b.Coefficients[i] != a.Coefficients[i])
                    return true;
            }
            return false;
        }
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            Polynomial c;
            //int resultDegree = a.Degree > b.Degree ? a.Degree : b.Degree;
            if (a.Degree > b.Degree)
            {
                c = new Polynomial(a);
                //c = new Polynomial(a.Coefficients);
                for (int i = 0; i < b.Degree; i++)
                {
                    c[i] -= b[i];
                }
            }
            else
            {
                c = new Polynomial(b);
                for (int i = 0; i < a.Degree; i++)
                {
                    c[i] -= a[i];
                }
            }

            return c;
        }
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            Polynomial c;
            //int resultDegree = a.Degree > b.Degree ? a.Degree : b.Degree;
            if (a.Degree > b.Degree)
            {
                c = new Polynomial(a);
                //c = new Polynomial(a.Coefficients);
                for (int i = 0; i < b.Degree; i++)
                {
                    c[i] += b[i];
                }
            }
            else
            {
                c = new Polynomial(b);
                for (int i = 0; i < a.Degree; i++)
                {
                    c[i] += a[i];
                }
            }

            return c;
        }
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            Polynomial c;
            int resultDegree = a.Degree + b.Degree - 1;//TODO
            var cof = new long[resultDegree];
            //cof = default(long[]);
            c = new Polynomial(cof);

            int bigDegree = a.Degree > b.Degree ? a.Degree : b.Degree;
            int smallDegree = a.Degree < b.Degree ? a.Degree : b.Degree;

            if (b.Degree > a.Degree)
                for (int i = 0; i < bigDegree; i++)
                {
                    for (int j = 0; j < smallDegree; j++)
                        c[i + j] += b[i] * a[j];//
                }
            else
                for (int i = 0; i < bigDegree; i++)
                {
                    for (int j = 0; j < smallDegree; j++)
                        c[i + j] += a[i] * b[j];//
                }



            return c;
        }
    }

}
