using NUnit.Framework;
using System.Collections.Generic;

namespace Solution 
{
    public class KataK
    {
        public static int[] MoveZeroes(int[] arr)
        {
            var result = new List<int>();
            var nullCounter = 0;
            foreach (var value in arr)
            {
                if (value == 0)
                {
                    nullCounter++;
                    continue;
                }

                result.Add(value);
            }
            for(var i = 0; i < nullCounter; i++)
                result.Add(0);
            return result.ToArray();
        }
    }

    [TestFixture]
    public class Sample_Test
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}, KataK.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}));
        }
    }
}