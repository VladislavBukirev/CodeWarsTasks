using NUnit.Framework;
using System;

public class Katann
{
    public static int ConsonantCount(string str)
    {
        var vowels = "aeiou";
        var counter = 0;
        foreach (var letter in str)
        {
            if(vowels.Contains(letter) || !char.IsLetter(letter))
                continue;
            counter++;
        }
        return counter;
    }
}
[TestFixture]
public class Testss
{
    [Test]
    [TestCase("", ExpectedResult=0)]
    [TestCase("aaaaa", ExpectedResult=0)]
    [TestCase("Bbbbb", ExpectedResult=5)]
    [TestCase("helLo world", ExpectedResult=7)]
    [TestCase("h^$&^#$&^elLo world", ExpectedResult=7)]
    [TestCase("012456789", ExpectedResult=0)]
    [TestCase("012345_Cb", ExpectedResult=2)]
    public static int FixedTest(string s)
    {
        return Katann.ConsonantCount(s);
    }
}