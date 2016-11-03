using System;
using System.Linq;
using System.Text;


namespace Task2
{
    /// <summary>
    /// Class that represent the math polynomial.
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Gets the degree of polynomial.
        /// </summary>
        public int Degree { get; private set; }
        /// <summary>
        /// Gets the coefficients of polynomial.
        /// </summary>
        public long[] Coefficients { get; private set; }
        /// <summary>
        /// Helps to iterate the polynomial.
        /// </summary>
        /// <param name="i"> Helps to seek the right coefficient. </param>
        /// <returns> Returns required coefficient.</returns>
        public long this[int i]
        {
            get { return Coefficients[i]; }
            private set { Coefficients[i] = value; }
        }
        /// <summary>
        /// Constructors each taking different number of parameters
        /// for creating a new polynomial.
        /// </summary>
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
        /// <summary>
        /// Constructor designed to create a new polynomial from an existing one.
        /// </summary>
        /// <param name="oldPolynomial"> Polynomial that helps create new one. </param>
        private Polynomial(Polynomial oldPolynomial)
        {
            if (ReferenceEquals(oldPolynomial, null)) throw new ArgumentNullException();
            Degree = oldPolynomial.Degree;
            Coefficients = new long[Degree];
            oldPolynomial.Coefficients.CopyTo(Coefficients, 0);
        }

        /// <summary>
        /// Supply the correct work the Equals method for the polynomial represented in object.
        /// </summary>
        public override bool Equals(object o)
        {
            if (this is Polynomial && o is Polynomial)
            {
                return ((Polynomial)this).Equals((Polynomial)o);
            }
            return false;
        }
        /// <summary>
        /// Supply the correct work the Equals method for the polynomial.
        /// </summary>
        /// <param name="secondPolynomial"> Polynomial for comparing.</param>
        /// <returns> Boolean value depending on the equality of objects.</returns>
        public bool Equals(Polynomial secondPolynomial)
        {
            if (secondPolynomial.Degree != this.Degree)
            {
                if (this.Degree > secondPolynomial.Degree)
                {
                    for (int i = this.Degree - 1; i > this.Degree - secondPolynomial.Degree; i--)
                    {
                        if (this.Coefficients[i] != 0)
                            return false;
                    }
                }
                else
                {

                    for (int i = secondPolynomial.Degree - 1; i > secondPolynomial.Degree - this.Degree; i--)
                    {
                        if (secondPolynomial.Coefficients[i] != 0)
                            return false;
                    }

                }
            }
            
            for (int i = 0; i < (this.Degree > secondPolynomial.Degree ? secondPolynomial.Degree : this.Degree); i++)
            {
                if (this.Coefficients[i] != secondPolynomial.Coefficients[i])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Returns the hash code for this polynomial.
        /// </summary>
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.Degree; i++)
            {
                hash += this[i].GetHashCode();
            }
            return hash;
        }
        /// <summary>
        /// Returns a string that represents the polynomial.
        /// </summary>
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            int i = this.Degree - 1;


            foreach (var x in this.Coefficients.Reverse())
            {

                if (i > 0)
                {
                    if (x > 0)
                        s.Append($"{x}x^{i} + ");
                    else
                        s.Append($"({x}x^{i}) + ");
                }
                else
                    s.Append($"{x}");

                i--;
            }

            return s.ToString();
        }

        /// <summary>
        /// Operators overloading which enable to properly use the operators for working with polynomials.
        /// </summary>
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
            for (int i = 0; i < (a.Degree > b.Degree ? b.Degree : a.Degree); i++)
            {
                if (b.Coefficients[i] != a.Coefficients[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(Polynomial a, Polynomial b)=>!(a == b);
    
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            Polynomial c;

            if (a.Degree > b.Degree)
            {
                c = new Polynomial(a);

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
        
            if (a.Degree > b.Degree)
            {
                c = new Polynomial(a);

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
            int resultDegree = a.Degree + b.Degree - 1;
            var coefficients = new long[resultDegree];

            c = new Polynomial(coefficients);

            int bigDegree = a.Degree > b.Degree ? a.Degree : b.Degree;
            int smallDegree = a.Degree < b.Degree ? a.Degree : b.Degree;

            if (b.Degree > a.Degree)
                for (int i = 0; i < bigDegree; i++)
                {
                    for (int j = 0; j < smallDegree; j++)
                        c[i + j] += b[i] * a[j];
                }
            else
                for (int i = 0; i < bigDegree; i++)
                {
                    for (int j = 0; j < smallDegree; j++)
                        c[i + j] += a[i] * b[j];
                }

            return c;
        }
    }

}
