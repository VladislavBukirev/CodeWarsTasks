using NUnit.Framework;
namespace PairOfGloves
{
    public class Kata
    {
        public static int NumberOfPairs(string[] gloves)
        {
            var glovesDict = new Dictionary<string, int>();
            foreach (var glove in gloves)
            {
                if (!glovesDict.ContainsKey(glove))
                    glovesDict.Add(glove, 1);
                else
                    glovesDict[glove]++;
            }

            return glovesDict.Sum(glove => glove.Value / 2);
        }
    }

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTests()
        {
            Assertion(0, new string[] { "Green", "Blue", "Purple", "Gray" });
            Assertion(0, new string[] { });
            Assertion(0, new string[] { "Purple" });

            Assertion(1, new string[] { "Blue", "Purple", "Blue", "Gray", "Lime", "Black" });
            Assertion(1, new string[] { "Blue", "Aqua", "Blue", "Teal", "Blue", "Black" });

            Assertion(2, new string[] { "Blue", "Aqua", "Blue", "Brown", "Blue", "Orange", "Aqua" });
        }

        private static void Assertion(int expected, string[] input) =>
            Assert.AreEqual(
                expected,
                Kata.NumberOfPairs(input),
                $"Input: [{string.Join(", ", input)}]"
            );
    }
}