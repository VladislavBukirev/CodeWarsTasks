using NUnit.Framework;
using System.Collections.Generic;

namespace Solution
{
    public class KataTask
    {
        public static int SumNoDuplicates(int[] arr)
        {
            var valuesDict = new Dictionary<int, int>();
            foreach (var value in arr)
            {
                if (!valuesDict.ContainsKey(value))
                    valuesDict.Add(value, 1);
                else
                    valuesDict[value]++;
            }
            var sum = 0;
            foreach (var uniqueValues in valuesDict)
            {
                if (uniqueValues.Value == 1)
                    sum += uniqueValues.Key;
            }

            return sum;
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MyTest()
        {
            Assert.AreEqual(5, KataTask.SumNoDuplicates(new int[] { 1, 1, 2, 3 }));
            Assert.AreEqual(3, KataTask.SumNoDuplicates(new int[] { 1, 1, 2, 2, 3 }));
        }
    }
}