using NUnit.Framework;
using System;

namespace Solution
{
    public class KataSolution
    {
        public static string Expand(string expr)
        {
            var splitedString = expr.Split('^');
            
            var degree = int.Parse(splitedString[1]);
            var cleanInstruction = splitedString[0].Substring(1, splitedString[0].Length - 2);

            var sign = TakeSign(cleanInstruction);

            var arguments = TakeArguments(cleanInstruction, sign);
            var firstArg = arguments[0];
            var secondArg = arguments[1];

            var variable = firstArg[firstArg.Length-1];


            var finalNumbers = new List<string>();

            for (var k = 0; k < degree; k++)
            {
                var binomialCoef = CalculateBinomialCoefficient(degree, k);
                var firstDigit = RaiseToDegree(firstArg, degree - k);
                var secondDigit = RaiseToDegree(secondArg, k);
                var value = MultiplyAruments(firstDigit, secondDigit, binomialCoef);
                finalNumbers.Add(value);
            }
            finalNumbers.Add(RaiseToDegree(secondArg, degree));
            
            var result = "";
            foreach (var number in finalNumbers)
            {
                result += number + "+";
            }

            result = result.Substring(0, result.Length - 1);
            result = result.Replace("++", "+");
            result = result.Replace("+-", "-");
            result = result.Replace("-+", "-");
            result = result.Replace("--", "+");
            return result;
        }
        
        
        private static string MultiplyAruments(string firstArg, string secondArg, int binCoef)
        {
            if (IsOnlyDigitsArgument(firstArg))
                return (int.Parse(firstArg) * int.Parse(secondArg)).ToString();
            if (!char.IsDigit(firstArg[0]) && firstArg[0] != '-')
            {
                var value = binCoef * int.Parse(secondArg);
                if (value == 1)
                    return firstArg;
                return value + firstArg;
            }
            var firstDigit = firstArg.Split('^')[0];
            var variable = firstDigit[^1];
            string degree = "";
            if (firstArg.Split('^').Length > 1)
                degree = firstArg.Split('^')[1];
            firstDigit = firstArg.Substring(0, firstDigit.Length - 1);
            if (!char.IsDigit(firstArg[^1]))
                return binCoef * int.Parse(firstDigit) * int.Parse(secondArg) + variable.ToString();
            return binCoef * int.Parse(firstDigit) * int.Parse(secondArg) + variable.ToString() + "^" + degree;
        }

        private static bool IsOnlyDigitsArgument(string argument)
        {
            var flag = true;
            foreach (var symbol in argument)
            {
                if (!char.IsDigit(symbol))
                    flag = false;
            }

            return flag;
        }
        private static char TakeSign(string expr)
        {
            for(var i = expr.Length-1; i > 0; i--)
                if (expr[i] == '+' || expr[i] == '-')
                    return expr[i];
            throw new ArgumentException();
        }
        
        private static string[] TakeArguments(string expr, char sign)
        {
            var flag = 0;
            for (var i = expr.Length - 1; i > 0; i--)
            {
                var symbol = expr[i];
                if (symbol == sign)
                {
                    flag = i;
                    break;
                }
            }

            if (sign == '+')
            {
                var firstArgAdd = expr.Substring(0, flag);
                var secondArgsAdd = expr.Substring(flag + 1, expr.Length - flag - 1);
                return new[] { firstArgAdd, secondArgsAdd };
            }
            var firstArg = expr.Substring(0, flag);
            var secondArg = expr.Substring(flag, expr.Length - flag);
            return new[] { firstArg, secondArg };
        }
        private static string RaiseToDegree(string value, int degree)
        {
            if (degree == 1)
                return value;
            if (!char.IsDigit(value[value.Length-1]))
            {
                var x = value[value.Length-1].ToString();
                var digit = value.Substring(0, value.Length - 1);
                if (degree == 0)
                    return 1.ToString();
                if (digit == "")
                    return x + "^" + degree;
                return Math.Pow(int.Parse(digit), degree) + x + "^" + degree;
            }

            return Math.Pow(int.Parse(value), degree).ToString();
        }

        private static int CalculateBinomialCoefficient(int n, int k)
            => CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k));


        private static int CalculateFactorial(int digit)
        {
            if (digit == 0)
                return 1;
            var result = 1;
            for (var i = 1; i <= digit; i++)
                result *= i;
            return result;
        }
    }

    [TestFixture]
    public class ExampleTest
    {
        [Test]
        public void testBPositive()
        {
            Assert.AreEqual("1", KataSolution.Expand("(x+1)^0"));
            Assert.AreEqual("x+1", KataSolution.Expand("(x+1)^1"));
            Assert.AreEqual("x^2+2x+1", KataSolution.Expand("(x+1)^2"));
        }

        [Test]
        public void testBNegative()
        {
            Assert.AreEqual("1", KataSolution.Expand("(x-1)^0"));
            Assert.AreEqual("x-1", KataSolution.Expand("(x-1)^1"));
            Assert.AreEqual("x^2-2x+1", KataSolution.Expand("(x-1)^2"));
        }

        [Test]
        public void testAPositive()
        {
            Assert.AreEqual("625m^4+1500m^3+1350m^2+540m+81", KataSolution.Expand("(5m+3)^4"));
            Assert.AreEqual("8x^3-36x^2+54x-27", KataSolution.Expand("(2x-3)^3"));
            Assert.AreEqual("1", KataSolution.Expand("(7x-7)^0"));
        }

        [Test]
        public void testANegative()
        {
            Assert.AreEqual("625m^4-1500m^3+1350m^2-540m+81", KataSolution.Expand("(-5m+3)^4"));
            Assert.AreEqual("-8k^3-36k^2-54k-27", KataSolution.Expand("(-2k-3)^3"));
            Assert.AreEqual("1", KataSolution.Expand("(-7x-7)^0"));
        }
    }
}