using System;
using System.Text;
using System.Xml.Xsl;
using NUnit.Framework;

public class Katan
{
    public static string PigIt(string str)
    {
        var words = str.Split(' ');
        var resultedWords = "";
        foreach (var argument in words)
        {
            if (!char.IsLetter(argument[0]))
            {
                resultedWords += argument + " ";
                continue;
            }
            resultedWords += (argument.Substring(1, argument.Length - 1) + argument[0] + "ay" + " ");
        }

        return resultedWords.Substring(0, resultedWords.Length - 1);
    }
}

[TestFixture]
public class KataTest
{
    [Test]
    public void KataTests()
    {
        Assert.AreEqual("igPay atinlay siay oolcay", Katan.PigIt("Pig latin is cool"));
        Assert.AreEqual("hisTay siay ymay tringsay", Katan.PigIt("This is my string"));
    }
}