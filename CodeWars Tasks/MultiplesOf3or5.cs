using NUnit.Framework;

public static class Kata

{
    public static int Solution(int value)
    {
        var result = 0;
        for (var i = 0; i < value; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                result += i;
                continue;
            }
            if (i % 3 == 0)
                result += i;
            if (i % 5 == 0)
                result += i;
        }

        return result;
    }
}

[TestFixture]
public class Tests
{
    [Test]
    public void Test()
    {
        Assert.AreEqual(23, Kata.Solution(10));
    }
}