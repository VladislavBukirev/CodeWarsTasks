using System;
using NUnit.Framework;

namespace MultiplicationTable
{
    class Solution
    {
        public static int[,] MultiplicationTable(int size)
        {
            var result = new int[size, size];
            for (var i = 0; i < size; i++)
            {
                for(var j = 0; j < size; j++)
                {
                    result[i, j] = (i+1) * (j+1);
                }
            }

            return result;
        }
    }
    
    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MyTest()
        {
            int[,] expected = new int[,]{{1,2,3},{2,4,6},{3,6,9}};
            Assert.AreEqual(expected, Solution.MultiplicationTable(3));
        }
    }
}