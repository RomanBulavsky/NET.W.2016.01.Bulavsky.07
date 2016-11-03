using System;
using NUnit.Framework;


namespace Task2.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
       
        public static object[] Data()
        {
            object[][] data = new object[3][];
            
            data[0] = new object[6];
            data[0][0] = new Polynomial(1, 2);
            data[0][1] = new Polynomial(1, 2);
            data[0][2] = new Polynomial(2, 4);//Sum
            data[0][3] = new Polynomial(0, 0);//Sub
            data[0][4] = new Polynomial(1, 4, 4);//Mul
            data[0][5] = true;//Equals*/
            
            data[1] = new object[6];
            data[1][0] = new Polynomial(-4, 2);
            data[1][1] = new Polynomial(1, 2, 3);
            data[1][2] = new Polynomial(-3, 4, 3);//Sum
            data[1][3] = new Polynomial(5,0,3);//Sub
            data[1][4] = new Polynomial(-4,-6,-8,6);//Mul
            data[1][5] = false;//Equals*/
            
            data[2] = new object[6];
            data[2][0] = new Polynomial(1, 2, 0);
            data[2][1] = new Polynomial(1, 2);
            data[2][2] = new Polynomial(2, 4, 0);
            data[2][3] = new Polynomial(0,0,0);
            data[2][4] = new Polynomial(1,4,4, 0);//Mul
            data[2][5] = true;//Equals*/

            return data;
           

        }
        //[TestCaseParameters(new Polynomial(1,2), new Polynomial(1,2), new Polynomial(2,4))]
        [Test, TestCaseSource(nameof(Data))]
        public void Addition_TwoPolynomial_ExpectedResultPolynomial(params object[] args)
        {
            Polynomial a = (Polynomial) args[0];
            Polynomial b = (Polynomial)args[1];
            Polynomial result = (Polynomial)args[2];
            Assert.AreEqual(a+b,result);
            //Console.WriteLine(xxx);

        }

        [Test, TestCaseSource(nameof(Data))]
        public void Subtraction_TwoPolynomial_ExpectedResultPolynomial(params object[] args)
        {
            Polynomial a = (Polynomial)args[0];
            Polynomial b = (Polynomial)args[1];
            Polynomial result = (Polynomial)args[3];
            Assert.AreEqual(a-b,result);
        }


        [Test, TestCaseSource(nameof(Data))]
        public void Multiplication_TwoPolynomial_ExpectedResultPolynomial(params object[] args)
        {
            Polynomial a = (Polynomial)args[0];
            Polynomial b = (Polynomial)args[1];
            Polynomial result = (Polynomial)args[4];
            Assert.AreEqual(a * b, result);

        }
        [Test, TestCaseSource(nameof(Data))]
        public void Comparison_TwoPolynomial_ExpectedBoolResult(params object[] args)
        {
            Polynomial a = (Polynomial)args[0];
            Polynomial b = (Polynomial)args[1];
            bool result = (bool)args[5];
            Assert.AreEqual(a == b, result);
        }
        [Test, TestCaseSource(nameof(Data))]
        public void ComparisonViaEquals_TwoPolynomial_ExpectedBoolResult(params object[] args)
        {
            Polynomial a = (Polynomial) args[0];
            Polynomial b = (Polynomial) args[1];
            bool result = (bool) args[5];
            Assert.AreEqual(a.Equals(b),result);
        }

        [TestCase("2x^1 + 1", 1, 2)]
        [TestCase("3x^2 + 2x^1 + 1", 1, 2, 3)]
        [TestCase("13x^2 + (-2x^1) + 1", 1, -2, 13)]
        public void PolynomialToString_PolynomialArgs_ExpectedString(string expected, params long[] args)
        {
            Polynomial pol = new Polynomial(args);
            Assert.AreEqual(pol.ToString(), expected);
        }

        [TestCase(null)]
        public void PolynomialCtor_BadArgs_Exception(long[] args)
        {
            
            Assert.That(() => new Polynomial(args), Throws.TypeOf<ArgumentNullException>());
        }

    }
}
