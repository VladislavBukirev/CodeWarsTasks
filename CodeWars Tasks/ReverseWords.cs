using NUnit.Framework;
using System.Collections.Generic;
using System.Text;


namespace Solution
{
    public static class Kata
        {
            public static string ReverseWords(string str)
            {
                var splitedStr = str.Split(' ');
                var words = new List<string>();
                foreach (var phrase in splitedStr)
                {
                    var collectedWord = new StringBuilder();
                    for (var i = phrase.Length - 1; i >= 0; i--)
                        collectedWord.Append(phrase[i]);
                    words.Add(collectedWord.ToString());
                }

                return string.Join(" ", words);
            }
        }
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Example()
        {
            Assert.AreEqual("sihT si na !elpmaxe", Kata.ReverseWords("This is an example!"));
        }
    }
}
